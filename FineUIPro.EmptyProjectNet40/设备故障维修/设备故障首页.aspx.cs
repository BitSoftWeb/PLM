using PLM.BusinessRlues;
using PLM_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FineUIPro.EmptyProjectNet40.设备故障维修
{
    public partial class 设备故障首页 : System.Web.UI.Page
    {
        设备故障BLL gzbll = new 设备故障BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)//是否是客户端回发而加载
            {
                

                //绑定树
                LoadData();
                DateTime dt = DateTime.Now;
                Grid1.DataSource = gzbll.按各单位查询设备故障(0, "", "", "", dt.Year);
                Grid1.DataBind();
            }
        }

        private void LoadData()
        {
            //绑定单位
            List<用户单位表> list = gzbll.查询二级单位();
            二级单位.DataTextField = "名称";
            二级单位.DataValueField = "ID";
            二级单位.DataSource = list;
            二级单位.DataBind();
            二级单位.EmptyText = "全部";
        }


        protected void Grid1_RowCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Action1")
            {
                //ID,完成情况,设备编号,设备名称,故障描述,故障时间,解决故障时间,更换备件,问题描述,问题的可能影响,修理费用,报修人,维修人,名称,维修人数,维修工时,维修人员名单,原因分析,开始维修时间,解决方案及计划,解决故障根本问题的办法
                object[] keys = Grid1.DataKeys[e.RowIndex];
                完成情况.Text = keys[1].ToString();
                设备编号.Text = keys[2].ToString();
                设备名称.Text = keys[3].ToString();
                故障描述.Text = keys[4].ToString();
                故障时间.Text = keys[5].ToString();
                if (keys[6] == null)
                {
                    解决故障时间.Text = "";
                }
                else
                {
                    解决故障时间.Text = keys[6].ToString();
                }
                if (keys[7] == null)
                {
                    更换备件.Text = "";
                }
                else
                {
                    更换备件.Text = keys[7].ToString();
                }

                if (keys[8] == null)
                {
                    问题描述.Text = "";
                }
                else
                {
                    问题描述.Text = keys[8].ToString();
                }

                if (keys[9] == null)
                {
                    问题的可能影响.Text = "";
                }
                else
                {
                    问题的可能影响.Text = keys[9].ToString();
                }
                if (keys[10] == null)
                {
                    修理费用.Text = "";
                }
                else
                {
                    修理费用.Text = keys[10].ToString();
                }

                if (keys[11] == null)
                {
                    报修人.Text = "";
                }
                else
                {
                    报修人.Text = keys[11].ToString();
                }
                if (keys[12] == null)
                {
                    维修人.Text = "";
                }
                else
                {
                    维修人.Text = keys[12].ToString();
                }
                if (keys[13] == null)
                {
                    所属单位.Text = "";
                }
                else
                {
                    所属单位.Text = keys[13].ToString();
                }
                if (keys[14] == null)
                {
                    维修人数.Text = "";
                }
                else
                {
                    维修人数.Text = keys[14].ToString();
                }
                if (keys[15] == null)
                {
                    维修工时.Text = "";
                }
                else
                {
                    维修工时.Text = keys[15].ToString();
                }
                if (keys[16] == null)
                {
                    维修人员名单.Text = "";
                }
                else
                {
                    维修人员名单.Text = keys[16].ToString();
                }
                if (keys[17] == null)
                {
                    原因分析.Text = "";
                }
                else
                {
                    原因分析.Text = keys[17].ToString();
                }
                if (keys[18] == null)
                {
                    开始维修时间.Text = "";
                }
                else
                {
                    开始维修时间.Text = keys[18].ToString();
                }
                if (keys[19] == null)
                {
                    解决方案及计划.Text = "";
                }
                else
                {
                    解决方案及计划.Text = keys[19].ToString();
                }
                if (keys[20] == null)
                {
                    解决故障根本问题的办法.Text = "";
                }
                else
                {
                    解决故障根本问题的办法.Text = keys[20].ToString();
                }
                Window1.Hidden = false;
            }
        }

        protected void SelectContentBtn_Click(object sender, EventArgs e)
        {
            string 起始日期 = "";
            string 截止日期 = "";
            try
            {
                起始日期 = DatePicker1.SelectedDate.Value.ToString("yyyy-MM-dd");
                截止日期 = DatePicker2.SelectedDate.Value.ToString("yyyy-MM-dd");
                DateTime dt1 = Convert.ToDateTime(起始日期);
                DateTime dt2 = Convert.ToDateTime(截止日期);
                if (dt2 < dt1)
                {
                    Alert.ShowInTop("截止日期不能小于起始日期！", MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception)
            {
                起始日期 = "";
                截止日期 = "";

            }
            int year = 0;
            if (年份.SelectedText == "")
            {
                DateTime dt = DateTime.Now;
                year = dt.Year;
            }
            else
            {
                year = int.Parse(年份.SelectedText);
            }
            int ID = Convert.ToInt32(二级单位.SelectedValue);
            Grid1.DataSource = gzbll.按各单位查询设备故障(ID, 起始日期, 截止日期, ttbSearch.Text, year);
            Grid1.DataBind();

        }

        protected void 二级单位_SelectedIndexChanged(object sender, EventArgs e)
        {
            string 起始日期 = "";
            string 截止日期 = "";
            try
            {
                起始日期 = DatePicker1.SelectedDate.Value.ToString("yyyy-MM-dd");
                截止日期 = DatePicker2.SelectedDate.Value.ToString("yyyy-MM-dd");
            }
            catch (Exception)
            {
                起始日期 = "";
                截止日期 = "";

            }
            int ID = Convert.ToInt32(二级单位.SelectedValue);
            int year = 0;
            if (年份.SelectedText == "" || 年份.SelectedText == null)
            {
                DateTime dt = DateTime.Now;
                year = dt.Year;
            }
            else
            {
                year = int.Parse(年份.SelectedText);
            }
            Grid1.DataSource = gzbll.按各单位查询设备故障(ID, 起始日期, 截止日期, ttbSearch.Text, year);
            Grid1.DataBind();

        }

        protected void Grid1_RowDataBound(object sender, GridRowEventArgs e)
        {
            DataRowView row = e.DataItem as DataRowView;

            // 入学年份
            string yen = row["完成情况"].ToString();
            BoundField cyen = Grid1.FindColumn("完成情况") as BoundField;
            if (yen == "正在进行")
            {
                e.CellAttributes[cyen.ColumnIndex]["data-color"] = "color3";
            }
            else if (yen == "完成")
            {
                e.CellAttributes[cyen.ColumnIndex]["data-color"] = "color2";
            }


            // 性别
            //int gender = Convert.ToInt32(row["Gender"]);
            //TemplateField cGender = Grid1.FindColumn("cGender") as TemplateField;
            //if (gender == 1)
            //{
            //    e.CellAttributes[cGender.ColumnIndex]["data-color"] = "color1";
            //}
        }

    }
}