<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="设备故障首页.aspx.cs" Inherits="FineUIPro.EmptyProjectNet40.设备故障维修.设备故障首页" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style>
        .f-grid-cell[data-color=color1] {
            background-color: #0094ff;
            color: #fff;
        }

        .f-grid-cell[data-color=color2] {
            background-color: #0026ff;
            color: #fff;
        }

        .f-grid-cell[data-color=color3] {
            background-color: #b200ff;
            color: #fff;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="Panel7" runat="server" />
        <f:Panel ID="Panel7" runat="server" BodyPadding="10px"
            Title="Panel" ShowBorder="false" ShowHeader="false" Layout="VBox" >
            <Items>
                <f:Form ID="Form5" ShowBorder="False" ShowHeader="False" runat="server">
                    <Rows>
                        <f:FormRow ColumnWidths="18% 18% 18% 18% 18% ">
                            <Items>

                                <f:DropDownList ID="二级单位" Width="250px" runat="server" Label="单位名称" LabelWidth="90" AutoPostBack="true" AutoSelectFirstItem="false" EmptyText="全部" OnSelectedIndexChanged="二级单位_SelectedIndexChanged">
                                </f:DropDownList>


                                <f:DatePicker runat="server" DateFormatString="yyyy-MM-dd" Label="开始日期" LabelWidth="90" EmptyText="请选择开始日期"
                                    ID="DatePicker1" ShowRedStar="true" Width="300px">
                                </f:DatePicker>
                                <f:DatePicker runat="server" DateFormatString="yyyy-MM-dd" Label="截止日期" LabelWidth="90" EmptyText="请选择截止日期"
                                    ID="DatePicker2" ShowRedStar="true" Width="300px">
                                </f:DatePicker>
                                <f:TwinTriggerBox runat="server" EmptyText="输入要搜索的关键词" ShowLabel="false" ID="ttbSearch"
                                    ShowTrigger1="false"
                                    Trigger1Icon="Clear" Trigger2Icon="Search" Width="300">
                                </f:TwinTriggerBox>
                                <f:DropDownList ID="年份" Width="150px" runat="server" Label="年份" LabelWidth="60" AutoPostBack="true" >
                                     <f:ListItem Text="2020" Value="2020" />
                                     <f:ListItem Text="2019" Value="2019" />
                                    <f:ListItem Text="2018" Value="2018" />
                                    <f:ListItem Text="2017" Value="2017" />
                                    <f:ListItem Text="2016" Value="2016" />
                                    <f:ListItem Text="2015" Value="2015" />
                                  
                                </f:DropDownList>
                                <f:Button ID="SelectContentBtn" runat="server" Text="查询" Icon="Magnifier" OnClick="SelectContentBtn_Click"></f:Button>
                                <f:Button ID="Button1" runat="server" Text="导出Excel" Icon="Magnifier" OnClick="SelectContentBtn_Click"></f:Button>
                            </Items>
                        </f:FormRow>
                    </Rows>
                </f:Form>
                <f:Grid ID="Grid1" Title="盘点统计" PageSize="15" IsFluid="true" CssClass="blockpanel" ShowBorder="true" BoxFlex="1" AllowPaging="true" IsDatabasePaging="false" ShowHeader="true" runat="server" DataKeyNames="ID,完成情况,设备编号,设备名称,故障描述,故障时间,解决故障时间,更换备件,问题描述,问题的可能影响,修理费用,报修人,维修人,名称,维修人数,维修工时,维修人员名单,原因分析,开始维修时间,解决方案及计划,解决故障根本问题的办法" OnRowCommand="Grid1_RowCommand" OnRowDataBound="Grid1_RowDataBound">
                    <%--  <Toolbars>
                        <f:Toolbar runat="server">
                            <Items>
                            </Items>
                        </f:Toolbar>
                    </Toolbars>--%>
                    <Columns>
                        <f:RowNumberField />
                        <f:RenderField ColumnID="ID" DataField="ID" HeaderText="ID" Hidden="True"></f:RenderField>
                        <f:BoundField ColumnID="完成情况" DataField="完成情况" HeaderText="完成情况"></f:BoundField>
                        <f:RenderField ColumnID="设备编号" DataField="设备编号" HeaderText="设备编号"></f:RenderField>
                        <f:RenderField ColumnID="设备名称" DataField="设备名称" HeaderText="设备名称" Width="150"></f:RenderField>
                        <f:RenderField ColumnID="故障描述" DataField="故障描述" HeaderText="故障描述" Width="150"></f:RenderField>
                        <f:RenderField ColumnID="故障时间" DataField="故障时间" HeaderText="故障时间" Width="150"></f:RenderField>
                        <f:RenderField ColumnID="解决故障时间" DataField="解决故障时间" HeaderText="解决故障时间" Width="150" />
                        <f:RenderField ColumnID="更换备件" DataField="更换备件" HeaderText="更换备件" Width="150"></f:RenderField>

                        <f:RenderField ColumnID="问题描述" DataField="问题描述" HeaderText="问题描述" />
                        <f:RenderField ColumnID="问题的可能影响" DataField="问题的可能影响" HeaderText="问题的可能影响" Hidden="True" />

                        <f:RenderField ColumnID="修理费用" DataField="修理费用" HeaderText="修理费用" Hidden="True" />
                        <f:RenderField ColumnID="报修人" DataField="报修人" HeaderText="报修人" />
                        <f:RenderField ColumnID="维修人" DataField="维修人" HeaderText="维修人" />
                        <f:RenderField ColumnID="名称" DataField="名称" HeaderText="所属单位" Width="150" />
                        <f:RenderField ColumnID="维修人数" DataField="维修人数" HeaderText="维修人数" Hidden="True" />
                        <f:RenderField ColumnID="维修工时" DataField="维修工时" HeaderText="维修工时" Hidden="True" />
                        <f:RenderField ColumnID="维修人员名单" DataField="维修人员名单" HeaderText="维修人员名单" Hidden="True"></f:RenderField>
                        <f:RenderField ColumnID="原因分析" DataField="原因分析" HeaderText="原因分析" Hidden="True" />
                        <f:RenderField ColumnID="开始维修时间" DataField="开始维修时间" HeaderText="开始维修时间" Hidden="True" />
                        <f:RenderField ColumnID="解决方案及计划" DataField="解决方案及计划" HeaderText="解决方案及计划" Hidden="True"></f:RenderField>
                        <f:RenderField ColumnID="解决故障根本问题的办法" DataField="解决故障根本问题的办法" HeaderText="解决故障根本问题的办法" Hidden="True" />

                        <f:LinkButtonField Width="150" CommandName="Action1" HeaderText="查看详情"  IconUrl="../res/icon/application_form.png" />

                    </Columns>
                </f:Grid>



            </Items>
        </f:Panel>

        <f:Window ID="Window1" Title="查看详情" Hidden="true" EnableIFrame="false"
            EnableMaximize="true" Target="Self" EnableResize="true" runat="server"
            IsModal="true" Width="900px">
            <Items>
                <f:SimpleForm ID="SimpleForm1" runat="server" ShowBorder="false" ShowHeader="false" BodyPadding="10px">
                    <Items>
                        <f:HiddenField ID="hfFormID" runat="server"></f:HiddenField>
                        <f:TabStrip ID="TabStrip1" IsFluid="true" CssClass="blockpanel" Height="550px" ShowBorder="true" TabPosition="Top"
                            EnableTabCloseMenu="false" ActiveTabIndex="0" runat="server" AutoPostBack="true">
                            <Tabs>
                                <f:Tab Title="<span class='highlight'>基础信息</span>" BodyPadding="10px"
                                    runat="server" TableColspan="0" TableRowspan="0" IconUrl="../res/icon/application_side_list.png">
                                    <Items>
                                        <f:ContentPanel runat="server" ShowHeader="False">
                                            <br />
                                            <f:TextBox runat="server" Label="完成情况" ID="完成情况" Width="400px" LabelWidth="110"></f:TextBox>
                                            &nbsp&nbsp&nbsp&nbsp
                                            <f:TextBox runat="server" Label="设备编号" ID="设备编号" Width="400px" LabelWidth="110"></f:TextBox>
                                            <br />
                                            <f:TextBox runat="server" Label="设备名称" ID="设备名称" Width="400px" LabelWidth="110"></f:TextBox>
                                            &nbsp&nbsp&nbsp&nbsp
                                            <f:TextBox runat="server" Label="故障描述" ID="故障描述" Width="400px" LabelWidth="110"></f:TextBox>
                                            <br />
                                            <f:TextBox runat="server" Label="更换备件" ID="更换备件" Width="400px" LabelWidth="110"></f:TextBox>
                                            &nbsp&nbsp&nbsp&nbsp
                                            <f:TextBox runat="server" Label="问题描述" ID="问题描述" Width="400px" LabelWidth="110"></f:TextBox>
                                            <br />
                                            <f:TextBox runat="server" Label="问题的可能影响" ID="问题的可能影响" Width="400px" LabelWidth="110"></f:TextBox>
                                            &nbsp&nbsp&nbsp&nbsp
                                            <f:TextBox runat="server" Label="故障时间" ID="故障时间" Width="400px" LabelWidth="110"></f:TextBox>
                                            &nbsp&nbsp&nbsp&nbsp
                                            <br />
                                            <f:TextBox runat="server" Label="解决故障时间" ID="解决故障时间" Width="400px" LabelWidth="110"></f:TextBox>
                                            &nbsp&nbsp&nbsp&nbsp
                                            <f:TextBox runat="server" Label="开始维修时间" ID="开始维修时间" Width="400px" LabelWidth="110"></f:TextBox>
                                            &nbsp&nbsp&nbsp&nbsp
                                            <br />
                                            <f:TextBox runat="server" Label="修理费用" ID="修理费用" Width="400px" LabelWidth="110"></f:TextBox>
                                            &nbsp&nbsp&nbsp&nbsp
                                            <f:TextBox runat="server" Label="报修人" ID="报修人" Width="400px" LabelWidth="110"></f:TextBox>
                                            &nbsp&nbsp&nbsp&nbsp
                                            <br />
                                            <f:TextBox runat="server" Label="维修人" ID="维修人" Width="400px" LabelWidth="110"></f:TextBox>
                                            &nbsp&nbsp&nbsp&nbsp
                                            <f:TextBox runat="server" Label="维修人数" ID="维修人数" Width="400px" LabelWidth="110"></f:TextBox>
                                            &nbsp&nbsp&nbsp&nbsp
                                            <br />
                                            <f:TextBox runat="server" Label="维修工时" ID="维修工时" Width="400px" LabelWidth="110"></f:TextBox>
                                            &nbsp&nbsp&nbsp&nbsp
                                            <f:TextBox runat="server" Label="维修人员名单" ID="维修人员名单" Width="400px" LabelWidth="110"></f:TextBox>
                                            &nbsp&nbsp&nbsp&nbsp
                                            <br />
                                            <f:TextBox runat="server" Label="原因分析" ID="原因分析" Width="400px" LabelWidth="110"></f:TextBox>
                                            &nbsp&nbsp&nbsp&nbsp
                                            <f:TextBox runat="server" Label="解决方案及计划" ID="解决方案及计划" Width="400px" LabelWidth="110"></f:TextBox>
                                            &nbsp&nbsp&nbsp&nbsp
                                            <br />
                                            <f:TextBox runat="server" Label="解决故障根本问题的办法" ID="解决故障根本问题的办法" Width="400px" LabelWidth="110"></f:TextBox>
                                            &nbsp&nbsp&nbsp&nbsp
                                          <f:TextBox runat="server" Label="所属单位" ID="所属单位" Width="400px" LabelWidth="110"></f:TextBox>
                                            <br />
                                        </f:ContentPanel>


                                    </Items>
                                </f:Tab>
                                <f:Tab Title="关联备件" BodyPadding="10px" Layout="Fit" runat="server" IconUrl="../res/icon/arrow_switch.png">
                                    <Items>
                                    </Items>
                                </f:Tab>

                                <f:Tab Title="维修记录" BodyPadding="10px" runat="server" IconUrl="../res/icon/asterisk_orange.png">
                                    <Items>
                                    </Items>
                                </f:Tab>

                                <f:Tab Title="设备BOM" BodyPadding="10px" runat="server" IconUrl="../res/icon/asterisk_orange.png">
                                    <Items>
                                    </Items>
                                </f:Tab>
                                <f:Tab Title="备件消耗汇总" BodyPadding="10px" runat="server" IconUrl="../res/icon/asterisk_orange.png">
                                    <Items>
                                    </Items>
                                </f:Tab>
                                <f:Tab Title="预防性维修" BodyPadding="10px" runat="server" IconUrl="../res/icon/asterisk_orange.png">
                                    <Items>
                                    </Items>

                                </f:Tab>
                            </Tabs>
                        </f:TabStrip>

                        <%--        <f:Button ID="Button3" CssClass="marginr" ValidateForms="SimpleForm1"
                            Text="验证第一个标签中的表单" runat="server">
                        </f:Button>
                        <f:Button ID="Button4" Text="打开下一个标签"  runat="server">
                        </f:Button>--%>
                    </Items>
                    <Toolbars>
                        <f:Toolbar ID="Toolbar1" Position="Bottom" ToolbarAlign="Right" runat="server">
                            <Items>

                                <f:Button ID="btnClose" Icon="SystemClose" runat="server" Text="关闭"></f:Button>
                            </Items>
                        </f:Toolbar>
                    </Toolbars>
                </f:SimpleForm>
            </Items>
        </f:Window>

    </form>
</body>
</html>
