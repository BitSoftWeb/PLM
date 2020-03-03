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
    public class 用户操作SQL
    {
        public 用户表 UserLogin(用户表 au)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT A.ID,  A.用户名,A.密码,A.权限,A.单位 AS 二级部门ID , A.部门 AS 三级部门ID, A.姓名,A.职务, A.联系电话, B.部门名称 AS 三级部门名称,C.部门名称 AS 二级部门名称");
            sb.Append(" FROM dbo.用户表 AS A ");
            sb.Append(" INNER JOIN  SYS_BD_三级机构表 AS B ON A.部门=B.ID ");
            sb.Append(" INNER JOIN  SYS_BD_一级机构表 AS C  ON C.ID=B.Superior_ID  where (A.用户名=@username and A.密码 =@userpassword)");
            SqlParameter[] para = { new SqlParameter("username", au.用户名), new SqlParameter("@userpassword", au.密码) };
            SqlDataReader read = DBHelper.ExecuteReader(DBHelper.ConnectionString, CommandType.Text, sb.ToString(), para);
            用户表 csuser = new 用户表();
            if (read.Read())
            {
                csuser.ID = Convert.ToInt32(read["ID"]);
                csuser.用户名 = read["用户名"].ToString();
                csuser.权限 = Convert.ToInt32(read["权限"]);
                csuser.二级部门ID = Convert.ToInt32(read["二级部门ID"]);
                csuser.三级部门ID = Convert.ToInt32(read["三级部门ID"]);
                csuser.姓名 = read["姓名"].ToString();
                csuser.职务 = read["职务"].ToString();
                csuser.联系电话 = read["联系电话"].ToString();
                csuser.三级部门名称 = read["三级部门名称"].ToString();
                csuser.二级部门名称 = read["二级部门名称"].ToString();
            }
            read.Close();
            return csuser;
        }
    }
}
