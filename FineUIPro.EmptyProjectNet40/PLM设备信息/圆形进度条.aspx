<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="圆形进度条.aspx.cs" Inherits="FineUIPro.EmptyProjectNet40.PLM设备信息.圆形进度条" %>

<html lang="zh">
<head>
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>基于SVG的轻量级js圆形进度条插件</title>
    <link rel="stylesheet" type="text/css" href="..res/css/normalize.css" />
    <link rel="stylesheet" type="text/css" href="../res/css/default.css" />
    <style>
        #canvas .circle {
            display: inline-block;
            margin: 1em;
        }

        .circles-decimals {
            font-size: .4em;
        }
    </style>
    <!--[if IE]>
		<script src="http://libs.baidu.com/html5shiv/3.7/html5shiv.min.js"></script>
	<![endif]-->
</head>
<body>
    <article class="htmleaf-container">
        <header class="htmleaf-header">

            <div class="htmleaf-demo center">
                <a href="index.html" class="current">基本例子</a>
                <a href="index2.html">响应式</a>
                <a href="index3.html">Viewport</a>
            </div>
        </header>
        <div id="canvas">
            <div class="circle" id="circles-1"></div>
            <div class="circle" id="circles-2"></div>
            <div class="circle" id="circles-3"></div>
            <div class="circle" id="circles-4"></div>
            <div class="circle" id="circles-5"></div>
            <br />
            <button id="add_button">Value +10</button>
            <button id="substract_button">Value -10</button>
            <button id="add_width_button">Width +10</button>
            <button id="substract_width_button">Width -10</button>
            <button id="colors_button">Swap colors</button>
        </div>

    </article>

    <script src="../res/js/circles.min.js"></script>
    <script>
        //@ http://jsfromhell.com/array/shuffle [v1.0]
        function shuffle(o) { //v1.0
            for (var j, x, i = o.length; i; j = Math.floor(Math.random() * i), x = o[--i], o[i] = o[j], o[j] = x);
            return o;
        }

        var colors = [
			['#D3B6C6', '#4B253A'], ['#FCE6A4', '#EFB917'], ['#BEE3F7', '#45AEEA'], ['#F8F9B6', '#D2D558'], ['#F4BCBF', '#D43A43']
        ], circles = [];

        for (var i = 1; i <= 5; i++) {
            var child = document.getElementById('circles-' + i),
				percentage = 600;

            circles.push(Circles.create({
                id: child.id,
                value: percentage,
                radius: 60,
                width: 10,
                colors: colors[i - 1]
            }));
        }

        document.getElementById('add_button').onclick = function () {
            for (var i = 0, l = circles.length; i < l; i++)
                circles[i].update(circles[i]._value + 10, 250);
        };

        document.getElementById('substract_button').onclick = function () {
            for (var i = 0, l = circles.length; i < l; i++)
                circles[i].update(circles[i]._value - 10, 250);
        };

        document.getElementById('add_width_button').onclick = function () {
            for (var i = 0, l = circles.length; i < l; i++)
                circles[i].updateWidth(circles[i]._strokeWidth + 10);
        };

        document.getElementById('substract_width_button').onclick = function () {
            for (var i = 0, l = circles.length; i < l; i++)
                circles[i].updateWidth(circles[i]._strokeWidth - 10);
        };

        document.getElementById('colors_button').onclick = function () {
            colors = shuffle(colors);
            for (var i = 0, l = circles.length; i < l; i++)
                circles[i].updateColors(colors[i]);
        };
    </script>
</body>
</html>
