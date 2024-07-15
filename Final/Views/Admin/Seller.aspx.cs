using System;
using System.Data;
using System.Web.UI.WebControls;
using Final.Models;

namespace Final.Views.Admin
{
    public partial class Seller : System.Web.UI.Page
    {
        Functions Con;

        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Functions();

            if (!IsPostBack)
            {
                ShowSellers();
            }
        }

        private void ShowSellers()
        {
            string query = "SELECT SelId, SelName, SelEmail, SelPhone, SelAddress FROM SellerTb1";
            SellerList.DataSource = Con.GetData(query);
            SellerList.DataBind();
        }

        protected void SaveBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SellerNameTb.Text) || string.IsNullOrEmpty(SellerEmailTb.Text) || string.IsNullOrEmpty(SellerPhoneTb.Text) || string.IsNullOrEmpty(SellerAddressTb.Text))
            {
                ErrMsg.Text = "All fields are required.";
                return;
            }

            string sellerName = SellerNameTb.Text;
            string sellerEmail = SellerEmailTb.Text;
            string sellerPhone = SellerPhoneTb.Text;
            string sellerAddress = SellerAddressTb.Text;

            string query = $"INSERT INTO SellerTb1 (SelName, SelEmail, SelPhone, SelAddress) VALUES ('{sellerName}', '{sellerEmail}', '{sellerPhone}', '{sellerAddress}')";
            Con.SetData(query);
            ShowSellers();
            ClearFields();
        }

        protected void EditBtn_Click(object sender, EventArgs e)
        {
            if (SellerList.SelectedRow == null)
            {
                ErrMsg.Text = "Select a seller to edit.";
                return;
            }

            if (string.IsNullOrEmpty(SellerNameTb.Text) || string.IsNullOrEmpty(SellerEmailTb.Text) || string.IsNullOrEmpty(SellerPhoneTb.Text) || string.IsNullOrEmpty(SellerAddressTb.Text))
            {
                ErrMsg.Text = "All fields are required.";
                return;
            }

            int sellerId = Convert.ToInt32(SellerList.SelectedRow.Cells[1].Text);
            string sellerName = SellerNameTb.Text;
            string sellerEmail = SellerEmailTb.Text;
            string sellerPhone = SellerPhoneTb.Text;
            string sellerAddress = SellerAddressTb.Text;

            string query = $"UPDATE SellerTb1 SET SelName='{sellerName}', SelEmail='{sellerEmail}', SelPhone='{sellerPhone}', SelAddress='{sellerAddress}' WHERE SelId={sellerId}";
            Con.SetData(query);
            ShowSellers();
            ClearFields();
        }

        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (SellerList.SelectedRow == null)
            {
                ErrMsg.Text = "Select a seller to delete.";
                return;
            }

            int sellerId = Convert.ToInt32(SellerList.SelectedRow.Cells[1].Text);
            string query = $"DELETE FROM SellerTb1 WHERE SelId={sellerId}";
            Con.SetData(query);
            ShowSellers();
            ClearFields();
        }

        protected void SellerList_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = SellerList.SelectedRow;
            SellerNameTb.Text = row.Cells[2].Text;
            SellerEmailTb.Text = row.Cells[3].Text;
            SellerPhoneTb.Text = row.Cells[4].Text;
            SellerAddressTb.Text = row.Cells[5].Text;
        }

        private void ClearFields()
        {
            SellerNameTb.Text = string.Empty;
            SellerEmailTb.Text = string.Empty;
            SellerPhoneTb.Text = string.Empty;
            SellerAddressTb.Text = string.Empty;
            ErrMsg.Text = string.Empty;
        }
    }
}
