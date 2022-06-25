using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IT_SCHOOL_DB_ADO_EXAMPLE_01
{
    public partial class FillOrCancelForm : Form
    {
        public FillOrCancelForm()
        {
            InitializeComponent();
        }

        private int parsedOrderID;

        private bool IsOrderIDValid()
        {
            if (txtOrderID.Text == "")
            {
                MessageBox.Show("Визначте будь-ласка ID-замовлення");
                return false;
            }

            else if (Regex.IsMatch(txtOrderID.Text, @"^\D*$"))
            {
                MessageBox.Show("ID повинен містити тільки цифри");
                txtOrderID.Clear();
                return false;
            }

            else
            {
                parsedOrderID = Int32.Parse(txtOrderID.Text);
                return true;
            }
        }

        private void btnFindByOrderID_Click(object sender, EventArgs e)
        {
            if (IsOrderIDValid())
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.connString))
                {
                    const string sql = "SELECT * FROM Sales.Orders WHERE orderID = @orderID";

                    using (SqlCommand sqlCommand = new SqlCommand(sql, connection))
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("@orderID", SqlDbType.Int));
                        sqlCommand.Parameters["@orderID"].Value = parsedOrderID;

                        try
                        {
                            connection.Open();

                            using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                            {
                                DataTable dataTable = new DataTable();

                                dataTable.Load(dataReader);

                                this.dgvCustomerOrders.DataSource = dataTable;

                                dataReader.Close();
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Шукаєме замовлення не може бути завантажене у форму.");
                        }
                        finally
                        {
                            connection.Close();
                        }
                    }
                }
            }
        }


        private void btnCancelOrder_Click(object sender, EventArgs e)
        {
            if (IsOrderIDValid())
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.connString))
                {
                    using (SqlCommand sqlCommand = new SqlCommand("Sales.uspCancelOrder", connection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;

                        sqlCommand.Parameters.Add(new SqlParameter("@orderID", SqlDbType.Int));
                        sqlCommand.Parameters["@orderID"].Value = parsedOrderID;

                        try
                        {
                            connection.Open();

                            sqlCommand.ExecuteNonQuery();

                            MessageBox.Show("Операція скасування замовлення успішно завершена. Оновіть");
                        }
                        catch
                        {
                            MessageBox.Show("Операція скасування замовлення не була завершена.");
                        }
                        finally
                        {
                            connection.Close();
                        }
                    }
                }
            }
        }

        private void btnFillOrder_Click(object sender, EventArgs e)
        {

        }

        private void btnFinishUpdates_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
