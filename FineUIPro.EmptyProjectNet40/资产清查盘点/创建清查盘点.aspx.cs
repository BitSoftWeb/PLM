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
            model.盘点方式 = "资产全生命周期（Web）";
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

        protected void btnClose_Click(object sender, EventArgs e)
        {

        }

        #region 关闭盘点任务事件,打开关闭窗口，填充信息
        protected void Button1_Click(object sender, EventArgs e)
        {
            form关闭盘点流程.Hidden = false;
            List<AM_盘点清查主表> listmodel = bll.查询盘点清查主表("否");
            关闭任务名称.DataTextField = "盘点名称";
            关闭任务名称.DataValueField = "ID";
            关闭任务名称.DataSource = listmodel;
            关闭任务名称.DataBind();

            关闭盘点范围.Text = listmodel[0].盘点范围;
            关闭创建人.Text = listmodel[0].创建人;
            关闭创建时间.Text = listmodel[0].创建时间.ToString();
            关闭备注.Text = listmodel[0].备注;
        }
        #endregion

        protected void Button3_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(关闭任务名称.SelectedValue);
            if (ID==0)
            {
                Alert alert = new Alert();
                alert.Message = "请选择";
                alert.Title = "提示信息";
                alert.MessageBoxIcon = MessageBoxIcon.Error;
                alert.Show();
                return;
            }
            int result = bll.关闭清查盘点(ID);
            if (result>0) 
            {
                //提示信息
                Alert alert = new Alert();
                alert.Message = "成功关闭";
                alert.Title = "提示信息";
                alert.MessageBoxIcon = MessageBoxIcon.Success;
                alert.Show();
                form关闭盘点流程.Hidden = true;
            }


        }
    }
}