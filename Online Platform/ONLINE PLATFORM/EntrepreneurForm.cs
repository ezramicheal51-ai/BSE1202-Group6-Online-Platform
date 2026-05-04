using System;
using System.Drawing;
using System.Windows.Forms;
using ONLINE_PLATFORM.Properties;

namespace ONLINE_PLATFORM
{
    public partial class EntrepreneurForm : Form
    {
        public EntrepreneurForm()
        {
            // Initialize via designer if available, otherwise continue
            if (!TryCallDesignerInitialize())
                MinimalInitializeComponent();

            // Force appearance and run layout after load
            this.BackColor = Color.FromArgb(64, 64, 64);
            this.Size = new Size(1250, 850);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Load += (s, e) => BuildDashboard();
        }

        private void BuildDashboard()
        {
            // Clear everything to prevent the 'white screen' from designer panels
            this.Controls.Clear();

            // --- 2. SIDEBAR (LOCKED LEFT) ---
            Panel pnlSidebar = new Panel { Width = 240, Dock = DockStyle.Left, BackColor = Color.FromArgb(45, 45, 48), Parent = this };

            var profileImg = Resources.ResourceManager.GetObject("download__1_") as Image;
            PictureBox pbProfile = new PictureBox { Size = new Size(110, 110), Location = new Point(65, 30), SizeMode = PictureBoxSizeMode.StretchImage, Image = profileImg, Parent = pnlSidebar };
            Label lblName = new Label { Text = "ENTREPRENEUR NAME", ForeColor = Color.White, Font = new Font("Arial", 10, FontStyle.Bold), Location = new Point(10, 150), Size = new Size(220, 25), TextAlign = ContentAlignment.MiddleCenter, Parent = pnlSidebar };
            Label lblRevenue = new Label { Text = "Total Revenue:\nUGX 4,850,000", ForeColor = Color.Gold, Font = new Font("Arial", 12, FontStyle.Bold), Location = new Point(10, 190), Size = new Size(220, 60), TextAlign = ContentAlignment.MiddleCenter, Parent = pnlSidebar };

            // --- 3. TOP SECTION (HEADING & NOTIFICATION) ---
            Label lblHeader = new Label { Text = "WELCOME BACK:)", Font = new Font("Arial", 28, FontStyle.Bold), ForeColor = Color.White, Location = new Point(270, 20), AutoSize = true, Parent = this };

            // NOTIFICATION BAR
            Panel pnlNotify = new Panel { Location = new Point(270, 85), Size = new Size(900, 45), BackColor = Color.FromArgb(255, 128, 0), Parent = this };
            Label lblNotifyText = new Label { Text = "🔔 NOTIFICATION BAR: You have 3 orders waiting for confirmation.", ForeColor = Color.Black, Font = new Font("Arial", 11, FontStyle.Bold), Location = new Point(15, 12), AutoSize = true, Parent = pnlNotify };

            // --- 4. MAIN WORKSPACE PANEL ---
            Panel pnlMain = new Panel { Location = new Point(270, 150), Size = new Size(950, 650), BackColor = Color.Transparent, Parent = this };

            // Manage Products Section
            Label lblManage = new Label { Text = "MANAGE PRODUCTS", ForeColor = Color.White, Font = new Font("Arial", 14, FontStyle.Bold), Location = new Point(0, 0), AutoSize = true, Parent = pnlMain };

            Button btnAdd = new Button { Text = "CLICK TO ADD", Size = new Size(200, 50), Location = new Point(0, 40), BackColor = Color.FromArgb(0, 122, 204), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Parent = pnlMain };
            Button btnRemove = new Button { Text = "CLICK TO REMOVE", Size = new Size(200, 50), Location = new Point(220, 40), BackColor = Color.Firebrick, ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Parent = pnlMain };

            // Recent Orders Section
            Label lblOrders = new Label { Text = "RECENT ORDERS", ForeColor = Color.White, Font = new Font("Arial", 14, FontStyle.Bold), Location = new Point(0, 110), AutoSize = true, Parent = pnlMain };

            FlowLayoutPanel flowOrders = new FlowLayoutPanel { Location = new Point(0, 150), Size = new Size(900, 450), AutoScroll = true, Parent = pnlMain };

            // Sample Order Rows
            string[] items = { "Phone", "Watch", "Earphones" };
            foreach (var item in items)
            {
                var localItem = item;
                Panel row = new Panel { Size = new Size(850, 70), BackColor = Color.FromArgb(55, 55, 60), Margin = new Padding(0, 0, 0, 10), Parent = flowOrders };
                Label details = new Label { Text = localItem + " - Awaiting Confirmation", ForeColor = Color.LightGray, Location = new Point(20, 25), AutoSize = true, Parent = row };
                Button btnConfirm = new Button { Text = "Confirm", Size = new Size(100, 30), Location = new Point(700, 20), BackColor = Color.Green, ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Parent = row };
                btnConfirm.Click += (s, e) => MessageBox.Show(localItem + " confirmed!");
            }

            // 5. Final Step: Bring everything to front to kill the white screen
            foreach (Control c in this.Controls) c.BringToFront();
            pnlSidebar.SendToBack(); // Keep sidebar behind the labels
        }

        // Minimal InitializeComponent - ensures form exists when designer file is absent
        private void MinimalInitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        // Try to call designer InitializeComponent if present
        private bool TryCallDesignerInitialize()
        {
            try
            {
                var mi = this.GetType().GetMethod("InitializeComponent", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Public);
                if (mi != null && mi.DeclaringType != typeof(EntrepreneurForm))
                {
                    mi.Invoke(this, null);
                    return true;
                }
            }
            catch
            {
                // ignore
            }
            return false;
        }
    }
}
