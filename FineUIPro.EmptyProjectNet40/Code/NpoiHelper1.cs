using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;

namespace mydddd.Web.code
{
    public class NpoiHelper1
    {
        //HSSFWorkbook （后缀是.xls）   03版excel 最大 256 列 × 65,536 行 - 65535
        //XSSFWorkbook （后缀是.xlsx） 07版excel  最大 16,384 列 × 1,048,576 行 - 1048576

        /// <summary>
        /// excel 类型
        /// </summary>
        public enum ExcelType
        {
            xls = 65535,
            xlsx = 1048576,
        }

        #region 直接下载

        /// <summary>
        /// 直接以流的形式下载Excel
        /// </summary>
        /// <param name="reader"></param>
        public static void DownloadExcel(IDataReader reader)
        {
            DownloadExcel(RenderToExcel(reader, ExcelType.xlsx), ExcelType.xlsx);
        }

        /// <summary>
        /// 直接以流的形式下载Excel
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="type"></param>
        public static void DownloadExcel(DataTable dt, ExcelType type)
        {
            DownloadExcel(RenderToExcel(dt, type), type);
        }

        /// <summary>
        /// 直接以流的形式下载Excel
        /// </summary>
        /// <param name="dt"></param>
        public static void DownloadExcel(DataTable dt)
        {
            DownloadExcel(RenderToExcel(dt, ExcelType.xlsx), ExcelType.xlsx);
        }

        /// <summary>
        /// 直接以流的形式下载Excel
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="type"></param>
        public static void DownloadExcel(IDataReader reader, ExcelType type)
        {
            DownloadExcel(RenderToExcel(reader, type), type);
        }

        #endregion

        #region 转成数据流

        public static MemoryStream RenderToExcel(DataTable sourceTable)
        {
            return RenderToExcel(sourceTable, ExcelType.xlsx);
        }

        /// <summary>
        /// DataTable转换成Excel文档流(超出最大行数，自动分页)，默认xlsx格式
        /// </summary>
        /// <param name="sourceTable"></param>
        /// <param name="type">生成excel类型</param>
        /// <returns></returns>
        public static MemoryStream RenderToExcel(DataTable sourceTable, ExcelType type)
        {
            int maxRowNum = (int)type;

            IWorkbook workbook = new XSSFWorkbook();
            if (type == ExcelType.xls)
            {
                workbook = new HSSFWorkbook();
            }

            MemoryStream ms = new MemoryStream();
            int dtRowsCount = sourceTable.Rows.Count;

            int sheetNum = 1;
            int rowIndex = 1;
            int tempIndex = 1; //标识
            ISheet sheet = workbook.CreateSheet("sheet" + sheetNum);

            CreateRow(sheet, sourceTable);

            for (int i = 0; i < dtRowsCount; i++)
            {
                IRow dataRow = sheet.CreateRow(tempIndex);

                foreach (DataColumn column in sourceTable.Columns)
                {
                    dataRow.CreateCell(column.Ordinal).SetCellValue(sourceTable.Rows[i][column].ToString());
                }
                if (tempIndex == maxRowNum)
                {
                    sheetNum++;
                    sheet = workbook.CreateSheet("sheet" + sheetNum);
                    CreateRow(sheet, sourceTable);
                    tempIndex = 0;
                }
                rowIndex++;
                tempIndex++;
                //AutoSizeColumns(sheet);
            }
            workbook.Write(ms);
            ms.Flush();
            if (type == ExcelType.xls)
                ms.Position = 0;
            sheet = null;
            // headerRow = null;
            workbook = null;
            return ms;
        }


        /// <summary>
        /// DataReader转换成Excel文档流(超出最大行数，自动分页)，默认xlsx格式
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static MemoryStream RenderToExcel(IDataReader reader)
        {
            return RenderToExcel(reader, ExcelType.xlsx);
        }

        /// <summary>
        /// DataReader转换成Excel文档流(超出最大行数，自动分页)
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="type">生成excel类型</param>
        /// <returns></returns>
        public static MemoryStream RenderToExcel(IDataReader reader, ExcelType type)
        {
            MemoryStream ms = new MemoryStream();

            // handling value.
            int sheetNum = 1;
            int rowIndex = 1;
            int tempIndex = 1; //标识

            using (reader)
            {

                int maxRowNum = (int)type;

                IWorkbook workbook = new XSSFWorkbook();
                if (type == ExcelType.xls)
                {
                    workbook = new HSSFWorkbook();
                }

                ISheet sheet = workbook.CreateSheet("sheet" + sheetNum);//

                int cellCount = reader.FieldCount;
                CreateRow(sheet, reader);

                while (reader.Read())
                {
                    IRow dataRow = sheet.CreateRow(rowIndex);

                    for (int i = 0; i < cellCount; i++)
                    {
                        dataRow.CreateCell(i).SetCellValue(reader[i].ToString());
                    }

                    if (rowIndex == maxRowNum)
                    {
                        sheetNum++;
                        sheet = workbook.CreateSheet("sheet" + sheetNum);//
                        CreateRow(sheet, reader);
                        tempIndex = 0;
                    }

                    rowIndex++;
                    tempIndex++;
                }

                workbook.Write(ms);
                ms.Flush();

                if (type == ExcelType.xls)
                    ms.Position = 0;

                workbook = null;
                sheet = null;
                //headerRow = null;
            }
            return ms;
        }

