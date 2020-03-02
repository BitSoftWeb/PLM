using PLM_SQLDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace PLM.BusinessRlues
{
    
    public class 备件统计分析BLL
    {
        备件统计分析SQL SQL = new 备件统计分析SQL();
        public DataSet lastYear(string sql)
        {
            return SQL.lastYear(sql);
        }
        public DataSet NowYear(string sql)
        {
            return SQL.NowYear(sql);
        }

        public DataSet 返回DataSet(string sql) 
        {
            return SQL.返回DataSet(sql);
        }

        
    }
}
