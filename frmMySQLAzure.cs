using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFAConnectToMySql.Models;

namespace WFAConnectToMySql
{
    public partial class frmMySQLAzure : Form
    {
        private MySqlManage oMySQL = null;
        private MySqlConnectionStringBuilder builder = null;
        private string _Server = string.Empty;
        private string  _Database = string.Empty;
        private string  _UserID = string.Empty;
        private string _KeyVaultName = string.Empty;
        private string _SecretName = string.Empty;

        public frmMySQLAzure()
        {
            InitializeComponent();
        }

        private void frmMySQLAzure_Load(object sender, EventArgs e)
        {
            // Client with IP address '93.35.219.145' is not allowed to connect to this MySQL server
            // https://docs.microsoft.com/en-us/azure/mysql/concepts-firewall-rules
            // https://portal.azure.com/#@3be9add1-f9f0-44e0-b01c-fa585c33b214/resource/subscriptions/aa67cdae-2fc0-41d1-bd24-694d92814576/resourceGroups/az400m07l01-RG/providers/Microsoft.DBforMySQL/servers/hotel-coupon-mgmt8f30b2c2/connectionSecurity

            // dall' Azure CLI
            // mysql --host mydemoserver.mysql.database.azure.com --database testdb --user db_user@mydemoserver -p
            // mysql --host hotel-coupon-mgmt8f30b2c2.mysql.database.azure.com --database testdb --user azureuser@hotel-coupon-mgmt8f30b2c2 -p
            // https://docs.microsoft.com/en-us/cli/azure/mysql/db?view=azure-cli-latest#az_mysql_db_create
            // az mysql db create -g testgroup -s testsvr -n testdb
            // az mysql db create -g az400m07l01-RG -s hotel-coupon-mgmt8f30b2c2.mysql.database.azure.com -n testdb
            textBoxResult.Text = string.Empty;
            oMySQL = new MySqlManage();
            
            labelDGVResult.Text = string.Empty;

            _Server = System.Configuration.ConfigurationManager.AppSettings["Server"];
            _Database = System.Configuration.ConfigurationManager.AppSettings["Database"];
            _UserID = System.Configuration.ConfigurationManager.AppSettings["UserID"];
            _KeyVaultName = System.Configuration.ConfigurationManager.AppSettings["KeyVaultName"];
            _SecretName = System.Configuration.ConfigurationManager.AppSettings["SecretName"];

            // https://az400lab07keyvault.vault.azure.net/
            //textBoxKeyVaultName.Text = "az400lab07keyvault";
            //textBoxSecretName.Text = "sqldbpassword";

            textBoxKeyVaultName.Text = _KeyVaultName;
            textBoxSecretName.Text = _SecretName;
        }

        private async void btnCreateTable_Click(object sender, EventArgs e)
        {
            string connectionStringMySql = string.Empty;
            
            try 
            {
                this.Enabled = false;
                labelDGVResult.Text = string.Empty;
                dataGridViewResult.DataSource = null;

                textBoxResult.Text = string.Empty;
                connectionStringMySql = getConnectionStringAsync(_Database).Result;

                string tableName = "inventory";
                
                await oMySQL.CreateTableInventory(connectionStringMySql, tableName);
                textBoxResult.Text = string.Format("ConnectionString: {0}{2}Table Name: {1}", connectionStringMySql, tableName, Environment.NewLine);
                this.Enabled = true;
            }
            catch (Exception ex)
            {
                string sErr = string.Format("Source: {0} - Message: {1} - StackTrace: {2}", ex.Source, ex.Message, ex.StackTrace);
                textBoxResult.Text = sErr;
                this.Enabled = true;
            }
        }

        private async void btnReadData_Click(object sender, EventArgs e)
        {
            string connectionStringMySql = string.Empty;
            string query = string.Empty;
            List<Inventory> listInventory = null;
            try
            {
                this.Enabled = false;
                textBoxResult.Text = string.Empty;
                labelDGVResult.Text = string.Empty;
                dataGridViewResult.DataSource = null;

                connectionStringMySql = await getConnectionStringAsync("testdb");

                query = "SELECT * FROM inventory;";     // LASCIARE il ; ALLA FINE DELLO STATEMENT
                
                listInventory = await oMySQL.getData(connectionStringMySql, query);
                dataGridViewResult.DataSource = listInventory;
                labelDGVResult.Text = string.Format("Num. record(s): {0}", listInventory.Count);
                textBoxResult.Text = string.Format("ConnectionString: {0}{2}query: {1}", connectionStringMySql, query, Environment.NewLine);
                this.Enabled = true;
            }
            catch (Exception ex)
            {
                string sErr = string.Format("Source: {0} - Message: {1} - StackTrace: {2}", ex.Source, ex.Message, ex.StackTrace);
                textBoxResult.Text = sErr;
                this.Enabled = true;
            }
            
        }

