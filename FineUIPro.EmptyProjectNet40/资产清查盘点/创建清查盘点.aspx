<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="创建清查盘点.aspx.cs" Inherits="FineUIPro.EmptyProjectNet40.资产清查盘点.创建清查盘点" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <%--  <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />--%>
    <meta charset="utf-8" />
    <title></title>
    <style type="text/css">
        .bgbtn {
            background-image: url(../res/images/创建资产清查.png) !important;
            width: 320px;
            height: 50px;
            border-width: 0 !important;
            background-color: transparent !important;
        }

        .clbtn {
            background-image: url(../res/images/关闭资产清查.png) !important;
            width: 320px;
            height: 50px;
            border-width: 0 !important;
            background-color: transparent !important;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="Panel7" runat="server" />
        <br />
        &nbsp&nbsp&nbsp&nbsp<f:Button ID="Button9" Text="" CssClass="bgbtn" runat="server" OnClick="Button9_Click" />
        <br /><br /><br />
        &nbsp&nbsp&nbsp&nbsp<f:Button ID="Button1" Text="" runat="server" CssClass="clbtn" OnClick="Button1_Click" />

        <f:Window ID="Window1" Title="创建盘点信息" Hidden="true" EnableIFrame="false"
            EnableMaximize="true" Target="Self" EnableResize="true" runat="server"
            IsModal="true" Width="500px">
            <Items>
                <f:SimpleForm ID="SimpleForm1" runat="server" ShowBorder="false" ShowHeader="false" BodyPadding="10px">
                    <Items>
                        <f:TextBox runat="server" Label="任务标题" ID="任务标题" Width="400px" LabelWidth="110" Enabled="false"></f:TextBox>
                        <f:DropDownList runat="server" Label="盘点范围" ID="盘点范围" Width="400px" LabelWidth="110">
                            <f:ListItem Text="全部" Value="全部" />
                            <f:ListItem Text="设备" Value="设备" EnableSelect="false" />
                            <f:ListItem Text="办公设备" Value="办公设备" EnableSelect="false" />
                            <f:ListItem Text="工装转" Value="工装转" EnableSelect="false" />
                            <f:ListItem Text="建筑物" Value="建筑物" EnableSelect="false" />
                            <f:ListItem Text="传导设备" Value="传导设备" EnableSelect="false" />
                        </f:DropDownList>
                        <f:TextBox runat="server" Label="创建人" ID="创建人" Width="400px" LabelWidth="110"></f:TextBox>
                        <f:TextBox runat="server" Label="备注" ID="备注" Width="400px" LabelWidth="110"></f:TextBox>
                    </Items>
                </f:SimpleForm>
            </Items>
            <Toolbars>
                <f:Toolbar ID="Toolbar1" Position="Bottom" ToolbarAlign="Right" runat="server">
                    <Items>
                        <f:Button ID="Button2" Icon="ApplicationAdd" runat="server" Text="确认" OnClick="Button2_Click"></f:Button>
                        <f:Button ID="btnClose" Icon="SystemClose" runat="server" Text="关闭" OnClick="btnClose_Click"></f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
        </f:Window>


        <f:Window ID="form关闭盘点流程" Title="关闭固定资产清查" Hidden="true" EnableIFrame="false"
            EnableMaximize="true" Target="Self" EnableResize="true" runat="server"
            IsModal="true" Width="500px">
            <Items>
                <f:SimpleForm ID="SimpleForm2" runat="server" ShowBorder="false" ShowHeader="false" BodyPadding="10px">
                    <Items>
                        <f:DropDownList runat="server" Label="任务名称" ID="关闭任务名称" Width="400px" LabelWidth="110">
                        </f:DropDownList>
                        <f:TextBox runat="server" Label="盘点范围" ID="关闭盘点范围" Width="400px" LabelWidth="110"></f:TextBox>
                        <f:TextBox runat="server" Label="创建人" ID="关闭创建人" Width="400px" LabelWidth="110"></f:TextBox>
                        <f:TextBox runat="server" Label="创建时间" ID="关闭创建时间" Width="400px" LabelWidth="110"></f:TextBox>
                        <f:TextBox runat="server" Label="备注" ID="关闭备注" Width="400px" LabelWidth="110"></f:TextBox>

                    </Items>
                </f:SimpleForm>
            </Items>
            <Toolbars>
                <f:Toolbar ID="Toolbar2" Position="Bottom" ToolbarAlign="Right" runat="server">
                    <Items>
                        <f:Button ID="Button3" Icon="ApplicationOsxStop" runat="server" Text="确认关闭" OnClick="Button3_Click"></f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>


        </f:Window>


    </form>
</body>
</html>
