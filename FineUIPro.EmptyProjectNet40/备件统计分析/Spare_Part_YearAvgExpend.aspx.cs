using FineUIPro;
using mydddd.Web.code;
using Newtonsoft.Json.Linq;
using PLM.BusinessRlues;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace mydddd.Web.Spare_Part_Analyze
{
    public partial class Spare_Part_YearAvgExpend : System.Web.UI.Page
    {

        备件统计分析BLL bll = new 备件统计分析BLL();
        protected void Page_Init(object sender, EventArgs e)
        {
            DateTime dtime = DateTime.Now;
            int a = Convert.ToInt32(dtime.ToString("yyyy"));
            int b = a - 2015;
            int c = 0;
            int d = a + 1;
            FineUIPro.BoundField bf;
            for (int i = 1; i <= b + 1; i++)
            {
                c = 2014 + i;
                bf = new FineUIPro.BoundField();
                bf.DataFormatString = "{0}";
                bf.SortField = "y" + c.ToString();
                bf.DataField = "y" + c.ToString();
                bf.HeaderText = c.ToString() + "年消耗";
                Grid1.Columns.Add(bf);

                bf = new FineUIPro.BoundField();
                bf.DataFormatString = "{0}";
                bf.SortField = "price" + c.ToString();
                bf.DataField = "price" + c.ToString();
                bf.HeaderText = c.ToString() + "总价";
                Grid1.Columns.Add(bf);

            }

            bf = new FineUIPro.BoundField();
            bf.DataFormatString = "{0}";
            bf.SortField = "新数量";
            bf.DataField = "新数量";
            bf.Width = 200;
            bf.HeaderText = d.ToString() + "年预计采购数量";
            Grid1.Columns.Add(bf);

            bf = new FineUIPro.BoundField();
            bf.DataFormatString = "{0}";
            bf.ColumnID= "新总价"; ;
            bf.SortField = "新总价";
            bf.DataField = "新总价";
            bf.Width = 250; 
            bf.HeaderText = "预计费用";
            Grid1.Columns.Add(bf);


            FineUIPro.WindowField wf = new FineUIPro.WindowField();
            wf.ColumnID = "ViewDeviceContent";
            wf.TextAlign = FineUIPro.TextAlign.Center;
            wf.Icon = FineUIPro.Icon.Pencil;
            wf.ToolTip = "预览";
            wf.HeaderText = "预览";
            wf.WindowID = "Window1";
            wf.Title = "预览设备类型";
            wf.DataIFrameUrlFields = "物料号";
            wf.DataIFrameUrlFormatString = "../备件统计分析/Spare_Part_DeviceContent.aspx?id={0}";
            Grid1.Columns.Add(wf);

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DeviceDropDownListBind();
                InitLoad();
            }
        }

        protected void DeviceDropDownListBind()
        {
            string Sql = @"select distinct 提报单位 from b_备件_导入日志表 order by 提报单位";
            DataSet ds = bll.返回DataSet(Sql);
            DataTable dt = ds.Tables[0];
            Company_Name.DataTextField = "提报单位";
            Company_Name.DataValueField = "提报单位";
            Company_Name.DataSource = dt;
            Company_Name.DataBind();
        }

        private void bind()
        {
            Grid1.PageSize = int.Parse(ddlPageSize.SelectedValue);
            string Company = Company_Name.SelectedValue;
            DateTime dtime = DateTime.Now;
            int a = Convert.ToInt32(dtime.ToString("yyyy"));
            int b = a - 2015;
            int c = 0;
            int lastyear = a - 1;
            string OrderbyStr= "LEN" + "(" + Grid1.SortField + ")" + " " + Grid1.SortDirection + "," + Grid1.SortField + " " + Grid1.SortDirection;
            StringBuilder Tiaojian1 = new StringBuilder();
            StringBuilder Tiaojian2 = new StringBuilder();
            StringBuilder Tiaojian3 = new StringBuilder();
            StringBuilder Tiaojian4 = new StringBuilder();
            StringBuilder Tiaojian5 = new StringBuilder();
            StringBuilder Tiaojian6 = new StringBuilder();
            StringBuilder Tiaojian7 = new StringBuilder();
            StringBuilder Tiaojian8 = new StringBuilder();
            Tiaojian8.AppendFormat("case when bc.y{0}>bc.y{1} THEN bc.y{0}*bc.newPrice ELSE bc.y{1}*bc.newPrice END AS 新总价,case when bc.y{0} > bc.y{1} THEN bc.y{0} ELSE bc.y{1} END AS 新数量", lastyear, a);

            string SpareNumContent = Spare_PartNum.Text.ToString();
            string SpareNameContent = Spare_PartName.Text.ToString();

            StringBuilder SpareNumsb = new StringBuilder();
            StringBuilder SpareNamesb = new StringBuilder();
            if (string.IsNullOrEmpty(SpareNumContent))
            {
                SpareNumsb.Append(" ");

            }
            else
            {
                SpareNumsb.AppendFormat("AND a.物料号 like '%{0}%'", SpareNumContent);
            }


            if (string.IsNullOrEmpty(SpareNameContent))
            {
                SpareNamesb.Append(" ");
            }
            else
            {
                SpareNamesb.AppendFormat("AND c.备件名称 like '%{0}%'", SpareNameContent);
            }


            string mohuContent_SpareNum = SpareNumsb.ToString();
            string mohuContent_SpareName = SpareNamesb.ToString();

            int year = 0;
            for (int k=0;k<=b;k++)
            {
                if (k==b)
                {
                    year = 2015 + k;
                    Tiaojian1.AppendFormat("{0}", "y"+year);
                    Tiaojian2.AppendFormat("ISNULL(sum(sa.{0}),0)", "y" + year);
                    Tiaojian3.AppendFormat("py.{0} as price{1}", "y" + year,year);
                    Tiaojian4.AppendFormat("ISNULL(sum(sa.{0}),0) as {0}", "y" + year);
                    Tiaojian5.AppendFormat("ypc.{0}", "price" + year);
                    Tiaojian6.AppendFormat("sum(ypc.price{0}) as {1}", year, "price" + year);
                    Tiaojian7.AppendFormat("ISNULL(sum(ypc.price{0}),0)", year);
                }
                else
                {
                    year = 2015 + k;
                    Tiaojian1.AppendFormat("{0},", "y" + year);
                    Tiaojian2.AppendFormat("ISNULL(sum(sa.{0}),0)+", "y" + year);
                    Tiaojian3.AppendFormat("py.{0} as price{1},", "y" + year,year);
                    Tiaojian4.AppendFormat("ISNULL(sum(sa.{0}),0) as {0},", "y" + year);
                    Tiaojian5.AppendFormat("ypc.{0},", "price" + year);
                    Tiaojian6.AppendFormat("sum(ypc.price{0}) as {1},", year, "price" + year);
                    Tiaojian7.AppendFormat("ISNULL(sum(ypc.price{0}),0)+", year);
                }
            }
            string StrWhere1 = Tiaojian1.ToString();
            string StrWhere2 = Tiaojian2.ToString();
            string StrWhere3 = Tiaojian3.ToString();
            string StrWhere4 = Tiaojian4.ToString();
            string StrWhere5 = Tiaojian5.ToString();
            string StrWhere6 = Tiaojian6.ToString();
            string StrWhere7 = Tiaojian7.ToString();
            string StrWhere8 = Tiaojian8.ToString();
           
            string Sql = @"WITH mytabCte AS (
         SELECT SUM(b.操作数量)  AS 总操作数量,
                a.价格,
                'y' + CONVERT(VARCHAR(50), YEAR(b.操作日期)) AS 年份,
                a.物料号,
                a.提报单位,
                c.备件名称,
                (
                    SELECT TOP 1 c.价格
                    FROM   b_备件_导入日志表 AS c
                    WHERE  c.物料号 = a.物料号
                    ORDER BY
                           c.[发料日期] DESC
                )            AS newPrice
         FROM   b_备件_导入日志表      a,
                b_备件_记录表        b,
                b_备件_信息表        c
         WHERE  a.ID = b.日志ID AND  a.物料号=c.物料号 "+ mohuContent_SpareNum + @" "+ mohuContent_SpareName + @"
                AND a.提报单位 = '" + Company+ @"'
                AND YEAR(b.操作日期) > 2014
         GROUP BY
                YEAR(b.操作日期),
                a.物料号,
                a.价格,
                a.提报单位,
                c.备件名称
     ),
     cte AS (
         SELECT YEAR(b.操作日期)     yearNum,
                b.操作数量 * a.价格 价格,
                a.物料号,
                a.提报单位,
                c.备件名称
         FROM   b_备件_导入日志表       a,
                b_备件_记录表         b,
                b_备件_信息表         c
         WHERE  a.ID = b.日志ID AND  a.物料号=c.物料号 " + mohuContent_SpareNum + @" " + mohuContent_SpareName + @"
                AND a.提报单位 = '" + Company+ @"'
                AND YEAR(b.操作日期) > 2014
     ),
     yearCte AS (
         SELECT SUM(价格) AS 总价格,
                'y' + CONVERT(VARCHAR(50), yearNum) AS 年份,
                物料号,
                提报单位,
                备件名称
         FROM   cte
         GROUP BY
                yearNum,
                物料号,
                提报单位,
                备件名称
     ),
     yearPIVOTCte AS (
         SELECT py.物料号,
                py.提报单位,
                py.备件名称,
                " + StrWhere3 + @"
         FROM   yearCte
                PIVOT(
                    SUM(yearCte.总价格) FOR yearCte.年份 IN (" + StrWhere1 + @")
                )         AS py
     ),
     baseCte AS (
         SELECT sa.物料号,
                sa.提报单位,
                 Convert(DECIMAL(13,2),(
                   " + StrWhere7 + @"
                ) / (
                   " + StrWhere2 + @"
                ) ) as newPrice,
                sa.备件名称,
                " + StrWhere4 + @",
                (
                   " + StrWhere2 + @"
                )                         AS 总操作数量,
                " + StrWhere6 + @",
                (
                   " + StrWhere7 + @"
                )                         AS 总价
         FROM   mytabCte
                PIVOT(
                    SUM(mytabCte.总操作数量) FOR mytabCte.年份 IN (" + StrWhere1 + @")
                )                         AS sa
                LEFT JOIN yearPIVOTCte ypc
                     ON  ypc.物料号 = sa.物料号
         GROUP BY
                sa.物料号,
                sa.newPrice,
                sa.提报单位,
                sa.备件名称
     )

SELECT bc.*," + StrWhere8+@"
	
FROM   baseCte AS bc
ORDER BY
       "+ OrderbyStr + "";

            
            
            DataSet ds = bll.返回DataSet(Sql);
            DataTable dt = ds.Tables[0];

            
           
            Grid1.DataSource = dt;
            Grid1.DataBind();

            double donateTotal = 0.00;
            double feeTotal = 0.00;
            foreach (DataRow row in dt.Rows)
            {
                donateTotal += Convert.ToDouble(row["总价"]);
                feeTotal+= Convert.ToDouble(row["新总价"]);
            }

            JObject summary = new JObject();

            summary.Add("总价", donateTotal.ToString("F2"));
            summary.Add("新总价", feeTotal.ToString("F2"));

            Grid1.SummaryData = summary;
            
        }

        #region gird常用方法

        //初始加载
        private void InitLoad()
        {
            bind();

        }




        //添加
        protected void Button_add_OnClick(object sender, EventArgs e)
        {
            //PageContext.RegisterStartupScript(
            //       Window1.GetShowReference("../UserManagement/AddJurisdiction.aspx", "添加"));

        }

        ////删除
        //protected void Button_delete_OnClick(object sender, EventArgs e)
        //{
        //    //string ids = GetDataKeysBySelectedRow(Grid1);
        //    //if (ids.Length == 0)
        //    //{
        //    //    NotifyWarning("请选择记录！");
        //    //    return;
        //    //}
        //    mydddd.BLL.sysAdmin bll = new mydddd.BLL.sysAdmin();
        //    bll.DeleteList(ids);
        //    bind();
        //}

        //每页显示数目
        protected void ddlPageSize_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            bind();
        }

        //分页事件
        protected void Grid1_OnPageIndexChange(object sender, GridPageEventArgs e)
        {
            Grid1.PageIndex = e.NewPageIndex;

            bind();
        }

        //排序事件
        protected void Grid1_OnSort(object sender, GridSortEventArgs e)
        {
            Grid1.SortDirection = e.SortDirection;
            Grid1.SortField = e.SortField;

            bind();
        }

        //重置搜索
        protected void ttbSearchMessage_OnTrigger1Click(object sender, EventArgs e)
        {
            //ttbSearchMessage.Text = String.Empty;
            //ttbSearchMessage.ShowTrigger1 = false;
            //DelPageState();
            //bind();
        }

        //搜索
        protected void ttbSearchMessage_OnTrigger2Click(object sender, EventArgs e)
        {
            //ttbSearchMessage.ShowTrigger1 = true;
            //DelPageState();
            //bind();
        }


        //页面重置
        protected void Button_Repage_OnClick(object sender, EventArgs e)
        {
            //DelPageState();
            //PageContext.Refresh();
        }

        //删除页面状态
        private void DelPageState()
        {
            //Grid1.PageIndex = 0;
            //Grid1.SortDirection = "";
            //Grid1.SortField = "id";
            //CookieHelper.DelCookie("page" + Request.PhysicalPath.Split('.')[0]);
        }
        #endregion

        protected void Button_delete_Click(object sender, EventArgs e)
        {

        }



        protected void Window1_Close(object sender, WindowCloseEventArgs e)
        {

        }



        #region 获取备件名称，就是物料名称
        public string GetSparePartName(string SpareNum)
        {
            string Sql = @"select 备件名称 from b_备件_信息表 where 物料号='" + SpareNum + "'";
            DataSet ds = bll.返回DataSet(Sql);
            DataTable dt = ds.Tables[0];
            string SpareName = dt.Rows[0]["备件名称"].ToString();
            return SpareName;
        }
        #endregion


        #region 获取物料单价
        public string GetPriceOfSpare(string SpareNum)
        {
            string Sql = @"select 价格 from b_备件_导入日志表 where 物料号='"+ SpareNum + "'";
            DataSet ds = bll.返回DataSet(Sql);
            DataTable dt = ds.Tables[0];
            string Spare_Price = dt.Rows[0]["价格"].ToString();
            return Spare_Price;
        }
        #endregion

        #region 获取物料总价
        public string GetTotalPriceSpare(string SpareNum,string TotalCount)
        {
            string Sql = @"select 价格 from b_备件_导入日志表 where 物料号 = '"+ SpareNum + "'";
            DataSet ds = bll.返回DataSet(Sql);
            DataTable dt = ds.Tables[0];
            double Spare_Price = Convert.ToDouble(dt.Rows[0]["价格"]);
            string TotalPrice = Math.Round(Convert.ToDouble(TotalCount) * Spare_Price, 2).ToString();
            return TotalPrice;
        }
        #endregion

        

        protected void Company_Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            bind();
        }
        #region 第一个列表导出到excel
        public override void VerifyRenderingInServerForm(Control control)
        {

        }

        protected void ExcelOutBtn_Click(object sender, EventArgs e)
        {
            string Company = Company_Name.SelectedValue;
            DateTime dtime = DateTime.Now;
            int a = Convert.ToInt32(dtime.ToString("yyyy"));
            int b = a - 2015;
            int c = 0;
            int lastyear = a - 1;

            
            StringBuilder Tiaojian1 = new StringBuilder();
            StringBuilder Tiaojian2 = new StringBuilder();
            StringBuilder Tiaojian3 = new StringBuilder();
            StringBuilder Tiaojian4 = new StringBuilder();
            StringBuilder Tiaojian5 = new StringBuilder();
            StringBuilder Tiaojian6 = new StringBuilder();
            StringBuilder Tiaojian7 = new StringBuilder();
            StringBuilder Tiaojian8 = new StringBuilder();
            Tiaojian8.AppendFormat("case when bc.y{0}>bc.y{1} THEN bc.y{0}*bc.newPrice ELSE bc.y{1}*bc.newPrice END AS 新总价,case when bc.y{0} > bc.y{1} THEN bc.y{0} ELSE bc.y{1} END AS 新数量", lastyear, a);

            int year = 0;
            for (int k = 0; k <= b; k++)
            {
                if (k == b)
                {
                    year = 2015 + k;
                    Tiaojian1.AppendFormat("{0}", "y" + year);
                    Tiaojian2.AppendFormat("ISNULL(sum(sa.{0}),0)", "y" + year);
                    Tiaojian3.AppendFormat("py.{0} as price{1}", "y" + year, year);
                    Tiaojian4.AppendFormat("ISNULL(sum(sa.{0}),0) as {0}", "y" + year);
                    Tiaojian5.AppendFormat("ypc.{0}", "price" + year);
                    Tiaojian6.AppendFormat("sum(ypc.price{0}) as {1}", year, "price" + year);
                    Tiaojian7.AppendFormat("ISNULL(sum(ypc.price{0}),0)", year);
                }
                else
                {
                    year = 2015 + k;
                    Tiaojian1.AppendFormat("{0},", "y" + year);
                    Tiaojian2.AppendFormat("ISNULL(sum(sa.{0}),0)+", "y" + year);
                    Tiaojian3.AppendFormat("py.{0} as price{1},", "y" + year, year);
                    Tiaojian4.AppendFormat("ISNULL(sum(sa.{0}),0) as {0},", "y" + year);
                    Tiaojian5.AppendFormat("ypc.{0},", "price" + year);
                    Tiaojian6.AppendFormat("sum(ypc.price{0}) as {1},", year, "price" + year);
                    Tiaojian7.AppendFormat("ISNULL(sum(ypc.price{0}),0)+", year);
                }
            }
            string StrWhere1 = Tiaojian1.ToString();
            string StrWhere2 = Tiaojian2.ToString();
            string StrWhere3 = Tiaojian3.ToString();
            string StrWhere4 = Tiaojian4.ToString();
            string StrWhere5 = Tiaojian5.ToString();
            string StrWhere6 = Tiaojian6.ToString();
            string StrWhere7 = Tiaojian7.ToString();
            string StrWhere8 = Tiaojian8.ToString();

            string Sql = @"WITH mytabCte AS (
         SELECT SUM(b.操作数量)  AS 总操作数量,
                a.价格,
                'y' + CONVERT(VARCHAR(50), YEAR(b.操作日期)) AS 年份,
                a.物料号,
                a.提报单位,
                c.备件名称,
                (
                    SELECT TOP 1 c.价格
                    FROM   b_备件_导入日志表 AS c
                    WHERE  c.物料号 = a.物料号
                    ORDER BY
                           c.[发料日期] DESC
                )            AS newPrice
         FROM   b_备件_导入日志表      a,
                b_备件_记录表        b,
                b_备件_信息表        c
         WHERE  a.ID = b.日志ID AND  a.物料号=c.物料号 
                AND a.提报单位 = '" + Company + @"'
                AND YEAR(b.操作日期) > 2014
         GROUP BY
                YEAR(b.操作日期),
                a.物料号,
                a.价格,
                a.提报单位,
                c.备件名称
     ),
     cte AS (
         SELECT YEAR(b.操作日期)     yearNum,
                b.操作数量 * a.价格 价格,
                a.物料号,
                a.提报单位,
                c.备件名称
         FROM   b_备件_导入日志表       a,
                b_备件_记录表         b,
                b_备件_信息表         c
         WHERE  a.ID = b.日志ID AND  a.物料号=c.物料号 
                AND a.提报单位 = '" + Company + @"'
                AND YEAR(b.操作日期) > 2014
     ),
     yearCte AS (
         SELECT SUM(价格) AS 总价格,
                'y' + CONVERT(VARCHAR(50), yearNum) AS 年份,
                物料号,
                提报单位,
                备件名称
         FROM   cte
         GROUP BY
                yearNum,
                物料号,
                提报单位,
                备件名称
     ),
     yearPIVOTCte AS (
         SELECT py.物料号,
                py.提报单位,
                py.备件名称,
                " + StrWhere3 + @"
         FROM   yearCte
                PIVOT(
                    SUM(yearCte.总价格) FOR yearCte.年份 IN (" + StrWhere1 + @")
                )         AS py
     ),
     baseCte AS (
         SELECT sa.物料号,
                sa.提报单位,
                Convert(DECIMAL(13,2),(
                   " + StrWhere7 + @"
                ) / (
                   " + StrWhere2 + @"
                ) ) as newPrice,
                sa.备件名称,
                " + StrWhere4 + @",
                (
                   " + StrWhere2 + @"
                )                         AS 总操作数量,
                " + StrWhere6 + @",
                (
                   " + StrWhere7 + @"
                )                         AS 总价
         FROM   mytabCte
                PIVOT(
                    SUM(mytabCte.总操作数量) FOR mytabCte.年份 IN (" + StrWhere1 + @")
                )                         AS sa
                LEFT JOIN yearPIVOTCte ypc
                     ON  ypc.物料号 = sa.物料号
         GROUP BY
                sa.物料号,
                sa.newPrice,
                sa.提报单位,
                sa.备件名称
     )

