<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="设备统计分析.aspx.cs" Inherits="FineUIPro.EmptyProjectNet40.设备统计分析" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" runat="server" />
    <meta name="Generator" content="EditPlus®" runat="server" />
    <meta name="Author" content="" runat="server" />
    <meta name="Keywords" content="" runat="server" />
    <meta name="Description" content="" runat="server" />
    <style type="text/css" runat="server">
        body {
            background-size: 100% 100%;
            font-weight: bold;
            font-family: 苹方;
            overflow: hidden;
            background: linear-gradient(-45deg, #17213e, #000000, #006970, #007c5f);
            background-size: 400% 400%;
            animation: gradientBG 15s ease infinite;
        }

        @keyframes gradientBG {
            0% {
                background-position: 0% 50%;
            }

            50% {
                background-position: 100% 50%;
            }

            100% {
                background-position: 0% 50%;
            }
        }

        .main {
            width: 1024px;
            height: 768px;
            position: relative;
            margin: auto;
        }

        div {
            border: 0px solid white;
            margin: 1px;
        }

        .layer {
            position: relative;
            width: 100%;
        }

        #layer01 {
        }

            #layer01 img {
                text-align: center;
                display: block;
                height: 35px;
                padding-top: 35px;
                margin: auto;
            }

        #layer02 > div {
            height: 100%;
            float: left;
            position: relative;
        }

        .layer02-data {
            position: absolute;
            width: auto;
            height: 100px;
            color: white;
            top: 45px;
            left: 65px;
        }

        .layer03-panel {
            height: 100%;
            position: relative;
            float: left;
        }

        .layer03-left-label {
            position: absolute;
        }

        #layer03_left_label01 {
            top: 10px;
            left: 10px;
            color: white;
            height: 20px;
            width: 200px;
            font-weight: bold;
        }

        #layer03_left_label02 {
            right: 10px;
            top: 10px;
            color: #036769;
            height: 20px;
            width: 200px;
        }

        .layer03-left-chart {
            position: relative;
            float: left;
            height: 100%;
        }

        #layer03_right_label {
            position: absolute;
            top: 10px;
            left: 10px;
            color: white;
            height: 20px;
            width: 100px;
        }

        .layer03-right-chart {
            position: relative;
            float: left;
            height: 100%;
            width: 32%;
        }

        .layer03-right-chart-label {
            color: white;
            text-align: center;
            position: absolute;
            bottom: 60px;
            width: 100%;
        }

        .layer04-panel {
            position: relative;
            float: left;
            height: 100%;
            width: 48%;
        }

        .layer04-panel-label {
            width: 100%;
            height: 15%;
            color: white;
            padding-top: 5px;
        }

        .layer04-panel-chart {
            width: 100%;
            height: 85%;
        }
    </style>
    <script src="../res/js/sy/jquery.min.js"></script>
    <script src="../res/js/sy/echarts.min.js"></script>
    <%--  <script src="monitor.js"></script>--%>
    <script type="text/javascript">
        $(function () {

            //alert(1);




            drawLayer02Label($("#layer02_01 canvas").get(0), "设备总数", 80, 200);
            drawLayer02Label($("#layer02_02 canvas").get(0), "故障总数", 80, 300);
            drawLayer02Label($("#layer02_03 canvas").get(0), "定保小修总数", 80, 400);
            drawLayer02Label($("#layer02_04 canvas").get(0), "委外维修总数", 50, 200);
            drawLayer02Label($("#layer02_05 canvas").get(0), "设备工程总数", 40, 200);
            //drawLayer02Label($("#layer02_06 canvas").get(0), "当前集群数", 50, 200);

            renderLegend();

            //饼状图
            renderChartBar01();
            //renderChartBar02();

            //存储
            renderLayer03Right();

            //30天日均线流量趋势
            //renderLayer04Left();

            ////集群性能
            //renderLayer04Right();
        });
    </script>
    <title>设备统计分析</title>
