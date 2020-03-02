<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EquipmentOperatingInstruction.aspx.cs" Inherits="FineUIPro.EmptyProjectNet40.设备操作规程.EquipmentOperatingInstruction" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>

    <form id="form1" target="_blank" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="Panel2" runat="server" />
        <br />
        <br />       
        <f:Panel ID="Panel2" ShowBorder="false" ShowHeader="false" Layout="VBox" BodyPadding="10px" runat="server">
            <Items>
                <f:Grid ID="Grid1" Title="数据表格" PageSize="15" IsFluid="true" CssClass="blockpanel" ShowBorder="true" BoxFlex="1" AllowPaging="true" IsDatabasePaging="false"
                    ShowHeader="true" runat="server" DataKeyNames="ID,设备类型,设备操作规程,新文件名,上传时间,新设备操作规程,文件类型,设备类型s" EnableCheckBoxSelect="false" Height="400px" OnRowCommand="Grid1_RowCommand">
                    <Toolbars>
                        <f:Toolbar runat="server">
                            <Items>
                                <f:Button runat="server" Text="上传文件" ID="upFile" OnClick="upFile_Click" ValidateForms="SimpleForm1"></f:Button>
                                <f:TwinTriggerBox EmptyText="输入要搜索的关键词"  ShowLabel="false" ID="ttSearch" ShowTrigger1="false" Trigger1Icon="Clear" Trigger2Icon="Search" OnTrigger2Click="ttSearch_Trigger2Click" runat="server"></f:TwinTriggerBox>
                                <%--<f:FileUpload runat="server" ID="filePhoto" Width="500px" EmptyText="请选择文件" Label="文件上传" Required="true" ButtonIcon="Add"
                                    ShowRedStar="true">
                                </f:FileUpload>
                                <f:DropDownList ID="DropDownList1" Width="250px" runat="server" AutoPostBack="true" Label="设备类型" AutoSelectFirstItem="false"  LabelWidth="80" EmptyText="全部">
                                </f:DropDownList>
                                <f:Button ID="btnSubmit" runat="server" Width="80px" OnClick="btnSubmit_Click" ValidateForms="SimpleForm1"
                                    Text="提交">
                                </f:Button>--%>
                            </Items>
                        </f:Toolbar>
                    </Toolbars>
                    <Columns>
                        <f:RowNumberField />
                        <f:RenderField ColumnID="ID" DataField="ID" HeaderText="ID" Hidden="True"></f:RenderField>
                        <f:RenderField ColumnID="设备名称" DataField="设备类型s" HeaderText="设备名称" Width="400px" Hidden="true"></f:RenderField>
                        <f:RenderField ColumnID="设备操作规程" DataField="设备操作规程" HeaderText="设备操作规程" ExpandUnusedSpace="true"></f:RenderField>
                        <f:RenderField ColumnID="新设备操作规程" DataField="新设备操作规程" HeaderText="新设备操作规程" Width="300px" Hidden="true"></f:RenderField>
                        <f:RenderField ColumnID="上传时间" DataField="上传时间" HeaderText="上传时间" Width="300px"></f:RenderField>
                        <f:RenderField ColumnID="文件类型" DataField="文件类型" HeaderText="文件类型" Hidden="true"></f:RenderField>
                        <f:LinkButtonField Width="160" CommandName="Action1" Text="查看详情" Icon="ApplicationGo" />
                        <f:LinkButtonField Width="160px" TextAlign="Center" EnableAjax="false" CommandName="Action2" Text="下载" />
                        <%--<f:LinkButtonField Width="160px" TextAlign="Center" Text="删除×" ConfirmText="确定要删除此文件吗？" ConfirmTarget="Top"
                            CommandName="Action3" />--%>
                    </Columns>
                </f:Grid>
                
                <f:Window ID="window1" Title="图片预览" runat="server" Hidden="true" EnableIFrame="false"
                    EnableMaximize="true" Target="Self" EnableResize="true" IsModal="true" Width="860px" Height="660px">
                    <Items>
                        <f:Image ID="image_1" runat="server" Margin="30px" ImageHeight="600px" ImageWidth="800px"></f:Image>
                    </Items>
                </f:Window>
            </Items>
        </f:Panel>
        <%-- 上传文件窗口 --%>
        <f:Window ID="Window2" Title="文件上传" Width="900px" Height="670px" AutoScroll="true" BodyPadding="20px" Hidden="true" runat="server">
            <Items>
                <f:Toolbar runat="server">
                    <Items>
                        <f:FileUpload runat="server" ID="filePhoto" Width="450px" EmptyText="请选择文件" Label="文件上传" Required="true" ButtonIcon="Add"
                            ShowRedStar="true">
                        </f:FileUpload>                       
                        <f:TwinTriggerBox  EmptyText="输入要搜索的关键词" ShowTrigger1="false" Trigger1Icon="Clear" Trigger2Icon="Search" OnTrigger2Click="tt_Search_Trigger2Click" ID="tt_Search" ShowLabel="false"  runat="server"></f:TwinTriggerBox>
                    </Items>
                </f:Toolbar>
                
                <f:Grid ID="Grid2" EnableCheckBoxSelect="true" IsFluid="true"  AutoSelectEditor="true" Height="500px" EnableMultiSelect="false" DataKeyNames="ID,设备类型"
                   EnableCollapse="false" ShowBorder="true" ShowHeader="true" OnRowClick="Grid2_RowClick"  EnableRowClickEvent="true" runat="server">
                    <Columns>
                        <f:RenderField ColumnID="ID" DataField="ID" HeaderText="ID"></f:RenderField>
                        <f:RenderField ColumnID="设备类型" TextAlign="Center" HeaderText="设备类型" DataField="设备类型" ExpandUnusedSpace="true"></f:RenderField>
                    </Columns>
                </f:Grid>             
            </Items>
            <Toolbars>
                <f:Toolbar  Position="Bottom" ToolbarAlign="Right" runat="server">
                    <Items>
                        <f:Button runat="server" Text="提交" RegionPosition="Right" OnClick="Unnamed_Click"></f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
        </f:Window>

    </form>
</body>
</html>
