using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PLM_Model
{
    public class 消息中心Model
    {
        public int ID { get; set; }

        public string  消息事项 { get; set; }

        public string 发起人 { get; set; }

        public string 时间 { get; set; }

        public string 通知类型 { get; set; }

        public string 是否已读 { get; set; }

        public string 事项内容 { get; set; }
    }
}
