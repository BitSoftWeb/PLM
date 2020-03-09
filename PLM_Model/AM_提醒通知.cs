using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PLM_Model
{
    public class AM_提醒通知
    {
        public int ID { get; set; }

        public string 消息事项 { get; set; }

        public string 消息内容 { get; set; }

        public string 发起人 { get; set; }

        public DateTime 发起时间 { get; set; }

        public string 通知类型 { get; set; }

        public string 是否已读 { get; set; }

        public int FlowID { get; set; }
        public string 通知职务 { get; set; }

        public string 处理职务 { get; set; }

        public string 处理方式 { get; set; }

        public string 处理人 { get; set; }

        public string FlowName { get; set; }

        public string 流程状态 { get; set; }

        public int Sort { get; set; }
    }
}
