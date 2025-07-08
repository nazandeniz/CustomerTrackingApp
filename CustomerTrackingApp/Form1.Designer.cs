namespace CustomerTrackingApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            btnSave = new Button();
            lblName = new Label();
            lblPhone = new Label();
            lblMail = new Label();
            txtName = new TextBox();
            txtPhone = new TextBox();
            txtMail = new TextBox();
            lstCustomers = new ListBox();
            toolTip1 = new ToolTip(components);
            lblWarning = new Label();
            btnUpdate = new Button();
            btnDelete = new Button();
            SuspendLayout();
            // 
            // btnSave
            // 
            btnSave.Location = new Point(51, 300);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 0;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(107, 73);
            lblName.Name = "lblName";
            lblName.Size = new Size(49, 20);
            lblName.TabIndex = 1;
            lblName.Text = "Name";
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Location = new Point(107, 138);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(50, 20);
            lblPhone.TabIndex = 1;
            lblPhone.Text = "Phone";
            // 
            // lblMail
            // 
            lblMail.AutoSize = true;
            lblMail.Location = new Point(107, 207);
            lblMail.Name = "lblMail";
            lblMail.Size = new Size(38, 20);
            lblMail.TabIndex = 1;
            lblMail.Text = "Mail";
            // 
            // txtName
            // 
            txtName.Location = new Point(176, 73);
            txtName.Name = "txtName";
            txtName.Size = new Size(125, 27);
            txtName.TabIndex = 2;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(176, 131);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(125, 27);
            txtPhone.TabIndex = 2;
            txtPhone.TextChanged += txtPhone_TextChanged;
            txtPhone.KeyPress += txtPhone_KeyPress;
            // 
            // txtMail
            // 
            txtMail.Location = new Point(176, 200);
            txtMail.Name = "txtMail";
            txtMail.Size = new Size(125, 27);
            txtMail.TabIndex = 2;
            // 
            // lstCustomers
            // 
            lstCustomers.FormattingEnabled = true;
            lstCustomers.Location = new Point(489, 53);
            lstCustomers.Name = "lstCustomers";
            lstCustomers.Size = new Size(150, 304);
            lstCustomers.TabIndex = 3;
            lstCustomers.SelectedIndexChanged += lstCustomers_SelectedIndexChanged;
            // 
            // toolTip1
            // 
            toolTip1.Popup += toolTip1_Popup;
            // 
            // lblWarning
            // 
            lblWarning.AutoSize = true;
            lblWarning.Location = new Point(233, 161);
            lblWarning.Name = "lblWarning";
            lblWarning.Size = new Size(198, 40);
            lblWarning.TabIndex = 4;
            lblWarning.Text = "\"Please enter numbers only!\"\n\n";
            lblWarning.Visible = false;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(151, 301);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(94, 28);
            btnUpdate.TabIndex = 5;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(251, 301);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 6;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(lblWarning);
            Controls.Add(lstCustomers);
            Controls.Add(txtMail);
            Controls.Add(txtPhone);
            Controls.Add(txtName);
            Controls.Add(lblMail);
            Controls.Add(lblPhone);
            Controls.Add(lblName);
            Controls.Add(btnSave);
            Name = "Form1";
            Text = "customerTracking";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSave;
        private Label lblName;
        private Label lblPhone;
        private Label lblMail;
        private TextBox txtName;
        private TextBox txtPhone;
        private TextBox txtMail;
        private ListBox lstCustomers;
        private ToolTip toolTip1;
        private Label lblWarning;
        private Button btnUpdate;
        private Button btnDelete;
    }
}
