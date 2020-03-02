<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Spare_Part_DeviceContent.aspx.cs" Inherits="mydddd.Web.Spare_Part_Analyze.Spare_Part_DeviceContent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" runat="server" AutoSizePanelID="Panel1" />
        <f:Panel ID="Panel1" runat="server" BodyPadding="3px" ShowBorder="False" ShowHeader="False" Title="Panel" Layout="Fit" AutoScroll="True">
            <Toolbars>
                <f:Toolbar ID="Toolbar1" runat="server">
                    <Items>
                        <%-- <f:Button ID="Button_add" runat="server" Icon="Add" Text="新增" OnClick="Button_add_OnClick">
                        </f:Button>--%>
                        <%--<f:ToolbarSeparator runat="server" />--%>
                        <%-- <f:Button ID="Button_delete" runat="server" Icon="Delete"
                            ConfirmText="确定要执行选中行操作吗？" Text="批量删除" OnClick="Button_delete_OnClick">
                        </f:Button>--%>
                    </Items>
                </f:Toolbar>
            </Toolbars>
            <Items>
                <f:Grid ID="Grid1" runat="server" Title="Grid" AllowPaging="True" AllowSorting="True" SortDirection="asc" SortField="设备相关名称"
                    EnableCheckBoxSelect="true"  DataKeyNames="id" EnableTextSelection="True" CheckBoxSelectOnly="false"
                    IsDatabasePaging="false" ShowHeader="False" ShowSelectedCell="true" OnPageIndexChange="Grid1_OnPageIndexChange" OnSort="Grid1_OnSort">
                    <Toolbars>
                        <f:Toolbar runat="server">
                            <Items>
                               <%-- <f:ToolbarText runat="server" Text="条件"></f:ToolbarText>--%>
                                <%--<f:DropDownList ID="sysrolepopedom_rname" runat="server" Label="权限角色" />--%>
                               <%-- <f:ToolbarSeparator runat="server" />--%>

                               <%-- <f:TwinTriggerBox ID="ttbSearchMessage" runat="server" ShowLabel="false" EmptyText="真实姓名搜索" OnTrigger1Click="ttbSearchMessage_OnTrigger1Click" OnTrigger2Click="ttbSearchMessage_OnTrigger2Click"
                                    Trigger1Icon="Clear" Trigger2Icon="Search" ShowTrigger1="false">
                                </f:TwinTriggerBox>--%>
                            </Items>
                        </f:Toolbar>
                    </Toolbars>
                    <PageItems>
                        <f:ToolbarSeparator ID="ToolbarSeparator1" runat="server"/>
                        <f:ToolbarText ID="ToolbarText1" runat="server" Text="每页记录数："/>
                        <f:DropDownList runat="server" ID="ddlPageSize" Width="80px" AutoPostBack="true" OnSelectedIndexChanged="ddlPageSize_OnSelectedIndexChanged">
                            <f:ListItem Text="10" Value="10"  />
                            <f:ListItem Text="20" Value="20" Selected="True"/>
                            <f:ListItem Text="50" Value="50" />
                            <f:ListItem Text="100" Value="100" />
                        </f:DropDownList>
                    </PageItems>
                    <Columns>
                        <f:TemplateField runat="server" SortField="设备相关名称" HeaderText="设备相关名称" Width="150px">
                            <ItemTemplate>
                                <%#Eval("设备相关名称") %>
                            </ItemTemplate>
                        </f:TemplateField>
                        <f:TemplateField runat="server" SortField="设备编号" HeaderText="设备编号" Width="150px">
                            <ItemTemplate>
                                <%#Eval("设备编号") %>
                            </ItemTemplate>
                        </f:TemplateField>
                        <f:TemplateField runat="server" SortField="操作数量" HeaderText="操作数量" Width="150px">
                            <ItemTemplate>
                                <%#Eval("操作数量") %>
                            </ItemTemplate>
                        </f:TemplateField>
                        <f:TemplateField runat="server" SortField="操作日期" HeaderText="操作日期" Width="250px">
                            <ItemTemplate>
                                <%#Eval("操作日期") %>
                            </ItemTemplate>
                        </f:TemplateField>
                        <f:TemplateField runat="server" SortField="使用单位名称" HeaderText="使用单位名称" Width="250px">
                            <ItemTemplate>
                                <%#Eval("使用单位名称") %>
                            </ItemTemplate>
                        </f:TemplateField>
                        <f:TemplateField runat="server" SortField="总价" HeaderText="总价" Width="200px">
                            <ItemTemplate>
                                <%#Eval("总价") %>
                            </ItemTemplate>
                        </f:TemplateField>
                    </Columns>
                </f:Grid>
            </Items>
        </f:Panel>
    </form>
</body>
</html>
