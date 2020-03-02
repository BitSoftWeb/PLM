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
    public partial class 设备履历 : System.Web.UI.Page
    {
        设备台账BLL bll = new 设备台账BLL();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)//是否是客户端回发而加载
            {
                //获取设备编号
                string paramName = Request.QueryString["SBBH"];
                //查询年份
                //string 年份 = bll.查询设备故障年份(paramName);
                string 投产时间 = Request.QueryString["tcsj"];

                //根据设备编号查询设备故障时间轴
                List<设备故障维修表> listmodel = bll.设备编号查询设备故障信息(paramName);


                foreach (设备故障维修表 item in listmodel)
                {
                    Label1.Text += item.故障时间.ToString("yyyy-MM-dd")+",";
                   
                    string 更换备件 = "否";
                    if (item.更换备件.Length > 0)
                    {
                        更换备件 = "是";
                    }
                    Label2.Text += "设备编号:" + paramName + ",故障描述：" + item.故障描述 + ",是否更换备件：" + 更换备件 + "*";

                }

                try
                {
                    DateTime tc = Convert.ToDateTime(投产时间);
                    Label1.Text += tc.ToString("yyyy-MM-dd");
                    Label2.Text += "设备编号:" + paramName+",投入运营";
                }
                catch (Exception)
                {
                    Label1.Text += "";
                    Label2.Text += "设备编号:" + paramName + ",投入运营";
                }
            }
        }
    }
}