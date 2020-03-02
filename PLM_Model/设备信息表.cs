using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLM_Model
{
    public class 设备信息表
    {
        public int ID { get; set; }

        public int SBID { get; set; }

        public string SAP编号 { get; set; }

        public string 设备编号 { get; set; }

        public string 设备名称 { get; set; }

        public string 设备型号 { get; set; }

        public double 固资原值 { get; set; }

        public string 制造商 { get; set; }

        public DateTime 投产时间 { get; set; }

        public int 使用单位 { get; set; }

        public int 厂房ID { get; set; }

        public string 机械 { get; set; }

        public string 电气 { get; set; }

        public string 属性 { get; set; }

        public string 引进 { get; set; }

        public string 数控 { get; set; }

        public string 设备规格 { get; set; }

        public double 固资净值 { get; set; }

        public 部门表 bmb  { get; set; }

     


    }
}
