<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="精度检测.aspx.cs" Inherits="FineUIPro.EmptyProjectNet40.设备运行管理.精度检测" %>


<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
    <meta name="sourcefiles" content="~/设备运行管理/选取设备台账.aspx" />
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" runat="server" />
        <%--     <f:Grid ID="Grid1" IsFluid="true" CssClass="blockpanel" ShowBorder="true" ShowHeader="true" Title="表格（进入编辑状态后，从弹出窗体中选择用户）"
            EnableCollapse="false" Height="350px"
            runat="server" DataKeyNames="Id,Name" AllowCellEditing="true" ClicksToEdit="1"
            OnPreDataBound="Grid1_PreDataBound" IncludeMergedData="true" >--%>

        <f:Grid ID="Grid1" IsFluid="true" CssClass="blockpanel" ShowBorder="true" ShowHeader="true" Title="表格"
            EnableCollapse="false" Height="500px" EnableColumnLines="true" IncludeMergedData="true"
            runat="server" DataKeyNames="" AllowCellEditing="true" ClicksToEdit="1">

            <Toolbars>
                <f:Toolbar ID="Toolbar1" runat="server">
                    <Items>
                        <f:Button ID="btnNew" Text="新增数据" Icon="Add" EnablePostBack="false" runat="server">
                        </f:Button>
                        <f:Button ID="btnDelete" Text="删除选中行" Icon="Delete" EnablePostBack="false" runat="server">
                        </f:Button>
                        <f:ToolbarFill runat="server">
                        </f:ToolbarFill>
                        <f:Button ID="btnReset" Text="重置表格数据" EnablePostBack="false" runat="server">
                        </f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
            <Columns>
                <f:RowNumberField />
                <f:RenderField Width="100px" ColumnID="设备编号" DataField="设备编号" HeaderText="设备编号">
                    <Editor>
                        <f:TriggerBox ID="tbxEditorName" TriggerIcon="Search" OnTriggerClick="tbxEditorName_TriggerClick" runat="server">
                            <%--        <Listeners>
                                <f:Listener Event="triggerclick" Handler="onNameSearchTriggerClick" />
                            </Listeners>--%>
                        </f:TriggerBox>
                    </Editor>
                </f:RenderField>



                <f:RenderField Width="100px" ColumnID="重点设备" DataField="重点设备"
                    HeaderText="重点设备">
                    <Editor>
                        <f:TextBox ID="重点设备" Required="true" runat="server">
                        </f:TextBox>
                    </Editor>
                </f:RenderField>



                <f:RenderField Width="100px" ColumnID="设备名称" DataField="设备名称"
                    HeaderText="设备名称">
                    <Editor>
                        <f:TextBox ID="设备名称" Required="true" runat="server">
                        </f:TextBox>
                    </Editor>
                </f:RenderField>



                <f:RenderField Width="100px" ColumnID="设备型号" DataField="设备型号"
                    HeaderText="设备型号">
                    <Editor>
                        <f:TextBox ID="型号" Required="true" runat="server">
                        </f:TextBox>
                    </Editor>
                </f:RenderField>

                <f:RenderField Width="100px" ColumnID="复杂系数Fj" DataField="复杂系数Fj"
                    HeaderText="复杂系数Fj">
                    <Editor>
                        <f:TextBox ID="复杂系数Fj" Required="true" runat="server">
                        </f:TextBox>
                    </Editor>
                </f:RenderField>
                <f:RenderField Width="100px" ColumnID="复杂系数Fd" DataField="复杂系数Fd"
                    HeaderText="复杂系数Fd">
                    <Editor>
                        <f:TextBox ID="复杂系数Fd" Required="true" runat="server">
                        </f:TextBox>
                    </Editor>
                </f:RenderField>

                <f:RenderCheckField Width="50px" ColumnID="一月份" DataField="一月份" HeaderText="1" />
                <f:RenderCheckField Width="50px" ColumnID="二月份" DataField="二月份" HeaderText="2" />
                <f:RenderCheckField Width="50px" ColumnID="三月份" DataField="三月份" HeaderText="3" />
                <f:RenderCheckField Width="50px" ColumnID="四月份" DataField="四月份" HeaderText="4" />
                <f:RenderCheckField Width="50px" ColumnID="五月份" DataField="五月份" HeaderText="5" />
                <f:RenderCheckField Width="50px" ColumnID="六月份" DataField="六月份" HeaderText="6" />
                <f:RenderCheckField Width="50px" ColumnID="七月份" DataField="七月份" HeaderText="7" />
                <f:RenderCheckField Width="50px" ColumnID="八月份" DataField="八月份" HeaderText="8" />
                <f:RenderCheckField Width="50px" ColumnID="九月份" DataField="九月份" HeaderText="9" />
                <f:RenderCheckField Width="50px" ColumnID="十月份" DataField="十月份" HeaderText="10" />
                <f:RenderCheckField Width="50px" ColumnID="十一月份" DataField="十一月份" HeaderText="11" />
                <f:RenderCheckField Width="50px" ColumnID="十二月份" DataField="十二月份" HeaderText="12" />

                <f:RenderField Width="100px" ColumnID="备注" DataField="备注"
                    HeaderText="备注">
                    <Editor>
                        <f:TextBox ID="备注" Required="true" runat="server">
                        </f:TextBox>
                    </Editor>
                </f:RenderField>

                <f:LinkButtonField ColumnID="Delete" Width="80px" EnablePostBack="false"
                    Icon="Delete" />
            </Columns>
            <Listeners>
                <f:Listener Event="dataload" Handler="onGridDataLoad" />
            </Listeners>
        </f:Grid>
        <br />
        <f:Button ID="Button2" runat="server" Text="保存数据" OnClick="Button2_Click">
        </f:Button>
        <br />
        <br />
        <f:Label ID="labResult" EncodeText="false" runat="server">
        </f:Label>
        <br />
        <f:Window ID="Window1" Hidden="true" EnableIFrame="true" EnableMaximize="true"
            EnableResize="true" Target="Top" runat="server" Height="350px" Width="700px"
            Title="选择用户">
        </f:Window>
    </form>
    <script>


        var gridClientID = '<%= Grid1.ClientID %>';

        function updateGridRow(rowId, values) {
            var grid = F(gridClientID);

            // cancelEdit用来取消编辑
            grid.cancelEdit();

            grid.updateCellValue(rowId, values);
        }
        var EMPTY_DATA = {
            '设备编号': '',
            '重点设备': '',  // Gender的列类型是整型，这里的空字符串表示未定义（对应于服务器断的DBNull.Value）
            '设备名称': '',
            '设备型号': '',
            '复杂系数Fj': '',  // AtSchool的列类型是布尔型，这里的空字符串表示未定义（对应于服务器断的DBNull.Value）
            '复杂系数Fd': '',
            '一月份': '',
            '二月份': '',
            '三月份': '',
            '四月份': '',
            '五月份': '',
            '六月份': '',
            '七月份': '',
            '八月份': '',
            '九月份': '',
            '十月份': '',
            '十一月份': '',
            '十二月份': '',
            'Delete': '<a href="javascript:;"><img src="../res/icon/delete.png"/></a>'
        };


        function onGridDataLoad(event) {
            //alert(1);
            var grid = F(gridClientID);

            var rowEls = grid.getRowEls();
            var rowElsCount = rowEls.length;

            // 最少 1 个空白行，最多 10 个空白行
            var emptyRowCount = 10 - rowElsCount;
            if (emptyRowCount === 0) {
                // 不作处理
            } else if (emptyRowCount > 0) {
                // 新增空白行
                var records = [];
                for (var i = 0; i < emptyRowCount; i++) {
                    records.push(EMPTY_DATA);
                }
                // 此过程禁止触发事件，防止 dataload 事件死循环
                F.noEvent(function () {
                    grid.addNewRecords(records, true);
                });
            } else {
                // 删除多余的空白行
                var rowIdsToRemove = [];
                var rowsCountToRemove = -emptyRowCount;
                for (var i = 0; i < rowsCountToRemove; i++) {
                    var lastRowData = grid.getRowData(rowEls.eq(rowElsCount - i - 1));
                    // 如果本行的姓名为空，则删除
                    if (!lastRowData.values['设备编号']) {
                        rowIdsToRemove.push(lastRowData.id);
                    } else {
                        // 从后面向前查找，第一个不为空的行就终止删除
                        break;
                    }
                }
                if (rowIdsToRemove.length) {
                    // 此过程禁止触发事件，防止 dataload 事件死循环
                    F.noEvent(function () {
                        grid.deleteRows(rowIdsToRemove);
                    });
                }
            }
        }



    </script>
</body>
</html>
