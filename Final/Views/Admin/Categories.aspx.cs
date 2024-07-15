using System;
using System.Data;
using System.Web.UI.WebControls;
using Final.Models;

namespace Final.Views.Admin
{
    public partial class Categories : System.Web.UI.Page
    {
        Functions Con;

        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Functions();

            if (!IsPostBack)
            {
                ShowCategories();
            }
        }

        protected void ShowCategories()
        {
            string query = "SELECT Catid, CatName, CatDescription FROM categoryTb1";
            GridView1.DataSource = Con.GetData(query);
            GridView1.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string categoryName = txtCategoryName.Text.Trim();
            string categoryDesc = txtCategoryDesc.Text.Trim();

            if (string.IsNullOrEmpty(categoryName) || string.IsNullOrEmpty(categoryDesc))
            {
                lblErrorMessage.Text = "Category Name and Description are required.";
                return;
            }

            string query = $"INSERT INTO categoryTb1 (CatName, CatDescription) VALUES ('{categoryName}', '{categoryDesc}')";
            int rowsAffected = Con.SetData(query);

            if (rowsAffected > 0)
            {
                ShowCategories();
                ClearFields();
                lblErrorMessage.Text = "Category added successfully.";
            }
            else
            {
                lblErrorMessage.Text = "Failed to add category.";
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (GridView1.SelectedIndex < 0)
            {
                lblErrorMessage.Text = "Select a category to update.";
                return;
            }

            int categoryId = Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text);
            string categoryName = txtCategoryName.Text.Trim();
            string categoryDesc = txtCategoryDesc.Text.Trim();

            if (string.IsNullOrEmpty(categoryName) || string.IsNullOrEmpty(categoryDesc))
            {
                lblErrorMessage.Text = "Category Name and Description are required.";
                return;
            }

            string query = $"UPDATE categoryTb1 SET CatName='{categoryName}', CatDescription='{categoryDesc}' WHERE Catid={categoryId}";
            int rowsAffected = Con.SetData(query);

            if (rowsAffected > 0)
            {
                ShowCategories();
                ClearFields();
                lblErrorMessage.Text = "Category updated successfully.";
            }
            else
            {
                lblErrorMessage.Text = "Failed to update category.";
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (GridView1.SelectedIndex < 0)
            {
                lblErrorMessage.Text = "Select a category to delete.";
                return;
            }

            int categoryId = Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text);
            string query = $"DELETE FROM categoryTb1 WHERE Catid={categoryId}";
            int rowsAffected = Con.SetData(query);

            if (rowsAffected > 0)
            {
                ShowCategories();
                ClearFields();
                lblErrorMessage.Text = "Category deleted successfully.";
            }
            else
            {
                lblErrorMessage.Text = "Failed to delete category.";
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            txtCategoryName.Text = row.Cells[2].Text;
            txtCategoryDesc.Text = row.Cells[3].Text;
        }

        private void ClearFields()
        {
            txtCategoryName.Text = string.Empty;
            txtCategoryDesc.Text = string.Empty;
            lblErrorMessage.Text = string.Empty;
        }
    }
}
