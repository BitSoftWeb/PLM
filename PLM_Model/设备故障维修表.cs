using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PLM_Model
{
    public class 设备故障维修表
    {
        public int ID { get; set; }

        public int TZID { get; set; }

        public int SBID { get; set; }

        public string 故障描述 { get; set; }

        public DateTime 故障时间 { get; set; }

        public DateTime 报修时间 { get; set; }

        public string 状态 { get; set; }

        public string 更换备件 { get; set; }

        public string 故障分析 { get; set; }

        public string 维修措施 { get; set; }

        public DateTime 解决故障时间 { get; set; }

        public double 修理费用 { get; set; }

        public DateTime 录入解决时间 { get; set; }

        public string 解决方案及计划 { get; set; }

        public string 报修人 { get; set; }

        public string 维修人 { get; set; }

        public string 完成情况 { get; set; }


        public int 对应单位 { get; set; }

        public string 设备编号 { get; set; }

        public string 设备名称 { get; set; }

        public DateTime 开始维修时间 { get; set; }

        public int 维修人数 { get; set; }

        public double 维修工时 { get; set; }

        public string 原因分析 { get; set; }

        public string 解决故障根本问题的办法 { get; set; }

        public string 维修人员名单 { get; set; }

        public Guid WorkflowInstanceID { get; set; }
    }
}
