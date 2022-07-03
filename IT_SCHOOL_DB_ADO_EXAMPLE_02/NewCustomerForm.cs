using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace IT_SCHOOL_DB_ADO_EXAMPLE_01
{
    public partial class NewCustomerForm : Form
    {
        public NewCustomerForm()
        {
            InitializeComponent();
        }

        // поля для збереження ID із таблиць бази даних
        private int parsedCustomerID; 
        private int orderID;

        /// <summary>
        /// Перевіряємо чи поле для введення імені користувача не є пустим
        /// </summary>
        /// <returns></returns>
        private bool IsCustomerNameValid()
        {
            if (txtCustomerName.Text == "")
            {
                MessageBox.Show("Введіть, будь-ласка ім'я");
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Перевіряємо щоб ID покупця та замовлення було введено
        /// </summary>
        /// <returns></returns>
        private bool IsOrderDataValid()
        {
            // перевіряємо щоб CustomerID було веедено
            if (txtCustomerID.Text == "")
            {
                MessageBox.Show("Будь-ласка створіть спочатку аккаунт перед створенням замовлення.");
                return false;
            }
            //перевіряємо щоб кількість одиниць товару при замовленні біла більше 0.
            else if ((numOrderAmount.Value < 1))
            {
                MessageBox.Show("Будь-ласка визначіть кількість");
                return false;
            }
            else
            {
                // якщо замовлення створене.
                return true;
            }
        }

        /// <summary>
        /// чистимо форму
        /// </summary>
        private void ClearForm()
        {
            txtCustomerName.Clear();
            txtCustomerID.Clear();
            dtpOrderDate.Value = DateTime.Now;
            numOrderAmount.Value = 0;
            this.parsedCustomerID = 0;
        }

        /// <summary>
        /// Створюємо нового покупця шляхом виклику збережуваної процедури Sales.uspNewCustomer із бази даних
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            if (IsCustomerNameValid())
            {
                // створення подключення.
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConnString))
                {
                    // створення SqlCommand, ідентифікація зебережуваної процедури.
                    using (SqlCommand sqlCommand = new SqlCommand("Sales.uspNewCustomer", connection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;

                        // додаємо вхіднрий параметр (він використовується збережуваною процедурою) і визначає виличину яку ми передамо в базу
                        sqlCommand.Parameters.Add(new SqlParameter("@CustomerName", SqlDbType.NVarChar, 40));
                        sqlCommand.Parameters["@CustomerName"].Value = txtCustomerName.Text;

                        // додаємо вихідний параметр
                        sqlCommand.Parameters.Add(new SqlParameter("@CustomerID", SqlDbType.Int));
                        sqlCommand.Parameters["@CustomerID"].Direction = ParameterDirection.Output;

                        try
                        {
                            connection.Open();

                            // запускаємо збережувану процедуру
                            sqlCommand.ExecuteNonQuery();

                            // Customer ID що повертається із бази даних
                            this.parsedCustomerID = (int)sqlCommand.Parameters["@CustomerID"].Value;

                            // встановлюємо значення Customer ID у відповідне поле форми
                            this.txtCustomerID.Text = Convert.ToString(parsedCustomerID);
                        }
                        catch
                        {
                            MessageBox.Show("ID покупця не може бути повернутий. Аккаунт не може бути створений");
                        }
                        finally
                        {
                            connection.Close();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Викликаємо збережувану процедуру Sales.uspPlaceNewOrder для створення замовлення
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            // валідуємо присутність необхідних даних
            if (IsOrderDataValid())
            {
                //створюємо підключення
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConnString))
                {
                    // створємо SqlCommand та ідентифікуємо збережувану процедуру що повинна виконатись
                    using (SqlCommand sqlCommand = new SqlCommand("Sales.uspPlaceNewOrder", connection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;

                        // додаємо @CustomerID в якості взідного параметру,  which was obtained from uspNewCustomer.
                        sqlCommand.Parameters.Add(new SqlParameter("@CustomerID", SqlDbType.Int));
                        sqlCommand.Parameters["@CustomerID"].Value = this.parsedCustomerID;

                        // Додаємо @OrderDate в якості вхідного параметру збережуваної процедури
                        sqlCommand.Parameters.Add(new SqlParameter("@OrderDate", SqlDbType.DateTime, 8));
                        sqlCommand.Parameters["@OrderDate"].Value = dtpOrderDate.Value;

                        // Додаємо @Amount в яксоті вхідного параметру збережуваної процедури
                        sqlCommand.Parameters.Add(new SqlParameter("@Amount", SqlDbType.Int));
                        sqlCommand.Parameters["@Amount"].Value = numOrderAmount.Value;

                        // Додаємо @Status в якості вхідного параметру процедури, це статус замовлення
                        // Для нового замовлення це - О (open).
                        sqlCommand.Parameters.Add(new SqlParameter("@Status", SqlDbType.Char, 1));
                        sqlCommand.Parameters["@Status"].Value = "O";

                        // додаємо повертаєму величину в якості відповідного параметру, по факту це ID.
                        sqlCommand.Parameters.Add(new SqlParameter("@RC", SqlDbType.Int));
                        sqlCommand.Parameters["@RC"].Direction = ParameterDirection.ReturnValue;

                        try
                        {
                            //відкривємо підключення
                            connection.Open();

                            // запускаємо на виконання збережувану процедуру
                            sqlCommand.ExecuteNonQuery();

                            // відображаємо номер замовлення та статус
                            this.orderID = (int)sqlCommand.Parameters["@RC"].Value;
                            MessageBox.Show("Замовлення № " + this.orderID + " було створено.");
                        }
                        catch
                        {
                            MessageBox.Show("Замовлення не може бути створено.");
                        }
                        finally
                        {
                            connection.Close();
                        }
                    }
                }
            }
        }

        private void btnAddAnotherAccount_Click(object sender, EventArgs e)
        {
            this.ClearForm();
        }

        private void btnAddFinish_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
