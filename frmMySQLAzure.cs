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
            builder = new MySqlConnectionStringBuilder
            {
                //Server = "YOUR-SERVER.mysql.database.azure.com",
                //Database = "YOUR-DATABASE",
                //UserID = "USER@YOUR-SERVER",
                //Password = "PASSWORD",
                Server = "hotel-coupon-mgmt8f30b2c2.mysql.database.azure.com",
                Database = "testdb",
                UserID = "azureuser@hotel-coupon-mgmt8f30b2c2",
                Password = "Patrizio01",
                SslMode = MySqlSslMode.Required,
            };

            labelDGVResult.Text = string.Empty;

            textBoxResult.Text = string.Format("MySql ConnectionString: {0}{1}", Environment.NewLine, builder.ConnectionString);
        }

        private async void btnCreateTable_Click(object sender, EventArgs e)
        {
            try 
            {
                textBoxResult.Text = string.Empty;
                await oMySQL.CreateTableInventory(builder.ConnectionString);
            }
            catch (Exception ex)
            {
                string sErr = string.Format("Source: {0} - Message: {1} - StackTrace: {2}", ex.Source, ex.Message, ex.StackTrace);
                textBoxResult.Text = sErr;
            }
        }

        private async void btnReadData_Click(object sender, EventArgs e)
        {
            string query = string.Empty;
            List<Inventory> listInventory = null;
            try
            {
                labelDGVResult.Text = string.Empty;
                textBoxResult.Text = string.Empty;
                query = "SELECT * FROM inventory;";     // LASCIARE il ; ALLA FINE DELLO STATEMENT
                listInventory = await oMySQL.getData(builder.ConnectionString, query);
                dataGridViewResult.DataSource = listInventory;
                labelDGVResult.Text = string.Format("Num. record(s): {0}", listInventory.Count);
            }
            catch (Exception ex)
            {
                string sErr = string.Format("Source: {0} - Message: {1} - StackTrace: {2}", ex.Source, ex.Message, ex.StackTrace);
                textBoxResult.Text = sErr;
            }
        }

        private async void btnReadGuest_Click(object sender, EventArgs e)
        {
            string query = string.Empty;
            List<Inventory> listInventory = null;
            try
            {
                builder = new MySqlConnectionStringBuilder
                {
                    // https://stackoverflow.com/questions/8334493/get-table-names-using-select-statement-in-mysql
                    //Server = "YOUR-SERVER.mysql.database.azure.com",
                    //Database = "YOUR-DATABASE",
                    //UserID = "USER@YOUR-SERVER",
                    //Password = "PASSWORD",
                    Server = "hotel-coupon-mgmt8f30b2c2.mysql.database.azure.com",
                    Database = "information_schema",
                    UserID = "azureuser@hotel-coupon-mgmt8f30b2c2",
                    Password = "Patrizio01",
                    SslMode = MySqlSslMode.Required,
                };

                labelDGVResult.Text = string.Empty;
                textBoxResult.Text = string.Empty;
                query = "SELECT table_name FROM information_schema.tables WHERE table_schema = 'hotel-coupon';";     // LASCIARE il ; ALLA FINE DELLO STATEMENT
                listInventory = await oMySQL.getFromGuest(builder.ConnectionString, query);
                dataGridViewResult.DataSource = listInventory;
                labelDGVResult.Text = string.Format("Num. record(s): {0}", listInventory.Count);
            }
            catch (Exception ex)
            {
                string sErr = string.Format("Source: {0} - Message: {1} - StackTrace: {2}", ex.Source, ex.Message, ex.StackTrace);
                textBoxResult.Text = sErr;
            }
        }
    }
}
