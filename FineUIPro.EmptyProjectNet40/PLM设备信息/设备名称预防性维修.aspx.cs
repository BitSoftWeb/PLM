using PLM_BusinessRlues;
using PLM_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FineUIPro.EmptyProjectNet40.PLM设备信息
{
    public partial class 设备名称预防性维修 : System.Web.UI.Page
    {
        设备台账BLL bll = new 设备台账BLL();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ttSearch_Trigger2Click(object sender, EventArgs e)
        {
            if (ttSearch.Text == "")
            {
                return;
            }
            else 
            {
                
                if (DropDownList1.SelectedValue == "设备类型")
                {
                    List<预防性维修> listmodel = bll.查询设备平均故障时间(ttSearch.Text);
                    
                    Grid1.DataSource = listmodel;
                    Grid1.DataBind();


                }
                else if (DropDownList1.SelectedValue == "设备编号")
                {
                    List<预防性维修> listmodel = bll.查询设备平均故障时间(ttSearch.Text);
                    Grid1.DataSource = listmodel;
                    Grid1.DataBind();
                }
            }
          

        }
    }
}