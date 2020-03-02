using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PLM_Model
{
    public class 用户表
    {
        public int ID { get; set; }

        public string 用户名 { get; set; }

        public string 密码 { get; set; }

        public int 权限 { get; set; }

        public int 二级部门ID { get; set; }

        public int 三级部门ID { get; set; }

        public string 二级部门名称 { get; set; }

        public string 三级部门名称 { get; set; }

        public int 系统角色 { get; set; }

        public string SAP编号 { get; set; }

        public string 姓名 { get; set; }

        public string 职务 { get; set; }

        public string 联系电话 { get; set; }

        public string 备注 { get; set; }

      


    }
}
