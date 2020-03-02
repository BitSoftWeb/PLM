using PLM.BusinessRlues;
using PLM_BusinessRlues;
using PLM_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FineUIPro.EmptyProjectNet40
{
    public partial class 设备统计分析 : System.Web.UI.Page
    {
        设备台账BLL bll = new 设备台账BLL();
        设备故障BLL gzbll = new 设备故障BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)//是否是客户端回发而加载
            {
                this.设备总数.Text = bll.查询设备总数().ToString();
                this.故障总数.Text = bll.查询故障设备总数().ToString();
                this.高速故障总数.Text = bll.树形结构查询设备总数(1, "二级").ToString();
                this.内饰件故障总数.Text = bll.树形结构查询设备总数(7, "二级").ToString();
                this.冲压件分公司.Text = bll.树形结构查询设备总数(8, "二级").ToString();
                this.客车制造中心.Text = bll.树形结构查询设备总数(9, "二级").ToString();
                this.转向架组制造中心.Text = bll.树形结构查询设备总数(2, "二级").ToString();
                this.动力厂.Text = bll.树形结构查询设备总数(3, "二级").ToString();
                LoadData();


            }

        }
        private void LoadData()
        {
            //绑定单位
            List<用户单位表> list = gzbll.查询二级单位();
            二级单位.DataTextField = "名称";
            二级单位.DataValueField = "ID";
            二级单位.DataSource = list;
            二级单位.DataBind();
            //二级单位.EmptyText = "全部";
        }
    }
}