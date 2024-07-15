using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace Final.Views
{
    public partial class Books : System.Web.UI.Page
    {
        private readonly string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\sharu\Documents\PROJECTASPDB.mdf;Integrated Security=True;Connect Timeout=30";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindAuthorsDropdown();
                BindCategoriesDropdown();
                BindBooksGrid();
            }
        }

        private void BindAuthorsDropdown()
        {
            string query = "SELECT AutId, AutName FROM AuthorTb1";
            DataTable dt = GetData(query);
            DropDownList2.DataSource = dt;
            DropDownList2.DataTextField = "AutName";
            DropDownList2.DataValueField = "AutId";
            DropDownList2.DataBind();
        }

        private void BindCategoriesDropdown()
        {
            string query = "SELECT Catid, CatName FROM categoryTb1";
            DataTable dt = GetData(query);
            DropDownList1.DataSource = dt;
            DropDownList1.DataTextField = "CatName";
            DropDownList1.DataValueField = "Catid";
            DropDownList1.DataBind();
        }

        private void BindBooksGrid()
        {
            string query = @"
                SELECT b.BId, b.BName, a.AutName AS BAuthor, c.CatName AS BCategory, b.BQty, b.BPrice
                FROM BookTb1 b
                INNER JOIN AuthorTb1 a ON b.BAuthor = a.AutId
                INNER JOIN categoryTb1 c ON b.BCategory = c.Catid";
            DataTable dt = GetData(query);
            GridView1.DataSource = dt;
            GridView1.DataKeyNames = new string[] { "BId" };
            GridView1.DataBind();
        }

        protected void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string booksTitle = BooksTitle.Value;
                int booksAuthor = Convert.ToInt32(DropDownList2.SelectedValue);
                int booksCategory = Convert.ToInt32(DropDownList1.SelectedValue);
                int price = Convert.ToInt32(Price.Value);
                int quantity = Convert.ToInt32(Quantity.Value);

                string query = "INSERT INTO BookTb1 (BName, BAuthor, BCategory, BQty, BPrice) " +
                               "VALUES (@BName, @BAuthor, @BCategory, @BQty, @BPrice)";

                ExecuteNonQuery(query,
                    "@BName", booksTitle,
                    "@BAuthor", booksAuthor,
                    "@BCategory", booksCategory,
                    "@BQty", quantity,
                    "@BPrice", price);

                BindBooksGrid(); // Rebind GridView after saving
                ClearFields();
            }
            catch (Exception ex)
            {
                ShowErrorMessage("Error saving book: " + ex.Message);
            }
        }

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int bookId = Convert.ToInt32(GridView1.SelectedDataKey.Value);
                string booksTitle = BooksTitle.Value;
                int booksAuthor = Convert.ToInt32(DropDownList2.SelectedValue);
                int booksCategory = Convert.ToInt32(DropDownList1.SelectedValue);
                int price = Convert.ToInt32(Price.Value);
                int quantity = Convert.ToInt32(Quantity.Value);

                string query = "UPDATE BookTb1 SET BName=@BName, BAuthor=@BAuthor, BCategory=@BCategory, BQty=@BQty, BPrice=@BPrice WHERE BId=@BId";

                ExecuteNonQuery(query,
                    "@BId", bookId,
                    "@BName", booksTitle,
                    "@BAuthor", booksAuthor,
                    "@BCategory", booksCategory,
                    "@BQty", quantity,
                    "@BPrice", price);

                BindBooksGrid(); // Rebind GridView after updating
                ClearFields();
            }
            catch (Exception ex)
            {
                ShowErrorMessage("Error updating book: " + ex.Message);
            }
        }

        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int bookId = Convert.ToInt32(GridView1.SelectedDataKey.Value);

                string query = "DELETE FROM BookTb1 WHERE BId=@BId";

                ExecuteNonQuery(query, "@BId", bookId);

                BindBooksGrid(); // Rebind GridView after deleting
                ClearFields();
            }
            catch (Exception ex)
            {
                ShowErrorMessage("Error deleting book: " + ex.Message);
            }
        }

        private void ClearFields()
        {
            BooksTitle.Value = string.Empty;
            DropDownList2.SelectedIndex = 0;
            DropDownList1.SelectedIndex = 0;
            Price.Value = string.Empty;
            Quantity.Value = string.Empty;
            GridView1.SelectedIndex = -1;
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            BooksTitle.Value = GridView1.SelectedRow.Cells[2].Text;
            DropDownList2.SelectedValue = GetAuthorIdByName(GridView1.SelectedRow.Cells[3].Text).ToString();
            DropDownList1.SelectedValue = GetCategoryIdByName(GridView1.SelectedRow.Cells[4].Text).ToString();
            Quantity.Value = GridView1.SelectedRow.Cells[5].Text;
            Price.Value = GridView1.SelectedRow.Cells[6].Text;
        }

        private int GetAuthorIdByName(string authorName)
        {
            string query = "SELECT AutId FROM AuthorTb1 WHERE AutName=@AutName";
            DataTable dt = GetData(query, "@AutName", authorName);
            if (dt.Rows.Count > 0)
            {
                return Convert.ToInt32(dt.Rows[0]["AutId"]);
            }
            return -1;
        }

        private int GetCategoryIdByName(string categoryName)
        {
            string query = "SELECT Catid FROM categoryTb1 WHERE CatName=@CatName";
            DataTable dt = GetData(query, "@CatName", categoryName);
            if (dt.Rows.Count > 0)
            {
                return Convert.ToInt32(dt.Rows[0]["Catid"]);
            }
            return -1;
        }

        private DataTable GetData(string query, params object[] parameters)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    for (int i = 0; i < parameters.Length; i += 2)
                    {
                        cmd.Parameters.AddWithValue(parameters[i].ToString(), parameters[i + 1]);
                    }

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        private void ExecuteNonQuery(string query, params object[] parameters)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    for (int i = 0; i < parameters.Length; i += 2)
                    {
                        cmd.Parameters.AddWithValue(parameters[i].ToString(), parameters[i + 1]);
                    }

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void ShowErrorMessage(string message)
        {
            ErrMsg.Text = message;
        }
    }
}
