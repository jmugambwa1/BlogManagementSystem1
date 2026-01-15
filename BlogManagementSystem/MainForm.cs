using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace BlogManagementSystem
{
    public partial class MainForm : Form
    {
        private string _username;

        public MainForm()
        {
            InitializeComponent();
        }

        public MainForm(string username) : this()
        {
            _username = username;
        }

        private void SetActiveButton(Button activeButton)
        {
            foreach (Control ctrl in panelSidebar.Controls)
            {
                if (ctrl is Button btn)
                {
                    btn.BackColor = Color.Transparent;
                    btn.ForeColor = Color.FromArgb(17, 24, 39);
                }
            }

            activeButton.BackColor = Color.FromArgb(237, 233, 254);
            activeButton.ForeColor = Color.FromArgb(124, 58, 237);
        }

        private void LoadContent(Form form)
        {
            panelContent.Controls.Clear();

            form.TopLevel = false;
            form.Dock = DockStyle.Fill;

            panelContent.Controls.Add(form);
            form.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = $"Welcome back, {CurrentUser.Username}!";
            var dashboard = new DashboardForm(_username);
            dashboard.CreatePostRequested += OpenPostEditor;

            LoadContent(dashboard);
            SetActiveButton(btnDashboard);
            ApplyRolePermissions();
        }

        private void ApplyRolePermissions()
        {
            if (CurrentUser.Role == "User")
            {
                btnCategories.Visible = false;
            }
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            LoadContent(new CategoriesForm());
            SetActiveButton(btnCategories);
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            var dashboard = new DashboardForm(_username);
            dashboard.CreatePostRequested += OpenPostEditor;

            LoadContent(dashboard);
            SetActiveButton(btnDashboard);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to sign out?",
                "Sign Out",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnPosts_Click(object sender, EventArgs e)
        {
            LoadContent(new PostsForm());
            SetActiveButton(btnPosts);
        }

        private void OpenPostEditor()
        {
            PostEditorForm form = new PostEditorForm();
            form.ShowDialog();

            btnDashboard_Click(null, null);
        }

    }



}
