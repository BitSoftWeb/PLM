using PLM_SQLDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace PLM.BusinessRlues
{
    
    public class 备件信息管理BLL
    {
        private 备件信息管理SQl sql = new 备件信息管理SQl();

        /// <summary>
        /// 管理类别下拉列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetList1(string strWhere)
        {
            return sql.GetList1(strWhere);
        }

        #region 库存信息表
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return sql.GetRecordCount(strWhere);
        }

        /// <summary>
        /// 库存信息表分页查询
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetListByPage11(int startIndex, int endIndex, string strWhere)
        {
            return sql.GetListByPage11(startIndex, endIndex, strWhere);
        }
        /// <summary>
        /// 库存信息表总金额查询
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public object GetMoney(string strWhere)
        {
            return sql.GetMoney(strWhere);
        }

        #endregion
        #region 备件记录表
        /// <summary>
        /// 记录信息表总记录数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int JL_PageCount(string strWhere)
        {
            return sql.JL_PageCount(strWhere);
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
            return sql.JL_GetListPage(startIndex, endIndex, strWhere);
        }

        /// <summary>
        /// 记录表总金额查询
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public object JL_GetMoney(string strWhere)
        {
            return sql.JL_GetMoney(strWhere);
        }
        #endregion
        #region 备件日志表
        /// <summary>
        /// 获取记录数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int RZ_GetCountPage(string strWhere)
        {
            return sql.RZ_GetCountPage(strWhere);
        }

        /// <summary>
        /// 分页方法
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet RZ_GetPage(int startIndex, int endIndex, string strWhere)
        {
            return sql.RZ_GetPage(startIndex, endIndex, strWhere);
        }

        /// <summary>
        /// 总金额查询
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public object RZ_GetMoney(string strWhere)
        {
            return sql.RZ_GetMoney(strWhere);
        }

        #endregion
    }
}