        private async void btnReadFromSchema_Click(object sender, EventArgs e)
        {
            string connectionStringMySql = string.Empty;
            string query = string.Empty;
            List<string> listTables = null;
            try
            {
                this.Enabled = false;
                textBoxResult.Text = string.Empty;
                labelDGVResult.Text = string.Empty;
                dataGridViewResult.DataSource = null;

                connectionStringMySql = await getConnectionStringAsync("information_schema");

                query = "SELECT table_name FROM information_schema.tables WHERE table_schema = 'testdb';";     // LASCIARE il ; ALLA FINE DELLO STATEMENT
               
                listTables = await oMySQL.getFromSchema(connectionStringMySql, query);

                // How to bind a List<string> to a DataGridView control?
                // https://stackoverflow.com/questions/479329/how-to-bind-a-liststring-to-a-datagridview-control
                // dataGridViewResult.DataSource = listTables;

                // IList<String> list_string = new List<String>();

                // dataGridViewResult.DataSource = listTables.Select(x => new { Value = x }).ToList();
                dataGridViewResult.DataSource = listTables.Select(x => new { TableName = x }).ToList();
                labelDGVResult.Text = string.Format("Num. table(s): {0}", listTables.Count);
                textBoxResult.Text = string.Format("ConnectionString: {0}{2}query: {1}", connectionStringMySql, query, Environment.NewLine);
                this.Enabled = true;
            }
            catch (Exception ex)
            {
                string sErr = string.Format("Source: {0} - Message: {1} - StackTrace: {2}", ex.Source, ex.Message, ex.StackTrace);
                textBoxResult.Text = sErr;
                this.Enabled = true;
            }
        }

        private async void btnReadKeyVault_Click(object sender, EventArgs e)
        {
            string keyVaultName = string.Empty;
            string secretName = string.Empty;
            string secretValue = string.Empty;
            // https://docs.microsoft.com/en-us/azure/key-vault/secrets/quick-create-net
            try
            {
                this.Enabled = false;
                labelDGVResult.Text = string.Empty;
                dataGridViewResult.DataSource = null;
                textBoxResult.Text = string.Empty;

                keyVaultName = textBoxKeyVaultName.Text; // Environment.GetEnvironmentVariable("KEY_VAULT_NAME");
                secretName = textBoxSecretName.Text;
                secretValue = await getSecretFromKeyVault(keyVaultName, secretName);
                textBoxResult.Text = string.Format("KeyVaultName: {0} - secret Name: {1} - secret Value: {2}", keyVaultName, secretName, secretValue);
                this.Enabled = true;
            }
            catch (Exception ex)
            {
                string sErr = string.Format("Source: {0} - Message: {1} - StackTrace: {2}", ex.Source, ex.Message, ex.StackTrace);
                textBoxResult.Text = sErr;
                this.Enabled = true;
            }
        }

        private async Task<string> getSecretFromKeyVault(string keyVaultName, string secretName)
        {
            string secretValue = string.Empty;
            try 
            {
                // https://docs.microsoft.com/en-us/azure/key-vault/secrets/quick-create-net
                var kvUri = "https://" + keyVaultName + ".vault.azure.net";

                var client = new SecretClient(new Uri(kvUri), new DefaultAzureCredential());
                var secret = await client.GetSecretAsync(secretName);
                secretValue = secret.Value.Value;
            }
            catch (Exception ex)
            {
                string sErr = string.Format("Source: {0} - Message: {1} - StackTrace: {2}", ex.Source, ex.Message, ex.StackTrace);
                textBoxResult.Text = sErr;
            }
            return secretValue;
        }

        private async Task<string> getConnectionStringAsync(string databasemysql)
        {
            string connectionStringMySql = string.Empty;
            string pwd = await getSecretFromKeyVault(_KeyVaultName, _SecretName);
            builder = new MySqlConnectionStringBuilder
            {
                Server = _Server,
                Database = databasemysql,
                UserID = _UserID,
                Password = pwd,
                SslMode = MySqlSslMode.Required,
            };
            connectionStringMySql = builder.ConnectionString;
            return connectionStringMySql;
        }

    }
}
