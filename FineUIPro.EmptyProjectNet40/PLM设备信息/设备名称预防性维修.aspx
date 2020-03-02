<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="设备名称预防性维修.aspx.cs" Inherits="FineUIPro.EmptyProjectNet40.PLM设备信息.设备名称预防性维修" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="Panel1" runat="server" />
        <f:Panel ID="Panel1" runat="server" ShowBorder="false" ShowHeader="false" BodyPadding="10px" Layout="VBox" BoxConfigAlign="Stretch">
            <Items>
                <f:Form ID="Form2" ShowBorder="false" ShowHeader="false" runat="server">
                    <Rows>
                        <f:FormRow>
                            <Items>
                                <f:TwinTriggerBox runat="server" EmptyText="输入要设备名称" ShowLabel="false" ID="ttSearch" ShowTrigger1="false" Trigger1Icon="Clear" Trigger2Icon="Search" OnTrigger2Click="ttSearch_Trigger2Click" >
                                </f:TwinTriggerBox>

                                <f:DropDownList ID="DropDownList1" ShowLabel="false" AutoPostBack="true"  runat="server">
                                    <f:ListItem Text="根据设备类型查询" Value="设备类型" />
                                 <%--   <f:ListItem Text="根据设备编号查询" Value="设备编号" />--%>
                                   
                                </f:DropDownList>
                            </Items>
                        </f:FormRow>
                    </Rows>
                </f:Form>
                <f:Grid ID="Grid1" Title="数据表格" PageSize="15" IsFluid="true" CssClass="blockpanel" ShowBorder="true" BoxFlex="1" AllowPaging="true" IsDatabasePaging="false"
                    ShowHeader="true" runat="server">
                    <Toolbars>
                        <f:Toolbar ID="Toolbar2" runat="server">
                            <Items>
                                <%--<f:Button ID="btnCheckSelection" runat="server" Text="资产处置"></f:Button>--%>
                            </Items>
                        </f:Toolbar>
                    </Toolbars>
                    <Columns>
                        <f:RowNumberField />
                        <f:RenderField ColumnID="设备类型" DataField="设备类型" HeaderText="设备类型" Width="150"></f:RenderField>
                      <%--  <f:RenderField ColumnID="设备编号" DataField="设备编号" HeaderText="设备编号" Width="150"></f:RenderField>--%>
                        <f:RenderField ColumnID="部位" DataField="部位" HeaderText="部位" Width="200"></f:RenderField>
                        <f:RenderField ColumnID="故障时间间隔" DataField="故障时间间隔" HeaderText="故障时间间隔（天）" Width="200"></f:RenderField>
                        <f:RenderField ColumnID="平均维修时长" DataField="平均维修时长" HeaderText="平均维修时长（小时）" Width="200"></f:RenderField>
                        <f:RenderField ColumnID="平均维修人数" DataField="平均维修人数" HeaderText="平均维修人数（人）" Width="200"></f:RenderField>
                    </Columns>
                </f:Grid>
            </Items>
        </f:Panel>
    </form>
</body>
</html>
