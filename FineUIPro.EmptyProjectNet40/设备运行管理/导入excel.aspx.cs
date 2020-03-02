using PLM_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FineUIPro.EmptyProjectNet40.设备运行管理
{
    public partial class 导入excel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (ExcelFileUpload.HasFile == false)//HasFile用来检查FileUpload是否有文件
            {
                Response.Write("<script>alert('请您选择Excel文件')</script> ");
                return;//当无文件时,返回
            }
            string IsXls = Path.GetExtension(ExcelFileUpload.FileName).ToString().ToLower();//System.IO.Path.GetExtension获得文件的扩展名
            if (IsXls != ".xlsx" && IsXls != ".xls")
            {
                Response.Write(ExcelFileUpload.FileName);
                Response.Write("<script>alert('只可以选择Excel文件')</script>");
                return;//当选择的不是Excel文件时,返回
            }
            string filename = ExcelFileUpload.FileName;//获取Execle文件名 ]
            string savePath = Server.MapPath(("UploadExcel\\") + filename);//Server.MapPath 服务器上的指定虚拟路径相对应的物理文件路径
            DataTable ds = new DataTable();
            ExcelFileUpload.SaveAs(savePath);//将文件保存到指定路径
            DataTable dt = GetExcelDatatable(savePath);//读取excel数据
            List<Model精度检测> regList = ConvertDtToInfo(dt);//将datatable转为list


        }

        /// <summary>
        /// 从excel文件中读取数据
        /// </summary>
        /// <param name="fileUrl">实体文件的存储路径</param>
        /// <returns></returns>
        private static DataTable GetExcelDatatable(string fileUrl)
        {
            //支持.xls和.xlsx，即包括office2010等版本的;HDR=Yes代表第一行是标题，不是数据；
            string cmdText = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileUrl + "; Extended Properties=\"Excel 12.0;HDR=Yes\"";
            System.Data.DataTable dt = null;
            //建立连接
            OleDbConnection conn = new OleDbConnection(cmdText);
            try
            {
                //打开连接
                if (conn.State == ConnectionState.Broken || conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                System.Data.DataTable schemaTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                string strSql = "select * from [2014$]";   //这里指定表明为Sheet1,如果修改过表单的名称，请使用修改后的名称
                OleDbDataAdapter da = new OleDbDataAdapter(strSql, conn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dt = ds.Tables[0]; ;
                return dt;
            }
            catch (Exception exc)
            {
                throw exc;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        /// <summary>
        /// 将datatable转换为list集合
        /// </summary>
        /// <param name="dt">DataTable</param>
        /// <returns></returns>
        private static List<Model精度检测> ConvertDtToInfo(DataTable dt)
        {
            List<Model精度检测> list = new List<Model精度检测>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    Model精度检测 info = new Model精度检测();
                    info.设备编号 = item[1].ToString();
                    info.设备名称 = item[10].ToString();//√
                    //所有int类型都需要转换string
                    list.Add(info);
                }
            }
            return list;
        }



    }
}