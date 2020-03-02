<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="消息中心首页.aspx.cs" Inherits="FineUIPro.EmptyProjectNet40.消息中心.消息中心首页" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
    <style type="text/css">
        .f-grid-row .f-grid-cell-消息事项 {
            background-color: #0094ff;
            color: #fff;
        }

        /*.f-grid-row .f-grid-cell-盘盈或盘亏简要原因 {
            background-color: #ff006e; 
            color: #fff;
        }

        .f-grid-row .f-grid-cell-闲置或待报废简要原因 {
            background-color: #ff6a00;
            color: #fff;
        }*/
        /*.f-grid-row .f-grid-cell-盘盈或盘亏简要原因 {
            background-color: #b200ff;
            color: #fff;
        }

            .f-grid-row .f-grid-cell-闲置或待报废简要原因 a,
            .f-grid-row .f-grid-cell-闲置或待报废简要原因 a:hover {
                color: #fff;
            }*/
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" runat="server" />


        <f:Panel ID="Panel7" runat="server" BodyPadding="10px"
            Title="Panel" ShowBorder="false" ShowHeader="false" Layout="VBox">
            <Items>
                <f:Form ID="Form5" ShowBorder="False" ShowHeader="False" runat="server">
                    <Rows>
                        <f:FormRow ColumnWidths="8% 8%  8% 8% 20%">
                            <Items>
                                <f:Button Text="选中所有行" runat="server" ID="btnSelectAll" Icon="Anchor" OnClick="btnSelectAll_Click">
                                </f:Button>
                                <f:Button Text="清空选中行" runat="server" ID="btnClearSelect" Icon="Anchor" OnClick="btnClearSelect_Click">
                                </f:Button>
                                <%--   <f:TextBox runat="server" Label="单位名称" ID="二级单位" Width="250px" LabelWidth="90" Enabled="false"></f:TextBox>--%>
                             
                                <f:Label ID="Label1" Text="XXX条未读数据" runat="server">
                                </f:Label>
                                <f:CheckBox ID="CheckBox1" ShowLabel="false" runat="server" Text="全部设为已读" Checked="true">
                                </f:CheckBox>
                                   <f:DropDownList ID="通知类型" Width="250px" runat="server" Label="通知类型" LabelWidth="90" AutoPostBack="true" AutoSelectFirstItem="false" EmptyText="全部消息">
                                </f:DropDownList>

                            <%--    <f:Button ID="SelectContentBtn" runat="server" Text="查询" Icon="Magnifier"></f:Button>--%>
                                <%--    <f:Button ID="Button1" runat="server" Text="设置" Icon="Magnifier"></f:Button>--%>
                            </Items>
                        </f:FormRow>
                    </Rows>
                </f:Form>



                <f:Grid ID="Grid1" IsFluid="true" CssClass="blockpanel" ShowBorder="true" ShowHeader="true" Title="提醒通知" EnableCollapse="false" Height="500px"
                    runat="server" DataKeyNames="Id,Name" ExpandAllRowExpanders="true" EnableCheckBoxSelect="true">
                    <Columns>
                        <f:TemplateField RenderAsRowExpander="true">
                            <ItemTemplate>
                                <div class="expander">
                                    <p>
                                        <strong><%# Eval("消息事项") %></strong>
                                    </p>
                                    <p>
                                        <strong><%# Eval("事项内容") %></strong>
                                    </p>
                                </div>
                            </ItemTemplate>
                        </f:TemplateField>
                        <f:RowNumberField />
                        <f:BoundField Width="250px" ColumnID="消息事项" DataField="消息事项" HeaderText="消息事项" />
                        <f:RenderField ColumnID="发起人" DataField="发起人" HeaderText="发起人"></f:RenderField>
                        <f:RenderField ColumnID="时间" DataField="时间" HeaderText="时间"></f:RenderField>
                        <f:RenderField ColumnID="通知类型" DataField="通知类型" HeaderText="通知类型" Width="150px"></f:RenderField>
                        <f:RenderField ColumnID="是否已读" DataField="是否已读" HeaderText="是否已读"></f:RenderField>

                    </Columns>

                    <Toolbars>
                        <f:Toolbar ID="Toolbar2" runat="server">
                            <Items>
                                <f:Button ID="btnExpandRowExpanders" runat="server" CssClass="marginr" Text="展开全部的行扩展列" OnClick="btnExpandRowExpanders_Click">
                                </f:Button>
                                <f:Button ID="btnCollapseRowExpanders" runat="server" Text="折叠全部的行扩展列" OnClick="btnCollapseRowExpanders_Click">
                                </f:Button>
                            </Items>
                        </f:Toolbar>
                    </Toolbars>
                </f:Grid>

            </Items>
        </f:Panel>
    </form>
</body>
</html>
