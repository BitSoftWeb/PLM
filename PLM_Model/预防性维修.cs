using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PLM_Model
{
    public class 预防性维修
    {
        public string 设备类型 { get; set; }

        public string 设备编号 { get; set; }

        public string 部位 { get; set; }

        public int 故障时间间隔 { get; set; }

        public int 平均维修人数 { get; set; }

        public double 平均维修时长 { get; set; }

        
    }
}
