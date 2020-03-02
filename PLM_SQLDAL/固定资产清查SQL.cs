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
    public class 固定资产清查SQL
    {
        //根据用户二级部门查询所在二级部门

        public List<用户单位表> 查询用户二级单位(int ID)
        {
            string sql = string.Format("SELECT * FROM 用户_单位表 where ID = {0}", ID);
            SqlDataReader read = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sql.ToString());
            List<用户单位表> list = new List<用户单位表>();
            //用户单位表 modelx = new 用户单位表();
            //modelx.ID = 0;
            //modelx.名称 = "全部";
            //list.Add(modelx);
            while (read.Read())
            {
                用户单位表 model = new 用户单位表();
                model.ID = Convert.ToInt32(read["ID"]);
                model.名称 = read["名称"].ToString();
                list.Add(model);
            }
            return list;

        }

        public List<部门表> 查询用户所在三级部门(int ID)
        {
            string sql = string.Format("select * from 部门表 where 所属单位 = {0}", ID);
            SqlDataReader read = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sql.ToString());
            List<部门表> list = new List<部门表>();
            部门表 modelx = new 部门表();
            modelx.ID = 0;
            modelx.名称 = "全部";
            list.Add(modelx);
            while (read.Read())
            {
                部门表 model = new 部门表();
                model.ID = Convert.ToInt32(read["ID"]);
                model.名称 = read["名称"].ToString();
                list.Add(model);
            }
            return list;
        }

        public List<Model录入盘点信息> 查询已盘点数据(int 盘点主表ID, int 部门ID, string 关键字, string rank, string 盘点类型, int PageIndex, int PageSize)
        {
            if (rank != "全部")
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("select * from (select row_number() over(order by 设备_设备信息表.ID) as row,  ");
                sb.Append("设备_设备信息表.ID,设备_设备信息表.SAP编号,设备_设备信息表.设备编号,设备_设备信息表.设备名称,设备_设备信息表.设备型号,");
                sb.Append(" 设备_设备信息表.制造商,设备_设备信息表.投产时间,设备_设备信息表.设备规格, b.ID as 已盘点ID ,b.盘点主表ID,b.二级部门ID,b.三级部门ID,b.二级部门名称 ");
                sb.Append(" ,b.三级部门名称,b.操作人,b.操作日期,b.盘点类型,b.帐物是否相符,b.盘盈或盘亏简要原因,b.闲置或待报废简要原因 ");
                sb.Append(" from 设备_设备信息表 , AM_已盘点设备表 as b  where b.设备编号 = 设备_设备信息表.设备编号 and 盘点主表ID =" + 盘点主表ID);
                sb.Append(" and b.三级部门ID =" + 部门ID);
                sb.Append(" and b.盘点类型='"+盘点类型+"'");
                sb.Append(" )as tt  ");
                sb.Append(" where");
                sb.Append(" row between ");
                sb.Append(PageIndex * PageSize);
                sb.Append(" and ");
                sb.Append((PageIndex + 1) * PageSize);
                sb.Append(" order by row desc");
                SqlDataReader read = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sb.ToString());
                List<Model录入盘点信息> list = new List<Model录入盘点信息>();
                while (read.Read())
                {
                    Model录入盘点信息 model = new Model录入盘点信息();
                    model.ID = Convert.ToInt32(read["ID"]);
                    model.SAP编号 = read["SAP编号"].ToString();
                    model.设备编号 = read["设备编号"].ToString();
                    model.设备名称 = read["设备名称"].ToString();
                    model.设备型号 = read["设备型号"].ToString();
                    model.制造商 = read["制造商"].ToString();
                    model.投产时间 = read["投产时间"].ToString();
                    model.三级部门ID = Convert.ToInt32(read["三级部门ID"]);
                    model.设备规格 = read["设备规格"].ToString();
                    model.三级部门名称 = read["三级部门名称"].ToString();
                    model.二级部门名称 = read["二级部门名称"].ToString();
                    model.二级部门ID = Convert.ToInt32(read["二级部门ID"]);
                    model.操作人 = read["操作人"].ToString();
                    model.帐物是否相符 = read["帐物是否相符"].ToString();
                    model.闲置或待报废简要原因 = read["闲置或待报废简要原因"].ToString();
                    model.盘盈或盘亏简要原因 = read["盘盈或盘亏简要原因"].ToString();
                    model.操作日期 = read["操作日期"].ToString();
                    model.盘点类型 = read["盘点类型"].ToString();
                    list.Add(model);
                }
                return list;

            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("select * from (select row_number() over(order by 设备_设备信息表.ID) as row,  ");
                sb.Append("设备_设备信息表.ID,设备_设备信息表.SAP编号,设备_设备信息表.设备编号,设备_设备信息表.设备名称,设备_设备信息表.设备型号,");
                sb.Append(" 设备_设备信息表.制造商,设备_设备信息表.投产时间,设备_设备信息表.设备规格, b.ID as 已盘点ID ,b.盘点主表ID,b.二级部门ID,b.三级部门ID,b.二级部门名称 ");
                sb.Append(" ,b.三级部门名称,b.操作人,b.操作日期,b.盘点类型,b.帐物是否相符,b.盘盈或盘亏简要原因,b.闲置或待报废简要原因 ");
                sb.Append(" from 设备_设备信息表 , AM_已盘点设备表 as b  where b.设备编号 = 设备_设备信息表.设备编号 and 盘点主表ID =" + 盘点主表ID);
                sb.Append(" and b.二级部门ID =" + 部门ID);
                sb.Append(" and b.盘点类型='" + 盘点类型 + "'");
                sb.Append(" )as tt  ");
                sb.Append(" where");
                sb.Append(" row between ");
                sb.Append(PageIndex * PageSize);
                sb.Append(" and ");
                sb.Append((PageIndex + 1) * PageSize);
                sb.Append(" order by row desc");
                SqlDataReader read = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sb.ToString());
                List<Model录入盘点信息> list = new List<Model录入盘点信息>();
                while (read.Read())
                {
                    Model录入盘点信息 model = new Model录入盘点信息();
                    model.ID = Convert.ToInt32(read["ID"]);
                    model.SAP编号 = read["SAP编号"].ToString();
                    model.设备编号 = read["设备编号"].ToString();
                    model.设备名称 = read["设备名称"].ToString();
                    model.设备型号 = read["设备型号"].ToString();
                    model.制造商 = read["制造商"].ToString();
                    model.投产时间 = read["投产时间"].ToString();
                    model.三级部门ID = Convert.ToInt32(read["三级部门ID"]);
                    model.设备规格 = read["设备规格"].ToString();
                    model.三级部门名称 = read["三级部门名称"].ToString();
                    model.二级部门名称 = read["二级部门名称"].ToString();
                    model.二级部门ID = Convert.ToInt32(read["二级部门ID"]);
                    model.操作人 = read["操作人"].ToString();
                    model.帐物是否相符 = read["帐物是否相符"].ToString();
                    model.闲置或待报废简要原因 = read["闲置或待报废简要原因"].ToString();
                    model.盘盈或盘亏简要原因 = read["盘盈或盘亏简要原因"].ToString();
                    model.操作日期 = read["操作日期"].ToString();
                    model.盘点类型 = read["盘点类型"].ToString();
                    list.Add(model);
                }
                return list;
            }
        }

        public List<Model录入盘点信息> 测试查询转向架台账数据(string rank, int ID, int PageIndex, int PageSize, string username)
        {
            if (rank != "全部")
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("  select * from (select row_number() over(order by 设备_设备信息表.ID) as row,");
                sb.Append("  设备_设备信息表.ID,设备_设备信息表.SAP编号,设备_设备信息表.设备编号,设备_设备信息表.设备名称");
                sb.Append("  ,设备_设备信息表.设备型号,设备_设备信息表.制造商,设备_设备信息表.投产时间,设备_设备信息表.使用单位,");
                sb.Append(" 设备_设备信息表.设备规格,bm.名称 as 三级部门名称 ,bm.ID as 三级部门ID ,copy.名称 as 二级部门名称 ,copy.ID as 二级部门ID");
                sb.Append(" from 设备_设备信息表,  dbo.用户_单位表 AS copy , dbo.部门表 as bm");
                sb.Append("  where  设备_设备信息表.使用单位=  bm.ID and bm.所属单位 =copy.ID and bm.ID =" + ID + "");

                sb.Append("  and 设备编号 not in (SELECT 设备编号 FROM  AM_已盘点设备表 where 三级部门ID=" + ID);
                sb.Append(")) as tt");
                sb.Append(" where");
                sb.Append(" row between ");
                sb.Append(PageIndex * PageSize);
                sb.Append(" and ");
                sb.Append((PageIndex + 1) * PageSize);
                sb.Append(" order by row desc");
                SqlDataReader read = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sb.ToString());
                List<Model录入盘点信息> list = new List<Model录入盘点信息>();
                while (read.Read())
                {
                    Model录入盘点信息 model = new Model录入盘点信息();
                    model.ID = Convert.ToInt32(read["ID"]);
                    model.SAP编号 = read["SAP编号"].ToString();
                    model.设备编号 = read["设备编号"].ToString();
                    model.设备名称 = read["设备名称"].ToString();
                    model.设备型号 = read["设备型号"].ToString();
                    model.制造商 = read["制造商"].ToString();
                    model.投产时间 = read["投产时间"].ToString();
                    model.三级部门ID = Convert.ToInt32(read["三级部门ID"]);
                    model.设备规格 = read["设备规格"].ToString();
                    model.三级部门名称 = read["三级部门名称"].ToString();
                    model.二级部门名称 = read["二级部门名称"].ToString();
                    model.二级部门ID = Convert.ToInt32(read["二级部门ID"]);
                    model.操作人 = username;
                    model.帐物是否相符 = "是";
                    model.闲置或待报废简要原因 = "";
                    model.盘盈或盘亏简要原因 = "";
                    list.Add(model);
                }
                return list;
            }
            else
            {
                //传全部数据
                StringBuilder sb = new StringBuilder();
                sb.Append("  select * from (select row_number() over(order by 设备_设备信息表.ID) as row,");
                sb.Append("  设备_设备信息表.ID,设备_设备信息表.SAP编号,设备_设备信息表.设备编号,设备_设备信息表.设备名称");
                sb.Append("  ,设备_设备信息表.设备型号,设备_设备信息表.制造商,设备_设备信息表.投产时间,设备_设备信息表.使用单位,");
                sb.Append(" 设备_设备信息表.设备规格,bm.名称 as 三级部门名称 ,bm.ID as 三级部门ID ,copy.名称 as 二级部门名称 ,copy.ID as 二级部门ID");
                sb.Append(" from 设备_设备信息表,  dbo.用户_单位表 AS copy , dbo.部门表 as bm");
                sb.Append("  where  设备_设备信息表.使用单位=  bm.ID and bm.所属单位 =copy.ID and copy.ID =" + ID + "");
                sb.Append("  and 设备编号 not in (SELECT 设备编号 FROM  AM_已盘点设备表 where 二级部门ID=" + ID);
                sb.Append(" )) as tt");
                sb.Append("  where");
                sb.Append(" row between ");
                sb.Append(PageIndex * PageSize);
                sb.Append(" and ");
                sb.Append((PageIndex + 1) * PageSize);
                sb.Append(" order by row desc");

                SqlDataReader read = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sb.ToString());
                List<Model录入盘点信息> list = new List<Model录入盘点信息>();
                while (read.Read())
                {
                    Model录入盘点信息 model = new Model录入盘点信息();
                    model.ID = Convert.ToInt32(read["ID"]);
                    model.SAP编号 = read["SAP编号"].ToString();
                    model.设备编号 = read["设备编号"].ToString();
                    model.设备名称 = read["设备名称"].ToString();
                    model.设备型号 = read["设备型号"].ToString();
                    model.制造商 = read["制造商"].ToString();
                    model.投产时间 = read["投产时间"].ToString();
                    model.三级部门ID = Convert.ToInt32(read["三级部门ID"]);
                    model.设备规格 = read["设备规格"].ToString();
                    model.三级部门名称 = read["三级部门名称"].ToString();
                    model.二级部门名称 = read["二级部门名称"].ToString();
                    model.二级部门ID = Convert.ToInt32(read["二级部门ID"]);
                    model.操作人 = username;
                    model.帐物是否相符 = "是";
                    model.闲置或待报废简要原因 = "";
                    model.盘盈或盘亏简要原因 = "";
                    list.Add(model);
                }
                return list;
            }

        }

        public int 查询盘点设备总数(string rank, int ID)
        {
            string sql = "";
            if (rank != "全部")
            {
                sql = string.Format("SELECT COUNT(*) AS 总数 FROM  dbo.设备_设备信息表 AS A ,部门表 AS B , 用户_单位表 AS C where A.使用单位 = B.ID and b.所属单位 = c.ID and B.ID ={0}  and 设备编号 not in (SELECT 设备编号 FROM  AM_已盘点设备表 where 三级部门ID={1})", ID, ID);
            }
            else
            {
                sql = string.Format("SELECT  COUNT(*) 总数	FROM  dbo.设备_设备信息表 AS A ,部门表 AS B , 用户_单位表 AS C where A.使用单位 = B.ID and b.所属单位 = C.ID and C.ID ={0}  and 设备编号 not in (SELECT 设备编号 FROM  AM_已盘点设备表 where 二级部门ID={1})", ID, ID);
            }
            return Convert.ToInt32(DBHelper.ExecuteScalar(DBHelper.ConnectionString, CommandType.Text, sql));
        }


        public int 查询已盘点总数(int 盘点主表ID,int 部门ID, string rank,string 盘点类型) 
        {
            string sql = "";
            if (rank != "全部")
            {
                sql = string.Format(" SELECT  COUNT(*) AS 总数 FROM AM_已盘点设备表 as a , 设备_设备信息表 as b where A.设备台账ID = B.ID AND A.盘点主表ID ={0}  AND A.三级部门ID ={1} AND A.盘点类型 = '{2}'", 盘点主表ID, 部门ID, 盘点类型);
            }
            else 
            {
                sql = string.Format(" SELECT  COUNT(*) AS 总数 FROM AM_已盘点设备表 as a , 设备_设备信息表 as b where A.设备台账ID = B.ID AND A.盘点主表ID ={0}  AND A.二级部门ID ={1} AND A.盘点类型 = '{2}'", 盘点主表ID, 部门ID, 盘点类型);
            }
            return Convert.ToInt32(DBHelper.ExecuteScalar(DBHelper.ConnectionString, CommandType.Text, sql));
        }


        public int 创建盘点主表(AM_盘点清查主表 model)
        {
            string sql = string.Format("INSERT INTO   dbo.AM_盘点清查主表(创建人,盘点范围,盘点方式,创建时间,盘点名称,备注,是否关闭 ) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", model.创建人, model.盘点范围, model.盘点方式, model.创建时间, model.盘点名称, model.备注, model.是否关闭);
            return Convert.ToInt32(DBHelper.ExecuteNonQuery(DBHelper.ConnectionString, CommandType.Text, sql));

        }

        public List<AM_盘点清查主表> 查询盘点主表()
        {
            string sql = "SELECT ID,盘点名称 FROM dbo.AM_盘点清查主表 where 是否关闭='否' order by 创建时间 desc";
            SqlDataReader read = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sql.ToString());
            List<AM_盘点清查主表> list = new List<AM_盘点清查主表>();
            while (read.Read())
            {
                AM_盘点清查主表 model = new AM_盘点清查主表();
                model.ID = Convert.ToInt32(read["ID"]);
                model.盘点名称 = read["盘点名称"].ToString();
                list.Add(model);
            }
            return list;
        }

        public int 插入已盘点设备表(List<Model录入盘点信息> listmodel)
        {
            List<string> strlist = new List<string>();
            string sql = "";
            foreach (Model录入盘点信息 item in listmodel)
            {
                sql = string.Format("INSERT INTO [AM_已盘点设备表] (设备编号,设备台账ID,盘点主表ID,二级部门ID,三级部门ID,二级部门名称,三级部门名称,操作人,操作日期,盘点类型,帐物是否相符,盘盈或盘亏简要原因,闲置或待报废简要原因) VALUES('{0}',{1},{2},{3},{4},'{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}')", item.设备编号
                    , item.设备台账ID, item.盘点主表ID, item.二级部门ID, item.三级部门ID, item.二级部门名称, item.三级部门名称, item.操作人, item.操作日期, item.盘点类型, item.帐物是否相符, item.盘盈或盘亏简要原因, item.闲置或待报废简要原因);
                strlist.Add(sql);
            }
            return DBHelper.ExecuteSqlTran(strlist);

        }

        public List<盘点统计> 查询三级部门盘点信息(int 二级部门ID, string 盘点任务名称)
        {
            string sql = string.Format("SELECT * from 部门表 WHERE 所属单位 = {0} order by ID", 二级部门ID);
            SqlDataReader read = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sql.ToString());
            List<部门表> list = new List<部门表>();
            while (read.Read())
            {
                部门表 model = new 部门表();
                model.ID = Convert.ToInt32(read["ID"]);
                model.所属单位 = Convert.ToInt32(read["所属单位"]);
                model.名称 = read["名称"].ToString();
                list.Add(model);
            }
            List<盘点统计> listpd = new List<盘点统计>();
            foreach (部门表 item in list)
            {
                盘点统计 model = new 盘点统计();
                model.部门 = item.名称;
                model.三级部门ID = item.ID;
                StringBuilder sb = new StringBuilder();
                sb.Append(" SELECT ( select COUNT(*) FROM AM_已盘点设备表 AS A  ");
                sb.Append(" INNER JOIN dbo.AM_盘点清查主表 AS B ON  A.盘点主表ID = B.ID ");
                sb.Append("  INNER JOIN dbo.AM_盘点清查主表 as c on A.盘点主表ID = c.ID ");
                sb.Append(" WHERE  三级部门ID ="+item.ID);
                sb.Append(" and C.盘点名称= '" + 盘点任务名称+"'");
                sb.Append(")AS 已盘点,");
                sb.Append("( SELECT  COUNT(*) 总数 FROM  dbo.设备_设备信息表 AS A");
                sb.Append(" INNER JOIN 部门表 AS B  ON A.使用单位 = B.ID");
                sb.Append(" INNER JOIN 用户_单位表 AS C ON b.所属单位 = C.ID");
                sb.Append(" where B.ID =" + item.ID + ") AS 设备总数");
                 SqlDataReader readpd = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sb.ToString());
                 while (readpd.Read())
                 {
                     model.生产设备已盘点 = Convert.ToInt32(readpd["已盘点"]);
                     model.生产设备总数 = Convert.ToInt32(readpd["设备总数"]);

                     model.办公设备总数 = 0;
                     model.办公设备已盘点 = 0;

                     model.传导设备总数 = 0;
                     model.传导设备已盘点 = 0;

                     model.建筑物总数 = 0;
                     model.建筑物已盘点 = 0;

                     model.工装总数 = 0;
                     model.工装已盘点 = 0;
                     model.盘点任务名称 = 盘点任务名称;
                 }
                 readpd.Close();
                 listpd.Add(model);
            }
            return listpd;

        }


        public List<盘点统计> 查询盘点统计(int 盘点主表ID,string 盘点任务名称) 
        {
            string sql = string.Format(" SELECT * FROM 用户_单位表  order by ID");
            SqlDataReader read = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sql.ToString());
            List<用户单位表> list = new List<用户单位表>();
            while (read.Read())
            {
                用户单位表 model = new 用户单位表();
                model.ID = Convert.ToInt32(read["ID"]);
                model.名称 = read["名称"].ToString();
                list.Add(model);
            }
            List<盘点统计> listpd = new List<盘点统计>();
            foreach (用户单位表 item in list)
            {
                盘点统计 model = new 盘点统计();
                model.部门 = item.名称;
                model.二级部门ID = item.ID;
                StringBuilder sb = new StringBuilder();
                //sb.Append(" SELECT ( select COUNT(*) FROM AM_已盘点设备表 AS A , dbo.AM_盘点清查主表 AS B WHERE A.盘点主表ID = B.ID AND 二级部门ID ="+item.ID);
                //sb.Append(" ) AS 已盘点 ,");
                //sb.Append("( SELECT  COUNT(*) 总数 FROM  dbo.设备_设备信息表 AS A ,部门表 AS B , 用户_单位表 AS C where A.使用单位 = B.ID and b.所属单位 = C.ID and C.ID ="+item.ID);
                //sb.Append(" ) AS 设备总数");

                sb.Append(" SELECT ( select COUNT(*) FROM AM_已盘点设备表 AS A  ");
                sb.Append(" INNER JOIN dbo.AM_盘点清查主表 AS B ON  A.盘点主表ID = B.ID ");
                sb.Append("  INNER JOIN dbo.AM_盘点清查主表 as c on A.盘点主表ID = c.ID ");
                sb.Append(" WHERE  二级部门ID =" + item.ID);
                sb.Append(" and C.盘点名称= '" + 盘点任务名称 + "'");
                sb.Append(")AS 已盘点,");
                sb.Append("( SELECT  COUNT(*) 总数 FROM  dbo.设备_设备信息表 AS A");
                sb.Append(" INNER JOIN 部门表 AS B  ON A.使用单位 = B.ID");
                sb.Append(" INNER JOIN 用户_单位表 AS C ON b.所属单位 = C.ID");
                sb.Append(" where C.ID =" + item.ID + ") AS 设备总数");

                SqlDataReader readpd = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sb.ToString());
                while (readpd.Read())
                {
                    //int 已盘点 = Convert.ToInt32(readpd["已盘点"]);
                    //int 设备总数 =  Convert.ToInt32(readpd["设备总数"]);
                    model.生产设备已盘点 = Convert.ToInt32(readpd["已盘点"]);
                    model.生产设备总数 = Convert.ToInt32(readpd["设备总数"]);

                    model.办公设备总数 = 0;
                    model.办公设备已盘点 = 0;

                    model.传导设备总数 = 0;
                    model.传导设备已盘点 = 0;

                    model.建筑物总数 = 0;
                    model.建筑物已盘点 = 0;

                    model.工装总数 = 0;
                    model.工装已盘点 = 0;
                    model.盘点任务名称 = 盘点任务名称;
                }
                listpd.Add(model);
            }
            return listpd;

        }





    }
}
