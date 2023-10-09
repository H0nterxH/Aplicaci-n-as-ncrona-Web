using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm1 : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Inicialmente, el GridView está vacío.
                GridView1.DataSource = null;
                GridView1.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-PTBLD39\\SQLEXPRESS;Initial Catalog=AdventureWorks2012;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"
                    SELECT
                        po.PurchaseOrderID,
                        po.VendorID,
                        pod.ProductID,
                        pod.UnitPrice,
                        pod.StockedQty,     
                    (SELECT Name FROM Purchasing.ShipMethod WHERE ShipMethodID = po.ShipMethodID) AS ShipMethodName,
                    (SELECT ShipBase FROM Purchasing.ShipMethod WHERE ShipMethodID = po.ShipMethodID) AS ShipBase
                    FROM Purchasing.PurchaseOrderDetail AS pod
                    INNER JOIN Purchasing.PurchaseOrderHeader AS po ON pod.PurchaseOrderID = po.PurchaseOrderID
                    WHERE po.VendorID = 1662;";

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                GridView1.DataSource = dataTable;
                GridView1.DataBind();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-PTBLD39\\SQLEXPRESS;Initial Catalog=AdventureWorks2012;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"
                    SELECT 
                    po.PurchaseOrderID,
                    po.VendorID,
                    po.SubTotal,
                    pod.UnitPrice,
                    pod.OrderQty,
                    p.ProductID,
                    p.Name AS ProductName,
                    p.Color,
                    v.Name AS VendorName,
                    v.AccountNumber
                FROM Purchasing.PurchaseOrderHeader AS po
                INNER JOIN Purchasing.PurchaseOrderDetail AS pod ON po.PurchaseOrderID = pod.PurchaseOrderID
                INNER JOIN Production.Product AS p ON pod.ProductID = p.ProductID
                INNER JOIN Purchasing.Vendor AS v ON po.VendorID = po.VendorID
                WHERE po.VendorID BETWEEN 1568 AND 1572;";

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                GridView1.DataSource = dataTable;
                GridView1.DataBind();
            }
        }
    }
}
