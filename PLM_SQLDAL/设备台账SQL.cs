using PLM_Common;
using PLM_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLM_SQLDAL
{
    public class 设备台账SQL
    {



        public List<Z_一级结构表> 查询一级结构()
        {
            string sql = "SELECT * from SYS_BD_一级部门表";
            SqlDataReader read = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sql.ToString());
            List<Z_一级结构表> listonejg = new List<Z_一级结构表>();
            while (read.Read())
            {
                Z_一级结构表 model = new Z_一级结构表();
                model.ID = Convert.ToInt32(read["ID"].ToString());
                model.名称 = read["部门名称"].ToString();
                model.程序显示名称 = read["部门名称"].ToString();
                listonejg.Add(model);
            }
            read.Close();
            return listonejg;
        }

        public List<AM_部门级别汇总> 查询部门汇总()
        {
            string sql = "SELECT ID,部门名称,Level from SYS_BD_一级部门表  ";
            string sqltwo = "select ID,部门名称,Superior_ID,Level from   SYS_BD_二级部门表  ";
            SqlDataReader read = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sql.ToString());
            List<AM_部门级别汇总> listmodel = new List<AM_部门级别汇总>();
            while (read.Read())
            {
                AM_部门级别汇总 model = new AM_部门级别汇总();
                model.ID = Convert.ToInt32(read["ID"].ToString());
                model.部门名称 = read["部门名称"].ToString();
                model.Lever = Convert.ToInt32(read["Level"].ToString());
                listmodel.Add(model);
            }
            read.Close();
            return listmodel;
        }



        public List<用户单位表> 查询二级结构(int 一级结构ID)
        {
            string sql = string.Format("SELECT * from SYS_BD_二级部门表 where Superior_ID ={0}   order by 部门名称 desc", 一级结构ID);
            SqlDataReader read = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sql.ToString());
            List<用户单位表> listyhdw = new List<用户单位表>();
            while (read.Read())
            {
                用户单位表 model = new 用户单位表();
                model.ID = Convert.ToInt32(read["ID"].ToString());
                model.名称 = read["部门名称"].ToString();
                model.成本中心 = read["Cost_center_number"].ToString();
                model.一级结构 = Convert.ToInt32(read["Superior_ID"].ToString());
                listyhdw.Add(model);
            }
            read.Close();
            return listyhdw;

        }

        public int 查询设备总数()
        {
            string sql = "SELECT COUNT(*) as 总数 FROM 设备_设备信息表";
            return Convert.ToInt32(DBHelper.ExecuteScalar(DBHelper.ConnectionString, CommandType.Text, sql));
        }
        public int 查询故障设备总数()
        {
            string sql = " SELECT COUNT(*) as 总数 FROM c_设备故障维修表 WHERE 完成情况 = '正在进行'";
            return Convert.ToInt32(DBHelper.ExecuteScalar(DBHelper.ConnectionString, CommandType.Text, sql));

        }

        public List<部门表> 查询三级结构(int 二级结构ID)
        {
            string sql = string.Format("SELECT * from SYS_BD_三级部门表 where Superior_ID ={0}", 二级结构ID);
            SqlDataReader read = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sql.ToString());
            List<部门表> listbm = new List<部门表>();
            while (read.Read())
            {
                部门表 model = new 部门表();
                model.ID = Convert.ToInt32(read["ID"].ToString());
                model.名称 = read["部门名称"].ToString();
                model.成本中心 = read["Cost_center_number"].ToString();
                listbm.Add(model);
            }
            read.Close();
            return listbm;
        }

        public DataSet 查询树结构设备台账(int ID, string rank)
        {
            if (rank == "一级")
            {
                return null;
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT A.*,B.部门名称 AS 部门名称, C.部门名称 AS 单位名称 FROM	 ");
                sb.Append("设备_设备信息表 AS A ,dbo.SYS_BD_二级部门表 AS B , dbo.SYS_BD_三级部门表 AS C where A.使用单位 = C.ID and  b.ID=C.Superior_ID ");
                if (rank == "二级")
                {
                    sb.Append("and B.ID =" + ID);
                }
                else if (rank == "三级")
                {
                    sb.Append("and C.ID =" + ID);
                }
                return DBHelper.ExecuteDataset(DBHelper.ConnectionString, CommandType.Text, sb.ToString());
            }
        }

        public int 树形结构查询设备总数(int ID, string rank)
        {

            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT COUNT(*) 总数 FROM	 ");
            sb.Append("设备_设备信息表 AS A ,dbo.SYS_BD_二级部门表 AS B , dbo.SYS_BD_三级部门表 AS C where A.使用单位 = C.ID and b.ID=C.Superior_ID ");
            if (rank == "二级")
            {
                sb.Append("and B.ID =" + ID);
            }
            else if (rank == "三级")
            {
                sb.Append("and C.ID =" + ID);
            }
            return Convert.ToInt32(DBHelper.ExecuteScalar(DBHelper.ConnectionString, CommandType.Text, sb.ToString()));

        }

        public int 树形结构查询设备故障总数(int ID, string rank)
        {
            string sql = "";
            if (rank == "二级")
            {
                sql = string.Format("SELECT COUNT(*) as 总数 FROM c_设备故障维修表 WHERE  完成情况 = '正在进行' AND 对应单位={0}", ID);
                return Convert.ToInt32(DBHelper.ExecuteScalar(DBHelper.ConnectionString, CommandType.Text, sql.ToString()));
            }
            else
            {
                return 0;
            }
            //else if(rank=="三级")
            //{
            //    string cidsql = string.Format("SELECT 所属单位 FROM 部门表 where ID ={0}",ID);
            //    int cid = Convert.ToInt32(DBHelper.ExecuteScalar(DBHelper.ConnectionString, CommandType.Text, cidsql.ToString()));


            //}

        }

        public DataSet 设备名称关联备件(string sbmc, int 所属单位)
        {
            string sql = string.Format("select 成本中心 from dbo.SYS_BD_三级部门表 where ID = {0}", 所属单位);
            string 成本中心 = "";
            SqlDataReader read = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sql.ToString());
            while (read.Read())
            {
                成本中心 = read["Cost_center_number"].ToString();
            }
            read.Close();
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT     a.ID, a.物料号, a.备件名称, a.规格型号, a.计量单位, a.管理类别, b.成本中心, b.提报单位, SUM(b.剩余数量) AS 库存, SUM(b.剩余数量 * b.价格) ");
            sb.Append(" AS 总金额, a.备注 FROM         b_备件_信息表 AS a INNER JOIN");
            sb.Append(" b_备件_导入日志表 AS b ON a.物料号 = b.物料号 ");
            sb.Append("WHERE     (a.物料号 IN  (SELECT DISTINCT 物料号 FROM b_备件_设备关联表");
            sb.Append(" WHERE (名称 = '" + sbmc + "'))) AND (b.成本中心 = '" + 成本中心 + "')");

            sb.Append("GROUP BY a.ID, a.物料号, a.备件名称, a.规格型号, a.计量单位, a.管理类别, b.成本中心, b.提报单位, a.备注");
            sb.Append(" ORDER BY LEN(a.物料号), a.物料号");

            //sb.Append("select a.物料号, a.备件名称, a.规格型号 ,b.提报单位 from (b_备件_信息表 as a inner join b_备件_导入日志表 as b on a.物料号 = b.物料号) ");
            //sb.Append(" inner join b_备件_设备关联表 as c on a.物料号 = c.物料号 where  c.名称 = '" + sbmc + "' group by c.ID,a.物料号,a.备件名称,a.规格型号,b.提报单位 ");
            //sb.Append(" order by LEN(a.物料号), a.物料号");
            return DBHelper.ExecuteDataset(DBHelper.ConnectionString, CommandType.Text, sb.ToString());
        }

        public DataSet 设备编号关联维修情况(string sbbh)
        {
            string sql = string.Format("SELECT * FROM dbo.c_设备故障维修表 where 设备编号='{0}' ORDER BY 故障时间 desc  ", sbbh);
            return DBHelper.ExecuteDataset(DBHelper.ConnectionString, CommandType.Text, sql);
        }
        public DataSet 设备编号查询备件消耗(string sbbh)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select b.物料号,c.备件名称, sum(a.操作数量) as 操作数量 from b_备件_记录表 as a inner join b_备件_导入日志表 as b ");
            sb.Append(" on a.日志ID = b.ID and a.设备编号 = '" + sbbh + "' inner join b_备件_信息表 as c on b.物料号 =c.物料号 ");
            sb.Append("group by b.物料号, c.备件名称 order by 操作数量 desc");
            return DBHelper.ExecuteDataset(DBHelper.ConnectionString, CommandType.Text, sb.ToString());
        }

        public string 查询所有年份()
        {
            string 年份 = "";
            //先查询投入使用时间
            string sql = "SELECT  distinct YEAR(故障时间) as 时间  FROM dbo.c_设备故障维修表  ORDER BY 时间 desc  ";
            SqlDataReader read = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sql.ToString());
            while (read.Read())
            {
                年份 += read["时间"] + ",";
            }
            read.Close();
            return 年份;
        }

        public string 查询设备故障年份(string sbbh)
        {
            string 年份 = "";
            string sql = string.Format("SELECT distinct YEAR(故障时间) as 时间  FROM dbo.c_设备故障维修表 where 设备编号='{0}'  ORDER BY 时间 desc ", sbbh);
            SqlDataReader read = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sql.ToString());
            while (read.Read())
            {
                年份 += read["时间"] + ",";
            }
            read.Close();
            return 年份;

        }

        public List<设备故障维修表> 设备编号查询设备故障信息(string sbbh)
        {
            string sql = string.Format("SELECT *  FROM dbo.c_设备故障维修表 where 设备编号='{0}'  ORDER BY 故障时间 desc ", sbbh);
            SqlDataReader read = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sql.ToString());
            List<设备故障维修表> listmodel = new List<设备故障维修表>();
            while (read.Read())
            {
                设备故障维修表 model = new 设备故障维修表();
                model.故障时间 = Convert.ToDateTime(read["故障时间"]);
                model.故障描述 = read["故障描述"].ToString();
                model.更换备件 = read["更换备件"].ToString();
                listmodel.Add(model);
            }
            read.Close();
            return listmodel;
        }

        //public string 查询单台设备平均故障时间(string sbbh,string bw)
        //{
        //    string sql = string.Format("SELECT 设备编号,设备名称,更换备件,故障描述,故障分析,故障时间,解决故障时间,维修人,维修人员名单,维修工时,维修人数,解决方案及计划,原因分析,解决故障根本问题的办法 from  c_设备故障维修表 where 设备编号 = '{0}'   and (故障描述 like '%{1}%' or 故障分析 like '%{1}%')   order by 故障时间  ",sbbh,bw);
        //    SqlDataReader read = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sql.ToString());
        //    List<设备故障维修表> listmodel = new List<设备故障维修表>();
        //    DateTime jjgz = DateTime.Now;
        //    int i = 0;
        //    int daydiff = 0;
        //    while (read.Read())
        //    {
        //        if (i == 0)
        //        {
        //            //第一次进入
        //            设备故障维修表 model = new 设备故障维修表();
        //            DateTime 故障时间 = Convert.ToDateTime(read["故障时间"]);
        //            DateTime 解决故障时间 = Convert.ToDateTime(read["解决故障时间"]);
        //            jjgz = 解决故障时间;

        //        }
        //        else 
        //        {
        //            DateTime 故障时间 = Convert.ToDateTime(read["故障时间"]);
        //            TimeSpan span = 故障时间.Subtract(jjgz);
        //            daydiff += span.Days+1;
        //            DateTime 解决故障时间 = Convert.ToDateTime(read["解决故障时间"]);
        //            jjgz = 解决故障时间;
        //        }
        //        i++;

        //    }
        //    read.Close();
        //    //查询总数
        //    string sqlcount = string.Format(" SELECT COUNT(*) as 总数 from  c_设备故障维修表 where 设备编号 = '{0}'   and (故障描述 like '%{1}%' or 故障分析 like '%{1}%')  ",sbbh,bw);
        //    int gzcount = Convert.ToInt32(DBHelper.ExecuteScalar(DBHelper.ConnectionString, CommandType.Text, sqlcount));
        //    int gzjgsj = daydiff / (gzcount-1);
        //    return "设备编号:" + sbbh + ",部位" + bw + "平均故障间隔时间" + gzjgsj;
        //}


        public List<预防性维修> 查询设备编号平均故障时间(string sqlwhsbbh)
        {
            string sql = string.Format(" SELECT * from dbo.Z_设备编号部位表  where 设备编号 =  '{0}'", sqlwhsbbh);
            SqlDataReader read = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sql.ToString());
            string 部位字符串 = "";
            while (read.Read())
            {
                部位字符串 = read["部位字符串"].ToString();
            }
            if (部位字符串 == "" || 部位字符串 == null)
            {
                return null;
            }
            read.Close();
            string[] sArray = 部位字符串.Split(',');
            List<预防性维修> modelyufxwx = new List<预防性维修>();
            foreach (string item in sArray)
            {
                string sqlsbgz = string.Format("SELECT 设备编号,设备名称,更换备件,故障描述,故障分析,故障时间,解决故障时间,维修人,维修人员名单,维修工时,维修人数,解决方案及计划,原因分析,解决故障根本问题的办法 from  c_设备故障维修表 where 设备编号 = '{0}'  and  解决故障时间  is not null   and (故障描述 like '%{1}%' or 故障分析 like '%{1}%')   order by 故障时间  ", sqlwhsbbh, item);
                SqlDataReader readsbgz = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sqlsbgz.ToString());

                DateTime jjgz = DateTime.Now;
                int i = 0;
                int daydiff = 0;
                double 维修时长 = 0;
                string 设备类型 = "";
                while (readsbgz.Read())
                {
                    if (i == 0)
                    {
                        //第一次进入
                        //sbbh = readsbgz["设备编号"].ToString();
                        DateTime 故障时间 = Convert.ToDateTime(readsbgz["故障时间"]);
                        DateTime 解决故障时间 = Convert.ToDateTime(readsbgz["解决故障时间"]);
                        维修时长 += Convert.ToDouble(readsbgz["维修工时"]);
                        设备类型 = readsbgz["设备名称"].ToString();
                        jjgz = 解决故障时间;

                    }
                    else
                    {
                        维修时长 += Convert.ToDouble(readsbgz["维修工时"]);
                        DateTime 故障时间 = Convert.ToDateTime(readsbgz["故障时间"]);
                        TimeSpan span = 故障时间.Subtract(jjgz);
                        daydiff += span.Days + 1;
                        DateTime 解决故障时间 = Convert.ToDateTime(readsbgz["解决故障时间"]);
                        jjgz = 解决故障时间;
                    }
                    i++;

                }
                string sqlcount = string.Format(" SELECT COUNT(*) as 总数 from  c_设备故障维修表 where 设备编号 = '{0}' and  解决故障时间  is not null   and (故障描述 like '%{1}%' or 故障分析 like '%{1}%')  ", sqlwhsbbh, item);
                int gzcount = Convert.ToInt32(DBHelper.ExecuteScalar(DBHelper.ConnectionString, CommandType.Text, sqlcount));
                int gzjgsj = daydiff / (gzcount - 1);

                预防性维修 model = new 预防性维修();
                model.部位 = item;
                //model.设备编号 = sbbh;
                model.设备类型 = 设备类型;
                model.设备编号 = sqlwhsbbh;
                model.故障时间间隔 = gzjgsj;
                model.平均维修时长 = (维修时长 / gzcount);
                model.平均维修时长 = Math.Round(model.平均维修时长, 2);
                modelyufxwx.Add(model);

            }
            return modelyufxwx;

        }


        public List<预防性维修> 查询设备平均故障时间(string sblx)
        {
            string sql = string.Format(" SELECT a.设备类型,b.部位字符串 FROM Z_设备类型表 as a ,Z_设备部件表 as b where a.ID = b.设备类型  and a.设备类型 = '{0}'", sblx);
            SqlDataReader read = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sql.ToString());
            string 部位字符串 = "";
            while (read.Read())
            {
                部位字符串 = read["部位字符串"].ToString().Trim();
            }
            read.Close();
            string[] sArray = 部位字符串.Split(',');
            List<预防性维修> modelyufxwx = new List<预防性维修>();
            foreach (string item in sArray)
            {
                string sqlsbgz = string.Format("SELECT 设备编号,设备名称,更换备件,故障描述,故障分析,故障时间,解决故障时间,维修人,维修人员名单,维修工时,维修人数,解决方案及计划,原因分析,解决故障根本问题的办法 from  c_设备故障维修表 where 设备名称 = '{0}'  and  解决故障时间  is not null   and (故障描述 like '%{1}%' or 故障分析 like '%{1}%')   order by 故障时间  ", sblx, item);
                SqlDataReader readsbgz = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sqlsbgz.ToString());

                DateTime jjgz = DateTime.Now;
                int i = 0;
                int daydiff = 0;
                double 维修时长 = 0;
                int 维修人数 = 0;
                while (readsbgz.Read())
                {
                    if (i == 0)
                    {
                        //第一次进入
                        //sbbh = readsbgz["设备编号"].ToString();
                        DateTime 故障时间 = Convert.ToDateTime(readsbgz["故障时间"]);
                        DateTime 解决故障时间 = Convert.ToDateTime(readsbgz["解决故障时间"]);
                        维修时长 += Convert.ToDouble(readsbgz["维修工时"]);
                        维修人数 += Convert.ToInt32(readsbgz["维修人数"]);
                        jjgz = 解决故障时间;

                    }
                    else
                    {
                        维修时长 += Convert.ToDouble(readsbgz["维修工时"]);
                        维修人数 += Convert.ToInt32(readsbgz["维修人数"]);
                        DateTime 故障时间 = Convert.ToDateTime(readsbgz["故障时间"]);
                        TimeSpan span = 故障时间.Subtract(jjgz);
                        daydiff += span.Days + 1;
                        DateTime 解决故障时间 = Convert.ToDateTime(readsbgz["解决故障时间"]);
                        jjgz = 解决故障时间;
                    }
                    i++;

                }
                string sqlcount = string.Format(" SELECT COUNT(*) as 总数 from  c_设备故障维修表 where 设备名称 = '{0}' and  解决故障时间  is not null   and (故障描述 like '%{1}%' or 故障分析 like '%{1}%')  ", sblx, item);
                int gzcount = Convert.ToInt32(DBHelper.ExecuteScalar(DBHelper.ConnectionString, CommandType.Text, sqlcount));
                int gzjgsj = daydiff / (gzcount - 1);

                预防性维修 model = new 预防性维修();
                model.部位 = item;
                //model.设备编号 = sbbh;
                model.设备类型 = sblx;
                model.故障时间间隔 = gzjgsj;
                model.平均维修时长 = (维修时长 / gzcount);
                if (维修人数 != 0)
                {
                    model.平均维修人数 = (维修人数 / gzcount);
                }

                model.平均维修时长 = Math.Round(model.平均维修时长, 2);
                modelyufxwx.Add(model);

            }
            return modelyufxwx;

        }

        public DataSet 模糊查询设备信息(string str)
        {
            string sql = string.Format("   SELECT 设备编号,设备名称,设备型号 from 设备_设备信息表  where (设备编号 like '%{0}%' or 设备名称 like '%{0}%') ", str);
            return DBHelper.ExecuteDataset(DBHelper.ConnectionString, CommandType.Text, sql);
        }


    }
}
