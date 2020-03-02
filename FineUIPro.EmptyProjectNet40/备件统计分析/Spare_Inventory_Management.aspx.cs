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
    public partial class Spare_Inventory_Management : System.Web.UI.Page
    {
        备件统计分析BLL bll = new 备件统计分析BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitLoad();
            }
        }

        private void bind()
        {
            Grid1.PageSize = int.Parse(ddlPageSize.SelectedValue);
            string Sql = @"select  物料号,SUM(预留数量) as 总预留数量,SUM(发料数量) as 总发料数量 ,SUM(剩余数量) as 总剩余数量 from b_备件_导入日志表 group by  物料号 order by 物料号";
            DataSet ds = bll.返回DataSet(Sql);
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
            //       Window1.GetShowReference("sysAdminAdd.aspx", "添加"));

        }

        //删除
        protected void Button_delete_OnClick(object sender, EventArgs e)
        {
            //string ids = GetDataKeysBySelectedRow(Grid1);
            //if (ids.Length == 0)
            //{
            //    NotifyWarning("请选择记录！");
            //    return;
            //}
            //mydddd.BLL.sysAdmin bll = new mydddd.BLL.sysAdmin();
            //bll.DeleteList(ids);
            //bind();
        }

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
            ttbSearchMessage.Text = String.Empty;
            ttbSearchMessage.ShowTrigger1 = false;
            DelPageState();
            bind();
        }

        //搜索
        protected void ttbSearchMessage_OnTrigger2Click(object sender, EventArgs e)
        {
            ttbSearchMessage.ShowTrigger1 = true;
            DelPageState();
            bind();
        }


        //页面重置
        protected void Button_Repage_OnClick(object sender, EventArgs e)
        {
            DelPageState();
            PageContext.Refresh();
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

        protected void Window1_OnClose(object sender, WindowCloseEventArgs e)
        {
            bind();
        }
    }
}