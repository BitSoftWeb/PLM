<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="盘点统计.aspx.cs" Inherits="FineUIPro.EmptyProjectNet40.资产清查盘点.盘点统计" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" runat="server" />
        <f:Panel ID="Panel7" runat="server" BodyPadding="10px"
            Title="Panel" ShowBorder="false" ShowHeader="false" Layout="VBox">
            <Items>
                <f:Form ID="Form5" ShowBorder="False" ShowHeader="False" runat="server">
                    <Rows>
                        <f:FormRow ColumnWidths="18% 18% 18% 15% 18%">
                            <Items>
                                <f:DropDownList ID="盘点名称" Width="250px" runat="server" Label="盘点名称" LabelWidth="90" AutoPostBack="true" Required="true">
                                </f:DropDownList>
                                <f:TextBox runat="server" Label="单位名称" ID="二级单位" Width="250px" LabelWidth="90" Enabled="false"></f:TextBox>
                                <f:DropDownList ID="三级单位" Width="250px" runat="server" Label="部门名称" LabelWidth="90" AutoPostBack="true" AutoSelectFirstItem="false" EmptyText="全部" OnSelectedIndexChanged="三级单位_SelectedIndexChanged">
                                </f:DropDownList>
                                <f:DropDownList ID="盘点类型" runat="server" Label="盘点类型" LabelWidth="90" AutoPostBack="true">
                                    <f:ListItem Text="生产设备" Value="生产设备" />
                                    <f:ListItem Text="办公设备" Value="办公设备" EnableSelect="false" />
                                    <f:ListItem Text="工装转" Value="工装转" EnableSelect="false" />
                                    <f:ListItem Text="建筑物" Value="建筑物" EnableSelect="false" />
                                    <f:ListItem Text="传导设备" Value="传导设备" EnableSelect="false" />
                                </f:DropDownList>
                                <f:Button ID="SelectContentBtn" runat="server" Text="查询" Icon="Magnifier" OnClick="SelectContentBtn_Click"></f:Button>
                            </Items>
                        </f:FormRow>
                    </Rows>
                </f:Form>

                <f:Grid ID="Grid1" IsFluid="true" CssClass="blockpanel" ShowBorder="true" ShowHeader="true" Title="资产清查统计" EnableCollapse="false" runat="server"
                    DataKeyNames="盘点任务名称,二级部门ID" AllowSorting="true" SortField="生产设备"
                    SortDirection="ASC" OnSort="Grid1_Sort" OnRowCommand="Grid1_RowCommand">
                    <Columns>
                        <f:RowNumberField />
                        <f:BoundField DataField="盘点任务名称" SortField="盘点任务名称" Width="150px" HeaderText="盘点任务名称" />
                        <f:BoundField DataField="部门" SortField="部门" Width="200px" HeaderText="部门" />
                        <f:BoundField DataField="二级部门ID" SortField="二级部门ID" Width="200px" HeaderText="二级部门ID" Hidden="true" />
                        <f:GroupField HeaderText="资产分类" TextAlign="Center">
                            <Columns>
                                <f:GroupField HeaderText="生产设备" TextAlign="Center" Width="200px">
                                    <Columns>
                                        <f:BoundField Width="100px" DataField="生产设备总数" HeaderText="总数" TextAlign="Center" />
                                        <f:BoundField Width="100px" DataField="生产设备已盘点" HeaderText="已盘点" TextAlign="Center" />
                                    </Columns>
                                </f:GroupField>

                                <f:GroupField HeaderText="办公设备" TextAlign="Center">
                                    <Columns>
                                        <f:BoundField Width="100px" DataField="办公设备总数" HeaderText="总数" TextAlign="Center" />
                                        <f:BoundField Width="100px" DataField="办公设备已盘点" HeaderText="已盘点" TextAlign="Center" />
                                    </Columns>
                                </f:GroupField>
                                <f:GroupField HeaderText="传导设备" TextAlign="Center">
                                    <Columns>
                                        <f:BoundField Width="100px" DataField="传导设备总数" HeaderText="总数" TextAlign="Center" />
                                        <f:BoundField Width="100px" DataField="传导设备已盘点" HeaderText="已盘点" TextAlign="Center" />
                                    </Columns>
                                </f:GroupField>
                                <f:GroupField HeaderText="建筑物" TextAlign="Center">
                                    <Columns>
                                        <f:BoundField Width="100px" DataField="建筑物总数" HeaderText="总数" TextAlign="Center" />
                                        <f:BoundField Width="100px" DataField="建筑物已盘点" HeaderText="已盘点" TextAlign="Center" />
                                    </Columns>
                                </f:GroupField>
                                <f:GroupField HeaderText="工装" TextAlign="Center">
                                    <Columns>
                                        <f:BoundField Width="100px" DataField="工装总数" HeaderText="总数" TextAlign="Center" />
                                        <f:BoundField Width="100px" DataField="工装已盘点" HeaderText="已盘点" TextAlign="Center" />
                                    </Columns>
                                </f:GroupField>

                            </Columns>
                        </f:GroupField>
                        <f:LinkButtonField Width="80" CommandName="Action1" HeaderText="查看详情" IconUrl="../res/icon/application_form.png" />
                    </Columns>
                </f:Grid>
            </Items>
        </f:Panel>

        <f:Window ID="Window1" Title="三级部门统计" Hidden="true" EnableIFrame="false"
            EnableMaximize="true" Target="Self" EnableResize="true" runat="server"
            IsModal="true" Width="1200px" Height="700">
            <Items>
                <f:Grid ID="Grid2" IsFluid="true" CssClass="blockpanel" ShowBorder="true" ShowHeader="true" Title="三级部门资产清查进度" EnableCollapse="false" runat="server"
                    DataKeyNames="" AllowSorting="true" SortField="生产设备"
                    SortDirection="ASC" OnSort="Grid1_Sort" OnRowCommand="Grid1_RowCommand" Height="620">
                    <Columns>
                        <f:RowNumberField />
                        <f:BoundField DataField="盘点任务名称" SortField="盘点任务名称" Width="150px" HeaderText="盘点任务名称" Hidden="true" />
                        <f:BoundField DataField="部门" SortField="部门" Width="150px" HeaderText="部门" />
                        <f:BoundField DataField="二级部门ID" SortField="二级部门ID" Width="200px" HeaderText="二级部门ID" Hidden="true"  />
                        <f:GroupField HeaderText="资产分类" TextAlign="Center">
                            <Columns>
                                <f:GroupField HeaderText="生产设备" TextAlign="Center" Width="200px">
                                    <Columns>
                                        <f:BoundField Width="100px" DataField="生产设备总数" HeaderText="总数" TextAlign="Center" />
                                        <f:BoundField Width="100px" DataField="生产设备已盘点" HeaderText="已盘点" TextAlign="Center" />
                                    </Columns>
                                </f:GroupField>

                                <f:GroupField HeaderText="办公设备" TextAlign="Center">
                                    <Columns>
                                        <f:BoundField Width="100px" DataField="办公设备总数" HeaderText="总数" TextAlign="Center" />
                                        <f:BoundField Width="100px" DataField="办公设备已盘点" HeaderText="已盘点" TextAlign="Center" />
                                    </Columns>
                                </f:GroupField>
                                <f:GroupField HeaderText="传导设备" TextAlign="Center">
                                    <Columns>
                                        <f:BoundField Width="100px" DataField="传导设备总数" HeaderText="总数" TextAlign="Center" />
                                        <f:BoundField Width="100px" DataField="传导设备已盘点" HeaderText="已盘点" TextAlign="Center" />
                                    </Columns>
                                </f:GroupField>
                                <f:GroupField HeaderText="建筑物" TextAlign="Center">
                                    <Columns>
                                        <f:BoundField Width="100px" DataField="建筑物总数" HeaderText="总数" TextAlign="Center" />
                                        <f:BoundField Width="100px" DataField="建筑物已盘点" HeaderText="已盘点" TextAlign="Center" />
                                    </Columns>
                                </f:GroupField>
                                <f:GroupField HeaderText="工装" TextAlign="Center">
                                    <Columns>
                                        <f:BoundField Width="100px" DataField="工装总数" HeaderText="总数" TextAlign="Center" />
                                        <f:BoundField Width="100px" DataField="工装已盘点" HeaderText="已盘点" TextAlign="Center" />
                                    </Columns>
                                </f:GroupField>

                            </Columns>
                        </f:GroupField>
                     
                    </Columns>
                </f:Grid>
            </Items>
        </f:Window>
    </form>
</body>
</html>
