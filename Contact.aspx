<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="CrudGridView.Contact" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Contact Info</h1>

        </div>
        <asp:GridView ID="gvContactInfo" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3"
            AutoGenerateColumns="false" ShowFooter="true" 
            DataKeyNames="ContactID"  
            ShowHeaderWhenEmpty="true" 
            onRowCommand="gvContactInfo_RowCommand"
            onRowEditing="gvContactInfo_RowEditing"
            onRowDeleting="gvContactInfo_RowDeleting"
            onRowUpdating="gvContactInfo_RowUpdating"
            onRowCancelingEdit="gvContactInfo_RowCancelingEdit"
>
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />

            <Columns>

                <asp:TemplateField HeaderText="First Name">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("FirstName") %>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtFirstName" Text='<%# Eval("FirstName") %>' runat="server" />
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtFirstNameFooter" Text='<%# Eval("FirstName") %>' runat="server" />
                    </FooterTemplate>

                </asp:TemplateField>
                <asp:TemplateField HeaderText="Last Name">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("LastName") %>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtLastName" Text='<%# Eval("LastName") %>' runat="server" />
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtLastNameFooter" Text='<%# Eval("LastName") %>' runat="server" />
                    </FooterTemplate>
                </asp:TemplateField>


                <asp:TemplateField HeaderText="Contact">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("ContactNo") %>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtContact" Text='<%# Eval("ContactNo") %>' runat="server" />
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtContactFooter" Text='<%# Eval("ContactNo") %>' runat="server" />
                    </FooterTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Email">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("Email") %>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtEmail" Text='<%# Eval("Email") %>' runat="server" />
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtEmailFooter" Text='<%# Eval("Email") %>' runat="server" />
                    </FooterTemplate>
                </asp:TemplateField>


                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:ImageButton ImageUrl="~/Images/Edit.jpg" runat="server" CommandName="Edit" ToolTip="Edit" Width="40px" Height="40px" />
                        <asp:ImageButton ImageUrl="~/Images/delete.png" runat="server" CommandName="Delete" ToolTip="Delete" Width="30px" Height="30px" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:ImageButton ImageUrl="~/Images/Save.png" runat="server" CommandName="Update" ToolTip="Save" Width="30px" Height="30px" />
                        <asp:ImageButton ImageUrl="~/Images/Cancel.png" runat="server" CommandName="Cancel" ToolTip="Cancel" Width="30px" Height="30px" />
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:ImageButton ImageUrl="~/Images/add.png" runat="server" CommandName="AddNew" ToolTip="Add" Width="30px" Height="30px" />
                    </FooterTemplate>
                </asp:TemplateField>


            </Columns>

        </asp:GridView>
                    <asp:Label ID="lblSuccesMsg" runat="server" Text="" ForeColor="Green"></asp:Label>
                    <asp:Label ID="lblErrorMsg" runat="server" Text="" ForeColor="Red"></asp:Label>

        
    </form>
</body>
</html>
