using FineUIPro;
using PLM.BusinessRlues;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace mydddd.Web.Spare_Part_Analyze
{
    
    public partial class Spare_Part_CompanyPrice : System.Web.UI.Page
    {
        备件统计分析BLL bll = new 备件统计分析BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                YearBind();
                CountYearBind();
                ChartBind();
                TotalCountChartBind();
            }
        }

        #region 年份绑定
        protected void YearBind()
        {
            DateTime dtime = DateTime.Now;
            int a = Convert.ToInt32(dtime.ToString("yyyy"));
            int b = a - 2015;
            DataTable dt = new DataTable();
            dt.Columns.Add("年份", typeof(string));
            DataRow dr;
            int c = 2015;
            for(int i=0;i<= b;i++)
            {
                c += i;
                dr = dt.NewRow();
                dr["年份"] = c.ToString();
                dt.Rows.Add(dr);
                c = 2015;
            }
            Year_Num.DataTextField = "年份";
            Year_Num.DataValueField = "年份";
            Year_Num.DataSource = dt;
            Year_Num.DataBind();
        }
        #endregion


        #region 数量的年份绑定
        protected void CountYearBind()
        {
            DateTime dtime = DateTime.Now;
            int a = Convert.ToInt32(dtime.ToString("yyyy"));
            int b = a - 2015;
            DataTable dt = new DataTable();
            dt.Columns.Add("年份", typeof(string));
            DataRow dr;
            int c = 2015;
            for (int i = 0; i <= b; i++)
            {
                c += i;
                dr = dt.NewRow();
                dr["年份"] = c.ToString();
                dt.Rows.Add(dr);
                c = 2015;
            }
            Year_NumOfCount.DataTextField = "年份";
            Year_NumOfCount.DataValueField = "年份";
            Year_NumOfCount.DataSource = dt;
            Year_NumOfCount.DataBind();
        }
        #endregion


        #region 车间价钱总和图标初始化
        protected void ChartBind()
        {
            //string time = Year_Time.SelectedDate.ToString();
            //DateTime dtime = Convert.ToDateTime(Year_Time.SelectedDate);
            int a = Convert.ToInt32(Year_Num.SelectedValue);
            string Sql = @"select SUM(b.总价) as 总价,a.提报单位 from  b_备件_导入日志表 as a, b_备件_记录表 as b where a.ID=b.日志ID and YEAR(b.操作日期)="+ a + " group by a.提报单位";
            DataSet ds = bll.返回DataSet(Sql);
            DataTable dt = ds.Tables[0];
            StringBuilder Xdata = new StringBuilder();
            StringBuilder Ydata = new StringBuilder();
            StringBuilder Totaljs = new StringBuilder();
            Xdata.Append("[");
            Ydata.Append("[");
            for (int i=0;i<dt.Rows.Count;i++)
            {
                if (i == dt.Rows.Count - 1)
                {
                    if (string.IsNullOrEmpty(dt.Rows[i]["提报单位"].ToString()))
                    {
                        Xdata.AppendFormat("'{0}'", "");
                    }
                    else
                    {
                        Xdata.AppendFormat("'{0}'", dt.Rows[i]["提报单位"]);
                    }

                    if (string.IsNullOrEmpty(dt.Rows[i]["总价"].ToString()))
                    {
                        Ydata.AppendFormat("'{0}'", "");
                    }
                    else
                    {
                        Ydata.AppendFormat("'{0}'", dt.Rows[i]["总价"]);
                    }

                }
                else
                {
                    if (string.IsNullOrEmpty(dt.Rows[i]["提报单位"].ToString()))
                    {
                        Xdata.AppendFormat("'{0}',", "");
                    }
                    else
                    {
                        Xdata.AppendFormat("'{0}',", dt.Rows[i]["提报单位"]);
                    }

                    if (string.IsNullOrEmpty(dt.Rows[i]["总价"].ToString()))
                    {
                        Ydata.AppendFormat("'{0}',", "");
                    }
                    else
                    {
                        Ydata.AppendFormat("'{0}',", dt.Rows[i]["总价"]);
                    }
                }
            }
            Xdata.Append("]");
            Ydata.Append("]");
            Totaljs.AppendFormat("RepairPeopleHour({0},{1});",Xdata,Ydata);
            PageContext.RegisterStartupScript(Totaljs.ToString());
        }
        #endregion

        #region 车间金额时间联动

        protected void Year_Num_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChartBind();
        }
        #endregion


        #region 车间数量总和图初始化
        protected void TotalCountChartBind()
        {
            int a = Convert.ToInt32(Year_NumOfCount.SelectedValue);
            string Sql = @"select SUM(b.操作数量) as 总数,a.提报单位 from  b_备件_导入日志表 as a, b_备件_记录表 as b where a.ID=b.日志ID and YEAR(b.操作日期)="+a+" group by a.提报单位 order by 总数 desc";
            DataSet ds = bll.返回DataSet(Sql);
            DataTable dt = ds.Tables[0];
            StringBuilder Xdata = new StringBuilder();
            StringBuilder Ydata = new StringBuilder();
            StringBuilder Totaljs = new StringBuilder();
            Xdata.Append("[");
            Ydata.Append("[");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (i == dt.Rows.Count - 1)
                {
                    if (string.IsNullOrEmpty(dt.Rows[i]["提报单位"].ToString()))
                    {
                        Xdata.AppendFormat("'{0}'", "");
                    }
                    else
                    {
                        Xdata.AppendFormat("'{0}'", dt.Rows[i]["提报单位"]);
                    }

                    if (string.IsNullOrEmpty(dt.Rows[i]["总数"].ToString()))
                    {
                        Ydata.AppendFormat("'{0}'", "");
                    }
                    else
                    {
                        Ydata.AppendFormat("'{0}'", dt.Rows[i]["总数"]);
                    }

                }
                else
                {
                    if (string.IsNullOrEmpty(dt.Rows[i]["提报单位"].ToString()))
                    {
                        Xdata.AppendFormat("'{0}',", "");
                    }
                    else
                    {
                        Xdata.AppendFormat("'{0}',", dt.Rows[i]["提报单位"]);
                    }

                    if (string.IsNullOrEmpty(dt.Rows[i]["总数"].ToString()))
                    {
                        Ydata.AppendFormat("'{0}',", "");
                    }
                    else
                    {
                        Ydata.AppendFormat("'{0}',", dt.Rows[i]["总数"]);
                    }
                }
            }
            Xdata.Append("]");
            Ydata.Append("]");
            Totaljs.AppendFormat("SpareTotalCountOfCompany({0},{1});", Xdata, Ydata);
            PageContext.RegisterStartupScript(Totaljs.ToString());
        }

        protected void Year_NumOfCount_SelectedIndexChanged(object sender, EventArgs e)
        {
            TotalCountChartBind();
        }
        #endregion

        //protected void Year_Time_DateSelect(object sender, EventArgs e)
        //{
        //    ChartBind();
        //}
    }
}