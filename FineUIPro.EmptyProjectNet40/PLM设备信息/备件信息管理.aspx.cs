using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PLM.BusinessRlues;
using PLM_BusinessRlues;
using PLM_Model;
using PLM_SQLDAL;

namespace FineUIPro.EmptyProjectNet40.PLM设备信息
{
    public partial class 备件信息管理 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //DD3Bind();
                BrindDorpDownList();
                KC_BindGrid();
                BL_列表选择();
                JL_BrindDorpDownList();
                JL_BindGrid();
                RZ_BrindDorpDownList();
                RZ_BindGrid();

            }
        }
        #region 备件库存信息
        private void KC_BindGrid()
        {
            //1.设置总项数
            备件信息管理BLL bll = new 备件信息管理BLL();
            BJ_KC_Grid.RecordCount = bll.GetRecordCount(tt().ToString());
            // 2.获取当前分页数据
            DataTable table = KC_GetPagedDataTable(BJ_KC_Grid.PageIndex, BJ_KC_Grid.PageSize);

            // 3.绑定到Grid
            BJ_KC_Grid.DataSource = table;
            BJ_KC_Grid.DataBind();
            Money();
        }


        /// <summary>
        /// 分页方法
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        private DataTable KC_GetPagedDataTable(int pageIndex, int pageSize)
        {
            备件信息管理BLL bll = new 备件信息管理BLL();
            int pageStar = pageIndex * pageSize;
            int pageEnd = (pageIndex + 1) * pageSize;
            //获取前端排序方式和排序系列
            string sortField = BJ_KC_Grid.SortField;
            string sortDirection = BJ_KC_Grid.SortDirection;

            DataTable table = bll.GetListByPage11(pageStar, pageEnd, tt().ToString()).Tables[0];
            DataView view1 = table.DefaultView;
            view1.Sort = String.Format("{0} {1}", sortField, sortDirection);
            BJ_KC_Grid.DataSource = view1;
            return view1.ToTable();
        }


        //管理类别、提报单位下拉列表初始化
        private void BrindDorpDownList()
        {
            备件信息管理BLL bll = new 备件信息管理BLL();
            DataSet ds = bll.GetList1("b." + BJ_KC_管理类别.Label);
            DataSet ds1 = bll.GetList1("a." + BJ_KC_提报单位.Label);
            DataTable dt = ds.Tables[0];
            DataTable dt1 = ds1.Tables[0];
            BJ_KC_管理类别.DataTextField = "管理类别";
            BJ_KC_管理类别.DataValueField = "管理类别";
            BJ_KC_管理类别.DataSource = dt;
            BJ_KC_管理类别.DataBind();
            BJ_KC_管理类别.Items.Insert(0, new FineUIPro.ListItem("全部", "全部"));
            BJ_KC_管理类别.Items[0].Selected = true;
            BJ_KC_提报单位.DataTextField = "提报单位";
            BJ_KC_提报单位.DataValueField = "提报单位";
            BJ_KC_提报单位.DataSource = dt1;
            BJ_KC_提报单位.DataBind();
            BJ_KC_提报单位.Items.Insert(0, new FineUIPro.ListItem("全部", "全部"));
            BJ_KC_提报单位.Items[0].Selected = true;
            DateTime time = DateTime.Now;
            BJ_KC_EndDate.SelectedDate = time;
        }

        //protected void DD3Bind()
        //{
        //    DateTime dt = DateTime.Now;
        //    BJ_KC_EndDate.SelectedDate = dt;

        //    备件信息管理BLL bll = new 备件信息管理BLL();
        //    DataSet ds = bll.GetList1("a." + BJ_KC_TC_提报单位.Label);
        //    DataTable table = ds.Tables[0];
        //    BJ_KC_TC_提报单位.DataTextField = "提报单位";
        //    BJ_KC_TC_提报单位.DataValueField = "提报单位";
        //    BJ_KC_TC_提报单位.DataSource = table;
        //    BJ_KC_TC_提报单位.DataBind();
        //    BJ_KC_TC_提报单位.Items.Insert(0, new FineUIPro.ListItem("全部", "全部"));
        //    BJ_KC_TC_提报单位.Items[0].Selected = true;
        //}



        private StringBuilder tt()
        {
            StringBuilder strWhere = new StringBuilder();
            if (BJ_KC_管理类别.SelectedValue == "全部")
            {
                strWhere.Append("1=1 ");
            }
            else
            {
                strWhere.Append("b.管理类别='" + BJ_KC_管理类别.SelectedValue + "'");
            }

            if (BJ_KC_提报单位.SelectedValue == "全部")
            {
                strWhere.Append(" and 1=1 ");
            }
            else
            {
                strWhere.Append(" and a.提报单位='" + BJ_KC_提报单位.SelectedValue + "'");
            }

            if (BJ_KC_TC_物料号.Text == "")
            {
                strWhere.Append(" and 1=1 ");
            }
            else
            {
                strWhere.Append(" and a.物料号 like '%" + BJ_KC_TC_物料号.Text + "%'");
            }
            if (BJ_KC_TC_物料名称.Text == "")
            {
                strWhere.Append(" and 1=1 ");
            }
            else
            {
                strWhere.Append(" and b.备件名称 like '%" + BJ_KC_TC_物料名称.Text + "%'");
            }
            
            return strWhere;
        }



        protected void BJ_KC_Grid_PageIndexChange(object sender, GridPageEventArgs e)
        {
            BJ_KC_Grid.PageIndex = e.NewPageIndex;
            KC_BindGrid();
        }

        protected void BJ_KC_条件筛选_Click(object sender, EventArgs e)
        {
            BJ_KC_筛选弹窗.Hidden = false;
        }

        protected void BJ_KC_btnSure_Click(object sender, EventArgs e)
        {
            BJ_KC_筛选弹窗.Hidden = true;
            //BJ_KC_提报单位.Text = BJ_KC_TC_提报单位.SelectedValue;
            KC_BindGrid();

        }

        protected void BJ_KC_btnCancel_Click(object sender, EventArgs e)
        {
            BJ_KC_筛选弹窗.Hidden = true;
        }

        protected void BJ_KC_清除筛选_Click(object sender, EventArgs e)
        {
            BJ_KC_TC_物料号.Text = "";
            BJ_KC_TC_物料名称.Text = "";
            BJ_KC_管理类别.Items[0].Selected = true;
            BJ_KC_提报单位.Items[0].Selected = true;
            //BJ_KC_TC_提报单位.Items[0].Selected = true;
            KC_BindGrid();
        }

        //总金额
        protected void Money()
        {
            备件信息管理BLL bll = new 备件信息管理BLL();
            //string strWhere = BJ_KC_TC_提报单位.SelectedValue;
            double aa = Convert.ToDouble(bll.GetMoney(tt().ToString()));
            if (aa / 100000000 >= 1)
            {
                double z = Math.Floor(aa / 100000000);
                double a = Math.Round(aa - (z * 100000000), 2);
                double x = Math.Floor(a / 10000);
                double c = x * 10000;
                double b = Math.Round(a - c, 2);
                string xx = "￥" + z + "亿" + x + "万" + b + "元";
                BJ_KC_金额.Text = xx;
            }
            else
            {
                if (aa / 10000 >= 1)
                {
                    double z = Math.Floor(aa / 10000);
                    double c = z * 10000;
                    double b = Math.Round(aa - c, 2);
                    string x = "￥" + z + "万" + b + "元";
                    BJ_KC_金额.Text = x;
                }
                else
                {
                    BJ_KC_金额.Text = "￥" + Convert.ToDouble(bll.GetMoney(tt().ToString())).ToString() + "元";
                }

            }


        }

        protected void BJ_KC_管理类别_SelectedIndexChanged(object sender, EventArgs e)
        {
            KC_BindGrid();
        }

        protected void BJ_KC_提报单位_SelectedIndexChanged(object sender, EventArgs e)
        {
            KC_BindGrid();
        }

        #endregion
        #region 列表选择
        protected void BJ_备件信息管理_SelectedIndexChanged(object sender, EventArgs e)
        {
            BL_列表选择();
        }

        private void BL_列表选择()
        {
            if (BJ_信息表选择.SelectedValue == "备件库存信息")
            {
                BJ_KC_Grid.Hidden = false;
                BJ_JL_Grid.Hidden = true;
                BJ_RZ_Grid.Hidden = true;
            }
            else
            {
                if (BJ_信息表选择.SelectedValue == "备件发放记录")
                {
                    BJ_KC_Grid.Hidden = true;
                    BJ_JL_Grid.Hidden = false;
                    BJ_RZ_Grid.Hidden = true;

                }
                else
                {
                    BJ_KC_Grid.Hidden = true;
                    BJ_JL_Grid.Hidden = true;
                    BJ_RZ_Grid.Hidden = false;
                }
            }
        }
        #endregion

        #region 备件记录表
        private void JL_BindGrid()
        {
            //1.设置总项数
            备件信息管理BLL bll = new 备件信息管理BLL();
            BJ_JL_Grid.RecordCount = bll.JL_PageCount(rr().ToString());
            // 2.获取当前分页数据
            DataTable table = JL_GetPagedDataTable(BJ_JL_Grid.PageIndex, BJ_JL_Grid.PageSize);

            // 3.绑定到Grid
            BJ_JL_Grid.DataSource = table;
            BJ_JL_Grid.DataBind();
            JL_Money();
        }


        private DataTable JL_GetPagedDataTable(int pageIndex, int pageSize)
        {
            备件信息管理BLL bll = new 备件信息管理BLL();
            int pageStar = pageIndex * pageSize;
            int pageEnd = (pageIndex + 1) * pageSize;
            //获取前端排序方式和排序系列
            string sortField = BJ_JL_Grid.SortField;
            string sortDirection = BJ_JL_Grid.SortDirection;

            DataTable table = bll.JL_GetListPage(pageStar, pageEnd, rr().ToString()).Tables[0];
            DataView view1 = table.DefaultView;
            view1.Sort = String.Format("{0} {1}", sortField, sortDirection);
            BJ_JL_Grid.DataSource = view1;
            return view1.ToTable();
        }


        private void JL_BrindDorpDownList()
        {
            备件信息管理BLL bll = new 备件信息管理BLL();
            DataSet ds1 = bll.GetList1("a." + BJ_JL_提报单位.Label);
            DataTable dt1 = ds1.Tables[0];
            BJ_JL_提报单位.DataTextField = "提报单位";
            BJ_JL_提报单位.DataValueField = "提报单位";
            BJ_JL_提报单位.DataSource = dt1;
            BJ_JL_提报单位.DataBind();
            BJ_JL_提报单位.Items.Insert(0, new FineUIPro.ListItem("全部", "全部"));
            BJ_JL_提报单位.Items[0].Selected = true;
            DateTime time = DateTime.Now;
            JL_EndDate.SelectedDate = time;
        }

        protected void JL_TC_RadioButtonList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (JL_RadioButtonList.SelectedValue == "不限")
            {
                JL_StarDate.Enabled = false;
                JL_EndDate.Enabled = false;
            }
            else
            {
                JL_StarDate.Enabled = true;
                JL_EndDate.Enabled = true;
            }
        }

        private StringBuilder rr()
        {
            StringBuilder strWhere = new StringBuilder();

            if (BJ_JL_提报单位.SelectedValue == "全部")
            {
                strWhere.Append("  1=1 ");
            }
            else
            {
                strWhere.Append("  a.提报单位='" + BJ_JL_提报单位.SelectedValue + "'");
            }



            if (JL_TC_物料号.Text == "")
            {
                strWhere.Append(" and 1=1 ");
            }
            else
            {
                strWhere.Append(" and a.物料号 like '%" + JL_TC_物料号.Text + "%'");
            }
            if (JL_TC_物料名称.Text == "")
            {
                strWhere.Append(" and 1=1 ");
            }
            else
            {
                strWhere.Append(" and b.备件名称 like '%" + JL_TC_物料名称.Text + "%'");
            }
            if (JL_RadioButtonList.SelectedValue == "不限")
            {
                strWhere.Append(" and 1=1 ");
            }
            else
            {
                if (JL_RadioButtonList.SelectedValue == "以到库时间")
                {
                    strWhere.Append(" and a.发料日期 between '" + JL_StarDate.Text + "' and '" + JL_EndDate.Text + "'");
                }
                else
                {
                    strWhere.Append(" and c.操作日期 between '" + JL_StarDate.Text + "' and '" + JL_EndDate.Text + "'");
                }
            }

            return strWhere;
        }

        protected void BJ_JL_提报单位_SelectedIndexChanged(object sender, EventArgs e)
        {
            JL_BindGrid();
        }

        protected void BJ_JL_Grid_PageIndexChange(object sender, GridPageEventArgs e)
        {
            BJ_JL_Grid.PageIndex = e.NewPageIndex;
            JL_BindGrid();
        }

        protected void BJ_JL_条件筛选_Click(object sender, EventArgs e)
        {
            BJ_JL_筛选弹窗.Hidden = false;
        }

        protected void BuBJ_JL_清除筛选_Click(object sender, EventArgs e)
        {
            JL_TC_物料号.Text = "";
            JL_TC_物料名称.Text = "";
            BJ_JL_提报单位.Items[0].Selected = true;
            //BJ_KC_TC_提报单位.Items[0].Selected = true;
            JL_StarDate.Text = "2015-01-01";
            DateTime time = DateTime.Now;
            JL_EndDate.Text = time.ToString();
            JL_BindGrid();
        }


        protected void JL_TC_确定筛选_Click(object sender, EventArgs e)
        {
            BJ_JL_筛选弹窗.Hidden = true;
            JL_BindGrid();
        }

        protected void JL_TC_取消_Click(object sender, EventArgs e)
        {
            BJ_JL_筛选弹窗.Hidden = true;
        }


        private void JL_Money()
        {
            备件信息管理BLL bll = new 备件信息管理BLL();
            double aa = Convert.ToDouble(bll.JL_GetMoney(rr().ToString()));
            if (aa / 100000000 >= 1)
            {
                double z = Math.Floor(aa / 100000000);
                double a = Math.Round(aa - (z * 100000000), 2);
                double x = Math.Floor(a / 10000);
                double c = x * 10000;
                double b = Math.Round(a - c, 2);
                string xx = "￥" + z + "亿" + x + "万" + b + "元";
                BJ_JL_金额.Text = xx;
            }
            else
            {
                if (aa / 10000 >= 1)
                {
                    double z = Math.Floor(aa / 10000);
                    double c = z * 10000;
                    double b = Math.Round(aa - c, 2);
                    string x = "￥" + z + "万" + b + "元";
                    BJ_JL_金额.Text = x;
                }
                else
                {
                    BJ_JL_金额.Text = "￥" + Convert.ToDouble(bll.GetMoney(rr().ToString())).ToString() + "元";
                }

            }
        }
        #endregion
        #region 备件日志表
        private void RZ_BindGrid()
        {
            //1.设置总项数
            备件信息管理BLL bll = new 备件信息管理BLL();
            BJ_RZ_Grid.RecordCount = bll.RZ_GetCountPage(jj().ToString());
            // 2.获取当前分页数据
            DataTable table = RZ_GetPagedDataTable(BJ_RZ_Grid.PageIndex, BJ_RZ_Grid.PageSize);

            // 3.绑定到Grid
            BJ_RZ_Grid.DataSource = table;
            BJ_RZ_Grid.DataBind();
            RZ_Money();
        }


        private DataTable RZ_GetPagedDataTable(int pageIndex, int pageSize)
        {
            备件信息管理BLL bll = new 备件信息管理BLL();
            int pageStar = pageIndex * pageSize;
            int pageEnd = (pageIndex + 1) * pageSize;
            //获取前端排序方式和排序系列
            string sortField = BJ_RZ_Grid.SortField;
            string sortDirection = BJ_RZ_Grid.SortDirection;

            DataTable table = bll.RZ_GetPage(pageStar, pageEnd, jj().ToString()).Tables[0];
            DataView view1 = table.DefaultView;
            view1.Sort = String.Format("{0} {1}", sortField, sortDirection);
            BJ_RZ_Grid.DataSource = view1;
            return view1.ToTable();
        }

        private StringBuilder jj()
        {
            StringBuilder strWhere = new StringBuilder();

            if (BJ_RZ_提报单位.SelectedValue == "全部")
            {
                strWhere.Append("  1=1 ");
            }
            else
            {
                strWhere.Append("  a.提报单位='" + BJ_RZ_提报单位.SelectedValue + "'");
            }



            if (RZ_TC_物料号.Text == "")
            {
                strWhere.Append(" and 1=1 ");
            }
            else
            {
                strWhere.Append(" and a.物料号 like '%" + RZ_TC_物料号.Text + "%'");
            }
            if (RZ_TC_物料名称.Text == "")
            {
                strWhere.Append(" and 1=1 ");
            }
            else
            {
                strWhere.Append(" and b.备件名称 like '%" + RZ_TC_物料名称.Text + "%'");
            }

            strWhere.Append(" and a.发料日期 between '" + RZ_TC_StarDate.Text + "' and '" + RZ_TC_EndDate.Text + "'");

            return strWhere;
        }

        private void RZ_BrindDorpDownList()
        {
            备件信息管理BLL bll = new 备件信息管理BLL();
            DataSet ds1 = bll.GetList1("a." + BJ_RZ_提报单位.Label);
            DataTable dt1 = ds1.Tables[0];
            BJ_RZ_提报单位.DataTextField = "提报单位";
            BJ_RZ_提报单位.DataValueField = "提报单位";
            BJ_RZ_提报单位.DataSource = dt1;
            BJ_RZ_提报单位.DataBind();
            BJ_RZ_提报单位.Items.Insert(0, new FineUIPro.ListItem("全部", "全部"));
            BJ_RZ_提报单位.Items[0].Selected = true;
            DateTime time = DateTime.Now;
            RZ_TC_EndDate.SelectedDate = time;
        }

        private void RZ_Money()
        {
            备件信息管理BLL bll = new 备件信息管理BLL();
            double aa = Convert.ToDouble(bll.RZ_GetMoney(jj().ToString()));
            if (aa / 100000000 >= 1)
            {
                double z = Math.Floor(aa / 100000000);
                double a = Math.Round(aa - (z * 100000000), 2);
                double x = Math.Floor(a / 10000);
                double c = x * 10000;
                double b = Math.Round(a - c, 2);
                string xx = "￥" + z + "亿" + x + "万" + b + "元";
                BJ_RZ_金额.Text = xx;
            }
            else
            {
                if (aa / 10000 >= 1)
                {
                    double z = Math.Floor(aa / 10000);
                    double c = z * 10000;
                    double b = Math.Round(aa - c, 2);
                    string x = "￥" + z + "万" + b + "元";
                    BJ_RZ_金额.Text = x;
                }
                else
                {
                    BJ_RZ_金额.Text = "￥" + Convert.ToDouble(bll.RZ_GetMoney(jj().ToString())).ToString() + "元";
                }

            }
        }



        #endregion

        protected void BJ_RZ_条件筛选_Click(object sender, EventArgs e)
        {
            BJ_RZ_筛选弹窗.Hidden = false;
        }

        protected void BJ_RZ_清除筛选_Click(object sender, EventArgs e)
        {
            RZ_TC_物料号.Text = "";
            RZ_TC_物料名称.Text = "";
            BJ_RZ_提报单位.Items[0].Selected = true;
            RZ_TC_StarDate.Text = "2015-01-01";
            DateTime time = DateTime.Now;
            RZ_TC_EndDate.Text = time.ToString();
            RZ_BindGrid();
        }

        protected void RZ_TC_确定筛选_Click(object sender, EventArgs e)
        {
            RZ_BindGrid();
            BJ_RZ_筛选弹窗.Hidden = true;
        }

        protected void RZ_TC_取消_Click(object sender, EventArgs e)
        {
            BJ_RZ_筛选弹窗.Hidden = true;
        }

        protected void BJ_RZ_提报单位_SelectedIndexChanged(object sender, EventArgs e)
        {
            RZ_BindGrid();
        }

        protected void BJ_RZ_Grid_PageIndexChange(object sender, GridPageEventArgs e)
        {
            BJ_RZ_Grid.PageIndex = e.NewPageIndex;
            RZ_BindGrid();
        }
    }
}