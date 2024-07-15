<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Authors.aspx.cs" Inherits="Final.Views.Admin.Authors" %>
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
    <form runat="server"> <!-- Ensure this form tag encompasses all server controls -->
        <div class="row mt-4"> <!-- Added mt-4 for top margin -->
            <div class="col-md-12">
                <h1 class="text-center page-header">Manage Authors</h1>
            </div>
        </div>

        <div class="row mt-3">
            <!-- Form Inputs -->
            <div class="col-md-6">
                <div class="mt-3">
                    <label for="ANnameTb" class="form-label text-success">Author Name</label>
                    <asp:TextBox ID="ANnameTb" runat="server" CssClass="form-control form-control-lg custom-input" placeholder="Author Name" autocomplete="off"></asp:TextBox>
                </div>
                <div class="mt-3">
                    <label for="GenCb" class="form-label text-success">Author Gender</label>
                    <asp:DropDownList runat="server" CssClass="form-control custom-dropdown" ID="GenCb">
                        <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                        <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="mt-3">
                    <label for="CountryCb" class="form-label text-success">Country</label>
                    <asp:DropDownList ID="CountryCb" runat="server" CssClass="form-control custom-dropdown">
                        <asp:ListItem Text="USA" Value="USA"></asp:ListItem>
                        <asp:ListItem Text="INDIA" Value="INDIA"></asp:ListItem>
                        <asp:ListItem Text="FRANCE" Value="FRANCE"></asp:ListItem>
                        <asp:ListItem Text="UK" Value="UK"></asp:ListItem>
                        <asp:ListItem Text="SPAIN" Value="SPAIN"></asp:ListItem>
                        <asp:ListItem Text="Other" Value="Other"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="mt-3">
                    <asp:Label runat="server" ID="ErrMsg" CssClass="text-danger"></asp:Label>
                </div>
                <div class="row mt-3">
                    <div class="col-md-12">
                        <div class="button-row">
                            <asp:Button Text="Update" runat="server" ID="EditBtn" CssClass="btn btn-warning btn-block" OnClick="EditBtn_Click" />
                            <asp:Button Text="Save" runat="server" ID="SaveBtn" CssClass="btn btn-success btn-block" OnClick="SaveBtn_Click" />
                            <asp:Button Text="Delete" runat="server" ID="DeleteBtn" CssClass="btn btn-danger btn-block" OnClick="DeleteBtn_Click" />
                        </div>
                    </div>
                </div>
            </div>

            <!-- Author List -->
            <div class="col-md-6">
                <asp:GridView ID="AuthorList" runat="server" CssClass="table table-bordered" AutoGenerateSelectButton="True" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="AuthorList_SelectedIndexChanged">
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
