using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PLM_Model
{
    public class Model录入盘点信息
    {
        public int ID { get; set; }

        public string SAP编号 { get; set; }

        public int 设备台账ID { get; set; }

        public string 设备编号 { get; set; }

        public string 设备名称 { get; set; }

        public string 设备型号 { get; set; }

        public string 制造商 { get; set; }

        public string 投产时间 { get; set; }

        public int 使用单位 { get; set; }

        public string 设备规格 { get; set; }

        public string 三级部门名称 { get; set; }

        public int 三级部门ID { get; set; }

        public string 二级部门名称 { get; set; }

        public int 二级部门ID { get; set; }

        public string 帐物是否相符 { get; set; }

        public string 盘盈或盘亏简要原因 { get; set; }

        public string 闲置或待报废简要原因 { get; set; }

        public int 盘点主表ID { get; set; }

        public string 操作人 { get; set; }

        public string 操作日期 { get; set; }

        public string 盘点类型 { get; set; }


    }
}
