using FineUIPro;
using PLM.BusinessRlues;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace mydddd.Web.Spare_Part_Analyze
{
    public partial class Spare_Part_CompanyPriceData : System.Web.UI.Page
    {
        备件统计分析BLL bll = new 备件统计分析BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //DeviceDropDownListBind();
                InitLoad();
            }
        }


        protected void bind()
        {
            string time = Request.QueryString["time"].ToString();
            string SQL = @"select SUM(b.总价) as 总价,a.提报单位 from  b_备件_导入日志表 as a, b_备件_记录表 as b where a.ID=b.日志ID and YEAR(b.操作日期)=" + time + " group by a.提报单位 order by 总价 desc";
            DataSet ds = bll.返回DataSet(SQL);
            DataTable dt = ds.Tables[0];
            Grid1.DataSource = dt;
            Grid1.DataBind();
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

        protected void Window1_Close(object sender, WindowCloseEventArgs e)
        {

        }
    }
}