<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="录入盘点信息.aspx.cs" Inherits="FineUIPro.EmptyProjectNet40.资产清查盘点.录入盘点信息" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style type="text/css">
        .f-grid-row .f-grid-cell-帐物是否相符 {
            background-color: #0094ff;
            color: #fff;
        }

        .f-grid-row .f-grid-cell-盘盈或盘亏简要原因 {
            background-color: #ff006e; 
            color: #fff;
        }

        .f-grid-row .f-grid-cell-闲置或待报废简要原因 {
            background-color: #ff6a00;
            color: #fff;
        }
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
        <f:PageManager ID="PageManager1" AutoSizePanelID="Panel7" runat="server" />
        <f:Panel ID="Panel7" runat="server" BodyPadding="10px"
            Title="Panel" ShowBorder="false" ShowHeader="false" Layout="VBox">
            <Items>

                <f:Form ID="Form5" ShowBorder="False" ShowHeader="False" runat="server">
                    <Rows>
                        <f:FormRow ColumnWidths="18% 18% 18% 15% ">
                            <Items>

                                <%--   <f:DropDownList ID="二级单位" Width="250px" runat="server" Label="单位名称" LabelWidth="90" AutoPostBack="true" AutoSelectFirstItem="false">
                                </f:DropDownList>--%>
                                <f:DropDownList ID="盘点名称" Width="250px" runat="server" Label="盘点名称" LabelWidth="90" AutoPostBack="true" >
                                </f:DropDownList>
                                <f:TextBox runat="server" Label="单位名称" ID="二级单位" Width="250px" LabelWidth="90" Enabled="false"></f:TextBox>
                                <f:DropDownList ID="三级单位" Width="250px" runat="server" Label="部门名称" LabelWidth="90" AutoPostBack="true" AutoSelectFirstItem="false" EmptyText="全部" OnSelectedIndexChanged="三级单位_SelectedIndexChanged">
                                </f:DropDownList>
                                <f:DropDownList ID="盘点类型" runat="server" Label="盘点类型" LabelWidth="90" AutoPostBack="true">
                                    <%--   <f:ListItem Text="全部" Value="全部" />--%>
                                    <f:ListItem Text="生产设备" Value="生产设备" />
                                    <f:ListItem Text="办公设备" Value="办公设备" EnableSelect="false" />
                                    <f:ListItem Text="工装转" Value="工装转" EnableSelect="false" />
                                    <f:ListItem Text="建筑物" Value="建筑物" EnableSelect="false" />
                                    <f:ListItem Text="传导设备" Value="传导设备" EnableSelect="false" />
                                </f:DropDownList>
                                <f:Button ID="SelectContentBtn" runat="server" Text="查询" Icon="Magnifier"></f:Button>
                            </Items>
                        </f:FormRow>
                    </Rows>
                </f:Form>


                <f:Grid ID="Grid1" Title="处理当前页数据" PageSize="15" IsFluid="true" CssClass="blockpanel" ShowBorder="true" BoxFlex="1" AllowPaging="true" IsDatabasePaging="true" EnableCollapse="false" ShowHeader="true" runat="server" AllowCellEditing="true" OnPageIndexChange="Grid1_PageIndexChange" DataKeyNames="ID,设备编号,帐物是否相符">



                    <Columns>
                        <f:RowNumberField EnablePagingNumber="true" />
                        <f:RenderField ColumnID="ID" DataField="ID"
                            HeaderText="ID" Hidden="True">
                            <Editor>
                                <f:TextBox ID="ID" runat="server">
                                </f:TextBox>
                            </Editor>
                        </f:RenderField>

                        <f:RenderField Width="100px" ColumnID="SAP编号" DataField="SAP编号"
                            HeaderText="SAP编号" EnableColumnEdit="false">
                            <Editor>
                                <f:TextBox ID="SAP编号" runat="server">
                                </f:TextBox>
                            </Editor>
                        </f:RenderField>
                        <f:RenderField Width="100px" ColumnID="设备编号" DataField="设备编号"
                            HeaderText="资产编号" EnableColumnEdit="false">
                            <Editor>
                                <f:TextBox ID="资产编号" runat="server">
                                </f:TextBox>
                            </Editor>
                        </f:RenderField>
                        <f:RenderField Width="150px" ColumnID="设备名称" DataField="设备名称"
                            HeaderText="资产名称" EnableColumnEdit="false">
                            <Editor>
                                <f:TextBox ID="资产名称" runat="server">
                                </f:TextBox>
                            </Editor>
                        </f:RenderField>

                        <f:RenderField Width="100px" ColumnID="设备型号" DataField="设备型号"
                            HeaderText="设备型号" EnableColumnEdit="false">
                            <Editor>
                                <f:TextBox ID="设备型号" runat="server">
                                </f:TextBox>
                            </Editor>
                        </f:RenderField>
                        <f:RenderField Width="100px" ColumnID="设备规格" DataField="设备规格"
                            HeaderText="设备规格" EnableColumnEdit="false">
                            <Editor>
                                <f:TextBox ID="设备规格" runat="server">
                                </f:TextBox>
                            </Editor>
                        </f:RenderField>
                        <f:RenderField Width="100px" ColumnID="制造商" DataField="制造商"
                            HeaderText="制造商" EnableColumnEdit="false">
                            <Editor>
                                <f:TextBox ID="制造商" runat="server">
                                </f:TextBox>
                            </Editor>
                        </f:RenderField>
                        <f:RenderField Width="150" ColumnID="三级部门名称" DataField="三级部门名称"
                            HeaderText="部门名称" EnableColumnEdit="false" >
                            <Editor>
                                <f:TextBox ID="部门名称" runat="server">
                                </f:TextBox>
                            </Editor>
                        </f:RenderField>

                        <f:RenderField Width="100px" ColumnID="投产时间" DataField="投产时间"
                            HeaderText="投产时间" EnableColumnEdit="false">
                            <Editor>
                                <f:TextBox ID="投产时间" runat="server">
                                </f:TextBox>
                            </Editor>
                        </f:RenderField>

                        <f:RenderField Width="100px" ColumnID="操作人" DataField="操作人"
                            HeaderText="操作人" EnableColumnEdit="false">
                            <Editor>
                                <f:TextBox ID="操作人" runat="server">
                                </f:TextBox>
                            </Editor>
                        </f:RenderField>


                        <f:RenderField Width="130px" ColumnID="帐物是否相符" DataField="帐物是否相符"
                            HeaderText="帐物是否相符">
                            <Editor>
                                <f:DropDownList ID="DropDownList1" Required="true" runat="server">
                                    <f:ListItem Text="是" Value="是"></f:ListItem>
                                    <f:ListItem Text="否" Value="否"></f:ListItem>
                                </f:DropDownList>
                            </Editor>
                        </f:RenderField>


                        <f:RenderField Width="100px" ColumnID="盘盈或盘亏简要原因" DataField="盘盈或盘亏简要原因"
                            HeaderText="盘盈或盘亏简要原因" ExpandUnusedSpace="true">
                            <Editor>
                                <f:TextBox ID="盘盈或盘亏简要原因"  runat="server">
                                </f:TextBox>
                            </Editor>
                        </f:RenderField>

                        <f:RenderField Width="100px" ColumnID="闲置或待报废简要原因" DataField="闲置或待报废简要原因"
                            HeaderText="闲置或待报废简要原因" ExpandUnusedSpace="true">
                            <Editor>
                                <f:TextBox ID="闲置或待报废简要原因"  runat="server">
                                </f:TextBox>
                            </Editor>
                        </f:RenderField>


                        <f:RenderField ColumnID="三级部门ID" DataField="三级部门ID"
                            HeaderText="三级部门ID" Hidden="True">
                            <Editor>
                                <f:TextBox ID="三级部门ID" runat="server">
                                </f:TextBox>
                            </Editor>
                        </f:RenderField>

                        <f:RenderField ColumnID="二级部门名称" DataField="二级部门名称"
                            HeaderText="二级部门名称" Hidden="True">
                            <Editor>
                                <f:TextBox ID="二级部门名称" runat="server">
                                </f:TextBox>
                            </Editor>
                        </f:RenderField>

                        <f:RenderField ColumnID="二级部门ID" DataField="二级部门ID"
                            HeaderText="二级部门ID" Hidden="True">
                            <Editor>
                                <f:TextBox ID="二级部门ID" runat="server">
                                </f:TextBox>
                            </Editor>
                        </f:RenderField>





                        <%--  <f:LinkButtonField Width="80" CommandName="Action1" HeaderText="查看详情" IconUrl="../res/icon/application_form.png" />--%>
                    </Columns>

                    <PageItems>
                        <f:ToolbarSeparator ID="ToolbarSeparator1" runat="server">
                        </f:ToolbarSeparator>
                        <f:ToolbarText runat="server" Text="每页记录数：">
                        </f:ToolbarText>
                        <f:DropDownList runat="server" ID="ddlPageSize" Width="100px" AutoPostBack="true"
                            OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged">
                            <f:ListItem Text="15" Value="15" />
                            <f:ListItem Text="30" Value="30" />
                            <f:ListItem Text="50" Value="50" />
                            <f:ListItem Text="100" Value="100" />
                        </f:DropDownList>
                    </PageItems>

                    <Toolbars>
                        <f:Toolbar ID="Toolbar2" runat="server">
                            <Items>
                                <f:Button ID="btnNew" Text="提交当前页盘点信息" Icon="ApplicationFormAdd" EnablePostBack="false" runat="server" OnClick="SelectContentBtn_Click">
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
