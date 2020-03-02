using PLM_BusinessRlues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FineUIPro.EmptyProjectNet40.设备运行管理
{
    public partial class 选取设备台账 : System.Web.UI.Page
    {
        设备台账BLL bll = new 设备台账BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {

            }
        }

        protected void ttbSearch_Trigger2Click(object sender, EventArgs e)
        {
            Grid1.DataSource = bll.模糊查询设备信息(ttbSearch.Text);
            Grid1.DataBind();
        }
    }
}