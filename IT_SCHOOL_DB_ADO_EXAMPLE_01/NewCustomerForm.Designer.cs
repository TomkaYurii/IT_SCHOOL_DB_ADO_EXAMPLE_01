namespace IT_SCHOOL_DB_ADO_EXAMPLE_01
{
    partial class NewCustomerForm
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
            this.grbRegister = new System.Windows.Forms.GroupBox();
            this.txtCustomerID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.btnCreateAccount = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpOrderDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.numOrderAmount = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnPlaceOrder = new System.Windows.Forms.Button();
            this.btnAddAnotherAccount = new System.Windows.Forms.Button();
            this.btnAddFinish = new System.Windows.Forms.Button();
            this.grbRegister.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numOrderAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // grbRegister
            // 
            this.grbRegister.Controls.Add(this.txtCustomerID);
            this.grbRegister.Controls.Add(this.label2);
            this.grbRegister.Controls.Add(this.label1);
            this.grbRegister.Controls.Add(this.txtCustomerName);
            this.grbRegister.Location = new System.Drawing.Point(12, 12);
            this.grbRegister.Name = "grbRegister";
            this.grbRegister.Size = new System.Drawing.Size(530, 172);
            this.grbRegister.TabIndex = 0;
            this.grbRegister.TabStop = false;
            this.grbRegister.Text = "Створити аккаунт";
            // 
            // txtCustomerID
            // 
            this.txtCustomerID.Location = new System.Drawing.Point(200, 109);
            this.txtCustomerID.Name = "txtCustomerID";
            this.txtCustomerID.ReadOnly = true;
            this.txtCustomerID.Size = new System.Drawing.Size(315, 27);
            this.txtCustomerID.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "ID користувача";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ім\'я користувача";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(200, 39);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(315, 27);
            this.txtCustomerName.TabIndex = 0;
            // 
            // btnCreateAccount
            // 
            this.btnCreateAccount.Location = new System.Drawing.Point(570, 51);
            this.btnCreateAccount.Name = "btnCreateAccount";
            this.btnCreateAccount.Size = new System.Drawing.Size(191, 119);
            this.btnCreateAccount.TabIndex = 1;
            this.btnCreateAccount.Text = "Створити акканут";
            this.btnCreateAccount.UseVisualStyleBackColor = true;
            this.btnCreateAccount.Click += new System.EventHandler(this.btnCreateAccount_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtpOrderDate);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.numOrderAmount);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(12, 207);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(530, 172);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Створити замовлення";
            // 
            // dtpOrderDate
            // 
            this.dtpOrderDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpOrderDate.Location = new System.Drawing.Point(200, 104);
            this.dtpOrderDate.Name = "dtpOrderDate";
            this.dtpOrderDate.Size = new System.Drawing.Size(315, 27);
            this.dtpOrderDate.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Дата замовлення";
            // 
            // numOrderAmount
            // 
            this.numOrderAmount.Location = new System.Drawing.Point(200, 41);
            this.numOrderAmount.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numOrderAmount.Name = "numOrderAmount";
            this.numOrderAmount.Size = new System.Drawing.Size(315, 27);
            this.numOrderAmount.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = " ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "Кількість";
            // 
            // btnPlaceOrder
            // 
            this.btnPlaceOrder.Location = new System.Drawing.Point(570, 237);
            this.btnPlaceOrder.Name = "btnPlaceOrder";
            this.btnPlaceOrder.Size = new System.Drawing.Size(191, 119);
            this.btnPlaceOrder.TabIndex = 5;
            this.btnPlaceOrder.Text = "Створити замовлення";
            this.btnPlaceOrder.UseVisualStyleBackColor = true;
            this.btnPlaceOrder.Click += new System.EventHandler(this.btnPlaceOrder_Click);
            // 
            // btnAddAnotherAccount
            // 
            this.btnAddAnotherAccount.Location = new System.Drawing.Point(443, 403);
            this.btnAddAnotherAccount.Name = "btnAddAnotherAccount";
            this.btnAddAnotherAccount.Size = new System.Drawing.Size(191, 79);
            this.btnAddAnotherAccount.TabIndex = 6;
            this.btnAddAnotherAccount.Text = "Додати інший аккаунт";
            this.btnAddAnotherAccount.UseVisualStyleBackColor = true;
            this.btnAddAnotherAccount.Click += new System.EventHandler(this.btnAddAnotherAccount_Click);
            // 
            // btnAddFinish
            // 
            this.btnAddFinish.Location = new System.Drawing.Point(212, 403);
            this.btnAddFinish.Name = "btnAddFinish";
            this.btnAddFinish.Size = new System.Drawing.Size(191, 79);
            this.btnAddFinish.TabIndex = 7;
            this.btnAddFinish.Text = "Завершити";
            this.btnAddFinish.UseVisualStyleBackColor = true;
            this.btnAddFinish.Click += new System.EventHandler(this.btnAddFinish_Click);
            // 
            // NewCustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 509);
            this.Controls.Add(this.btnAddFinish);
            this.Controls.Add(this.btnAddAnotherAccount);
            this.Controls.Add(this.btnPlaceOrder);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCreateAccount);
            this.Controls.Add(this.grbRegister);
            this.Name = "NewCustomerForm";
            this.Text = "NewCustomer";
            this.grbRegister.ResumeLayout(false);
            this.grbRegister.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numOrderAmount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbRegister;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.TextBox txtCustomerID;
        private System.Windows.Forms.Button btnCreateAccount;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpOrderDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numOrderAmount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnPlaceOrder;
        private System.Windows.Forms.Button btnAddAnotherAccount;
        private System.Windows.Forms.Button btnAddFinish;
    }
}