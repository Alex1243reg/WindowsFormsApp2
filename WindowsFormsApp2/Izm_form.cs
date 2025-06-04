using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace WindowsFormsApp2
{
    public partial class Izm_form : Form
    {
        private string recordId;
        public Izm_form(string id, string name, string price, string status)
        {
            InitializeComponent();
            recordId = id;
            textBox1.Text = name;
            textBox2.Text = price;
            textBox3.Text = status;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (!int.TryParse(textBox2.Text, out int ratting) || ratting < 0)
            {
                MessageBox.Show("Price не может быть отрицательным", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            DB db = new DB();

            string query = "UPDATE `admins` SET `Name` = @name, `Price` = @price, `Starus` = @status WHERE `id` = @id";
            MySqlCommand command = new MySqlCommand(query, db.GetConnection());
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = textBox1.Text;
            command.Parameters.Add("@price", MySqlDbType.Int64).Value = textBox2.Text;
            command.Parameters.Add("@status", MySqlDbType.VarChar).Value = textBox3.Text;
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = Convert.ToInt32(recordId);
            db.OpenConnection();
            try
            {
                if (command.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Тип обновлён!");
                    this.Hide();
                    Form1 form1 = new Form1();
                    form1.Show();
                }
                else
                    MessageBox.Show("Тип не обновлён!");
            }
            finally
            {
                db.CloseConnection();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }
    }
}
