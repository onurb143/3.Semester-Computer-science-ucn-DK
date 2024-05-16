using MomentozClientApp.Model;
using MomentozClientApp.Servicelayer;
using System.Diagnostics;

namespace MomentozClientApp.GuiLayer
{
    public partial class LogIn : Form
    {
        private readonly CustomerAccess _customerAccess;
        private Button button1;
        private Label label1;
        private TextBox textBox1;

        public LogIn(CustomerAccess customerAccess)
        {
            InitializeComponent();
            _customerAccess = customerAccess ?? throw new ArgumentNullException(nameof(customerAccess));

        }

        private void InitializeComponent()
        {
            button1 = new Button();
            label1 = new Label();
            textBox1 = new TextBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(202, 140);
            button1.Name = "button1";
            button1.Size = new Size(109, 62);
            button1.TabIndex = 0;
            button1.Text = "Login";
            button1.UseVisualStyleBackColor = true;
            button1.Click += LoginKnap;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(46, 51);
            label1.Name = "label1";
            label1.Size = new Size(58, 25);
            label1.TabIndex = 1;
            label1.Text = "Email:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(141, 48);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(170, 31);
            textBox1.TabIndex = 4;
            // 
            // LogIn
            // 
            ClientSize = new Size(344, 230);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(button1);
            Name = "LogIn";
            Text = "Momentoz";
            ResumeLayout(false);
            PerformLayout();
        }

        private async Task<Customer> GetCustomerByEmailAsync(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return null;
            }

            try
            {
                Customer customers = await _customerAccess.GetCustomerByEmail(email);

                if (customers != null)  // Tjek om der er nogen kunder i listen
                {
                    // Hent den første kunde fra listen
                  
                    return customers;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Der opstod en fejl under log ind: {ex.Message}", "Fejl", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Debug.WriteLine($"Der opstod en fejl under log ind: {ex.Message}");
                return null;
            }
        }


        // Denne metode bliver kaldt, når brugeren klikker på login-knappen.
        private async void LoginKnap(object sender, EventArgs e)
        {
            var userEmail = textBox1.Text.Trim();

            if (string.IsNullOrEmpty(userEmail))
            {
                MessageBox.Show("E-mailfeltet må ikke være tomt.", "Ugyldig indtastning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Customer customer = await GetCustomerByEmailAsync(userEmail);

                if (customer != null && customer.Email != null)
                {
                    // Kunden blev fundet i databasen, og du kan udføre handlingen for at logge ind.

                    // Opret en ny instans af MainMenu med kunden som argument
                    MainMenu mainMenu = new MainMenu(customer); // Ændret her
                                                                // mainMenu.SetLoggedInCustomer(customer); // Denne linje kan fjernes, hvis din MainMenu konstruktør korrekt initialiserer formen med kunden
                    mainMenu.Closed += (s, args) => this.Close();
                    mainMenu.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Forkert email. Indtast en gyldig email for at logge ind.", "Login mislykkedes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Der opstod en fejl under log ind: {ex.Message}", "Fejl", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Debug.WriteLine($"Der opstod en fejl under log ind: {ex.Message}");
            }
        }




        private async Task<bool> LoginWithEmailAsync(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("E-mailfeltet må ikke være tomt.", "Ugyldig indtastning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            try
            {
                var customer = await GetCustomerByEmailAsync(email);

                if (customer != null)
                {
                    // Kunden blev fundet i databasen, og du kan udføre handlingen for at logge ind.
                    MessageBox.Show($"Velkommen, {customer.FullName}!", "Log ind", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Tilføj din log ind logik her, f.eks. navigering til hovedmenuen.
                    return true;
                }
                else
                {
                    MessageBox.Show("Forkert email. Indtast en gyldig email for at logge ind.", "Login mislykkedes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Der opstod en fejl under log ind: {ex.Message}", "Fejl", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                return false;
            }
        }



        private async Task<bool> IsValidEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("E-mailfeltet må ikke være tomt.", "Ugyldig indtastning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            try
            {
                var customer = await _customerAccess.GetCustomerByEmail(email);
                return customer != null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Der opstod en fejl under verifikation af e-mail. Prøv igen senere.", "Fejl", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Debug.WriteLine($"Der opstod en fejl under adgang til databasen: {ex.Message}");
                return false;
            }




            void textBox1_TextChanged(object sender, EventArgs e)
            {

            }

        }
    } }
