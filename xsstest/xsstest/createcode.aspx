<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="createcode.aspx.cs" Inherits="xsstest.createcode" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>新建</title>
    <script>
        function f()
        {
            var title = document.getElementById("codetitle").value;
            var codecontent = document.getElementById("codeducument").value;
            if(title=="")
            {
                alert("项目名称不能为空");
                document.getElementById("codetitle").focus();
                return;
            }
            if (codecontent == "") {
                alert("项目内容不能为空");
                document.getElementById("codeducument").focus();
                return;
            }
            
            this.form1.action = "createcode.aspx";
            this.form1.submit();
        }
    </script>
    <style type="text/css">
        #codeducument {
            height: 111px;
            width: 263px;
        }
        #beizhu {
            height: 77px;
            width: 285px;
        }
    </style>
</head>
<body>
    <form id="form1" method="post" action="createcode.aspx">
    项目名称：<input type="text" id="codetitle" name="codetitle" /><br /><br />
    项目内容：<textarea id="codeducument" name="codeducument"></textarea><br /><br />
    备注：<textarea id="beizhu" name="beizhu"></textarea><br /><br />
        <input type="hidden" id="flag" name="flag" value="true"/>
        <input type="button" value="提交" onclick="f()" />
    </form>
</body>
</html>
