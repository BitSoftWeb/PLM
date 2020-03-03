using PLM_Model;
using PLM_SQLDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLM_BusinessRlues
{
    public class 设备台账BLL
    {
        设备台账SQL sql = new 设备台账SQL();
        public DataSet 查询树结构设备台账(int ID,string rank)
        {
            return sql.查询树结构设备台账(ID,rank);
        }

   

        public List<用户单位表> 查询二级结构(int ID) 
        {
            return sql.查询二级结构(ID);
        }

        public List<Z_一级结构表> 查询一级结构() 
        {
            return sql.查询一级结构();
        }


        

        public int 查询设备总数()
        {
            return sql.查询设备总数();
        }
        public int 树形结构查询设备总数(int ID, string rank)
        {
            return sql.树形结构查询设备总数(ID,rank);
        }

        public int 树形结构查询设备故障总数(int ID, string rank)
        {
            return sql.树形结构查询设备故障总数(ID, rank);
        }
        
        

        public int 查询故障设备总数()
        {
            return sql.查询故障设备总数();
        }

        public List<部门表> 查询三级结构(int 二级结构ID)
        {
            return sql.查询三级结构(二级结构ID);
        }

        public DataSet 设备名称关联备件(string sbmc,int 所属单位) 
        {
            return sql.设备名称关联备件(sbmc,所属单位);
        }
        public DataSet 设备编号关联维修情况(string sbbh) 
        {
            return sql.设备编号关联维修情况(sbbh);
        }

        public DataSet 设备编号查询备件消耗(string sbbh)
        {
            return sql.设备编号查询备件消耗(sbbh);
        }

        public string 查询所有年份() 
        {
            return sql.查询所有年份();
        }
        public string 查询设备故障年份(string sbbh) 
        {
            return sql.查询设备故障年份(sbbh);
        }
        public List<设备故障维修表> 设备编号查询设备故障信息(string sbbh) 
        {
            return sql.设备编号查询设备故障信息(sbbh);
        }

        //public string 查询单台设备平均故障时间(string sbbh, string bw)
        //{
        //    return sql.查询单台设备平均故障时间(sbbh, bw);
        //}
        public List<预防性维修> 查询设备平均故障时间(string 设备类型)
        {
            return sql.查询设备平均故障时间(设备类型);
        }
        public List<预防性维修> 查询设备编号平均故障时间(string 设备编号)
        {
            return sql.查询设备编号平均故障时间(设备编号);
        }

        public DataSet 模糊查询设备信息(string str)
        {
            return sql.模糊查询设备信息(str);
        }
        
    }
}
