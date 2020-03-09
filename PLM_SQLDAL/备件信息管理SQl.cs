using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using PLM_Common;

namespace PLM_SQLDAL
{
    public class 备件信息管理SQl
    {

        /// <summary>
        /// 提报单位分类
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetList1(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  " + strWhere);
            strSql.Append(" FROM b_备件_导入日志表 a,b_备件_信息表 b where a.物料号=b.物料号 ");
            strSql.Append("group by " + strWhere);
            //if (strWhere.Trim() != "")
            //{
            //    strSql.Append(" where " + strWhere);
            //}
            return DBHelper.Query(strSql.ToString());

        }

        #region 备件库存表
        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select COUNT(1) from (select a.物料号, b.备件名称, b.规格型号, b.计量单位, b.管理类别, a.提报单位, a.成本中心, SUM(a.剩余数量) as 库存, SUM(a.剩余数量 * 价格) as 总价 from b_备件_导入日志表 a , b_备件_信息表 b    ");
			if (strWhere.Trim() != "")
			{
				strSql.Append(" where a.物料号 = b.物料号 and " + strWhere);
            }
            else
            {
                strSql.Append("where a.物料号 = b.物料号 ");
            }
            strSql.Append("group by a.物料号, b.备件名称, b.规格型号, b.计量单位, b.管理类别, a.提报单位, a.成本中心) as qq");
			object obj = DBHelper.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetListByPage11(int startIndex, int endIndex, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select   *, row_number() over(order by 物料号 ASC) rid into #tt from (SELECT a.物料号, b.备件名称, b.规格型号, b.计量单位, b.管理类别, a.提报单位, a.成本中心, SUM(a.剩余数量) AS 库存, SUM(a.剩余数量 * a.价格) as 总价 FROM b_备件_导入日志表 a, b_备件_信息表 b ");
            
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where a.物料号 = b.物料号 and " + strWhere);
            }
            else
            {
                strSql.Append(" where a.物料号 = b.物料号");
            }
            strSql.Append(" GROUP BY a.物料号, b.备件名称, b.规格型号, b.计量单位, b.管理类别, a.提报单位, a.成本中心) as qq");
            strSql.Append(" select * from  #tt where rid> " + startIndex + " and rid<=" + endIndex + " Order By 物料号 ASC drop table #tt");
            return DBHelper.Query(strSql.ToString());

        }

        /// <summary>
        /// 总金额查询
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public object GetMoney(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SUM(总价) from");
            strSql.Append("(select a.物料号, b.备件名称, b.规格型号, b.计量单位, b.管理类别 ,a.提报单位,a.成本中心,SUM(剩余数量) as 库存,SUM(剩余数量*价格) as 总价 from b_备件_导入日志表 a ,b_备件_信息表 b ");
            if (strWhere != "全部")
            {
                strSql.Append(" where a.物料号 = b.物料号 and " + strWhere );
            }
            else
            {
                strSql.Append(" where a.物料号 = b.物料号");
            }
            strSql.Append(" group by a.物料号, b.备件名称, b.规格型号, b.计量单位, b.管理类别,a.提报单位,a.成本中心) as qq");
            return DBHelper.GetSingle(strSql.ToString());
        }
        #endregion
        #region 备件记录表
        public int JL_PageCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) ");
            strSql.Append(" from b_备件_导入日志表 a , b_备件_信息表 b ,b_备件_记录表 c ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where a.物料号=b.物料号 and a.ID=c.日志ID and " + strWhere);
            }
            else
            {
                strSql.Append(" where a.物料号=b.物料号 and a.ID=c.日志ID ");
            }
            object obj = DBHelper.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        
        /// <summary>
        /// 记录表分页
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet JL_GetListPage(int startIndex, int endIndex, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select a.物料号,b.备件名称,b.规格型号,b.计量单位,a.成本中心,c.使用单位名称,a.提报单位,a.提报人,c.发放人,c.领取人,c.操作类型, c.操作数量, c.操作日期, c.总价, c.设备编号, c.设备相关名称, c.使用类型, ROW_NUMBER() over(order by a.物料号 asc) rid into #tr  ");
            strSql.Append(" from b_备件_导入日志表 a , b_备件_信息表 b ,b_备件_记录表 c  ");

            if (strWhere.Trim() != "")
            {
                strSql.Append(" where a.物料号=b.物料号 and a.ID=c.日志ID and " + strWhere);
            }
            else
            {
                strSql.Append(" where a.物料号=b.物料号 and a.ID=c.日志ID");
            }
            strSql.Append(" select * from  #tr where rid> " + startIndex + " and rid<=" + endIndex + " Order By 物料号 ASC drop table #tr");
            return DBHelper.Query(strSql.ToString());
        }

        /// <summary>
        /// 记录表总金额查询
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public object JL_GetMoney(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SUM(c.总价) ");
            strSql.Append(" from b_备件_导入日志表 a , b_备件_信息表 b ,b_备件_记录表 c ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where a.物料号=b.物料号 and a.ID=c.日志ID and" + strWhere);
            }
            else
            {
                strSql.Append(" where a.物料号=b.物料号 and a.ID=c.日志ID");
            }
            return DBHelper.GetSingle(strSql.ToString());
        }
        #endregion
        #region 备件日志表

        /// <summary>
        /// 日志表记录数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int RZ_GetCountPage(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select COUNT(1) from b_备件_导入日志表 a , b_备件_信息表 b");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where a.物料号=b.物料号 and " + strWhere);
            }
            else
            {
                strSql.Append(" where a.物料号=b.物料号 ");
            }
            object obj = DBHelper.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        /// <summary>
        /// 日志表分页
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet RZ_GetPage(int startIndex, int endIndex, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select a.物料号,b.备件名称,b.规格型号,b.计量单位,a.成本中心,a.提报单位,a.提报人,a.预留号,a.预留数量,a.发料数量,a.剩余数量,a.价格 as 单价,a.发料时间,a.库存地址,a.订单号,a.预留文本,ROW_NUMBER() over(order by a.物料号 asc) rid into #tt");
            strSql.Append(" from b_备件_导入日志表 a ,b_备件_信息表 b");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where a.物料号=b.物料号 and " + strWhere);
            }
            else
            {
                strSql.Append(" where a.物料号=b.物料号 ");
            }
            strSql.Append(" select * from  #tt where rid> " + startIndex + " and rid<=" + endIndex + " Order By 物料号 ASC drop table #tt");
            return DBHelper.Query(strSql.ToString());
        }
        
        /// <summary>
        /// 日志总金额查询
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public object RZ_GetMoney(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select sum(a.价格*a.发料数量) ");
            strSql.Append(" from b_备件_导入日志表 a ,b_备件_信息表 b ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where a.物料号=b.物料号 and " + strWhere);
            }
            else
            {
                strSql.Append(" where a.物料号=b.物料号 ");
            }
            return DBHelper.GetSingle(strSql.ToString());
        }
        #endregion
    }
}
