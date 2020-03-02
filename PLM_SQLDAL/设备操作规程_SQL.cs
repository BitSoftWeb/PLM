using PLM_Common;
using PLM_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace PLM_SQLDAL
{
    public class 设备操作规程_SQL
    {
        public DataSet 文件上传功能(int deviceType, string fileName, string newfile, string nowTime, string houzhuiming)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("");
            sb.Append("INSERT INTO ZJ_设备操作规范表");
            sb.Append("(设备类型,设备操作规程,新设备操作规程,上传时间,文件类型");
            sb.Append(")VALUES(");
            sb.Append("" + deviceType + ",'" + fileName + "','" + newfile + "','" + nowTime + "','" + houzhuiming + "')");
            return DBHelper.ExecuteDataset(DBHelper.ConnectionString, CommandType.Text, sb.ToString());
        }


        public DataSet 文件上传查询()
        {
            StringBuilder sb = new StringBuilder();
            //sb.Append("select * from ZJ_设备操作规范表");
            sb.Append("select a.ID,a.设备类型,a.设备操作规程,a.上传时间,a.新设备操作规程,a.文件类型,b.设备类型 as 设备类型s from ZJ_设备操作规范表 as a,Z_设备类型表 as b where a.设备类型=b.ID order by a.ID ASC");
            return DBHelper.ExecuteDataset(DBHelper.ConnectionString, CommandType.Text, sb.ToString());
        }

        //List<Z_设备类型表> sbmc = sbczgcbll.查询设备类型();
        public DataSet 查询设备类型(string s_search)
        {
            StringBuilder sb = new StringBuilder();
            //sb.Append("select * from ZJ_设备操作规范表");
            sb.Append("SELECT * FROM Z_设备类型表");
            if (s_search == "")
            {
                sb.Append("");
            }
            else
            {
                sb.Append(" and a.设备类型 like '%" + s_search + "%'");
            }
            return DBHelper.ExecuteDataset(DBHelper.ConnectionString, CommandType.Text, sb.ToString());
        }

        public List<Z_设备类型表> 查询设备类型()
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("SELECT * FROM Z_设备类型表");

                SqlDataReader read = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sb.ToString());

                List<Z_设备类型表> list = new List<Z_设备类型表>();
                Z_设备类型表 modelx = new Z_设备类型表();
                modelx.ID = 0;
                modelx.设备类型 = "全部";
                list.Add(modelx);
                while (read.Read())
                {
                    Z_设备类型表 model = new Z_设备类型表();
                    model.ID = Convert.ToInt32(read["ID"]);

                    model.设备类型 = read["设备类型"].ToString();
                    list.Add(model);
                }
                return list;
            }
            catch (Exception)
            {
                throw;
            }

        }


        public DataSet 设备操作规程查询(string sSearch)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select a.设备类型,a.设备操作规程,a.上传时间,a.新设备操作规程,a.文件类型,b.设备类型 from ZJ_设备操作规范表 as a,Z_设备类型表 as b");
            sb.Append("  where a.设备类型=b.ID ");
            if (sSearch == "")
            {
                sb.Append("");
            }
            else
            {
                sb.Append(" and a.设备操作规程 like '%" + sSearch + "%'");
            }
            return DBHelper.ExecuteDataset(DBHelper.ConnectionString, CommandType.Text, sb.ToString());

        }

        public DataSet 设备操作规程模糊查询(string sSearchs)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT  * FROM Z_设备类型表 ");
            sb.Append("where 1=1 ");
            if (sSearchs == "")
            {
                sb.Append("");
            }
            else
            {
                sb.Append(" and 设备类型 like '%" + sSearchs + "%'");
            }
            return DBHelper.ExecuteDataset(DBHelper.ConnectionString, CommandType.Text, sb.ToString());
        }
    }
}
