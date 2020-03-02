using PLM_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FineUIPro.EmptyProjectNet40.消息中心
{
    public partial class 消息中心首页 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                List<消息中心Model> userlist = new List<消息中心Model>();
                消息中心Model model = new 消息中心Model();
                model.发起人 = "admin";
                model.时间 = DateTime.Now.ToShortDateString() ;
                model.是否已读 = "否";
                model.通知类型 = "待办业务通知";
                model.消息事项 = "资产借用";
                model.事项内容 = "您有来自XXX的资产借用申请,请及时处理";
                userlist.Add(model);

                消息中心Model model1 = new 消息中心Model();
                model1.发起人 = "admin";
                model1.时间 = DateTime.Now.ToShortDateString();
                model1.是否已读 = "否";
                model1.通知类型 = "待办业务通知";
                model1.消息事项 = "盘点任务";
                model1.事项内容 = "您有来自XXX的盘点任务,请及时处理";
                userlist.Add(model1);

                Grid1.DataSource = userlist;
                Grid1.DataBind();

            }

        }


        protected void btnExpandRowExpanders_Click(object sender, EventArgs e)
        {
            Grid1.ExpandRowExpanders();
        }

        protected void btnCollapseRowExpanders_Click(object sender, EventArgs e)
        {
            Grid1.CollapseRowExpanders();
        }

        protected void btnSelectAll_Click(object sender, EventArgs e)
        {
            Grid1.SelectAllRows();
        }

        protected void btnClearSelect_Click(object sender, EventArgs e)
        {
            Grid1.SelectedRowIndexArray = null;
        }


    }
}