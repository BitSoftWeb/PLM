using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PLM_Model
{
    public class 备件信息管理
    {
        public int Xx_ID { set; get; }
        public string Xx_物料号 { set; get; }
        public string Xx_备件名称 { set; get; }
        public string Xx_规格型号 { set; get; }
        public string Xx_物料描述 { set; get; }
        public string Xx_备注 { set; get; }
        public  string Xx_管理类别 { set; get; }
        public string Xx_计量单位 { set; get; }
        public int Jl_ID { set; get; }
        public int Jl_日志ID { set; get; }
        public string Jl_发放人 { set; get; }
        public string Jl_领取人 { set; get; }
        public string Jl_操作类型 { set; get; }
        public string Jl_操作数量 { set; get; }
        public DateTime Jl_操作日期 { set; get; }
        public decimal Jl_总价 { set; get; }
        public string Jl_设备编号 { set; get; }
        public string Jl_设备相关名称 { set; get; }
        public string Jl_使用类型 { set; get; }
        public string Jl_使用单位名称 { set; get; }
        public int Jl_对应单位 { set; get; }
        public string Jl_备注 { set; get; }
        public int Jl_故障ID { set; get; }
        public DateTime Jl_录入日期 { set; get; }
        public int Rz_ID { set; get; }
        public string Rz_物料号 { set; get; }
        public string Rz_成本中心 { set; get; }
        public string Rz_提报单位 { set; get; }
        public string Rz_提报人 { set; get; }
        public string Rz_预留号 { set; get; }
        public int Rz_预留数量 { set; get; }
        public int Rz_发料数量 { set; get; }
        public DateTime Rz_发料日期 { set; get; }
        public decimal Rz_发料时间 { set; get; }
        public decimal Rz_价格 { set; get; }
        public int Rz_剩余数量 { set; get; }
        public string Rz_库存地址 { set; get; }
        public string Rz_预留行号 { set; get; }
        public string Rz_移动类型 { set; get; }
        public string Rz_预留文本 { set; get; }
        public int Rz_标记 { set; get; }
        public DateTime Rz_审核日期 { set; get; }
        public int Gl_ID { set; get; }
        public string Gl_物料号 { set; get; }
        public string Gl_设备编号 { set; get; }
        public string Gl_名称 { set; get; }
        public int Cb_ID { set; get; }
        public string Cb_名称 { set; get; }
        public string Cb_成本中心 { set; get; }
        public int Cb_所属单位 { set; get; }
        public int Dw_ID { set; get; }
        public string Dw_名称 { set; get; }
        public string Dw_成本中心 { set; get; }
        public int Dw_一级结构 { set; get; }
        public string Dw_单位属性 { set; get; }
        public int Yh_ID { set; get; }
        public string Yh_用户名 { set; get; }
        public string Yh_密码 { set; get; }
        public int Yh_权限 { set; get; }
        public int Yh_单位 { set; get; }
        public int Yh_部门 { set; get; }
        public int Yh_系统角色 { set; get; }
        public string Yh_sap帐号 { set; get; }
        public string Yh_姓名 { set; get; }
        public string Yh_职务 { set; get; }
        public string Yh_联系电话 { set; get; }
        public string Yh_备注 { set; get; }


    }
}
