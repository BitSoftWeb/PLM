<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="设备履历.aspx.cs" Inherits="FineUIPro.EmptyProjectNet40.PLM设备信息.设备履历" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../res/css/about.css" />
    <style>
        .page {
            width: 100%;
            background: #F0F0F0 url('img/dian2.png') repeat-x;
        }
    </style>
    <title>设备履历</title>
</head>
<body onload="load();">
    <form id="form1" runat="server">
        <asp:Label ID="Label1" runat="server" ></asp:Label>
        <asp:Label ID="Label2" runat="server" ></asp:Label>
        <div class="box">

          
            <ul class="event_list">
                <div id="di1">
                    <h3 id="h0">
                        <label id="l0">设备履历</label>
                    </h3>
                </div>
            </ul>

            <div class="clearfix"></div>

        </div>



        <script src="../res/js/jquery.min_v1.0.js" type="text/javascript"></script>
        <script>

            function load() {
                var lab = document.getElementById("<%= Label1.ClientID %>").innerText;
                var labs = document.getElementById("<%= Label2.ClientID %>").innerText;
                var strs = new Array(); //定义一数组日期
                strs = lab.split(","); //字符分割日期
                var strss = new Array();
                strss = labs.split("*");
                for (i = 0; i < strs.length ; i++)
                {
                    $("#di1").append(' <li>  <span style="color: red;" id="sp1">' + '<b>' + strs[i] + '</b>' + '</span> <p><span>' + strss[i] + '</span></p>  </li> ');
                }


                document.getElementById("<%= Label1.ClientID %>").style.display = "none";//隐藏lable
                document.getElementById("<%= Label2.ClientID %>").style.display = "none";//隐藏lable
<%--                var lab = document.getElementById("<%= Label1.ClientID %>").innerText;
                document.getElementById("<%= Label1.ClientID %>").style.display = "none";//隐藏lable
                var strs = new Array(); //定义一数组
                strs = lab.split(","); //字符分割
                for (i = 0; i < strs.length ; i++) {
                    document.getElementById(i).innerHTML = strs[i];
                    //document.getElementById(1).style.display = "none";
                    document.getElementById(i).setAttribute("for", strs[i]);
                    document.getElementById("h" + i).id = strs[i];
                    document.getElementById("l" + i).innerHTML = strs[i];
                  
                  
                }--%>





            }


            //$(function () {

            //    $('label').click(function () {

            //        $('.event_year>li').removeClass('current');

            //        $(this).parent('li').addClass('current');

            //        var year = $(this).attr('for');

            //        $('#' + year).parent().prevAll('div').slideUp(800);

            //        $('#' + year).parent().slideDown(800).nextAll('div').slideDown(800);

            //    });

            //});

        </script>

    </form>

</body>
</html>
