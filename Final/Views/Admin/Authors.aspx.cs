using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using Final.Models;

namespace Final.Views.Admin
{
    public partial class Authors : System.Web.UI.Page
    {
        Functions Con;

        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Functions();
            if (!IsPostBack)
            {
                ShowAuthors();
            }
        }

        private void ShowAuthors()
        {
            try
            {
                string query = "SELECT AutId, AutName, AutGender, AutCountry FROM AuthorTb1";
                AuthorList.DataSource = Con.GetData(query);
                AuthorList.DataBind();
            }
            catch (Exception ex)
            {
                ErrMsg.Text = "Error fetching authors: " + ex.Message;
            }
        }

        protected void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(ANnameTb.Text) || string.IsNullOrEmpty(GenCb.SelectedValue) || string.IsNullOrEmpty(CountryCb.SelectedValue))
                {
                    ErrMsg.Text = "All fields are required.";
                    return;
                }

                string authorName = ANnameTb.Text;
                string authorGender = GenCb.SelectedValue;
                string authorCountry = CountryCb.SelectedValue;

                string query = $"INSERT INTO AuthorTb1 (AutName, AutGender, AutCountry) VALUES ('{authorName}', '{authorGender}', '{authorCountry}')";
                Con.SetData(query);
                ShowAuthors();
                ClearFields();
            }
            catch (Exception ex)
            {
                ErrMsg.Text = "Error saving author: " + ex.Message;
            }
        }

        protected void EditBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (AuthorList.SelectedRow == null)
                {
                    ErrMsg.Text = "Select an author to edit.";
                    return;
                }

                int authorId = Convert.ToInt32(AuthorList.SelectedRow.Cells[1].Text);
                string authorName = ANnameTb.Text;
                string authorGender = GenCb.SelectedValue;
                string authorCountry = CountryCb.SelectedValue;

                string query = $"UPDATE AuthorTb1 SET AutName='{authorName}', AutGender='{authorGender}', AutCountry='{authorCountry}' WHERE AutId={authorId}";
                Con.SetData(query);
                ShowAuthors();
                ClearFields();
            }
            catch (Exception ex)
            {
                ErrMsg.Text = "Error updating author: " + ex.Message;
            }
        }

        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (AuthorList.SelectedRow == null)
                {
                    ErrMsg.Text = "Select an author to delete.";
                    return;
                }

                int authorId = Convert.ToInt32(AuthorList.SelectedRow.Cells[1].Text);
                string query = $"DELETE FROM AuthorTb1 WHERE AutId={authorId}";
                Con.SetData(query);
                ShowAuthors();
                ClearFields();
            }
            catch (Exception ex)
            {
                ErrMsg.Text = "Error deleting author: " + ex.Message;
            }
        }

        protected void AuthorList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = AuthorList.SelectedRow;
                ANnameTb.Text = row.Cells[2].Text;
                GenCb.SelectedValue = row.Cells[3].Text;
                CountryCb.SelectedValue = row.Cells[4].Text;
            }
            catch (Exception ex)
            {
                ErrMsg.Text = "Error selecting author: " + ex.Message;
            }
        }

        private void ClearFields()
        {
            ANnameTb.Text = string.Empty;
            GenCb.SelectedIndex = -1;
            CountryCb.SelectedIndex = -1;
            ErrMsg.Text = string.Empty;
        }
    }
}
