using ONLINE_PLATFORM.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ONLINE_PLATFORM
{
    public partial class StudentUserForm : Form
    {
        // Controls used by this form (designer not present) - instantiated in InitializeComponent
        private Panel pnlSidebar;
        private PictureBox pbProfile;
        private Label lblStudentName;
        private Label lblBalance;
        private Label lblHeader;
        private FlowLayoutPanel flowNav;
        private FlowLayoutPanel flowProducts;

        public StudentUserForm()
        {
            // If there is no designer file, provide a minimal InitializeComponent implementation
            // to ensure controls exist at runtime.
            if (!TryCallDesignerInitialize())
            {
                MinimalInitializeComponent();
            }
            this.Size = new Size(1250, 850);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(64, 64, 64);

            SetupSidebar();
            SetupMainArea();
            LoadMarketItems();
        }

        // Attempt to invoke designer-generated InitializeComponent if present
        private bool TryCallDesignerInitialize()
        {
            try
            {
                // Call the designer method via reflection if it exists in this type
                var mi = this.GetType().GetMethod("InitializeComponent", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Public);
                if (mi != null && mi.DeclaringType != typeof(StudentUserForm))
                {
                    mi.Invoke(this, null);
                    return true;
                }
            }
            catch
            {
                // ignore failures and fall back to minimal init
            }
            return false;
        }

        // Minimal InitializeComponent used when designer file isn't present
        private void MinimalInitializeComponent()
        {
            this.SuspendLayout();

            pnlSidebar = new Panel();
            pbProfile = new PictureBox();
            lblStudentName = new Label();
            lblBalance = new Label();
            lblHeader = new Label();
            flowNav = new FlowLayoutPanel();
            flowProducts = new FlowLayoutPanel();

            this.Controls.Add(pnlSidebar);
            this.Controls.Add(lblHeader);
            this.Controls.Add(flowNav);
            this.Controls.Add(flowProducts);

            pnlSidebar.Controls.Add(pbProfile);
            pnlSidebar.Controls.Add(lblStudentName);
            pnlSidebar.Controls.Add(lblBalance);

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void SetupSidebar()
        {
            // 1. Sidebar Container
            if (pnlSidebar == null) return;
            pnlSidebar.Width = 220;
            pnlSidebar.Dock = DockStyle.Left; // This locks it to the left wall
            pnlSidebar.BackColor = Color.FromArgb(45, 45, 48);

            // 2. Profile Picture
            if (pbProfile != null)
            {
                pbProfile.Parent = pnlSidebar;
                pbProfile.Size = new Size(110, 110);
                pbProfile.Location = new Point(55, 30);
                pbProfile.SizeMode = PictureBoxSizeMode.StretchImage;
                pbProfile.Image = Resources.ResourceManager.GetObject("download__1_") as Image;
            }

            // 3. Student Name
            if (lblStudentName != null)
            {
                lblStudentName.Parent = pnlSidebar;
                lblStudentName.Text = "STUDENT NAME";
                lblStudentName.ForeColor = Color.White;
                lblStudentName.Font = new Font("Arial", 11, FontStyle.Bold);
                lblStudentName.Location = new Point(10, 150);
                lblStudentName.Size = new Size(200, 30);
                lblStudentName.TextAlign = ContentAlignment.MiddleCenter;
            }

            // 4. Account Balance (Dashboard)
            if (lblBalance != null)
            {
                lblBalance.Parent = pnlSidebar;
                lblBalance.Text = "Account Balance:\nUGX 50,000";
                lblBalance.ForeColor = Color.LimeGreen;
                lblBalance.Font = new Font("Arial", 11, FontStyle.Bold);
                lblBalance.Location = new Point(10, 190);
                lblBalance.Size = new Size(200, 55);
                lblBalance.TextAlign = ContentAlignment.MiddleCenter;
                lblBalance.BringToFront(); // Force visibility
            }
        }

        private void SetupMainArea()
        {
            // 5. Header (Positioned to avoid Sidebar)
            if (lblHeader != null)
            {
                lblHeader.Text = "WELCOME BACK";
                lblHeader.Font = new Font("Arial", 26, FontStyle.Bold);
                lblHeader.ForeColor = Color.White;
                lblHeader.Location = new Point(250, 20);
                lblHeader.AutoSize = true;
                lblHeader.BringToFront();
            }

            // 6. Navigation Row (Products, Books, Food, Clothing, Electronics, My Orders)
            if (flowNav != null)
            {
                flowNav.Location = new Point(250, 80);
                flowNav.Size = new Size(950, 60);
                flowNav.Controls.Clear();
                flowNav.BringToFront();

                string[] categories = { "Products", "Books", "Food", "Clothing", "Electronics" };
                foreach (string cat in categories)
                {
                    flowNav.Controls.Add(CreateStyledButton(cat, Color.FromArgb(0, 122, 204)));
                }

                // ADDING MY ORDERS BUTTON WITH FUNCTIONALITY
                Button btnOrders = CreateStyledButton("My Orders", Color.FromArgb(255, 128, 0));
                btnOrders.Click += (s, e) => { MessageBox.Show("Displaying your current and past orders...", "Order History"); };
                flowNav.Controls.Add(btnOrders);
            }

            // 7. Product Catalog (The Items Area)
            if (flowProducts != null)
            {
                flowProducts.Location = new Point(250, 160); // Placed exactly below the Nav row
                flowProducts.Size = new Size(950, 620);
                flowProducts.AutoScroll = true; // Essential so items don't disappear off-screen
                flowProducts.BringToFront();
                flowProducts.FlowDirection = FlowDirection.LeftToRight;
                flowProducts.WrapContents = true;
            }
        }

        private Button CreateStyledButton(string text, Color backColor)
        {
            return new Button
            {
                Text = text,
                Size = new Size(135, 40),
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.White,
                BackColor = backColor,
                Font = new Font("Arial", 9, FontStyle.Bold),
                Margin = new Padding(5)
            };
        }

        private void LoadMarketItems()
        {
            if (flowProducts == null) return;
            flowProducts.Controls.Clear();

            var items = new List<Tuple<string, int, Image>>
            {
                Tuple.Create("Phone", 450000, Resources.ResourceManager.GetObject("img_phone") as Image),
                Tuple.Create("Earphones", 25000, Resources.ResourceManager.GetObject("img_earphones") as Image),
                Tuple.Create("Rings", 5000, Resources.ResourceManager.GetObject("img_rings") as Image),
                Tuple.Create("Bracelets", 3500, Resources.ResourceManager.GetObject("img_bracelets") as Image),
                Tuple.Create("Watches", 15000, Resources.ResourceManager.GetObject("img_watches") as Image),
                Tuple.Create("Caps", 10000, Resources.ResourceManager.GetObject("img_caps") as Image)
            };

            foreach (var item in items)
            {
                Panel card = new Panel { Size = new Size(210, 280), BackColor = Color.FromArgb(50, 50, 55), Margin = new Padding(10) };

                PictureBox p = new PictureBox { Size = new Size(190, 130), Location = new Point(10, 10), Image = item.Item3, SizeMode = PictureBoxSizeMode.Zoom, BackColor = Color.DimGray };
                Label n = new Label { Text = item.Item1, ForeColor = Color.White, Location = new Point(10, 150), Font = new Font("Arial", 12, FontStyle.Bold), AutoSize = true };
                Label pr = new Label { Text = "UGX " + item.Item2.ToString("N0"), ForeColor = Color.Gold, Location = new Point(10, 180), AutoSize = true };
                Button b = new Button { Text = "Buy Now", Size = new Size(190, 35), Location = new Point(10, 225), BackColor = Color.DimGray, ForeColor = Color.White, FlatStyle = FlatStyle.Flat };

                card.Controls.AddRange(new Control[] { p, n, pr, b });
                flowProducts.Controls.Add(card);
            }
        }
    }
}