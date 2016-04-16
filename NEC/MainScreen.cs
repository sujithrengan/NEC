using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;

namespace NEC
{
    public partial class MainScreen : Form
    {
        public static SQLiteConnection m_dbConnection;
        public void DatabaseConnect()
        {
            //m_dbConnection = new SQLiteConnection("Data Source="+Application.StartupPath.ToString()+"\\DB\\DatabaseName.db;Version=3;");
            m_dbConnection = new SQLiteConnection("Data Source=C:\\NEC\\DB\\DatabaseName.db;Version=3;");
            //MessageBox.Show("Data Source=" + Application.StartupPath.ToString() + "\\DB\\DatabaseName.db;Version=3;");
            m_dbConnection.Open();
        }
        public MainScreen()
        {
            InitializeComponent();
            DatabaseConnect();
        }

        private void add_customer_Click(object sender, EventArgs e)
        {
            AddCustomer add = new AddCustomer();
            add.Show();
        }

        private void view_customers_Click(object sender, EventArgs e)
        {
            ViewTransactions viewCust = new ViewTransactions();
            viewCust.Show();
        }

        private void add_transaction_Click(object sender, EventArgs e)
        {
            new Add_Transaction().Show();
        }

        private void button_pro_Click(object sender, EventArgs e)
        {
            new AddProduct().Show();
        }

        private void view_transactions_Click(object sender, EventArgs e)
        {
            new TranscationsView().Show();
        }

        

    }
}
