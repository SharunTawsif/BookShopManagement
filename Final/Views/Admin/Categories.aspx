<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Categories.aspx.cs" Inherits="Final.Views.Admin.Categories" %>
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
            margin-top: 250px;
            margin-bottom: 20px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MyContent" runat="server">
    <form runat="server">
        <div class="row mt-4"> 
            <div class="col-md-12">
                <h1 class="text-center page-header">Manage Categories</h1>
            </div>
        </div>

        <div class="row mt-3">
   
            <div class="col-md-6">
                <div class="mt-3">
                    <label for="txtCategoryName" class="form-label text-success">Category Name</label>
                    <asp:TextBox ID="txtCategoryName" runat="server" CssClass="form-control form-control-lg custom-input" placeholder="Category Name" autocomplete="off"></asp:TextBox>
                </div>
                <div class="mt-3">
                    <label for="txtCategoryDesc" class="form-label text-success">Category Description</label>
                    <asp:TextBox ID="txtCategoryDesc" runat="server" CssClass="form-control form-control-lg custom-input" placeholder="Category Description" autocomplete="off"></asp:TextBox>
                </div>
                <div class="mt-3">
                    <asp:Label runat="server" ID="lblErrorMessage" CssClass="text-danger"></asp:Label>
                </div>
                <div class="row mt-3">
                    <div class="col-md-12">
                        <div class="button-row">
                            <asp:Button Text="Update" runat="server" ID="btnUpdate" CssClass="btn btn-warning btn-block" OnClick="btnUpdate_Click" />
                            <asp:Button Text="Save" runat="server" ID="btnSave" CssClass="btn btn-success btn-block" OnClick="btnSave_Click" />
                            <asp:Button Text="Delete" runat="server" ID="btnDelete" CssClass="btn btn-danger btn-block" OnClick="btnDelete_Click" />
                        </div>
                    </div>
                </div>
            </div>

    
            <div class="col-md-6">
                <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered" AutoGenerateSelectButton="True" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
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
