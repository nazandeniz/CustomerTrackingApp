using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CustomerTrackingApp
{
    public partial class Form1 : Form
    {
        string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "customers.txt");
        List<Customer> customerList = new List<Customer>();
        int currentID = 1;
 

        public Form1()
        {
            InitializeComponent();
            txtSearch.TextChanged += txtSearch_TextChanged;

            txtName.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            txtSurname.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            txtPhone.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            txtMail.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnUpdate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnDelete.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnExport.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            lvCustomers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            this.AcceptButton = btnSave;

            txtSearch.Text = "Search...";
            txtSearch.ForeColor = Color.Gray;

            txtSearch.Enter += txtSearch_Enter;
            txtSearch.Leave += txtSearch_Leave;

            lvCustomers.MouseDoubleClick += lvCustomers_MouseDoubleClick;
        }
        private void RefreshListView()
        {
            lvCustomers.Items.Clear(); // ListView'ý temizle

            foreach (var customer in customerList)
            {
                var item = new ListViewItem(customer.ID.ToString());
                item.SubItems.Add(customer.Name);
                item.SubItems.Add(customer.Surname);
                item.SubItems.Add(customer.Phone);
                item.SubItems.Add(customer.Mail);
                lvCustomers.Items.Add(item);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnSave.BackColor = Color.FromArgb(76, 175, 80);
            btnUpdate.BackColor = Color.FromArgb(33, 150, 243);
            btnDelete.BackColor = Color.FromArgb(244, 67, 54);
            btnExport.BackColor = Color.FromArgb(255, 193, 7);

            lvCustomers.View = View.Details;
            lvCustomers.Columns.Add("ID", 50);
            lvCustomers.Columns.Add("Name", 100);
            lvCustomers.Columns.Add("Surname", 100);
            lvCustomers.Columns.Add("Phone", 100);
            lvCustomers.Columns.Add("Mail", 150);

            lblTitle.Text = "Customer Tracking System";
            lblTitle.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            lblTitle.ForeColor = Color.DarkBlue;
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Height = 50;
            lblTitle.BackColor = Color.LightGray;

            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    string[] parts = line.Split('|');
                    if (parts.Length == 5)
                    {
                        Customer c = new Customer
                        {
                            ID = int.Parse(parts[0]),
                            Name = parts[1],
                            Surname = parts[2],
                            Phone = parts[3],
                            Mail = parts[4]
                        };
                        customerList.Add(c);

                        ListViewItem item = new ListViewItem(c.ID.ToString());
                        item.SubItems.Add(c.Name);
                        item.SubItems.Add(c.Surname);
                        item.SubItems.Add(c.Phone);
                        item.SubItems.Add(c.Mail);
                        lvCustomers.Items.Add(item);

                        if (c.ID >= currentID)
                            currentID = c.ID + 1;
                    }
                }
                lvCustomers.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

            }

            toolTip1.SetToolTip(btnSave, "Save Info!");
            toolTip1.SetToolTip(txtName, "Enter name!");
            toolTip1.SetToolTip(txtPhone, "Enter phone!");
            toolTip1.SetToolTip(txtMail, "Enter mail!");

            lvCustomers.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtSurname.Text) ||
                string.IsNullOrWhiteSpace(txtPhone.Text) ||
                string.IsNullOrWhiteSpace(txtMail.Text))
            {
                MessageBox.Show("Required fields must be filled in!");
                return;
            }

            string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z]{2,}$";

            if (!Regex.IsMatch(txtMail.Text, pattern))
            {
                MessageBox.Show("Please enter a valid email address!");
                return;
            }

            if (!IsValidPhoneNumber(txtPhone.Text))
            {
                MessageBox.Show("Please enter an 11-digit phone number starting with 0!");
                return;
            }

            string formattedPhone = FormatPhoneNumber(txtPhone.Text);


            if (customerList.Any(c => c.Name == txtName.Text && c.Surname == txtSurname.Text && c.Phone == formattedPhone && c.Mail == txtMail.Text))
            {
                MessageBox.Show("This user is already registered!");
                return;
            }
            Customer c = new Customer()
            {
                ID = currentID,
                Name = txtName.Text,
                Surname = txtSurname.Text,
                Phone = formattedPhone,
                Mail = txtMail.Text
            };

            customerList.Add(c);
            currentID++;

            ListViewItem item = new ListViewItem(c.ID.ToString());
            item.SubItems.Add(c.Name);
            item.SubItems.Add(c.Surname);
            item.SubItems.Add(c.Phone);
            item.SubItems.Add(c.Mail);
            lvCustomers.Items.Add(item);

            using (StreamWriter sw = new StreamWriter(filePath, true, Encoding.UTF8))
            {
                sw.WriteLine($"{c.ID}|{c.Name}|{c.Surname}|{c.Phone}|{c.Mail}");

            }

            ClearInputs();
            MessageBox.Show("Record added successfully!");
            lvCustomers.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtSurname.Text) ||
                string.IsNullOrWhiteSpace(txtPhone.Text) ||
                string.IsNullOrWhiteSpace(txtMail.Text))
            {
                MessageBox.Show("Required fields must be filled in!");
                return;
            }

            if (!IsValidPhoneNumber(txtPhone.Text))
            {
                MessageBox.Show("Please enter an 11-digit phone number starting with 0!");
                return;
            }

            if (lvCustomers.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a record to update.");
                return;
            }

            string formattedPhone = FormatPhoneNumber(txtPhone.Text);
            string selectedIDText = lvCustomers.SelectedItems[0].SubItems[0].Text;

            if (int.TryParse(selectedIDText, out int selectedID))
            {
                Customer customerToUpdate = customerList.FirstOrDefault(c => c.ID == selectedID);
                if (customerToUpdate != null)
                {
                    customerToUpdate.Name = txtName.Text;
                    customerToUpdate.Surname = txtSurname.Text;
                    customerToUpdate.Phone = formattedPhone;
                    customerToUpdate.Mail = txtMail.Text;

                    // ListView'deki seçili item'ý güncelle
                    var item = lvCustomers.SelectedItems[0];
                    item.SubItems[1].Text = txtName.Text;
                    item.SubItems[2].Text = txtSurname.Text;
                    item.SubItems[3].Text = formattedPhone;
                    item.SubItems[4].Text = txtMail.Text;

                    // Dosyaya kaydet
                    File.WriteAllLines(filePath, customerList.Select(c => $"{c.ID}|{c.Name}|{c.Surname}|{c.Phone}|{c.Mail}"));

                    ClearInputs();
                    MessageBox.Show("Record Updated!");
                    lvCustomers.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                }
                else
                {
                    MessageBox.Show("Customer not found.");
                }
            }
        }

        private void SaveToFile()
        {
            using (StreamWriter sw = new StreamWriter(filePath, false, Encoding.UTF8)) // false = overwrite
            {
                foreach (var customer in customerList)
                {
                    sw.WriteLine($"{customer.ID}|{customer.Name}|{customer.Surname}|{customer.Phone}|{customer.Mail}");
                }
            }
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvCustomers.SelectedItems.Count > 0)
            {
                string selectedIDText = lvCustomers.SelectedItems[0].SubItems[0].Text;
                if (int.TryParse(selectedIDText, out int selectedID))
                {
                    // ID'ye göre müþteriyi bul
                    Customer customerToRemove = customerList.FirstOrDefault(c => c.ID == selectedID);
                    if (customerToRemove != null)
                    {
                        customerList.Remove(customerToRemove);

                        // Ýstersen ID'leri yeniden düzenle (isteðe baðlý)
                        for (int i = 0; i < customerList.Count; i++)
                        {
                            customerList[i].ID = i + 1;
                        }

                        currentID = customerList.Count > 0 ? customerList.Max(c => c.ID) + 1 : 1;

                        RefreshListView();
                        SaveToFile();
                        MessageBox.Show("Record Deleted!");
                        ClearInputs();
                    }
                    else
                    {
                        MessageBox.Show("Customer not found.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a record!");
            }
        }


        private void txtSearch_TextChanged(object sender, EventArgs e)
{
    string search = txtSearch.Text.ToLower();

    if (search == "search..." || string.IsNullOrWhiteSpace(search))
    {
        // Arama kutusu boþsa tüm listeyi tekrar göster
        lvCustomers.Items.Clear();
        foreach (Customer c in customerList)
        {
            ListViewItem item = new ListViewItem(c.ID.ToString());
            item.SubItems.Add(c.Name);
            item.SubItems.Add(c.Surname);
            item.SubItems.Add(c.Phone);
            item.SubItems.Add(c.Mail);
            lvCustomers.Items.Add(item);


                }
                lvCustomers.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

                return;
    }

    // Filtreleme
    lvCustomers.Items.Clear();
    foreach (Customer c in customerList)
    {
        if (c.Name.ToLower().Contains(search) ||
            c.Surname.ToLower().Contains(search) ||
            c.Phone.Contains(search) ||
            c.Mail.ToLower().Contains(search))
        {
            ListViewItem item = new ListViewItem(c.ID.ToString());
            item.SubItems.Add(c.Name);
            item.SubItems.Add(c.Surname);
            item.SubItems.Add(c.Phone);
            item.SubItems.Add(c.Mail);
            lvCustomers.Items.Add(item);
        }
    }
}

        private void btnExport_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "CSV files (*.csv)|*.csv";
                sfd.Title = "Export File Location";
                sfd.FileName = "export.csv";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter sw = new StreamWriter(sfd.FileName, false, Encoding.UTF8))
                    {
                        sw.WriteLine("ID,Name, Surname, Phone, Mail");
                        foreach (Customer c in customerList)
                        {
                            sw.WriteLine($"{c.ID},{c.Name},{c.Surname},{c.Phone},{c.Mail}");
                        }
                    }

                    MessageBox.Show("Records exported!:\n" + sfd.FileName, "Export Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void lvCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvCustomers.SelectedItems.Count > 0)
            {
                string selectedIDText = lvCustomers.SelectedItems[0].SubItems[0].Text;
                if (int.TryParse(selectedIDText, out int selectedID))
                {
                    Customer selected = customerList.FirstOrDefault(c => c.ID == selectedID);
                    if (selected != null)
                    {
                        txtName.Text = selected.Name;
                        txtSurname.Text = selected.Surname;
                        txtPhone.Text = selected.Phone;
                        txtMail.Text = selected.Mail;
                    }
                }
            }
        }


        private void lvCustomers_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lvCustomers.SelectedItems.Count > 0)
            {
                // Seçilen item'ýn ID'sini al
                string selectedIDText = lvCustomers.SelectedItems[0].SubItems[0].Text;
                if (int.TryParse(selectedIDText, out int selectedID))
                {
                    // ID ile eþleþen müþteri nesnesini bul
                    Customer selected = customerList.FirstOrDefault(c => c.ID == selectedID);

                    if (selected != null)
                    {
                        MessageBox.Show(selected.GetSummary(), "Customer Details");
                    }
                    else
                    {
                        MessageBox.Show("Customer not found.");
                    }
                }
            }
        }


        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                lblWarning.Visible = true;

                System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
                timer.Interval = 1000;
                timer.Tick += (s, args) =>
                {
                    lblWarning.Visible = false;
                    timer.Stop();
                    timer.Dispose();
                };
                timer.Start();
            }
        }

        private void btnSave_MouseHover(object sender, EventArgs e)
        {
            btnSave.BackColor = Color.LightGreen;
        }

        private void btnSave_MouseLeave(object sender, EventArgs e)
        {
            btnSave.BackColor = Color.FromArgb(76, 175, 80);
        }

        private void ClearInputs()
        {
            txtName.Clear();
            txtSurname.Clear();
            txtPhone.Clear();
            txtMail.Clear();
            txtSearch.Text = "Search...";
        }

        private string FormatPhoneNumber(string raw)
        {
            string digits = new string(raw.Where(char.IsDigit).ToArray());
            if (digits.Length == 11 && digits.StartsWith("0"))
            {
                return $"{digits.Substring(0, 4)}-{digits.Substring(4, 3)}-{digits.Substring(7, 4)}";
            }
            return raw;
        }

        private bool IsValidPhoneNumber(string raw)
        {
            string digits = new string(raw.Where(char.IsDigit).ToArray());
            return digits.Length == 11 && digits.StartsWith("0");
        }

        private void lblTitle_Click(object sender, EventArgs e) { }
        private void lblWarning_Click(object sender, EventArgs e) { }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Search...")
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = Color.Black;
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = "Search...";
                txtSearch.ForeColor = Color.Gray;
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
