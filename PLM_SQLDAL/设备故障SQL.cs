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
    public class 设备故障SQL
    {
        public DataSet 按各单位查询设备故障(int ID, string 起始时间, string 截止时间, string 关键字, int Year)
        {
            if (ID > 0)
            {

                StringBuilder sb = new StringBuilder();
                sb.Append(" select TOP(200) a.ID, a.设备编号,a.设备名称, a.故障描述,a.故障时间,a.更换备件,a.故障分析 as 问题描述,");
                sb.Append("  a.维修措施 as 问题的可能影响,a.解决故障时间,a.修理费用,a.报修人,a.维修人,a.维修人数,a.维修工时,a.维修人员名单,a.原因分析, ");
                sb.Append("  a.开始维修时间,a.解决方案及计划,a. 解决故障根本问题的办法,a.完成情况 ,b.名称 from dbo.c_设备故障维修表 as a , SYS_BD_二级部门表 as b ");
                sb.Append(" where a.对应单位=b.ID and a.对应单位 = " + ID);
                if (起始时间 != "" && 截止时间 != "")
                {
                    sb.Append(" and  故障时间  between  '" + 起始时间 + "' and '" + 截止时间 + "'");
                }
                if (关键字 != "")
                {

                }
                sb.Append("  and YEAR(故障时间) = " + Year);
                sb.Append("  order by 故障时间 desc");
                return DBHelper.ExecuteDataset(DBHelper.ConnectionString, CommandType.Text, sb.ToString());
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(" select TOP(200) a.ID, a.设备编号,a.设备名称, a.故障描述,a.故障时间,a.更换备件,a.故障分析 as 问题描述,");
                sb.Append("  a.维修措施 as 问题的可能影响,a.解决故障时间,a.修理费用,a.报修人,a.维修人,a.维修人数,a.维修工时,a.维修人员名单,a.原因分析, ");
                sb.Append("  a.开始维修时间,a.解决方案及计划,a. 解决故障根本问题的办法,a.完成情况 ,b.名称 from dbo.c_设备故障维修表 as a , SYS_BD_二级部门表 as b ");
                sb.Append(" where a.对应单位=b.ID  ");
                if (起始时间 != "" && 截止时间 != "")
                {
                    sb.Append(" and  故障时间  between  '" + 起始时间 + "' and '" + 截止时间 + "'");
                }
                sb.Append("  and YEAR(故障时间) = " + Year);
                sb.Append(" order by 故障时间 desc");
                return DBHelper.ExecuteDataset(DBHelper.ConnectionString, CommandType.Text, sb.ToString());
            }

        }

        public DataSet 按各单位查询设备故障(int ID, string 关键字, int Year, int PageIndex, int PageSize)
        {
            if (ID > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(" select * from (select row_number() over(order by dbo.c_设备故障维修表.故障时间 desc) as row ,*  from c_设备故障维修表");
                sb.Append(" where ID>0 and   对应单位= " + ID);
                sb.Append(" and(设备编号 like '%" + 关键字 + "%' or 设备名称 like '%" + 关键字 + "%')");

                sb.Append("  and YEAR(故障时间) = " + Year);
                sb.Append("  )  as tt ,SYS_BD_二级部门表 where tt.对应单位 = SYS_BD_二级部门表.ID  ");
                sb.Append("and ");
                sb.Append("row between ");
                sb.Append(PageIndex * PageSize);
                sb.Append(" and ");
                sb.Append((PageIndex + 1) * PageSize);
                sb.Append(" order by row desc");
                return DBHelper.ExecuteDataset(DBHelper.ConnectionString, CommandType.Text, sb.ToString());
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(" select * from (select row_number() over(order by dbo.c_设备故障维修表.故障时间 desc) as row ,*  from c_设备故障维修表");
                sb.Append(" where ID>0   ");
                //if (起始时间 != "" && 截止时间 != "")
                //{
                //    sb.Append(" and  故障时间  between  '" + 起始时间 + "' and '" + 截止时间 + "'");
                //}
                sb.Append("  and YEAR(故障时间) = " + Year);
                sb.Append(" and(设备编号 like '%" + 关键字 + "%' or 设备名称 like '%" + 关键字 + "%')");
                sb.Append("  )  as tt ,SYS_BD_二级部门表 where tt.对应单位 = SYS_BD_二级部门表.ID  ");
                sb.Append("and ");
                sb.Append("row between ");
                sb.Append(PageIndex * PageSize);
                sb.Append(" and ");
                sb.Append((PageIndex + 1) * PageSize);
                sb.Append(" order by row desc");
                return DBHelper.ExecuteDataset(DBHelper.ConnectionString, CommandType.Text, sb.ToString());
            }

        }

        public int 查询设备故障总数(int ID, string 关键字, int Year)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select COUNT(*)  总数 from  c_设备故障维修表 WHERE ID>0 ");
            if (ID != 0)
            {
                sb.Append(" and 对应单位=" + ID);
            }
            sb.Append(" and YEAR(故障时间) =" + Year);
            sb.Append(" and(设备编号 like '%" + 关键字 + "%' or 设备名称 like '%" + 关键字 + "%')");
            return Convert.ToInt32(DBHelper.ExecuteScalar(DBHelper.ConnectionString, CommandType.Text, sb.ToString()));
        }



        public List<用户单位表> 查询二级单位()
        {
            string sql = "  SELECT * FROM SYS_BD_二级部门表 where Superior_ID = 1";
            SqlDataReader read = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sql.ToString());
            List<用户单位表> list = new List<用户单位表>();
            用户单位表 modelx = new 用户单位表();
            modelx.ID = 0;
            modelx.名称 = "全部";
            list.Add(modelx);
            while (read.Read())
            {
                用户单位表 model = new 用户单位表();
                model.ID = Convert.ToInt32(read["ID"]);
                model.名称 = read["部门名称"].ToString();
                list.Add(model);
            }
            return list;

        }
    }
}
