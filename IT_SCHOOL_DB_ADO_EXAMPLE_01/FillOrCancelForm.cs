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

        // поле для збереження значення ID поля замовлення
        private int parsedOrderID;

        /// <summary>
        /// Перевіряємо що ID замолення внесено в поле та задовольняє всім умовам
        /// </summary>
        /// <returns></returns>
        private bool IsOrderIDValid()
        {
            // Перевіряємо що ID в полі для введення не є пустим
            if (txtOrderID.Text == "")
            {
                MessageBox.Show("Визначте будь-ласка ID-замовлення");
                return false;
            }
   
            // Перевіряємо що в полі ми вводимо цифри
            else if (Regex.IsMatch(txtOrderID.Text, @"^\D*$"))
            {
                // виводимо повідомлення та очищаємо поле від некоректного виведення
                MessageBox.Show("ID повинен містити тільки цифри");
                txtOrderID.Clear();
                return false;
            }
            else
            {
                // конвертуємо текст в полі для введення в Int для відправки в базу даних
                parsedOrderID = Int32.Parse(txtOrderID.Text);
                return true;
            }
        }


        private void btnFindByOrderID_Click(object sender, EventArgs e)
        {
            if (IsOrderIDValid())
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConnString))
                {
                    // Визначаємо t-SQL запит. Сам запит в якості параметра приймає orderID
                    const string sql = "SELECT * FROM Sales.Orders WHERE orderID = @orderID";

                    // Створємо об'єкт команди необхідний для виконання запиту
                    using (SqlCommand sqlCommand = new SqlCommand(sql, connection))
                    {
                        // визначаємо @orderID в якості вхідного параметру виществореного запиту у змінній sql
                        sqlCommand.Parameters.Add(new SqlParameter("@orderID", SqlDbType.Int));
                        sqlCommand.Parameters["@orderID"].Value = parsedOrderID;

                        try
                        {
                            connection.Open();
                            
                            // 1) - ВІД'ЄДНАНИЙ РЕЖИМ (ПІДКЛЮЧАЄМОСЬ, ЗАБИРАЄМО ВСЕ, ВІДКЛЮЧАЄМОСЬ, ПРАЦЮЄМО ІЗ ДАНИМИ)

                            // БУДЕМО РЕАЛЫЗОВУВАТИ

                            // 2) - ПІДКЛЮЧЕНИЙ РЕЖИМ (ПІДКЛЮЧИЛИСЬ І ПРАЦЮЄМО ІЗ БД НАПРЯМУ)
                            // РОЗБЕРЕМО

                            // Запускаємо на виконання вищесконфігурований запит на основі команди ExecuteReader()
                            using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                            {
                                // Створення таблиці даних
                                DataTable dataTable = new DataTable();

                                // Заливаємо у DataTable (спосіб представлення таблиці через клас) всі дані через SqlDataReader
                                dataTable.Load(dataReader);

                                // Відображаємо дані із dataTable у елементі DataGridView на самій формі
                                this.dgvCustomerOrders.DataSource = dataTable;

                                // Закриваємо SqlDataReader
                                dataReader.Close();
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Шукаєме замовлення не може бути завантажене у форму.");
                        }
                        finally
                        {
                            // Закриваємо підключення
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
                // Створюємо підключення
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConnString))
                {
                    // Створюємо команду SqlCommand та ідентифікуємо збережувану процедуру на виконання
                    using (SqlCommand sqlCommand = new SqlCommand("Sales.uspCancelOrder", connection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;

                        //додаємо ID замовлення в якості вхідного параметру збережуваної процедури
                        sqlCommand.Parameters.Add(new SqlParameter("@orderID", SqlDbType.Int));
                        sqlCommand.Parameters["@orderID"].Value = parsedOrderID;

                        try
                        {
                            // Відкриваємо підключення
                            connection.Open();
                            // Запускаємо на виконання збережувану процеудуру
                            sqlCommand.ExecuteNonQuery();
                        }
                        catch
                        {
                            MessageBox.Show("Операція скасування замовлення не була завершена.");
                        }
                        finally
                        {
                            // Закриваємо підключення
                            connection.Close();
                        }
                    }
                }
            }

        }

        private void btnFillOrder_Click(object sender, EventArgs e)
        {
            if (IsOrderIDValid())
            {
                // Створюємо підключення
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConnString))
                {
                    // Створюємо команду та ідентифікуємо збережувану процедуру для виконання
                    using (SqlCommand sqlCommand = new SqlCommand("Sales.uspFillOrder", connection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;

                        // додаємо ID замовлення в якості вхідного параметру збережуваної процедури
                        sqlCommand.Parameters.Add(new SqlParameter("@orderID", SqlDbType.Int));
                        sqlCommand.Parameters["@orderID"].Value = parsedOrderID;

                        // додаємо дату підтвердження замовлення в якості вхідного параметру збережуваної процедури
                        sqlCommand.Parameters.Add(new SqlParameter("@FilledDate", SqlDbType.DateTime, 8));
                        sqlCommand.Parameters["@FilledDate"].Value = dtpFillDate.Value;

                        try
                        {
                            connection.Open();

                            // запускаємо збережувану процедуру
                            sqlCommand.ExecuteNonQuery();
                        }
                        catch
                        {
                            MessageBox.Show("The fill operation was not completed.");
                        }
                        finally
                        {
                            // закриваємо відключення
                            connection.Close();
                        }
                    }
                }
            }
        }

        private void btnFinishUpdates_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