</head>
<body onload="load();">

    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="Panel7" runat="server" />
        <asp:Label ID="设备总数" runat="server" Text="Label"></asp:Label>
        <asp:Label ID="故障总数" runat="server" Text="Label"></asp:Label>
        <asp:Label ID="高速故障总数" runat="server" Text="Label"></asp:Label>
        <asp:Label ID="内饰件故障总数" runat="server" Text="Label"></asp:Label>
        <asp:Label ID="冲压件分公司" runat="server" Text="Label"></asp:Label>
        <asp:Label ID="客车制造中心" runat="server" Text="Label"></asp:Label>
        <asp:Label ID="转向架组制造中心" runat="server" Text="Label"></asp:Label>
        <asp:Label ID="动力厂" runat="server" Text="Label"></asp:Label>
        <f:DropDownList ID="二级单位" Width="300px" runat="server"  AutoPostBack="true" AutoSelectFirstItem="false"  EmptyText="非精准数据">
        </f:DropDownList>
    </form>

    <div class="main">

        <div id="layer02" class="layer" style="height: 15%;">
            <div id="layer02_01" style="width: 20%;">
                <div class="layer02-data">
                    <span id="span1" style="font-size: 26px;"></span>

                    <span style="font-size: 16px;">台</span>
                </div>
                <canvas width="200" height="100"></canvas>
            </div>
            <div id="layer02_02" style="width: 20%;">
                <div class="layer02-data">
                    <span id="span2" style="font-size: 26px;"></span>
                    <span style="font-size: 16px;">台</span>
                </div>
                <canvas width="200" height="100"></canvas>
            </div>
            <div id="layer02_03" style="width: 21%;">
                <div class="layer02-data">
                    <span style="font-size: 26px;">30</span>
                    <span style="font-size: 16px;">台</span>
                </div>
                <canvas width="200" height="100"></canvas>
            </div>
            <div id="layer02_04" style="width: 12%;">
                <div class="layer02-data">
                    <span style="font-size: 26px;">32</span>
                    <span style="font-size: 16px;">台</span>
                </div>
                <canvas width="120" height="100"></canvas>
            </div>
            <div id="layer02_05" style="width: 12%;">
                <div class="layer02-data">
                    <span style="font-size: 26px;">25</span>
                    <span style="font-size: 16px;">台</span>
                </div>
                <canvas width="120" height="100"></canvas>
            </div>
            <%--      <div id="layer02_06" style="width: 12%;">
                <div class="layer02-data">
                    <span style="font-size: 26px;">5</span>
                    <span style="font-size: 16px;">个</span>
                </div>
                <canvas width="120" height="100"></canvas>
            </div>--%>
        </div>
        <div id="layer03" class="layer" style="height: 40%;">
            <div id="layer03_left" style="width: 48%;" class="layer03-panel">
                <div id="layer03_left_label01" class="layer03-left-label">当前年份故障次数占比</div>
                <!--
				<div id="layer03_left_label02" class="layer03-left-label">(左)在线数量 (右)上线率</div>
				-->
                <div id="layer03_left_01" class="layer03-left-chart" style="width: 16%;">
                    <canvas width="100" height="200" style="margin: 30px 0 0 20px;"></canvas>
                </div>

                <div id="layer03_left_02" class="layer03-left-chart" style="width: 80%;"></div>
                <!--
				<div id="layer03_left_03" class="layer03-left-chart" style="width:80%;"></div>
				-->
            </div>
            <div id="layer03_right" style="width: 50%;" class="layer03-panel">
                <div id="layer03_right_label">存储</div>
                <div id="layer03_right_chart01" class="layer03-right-chart">
                    <canvas width="130" height="150" style="margin: 40px 0 0 20px;"></canvas>
                    <div class="layer03-right-chart-label">故障占比</div>
                </div>
                <div id="layer03_right_chart02" class="layer03-right-chart">
                    <canvas width="130" height="150" style="margin: 40px 0 0 20px;"></canvas>
                    <div class="layer03-right-chart-label">定保小修占比</div>
                </div>
                <div id="layer03_right_chart03" class="layer03-right-chart">
                    <canvas width="130" height="150" style="margin: 40px 0 0 20px;"></canvas>
                    <div class="layer03-right-chart-label">委外工程占比</div>
                </div>
            </div>
        </div>
        <%--    <div id="layer04" class="layer" style="height: 30%;">
            <div id="layer04_left" class="layer04-panel">
                <div id="layer04_left_label" class="layer04-panel-label">30天日均线流量趋势</div>
                <div id="layer04_left_chart" class="layer04-panel-chart"></div>
            </div>
            <div id="layer04_right" class="layer04-panel">
                <div id="layer04_right_label" class="layer04-panel-label">
                    <span>集群性能/</span><span style="color: #00A09A;">近一个小时</span>
                </div>
                <div id="layer04_right_chart" class="layer04-panel-chart"></div>
            </div>
        </div>--%>
    </div>
    <script>

        function load() {

            var value = $("#设备总数").html().trim();
            document.getElementById('span1').innerText = value;

            var value1 = $("#故障总数").html().trim();
            document.getElementById('span2').innerText = value1;
            document.getElementById("<%= 设备总数.ClientID %>").style.display = "none";//隐藏lable
            document.getElementById("<%= 故障总数.ClientID %>").style.display = "none";//隐藏lable

        }

        function drawLayer02Label(canvasObj, text, textBeginX, lineEndX) {
            var colorValue = '#04918B';

            var ctx = canvasObj.getContext("2d");

            ctx.beginPath();
            ctx.arc(35, 55, 2, 0, 2 * Math.PI);
            ctx.closePath();
            ctx.fillStyle = colorValue;
            ctx.fill();

            ctx.moveTo(35, 55);
            ctx.lineTo(60, 80);
            ctx.lineTo(lineEndX, 80);
            ctx.lineWidth = 1;
            ctx.strokeStyle = colorValue;
            ctx.stroke();

            ctx.font = '12px Georgia';
            ctx.fillStyle = colorValue;
            ctx.fillText(text, textBeginX, 92);
        }

        //接入机型占比

        var COLOR = {
            MACHINE: {
                TYPE_A: '#0175EE',
                TYPE_B: '#D89446',
                TYPE_C: '#9370DB',
                TYPE_D: '#25AE4F',
                TYPE_E: '#06B5C6',
                TYPE_F: '#009E9A',
                TYPE_G: '#AC266F',
                //TYPE_H: '#AC246F'
            }
        };

        function renderLegend() {
            <%--var lab = document.getElementById("<%= .ClientID %>").innerText;--%>
            drawLegend(COLOR.MACHINE.TYPE_A, 30, '高速动车组制造中心');
            drawLegend(COLOR.MACHINE.TYPE_B, 60, '内饰件分公司');
            drawLegend(COLOR.MACHINE.TYPE_C, 90, '冲压件分公司');
            drawLegend(COLOR.MACHINE.TYPE_D, 120, '客车制造中心');
            drawLegend(COLOR.MACHINE.TYPE_E, 150, '转向架组制造中心');
            drawLegend(COLOR.MACHINE.TYPE_F, 180, '动力厂');
            //drawLegend(COLOR.MACHINE.TYPE_G, 175, 'G机型');
            //drawLegend(COLOR.MACHINE.TYPE_H, 175, 'G机型');
        }

        function drawLegend(pointColor, pointY, text) {
            var ctx = $("#layer03_left_01 canvas").get(0).getContext("2d");
            ctx.beginPath();
            ctx.arc(20, pointY, 6, 0, 2 * Math.PI);
            ctx.fillStyle = pointColor;
            ctx.fill();
            ctx.font = '20px';
            ctx.fillStyle = '#FEFFFE';
            ctx.fillText(text, 40, pointY + 3);
        }


        //存储
        function renderLayer03Right() {
            drawLayer03Right($("#layer03_right_chart01 canvas").get(0), "#027825", 0.20);
            drawLayer03Right($("#layer03_right_chart02 canvas").get(0), "#006DD6", 0.15);
            drawLayer03Right($("#layer03_right_chart03 canvas").get(0), "#238681", 0.8);
        }

        function drawLayer03Right(canvasObj, colorValue, rate) {
            var ctx = canvasObj.getContext("2d");

            var circle = {
                x: 65,    //圆心的x轴坐标值
                y: 80,    //圆心的y轴坐标值
                r: 60      //圆的半径
            };

            //画扇形
            //ctx.sector(circle.x,circle.y,circle.r,1.5*Math.PI,(1.5+rate*2)*Math.PI);
            //ctx.fillStyle = colorValue;
            //ctx.fill();

            ctx.beginPath();
            ctx.arc(circle.x, circle.y, circle.r, 0, Math.PI * 2)
            ctx.lineWidth = 10;
            ctx.strokeStyle = '#052639';
            ctx.stroke();
            ctx.closePath();

            ctx.beginPath();
            ctx.arc(circle.x, circle.y, circle.r, 1.5 * Math.PI, (1.5 + rate * 2) * Math.PI)
            ctx.lineWidth = 10;
            ctx.lineCap = 'round';
            ctx.strokeStyle = colorValue;
            ctx.stroke();
            ctx.closePath();

            ctx.fillStyle = 'white';
            ctx.font = '20px Calibri';
            ctx.fillText(rate * 100 + '%', circle.x - 15, circle.y + 10);

        }


        function renderChartBar01() {
            //var ss = 123456;
            var 高速故障总数 = $("#高速故障总数").html().trim();
            var 内饰件故障总数 = $("#内饰件故障总数").html().trim();
            var 冲压件分公司 = $("#冲压件分公司").html().trim();
            var 客车制造中心 = $("#客车制造中心").html().trim();
            var 转向架组制造中心 = $("#转向架组制造中心").html().trim();
            var 动力厂 = $("#动力厂").html().trim();

            document.getElementById("<%= 高速故障总数.ClientID %>").style.display = "none";//隐藏lable
            document.getElementById("<%= 内饰件故障总数.ClientID %>").style.display = "none";//隐藏lable
            document.getElementById("<%= 冲压件分公司.ClientID %>").style.display = "none";//隐藏lable
            document.getElementById("<%= 客车制造中心.ClientID %>").style.display = "none";//隐藏lable
            document.getElementById("<%= 转向架组制造中心.ClientID %>").style.display = "none";//隐藏lable
            document.getElementById("<%= 动力厂.ClientID %>").style.display = "none";//隐藏lable
            var myChart = echarts.init(document.getElementById("layer03_left_02"));
            myChart.setOption(
                         {
                             title: {
                                 text: '',
                                 subtext: '',
                                 x: 'center'
                             },
                             tooltip: {
                                 trigger: 'item',
                                 formatter: "{b} : {c} ({d}%)"
                             },
                             legend: {
                                 show: false,
                                 x: 'center',
                                 y: 'bottom',
                                 data: ['高速动车组制造中心', '内饰件分公司', '冲压件分公司', '客车制造中心', '转向架组制造中心', '动力厂']
                             },
                             toolbox: {
                             },
                             label: {
                                 normal: {
                                     show: true,
                                     formatter: "{b} \n{d}%"
                                 }
                             },
                             calculable: true,
                             color: [COLOR.MACHINE.TYPE_A, COLOR.MACHINE.TYPE_B, COLOR.MACHINE.TYPE_C, COLOR.MACHINE.TYPE_D, COLOR.MACHINE.TYPE_E, COLOR.MACHINE.TYPE_F, COLOR.MACHINE.TYPE_G],

                             series: [
                                 {
                                     name: '',
                                     type: 'pie',
                                     radius: [40, 80],
                                     center: ['50%', '50%'],
                                     //roseType : 'area',
                                     data: [
                                         { value: 高速故障总数, name: '高速动车组制造中心' },
                                         { value: 内饰件故障总数, name: '内饰件分公司' },
                                         { value: 冲压件分公司, name: '冲压件分公司' },
                                         { value: 客车制造中心, name: '客车制造中心' },
                                         { value: 转向架组制造中心, name: '转向架组制造中心' },
                                         { value: 动力厂, name: '动力厂' },
                                         //{ value: 3500, name: 'G机型' }
                                     ]
                                 }
                             ]
                         }
            );

        }

        /*
        function renderChartBar02(){
            var myChart = echarts.init(document.getElementById("layer03_left_03"));
                myChart.setOption(
                            {
                                title : {
                                    text: '',
                                    subtext: '',
                                    x:'center'
                                },
                                tooltip : {
                                    show:true,
                                    trigger: 'item',
                                    formatter: "上线率<br>{b} : {c} ({d}%)"
                                },
                                legend: {
                                    show:false,
                                    orient: 'vertical',
                                    left: 'left',
                                    data: ['A机型','B机型','C机型','D机型','E机型','F机型','G机型']
                                },
                                series : [
                                    {
                                        name: '',
                                        type: 'pie',
                                        radius : '50%',
                                        center: ['50%', '60%'],
                                        data:[
                                            {value:7600, name:'A机型'},
                                            {value:6600, name:'B机型'},
                                            {value:15600, name:'C机型'},
                                            {value:5700, name:'D机型'},
                                            {value:4600, name:'E机型'},
                                            {value:4600, name:'F机型'},
                                            {value:3500, name:'G机型'}
                                        ],
                                        itemStyle: {
                                            emphasis: {
                                                shadowBlur: 10,
                                                shadowOffsetX: 0,
                                                shadowColor: 'rgba(0, 0, 0, 0.5)'
                                            }
                                        }
                                    }
                                ],
                                color:[COLOR.MACHINE.TYPE_A,COLOR.MACHINE.TYPE_B,COLOR.MACHINE.TYPE_C,COLOR.MACHINE.TYPE_D,COLOR.MACHINE.TYPE_E,COLOR.MACHINE.TYPE_F,COLOR.MACHINE.TYPE_G]
                            }
                );
        }*/

        function renderLayer04Left() {
            var myChart = echarts.init(document.getElementById("layer04_left_chart"));
            myChart.setOption(
                {
                    title: {
                        text: ''
                    },
                    tooltip: {
                        trigger: 'axis'
                    },
                    legend: {
                        data: []
                    },
                    grid: {
                        left: '3%',
                        right: '4%',
                        bottom: '5%',
                        top: '4%',
                        containLabel: true
                    },
                    xAxis:
                    {
                        type: 'category',
                        boundaryGap: false,
                        data: getLatestDays(31),
                        axisLabel: {
                            textStyle: {
                                color: "white", //刻度颜色
                                fontSize: 8  //刻度大小
                            },
                            rotate: 45,
                            interval: 2
                        },
                        axisTick: { show: false },
                        axisLine: {
                            show: true,
                            lineStyle: {
                                color: '#0B3148',
                                width: 1,
                                type: 'solid'
                            }
                        }
                    },
                    yAxis:
                    {
                        type: 'value',
                        axisTick: { show: false },
                        axisLabel: {
                            textStyle: {
                                color: "white", //刻度颜色
                                fontSize: 8  //刻度大小
                            }
                        },
                        axisLine: {
                            show: true,
                            lineStyle: {
                                color: '#0B3148',
                                width: 1,
                                type: 'solid'
                            }
                        },
                        splitLine: {
                            show: false
                        }
                    },
                    tooltip: {
                        formatter: '{c}',
                        backgroundColor: '#FE8501'
                    },
                    series: [
                        {
                            name: '',
                            type: 'line',
                            smooth: true,
                            areaStyle: {
                                normal: {
                                    color: new echarts.graphic.LinearGradient(0, 0, 0, 1, [{ offset: 0, color: '#026B6F' }, { offset: 1, color: '#012138' }], false),
                                    opacity: 0.2
                                }
                            },
                            itemStyle: {
                                normal: {
                                    color: '#009991'
                                },
                                lineStyle: {
                                    normal: {
                                        color: '#009895',
                                        opacity: 1
                                    }
                                }
                            },
                            symbol: 'none',
                            data: [48, 52, 45, 46, 89, 120, 110, 100, 88, 96, 88, 45, 78, 67, 89, 103, 104, 56, 45, 104, 112, 132, 120, 110, 89, 95, 90, 89, 102, 110, 110]
                        }
                    ]
                }

            );
        }

        function renderLayer04Right() {
            var myChart = echarts.init(document.getElementById("layer04_right_chart"));
            myChart.setOption({
                title: {
                    text: ''
                },
                tooltip: {
                    trigger: 'axis'
                },
                legend: {
                    top: 20,
                    right: 5,
                    textStyle: {
                        color: 'white'
                    },
                    orient: 'vertical',
                    data: [
                            { name: '网络', icon: 'circle' },
                            { name: '内存', icon: 'circle' },
                            { name: 'CPU', icon: 'circle' }
                    ]
                },
                grid: {
                    left: '3%',
                    right: '16%',
                    bottom: '3%',
                    top: '3%',
                    containLabel: true
                },
                xAxis: {
                    type: 'category',
                    boundaryGap: false,
                    axisTick: { show: false },
                    axisLabel: {
                        textStyle: {
                            color: "white", //刻度颜色
                            fontSize: 8  //刻度大小
                        }
                    },
                    axisLine: {
                        show: true,
                        lineStyle: {
                            color: '#0B3148',
                            width: 1,
                            type: 'solid'
                        }
                    },
                    data: get10MinutesScale()
                },
                yAxis: {
                    type: 'value',
                    axisTick: { show: false },
                    axisLabel: {
                        textStyle: {
                            color: "white", //刻度颜色
                            fontSize: 8  //刻度大小
                        }
                    },
                    axisLine: {
                        show: true,
                        lineStyle: {
                            color: '#0B3148',
                            width: 1,
                            type: 'solid'
                        }
                    },
                    splitLine: {
                        show: false
                    }
                },
                series: [
                            {
                                name: '网络',
                                type: 'line',
                                itemStyle: {
                                    normal: {
                                        color: '#F3891B'
                                    },
                                    lineStyle: {
                                        normal: {
                                            color: '#F3891B',
                                            opacity: 1
                                        }
                                    }
                                },
                                data: [120, 132, 101, 134, 90, 230, 210]
                            },
                            {
                                name: '内存',
                                type: 'line',
                                itemStyle: {
                                    normal: {
                                        color: '#006AD4'
                                    },
                                    lineStyle: {
                                        normal: {
                                            color: '#F3891B',
                                            opacity: 1
                                        }
                                    }
                                },
                                data: [220, 182, 191, 234, 290, 330, 310]
                            },
                            {
                                name: 'CPU',
                                type: 'line',
                                itemStyle: {
                                    normal: {
                                        color: '#009895'
                                    },
                                    lineStyle: {
                                        normal: {
                                            color: '#009895',
                                            opacity: 1
                                        }
                                    }
                                },
                                data: [150, 232, 201, 154, 190, 330, 410]
                            }
                ]
            }
            );
        }

        function get10MinutesScale() {
            var currDate = new Date();
            var odd = currDate.getMinutes() % 10;
            var returnArr = new Array();
            currDate.setMinutes(currDate.getMinutes() - odd);
            for (var i = 0; i < 7; i++) {
                returnArr.push(currDate.getHours() + ":" + (currDate.getMinutes() < 10 ? ("0" + currDate.getMinutes()) : currDate.getMinutes()));
                currDate.setMinutes(currDate.getMinutes() - 10);
            }
            return returnArr;
        }


        function getLatestDays(num) {
            var currentDay = new Date();
            var returnDays = [];
            for (var i = 0 ; i < num ; i++) {
                currentDay.setDate(currentDay.getDate() - 1);
                returnDays.push((currentDay.getMonth() + 1) + "/" + currentDay.getDate());
            }
            return returnDays;
        }
    </script>
</body>

</html>
