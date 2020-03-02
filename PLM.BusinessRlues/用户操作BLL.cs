using PLM_Model;
using PLM_SQLDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PLM.BusinessRlues
{
   
    public class 用户操作BLL
    {
        用户操作SQL sql = new 用户操作SQL();
        public 用户表 UserLogin(用户表 au)
        {
            return sql.UserLogin(au);
        }
    }
}
