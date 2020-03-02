<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="选取设备台账.aspx.cs" Inherits="FineUIPro.EmptyProjectNet40.设备运行管理.选取设备台账" %>


<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="Grid1" runat="server" />
        <f:Grid ID="Grid1" ShowBorder="false" ShowHeader="false" Title="表格" runat="server" EnableCollapse="false"
            DataKeyNames="Id" EnableCheckBoxSelect="true" EnableMultiSelect="false">
            <Toolbars>
                <f:Toolbar runat="server" Position="Top">
                    <Items>

                        <f:TwinTriggerBox runat="server" EmptyText="设备编号/名称模糊查询" ShowLabel="false" ID="ttbSearch"
                            ShowTrigger1="false"
                            Trigger1Icon="Clear" Trigger2Icon="Search" Width="300" OnTrigger2Click="ttbSearch_Trigger2Click"  >
                        </f:TwinTriggerBox>

                        <f:Button ID="btnClose" EnablePostBack="false" Text="确定" runat="server" Icon="SystemClose">
                        </f:Button>
                        <f:Button ID="btnSaveClose" Text="选择后关闭" runat="server" Icon="SystemSaveClose" EnablePostBack="false">
                            <Listeners>
                                <f:Listener Event="click" Handler="onGridRowSelect" />
                            </Listeners>
                        </f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
            <Columns>
                <f:RowNumberField />
                <f:RenderField Width="100px" ColumnID="设备编号" DataField="设备编号" HeaderText="设备编号" />
                <f:RenderField Width="100px" ColumnID="设备名称" DataField="设备名称"  HeaderText="设备名称" />
                <f:RenderField Width="100px" ColumnID="设备型号" DataField="设备型号" HeaderText="设备型号" />
            
            </Columns>

            <Listeners>
                <f:Listener Event="rowdblclick" Handler="onGridRowSelect" />
            </Listeners>
        </f:Grid>
        <br />
        <br />
        注：由于需要在客户端获取表格行数据，所以需要使用RenderField替换所有的BoundField。
    </form>
    <script>

        var gridClientID = '<%= Grid1.ClientID %>';

    

        function onGridRowSelect() {
            // 返回当前活动Window对象（浏览器窗口对象通过F.getActiveWindow().window获取）
            var activeWindow = F.getActiveWindow();

            // 选中行数据
            var rowData = F(gridClientID).getSelectedRow(true);
            var rowValue = rowData.values;

            var queryRowId = F.queryString('rowid');
            var selectedValues = {
                '设备编号': rowValue['设备编号'],
                '设备名称': rowValue['设备名称'],
                '设备型号': rowValue['设备型号']
               
            };
        
            // 隐藏弹出窗体
            activeWindow.hide();

            // 调用父页面的 updateGridRow 函数
            activeWindow.window.updateGridRow(queryRowId, selectedValues);
        }

    </script>
</body>
</html>
