using System.Xml.Linq;

namespace CustomerTrackingApp
{
    public partial class Form1 : Form
    {
        string filePath = "customers.txt";
        List<Customer> customerList = new List<Customer>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    string[] parts = line.Split('|');
                    if (parts.Length == 3)
                    {
                        Customer c = new Customer
                        {
                            Name = parts[0],
                            Phone = parts[1],
                            Mail = parts[2]
                        };
                        customerList.Add(c);
                        lstCustomers.Items.Add(c.Name);
                    }
                }
            }

            // ToolTip atamalarý burada yapýlýr
            toolTip1.SetToolTip(btnSave, "Save Info!");
            toolTip1.SetToolTip(txtName, "Enter name! ");
            toolTip1.SetToolTip(txtPhone, "Enter phone!");
            toolTip1.SetToolTip(txtMail, "Enter mail!");
        }
        private void btnSave_MouseHover(object sender, EventArgs e)
        {
            btnSave.BackColor = Color.LightGreen;
        }

        private void btnSave_MouseLeave(object sender, EventArgs e)
        {
            btnSave.BackColor = SystemColors.Control;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Customer c = new Customer()
            {
                Name = txtName.Text,
                Phone = txtPhone.Text,
                Mail = txtMail.Text
            };

            customerList.Add(c);
            lstCustomers.Items.Add(c.Name); // Sadece isim göster


            using (StreamWriter sw = File.AppendText(filePath))
            {
                sw.WriteLine($"{c.Name}|{c.Phone}|{c.Mail}");
            }
            MessageBox.Show("Record added successfully!");
        }
        private void lstCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = lstCustomers.SelectedIndex;
            if (index >= 0 && index < customerList.Count)
            {
                Customer selected = customerList[index];
                txtName.Text = selected.Name;
                txtPhone.Text = selected.Phone;
                txtMail.Text = selected.Mail;
            }
        }


        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {
            // Kullanýlmýyorsa silebilirsin
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;           // Geçersiz karakterin yazýlmasýný engelle
                lblWarning.Visible = true;  // Uyarý labelýný göster

                // Timer oluþtur ve 1 saniye sonra uyarýyý gizle
                System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
                timer.Interval = 1000; // 1000 ms = 1 saniye
                timer.Tick += (s, args) =>
                {
                    lblWarning.Visible = false; // Uyarýyý gizle
                    timer.Stop();
                    timer.Dispose();
                };
                timer.Start();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int index = lstCustomers.SelectedIndex;
            if (index >= 0 && index < customerList.Count)
            {
                customerList[index].Name = txtName.Text;
                customerList[index].Phone = txtPhone.Text;
                customerList[index].Mail = txtMail.Text;

                // Dosyayý yeniden yaz
                File.WriteAllLines(filePath, customerList.Select(c => $"{c.Name}|{c.Phone}|{c.Mail}"));

                // Liste kutusunu güncelle
                lstCustomers.Items[index] = txtName.Text;

                MessageBox.Show("Kayýt güncellendi.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int index = lstCustomers.SelectedIndex;
            if (index >= 0 && index < customerList.Count)
            {
                customerList.RemoveAt(index);
                lstCustomers.Items.RemoveAt(index);

                // Dosyayý yeniden yaz
                File.WriteAllLines(filePath, customerList.Select(c => $"{c.Name}|{c.Phone}|{c.Mail}"));

                txtName.Clear();
                txtPhone.Clear();
                txtMail.Clear();

                MessageBox.Show("Kayýt silindi.");
            }
        }

    }


}
