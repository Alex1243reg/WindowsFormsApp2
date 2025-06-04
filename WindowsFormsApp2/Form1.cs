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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddForm addform = new AddForm();
            addform.Show();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        public void LoadData()
        {
            DB db = new DB();

            DataTable table = new DataTable();

            try
            {
                db.OpenConnection();
                using (MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM `admins`",db.GetConnection()))
                {
                    adapter.Fill(table);
                }
                dataGridView1.DataSource = table;
            }
            catch (Exception ex) 
            {
                MessageBox.Show($"Ошибка {ex.Message}");
            }
            finally
            {
                db.CloseConnection();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите строку для редактирования!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int rowIndex = dataGridView1.SelectedRows[0].Index;
            string id = dataGridView1["id", rowIndex].Value.ToString();
            string name = dataGridView1["Name", rowIndex].Value.ToString();
            string price = dataGridView1["Price", rowIndex].Value.ToString();
            string status = dataGridView1["Starus", rowIndex].Value.ToString();

            // Переход на форму редактирования
            this.Hide();
            Izm_form editForm = new Izm_form(id, name, price, status);
            editForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Istoria istoria = new Istoria();
            istoria.Show();
        }
    }
}