        /// <summary>
        /// 将DataTable转成html Table字符串. 可用于直接输出.
        /// </summary>
        /// <param name="dt">传入的DataTable数据, 必须提供标题!</param>
        /// <returns></returns>
        public static string DataTableToHtml(DataTable dt)
        {
            StringBuilder newLine = new StringBuilder();
            newLine.Append("<table cellspacing=\"1\" border=\"1\">");
            //newLine.Append("<tr><td colspan=\"" + dt.Columns.Count + "\" align=\"center\">" + dt.TableName + "</td></tr>");
            newLine.Append("<tr>");
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                newLine.AppendFormat("<td>{0}</td>", dt.Columns[i].Caption);
            }
            newLine.Append("</tr>");

            for (int j = 0; j < dt.Rows.Count; j++)
            {
                newLine.Append("<tr>");

                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    newLine.AppendFormat("<td>{0}</td>", dt.Rows[j][i]);
                }
                newLine.Append("</tr>");
            }
            newLine.Append("</table>");
            return newLine.ToString();
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 创建列
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="sourceTable"></param>
        private static void CreateRow(ISheet sheet, DataTable sourceTable)
        {
            IRow headerRow = sheet.CreateRow(0);
            foreach (DataColumn column in sourceTable.Columns) //创建列
                headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);
        }

        /// <summary>
        /// 创建列
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="reader"></param>
        private static void CreateRow(ISheet sheet, IDataReader reader)
        {
            IRow headerRow = sheet.CreateRow(0);
            int cellCount = reader.FieldCount;

            // handling header.

            for (int i = 0; i < cellCount; i++)
            {
                headerRow.CreateCell(i).SetCellValue(reader.GetName(i));
            }
        }

        /// <summary>
        /// 以流的形式下载
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="type"></param>
        private static void DownloadExcel(MemoryStream stream, ExcelType type)
        {
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.AppendHeader("Content-Disposition", String.Format("attachment;filename={0}.{1}", DateTime.Now.ToString("yyyyMMdd"), type.ToString())); //导出xlsx，要引用5个dll
            //Response.AppendHeader("Content-Disposition", "attachment;filename=" + DateTime.Now.ToString("yyyyMMdd") + ".xls");//注意导出的文件格式
            HttpContext.Current.Response.ContentType = "application/excel";
            HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.UTF8;
            HttpContext.Current.Response.BinaryWrite(stream.ToArray());
            stream.Dispose();
            HttpContext.Current.Response.End();
        }

        #endregion
    }
}

#region 调用例子
/*
 //自定义下载
        private void DownloadExcel(string sql, SqlParameter[] par)
        {
            string sql = string.Format("select * from Account");
            IDataReader reader = DbHelperSQL.ExecuteReader(sql);

            MemoryStream ms = NPOIHelper.RenderToExcel(reader);
            reader.Close();

            Response.ClearContent();
            Response.AppendHeader("Content-Disposition", "attachment;filename=" + DateTime.Now.ToString("yyyyMMdd") + ".xlsx"); //导出xlsx，要引用5个dll
            //Response.AppendHeader("Content-Disposition", "attachment;filename=" + DateTime.Now.ToString("yyyyMMdd") + ".xls");//注意导出的文件格式
            Response.ContentType = "application/excel";
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            Response.BinaryWrite(ms.ToArray());

            ms.Dispose();

            Response.End();
        }
*/
/*//直接下载
     protected void btn1_OnClick(object sender, EventArgs e)
        {
            string sql = string.Format("select * from Account");
            IDataReader reader = DbHelperSQL.ExecuteReader(sql);

           NPOIHelper.DownloadExcel(reader,NPOIHelper.ExcelType.xls);
        }
 */
#endregion


#region OldCode

/*
  public static MemoryStream RenderToExcel(DataTable table)
        {
            MemoryStream ms = new MemoryStream();

            using (table)
            {
                IWorkbook workbook = new HSSFWorkbook();

                ISheet sheet = workbook.CreateSheet();

                IRow headerRow = sheet.CreateRow(0);

                // handling header.
                foreach (DataColumn column in table.Columns)
                    headerRow.CreateCell(column.Ordinal).SetCellValue(column.Caption);//If Caption not set, returns the ColumnName value

                // handling value.
                int rowIndex = 1;

                foreach (DataRow row in table.Rows)
                {
                    IRow dataRow = sheet.CreateRow(rowIndex);

                    foreach (DataColumn column in table.Columns)
                    {
                        dataRow.CreateCell(column.Ordinal).SetCellValue(row[column].ToString());
                    }

                    rowIndex++;
                }

                workbook.Write(ms);
                ms.Flush();
                ms.Position = 0;

                workbook = null;
                sheet = null;
                headerRow = null;
            }
            return ms;
        }


        public static MemoryStream RenderToExcel(IDataReader reader)
        {
            MemoryStream ms = new MemoryStream();

            using (reader)
            {
                IWorkbook workbook = new HSSFWorkbook();

                ISheet sheet = workbook.CreateSheet();

                IRow headerRow = sheet.CreateRow(0);
                int cellCount = reader.FieldCount;

                // handling header.
                for (int i = 0; i < cellCount; i++)
                {
                    headerRow.CreateCell(i).SetCellValue(reader.GetName(i));
                }

                // handling value.
                int rowIndex = 1;
                while (reader.Read())
                {
                    IRow dataRow = sheet.CreateRow(rowIndex);

                    for (int i = 0; i < cellCount; i++)
                    {
                        dataRow.CreateCell(i).SetCellValue(reader[i].ToString());
                    }

                    rowIndex++;
                }

                workbook.Write(ms);
                ms.Flush();
                ms.Position = 0;

                workbook = null;
                sheet = null;
                headerRow = null;
            }
            return ms;
        }

 */

#endregion