using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BlogManagementSystem.Data;
using System.Data.SqlClient;


namespace BlogManagementSystem
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("All fields are required.",
                                "Validation Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            if (!chkAgreeTerms.Checked)
            {
                MessageBox.Show("You must agree to the Terms and Services.",
                                "Validation Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();

                    string query = @"INSERT INTO Users (Username, Email, PasswordHash)
                             VALUES (@Username, @Email, @PasswordHash)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", txtUsername.Text.Trim());
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@PasswordHash", txtPassword.Text.Trim()); // hash later

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Registration successful!",
                                "Success",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                // Go back to LoginForm
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
                this.Close();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627) // UNIQUE constraint violation
                {
                    MessageBox.Show("Username already exists.",
                                    "Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Database error: " + ex.Message);
                }
            }
        }

        private void linkLblLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            panelRegister.Left = (this.ClientSize.Width - panelRegister.Width) / 2;
            panelRegister.Top = (this.ClientSize.Height - panelRegister.Height) / 2;
        }
    }
}
