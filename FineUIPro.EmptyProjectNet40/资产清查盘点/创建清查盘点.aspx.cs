using PLM.BusinessRlues;
using PLM_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FineUIPro.EmptyProjectNet40.资产清查盘点
{
    public partial class 创建清查盘点 : System.Web.UI.Page
    {
        固定资产清查BLL bll = new 固定资产清查BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack) 
            {

                if (Session["UserName"] == null)
                {
                   //Session失效 
                }

                创建人.Text = "admin";
                DateTime dt = DateTime.Now;
                int month = dt.Month;
                int year = dt.Year;
                if (month <= 6)
                {
                    任务标题.Text = year.ToString() + "年上半年固定资产清查";
                }
                else 
                {
                    任务标题.Text = year.ToString() + "年下半年固定资产清查";
                }
            }
        }
        protected void Button9_Click(object sender, EventArgs e)
        {
            Window1.Hidden = false;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            AM_盘点清查主表 model = new AM_盘点清查主表();
            model.创建人 = 创建人.Text;
            model.创建时间 = DateTime.Now;
            model.盘点范围 = 盘点范围.SelectedText;
            model.盘点名称 = 任务标题.Text;
            model.是否关闭 = "否";
            model.盘点方式 = "";
            //int oky = bll.创建盘点主表(model);
            if (bll.创建盘点主表(model)>0)
            {
                //提示信息
                Alert alert = new Alert();
                alert.Message = "创建成功，各单位盘点结束后请关闭";
                alert.Title = "提示信息";
                alert.MessageBoxIcon = MessageBoxIcon.Success;
                alert.Show();
                Window1.Hidden = true;
            }

        }
    }
}