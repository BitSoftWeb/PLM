using PLM_Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace PLM_SQLDAL
{
    public class 备件统计分析SQL
    {
        public DataSet lastYear(string sql)
        {

            return DBHelper.ExecuteDataset(DBHelper.ConnectionString, CommandType.Text, sql.ToString());

        }

        public DataSet NowYear(string sql)
        {
            return DBHelper.ExecuteDataset(DBHelper.ConnectionString, CommandType.Text, sql.ToString());
        }

        public DataSet 返回DataSet(string sql)
        {
            return DBHelper.ExecuteDataset(DBHelper.ConnectionString, CommandType.Text, sql.ToString());
        }
    }
}
