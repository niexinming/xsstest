<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="xsstest.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        #Text1 {
            height: 20px;
            width: 249px;
        }
        #Text2 {
            width: 251px;
        }
        #Button2 {
            width: 192px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
  
    
        <asp:Label ID="Label1" runat="server" Font-Size="XX-Large" Text="姓名"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;
        <input id="Text1" type="text" runat="server" /><br/>
         <asp:Label ID="Label2" runat="server" Font-Size="XX-Large" Text="密码"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;
        <input id="Text2" type="password" runat="server" /><br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="提   交" Width="158px" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <input type="button" id="Button2" value="注册" onclick="javascript:location.href='http://localhost:35767/register.aspx'" />
        <br />
       
        <asp:Label ID="Label3" runat="server"></asp:Label>
    </form>
</body>
</html>
