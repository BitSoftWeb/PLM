<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewLogin.aspx.cs" Inherits="FineUIPro.EmptyProjectNet40.NewLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type"  name="viewport" content="width=device-width,initial-scale=1" />
    <link href="LoginTestStyle/css/style.css" rel="stylesheet" />
    <link href="LoginTestStyle/css/reset.css" rel="stylesheet" />
    <title></title>
    <script>
        if (window.screen.width == 1600) {
            alert(2);
            document.write('<link rel="stylesheet" href="a_Style/Screen1600.css">');
        }
            // 分辨率再在1024-1600的情况下，调用此css
        else if (window.screen.width >= 1920) {
         
            document.write('<link rel="stylesheet" href="a_Style/Screen1920.css">');
        }
            // 分辨率小于1024的情况下，调用此css
        else{
            document.write('<link rel="stylesheet" href="css/index.css">');
        }

    </script>
    <style type="text/css">
        .check {
            margin-left: 76px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="main">
            <div id="title" style="height: 75px">
                <table style="width: 100%">
                    <tr>
                        <td class="td1"><img src="MenuImage/车.png" /><div class="div1">企业资产运营管理平台</div></td>
                        <td><div class="div2">|</div></td>
                        <td class="td2"><div class="div3">登录平台</div></td>
                        <td class="td3"><div class="div4"><a href="#">功能</a>|<a href="#">服务</a></div></td>
                    </tr>
                </table>
                
            </div>
            <div id="Middle" class="div_middle">
                <div class="login" style="margin-left: 250px">
                    <%--<img id="img1" src="MenuImage/车.png" style="margin-top: 60px; margin-left: 40px" />--%>
                    <div style="margin-top: 60px; margin-left: 115px; font-size: 25px">用 户 登 录</div>
                    <div class="login-top">
                        <%--登录--%>
                    </div>
                    <div class="login-center clearfix">
                        <div class="login-center-img">
                            <img src="LoginTestStyle/img/name.png" />
                        </div>
                        <div class="login-center-input">
                            <asp:TextBox ID="Login_name" runat="server"></asp:TextBox>
                            <div class="login-center-input-text">用户名</div>
                        </div>
                    </div>
                    <div class="login-center clearfix">
                        <div class="login-center-img">
                            <img src="LoginTestStyle/img/password.png" />
                        </div>
                        <div class="login-center-input">
                            <asp:TextBox ID="Pass_word" runat="server" TextMode="Password"></asp:TextBox>
                            <div class="login-center-input-text">密码</div>
                        </div>
                    </div>

                    <%--<asp:CheckBox ID="CheckBox1" runat="server" CssClass="check" Text="记住账号和密码" OnCheckedChanged="CheckBox1_CheckedChanged" />
                    <br />--%>
                    <asp:Button CssClass="login-button1" ID="Login_Button" Text="登录" OnClick="Login_Button_Click" runat="server" />
                       <br />
                    <br />
                    <br />
                    &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<asp:Label ID="Label1" runat="server" Text="" ForeColor="#FF3300" Font-Size="Large"></asp:Label>
                </div>
            </div>
            <div class="sk-rotating-plane"></div>
        </div>
           <div class="sk-rotating-plane"></div>
            <div style="width: 100%; text-align: center; margin-top: 10px;">*********©1997-2020   ICP备案 粤B2-20090191-18 粤公网安备 44010602000311 增值电信业务许可证 粤B2-20090191  B2-20090058 （数据来源：艾媒邮箱报告）</div>
        </div>
    </form>
</body>
</html>
