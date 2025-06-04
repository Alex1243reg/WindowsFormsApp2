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

namespace WindowsFormsApp2
{
    public partial class AddForm : Form
    {
        public AddForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DB db = new DB();

            string query = "INSERT INTO `admins` (`Name`, `Price`, `Starus`) VAlUES (@name, @price, @status)";
            MySqlCommand command = new MySqlCommand(query, db.GetConnection());
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = textBox1.Text;
            command.Parameters.Add("@price", MySqlDbType.Int64).Value = textBox2.Text;
            command.Parameters.Add("@status", MySqlDbType.VarChar).Value = textBox3.Text;

            db.OpenConnection();

            try
            {
                if (command.ExecuteNonQuery() > 0)
                    MessageBox.Show("Тип создан!");
                else
                    MessageBox.Show("Тип не создан!");
            }
            finally
            {
                db.CloseConnection();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы хотите выйти с этого окна?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if(result == DialogResult.Yes)
            {
                this.Hide();
                Form1 form1 = new Form1();
                form1.Show();
            }
        }
    }
}
