<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="xsstest.register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        #name,#mima1,#mail,#mima2 {
            width: 342px;
            height: 40px;
        }
    </style>
    <script language="javascript">
        var nameok=false;
        function createXmlHttpRequest(){    
               if(window.ActiveXObject){ //如果是IE浏览器    
                   return new ActiveXObject("Microsoft.XMLHTTP");    
               }else if(window.XMLHttpRequest){ //非IE浏览器    
                       return new XMLHttpRequest();    
                }    
           }    

        function f() {
            var a = document.getElementById("name").value;


            var reg = /^[a-z\d_]{3,16}/i;
            var isok = reg.test(a);
            if (isok == false)
            {
                alert("用户名必须是3-16个字母,数字,下划线");
                document.getElementById("name").focus();
                nameok=false;
                return false;
            }
            else
                nameok=true;

            var url = "http://localhost:35767/username.ashx?username="+a;
                       
               //1.创建XMLHttpRequest组建    
               xmlHttpRequest = createXmlHttpRequest();    
                   
               //2.设置回调函数    
               xmlHttpRequest.onreadystatechange = zswFun;    
                   
               //3.初始化XMLHttpRequest组建    
               xmlHttpRequest.open("GET",url,true);    
                   
               //4.发送请求    
               xmlHttpRequest.send(url);     

        }

        function zswFun(){    
            if(xmlHttpRequest.readyState == 4 && xmlHttpRequest.status == 200){    
                    var b = xmlHttpRequest.responseText;    
                    if(b == "True"){    
                        alert("用户名存在");
                        document.getElementById("name").focus();
                        nameok=false;
                    }
                    else
                    {
                        nameok=true;
                    }
               }    
           }  


        function querenmima()
        {
            var mima1 = document.getElementById("mima1").value;
            var mima2 = document.getElementById("mima2").value;
            if(mima1!=mima2)
            {
                alert("两次输入的密码不一样");
                document.getElementById("mima1").value = "";
                document.getElementById("mima2").value = "";
                document.getElementById("mima1").focus();
                return false;
            }
            else
                return true;
        }



        function verifyAddress() {
            var email =  document.getElementById("mail").value;
            var pattern = /^([a-zA-Z0-9_-])+@([a-zA-Z0-9_-])+(.[a-zA-Z0-9_-])+/;
            flag = pattern.test(email);
            if (!flag) {
                alert("邮箱格式不正确");
                document.getElementById("mail").focus();
                document.getElementById("mail").value = "";
                return false;

            }
            else
                return true;
        }
       

        function mysubmit()
        {
            var usn = document.getElementById("name").value;
            if (usn == "") { alert("用户名不能为空"); document.getElementById("name").focus(); nameok = false; return false; }
            var flag = 1;
            var qrm = querenmima();
            if (qrm == false) return; else flag++;
            var vfa = verifyAddress();
            if (vfa == false) return; else flag++;
          
            if(flag==3 && nameok==true)
            {
               
                this.form1.action = "register.aspx";
                this.form1.submit();
            }
           
        }
    </script>
</head>
<body>
    <form id="form1" method="post" action="register.aspx">
       姓名：
&nbsp;&nbsp;
        <input id="name" name="name" type="text" onblur="f()" /><br />
        <br/>
         密码：
&nbsp;&nbsp;
        <input id="mima1" name="mima1" type="password" /><br />
        <br/>
         确认密码：
&nbsp;&nbsp;
        <input id="mima2" name="mima2" type="password" /><br />
        <br/>
        邮箱：
&nbsp;&nbsp;
        <input id="mail" name="mail" type="text" /><br />
        <br />
        <br />
        <input type="hidden" id="flag" name="flag" value="true" />
        <input type="button" ID="Button1" onclick="mysubmit()" value="提交" />
        <br/>
        <asp:Label ID="Label4" runat="server"></asp:Label>
    </form>
</body>
</html>
