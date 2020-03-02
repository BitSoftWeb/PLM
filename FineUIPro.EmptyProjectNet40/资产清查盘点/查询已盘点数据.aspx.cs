using mydddd.Web.code;
using PLM.BusinessRlues;
using PLM_Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FineUIPro.EmptyProjectNet40.资产清查盘点
{
    public partial class 查询已盘点数据 : System.Web.UI.Page
    {
        固定资产清查BLL bll = new 固定资产清查BLL();
        string username = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }
        private void LoadData()
        {
            int 用户二级部门ID = Convert.ToInt32(Session["二级部门ID"]);
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
        protected void Grid1_PageIndexChange(object sender, GridPageEventArgs e)
        {
            string name = 三级单位.SelectedText;
            int 用户二级部门ID = Convert.ToInt32(Session["二级部门ID"]);
            string str盘点类型= 盘点类型.SelectedText;
            int 盘点主表ID = Convert.ToInt32(盘点名称.SelectedValue);
            if (name == "全部")
            {
                //Grid1.RecordCount = bll.查询盘点设备总数("全部", 2);
                Grid1.RecordCount = bll.查询已盘点总数(盘点主表ID, 用户二级部门ID, "全部", str盘点类型);
                Grid1.DataSource = bll.查询已盘点数据(盘点主表ID, 用户二级部门ID, "", "全部", str盘点类型, Grid1.PageIndex, Grid1.PageSize - 1);
                Grid1.DataBind();
            }
            else
            {
                int ID = Convert.ToInt32(三级单位.SelectedValue);
                //Grid1.RecordCount = bll.查询盘点设备总数(name, ID);
                //DataTable table = GetSourceData();
                Grid1.RecordCount = bll.查询已盘点总数(盘点主表ID, ID, "部门", str盘点类型);
                Grid1.DataSource = bll.查询已盘点数据(盘点主表ID, ID, "", "部门", str盘点类型, Grid1.PageIndex, Grid1.PageSize - 1);
                Grid1.DataBind();
            }

        }

        protected void 三级单位_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str盘点类型 = 盘点类型.SelectedText;
            string name = 三级单位.SelectedText;
            int 用户二级部门ID = Convert.ToInt32(Session["二级部门ID"]);
            int 盘点主表ID = Convert.ToInt32(盘点名称.SelectedValue);
            if (name == "全部")
            {
                //Grid1.RecordCount = bll.查询盘点设备总数("全部", 2);
                Grid1.RecordCount = bll.查询已盘点总数(盘点主表ID, 用户二级部门ID, "全部", str盘点类型);
                Grid1.DataSource = bll.查询已盘点数据(盘点主表ID, 用户二级部门ID, "", "全部", str盘点类型, Grid1.PageIndex, Grid1.PageSize);
                Grid1.DataBind();
            }
            else
            {
                int ID = Convert.ToInt32(三级单位.SelectedValue);
                //Grid1.RecordCount = bll.查询盘点设备总数(name, ID);
                //DataTable table = GetSourceData();
                Grid1.RecordCount = bll.查询已盘点总数(盘点主表ID, ID, "部门", str盘点类型);
                Grid1.DataSource = bll.查询已盘点数据(盘点主表ID, ID, "", "部门", str盘点类型, Grid1.PageIndex, Grid1.PageSize);
                Grid1.DataBind();
            }
        }

        protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            string name = 三级单位.SelectedText;
            int 用户二级部门ID = Convert.ToInt32(Session["二级部门ID"]);
            string str盘点类型 = 盘点类型.SelectedText;
            int 盘点主表ID = Convert.ToInt32(盘点名称.SelectedValue);
            if (name == "全部")
            {
                Grid1.RecordCount = bll.查询已盘点总数(盘点主表ID, 用户二级部门ID, "全部", str盘点类型);
                Grid1.DataSource = bll.查询已盘点数据(盘点主表ID, 用户二级部门ID, "", "全部", str盘点类型, Grid1.PageIndex, Grid1.PageSize);
                Grid1.DataBind();
            }
            else
            {
                int ID = Convert.ToInt32(三级单位.SelectedValue);
                Grid1.RecordCount = bll.查询已盘点总数(盘点主表ID, ID, "部门", str盘点类型);
                Grid1.DataSource = bll.查询已盘点数据(盘点主表ID, ID, "", "部门", str盘点类型, Grid1.PageIndex, Grid1.PageSize);
                Grid1.DataBind();
            }
        }

        protected void SelectContentBtn_Click(object sender, EventArgs e)
        {
            string name = 三级单位.SelectedText;
            int 用户二级部门ID = Convert.ToInt32(Session["二级部门ID"]);
            string str盘点类型 = 盘点类型.SelectedText;
            int 盘点主表ID = Convert.ToInt32(盘点名称.SelectedValue);
            if (name == "全部")
            {
                Grid1.RecordCount = bll.查询已盘点总数(盘点主表ID, 用户二级部门ID, "全部", str盘点类型);
                Grid1.DataSource = bll.查询已盘点数据(盘点主表ID, 用户二级部门ID, "", "全部", str盘点类型, Grid1.PageIndex, Grid1.PageSize);
                Grid1.DataBind();
            }
            else
            {
                int ID = Convert.ToInt32(三级单位.SelectedValue);
                Grid1.RecordCount = bll.查询已盘点总数(盘点主表ID, ID, "部门", str盘点类型);
                Grid1.DataSource = bll.查询已盘点数据(盘点主表ID, ID, "", "部门", str盘点类型, Grid1.PageIndex, Grid1.PageSize);
                Grid1.DataBind();
            }
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            string name = 三级单位.SelectedText;
            int 用户二级部门ID = Convert.ToInt32(Session["二级部门ID"]);
            string str盘点类型 = 盘点类型.SelectedText;
            int 盘点主表ID = Convert.ToInt32(盘点名称.SelectedValue);
            List<Model录入盘点信息> moList = bll.查询已盘点数据(盘点主表ID, 用户二级部门ID, "", "全部", str盘点类型, Grid1.PageIndex, Grid1.PageSize);
            DataTable dt = ToDataTable(moList);

            NpoiHelper1.DownloadExcel(dt, NpoiHelper1.ExcelType.xls);
        }
        public static DataTable ToDataTable<T>(List<T> list)
        {
            DataTable dt = new DataTable();
            Type type = typeof(T);
            List<PropertyInfo> properties = new List<PropertyInfo>();
            Array.ForEach<PropertyInfo>(type.GetProperties(), p =>
            {
                properties.Add(p);
                dt.Columns.Add(p.Name, p.PropertyType);
            });
            foreach (var item in list)
            {
                DataRow row = dt.NewRow();
                properties.ForEach(p =>
                {
                    row[p.Name] = p.GetValue(item, null);
                });
                dt.Rows.Add(row);
            }
            return dt;
        }

        private string GetGridTableHtml(Grid grid)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("<meta http-equiv=\"content-type\" content=\"application/excel; charset=UTF-8\"/>");

            sb.Append("<table cellspacing=\"0\" rules=\"all\" border=\"1\" style=\"border-collapse:collapse;\">");

            sb.Append("<tr>");
            foreach (GridColumn column in grid.Columns)
            {
                sb.AppendFormat("<td>{0}</td>", column.HeaderText);
            }
            sb.Append("</tr>");


            foreach (GridRow row in grid.Rows)
            {
                sb.Append("<tr>");
                foreach (object value in row.Values)
                {
                    string html = value.ToString();
                    if (html.StartsWith(Grid.TEMPLATE_PLACEHOLDER_PREFIX))
                    {
                        // 模板列
                        string templateID = html.Substring(Grid.TEMPLATE_PLACEHOLDER_PREFIX.Length);
                        Control templateCtrl = row.FindControl(templateID);
                        html = GetRenderedHtmlSource(templateCtrl);
                    }
                    else
                    {
                        // 处理CheckBox
                        if (html.Contains("box-grid-static-checkbox"))
                        {
                            if (html.Contains("uncheck"))
                            {
                                html = "×";
                            }
                            else
                            {
                                html = "√";
                            }
                        }

                        // 处理图片
                        if (html.Contains("<img"))
                        {
                            string prefix = Request.Url.AbsoluteUri.Replace(Request.Url.AbsolutePath, "");
                            html = html.Replace("src=\"", "src=\"" + prefix);
                        }
                    }

                    sb.AppendFormat("<td>{0}</td>", html);
                }
                sb.Append("</tr>");
            }

            sb.Append("</table>");

            return sb.ToString();
        }

        private string GetRenderedHtmlSource(Control ctrl)
        {
            if (ctrl != null)
            {
                using (StringWriter sw = new StringWriter())
                {
                    using (HtmlTextWriter htw = new HtmlTextWriter(sw))
                    {
                        ctrl.RenderControl(htw);

                        return sw.ToString();
                    }
                }
            }
            return String.Empty;
        }

        protected void btnall_Click(object sender, EventArgs e)
        {

        }

    }
}