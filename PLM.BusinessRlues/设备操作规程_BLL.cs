using PLM_Model;
using PLM_SQLDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace PLM.BusinessRlues
{
    public class 设备操作规程_BLL
    {
        设备操作规程_SQL sql = new 设备操作规程_SQL();
        public DataSet 文件上传功能(int deviceType, string fileName, string newfile, string nowTime, string houzhuiming)
        {
            return sql.文件上传功能(deviceType, fileName, newfile, nowTime, houzhuiming);
        }
        public DataSet 文件上传查询()
        {
            return sql.文件上传查询();
        }

        public DataSet 查询设备类型(string s_search)
        {
            return sql.查询设备类型(s_search);
        }
        public List<Z_设备类型表> 查询设备类型()
        {
            return sql.查询设备类型();
        }
        public DataSet 设备操作规程查询(string sSearch)
        {
            return sql.设备操作规程查询(sSearch);
        }

        public DataSet 设备操作规程模糊查询(string sSearchs)
        {
            return sql.设备操作规程模糊查询(sSearchs);
        }
        //public DataSet 删除上传数据(string fileName)
        //{
        //    return sql.删除上传数据(fileName);
        //}
    }
}
