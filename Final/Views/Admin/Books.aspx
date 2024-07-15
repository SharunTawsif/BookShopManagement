<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Books.aspx.cs" Inherits="Final.Views.Books" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .custom-input {
            width: 100%;
            height: 50px;
            padding: 10px;
            font-size: 1rem;
        }
        .button-row {
            margin-top: 10px;
        }
        .custom-dropdown {
            width: 100%;
            height: 50px;
            font-size: 1rem;
        }
        .btn {
            width: 200px;
            margin-right: 10px;
        }
        .btn-block {
            display: block;
            width: 100%;
        }
        .page-header {
            margin-top: 50px;
            margin-bottom: 20px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MyContent" runat="server">
    <form runat="server">
        <div class="row mt-4">
            <div class="col-md-12">
                <h1 class="text-center page-header">Manage Books</h1>
            </div>
        </div>

        <div class="row mt-3">
            <div class="col-md-6">
                <div class="mt-3">
                    <label for="BooksTitle" class="form-label text-success">Books Title</label>
                    <input type="text" id="BooksTitle" runat="server" class="form-control form-control-lg custom-input" placeholder="Books Title" autocomplete="off" />
                </div>
                <div class="mt-3">
                    <label for="BooksAuthor" class="form-label text-success">Books Author</label>
                    <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control custom-dropdown"></asp:DropDownList>
                </div>
                <div class="mt-3">
                    <label for="Categories" class="form-label text-success">Categories</label>
                    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control custom-dropdown"></asp:DropDownList>
                </div>
                <div class="mt-3">
                    <label for="Price" class="form-label text-success">Price</label>
                    <input type="text" id="Price" runat="server" class="form-control form-control-lg custom-input" placeholder="Price" autocomplete="off" />
                </div>
                <div class="mt-3">
                    <label for="Quantity" class="form-label text-success">Quantity</label>
                    <input type="text" id="Quantity" runat="server" class="form-control form-control-lg custom-input" placeholder="Quantity" autocomplete="off" />
                </div>
                <div class="mt-3">
                    <asp:Label runat="server" ID="ErrMsg" CssClass="text-danger"></asp:Label>
                </div>
                <div class="row mt-3">
                    <div class="col-md-12">
                        <div class="button-row">
                            <asp:Button Text="Update" runat="server" ID="UpdateBtn" CssClass="btn btn-warning btn-block" OnClick="UpdateBtn_Click" />
                            <asp:Button Text="Save" runat="server" ID="SaveBtn" CssClass="btn btn-success btn-block" OnClick="SaveBtn_Click" />
                            <asp:Button Text="Delete" runat="server" ID="DeleteBtn" CssClass="btn btn-danger btn-block" OnClick="DeleteBtn_Click" />
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-md-6">
                <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered" AutoGenerateColumns="False" AutoGenerateSelectButton="True" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="BId" HeaderText="ID" ReadOnly="True" />
                        <asp:BoundField DataField="BName" HeaderText="Book Title" />
                        <asp:BoundField DataField="BAuthor" HeaderText="Author" />
                        <asp:BoundField DataField="BCategory" HeaderText="Category" />
                        <asp:BoundField DataField="BQty" HeaderText="Quantity" />
                        <asp:BoundField DataField="BPrice" HeaderText="Price" />
                    </Columns>
                    <AlternatingRowStyle BackColor="White" />
                    <EditRowStyle BackColor="#7C6F57" />
                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#E3EAEB" />
                    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F8FAFA" />
                    <SortedAscendingHeaderStyle BackColor="#246B61" />
                    <SortedDescendingCellStyle BackColor="#D4DFE1" />
                    <SortedDescendingHeaderStyle BackColor="#15524A" />
                </asp:GridView>
            </div>
        </div>
    </form>
</asp:Content>
