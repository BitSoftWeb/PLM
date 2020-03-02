using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FineUIPro.EmptyProjectNet40.PLM设备信息
{
    public partial class 全生命周期页面 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)//是否是客户端回发而加载
            {
                //获取设备编号
                string paramName = Request.QueryString["SBBH"];
                Label6.Text = "设备编号："+paramName;
            }
        }

        protected void s_Click(object sender, EventArgs e)
        {
            Window1.Hidden = false;
        }
    }
}