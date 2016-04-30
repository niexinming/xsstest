<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="viewcode.aspx.cs" Inherits="xsstest.viewcode" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <h1><a href="http://localhost:35767/createcode.aspx">新建项目</a></h1>
    <form id="form1" runat="server">
   
        <asp:GridView ID="GridView1" runat="server" Height="348px" Width="731px" OnRowDeleting="GridView1_RowDeleting" AutoGenerateColumns="False" EnableModelValidation="True" OnSelectedIndexChanged="GridView1_SelectedIndexChanged1" OnRowEditing="GridView1_RowEditing" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" GridLines="None"
>
            <Columns>
                <asp:BoundField DataField="codeid" HeaderText="项目id" ReadOnly="True" />
                 <asp:BoundField DataField="mycodename" HeaderText="项目名称" />
                 <asp:BoundField DataField="path" HeaderText="项目地址" />
                 
                  <asp:CommandField HeaderText="查看cookie" ShowSelectButton="True" />

                 <asp:CommandField HeaderText="查看项目代码" ShowEditButton="True" EditText="查看" />

                 <asp:CommandField HeaderText="删除项目" ShowDeleteButton="True" />
                  
            </Columns>
            <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
            <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
            <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
        </asp:GridView>
    </form>
</body>
</html>

