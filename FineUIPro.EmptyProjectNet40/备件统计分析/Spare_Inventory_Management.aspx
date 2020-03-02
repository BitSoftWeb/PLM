<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Spare_Inventory_Management.aspx.cs" Inherits="mydddd.Web.Spare_Part_Analyze.Spare_Inventory_Management" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager AutoSizePanelID="Panel1" runat="server" />
        <f:Panel ID="Panel1" runat="server" BodyPadding="3px" ShowBorder="False" ShowHeader="False" Title="Panel" Layout="Fit" AutoScroll="True">
            <Toolbars>
                <f:Toolbar ID="Toolbar1" runat="server">
                    <Items>
                       <%-- <f:Button ID="Button_add" runat="server" Icon="Add" Text="新增" OnClick="Button_add_OnClick">
                        </f:Button>--%>
                        <f:ToolbarSeparator runat="server" />

                     <%--  <f:Button ID="Button_delete" runat="server" Icon="Delete"
                            ConfirmText="确定要执行选中行操作吗？" Text="批量删除" OnClick="Button_delete_OnClick">
                        </f:Button>--%>

                
                    </Items>
                </f:Toolbar>
            </Toolbars>
            <Items>
                <f:Grid ID="Grid1" runat="server" Title="Grid" AllowPaging="True" AllowSorting="True" SortDirection="asc" SortField="sort"
                    EnableCheckBoxSelect="true"  DataKeyNames="id" EnableTextSelection="True" CheckBoxSelectOnly="True"
                    IsDatabasePaging="false" ShowHeader="False" OnPageIndexChange="Grid1_OnPageIndexChange" OnSort="Grid1_OnSort">
                    <Toolbars>
                        <f:Toolbar runat="server">
                            <Items>
                                <f:ToolbarText runat="server" Text="条件"></f:ToolbarText>
                                <f:ToolbarSeparator runat="server" />

                                <f:TwinTriggerBox ID="ttbSearchMessage" runat="server" ShowLabel="false" EmptyText="真实姓名搜索" OnTrigger1Click="ttbSearchMessage_OnTrigger1Click" OnTrigger2Click="ttbSearchMessage_OnTrigger2Click"
                                    Trigger1Icon="Clear" Trigger2Icon="Search" ShowTrigger1="false">
                                </f:TwinTriggerBox>
                            </Items>
                        </f:Toolbar>
                    </Toolbars>
                    <PageItems>
                        <f:ToolbarSeparator ID="ToolbarSeparator1" runat="server"/>
                        
                        <f:ToolbarText ID="ToolbarText1" runat="server" Text="每页记录数："/>
                        
                        <f:DropDownList runat="server" ID="ddlPageSize" Width="80px" AutoPostBack="true" OnSelectedIndexChanged="ddlPageSize_OnSelectedIndexChanged">
                            <f:ListItem Text="10" Value="10" />
                            <f:ListItem Text="20" Value="20" Selected="True" />
                            <f:ListItem Text="50" Value="50" />
                            <f:ListItem Text="100" Value="100" />
                        </f:DropDownList>
                        
                         
                    </PageItems>
                    <Columns>
                        <f:RowNumberField EnablePagingNumber="true" HeaderText="序号" Width="150px" TextAlign="Center" />
                        <f:TemplateField runat="server" SortField="物料号" Width="100px" HeaderText="物料号">
                            <ItemTemplate>
                                <%#Eval("物料号") %>
                            </ItemTemplate>
                        </f:TemplateField>
                        <f:TemplateField runat="server" SortField="总预留数量" Width="100px" HeaderText="总预留数量">
                            <ItemTemplate>
                                <%#Eval("总预留数量") %>
                            </ItemTemplate>
                        </f:TemplateField>
                        <f:TemplateField runat="server" SortField="总发料数量" Width="100px" HeaderText="总发料数量">
                            <ItemTemplate>
                                <%#Eval("总发料数量") %>
                            </ItemTemplate>
                        </f:TemplateField>
                        <f:TemplateField runat="server" SortField="总剩余数量" Width="150px" HeaderText="总剩余数量">
                            <ItemTemplate>
                                <%#Eval("总剩余数量") %>
                            </ItemTemplate>
                        </f:TemplateField>
                       <%-- <f:WindowField ColumnID="editField" TextAlign="Center" Icon="Pencil" ToolTip="编辑" HeaderText="编辑"
                            WindowID="Window1" Title="编辑" DataIFrameUrlFields="ID" DataIFrameUrlFormatString="sysAdminAdd.aspx?id={0}"
                            Width="50px" />--%>
                    </Columns>
                </f:Grid>
            </Items>
        </f:Panel>

        <f:Window ID="Window1" runat="server" Height="450px" Width="650px" IsModal="true" EnableMaximize="True"
            CloseAction="HidePostBack" EnableIFrame="True" Hidden="True" Icon="ApplicationFormEdit" OnClose="Window1_OnClose"
            Target="Top" EnableResize="True">
        </f:Window>
    </form>
</body> 
</html>
