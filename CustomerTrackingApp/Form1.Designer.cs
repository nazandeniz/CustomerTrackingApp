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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            btnSave = new Button();
            lblName = new Label();
            lblPhone = new Label();
            lblMail = new Label();
            txtName = new TextBox();
            txtPhone = new TextBox();
            txtMail = new TextBox();
            lblWarning = new Label();
            btnUpdate = new Button();
            btnDelete = new Button();
            txtSearch = new TextBox();
            lblSearch = new Label();
            btnExport = new Button();
            lvCustomers = new ListView();
            lblTitle = new Label();
            toolTip1 = new ToolTip(components);
            lblSurname = new Label();
            txtSurname = new TextBox();
            SuspendLayout();
            // 
            // btnSave
            // 
            btnSave.Location = new Point(66, 515);
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
            lblName.Location = new Point(123, 244);
            lblName.Name = "lblName";
            lblName.Size = new Size(49, 20);
            lblName.TabIndex = 1;
            lblName.Text = "Name";
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Location = new Point(122, 361);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(50, 20);
            lblPhone.TabIndex = 1;
            lblPhone.Text = "Phone";
            // 
            // lblMail
            // 
            lblMail.AutoSize = true;
            lblMail.Location = new Point(122, 430);
            lblMail.Name = "lblMail";
            lblMail.Size = new Size(38, 20);
            lblMail.TabIndex = 1;
            lblMail.Text = "Mail";
            // 
            // txtName
            // 
            txtName.Location = new Point(191, 244);
            txtName.Name = "txtName";
            txtName.Size = new Size(125, 27);
            txtName.TabIndex = 2;
            txtName.TextChanged += txtName_TextChanged;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(191, 354);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(125, 27);
            txtPhone.TabIndex = 2;
            txtPhone.TextChanged += txtPhone_TextChanged;
            txtPhone.KeyPress += txtPhone_KeyPress;
            // 
            // txtMail
            // 
            txtMail.Location = new Point(191, 423);
            txtMail.Name = "txtMail";
            txtMail.Size = new Size(125, 27);
            txtMail.TabIndex = 2;
            // 
            // lblWarning
            // 
            lblWarning.AutoSize = true;
            lblWarning.Location = new Point(231, 361);
            lblWarning.Name = "lblWarning";
            lblWarning.Size = new Size(198, 40);
            lblWarning.TabIndex = 4;
            lblWarning.Text = "\"Please enter numbers only!\"\n\n";
            lblWarning.Visible = false;
            lblWarning.Click += lblWarning_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(166, 516);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(94, 28);
            btnUpdate.TabIndex = 5;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(278, 515);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 6;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // txtSearch
            // 
            txtSearch.BackColor = SystemColors.Control;
            txtSearch.Location = new Point(831, 165);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(247, 27);
            txtSearch.TabIndex = 7;
            txtSearch.TextAlign = HorizontalAlignment.Center;
            txtSearch.TextChanged += txtSearch_TextChanged;
            txtSearch.Enter += txtSearch_Enter;
            txtSearch.Leave += txtSearch_Leave;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Location = new Point(745, 165);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(53, 20);
            lblSearch.TabIndex = 8;
            lblSearch.Text = "Search";
            // 
            // btnExport
            // 
            btnExport.Location = new Point(853, 600);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(150, 41);
            btnExport.TabIndex = 9;
            btnExport.Text = "Export To File";
            btnExport.UseVisualStyleBackColor = true;
            btnExport.Click += btnExport_Click;
            // 
            // lvCustomers
            // 
            lvCustomers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lvCustomers.FullRowSelect = true;
            lvCustomers.GridLines = true;
            lvCustomers.Location = new Point(507, 244);
            lvCustomers.Name = "lvCustomers";
            lvCustomers.Size = new Size(929, 300);
            lvCustomers.TabIndex = 10;
            lvCustomers.UseCompatibleStateImageBehavior = false;
            lvCustomers.View = View.Details;
            lvCustomers.SelectedIndexChanged += lvCustomers_SelectedIndexChanged;
            // 
            // lblTitle
            // 
            lblTitle.BackColor = Color.LightGray;
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.DarkBlue;
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(1868, 60);
            lblTitle.TabIndex = 11;
            lblTitle.Text = "Customer Tracking System";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblTitle.Click += lblTitle_Click;
            // 
            // lblSurname
            // 
            lblSurname.AutoSize = true;
            lblSurname.Location = new Point(105, 303);
            lblSurname.Name = "lblSurname";
            lblSurname.Size = new Size(67, 20);
            lblSurname.TabIndex = 12;
            lblSurname.Text = "Surname";
            // 
            // txtSurname
            // 
            txtSurname.Location = new Point(191, 303);
            txtSurname.Name = "txtSurname";
            txtSurname.Size = new Size(125, 27);
            txtSurname.TabIndex = 2;
            txtSurname.TextChanged += txtName_TextChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1868, 764);
            Controls.Add(lblSurname);
            Controls.Add(lblTitle);
            Controls.Add(lvCustomers);
            Controls.Add(btnExport);
            Controls.Add(lblSearch);
            Controls.Add(txtSearch);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(lblWarning);
            Controls.Add(txtMail);
            Controls.Add(txtPhone);
            Controls.Add(txtSurname);
            Controls.Add(txtName);
            Controls.Add(lblMail);
            Controls.Add(lblPhone);
            Controls.Add(lblName);
            Controls.Add(btnSave);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "customerTracking";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }
        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            // Şimdilik boş bırakabiliriz
        }
        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {
            // Eğer bir şey yapmak istemiyorsan boş bırakabilirsin
        }


        #endregion

        private Button btnSave;
        private Label lblName;
        private Label lblPhone;
        private Label lblMail;
        private TextBox txtName;
        private TextBox txtPhone;
        private TextBox txtMail;
        private Label lblWarning;
        private Button btnUpdate;
        private Button btnDelete;
        private TextBox txtSearch;
        private Label lblSearch;
        private Button btnExport;
        private ListView lvCustomers;
        private Label lblTitle;
        private ToolTip toolTip1;
        private Label lblSurname;
        private TextBox txtSurname;
    }
}
