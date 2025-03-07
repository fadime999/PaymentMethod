using System.Reflection;

namespace ÖdemeYöntemi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.AddRange(new string[] { "Seçiniz", "KrediKartı", "MailOrder", "SmsOdeme" });
            comboBox1.SelectedIndex = 0;
        }

        private void button1_without_reflection(object sender, EventArgs e)
        {
            string selectedPayment = comboBox1.SelectedItem.ToString();
            if (selectedPayment == "Seçiniz")
            {
                MessageBox.Show("Lütfen bir ödeme yöntemi seçiniz.");
                return;
            }

            using (var context = new PaymentContext())
            {
                PaymentModel payment = new PaymentModel
                {
                    PaymentType = selectedPayment,
                    Amount = Convert.ToDecimal(textBox1.Text),
                    PaymentDate = DateTime.Now
                };

                context.Payments.Add(payment);
                context.SaveChanges();
            }

            MessageBox.Show($"Reflection olmadan {selectedPayment} ile {textBox1.Text} TL ödeme yapıldı ve kaydedildi.");
        }

        private void button2_with_reflection(object sender, EventArgs e)
        {
            string selectedPayment = comboBox1.SelectedItem.ToString();
            if (selectedPayment == "Seçiniz")
            {
                MessageBox.Show("Lütfen bir ödeme yöntemi seçiniz.");
                return;
            }

            // Reflection ile Ödeme
            Type type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == selectedPayment);
            if (type != null)
            {
                IPayment paymentInstance = (IPayment)Activator.CreateInstance(type);
                paymentInstance.ProcessPayment(textBox1.Text);

                MessageBox.Show($"Reflection kullanılarak {selectedPayment} ile {textBox1.Text} TL ödeme yapıldı ve kaydedildi.");
            }
            else
            {
                MessageBox.Show("Ödeme yöntemi bulunamadı!");
            }


        }
    }
}