SELECT bc.*," + StrWhere8 + @"
	
FROM   baseCte AS bc
ORDER BY
       物料号";



            DataSet ds = bll.返回DataSet(Sql);
            DataTable dt = ds.Tables[0];

            NpoiHelper1.DownloadExcel(dt, NpoiHelper1.ExcelType.xls);
        }


        private string GetGridTableHtml(Grid grid)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("<meta http-equiv=\"content-type\" content=\"application/excel; charset=UTF-8\"/>");

            sb.Append("<table cellspacing=\"0\" rules=\"all\" border=\"1\" style=\"border-collapse:collapse;\">");

            sb.Append("<tr>");
            foreach (GridColumn column in grid.Columns)
            {
                sb.AppendFormat("<td>{0}</td>", column.HeaderText);
            }
            sb.Append("</tr>");


            foreach (GridRow row in grid.Rows)
            {
                sb.Append("<tr>");
                foreach (object value in row.Values)
                {
                    string html = value.ToString();
                    if (html.StartsWith(Grid.TEMPLATE_PLACEHOLDER_PREFIX))
                    {
                        // 模板列
                        string templateID = html.Substring(Grid.TEMPLATE_PLACEHOLDER_PREFIX.Length);
                        Control templateCtrl = row.FindControl(templateID);
                        html = GetRenderedHtmlSource(templateCtrl);
                    }
                    else
                    {
                        // 处理CheckBox
                        if (html.Contains("box-grid-static-checkbox"))
                        {
                            if (html.Contains("uncheck"))
                            {
                                html = "×";
                            }
                            else
                            {
                                html = "√";
                            }
                        }

                        // 处理图片
                        if (html.Contains("<img"))
                        {
                            string prefix = Request.Url.AbsoluteUri.Replace(Request.Url.AbsolutePath, "");
                            html = html.Replace("src=\"", "src=\"" + prefix);
                        }
                    }

                    sb.AppendFormat("<td>{0}</td>", html);
                }
                sb.Append("</tr>");
            }

            sb.Append("</table>");

            return sb.ToString();
        }

        /// <summary>
        /// 获取控件渲染后的HTML源代码
        /// 可能遇到的两个错误：
        /// 1. 控件必须放在具有 runat=server 的窗体标记内" - 添加重载方法 VerifyRenderingInServerForm
        /// 2. 只能在执行Render()的过程中调用RegisterForEventValidation” - 为页面添加声明 EnableEventValidation="false"
        /// </summary>
        /// <param name="ctrl"></param>
        /// <returns></returns>
        /// 
        private string GetRenderedHtmlSource(Control ctrl)
        {
            if (ctrl != null)
            {
                using (StringWriter sw = new StringWriter())
                {
                    using (HtmlTextWriter htw = new HtmlTextWriter(sw))
                    {
                        ctrl.RenderControl(htw);

                        return sw.ToString();
                    }
                }
            }
            return String.Empty;
        }
        #endregion

        protected void SelectContentBtn_Click(object sender, EventArgs e)
        {
            bind();
        }
    }
}