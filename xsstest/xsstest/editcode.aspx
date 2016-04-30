<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="editcode.aspx.cs" Inherits="xsstest.editcode" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
   
   
   
    <form id="form1" runat="server">
        <asp:FormView ID="FormView1" runat="server" EnableModelValidation="True" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" >

            <EditRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
            <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />

            <ItemTemplate>
                codeid:
            <asp:TextBox ID="codeid" runat="server" Text='<%# Eval("codeid") %>'
　Width="122px"></asp:TextBox><br /><br /><br />
              项目名称:
                <asp:TextBox ID="mycodename" runat="server" Text='<%# Eval("mycodename") %>'
　Width="122px"></asp:TextBox><br /><br /><br />
                代码内容:<br />
                 <asp:TextBox ID="mycodedocument" runat="server" Text='<%# Eval("mycodedocument") %>' TextMode="MultiLine" 
　Width="900px" Height="900"></asp:TextBox><br /><br /><br />
                备注:<br />
                <asp:TextBox ID="beizhu" runat="server" Text='<%# Eval("beizhu") %>' TextMode="MultiLine" 
　Width="122px"></asp:TextBox><br /><br /><br />
               <asp:Button ID="button1" Width="200" Height="100" Runat="server" Text="提交编辑代码" CommandName="Add" />
            </ItemTemplate>
                
            <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                
        </asp:FormView>
        <asp:Button ID="Button1"  runat="server" OnClick="Button1_Click" Text="静态化代码" />
        <br />
        代码的路径为：<asp:Label ID="Label1" runat="server"></asp:Label>
        
        
        
    </form>
   
   
   
</body>
</html>
