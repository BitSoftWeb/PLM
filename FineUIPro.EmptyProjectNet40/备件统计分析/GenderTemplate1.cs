using PLM.BusinessRlues;
using System;
using System.Data;
using System.Web.UI;
using AspNet = System.Web.UI.WebControls;

namespace mydddd.Web.Spare_Part_Analyze
{
    internal class GenderTemplate1 : ITemplate
    {
        备件统计分析BLL bll = new 备件统计分析BLL();
        public void InstantiateIn(Control container)
        {
            AspNet.Label labGender = new AspNet.Label();
            labGender.ID = "GenderItem";
            labGender.DataBinding += new EventHandler(labGender_DataBinding);
            container.Controls.Add(labGender);
        }


        private void labGender_DataBinding(object sender, EventArgs e)
        {
            AspNet.Label labGender = (AspNet.Label)sender;

            IDataItemContainer dataItemContainer = (IDataItemContainer)labGender.NamingContainer;
            
            string SpareNum = Convert.ToString(((DataRowView)dataItemContainer.DataItem)["物料号"]);
            string Company_Name = Convert.ToString(((DataRowView)dataItemContainer.DataItem)["提报单位"]);
            double price= Convert.ToDouble(((DataRowView)dataItemContainer.DataItem)["newPrice"]);
            DateTime dtime = DateTime.Now;
            int Last_Year = Convert.ToInt32(dtime.ToString("yyyy")) - 1;
            int Now_Year = Convert.ToInt32(dtime.ToString("yyyy"));
            //string Sql = @"select sum(ma.数量) as 总 from(select sum(操作数量) as 数量,设备编号,YEAR(操作日期) as 年份 from b_备件_记录表 where YEAR(操作日期)=" + Last_Year + " and 日志ID in (select ID from b_备件_导入日志表 where 物料号='"+ SpareNum + "' and 提报单位='"+Company_Name+"') group by 设备编号,YEAR(操作日期)) as ma";

            string Sql_lastYear = @"select  SUM(b.操作数量) as 总数量,b.设备相关名称  from b_备件_导入日志表 as a,b_备件_记录表 as b where a.ID=b.日志ID and a.物料号='" + SpareNum + "' and a.提报单位='" + Company_Name + "' and Year(b.操作日期)=" + Last_Year + " group by  b.设备相关名称";

            string Sql_NowYear = @"select  SUM(b.操作数量) as 总数量,b.设备相关名称  from b_备件_导入日志表 as a,b_备件_记录表 as b where a.ID=b.日志ID and a.物料号='" + SpareNum + "' and a.提报单位='" + Company_Name + "' and Year(b.操作日期)=" + Now_Year + " group by  b.设备相关名称";

            #region 查询名称为当前年的设备的投产时间小于当前年的设备
            //string Sql_Count_NowYear = @"select * from 设备_设备信息表 as sbtab,(select  SUM(b.操作数量) as 总数量,b.设备相关名称  from b_备件_导入日志表 as a,b_备件_记录表 as b where a.ID=b.日志ID and a.物料号='"+ SpareNum + "' and a.提报单位='"+Company_Name+"' and Year(b.操作日期)="+Now_Year+" group by  b.设备相关名称) as c where sbtab.设备名称 in(c.设备相关名称) and year(sbtab.投产时间)="+Now_Year+"";

            //string Sql_Count_LastYear = @"select * from 设备_设备信息表 as sbtab,(select  SUM(b.操作数量) as 总数量,b.设备相关名称  from b_备件_导入日志表 as a,b_备件_记录表 as b where a.ID=b.日志ID and a.物料号='" + SpareNum + "' and a.提报单位='" + Company_Name + "' and Year(b.操作日期)=" + Now_Year + " group by  b.设备相关名称) as c where sbtab.设备名称 in(c.设备相关名称) and year(sbtab.投产时间)<" + Now_Year + "";
            #endregion
            DataSet ds_lastYear = bll.返回DataSet(Sql_lastYear);
            DataTable dt_lastYear = ds_lastYear.Tables[0];

            DataSet ds_NowYear = bll.返回DataSet(Sql_NowYear);
            DataTable dt_NowYear = ds_NowYear.Tables[0];

            //DataSet ds_CountNowYear = BLL.DBControl.Query(Sql_Count_NowYear);
            //DataTable dt_CountNowYear = ds_CountNowYear.Tables[0];

            //DataSet ds_CountLastYear = BLL.DBControl.Query(Sql_Count_LastYear);
            //DataTable dt_CountLastYear = ds_CountLastYear.Tables[0];

            int lasttotal = 0;
            int NowToral = 0;
            int allTotal = 0;
            double TotalPrice = 0;
            if (dt_NowYear.Rows.Count - dt_lastYear.Rows.Count > 0)
            {
                for (int i = 0; i < dt_lastYear.Rows.Count; i++)
                {
                    lasttotal += Convert.ToInt32(dt_lastYear.Rows[i]["总数量"]);
                }

                for (int n = 0; n < dt_NowYear.Rows.Count; n++)
                {
                    NowToral += Convert.ToInt32(dt_NowYear.Rows[n]["总数量"]);
                }
                double avgcount = Math.Round(Convert.ToDouble(NowToral / dt_NowYear.Rows.Count), 0);
                allTotal = lasttotal + Convert.ToInt32(avgcount) * (dt_NowYear.Rows.Count - dt_lastYear.Rows.Count);
                TotalPrice = Math.Round(allTotal * price, 2);
            }
            else if (dt_NowYear.Rows.Count - dt_lastYear.Rows.Count == 0)
            {
                for (int i = 0; i < dt_lastYear.Rows.Count; i++)
                {
                    lasttotal += Convert.ToInt32(dt_lastYear.Rows[i]["总数量"]);
                }
                allTotal = lasttotal;
                TotalPrice = Math.Round(allTotal * price, 2);
            }
            else
            {
                for (int i = 0; i < dt_lastYear.Rows.Count; i++)
                {
                    lasttotal += Convert.ToInt32(dt_lastYear.Rows[i]["总数量"]);
                }
                allTotal = lasttotal;
                TotalPrice = Math.Round(allTotal * price, 2);
            }
            labGender.Text = TotalPrice.ToString();
        }
    }
}