<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="全生命周期页面.aspx.cs" Inherits="FineUIPro.EmptyProjectNet40.PLM设备信息.全生命周期页面" %>

<!DOCTYPE html>
<html>

<head runat="server">
    <meta charset="utf-8" />
    <link rel="stylesheet" type="text/css" href="../res/css/lib/bootstrap.min.css" />
    <!--<link rel="stylesheet/less" type="text/css" href="css/less/style.less?1.10" />
		<script type="text/javascript" src="js/lib/less.js"></script>-->
    <link rel="stylesheet" type="text/css" href="../res/css/less/style.css" />
    <title></title>
</head>

<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="Panel7" runat="server" />
        <div class="container">
            <h3>全生命周期阶段</h3>
            <hr />
            <h5>
                <asp:Label ID="Label6" runat="server" Text="Label" Font-Size="X-Large" ForeColor="#ff3300"></asp:Label></h5>
            <ul class="nav nav-pills nav-justified step step-arrow">
                <li>
                    <a>购置验收阶段</a>
                    <br />
                    <asp:Button ID="s" runat="server" Text="查看详情" OnClick="s_Click" />
                </li>
                <li>
                    <a>运行/故障阶段</a>
                    <br />
                    <asp:Button ID="Button1" runat="server" Text="查看详情" OnClick="s_Click" />
                </li>
                <li>
                    <a>资产处置阶段</a>
                    <br />
                    <asp:Button ID="Button2" runat="server" Text="查看详情" OnClick="s_Click" />
                </li>
                <%--    <li>
                    <a>处置阶段</a>
                    <br />
                    <asp:Label ID="Label4" runat="server" Text="查看详情"></asp:Label>
                </li>
                <li>
                    <a>***阶段</a>
                    <br />
                    <asp:Label ID="Label5" runat="server" Text="查看详情"></asp:Label>
                </li>--%>
            </ul>
            <%--<h5>square模式</h5>
			<ul class="nav nav-pills nav-justified step step-square" data-step="2">
				<li>
					<a>step1</a>
				</li>
				<li>
					<a>step2</a>
				</li>
				<li>
					<a>step3</a>
				</li>
				<li>
					<a>step4</a>
				</li>
				<li>
					<a>step5</a>
				</li>
			</ul>--%>
            <%--	<h5>round模式</h5>
			<ul class="nav nav-pills nav-justified step step-round" data-step="3">
				<li>
					<a>step1</a>
				</li>
				<li>
					<a>step2</a>
				</li>
				<li>
					<a>step3</a>
				</li>
				<li>
					<a>step4</a>
				</li>
				<li>
					<a>step5</a>
				</li>
			</ul>--%>
            <%--<h5>progress模式</h5>
			<ul class="nav nav-pills nav-justified step step-progress" data-step="4">
				<li>
					<a>step1<span class="caret"></span></a>
				</li>
				<li>
					<a>step2<span class="caret"></span></a>
				</li>
				<li>
					<a>step3<span class="caret"></span></a>
				</li>
				<li>
					<a>step4<span class="caret"></span></a>
				</li>
				<li>
					<a>step5<span class="caret"></span></a>
				</li>
			</ul>--%>
            <style type="text/css">
                .vertical li > a {
                    padding: 45px 15px;
                }
            </style>
            <hr />


        </div>


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
                                    <%--    <f:ContentPanel runat="server" ShowHeader="False">
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
                                        </f:ContentPanel>--%>


                                    </Items>
                                </f:Tab>
                                <f:Tab Title="购置验收信息" BodyPadding="10px" Layout="Fit" runat="server" IconUrl="../res/icon/arrow_switch.png">
                                    <Items>
                                      <%--  <asp:Label ID="Label1" runat="server" Text="暂无数据"></asp:Label>--%>
                                           <f:Label ID="Label4" Text="暂无数据" runat="server"></f:Label>
                                    </Items>
                                </f:Tab>

                                <f:Tab Title="相关文件" BodyPadding="10px" runat="server" IconUrl="../res/icon/asterisk_orange.png">
                                    <Items>
                                       <%--  <asp:Label ID="Label2" runat="server" Text="暂无数据"></asp:Label>--%>
                                         <f:Label ID="Label3" Text="暂无数据" runat="server"></f:Label>
                                    </Items>
                                </f:Tab>

                            </Tabs>
                        </f:TabStrip>
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

        <script src="../res/js/jquery-1.10.2.js"></script>
        <script type="text/javascript" src="../res/js/lib/lib.js"></script>
        <script>
            $(function () {
                bsStep(2);
                //bsStep(i) i 为number 可定位到第几步 如bsStep(2)/bsStep(3)
            })
        </script>
    </form>
</body>

</html>
