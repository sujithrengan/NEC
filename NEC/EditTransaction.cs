using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;

namespace NEC
{
    public partial class EditTransaction : Form
    {
        DataSet ds;
        CustomerTransaction mForm;
        ViewTransactions vForm;
        int oldamt;
        string olddate;

        public EditTransaction(CustomerTransaction mForm,ViewTransactions vForm, int refid,int amt, int type, string date, string product,string remarks)
        {

            InitializeComponent();
            this.oldamt = amt;
            this.mForm = mForm;
            this.olddate = date;
            dateTimePicker1.Value = System.DateTime.Parse(date);
            textBox1.Text = refid.ToString();
            textBox2.Text = (amt*type).ToString();
            textBox3.Text = remarks;
            SQLiteCommand command;
            SQLiteDataAdapter adapter = new SQLiteDataAdapter();

            ds = new DataSet();
            string sql = null;
            sql = "select ID,Name from Products";
            command = new SQLiteCommand(sql, MainScreen.m_dbConnection);
            adapter.SelectCommand = command;
            adapter.Fill(ds);
            adapter.Dispose();
            command.Dispose();
            comboBox3.DataSource = ds.Tables[0];

            comboBox3.ValueMember = "ID";
            comboBox3.DisplayMember = "Name";

            //MessageBox.Show(type + "");
            if (type == 1) comboBox2.SelectedIndex = 0;
            else
                comboBox2.SelectedIndex = 1;

            for (int i = 0; i < ds.Tables[0].Rows.Count;i++ )
            {

                if (ds.Tables[0].Rows[i]["Name"].ToString() == product)
                    comboBox3.SelectedIndex = i;
            }

        }

        private void EditTransaction_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int amt = 0;
            int id = 0;
            int type = 1;
            string date = "";
            id = Int32.Parse(textBox1.Text.ToString());
            if (textBox2.Text.ToString()!= "")
                amt = Int32.Parse(textBox2.Text.ToString());
            if (comboBox2.SelectedIndex==0)
                type=1;
            else
                type=-1;

            date = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string remarks = textBox3.Text.ToString();
            amt = (amt * type);
            if (type == 1)
            {
                try
                {
                    string sql = "update Transactions set ID=" + id + ", Amount=" + (amt) + ",Type=" + type + ",Remarks='" + remarks + "',Date='" + date + "',Product='" + ds.Tables[0].Rows[comboBox3.SelectedIndex]["Name"].ToString() + "' where ID=" + id + "";
                    SQLiteCommand command;
                    command = new SQLiteCommand(sql, MainScreen.m_dbConnection);
                    command.ExecuteNonQuery();




                    mForm.setData();


                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Update errorin Customer Trans\n" + ex.StackTrace + "\n" + ex.Message);
                }
            }

            else
            {

                string sql = "update Transactions set Amount=" + (amt) + ",Type=" + type + ",Date='" + date + "',Product='" + ds.Tables[0].Rows[comboBox3.SelectedIndex]["Name"].ToString() + "' where Date='" + olddate + "' and Customer_id="+mForm.cid+" and Type="+type+"";
                SQLiteCommand command;
                command = new SQLiteCommand(sql, MainScreen.m_dbConnection);
                command.ExecuteNonQuery();




                mForm.setData();


                this.Close();

            }
            try
            {
                string sql;
                SQLiteCommand command;
                sql = "select Total from Customers where ID=" + mForm.cid + "";
                command = new SQLiteCommand(sql, MainScreen.m_dbConnection);
                SQLiteDataReader reader = command.ExecuteReader();

                reader.Read();
                int total = Int32.Parse(reader["Total"].ToString());

                total += (amt - oldamt);

                sql = "update Customers set Total=" + total + " where ID=" + mForm.cid + "";
                command = new SQLiteCommand(sql, MainScreen.m_dbConnection);
                command.ExecuteNonQuery();

                //vForm.setData();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Update error in Total\n" + ex.StackTrace + "\n" + ex.Message);
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
