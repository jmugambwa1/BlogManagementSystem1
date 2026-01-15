using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using BlogManagementSystem.Data;


namespace BlogManagementSystem
{
    public partial class CategoriesForm : Form
    {
        public CategoriesForm()
        {
            InitializeComponent();
        }

        private int selectedCategoryId = -1;

        private void panelCategories_Paint(object sender, PaintEventArgs e)
        {

        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            LoadCategories();
            ClearFields();
        }


        private void LoadCategories()
        {
            dgvCategories.Rows.Clear();

            using (SqlConnection con = Database.GetConnection())
            {
                string query = "SELECT CategoryId, Name, Description FROM Categories";
                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    dgvCategories.Rows.Add(
                        reader["CategoryId"],
                        reader["Name"].ToString(),
                        reader["Description"].ToString()
                    );
                }
            }
            dgvCategories.ClearSelection();

        }

        private void CategoriesForm_Load(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            txtCategoryName.Clear();
            txtDescription.Clear();
            selectedCategoryId = -1;

            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCategoryName.Text))
            {
                MessageBox.Show("Category name is required.");
                return;
            }

            try
            {
                using (SqlConnection conn = Database.GetConnection())
                {
                    string query = "INSERT INTO Categories (Name, Description) VALUES (@name, @desc)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@name", txtCategoryName.Text.Trim());
                    cmd.Parameters.AddWithValue("@desc", txtDescription.Text.Trim());

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Category added successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadCategories();
                ClearFields();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601)
                {
                    MessageBox.Show("Category already exists.",
                        "Duplicate Category",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedCategoryId == -1)
            {
                MessageBox.Show("Select a category to update.");
                return;
            }

            using (SqlConnection con = Database.GetConnection())
            {
                string query = "UPDATE Categories SET Name=@name, Description=@desc WHERE CategoryId=@id";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@name", txtCategoryName.Text.Trim());
                cmd.Parameters.AddWithValue("@desc", txtDescription.Text.Trim());
                cmd.Parameters.AddWithValue("@id", selectedCategoryId);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            LoadCategories();
            ClearFields();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedCategoryId == -1)
            {
                MessageBox.Show("Select a category to delete.");
                return;
            }

            if (MessageBox.Show("Delete this category?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;

            using (SqlConnection con = Database.GetConnection())
            {
                string query = "DELETE FROM Categories WHERE CategoryId=@id";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@id", selectedCategoryId);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            LoadCategories();
            ClearFields();
        }

        private void dgvCategories_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCategories.SelectedRows.Count == 0)
                return;

            DataGridViewRow row = dgvCategories.SelectedRows[0];

            if (row.Cells[0].Value == null)
                return;

            selectedCategoryId = Convert.ToInt32(row.Cells[0].Value);
            txtCategoryName.Text = row.Cells[1].Value?.ToString() ?? "";
            txtDescription.Text = row.Cells[2].Value?.ToString() ?? "";

            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void dgvCategories_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }


}
