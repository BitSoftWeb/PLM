using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PLM_Model
{
    public class 盘点统计
    {
        public string 盘点任务名称 { get; set; }

        public string 部门 { get; set; }

        public int 生产设备总数 { get; set; }

        public int 生产设备已盘点{ get; set; }

        public int 办公设备总数 { get; set; }

        public int 办公设备已盘点 { get; set; }

        public int 传导设备总数 { get; set; }

        public int 传导设备已盘点 { get; set; }

        public int 建筑物总数 { get; set; }

        public int 建筑物已盘点 { get; set; }

        public int 工装总数 { get; set; }

        public int 工装已盘点 { get; set; }

        public int 二级部门ID { get; set; }

        public int 三级部门ID { get; set; }
    }
}
