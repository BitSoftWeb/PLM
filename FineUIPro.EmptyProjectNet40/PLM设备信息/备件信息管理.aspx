<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="备件信息管理.aspx.cs" Inherits="FineUIPro.EmptyProjectNet40.PLM设备信息.备件信息管理" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" runat="server" />
        <f:Form runat="server">
            <Items>
                <f:RadioButtonList ID="BJ_信息表选择" Label="信息类型" LabelAlign="Right" ColumnNumber="5" runat="server" AutoPostBack="true" LabelWidth="120" OnSelectedIndexChanged="BJ_备件信息管理_SelectedIndexChanged">
                    <f:RadioItem Text="备件库存信息" Selected="true" Value="备件库存信息" />
                    <f:RadioItem Text="备件发放记录" Value="备件发放记录" />
                    <f:RadioItem Text="备件日志信息" Value="备件日志信息" />
                </f:RadioButtonList>
            </Items>
        </f:Form>
        <%-- 备件库存信息 --%>
        <f:Grid runat="server" ID="BJ_KC_Grid" ShowBorder="true" ShowHeader="true" ForceFit="true" EnableCollapse="false" DataKeyNames="物料号,备件名称,规格型号,计量单位,成本中心,提报单位,管理类别,库存,总价,备注" SortDirection="ASC" AllowSorting="true" PageSize="30" SortField="物料号" AllowPaging="true" IsDatabasePaging="true" ShowPagingMessage="true" EnableCheckBoxSelect="true" EnableMultiSelect="false" OnPageIndexChange="BJ_KC_Grid_PageIndexChange">
            <Toolbars>
                <f:Toolbar runat="server" ID="BJ_KC_Tool">
                    <Items>
                        <f:Label runat="server" ID="BJ_KC_金额" Label="总金额" Enabled="true" LabelAlign="Right"></f:Label>
                        <f:DropDownList runat="server" ID="BJ_KC_管理类别" Label="管理类别" AutoPostBack="true" LabelAlign="Right" OnSelectedIndexChanged="BJ_KC_管理类别_SelectedIndexChanged"></f:DropDownList>
                        <f:DropDownList runat="server" ID="BJ_KC_提报单位" EnableEdit="true" Label="提报单位" LabelAlign="Right" AutoPostBack="true" OnSelectedIndexChanged="BJ_KC_提报单位_SelectedIndexChanged"></f:DropDownList>
                        <f:Button runat="server" ID="BJ_KC_条件筛选" Text="条件筛选" MarginLeft="20" OnClick="BJ_KC_条件筛选_Click"></f:Button>
                        <f:Button runat="server" ID="BJ_KC_清除筛选" Text="清除筛选" OnClick="BJ_KC_清除筛选_Click" MarginLeft="20"></f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
            <Columns>
                <f:RowNumberField EnablePagingNumber="true" />
                <f:BoundField DataField="物料号" HeaderText="物料号" DataFormatString="{0}" SortField="物料号" TextAlign="Center" />
                <f:BoundField DataField="备件名称" HeaderText="备件名称" TextAlign="Center" />
                <f:BoundField DataField="规格型号" HeaderText="规格型号" TextAlign="Center" />
                <f:BoundField DataField="计量单位" HeaderText="计量单位" TextAlign="Center" />
                <f:BoundField DataField="成本中心" HeaderText="成本中心" TextAlign="Center" />
                <f:BoundField DataField="提报单位" HeaderText="提报单位" TextAlign="Center" />
                <f:BoundField DataField="管理类别" HeaderText="管理类别" TextAlign="Center" />
                <f:BoundField DataField="库存" HeaderText="库存" TextAlign="Center" />
                <f:BoundField DataField="总价" HeaderText="总价" TextAlign="Center" />
                <f:BoundField DataField="备注" HeaderText="备注" TextAlign="Center" />
            </Columns>
        </f:Grid>
        <%-- 条件筛选弹窗 --%>
        <f:Window runat="server" ID="BJ_KC_筛选弹窗" Hidden="true" EnableFrame="false" EnableMaximize="true" Target="Self" EnableResize="true" IsModal="true" Width="330" AutoScroll="true">
            <Items>
                <f:SimpleForm ID="BJ_KC_SimpleForm" runat="server" ShowBorder="true" ShowHeader="false" BodyPadding="10px" AutoScroll="true">
                    <Items>
                        <f:HiddenField ID="hfFormID" runat="server"></f:HiddenField>
                        <f:TextBox ID="BJ_KC_TC_物料号" runat="server" Label="物料号"></f:TextBox>
                        <f:TextBox ID="BJ_KC_TC_物料名称" runat="server" Label="物料名称"></f:TextBox>
                        <%--<f:DropDownList ID="BJ_KC_TC_提报单位" Label="提报单位" AutoSelectFirstItem="false" runat="server">
                        </f:DropDownList>--%>
                        <f:DatePicker ID="BJ_KC_StrDate" Label="起始日期" SelectedDate="2015-01-01" DateFormatString="yyyy-MM-dd-dddd" runat="server" Enabled="false">
                        </f:DatePicker>
                        <f:DatePicker ID="BJ_KC_EndDate" Label="结束日期" DateFormatString="yyyy-MM-dd-dddd" runat="server" Enabled="false">
                        </f:DatePicker>
                    </Items>
                    <Toolbars>
                        <f:Toolbar ID="BJ_CK_Tool_筛选按钮" runat="server" Position="Bottom" ToolbarAlign="Center">
                            <Items>
                                <f:Button ID="BJ_KC_btnSure" runat="server" Text="确定筛选" OnClick="BJ_KC_btnSure_Click" ValidateForms="BJ_KC_SimpleForm" Icon="SystemSearch"></f:Button>
                                <f:Button ID="BJ_KC_btnCancel" runat="server" Text="取消" OnClick="BJ_KC_btnCancel_Click" ValidateForms="BJ_KC_SimpleForm" Icon="Cancel"></f:Button>
                            </Items>
                        </f:Toolbar>
                    </Toolbars>
                </f:SimpleForm>
            </Items>
        </f:Window>

        <%-- 备件发放记录 --%>
        <f:Grid runat="server" ID="BJ_JL_Grid" ShowBorder="true" ShowHeader="true" ForceFit="true" EnableCollapse="false" DataKeyNames="物料号,备件名称,规格型号,计量单位,成本中心,提报人,发放人,操作类型,操作数量,操作日期,总价,设备编号,设备相关名称,使用类型,备注" SortDirection="ASC" AllowSorting="true" PageSize="30" SortField="物料号" AllowPaging="true" IsDatabasePaging="true" ShowPagingMessage="true" EnableCheckBoxSelect="true" EnableMultiSelect="false" OnPageIndexChange="BJ_JL_Grid_PageIndexChange">
            <Toolbars>
                <f:Toolbar runat="server" ID="BJ_JL_Tool">
                    <Items>
                        <f:Label runat="server" ID="BJ_JL_金额" Label="总金额" Enabled="true" LabelAlign="Right"></f:Label>
                        <f:DropDownList runat="server" ID="BJ_JL_管理类别" Label="管理类别" AutoPostBack="true" LabelAlign="Right" Hidden="true"></f:DropDownList>
                        <f:DropDownList runat="server" ID="BJ_JL_提报单位" EnableEdit="true" Label="提报单位" LabelAlign="Right" AutoPostBack="true" OnSelectedIndexChanged="BJ_JL_提报单位_SelectedIndexChanged"></f:DropDownList>
                        <f:Button runat="server" ID="BJ_JL_条件筛选" Text="条件筛选" OnClick="BJ_JL_条件筛选_Click" MarginLeft="20"></f:Button>
                        <f:Button runat="server" ID="BuBJ_JL_清除筛选" Text="清除筛选" OnClick="BuBJ_JL_清除筛选_Click" MarginLeft="20"></f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
            <Columns>
                <f:BoundField DataField="物料号" HeaderText="物料号" DataFormatString="{0}" SortField="物料号" TextAlign="Center" />
                <f:BoundField DataField="备件名称" HeaderText="备件名称" TextAlign="Center" />
                <f:BoundField DataField="规格型号" HeaderText="规格型号" TextAlign="Center" />
                <f:BoundField DataField="计量单位" HeaderText="计量单位" TextAlign="Center" />
                <f:BoundField DataField="成本中心" HeaderText="成本中心" TextAlign="Center" />
                <f:BoundField DataField="提报人" HeaderText="提报人" TextAlign="Center" />
                <f:BoundField DataField="发放人" HeaderText="发放人" TextAlign="Center" />
                <f:BoundField DataField="操作类型" HeaderText="操作类型" TextAlign="Center" />
                <f:BoundField DataField="操作数量" HeaderText="操作数量" TextAlign="Center" />
                <f:BoundField DataField="操作日期" HeaderText="操作日期" TextAlign="Center" />
                <f:BoundField DataField="总价" HeaderText="总价" TextAlign="Center" />
                <f:BoundField DataField="设备编号" HeaderText="设备编号" TextAlign="Center" />
                <f:BoundField DataField="设备相关名称" HeaderText="设备相关名称" TextAlign="Center" />
                <f:BoundField DataField="使用类型" HeaderText="使用类型" TextAlign="Center" />
                <f:BoundField DataField="备注" HeaderText="备注" TextAlign="Center" />
            </Columns>
        </f:Grid>
        <f:Window runat="server" Hidden="true" ID="BJ_JL_筛选弹窗" EnableFrame="false" EnableMaximize="true" Target="Self" EnableResize="true" IsModal="true" Width="330" AutoScroll="true">
            <Items>
                <f:SimpleForm ID="SimpleForm1" runat="server" ShowBorder="true" ShowHeader="false" BodyPadding="10px" AutoScroll="true">
                    <Items>
                        <f:HiddenField ID="HiddenField1" runat="server"></f:HiddenField>
                        <f:TextBox ID="JL_TC_物料号" runat="server" Label="物料号"></f:TextBox>
                        <f:TextBox ID="JL_TC_物料名称" runat="server" Label="物料名称"></f:TextBox>
                        <f:RadioButtonList ID="JL_RadioButtonList" LabelAlign="Right" ColumnNumber="3" runat="server" AutoPostBack="true" OnSelectedIndexChanged="JL_TC_RadioButtonList_SelectedIndexChanged">
                            <f:RadioItem Text="不限" Selected="true" Value="不限" />
                            <f:RadioItem Text="以出库时间" Value="以出库时间" />
                            <f:RadioItem Text="以到库时间" Value="以到库时间" />
                        </f:RadioButtonList>
                        <f:DatePicker ID="JL_StarDate" Label="起始日期" SelectedDate="2015-01-01" DateFormatString="yyyy-MM-dd" runat="server" Enabled="false">
                        </f:DatePicker>
                        <f:DatePicker ID="JL_EndDate" Label="结束日期" DateFormatString="yyyy-MM-dd" runat="server" Enabled="false">
                        </f:DatePicker>
                    </Items>
                    <Toolbars>
                        <f:Toolbar ID="Toolbar1" runat="server" Position="Bottom" ToolbarAlign="Center">
                            <Items>
                                <f:Button ID="JL_TC_确定筛选" runat="server" Text="确定筛选" OnClick="JL_TC_确定筛选_Click" ValidateForms="BJ_JL_SimpleForm" Icon="SystemSearch"></f:Button>
                                <f:Button ID="JL_TC_取消" runat="server" Text="取消" OnClick="JL_TC_取消_Click" ValidateForms="BJ_JL_SimpleForm" Icon="Cancel"></f:Button>
                            </Items>
                        </f:Toolbar>
                    </Toolbars>
                </f:SimpleForm>
            </Items>
        </f:Window>

        <%-- 备件日志信息 --%>
        <f:Grid runat="server" ID="BJ_RZ_Grid" ShowBorder="true" ShowHeader="true" ForceFit="true" EnableCollapse="false" DataKeyNames="物料号,备件名称,规格型号,计量单位,成本中心,提报单位,提报人,预留号,预留数量,发料数量,剩余数量,单价,发料日期,库存地址,订单号,预留文本" SortDirection="ASC" AllowSorting="true" PageSize="30" SortField="物料号" AllowPaging="true" IsDatabasePaging="true" ShowPagingMessage="true" EnableCheckBoxSelect="true" EnableMultiSelect="false" OnPageIndexChange="BJ_RZ_Grid_PageIndexChange">
            <Toolbars>
                <f:Toolbar runat="server">
                    <Items>
                        <f:Label runat="server" ID="BJ_RZ_金额" Label="总金额" Enabled="true" LabelAlign="Right"></f:Label>
                        <f:DropDownList runat="server" ID="BJ_RZ_管理类别" Label="管理类别" AutoPostBack="true" LabelAlign="Right" Hidden="true"></f:DropDownList>
                        <f:DropDownList runat="server" ID="BJ_RZ_提报单位" EnableEdit="true" Label="提报单位" LabelAlign="Right" AutoPostBack="true" OnSelectedIndexChanged="BJ_RZ_提报单位_SelectedIndexChanged"></f:DropDownList>
                        <f:Button runat="server" ID="BJ_RZ_条件筛选" Text="条件筛选" MarginLeft="20" OnClick="BJ_RZ_条件筛选_Click"></f:Button>
                        <f:Button runat="server" ID="BJ_RZ_清除筛选" Text="清除筛选" MarginLeft="20" OnClick="BJ_RZ_清除筛选_Click"></f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
            <Columns>
                <f:BoundField DataField="物料号" HeaderText="物料号" DataFormatString="{0}" SortField="物料号" TextAlign="Center" />
                <f:BoundField DataField="备件名称" HeaderText="备件名称" TextAlign="Center" />
                <f:BoundField DataField="规格型号" HeaderText="规格型号" TextAlign="Center" />
                <f:BoundField DataField="计量单位" HeaderText="计量单位" TextAlign="Center" />
                <f:BoundField DataField="成本中心" HeaderText="成本中心" TextAlign="Center" />
                <f:BoundField DataField="提报单位" HeaderText="提报单位" TextAlign="Center" />
                <f:BoundField DataField="提报人" HeaderText="提报人" TextAlign="Center" />
                <f:BoundField DataField="预留号" HeaderText="预留号" TextAlign="Center" />
                <f:BoundField DataField="预留数量" HeaderText="预留数量" TextAlign="Center" />
                <f:BoundField DataField="发料数量" HeaderText="发料数量" TextAlign="Center" />
                <f:BoundField DataField="剩余数量" HeaderText="剩余数量" TextAlign="Center" />
                <f:BoundField DataField="单价" HeaderText="单价" TextAlign="Center" />
                <f:BoundField DataField="发料日期" HeaderText="发料日期" TextAlign="Center" />
                <f:BoundField DataField="库存地址" HeaderText="库存地址" TextAlign="Center" />
                <f:BoundField DataField="订单号" HeaderText="订单号" TextAlign="Center" />
                <f:BoundField DataField="预留文本" HeaderText="预留文本" TextAlign="Center" />
            </Columns>
        </f:Grid>
        <f:Window runat="server" ID="BJ_RZ_筛选弹窗" Hidden="true" EnableFrame="false" EnableMaximize="true" Target="Self" EnableResize="true" IsModal="true" Width="330" AutoScroll="true">
            <Items>
                <f:SimpleForm ID="SimpleForm2" runat="server" ShowBorder="true" ShowHeader="false" BodyPadding="10px" AutoScroll="true">
                    <Items>
                        <f:HiddenField ID="HiddenField2" runat="server"></f:HiddenField>
                        <f:TextBox ID="RZ_TC_物料号" runat="server" Label="物料号"></f:TextBox>
                        <f:TextBox ID="RZ_TC_物料名称" runat="server" Label="物料名称"></f:TextBox>
                        <f:DatePicker ID="RZ_TC_StarDate" Label="起始日期" SelectedDate="2015-01-01" DateFormatString="yyyy-MM-dd" runat="server" >
                        </f:DatePicker>
                        <f:DatePicker ID="RZ_TC_EndDate" Label="结束日期" DateFormatString="yyyy-MM-dd" runat="server" >
                        </f:DatePicker>
                    </Items>
                    <Toolbars>
                        <f:Toolbar ID="RZ_TC_Tool" runat="server" Position="Bottom" ToolbarAlign="Center">
                            <Items>
                                <f:Button ID="RZ_TC_确定筛选" runat="server" Text="确定筛选"  ValidateForms="BJ_JL_SimpleForm" Icon="SystemSearch" OnClick="RZ_TC_确定筛选_Click"></f:Button>
                                <f:Button ID="RZ_TC_取消" runat="server" Text="取消"  ValidateForms="BJ_JL_SimpleForm" Icon="Cancel" OnClick="RZ_TC_取消_Click"></f:Button>
                            </Items>
                        </f:Toolbar>
                    </Toolbars>
                </f:SimpleForm>
            </Items>
        </f:Window>
    </form>
</body>
</html>
