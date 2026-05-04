using System;
using System.Drawing;
using System.Windows.Forms;

namespace ONLINE_PLATFORM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // 1. Force Form Size and Center it
            this.Size = new Size(800, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(64, 64, 64); // Dark Grey

            // 2. Setup the "Card" (Panel)
            if (this.panel1 != null)
            {
                panel1.BackColor = Color.FromArgb(45, 45, 48);
                panel1.Size = new Size(500, 400);
            }

            // 3. Fix Heading Spelling & Style (use designer name lblHeading)
            if (this.lblHeading != null)
            {
                lblHeading.Text = "STUDENT/ENTREPRENEUR";
                lblHeading.Font = new Font("Arial", 18, FontStyle.Bold);
                lblHeading.ForeColor = Color.White;
                lblHeading.TextAlign = ContentAlignment.MiddleCenter;
                lblHeading.AutoSize = false;
                lblHeading.Size = new Size(480, 40);
            }

            // 4. Muted Welcome Text (optional control)
            var welcome = this.Controls.Find("lblWelcome", true);
            if (welcome.Length > 0 && welcome[0] is Label lblWelcome)
            {
                lblWelcome.Text = "Welcome back! Please enter your details";
                lblWelcome.Font = new Font("Arial", 10);
                lblWelcome.ForeColor = Color.DarkGray;
                lblWelcome.TextAlign = ContentAlignment.MiddleCenter;
                lblWelcome.AutoSize = false;
                lblWelcome.Size = new Size(480, 20);
            }

            // 5. Input Labels
            if (this.lblUsername != null) lblUsername.ForeColor = Color.White;
            if (this.lblPassword != null) lblPassword.ForeColor = Color.White;

            // 6. Centering Logic
            this.Load += CenterCard;
            this.Resize += CenterCard;
        }

        private void CenterCard(object sender, EventArgs e)
        {
            if (this.panel1 == null) return;
            panel1.Left = (this.ClientSize.Width - panel1.Width) / 2;
            panel1.Top = (this.ClientSize.Height - panel1.Height) / 2;
        }

        // This is the login logic connecting your pages
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userRole = (txtUsername?.Text ?? string.Empty).Trim().ToLower();

            if (userRole == "student")
            {
                new StudentUserForm().Show();
                this.Hide();
            }
            else if (userRole == "entrepreneur")
            {
                new EntrepreneurForm().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Please enter 'student' or 'entrepreneur' in the username box.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnForgotPassword_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please contact the administrator to reset your password.", "Forgot Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
