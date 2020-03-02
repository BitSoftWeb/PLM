using PLM_Model;
using PLM_SQLDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace PLM.BusinessRlues
{

    public class 设备故障BLL
    {
        设备故障SQL sql = new 设备故障SQL();

        public DataSet 按各单位查询设备故障(int ID, string 起始时间, string 截止时间, string 关键字, int Year)
        {
            return sql.按各单位查询设备故障(ID, 起始时间, 截止时间, 关键字, Year);
        }
        public DataSet 按各单位查询设备故障(int ID, string 关键字, int Year, int PageIndex, int PageSize)
        {
            return sql.按各单位查询设备故障(ID, 关键字, Year, PageIndex, PageSize);
        }
        public int 查询设备故障总数(int ID, string 关键字, int Year) 
        {
            return sql.查询设备故障总数(ID,关键字,Year);
        }


        public List<用户单位表> 查询二级单位()
        {
            return sql.查询二级单位();
        }
    }
}
