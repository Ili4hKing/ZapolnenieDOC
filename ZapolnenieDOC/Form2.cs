using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZapolnenieDOC
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            using (IDbConnection connection = new SqlConnection())
            {

            }
            using (TexnikymBDEntities db = new TexnikymBDEntities())
            {

                db.ШаблонГруппы.Load();

                dataGridView1.DataSource = db.ШаблонГруппы.Local.ToBindingList();

                db.Студенты2.Load();

                dataGridView2.DataSource = db.Студенты2.Local.ToBindingList();

            }
        }

            private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 rr = new Form1();
            rr.Show();
        }
    }
}
