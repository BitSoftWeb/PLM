<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Spare_Part_CompanyPrice.aspx.cs" Inherits="mydddd.Web.Spare_Part_Analyze.Spare_Part_CompanyPrice" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <script src="../echarts/echarts.min.js"></script>
    <title></title>
    <style>
        .mypanel {
            display: inline-block;
            margin-right: 5px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PangeManager1" AutoSizePanelID="Panel1" runat="server" AjaxLoadingType="Mask" />
        <f:Panel ID="Panel1" IsFluid="true" CssClass="blockpanel" runat="server" ShowBorder="true" EnableCollapse="false" BodyPadding="10px" ShowHeader="true" Title="维修人员分析" AutoScroll="true" Margin="20px">
            <Items>
                <f:Panel ID="Repair_BreakDown_Hour" runat="server" Title="维修某类故障时长" CssClass="mypanel" Width="800px" Height="400px" BodyPadding="10px" ShowHeader="false" ShowBorder="false">
                    <Items>
                        <f:Form ID="Repair_BreakDown_Form" runat="server" ShowBorder="false" ShowHeader="false">
                            <Items>
                                <f:FormRow runat="server" ColumnWidths="50%">
                                    <Items>
                                        <f:DropDownList ID="Year_Num" runat="server" Label="年份" LabelWidth="50px" OnSelectedIndexChanged="Year_Num_SelectedIndexChanged" AutoPostBack="true"></f:DropDownList>
                                        <f:Button ID="Button1" runat="server" Text="详细数据" Icon="Accept" OnClientClick="OpenButton1()"></f:Button>
                                    </Items>
                                </f:FormRow>
                            </Items>
                        </f:Form>
                        <f:ContentPanel ID="Repair_BreakDown_ContentPanel" runat="server" ShowBorder="false" ShowHeader="false">
                            <div id="Part1_tab" style="width: 750px; height: 300px"></div>
                        </f:ContentPanel>
                    </Items>
                </f:Panel>
                <f:Panel ID="Use_SpareMax" runat="server" Title="同一备件消耗峰值" CssClass="mypanel" Width="800px" Height="400px" BodyPadding="10px" ShowHeader="false" ShowBorder="false">
                    <Items>
                        <f:Form ID="User_SpareMax_Form" runat="server" ShowBorder="false" ShowHeader="false">
                            <Items>
                                <f:FormRow runat="server" ColumnWidths="50%">
                                    <Items>
                                        <f:DropDownList ID="Year_NumOfCount" runat="server" Label="年份" LabelWidth="50px" OnSelectedIndexChanged="Year_NumOfCount_SelectedIndexChanged" AutoPostBack="true"></f:DropDownList>
                                    </Items>
                                </f:FormRow>
                            </Items>
                        </f:Form>
                        <f:ContentPanel ID="Spare_Part_YearNumOfCountContentPanel" runat="server" ShowBorder="false" ShowHeader="false">
                            <div id="Part2_tab" style="width: 750px; height: 300px"></div>
                        </f:ContentPanel>
                    </Items>
                </f:Panel>
            </Items>
        </f:Panel>
    </form>
</body>
</html>
<script type="text/javascript">
    function RepairPeopleHour(Xdata, Ydata) {
        var myChart = echarts.init(document.getElementById('Part1_tab'));
        option = {
            title: {
                text: '车间年消耗总价'
            },
            color: ['#3398DB'],
            tooltip: {
                trigger: 'axis',
                axisPointer: {            // 坐标轴指示器，坐标轴触发有效
                    type: 'shadow'        // 默认为直线，可选为：'line' | 'shadow'
                }
            },
            dataZoom: {
                show: true,
                type: 'slider',
                height: 25,
                bottom: -15,
                textStyle: false,
                start: 0,
                end: 100
            },
            xAxis: [
                {
                    type: 'category',
                    data: Xdata,
                    axisLabel: {//坐标轴刻度标签的相关设置。
                        interval: 0,
                        rotate: "30"
                    },
                    axisTick: {
                        alignWithLabel: true
                    }
                }
            ],
            yAxis: {
                type: 'value'
            },
            series: [{
                data: Ydata,
                type: 'bar',
                barWidth: '25'
            }]
        };
        myChart.setOption(option);
    }
</script>

<script type="text/javascript">
    function SpareTotalCountOfCompany(Xdata, Ydata) {
        var myChart1 = echarts.init(document.getElementById('Part2_tab'));
        option1 = {
            title: {
                text: '车间年消耗数量'
            },
            color: ['#3398DB'],
            tooltip: {
                trigger: 'axis',
                axisPointer: {            // 坐标轴指示器，坐标轴触发有效
                    type: 'shadow'        // 默认为直线，可选为：'line' | 'shadow'
                }
            },
            dataZoom: {
                show: true,
                type: 'slider',
                height: 25,
                bottom: -15,
                textStyle: false,
                start: 0,
                end: 100
            },
            xAxis: [
                {
                    type: 'category',
                    data: Xdata,
                    axisLabel: {//坐标轴刻度标签的相关设置。
                        interval: 0,
                        rotate: "30"
                    },
                    axisTick: {
                        alignWithLabel: true
                    }
                }
            ],
            yAxis: {
                type: 'value'
            },
            series: [{
                data: Ydata,
                type: 'bar',
                barWidth: '25'
            }]
        };
        myChart1.setOption(option1);
    }
</script>

<script type="text/javascript">
    function OpenButton1() {
        var bt = F('<%=Year_Num.ClientID%>').getValue();
        parent.addExampleTab({
            id: 'hello_fineui_tab',
            iframeUrl: '../备件统计分析/Spare_Part_CompanyPriceData.aspx?time=' + bt + '',
            title: '详细数据',
            icon: 'res/icon/page_white_wrench.png',
            refreshWhenExist: true
        });
    }
</script>
