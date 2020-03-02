<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="导入excel.aspx.cs" Inherits="FineUIPro.EmptyProjectNet40.设备运行管理.导入excel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:FileUpload ID="ExcelFileUpload" runat="server" />
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
    </div>
    </form>
</body>
</html>
