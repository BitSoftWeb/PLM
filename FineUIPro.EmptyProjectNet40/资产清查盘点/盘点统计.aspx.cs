using PLM.BusinessRlues;
using PLM_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FineUIPro.EmptyProjectNet40.资产清查盘点
{
    public partial class 盘点统计 : System.Web.UI.Page
    {
        固定资产清查BLL bll = new 固定资产清查BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                OffSession();
                int 用户二级部门ID = Convert.ToInt32(Session["二级部门ID"]);
                List<用户单位表> list = bll.查询用户二级单位(用户二级部门ID);
                if (list != null)
                {
                    二级单位.Text = list[0].名称;
                    //二级ID = list[0].ID;
                }

                List<部门表> listbm = bll.查询用户所在三级部门(用户二级部门ID);
                三级单位.DataTextField = "名称";
                三级单位.DataValueField = "ID";
                三级单位.DataSource = listbm;
                三级单位.DataBind();
                三级单位.EmptyText = "全部";


                List<AM_盘点清查主表> listpd = bll.查询盘点主表();
                盘点名称.DataTextField = "盘点名称";
                盘点名称.DataValueField = "ID";
                盘点名称.DataSource = listpd;
                盘点名称.DataBind();
            }
        }


        private void OffSession()
        {
            try
            {
                if (Session["用户名"].ToString() == null)
                {
                    Response.Write("<script>alert('Session已失效，请点击系统名称返回登录页面')</script>");
                    Response.End();
                }
                else
                {
                    //不等于null
                }
            }
            catch (Exception)
            {
                Response.Write("<script>alert('Session已失效，请点击系统名称返回登录页面')</script>");
                Response.End();
            }
        }
        private void BindGrid()
        {
            if (Convert.ToInt32(盘点名称.SelectedValue) > 0)
            {
                Grid1.DataSource = bll.查询盘点统计(Convert.ToInt32(盘点名称.SelectedValue), 盘点名称.SelectedText);
                Grid1.DataBind();
            }
            else 
            {
            }
          
        }
      
        protected void Grid1_Sort(object sender, GridSortEventArgs e)
        {
            //Grid1.SortDirection = e.SortDirection;
            //Grid1.SortField = e.SortField;

            BindGrid();
        }

        protected void SelectContentBtn_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void Grid1_RowCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Action1")
            {
                object[] keys = Grid1.DataKeys[e.RowIndex];
                string 盘点任务名称 = keys[0].ToString();
                int 二级部门ID = Convert.ToInt32( keys[1].ToString());
                if (Convert.ToInt32(盘点名称.SelectedValue) > 0)
                {
                    Grid2.DataSource = bll.查询三级部门盘点信息(二级部门ID, 盘点任务名称);
                    Grid2.DataBind();
                }

                Window1.Hidden = false;
            }
        }

        protected void 三级单位_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}