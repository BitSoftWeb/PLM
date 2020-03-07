using PLM_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace PLM_Common
{
    public static class PLMUtility
    {
        #region 插入消息中心
        public static int 插入消息中心(AM_提醒通知 ammodel)
        {
            StringBuilder sbtz = new StringBuilder();
            sbtz.Append("INSERT INTO AM_提醒通知 ");
            sbtz.Append("(消息事项,消息内容,发起人,发起时间,通知类型,是否已读,通知职务,FlowID,处理职务,处理方式,处理人,FlowName,流程状态,Sort ");
            sbtz.Append(" ) VALUES( ");
            sbtz.Append(" @消息事项,@消息内容,@发起人,@发起时间,@通知类型,@是否已读,@通知职务,@FlowID,@处理职务,@处理方式,@处理人,@FlowName,@流程状态,@Sort ");
            sbtz.Append(")");
            SqlParameter[] paratz = {
                                       new SqlParameter("@消息事项",ammodel.消息事项),
                                       new SqlParameter("@消息内容",ammodel.消息内容),
                                       new SqlParameter("@发起人",ammodel.发起人),
                                       new SqlParameter("@发起时间",ammodel.发起时间),
                                       new SqlParameter("@通知类型",ammodel.通知类型),
                                       new SqlParameter("@是否已读",ammodel.是否已读),
                                       new SqlParameter("@通知职务",ammodel.通知职务),
                                       new SqlParameter("@FlowID",ammodel.FlowID),
                                       new SqlParameter("@处理职务",ammodel.处理职务),
                                       new SqlParameter("@处理方式",ammodel.处理方式),
                                       new SqlParameter("@处理人",ammodel.处理人),
                                       new SqlParameter("@FlowName",ammodel.FlowName),
                                       new SqlParameter("@流程状态",ammodel.流程状态),
                                        new SqlParameter("@Sort",ammodel.Sort),
                                   };
            return Convert.ToInt32(DBHelper.ExecuteScalar(DBHelper.ConnectionString, CommandType.Text, sbtz.ToString(), paratz));
        }
        #endregion

        #region 插入待办中心
        public static int 插入待办中心(AM_待办业务 ammodel)
        {

            StringBuilder dbsb = new StringBuilder();
            dbsb.Append("INSERT INTO AM_待办业务 ");
            dbsb.Append("(流程状态,FlowID,事项名称,通知内容,发起人,发起时间,处理职务,处理方式,处理人,FlowName,Sort ");
            dbsb.Append(" ) VALUES( ");
            dbsb.Append(" @流程状态,@FlowID,@事项名称,@通知内容,@发起人,@发起时间,@处理职务,@处理方式,@处理人,@FlowName ,@Sort");
            dbsb.Append(")");
            SqlParameter[] dbpara = {


                                       new SqlParameter("@流程状态",ammodel.流程状态),
                                       new SqlParameter("@FlowID",ammodel.FlowID),
                                       new SqlParameter("@事项名称",ammodel.事项名称),
                                       new SqlParameter("@通知内容",ammodel.通知内容),
                                       new SqlParameter("@发起人",ammodel.发起人),
                                       new SqlParameter("@发起时间",ammodel.发起时间),
                                       new SqlParameter("@处理职务",ammodel.处理职务),
                                        new SqlParameter("@处理方式",ammodel.处理方式),
                                        new SqlParameter("@处理人",ammodel.处理人),
                                        new SqlParameter("@FlowName",ammodel.FlowName),
                                        new SqlParameter("@Sort",ammodel.Sort),
                                   };
            return Convert.ToInt32(DBHelper.ExecuteScalar(DBHelper.ConnectionString, CommandType.Text, dbsb.ToString(), dbpara));
        }
        #endregion

        #region 修改待办中心
        public static int 修改待办中心(AM_待办业务 ammodel)
        {
            //所需参数   “流程状态，处理职务，处理方式，处理人，通知内容，FlowID，FlowName”
            string sql = string.Format("UPDATE dbo.AM_待办业务 set 流程状态 = '{0}',处理职务='{1}',处理方式='{2}',处理人='{3}',Sort={4} , 通知内容='{5}' where FlowID = {6} and FlowName = '{7}'", ammodel.流程状态, ammodel.处理职务, ammodel.处理方式, ammodel.处理人, ammodel.Sort, ammodel.通知内容, ammodel.FlowID, ammodel.FlowName);
            return DBHelper.ExecuteNonQuery(DBHelper.ConnectionString, CommandType.Text, sql.ToString());


        }
        #endregion

        #region 返回随机数
        public static string strbumber(string prefix)
        {
            string number = prefix;
            DateTime dt = DateTime.Now;
            string y = dt.Year.ToString();
            string m = dt.Month.ToString();
            string d = dt.Day.ToString();
            string h = dt.Hour.ToString();
            string mm = dt.Minute.ToString();
            number += y + m + d + h + mm;
            return number;
        }
        #endregion
    }
}
