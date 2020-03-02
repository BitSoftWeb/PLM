<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Spare_Part_CompanyPriceData.aspx.cs" Inherits="mydddd.Web.Spare_Part_Analyze.Spare_Part_CompanyPriceData" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <f:PageManager AutoSizePanelID="Panel1" runat="server" />
            <f:Panel ID="Panel1" runat="server" ShowBorder="false" ShowHeader="false" Title="同一设备年平均消耗" Layout="Fit" AutoScroll="true">
            <Toolbars>
                <f:Toolbar ID="Toolbar1" runat="server">
                    <Items>
                       <%-- <f:Button ID="Button_add" runat="server" Icon="Add" Text="新增" OnClick="Button_add_OnClick">
                        </f:Button>
                        <f:ToolbarSeparator runat="server" />
                        <f:Button ID="Button_delete" runat="server" Icon="Delete"
                            ConfirmText="确定要执行选中行操作吗？" Text="批量删除" OnClick="Button_delete_Click">
                        </f:Button>--%>
                    </Items>
                </f:Toolbar>
            </Toolbars>
            <Items>
                <f:Grid ID="Grid1" runat="server" IsFluid="true" Title="Grid" AllowPaging="True" AllowSorting="True" SortDirection="asc" SortField="sort"
                    EnableCheckBoxSelect="true"  DataKeyNames="提报单位" EnableTextSelection="True" CheckBoxSelectOnly="True"
                    IsDatabasePaging="false" ShowHeader="False" EnableColumnLines="true"   OnPageIndexChange="Grid1_OnPageIndexChange" OnSort="Grid1_OnSort">
                    <Toolbars>
                        <f:Toolbar runat="server">
                            <Items>
                                <f:ToolbarText runat="server" Text="条件"></f:ToolbarText>
                                <f:ToolbarSeparator runat="server" />
                                <%--<f:DropDownList ID="Company_Name" runat="server" Label="单位" LabelWidth="50px" OnSelectedIndexChanged="Company_Name_SelectedIndexChanged" AutoPostBack="true"></f:DropDownList>--%>
                                <%--<f:TwinTriggerBox ID="ttbSearchMessage" runat="server" ShowLabel="false" EmptyText="真实姓名搜索" OnTrigger1Click="ttbSearchMessage_OnTrigger1Click" OnTrigger2Click="ttbSearchMessage_OnTrigger2Click"
                                    Trigger1Icon="Clear" Trigger2Icon="Search" ShowTrigger1="false">
                                </f:TwinTriggerBox>--%>
                            </Items>
                        </f:Toolbar>
                    </Toolbars>
                    <PageItems>
                        <f:ToolbarSeparator ID="ToolbarSeparator1" runat="server"/>
                        
                        <f:ToolbarText ID="ToolbarText1" runat="server" Text="每页记录数："/>
                        
                        <f:DropDownList runat="server" ID="ddlPageSize" Width="80px" AutoPostBack="true" OnSelectedIndexChanged="ddlPageSize_OnSelectedIndexChanged">
                            <f:ListItem Text="10" Value="10" />
                            <f:ListItem Text="20" Value="20" Selected="true" />
                            <f:ListItem Text="50" Value="50" />
                            <f:ListItem Text="100" Value="100" />
                        </f:DropDownList>
                    </PageItems>
                    <Columns>
                        <f:RowNumberField EnablePagingNumber="true" HeaderText="序号" Width="150px" TextAlign="Center" />
                       <f:TemplateField runat="server" SortField="总价" Width="250px" HeaderText="总价">
                            <ItemTemplate>
                                <%#Eval("总价") %>
                            </ItemTemplate>
                        </f:TemplateField>
                        <f:TemplateField runat="server" SortField="提报单位" Width="250px" HeaderText="提报单位">
                            <ItemTemplate>
                                <%#Eval("提报单位") %>
                            </ItemTemplate>
                        </f:TemplateField>
                    </Columns>
                </f:Grid>
            </Items>
        </f:Panel>
        <f:Window ID="Window1" runat="server" Height="450px" Width="650px" IsModal="true" EnableMaximize="True"
            CloseAction="HidePostBack" EnableIFrame="True" Hidden="True" Icon="ApplicationFormEdit" OnClose="Window1_Close"
            Target="Top" EnableResize="True">
        </f:Window>
    </form>
</body>
</html>
