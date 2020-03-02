using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FineUIPro.EmptyProjectNet40.设备运行管理
{
    public partial class 精度检测 : System.Web.UI.Page
    {
        private bool AppendToEnd = true;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // 删除选中单元格的客户端脚本
                string deleteScript = GetDeleteScript();

                // 新增数据初始值
                JObject defaultObj = new JObject();
                defaultObj.Add("设备编号", "");
                defaultObj.Add("重点设备", "");
                defaultObj.Add("设备名称", "");
                defaultObj.Add("型号", "");
                defaultObj.Add("复杂系数Fj", "");
                //defaultObj.Add("Major", "未知");
                defaultObj.Add("Delete", String.Format("<a href=\"javascript:;\" onclick=\"{0}\"><img src=\"{1}\"/></a>", deleteScript, IconHelper.GetResolvedIconUrl(Icon.Delete)));


                // 在第一行新增一条数据
                btnNew.OnClientClick = Grid1.GetAddNewRecordReference(defaultObj, AppendToEnd);

                // 重置表格
                btnReset.OnClientClick = Confirm.GetShowReference("确定要重置表格数据？", String.Empty, Grid1.GetRejectChangesReference(), String.Empty);


                // 删除选中行按钮
                btnDelete.OnClientClick = Grid1.GetNoSelectionAlertReference("请至少选择一项！") + deleteScript;



            }
        }



        // 删除选中行的脚本
        private string GetDeleteScript()
        {
            return Confirm.GetShowReference("删除选中行？", String.Empty, MessageBoxIcon.Question, Grid1.GetDeleteSelectedRowsReference(), String.Empty);
        }


        #region BindGrid




        #endregion

        #region Events

        protected void Grid1_PreDataBound(object sender, EventArgs e)
        {
            // 设置LinkButtonField的点击客户端事件
            LinkButtonField deleteField = Grid1.FindColumn("Delete") as LinkButtonField;
            deleteField.OnClientClick = GetDeleteScript();
        }

        public DataTable GetSourceData() 
        {
            DataTable table = new DataTable();
            table.Columns.Add(new DataColumn("ID", typeof(int)));
            table.Columns.Add(new DataColumn("设备编号", typeof(String)));
            table.Columns.Add(new DataColumn("重点设备", typeof(String)));
            table.Columns.Add(new DataColumn("设备名称", typeof(String)));
            table.Columns.Add(new DataColumn("型号", typeof(String)));
            table.Columns.Add(new DataColumn("复杂系数Fj", typeof(String)));
            table.Columns.Add(new DataColumn("复杂系数Fd", typeof(String)));
            table.Columns.Add(new DataColumn("一月份", typeof(int)));
            table.Columns.Add(new DataColumn("二月份", typeof(int)));
            table.Columns.Add(new DataColumn("三月份", typeof(int)));
            table.Columns.Add(new DataColumn("四月份", typeof(int)));
            table.Columns.Add(new DataColumn("五月份", typeof(int)));
            table.Columns.Add(new DataColumn("六月份", typeof(int)));
            table.Columns.Add(new DataColumn("七月份", typeof(int)));
            table.Columns.Add(new DataColumn("八月份", typeof(int)));
            table.Columns.Add(new DataColumn("九月份", typeof(int)));
            table.Columns.Add(new DataColumn("十月份", typeof(int)));
            table.Columns.Add(new DataColumn("十一月份", typeof(int)));
            table.Columns.Add(new DataColumn("十二月份", typeof(int)));
            return table;
        }


        protected void Button2_Click(object sender, EventArgs e)
        {

            if (Grid1.GetModifiedData().Count == 0)
            {
                //labResult.Text = "";
                //ShowNotify("表格数据没有变化！");
                Alert.ShowInTop("表格内没有数据！");
                return;
            }

            // 复制原始表格的结构
            DataTable newTable = GetSourceData().Clone();
            DataRow newRow;

            int rowIndex = 0;
            JArray mergedData = Grid1.GetMergedData();

            foreach (JObject mergedRow in mergedData)
            {
                JObject values = mergedRow.Value<JObject>("values");
                newRow = newTable.NewRow();
                newRow[0] = rowIndex;
                newRow[1] = values.Value<string>("设备编号");
                string ss = values.Value<string>("设备编号");
                if (ss == "" || ss == null)
                {
                    Alert.ShowInTop("请填写完整数据");
                    return;
                }
               
                newRow[2] = values.Value<string>("重点设备");
                newRow[3] = values.Value<string>("设备名称");
            }
        }

        private void UpdateDataRow(Dictionary<string, object> rowDict, DataRow rowData)
        {
            // 姓名
            UpdateDataRow("Name", rowDict, rowData);

            // 性别
            UpdateDataRow("Gender", rowDict, rowData);

            // 入学年份
            UpdateDataRow("EntranceYear", rowDict, rowData);

            // 入学日期
            UpdateDataRow("EntranceDate", rowDict, rowData);

            // 是否在校
            UpdateDataRow("AtSchool", rowDict, rowData);

            // 所学专业
            UpdateDataRow("Major", rowDict, rowData);

        }

        private void UpdateDataRow(string columnName, Dictionary<string, object> rowDict, DataRow rowData)
        {
            if (rowDict.ContainsKey(columnName))
            {
                rowData[columnName] = rowDict[columnName];
            }
        }


        #endregion

        #region Data

        //private static readonly string KEY_FOR_DATASOURCE_SESSION = "datatable_for_grideditor_selectfromwindow_clientscript";

        // 模拟在服务器端保存数据
        // 特别注意：在真实的开发环境中，不要在Session放置大量数据，否则会严重影响服务器性能
        //private DataTable GetSourceData()
        //{
        //    if (Session[KEY_FOR_DATASOURCE_SESSION] == null)
        //    {
        //        Session[KEY_FOR_DATASOURCE_SESSION] = DataSourceUtil.GetEmptyDataTable();
        //    }
        //    return (DataTable)Session[KEY_FOR_DATASOURCE_SESSION];
        //}

        // 根据行ID来获取行数据
    

  

        #endregion


        protected void tbxEditorName_TriggerClick(object sender, EventArgs e)
        {
            string[] selectedCell = Grid1.SelectedCell;
            if (selectedCell != null)
            {
                PageContext.RegisterStartupScript(Window1.GetShowReference("选取设备台账.aspx?rowid=" + selectedCell[0]));
            }
        }





    }
}