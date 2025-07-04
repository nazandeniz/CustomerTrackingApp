using System.Xml.Linq;

namespace CustomerTrackingApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
            lstCustomers.Items.Add(c.Name); // Sadece isim g�ster

            MessageBox.Show("Kay�t ba�ar�yla eklendi.");



        }
        List<Customer> customerList = new List<Customer>();


    }
}
