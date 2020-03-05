using FineUIPro;
using PLM.BusinessRlues;
using PLM_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FineUIPro.EmptyProjectNet40
{
    public partial class NewLogin : System.Web.UI.Page
    {
        用户操作BLL bll = new 用户操作BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Label1.Text = "";
            }
        }

        protected void Login_Button_Click(object sender, EventArgs e)
        {
            Label1.Text = "";
            用户表 loginuser = new 用户表();
            loginuser.用户名 = Login_name.Text.Trim();
            string mwpa = Pass_word.Text.Trim();
            if (loginuser.用户名 == "" || mwpa == "")
            {
                //提示
                Label1.Text = "请输入用户名或密码";
                return;
            }
            //密码转换MD5
            loginuser.密码 = GetMD5Str(mwpa);
            用户表 user = bll.UserLogin(loginuser);
            if (user.ID == 0)
            {
                //用户名密码错误了
                Label1.Text = "用户名或密码错误";
                return;
            }
            else
            {
                //创建Session
                //跳转页面
                Session["UserID"] = user.ID;
                Session["用户名"] = user.用户名;
                Session["权限"] = user.权限;
                Session["二级部门ID"] = user.二级部门ID;

                Session["三级部门ID"] = user.三级部门ID;
                Session["姓名"] = user.姓名;
                Session["职务"] = user.职务;
                Session["联系电话"] = user.联系电话;
                Session["三级部门名称"] = user.三级部门名称;
                Session["二级部门名称"] = user.二级部门名称;
                Response.Redirect("index.aspx");
                return;
            }


        }

        public static string GetMD5Str(string toCryString)
        {
            MD5CryptoServiceProvider hashmd5;
            hashmd5 = new MD5CryptoServiceProvider();
            return BitConverter.ToString(hashmd5.ComputeHash(Encoding.Default.GetBytes(toCryString))).Replace("-", "").ToLower();//asp是小写,把所有字符变小写
        }

    }
}