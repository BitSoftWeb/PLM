<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="设备台账.aspx.cs" Inherits="FineUIPro.EmptyProjectNet40.PLM设备信息.设备台账" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="sourcefiles" content="~/PLM设备信息/设备履历.aspx" />
    <meta name="sourcefiless" content="~/PLM设备信息/全生命周期页面.aspx" />
    <title></title>

</head>
<%--<link rel="stylesheet" type="text/css" media="all" href="../res/ztree/css/zTreeStyle.css" />
<link rel="stylesheet" type="text/css" media="all" href="../res/core/treeSelect.css" />--%>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="Panel7" runat="server" />
        <f:Panel ID="Panel7" runat="server" BodyPadding="10px"
            Title="Panel" ShowBorder="false" ShowHeader="false" Layout="VBox" BoxConfigAlign="Stretch">
            <Items>
                <f:Form ID="Form2" ShowBorder="False" ShowHeader="False" runat="server">
                    <Rows>
                        <f:FormRow ColumnWidths="20% 80%">
                            <Items>
                                <f:Tree ID="Tree1" IsFluid="true" CssClass="blockpanel" ShowHeader="true" Title="树控件" EnableCollapse="false"
                                    runat="server" Height="900px" EnableSingleExpand="true" OnNodeCommand="Tree1_NodeCommand">
                                </f:Tree>


                                <f:Grid ID="Grid1" Title="数据表格" PageSize="15" IsFluid="true" CssClass="blockpanel" ShowBorder="true" BoxFlex="1" AllowPaging="true" IsDatabasePaging="false" ShowHeader="true" runat="server" DataKeyNames="ID,SBID,SAP编号,设备编号,设备名称,设备规格,设备型号,投产时间,部门名称,单位名称,使用单位" OnRowCommand="Grid1_RowCommand">
                                    <Toolbars>
                                        <f:Toolbar ID="Toolbar2" runat="server">
                                            <Items>
                                                <f:ToolbarSeparator ID="ToolbarSeparator1" runat="server">
                                                </f:ToolbarSeparator>
                                                <f:ContentPanel runat="server" Title="asd" ShowHeader="False" Height="45">
                                                    <f:Label ID="设备总数" EncodeText="false" runat="server"></f:Label>
                                                    &nbsp&nbsp&nbsp
                                                  <f:Label ID="故障总数" EncodeText="false" runat="server"></f:Label>
                                                    &nbsp&nbsp
                                                   <%-- <div  class="treeSelect"  style="width: 350px;"></div>--%>
                                                    <%--  <br />--%>
                                                    <%--  <f:Label ID="labResult" EncodeText="false" runat="server"></f:Label>--%>
                                                </f:ContentPanel>

                                                <f:TwinTriggerBox runat="server" EmptyText="输入要搜索的关键词" ShowLabel="false" ID="ttbSearch"
                                                    ShowTrigger1="false"
                                                    Trigger1Icon="Clear" Trigger2Icon="Search" Width="300">
                                                </f:TwinTriggerBox>
                                                    <f:DropDownList AutoPostBack="false" Required="true"   EnableSimulateTree="true"
                                                    ShowRedStar="true" runat="server" ID="ddlBox" Width="400" >
                                                </f:DropDownList>

                                                

                                            </Items>
                                        </f:Toolbar>
                                    </Toolbars>
                                    <Columns>
                                        <%--这里要想获取选中行数据必须使用RenderField声明 根据ColumnID获取 DataField数据库绑定字段 HeaderText HTML显示标题 --%>
                                        <f:RowNumberField />
                                        <f:RenderField ColumnID="ID" DataField="ID" HeaderText="ID" Hidden="True"></f:RenderField>
                                        <f:RenderField ColumnID="SBID" DataField="SBID" HeaderText="SBID" Hidden="True"></f:RenderField>

                                        <f:RenderField ColumnID="SAP编号" DataField="SAP编号" HeaderText="SAP编号" Hidden="True"></f:RenderField>
                                        <f:RenderField ColumnID="设备编号" DataField="设备编号" HeaderText="设备编号"></f:RenderField>
                                        <f:RenderField ColumnID="设备名称" DataField="设备名称" HeaderText="设备名称" Width="200"></f:RenderField>
                                        <f:RenderField ColumnID="设备型号" DataField="设备型号" HeaderText="设备型号" />
                                        <f:RenderField ColumnID="固资原值" DataField="固资原值" HeaderText="固资原值" />
                                        <f:RenderField ColumnID="固资净值" DataField="固资净值" HeaderText="固资净值" />
                                        <f:RenderField ColumnID="制造商" DataField="制造商" HeaderText="制造商" />
                                        <f:RenderField ColumnID="投产时间" DataField="投产时间" HeaderText="投产时间" />
                                        <f:RenderField ColumnID="设备规格" DataField="设备规格" HeaderText="设备规格" ExpandUnusedSpace="true" />
                                        <f:RenderField ColumnID="部门名称" DataField="部门名称" HeaderText="部门名称" Hidden="True" />
                                        <f:RenderField ColumnID="单位名称" DataField="单位名称" HeaderText="单位名称" Hidden="True" />
                                        <f:RenderField ColumnID="使用单位" DataField="使用单位" HeaderText="使用单位" Hidden="True"></f:RenderField>

                                        <%--  <f:LinkButtonField Width="100" CommandName="Action2" Text="设备履历" Icon="ApplicationGo" />--%>
                                        <f:LinkButtonField Width="80" CommandName="Action1" HeaderText="设备卡片" IconUrl="../res/icon/application_form.png" />
                                        <f:TemplateField HeaderText="新标签页打开" Width="100px">
                                            <ItemTemplate>
                                                <a href="javascript:;" onclick="<%# GetEditUrl(Eval("设备编号"), Eval("设备名称"), Eval("投产时间")) %>">设备履历</a>
                                            </ItemTemplate>
                                        </f:TemplateField>

                                        <f:TemplateField HeaderText="新标签页打开" Width="100px">
                                            <ItemTemplate>
                                                <a href="javascript:;" onclick="<%# GetEditUrls(Eval("设备编号")) %>">全生命周期</a>
                                            </ItemTemplate>
                                        </f:TemplateField>


                                        <%--  <f:LinkButtonField Width="80" CommandName="Action1" HeaderText="全生命周期" IconUrl="../res/icon/shape_align_middle.png" />--%>
                                    </Columns>
                                </f:Grid>

                            </Items>
                        </f:FormRow>

                    </Rows>
                </f:Form>




            </Items>
        </f:Panel>

        <f:Window ID="Window1" Title="查看详情" Hidden="true" EnableIFrame="false"
            EnableMaximize="true" Target="Self" EnableResize="true" runat="server"
            IsModal="true" Width="900px">
            <Items>
                <f:SimpleForm ID="SimpleForm1" runat="server" ShowBorder="false" ShowHeader="false" BodyPadding="10px">
                    <Items>
                        <f:HiddenField ID="hfFormID" runat="server"></f:HiddenField>
                        <f:TabStrip ID="TabStrip1" IsFluid="true" CssClass="blockpanel" Height="500px" ShowBorder="true" TabPosition="Top"
                            EnableTabCloseMenu="false" ActiveTabIndex="0" runat="server" AutoPostBack="true" OnTabIndexChanged="TabStrip1_TabIndexChanged">
                            <Tabs>
                                <f:Tab Title="<span class='highlight'>基础信息</span>" BodyPadding="10px"
                                    runat="server" TableColspan="0" TableRowspan="0" IconUrl="../res/icon/application_side_list.png">
                                    <Items>
                                        <f:ContentPanel runat="server" Title="asd" ShowHeader="False">
                                            <br />
                                            <f:TextBox runat="server" Label="SAP编号" ID="SAP编号" Width="400px" LabelWidth="110"></f:TextBox>
                                            &nbsp&nbsp&nbsp&nbsp
                                            <f:TextBox runat="server" Label="设备编号" ID="设备编号" Width="400px" LabelWidth="110"></f:TextBox>
                                            <br />
                                            <f:TextBox runat="server" Label="设备名称" ID="设备名称" Width="400px" LabelWidth="110"></f:TextBox>
                                            &nbsp&nbsp&nbsp&nbsp
                                            <f:TextBox runat="server" Label="设备规格" ID="设备规格" Width="400px" LabelWidth="110"></f:TextBox>
                                            <br />
                                            <f:TextBox runat="server" Label="设备型号" ID="设备型号" Width="400px" LabelWidth="110"></f:TextBox>
                                            &nbsp&nbsp&nbsp&nbsp
                                            <f:TextBox runat="server" Label="投产时间" ID="投产时间" Width="400px" LabelWidth="110"></f:TextBox>
                                            <br />
                                            <f:TextBox runat="server" Label="所属部门" ID="所属部门" Width="400px" LabelWidth="110"></f:TextBox>
                                            &nbsp&nbsp&nbsp&nbsp
                                            <f:TextBox runat="server" Label="所属单位" ID="所属单位" Width="400px" LabelWidth="110"></f:TextBox>
                                            <br />

                                            <asp:Image ID="Image1" runat="server" ImageUrl="~/res/images/wzp.gif" Width="400" Height="270" AlternateText="图片" />
                                            &nbsp
                                            <%--<asp:Image ID="Image2" runat="server"   Width="400" Height="270" AlternateText="图片"  />--%>
                                            <%--     <h3>设备二维码</h3>--%>
                                            <f:Image ID="Image3" runat="server" Width="400" Height="270"></f:Image>
                                        </f:ContentPanel>

                                        <%-- <f:TextBox runat="server" Label="资产编号" ID="资产编号"></f:TextBox>
                                        <f:TextBox runat="server" Label="资产名称" ID="资产名称"></f:TextBox>
                                        <f:TextBox runat="server" Label="型号" ID="型号"></f:TextBox>
                                        <f:TextBox runat="server" Label="归属部门" ID="归属部门"></f:TextBox>
                                        <f:TextBox runat="server" Label="存放地点" ID="存放地点"></f:TextBox>
                                        <f:TextBox runat="server" Label="负责人" ID="负责人"></f:TextBox>
                                        <f:TextBox runat="server" Label="使用状态" ID="使用状态"></f:TextBox>--%>
                                    </Items>
                                </f:Tab>
                                <f:Tab Title="关联备件" BodyPadding="10px" Layout="Fit" runat="server" IconUrl="../res/icon/arrow_switch.png">
                                    <Items>
                                        <f:SimpleForm ID="SimpleForm2" ShowBorder="false"
                                            ShowHeader="false" Title="SimpleForm1" LabelWidth="120px" runat="server">
                                            <Items>
                                                <f:Grid ID="Grid2" Title="数据表格" PageSize="15" IsFluid="true" CssClass="blockpanel" ShowBorder="true" BoxFlex="1" AllowPaging="true" IsDatabasePaging="false" ShowHeader="true" runat="server" Height="450px">
                                                    <Columns>
                                                        <%--这里要想获取选中行数据必须使用RenderField声明 根据ColumnID获取 DataField数据库绑定字段 HeaderText HTML显示标题 --%>
                                                        <f:RowNumberField />
                                                        <f:RenderField ColumnID="物料号" DataField="物料号" HeaderText="物料号"></f:RenderField>
                                                        <f:RenderField ColumnID="备件名称" DataField="备件名称" HeaderText="备件名称"></f:RenderField>
                                                        <f:RenderField ColumnID="规格型号" DataField="规格型号" HeaderText="规格型号" Hidden="True" />
                                                        <f:RenderField ColumnID="计量单位" DataField="计量单位" HeaderText="计量单位" Hidden="True" />
                                                        <f:RenderField ColumnID="管理类别" DataField="管理类别" HeaderText="管理类别" />
                                                        <f:RenderField ColumnID="成本中心" DataField="成本中心" HeaderText="成本中心" Hidden="True" />
                                                        <f:RenderField ColumnID="提报单位" DataField="提报单位" HeaderText="提报单位" Hidden="True" />
                                                        <f:RenderField ColumnID="库存" DataField="库存" HeaderText="库存" />
                                                        <f:RenderField ColumnID="总金额" DataField="总金额" HeaderText="总金额" />

                                                    </Columns>
                                                </f:Grid>

                                            </Items>
                                        </f:SimpleForm>
                                    </Items>
                                </f:Tab>

                                <f:Tab Title="维修记录" BodyPadding="10px" runat="server" IconUrl="../res/icon/asterisk_orange.png">
                                    <Items>
                                        <f:Grid ID="Grid3" Title="数据表格" PageSize="15" IsFluid="true" CssClass="blockpanel" ShowBorder="true" BoxFlex="1" AllowPaging="true" IsDatabasePaging="false" ShowHeader="true" runat="server" Height="450px">
                                            <Columns>
                                                <%--这里要想获取选中行数据必须使用RenderField声明 根据ColumnID获取 DataField数据库绑定字段 HeaderText HTML显示标题 --%>
                                                <f:RowNumberField />
                                                <f:RenderField ColumnID="故障时间" DataField="故障时间" HeaderText="故障时间"></f:RenderField>
                                                <f:RenderField ColumnID="报修时间" DataField="报修时间" HeaderText="报修时间"></f:RenderField>
                                                <f:RenderField ColumnID="故障描述" DataField="故障描述" HeaderText="故障描述" />
                                                <f:RenderField ColumnID="更换备件" DataField="更换备件" HeaderText="更换备件" />
                                                <f:RenderField ColumnID="故障分析" DataField="故障分析" HeaderText="故障分析" />
                                                <f:RenderField ColumnID="维修措施" DataField="维修措施" HeaderText="维修措施" />
                                                <f:RenderField ColumnID="解决故障时间" DataField="解决故障时间" HeaderText="解决故障时间" />
                                                <f:RenderField ColumnID="维修费用" DataField="维修费用" HeaderText="维修费用" />
                                                <f:RenderField ColumnID="解决方案及计划" DataField="解决方案及计划" HeaderText="解决方案及计划" />
                                                <f:RenderField ColumnID="维修人" DataField="维修人" HeaderText="维修人" />
                                                <f:RenderField ColumnID="完成情况" DataField="完成情况" HeaderText="完成情况" />
                                                <f:RenderField ColumnID="原因分析" DataField="原因分析" HeaderText="原因分析" />
                                                <f:RenderField ColumnID="解决故障办法" DataField="解决故障办法" HeaderText="解决故障办法" />
                                            </Columns>
                                        </f:Grid>
                                    </Items>
                                </f:Tab>

                                <f:Tab Title="设备BOM" BodyPadding="10px" runat="server" IconUrl="../res/icon/asterisk_orange.png">
                                    <Items>
                                    </Items>
                                </f:Tab>
                                <f:Tab Title="备件消耗汇总" BodyPadding="10px" runat="server" IconUrl="../res/icon/asterisk_orange.png">
                                    <Items>
                                        <f:Grid ID="Grid4" Title="数据表格" PageSize="15" IsFluid="true" CssClass="blockpanel" ShowBorder="true" BoxFlex="1" AllowPaging="true" IsDatabasePaging="false" ShowHeader="true" runat="server" Height="450px">
                                            <Columns>
                                                <%--这里要想获取选中行数据必须使用RenderField声明 根据ColumnID获取 DataField数据库绑定字段 HeaderText HTML显示标题 --%>
                                                <f:RowNumberField />
                                                <f:RenderField ColumnID="物料号" DataField="物料号" HeaderText="物料号"></f:RenderField>
                                                <f:RenderField ColumnID="备件名称" DataField="备件名称" HeaderText="备件名称" Width="150"></f:RenderField>
                                                <f:RenderField ColumnID="操作数量" DataField="操作数量" HeaderText="消耗量"></f:RenderField>
                                            </Columns>
                                        </f:Grid>

                                    </Items>
                                </f:Tab>
                                <f:Tab Title="预防性维修" BodyPadding="10px" runat="server" IconUrl="../res/icon/asterisk_orange.png">
                                    <Items>
                                        <f:Grid ID="Grid5" Title="数据表格" PageSize="15" IsFluid="true" CssClass="blockpanel" ShowBorder="true" BoxFlex="1" AllowPaging="true" IsDatabasePaging="false" ShowHeader="true" runat="server" Height="450px">
                                            <Columns>
                                                <%--这里要想获取选中行数据必须使用RenderField声明 根据ColumnID获取 DataField数据库绑定字段 HeaderText HTML显示标题 --%>
                                                <f:RowNumberField />
                                                <f:RenderField ColumnID="设备类型" DataField="设备类型" HeaderText="设备类型" Width="150"></f:RenderField>
                                                <f:RenderField ColumnID="部位" DataField="部位" HeaderText="部位" Width="150"></f:RenderField>
                                                <f:RenderField ColumnID="故障时间间隔" DataField="故障时间间隔" HeaderText="故障时间间隔" Width="150"></f:RenderField>
                                                <f:RenderField ColumnID="平均维修时长" DataField="平均维修时长" HeaderText="平均维修时长" Width="150"></f:RenderField>
                                            </Columns>
                                        </f:Grid>
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
