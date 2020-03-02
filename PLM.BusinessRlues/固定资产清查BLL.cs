using PLM_Model;
using PLM_SQLDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace PLM.BusinessRlues
{
  
    public class 固定资产清查BLL
    {
        固定资产清查SQL sql = new 固定资产清查SQL();
        public List<用户单位表> 查询用户二级单位(int ID)
        {
            return sql.查询用户二级单位(ID);
        }

        public List<Model录入盘点信息> 测试查询转向架台账数据(string rank, int ID, int PageIndex, int PageSize,string username)
        {
            return sql.测试查询转向架台账数据(rank, ID, PageIndex, PageSize,username);
        }

        public List<部门表> 查询用户所在三级部门(int ID)
        {
            return sql.查询用户所在三级部门(ID);
        }

        public int 查询盘点设备总数(string rank, int ID)
        {
            return sql.查询盘点设备总数(rank, ID);
        }

        public int 创建盘点主表(AM_盘点清查主表 model)
        {
            return sql.创建盘点主表(model);
        }

        public List<AM_盘点清查主表> 查询盘点主表()
        {
            return sql.查询盘点主表();
        }

        public int 插入已盘点设备表(List<Model录入盘点信息> listmodel)
        {
            return sql.插入已盘点设备表(listmodel);
        }

        public List<Model录入盘点信息> 查询已盘点数据(int 盘点主表ID, int 部门ID, string 关键字, string rank, string 盘点类型, int PageIndex, int PageSize)
        {
            return sql.查询已盘点数据(盘点主表ID, 部门ID, 关键字, rank, 盘点类型, PageIndex, PageSize);
        }

        public int 查询已盘点总数(int 盘点主表ID, int 部门ID, string rank, string 盘点类型)
        {
            return sql.查询已盘点总数(盘点主表ID, 部门ID, rank, 盘点类型);
        }

        public List<盘点统计> 查询盘点统计(int 盘点主表ID,string 盘点任务名称)
        {
            return sql.查询盘点统计(盘点主表ID, 盘点任务名称);
        }

        public List<盘点统计> 查询三级部门盘点信息(int 盘点主表ID, string 盘点任务名称)
        {
            return sql.查询三级部门盘点信息(盘点主表ID, 盘点任务名称);
        }
        
    }
}
