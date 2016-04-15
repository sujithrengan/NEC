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
            this.SuspendLayout();
            // 
            // add_customer
            // 
            this.add_customer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.add_customer.AutoSize = true;
            this.add_customer.Location = new System.Drawing.Point(120, 36);
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
            this.add_transaction.Location = new System.Drawing.Point(120, 65);
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
            this.view_transactions.Location = new System.Drawing.Point(120, 94);
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
            this.view_customers.Location = new System.Drawing.Point(120, 123);
            this.view_customers.Name = "view_customers";
            this.view_customers.Size = new System.Drawing.Size(109, 23);
            this.view_customers.TabIndex = 3;
            this.view_customers.Text = "View Customers";
            this.view_customers.UseVisualStyleBackColor = true;
            this.view_customers.Click += new System.EventHandler(this.view_customers_Click);
            // 
            // button_pro
            // 
            this.button_pro.Location = new System.Drawing.Point(120, 152);
            this.button_pro.Name = "button_pro";
            this.button_pro.Size = new System.Drawing.Size(109, 23);
            this.button_pro.TabIndex = 4;
            this.button_pro.Text = "Add Product";
            this.button_pro.UseVisualStyleBackColor = true;
            this.button_pro.Click += new System.EventHandler(this.button_pro_Click);
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 234);
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
    }
}

