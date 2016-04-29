namespace NEC
{
    partial class MainScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.add_customer = new System.Windows.Forms.Button();
            this.add_transaction = new System.Windows.Forms.Button();
            this.view_transactions = new System.Windows.Forms.Button();
            this.view_customers = new System.Windows.Forms.Button();
            this.button_pro = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // add_customer
            // 
            this.add_customer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.add_customer.AutoSize = true;
            this.add_customer.Location = new System.Drawing.Point(110, 45);
            this.add_customer.Name = "add_customer";
            this.add_customer.Size = new System.Drawing.Size(109, 23);
            this.add_customer.TabIndex = 0;
            this.add_customer.Text = "Add Customer";
            this.add_customer.UseVisualStyleBackColor = true;
            this.add_customer.Click += new System.EventHandler(this.add_customer_Click);
            // 
            // add_transaction
            // 
            this.add_transaction.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.add_transaction.AutoSize = true;
            this.add_transaction.Location = new System.Drawing.Point(110, 74);
            this.add_transaction.Name = "add_transaction";
            this.add_transaction.Size = new System.Drawing.Size(109, 23);
            this.add_transaction.TabIndex = 1;
            this.add_transaction.Text = "Add Transaction";
            this.add_transaction.UseVisualStyleBackColor = true;
            this.add_transaction.Click += new System.EventHandler(this.add_transaction_Click);
            // 
            // view_transactions
            // 
            this.view_transactions.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.view_transactions.AutoSize = true;
            this.view_transactions.Location = new System.Drawing.Point(110, 103);
            this.view_transactions.Name = "view_transactions";
            this.view_transactions.Size = new System.Drawing.Size(109, 23);
            this.view_transactions.TabIndex = 2;
            this.view_transactions.Text = "View Transactions";
            this.view_transactions.UseVisualStyleBackColor = true;
            this.view_transactions.Click += new System.EventHandler(this.view_transactions_Click);
            // 
            // view_customers
            // 
            this.view_customers.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.view_customers.AutoSize = true;
            this.view_customers.Location = new System.Drawing.Point(110, 132);
            this.view_customers.Name = "view_customers";
            this.view_customers.Size = new System.Drawing.Size(109, 23);
            this.view_customers.TabIndex = 3;
            this.view_customers.Text = "View Customers";
            this.view_customers.UseVisualStyleBackColor = true;
            this.view_customers.Click += new System.EventHandler(this.view_customers_Click);
            // 
            // button_pro
            // 
            this.button_pro.Location = new System.Drawing.Point(110, 161);
            this.button_pro.Name = "button_pro";
            this.button_pro.Size = new System.Drawing.Size(109, 23);
            this.button_pro.TabIndex = 4;
            this.button_pro.Text = "Add Product";
            this.button_pro.UseVisualStyleBackColor = true;
            this.button_pro.Click += new System.EventHandler(this.button_pro_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(110, 190);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Add Collection";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(110, 219);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(109, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Add Route";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(110, 248);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(109, 23);
            this.button3.TabIndex = 7;
            this.button3.Text = "Add Salesman";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(110, 277);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(109, 23);
            this.button4.TabIndex = 8;
            this.button4.Text = "View Collections";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 356);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button_pro);
            this.Controls.Add(this.view_customers);
            this.Controls.Add(this.view_transactions);
            this.Controls.Add(this.add_transaction);
            this.Controls.Add(this.add_customer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NEC";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button add_customer;
        private System.Windows.Forms.Button add_transaction;
        private System.Windows.Forms.Button view_transactions;
        private System.Windows.Forms.Button view_customers;
        private System.Windows.Forms.Button button_pro;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}

