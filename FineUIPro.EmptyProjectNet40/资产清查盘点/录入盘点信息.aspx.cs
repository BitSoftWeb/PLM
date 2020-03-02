using Newtonsoft.Json.Linq;
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
    public partial class 录入盘点信息 : System.Web.UI.Page
    {
        固定资产清查BLL bll = new 固定资产清查BLL();

        string username = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                btnNew.OnClientClick = Confirm.GetShowReference("确定提交当前页盘点信息？", String.Empty, MessageBoxIcon.Question, btnNew.GetPostBackEventReference(), String.Empty);
                LoadData();
                OffSession();

                //DataTable table = GetSourceData();
                //Grid1.DataSource = bll.测试查询转向架台账数据(2);
                //Grid1.DataBind();
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
        private void LoadData()
        {
            //绑定单位
            //把二级部门绑定上
            OffSession();
            int 用户二级部门ID = Convert.ToInt32(Session["二级部门ID"]);

            username = Session["用户名"].ToString();
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

        public DataTable GetSourceData()
        {

            //获取用户Session
            int id = 1;//模拟用户ID
            //string username = HttpContext.Current.Session["f_user_name"].ToString();//读取session
            //查询数据库
            // //SAP编号,设备编号,设备名称,设备型号,设备规格,制造商,部门名称,投产时间,操作人,帐物是否相符,盘盈或盘亏简要原因,闲置或待报废简要原因

            DataTable table = new DataTable();
            table.Columns.Add(new DataColumn("ID", typeof(int)));
            table.Columns.Add(new DataColumn("SAP编号", typeof(String)));
            table.Columns.Add(new DataColumn("设备编号", typeof(String)));
            table.Columns.Add(new DataColumn("设备名称", typeof(String)));
            table.Columns.Add(new DataColumn("设备型号", typeof(String)));
            table.Columns.Add(new DataColumn("设备规格", typeof(String)));
            table.Columns.Add(new DataColumn("制造商", typeof(String)));
            table.Columns.Add(new DataColumn("部门名称", typeof(String)));
            table.Columns.Add(new DataColumn("投产时间", typeof(String)));
            table.Columns.Add(new DataColumn("操作人", typeof(String)));
            table.Columns.Add(new DataColumn("帐物是否相符", typeof(String)));
            table.Columns.Add(new DataColumn("盘盈或盘亏简要原因", typeof(String)));
            table.Columns.Add(new DataColumn("闲置或待报废简要原因", typeof(String)));

            return table;
        }

        protected void SelectContentBtn_Click(object sender, EventArgs e)
        {
            OffSession();
            if (盘点名称.SelectedText == "" || 盘点名称.SelectedText == null)
            {
                Alert alert = new Alert();
                alert.Message = "请选择盘点名称";
                alert.Title = "提示信息";
                alert.MessageBoxIcon = MessageBoxIcon.Warning;
                alert.Show();
                return;
            }
            DataTable newTable = GetSourceData().Clone();
            DataRow newRow;
            JArray mergedData = Grid1.GetMergedData();
            if (mergedData.Count == 0)
            {
                Alert alert = new Alert();
                alert.Message = "请选择数据";
                alert.Title = "提示信息";
                alert.MessageBoxIcon = MessageBoxIcon.Warning;
                alert.Show();
                return;
            }
            List<Model录入盘点信息> listpd = new List<Model录入盘点信息>();
            foreach (JObject mergedRow in mergedData)
            {
                JObject values = mergedRow.Value<JObject>("values");
                newRow = newTable.NewRow();
                Model录入盘点信息 model = new Model录入盘点信息();
                model.设备台账ID = Convert.ToInt32(values.Value<string>("ID"));
                model.设备编号 = values.Value<string>("设备编号");
                model.盘点主表ID = Convert.ToInt32(盘点名称.SelectedValue);
                model.二级部门ID = Convert.ToInt32(values.Value<string>("二级部门ID"));
                model.三级部门ID = Convert.ToInt32(values.Value<string>("三级部门ID"));
                model.二级部门名称 = values.Value<string>("二级部门名称");
                model.三级部门名称 = values.Value<string>("三级部门名称");
                model.操作人 = username;
                model.操作日期 = DateTime.Now.ToShortDateString();
                model.盘点类型 = 盘点类型.Text;
                model.帐物是否相符 = values.Value<string>("帐物是否相符");
                model.盘盈或盘亏简要原因 = values.Value<string>("盘盈或盘亏简要原因");
                model.闲置或待报废简要原因 = values.Value<string>("闲置或待报废简要原因");
                model.盘点类型 = 盘点类型.SelectedText;
                listpd.Add(model);
            }
            int yisn = bll.插入已盘点设备表(listpd);
            if (yisn > 0)
            {
                int ID = 0;
                string name = 三级单位.SelectedText;
                if (name == "全部")
                {
                    int 用户二级部门ID = Convert.ToInt32(Session["二级部门ID"]);
                    Grid1.RecordCount = bll.查询盘点设备总数("全部", 用户二级部门ID);
                    DataTable table = GetSourceData();
                    Grid1.DataSource = bll.测试查询转向架台账数据("全部", 用户二级部门ID, Grid1.PageIndex, Grid1.PageSize - 1, username);
                    Grid1.DataBind();
                }
                else
                {
                    ID = Convert.ToInt32(三级单位.SelectedValue);
                    Grid1.RecordCount = bll.查询盘点设备总数(name, ID);
                    DataTable table = GetSourceData();
                    Grid1.DataSource = bll.测试查询转向架台账数据("部门", ID, Grid1.PageIndex, Grid1.PageSize - 1, username);
                    Grid1.DataBind();
                }
            }



        }

        protected void 三级单位_SelectedIndexChanged(object sender, EventArgs e)
        {
            OffSession();
            int ID = 0;
            string name = 三级单位.SelectedText;
            if (name == "全部")
            {
                int 用户二级部门ID = Convert.ToInt32(Session["二级部门ID"]);
                Grid1.RecordCount = bll.查询盘点设备总数("全部", 用户二级部门ID);
                DataTable table = GetSourceData();
                Grid1.DataSource = bll.测试查询转向架台账数据("全部", 用户二级部门ID, Grid1.PageIndex, Grid1.PageSize, username);
                Grid1.DataBind();
            }
            else
            {
                ID = Convert.ToInt32(三级单位.SelectedValue);
                Grid1.RecordCount = bll.查询盘点设备总数(name, ID);
                DataTable table = GetSourceData();
                Grid1.DataSource = bll.测试查询转向架台账数据(name, ID, Grid1.PageIndex, Grid1.PageSize, username);
                Grid1.DataBind();
            }
            //int ID = Convert.ToInt32(二级单位.SelectedValue);
            //Grid1.DataSource = gzbll.按各单位查询设备故障(ID, 起始日期, 截止日期, ttbSearch.Text, year);
            //Grid1.DataBind();
        }

        protected void Grid1_PageIndexChange(object sender, GridPageEventArgs e)
        {
            OffSession();
            int ID = 0;
            string name = 三级单位.SelectedText;
            if (name == "全部")
            {
                int 用户二级部门ID = Convert.ToInt32(Session["二级部门ID"]);
                Grid1.RecordCount = bll.查询盘点设备总数("全部", 用户二级部门ID);
                DataTable table = GetSourceData();
                Grid1.DataSource = bll.测试查询转向架台账数据("全部", 用户二级部门ID, Grid1.PageIndex, Grid1.PageSize - 1, username);
                Grid1.DataBind();
            }
            else
            {
                ID = Convert.ToInt32(三级单位.SelectedValue);
                Grid1.RecordCount = bll.查询盘点设备总数(name, ID);
                DataTable table = GetSourceData();
                Grid1.DataSource = bll.测试查询转向架台账数据("部门", ID, Grid1.PageIndex, Grid1.PageSize - 1, username);
                Grid1.DataBind();
            }


        }

        protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            OffSession();
            Grid1.PageSize = Convert.ToInt32(ddlPageSize.SelectedValue);

            int ID = 0;
            string name = 三级单位.SelectedText;
            if (name == "全部")
            {
                int 用户二级部门ID = Convert.ToInt32(Session["二级部门ID"]);
                Grid1.RecordCount = bll.查询盘点设备总数("全部", 用户二级部门ID);
                DataTable table = GetSourceData();
                Grid1.DataSource = bll.测试查询转向架台账数据("全部", 用户二级部门ID, Grid1.PageIndex, Grid1.PageSize - 1, username);
                Grid1.DataBind();
            }
            else
            {
                ID = Convert.ToInt32(三级单位.SelectedValue);
                Grid1.RecordCount = bll.查询盘点设备总数(name, ID);
                DataTable table = GetSourceData();
                Grid1.DataSource = bll.测试查询转向架台账数据("部门", ID, Grid1.PageIndex, Grid1.PageSize - 1, username);
                Grid1.DataBind();
            }
        }
    }
}