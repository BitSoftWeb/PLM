using PLM.BusinessRlues;
using PLM_BusinessRlues;
using PLM_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FineUIPro.EmptyProjectNet40
{
    public partial class index : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Constants.IS_BASE)
                {
                    try
                    {
                        btn1.Text = HttpContext.Current.Session["用户名"].ToString();
                    }
                    catch (Exception)
                    {
                        Response.Write("<script>alert('Session已失效，请点击系统名称返回登录页面')</script>");
                        //Response.Write(" <script language=javascript>alert('Session已失效，请点击系统名称返回登录页面') window.window.open='LoginTest.aspx';</script> ");
                        Response.End();
                    }

                    treeMenu.HideHScrollbar = false;
                    treeMenu.HideVScrollbar = false;
                    treeMenu.ExpanderToRight = false;
                    treeMenu.HeaderStyle = false;

 
                }
            }
        }

    

        private void LoadData()
        {
            //绑定单位
            //List<用户单位表> list = gzbll.查询二级单位();
            //二级单位.DataTextField = "名称";
            //二级单位.DataValueField = "ID";
            //二级单位.DataSource = list;
            //二级单位.DataBind();
            //二级单位.EmptyText = "全部";
        }


  
    }
}