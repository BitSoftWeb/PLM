using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web;
using System.Web.Security;
using FineUIPro;
using mydddd.Web.code;



public class BasePage : System.Web.UI.Page
{

    #region 初始化语言和皮肤
    protected override void OnInit(EventArgs e)
    {
        try
        {
            var pm = PageManager.Instance;
            if (pm != null)
            {
                HttpCookie themeCookie = Request.Cookies["Theme"];
                //HttpCookie themeCookie = new HttpCookie("new_Style");
                
                if (themeCookie != null)
                {
                    string themeValue = "new_Style";

                    // 是否为内置主题
                    if (IsSystemTheme(themeValue))
                    {
                        pm.CustomTheme = String.Empty;
                        pm.Theme = (Theme)Enum.Parse(typeof(Theme), themeValue, true);
                    }
                    else
                    {
                        pm.CustomTheme = themeValue;
                    }
                }

                if (Constants.IS_BASE)
                {
                    pm.CustomTheme = "new_Style";
                    pm.EnableAnimation = false;
                }
            }
            base.OnInit(e);
        }
        catch (Exception ex)
        {
            DateTime time = DateTime.Now;
            string content = ex.ToString();
            string sql = @"insert into NoteError (Error,time) values('" + content + "','" + time + "')";
           mydddd.BLL.DBControl.ExecuteSql(sql);
        }
        
    }
    private bool IsSystemTheme(string themeName)
    {
        themeName = themeName.ToLower();
        string[] themes = Enum.GetNames(typeof(Theme));
        foreach (string theme in themes)
        {
            if (theme.ToLower() == themeName)
            {
                return true;
            }
        }
        return false;
    }
    #endregion

    #region 页面权限相关

    protected void Page_PreInit(object sender, EventArgs e)
    {
//#if DEBUG
//        return;
//#endif
        if (Session["Admin"] == null)//网站管理员登录
        {
            //Response.Redirect("~/timeout.aspx", true);
            //PageContext.Refresh("~/timeout.aspx");
            //PageContext.RegisterStartupScript("alert('登录超时,请重新登录');top.location.href='/login.aspx'");

            //FormsAuthentication.SignOut();
            //Response.Redirect(FormsAuthentication.LoginUrl);

            //Response.Write("<script>alert('登录超时,请刷新页面重新登录');top.location.href='/login.aspx'</script>");
            //Response.End();



        }
    }

    /// <summary>
    /// 页面权限验证
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Init(object sender, EventArgs e)
    {
        
//#if DEBUG
//        return;
//#endif
        //if (!IsPostBack)
        //{

        //    if (Session["Admin"] == null)//网站管理员登录
        //    {
        //        Response.Write("您无权限浏览");
        //        Response.End();
        //    }
        //    else
        //    {
        //        string url = HttpContext.Current.Request.Url.AbsolutePath.ToLower().Replace("/admin/", "");

        //        //默认页和修改密码页排除验证
        //        switch (url)
        //        {
        //            case "default.aspx": //默认页
        //            //break;
        //            case "main.aspx": //默认页
        //            //break;
        //            case "edit.aspx"://修改密码页
        //                break;
        //            default:
        //                DataRow dr = Session["Admin"] as DataRow;
        //                if (!mydddd.BLL.SysModule.IsRole(int.Parse(dr["sysrolepopedom_rname"].ToString()), url))
        //                {
        //                    Response.Write("您无权限浏览");
        //                    Response.End();
        //                }
        //                break;
        //        }
        //    }
            
        //}
    }

    #endregion

    #region  数据操作，分页相关
    /// <summary>
    /// 绑定FineUIPro.Grid分页方法
    /// </summary>
    /// <param name="grid">FineUIPro.Grid</param>
    /// <param name="tableName">表名</param>
    /// <param name="strSql">where条件(加and)</param>
    /// <param name="orderbyColumn">排序条件</param>
    public void BindFineUI(FineUIPro.Grid grid, string tableName, string strSql, string orderbyColumn)
    {
        BindFineUI(" * ", grid, tableName, strSql, orderbyColumn);
    }

    /// <summary>
    /// 绑定FineUIPro.Grid分页方法
    /// </summary>
    /// <param name="columns">显示列名</param>
    ///  <param name="grid">FineUIPro.Grid</param>
    /// <param name="tableName">表名</param>
    /// <param name="whereSql">where条件(加and)</param>
    /// <param name="orderbyColumn">排序条件</param>
    public void BindFineUI(string columns, FineUIPro.Grid grid, string tableName, string whereSql, string orderbyColumn)
    {
        FineuiProHelper.Grid.BindFineUI(columns,  grid,  tableName,  whereSql,  orderbyColumn);
    }

    /// <summary>
    /// 绑定FineUIPro.Grid分页方法
    /// </summary>
    /// <param name="columns">显示列名</param>
    ///  <param name="grid">FineUIPro.Grid</param>
    /// <param name="tableName">表名</param>
    /// <param name="whereSql">where条件(加and)</param>
    /// <param name="orderbyColumn">排序条件</param>
    public void BindFineUI2(string columns, FineUIPro.Grid grid, string tableName, string whereSql, string orderbyColumn)
    {
        int pageindex = grid.PageIndex;

        if (orderbyColumn.Length == 0)
        {
            orderbyColumn = string.Format(" {0} {1} ", grid.SortField, grid.SortDirection);
        }

        string sql = string.Format(@"select  {0},row_number() over(order by {1}) rid into #tt from {2} 
            where isdel=0 {3} Order By {1}  select * from  #tt where rid> {4} and rid<={5} drop table  #tt", 
                            columns, orderbyColumn, tableName, whereSql, grid.PageSize * pageindex, grid.PageSize * (pageindex + 1));
        grid.RecordCount = Getdatatablecount(string.Format("select count(1) from {0}  where isdel=0 {1}", tableName, whereSql));
        DataTable dt = GetPagedDataTable(sql);
        DataView view1 = dt.DefaultView;
        view1.Sort = orderbyColumn;
        grid.DataSource = null;
        grid.DataSource = view1;
        grid.DataBind();
    }


    /// <summary>
    /// 绑定FineUIPro.Grid分页方法 获取删除的页面
    /// </summary>
    /// <param name="columns">显示列名</param>
    ///  <param name="grid">FineUIPro.Grid</param>
    /// <param name="tableName">表名</param>
    /// <param name="strSql">where条件(加and)</param>
    /// <param name="orderbyColumn">排序条件</param>
    public void BindFineUI_del(string columns, FineUIPro.Grid grid, string tableName, string strSql, string orderbyColumn)
    {

        if (orderbyColumn.Length == 0)
        {
            orderbyColumn = string.Format(" {0} {1} ", grid.SortField, grid.SortDirection);
        }

        string sql = string.Format(@"select  {0},row_number() over(order by {1}) rid into #tt from {2} 
                                where isdel=1 {3} Order By {1}  select * from  #tt where rid> {4} and rid<={5} drop table  #tt", 
                                columns, orderbyColumn, tableName, strSql, grid.PageSize * grid.PageIndex, grid.PageSize * (grid.PageIndex + 1));
        grid.RecordCount = Getdatatablecount(string.Format("select count(1) from {0}  where isdel=1 {1}", tableName, strSql));
        DataTable dt = GetPagedDataTable(sql);
        DataView view1 = dt.DefaultView;
        view1.Sort = orderbyColumn;
        grid.DataSource = null;
        grid.DataSource = view1;
        grid.DataBind();
    }

    /// <summary>
    /// 绑定FineUIPro.Grid分页方法
    /// </summary>
    /// <param name="columns">显示列名</param>
    ///  <param name="grid">FineUIPro.Grid</param>
    /// <param name="tableName">表名</param>
    /// <param name="whereSql">where条件(加and)</param>
    /// <param name="dic">条件参数和赋值</param>
    /// <param name="orderbyColumn">排序条件</param>
    public void BindFineUI(string columns, FineUIPro.Grid grid, string tableName, string whereSql, Dictionary<string, object> dic, string orderbyColumn)
    {
        FineuiProHelper.Grid.BindFineUI(columns,  grid,  tableName,  whereSql,  dic,  orderbyColumn);
    }

    /// <summary>
    /// 查询数据库记录条数
    /// </summary>
    /// <param name="sql"></param>
    /// <returns></returns>
    private int Getdatatablecount(string sql)
    {
        string cnt = mydddd.BLL.DBControl.Query(sql).Tables[0].Rows[0][0].ToString();
        return Convert.ToInt32(cnt);
    }

   

    /// <summary>
    /// 数据库分页查询语句
    /// </summary>
    /// <returns></returns>
    private DataTable GetPagedDataTable(string sql)
    {
        DataSet ds = mydddd.BLL.DBControl.Query(sql);
        return ds.Tables[0];
    }

    /// <summary>
    /// 数据库分页查询语句
    /// </summary>
    /// <returns></returns>
    private DataTable GetPagedDataTable(string sql, SqlParameter[] par)
    {
        DataSet ds = mydddd.BLL.DBControl.Query(sql, par);
        return ds.Tables[0];
    }


    /// <summary>
    /// 伪删除(表有isdel字段才可以)
    /// </summary>
    /// <param name="tablename">表名</param>
    /// <param name="isdel">0显示，1删除</param>
    /// <param name="ids">多个id</param>
    /// <returns></returns>
    public int IsDelSet(string tablename, int isdel, string ids)
    {
        string sql = string.Format("update {0} set isdel={1} where id in ({2}) ", tablename, isdel, ids);
        return mydddd.BLL.DBControl.ExecuteSql(sql);
    }

  


    #endregion

    #region Fineui公共方法 
    
    #region Alert 或 页面跳转

    /// <summary>
    /// 提示信息(弹层用),并指定父页面跳转
    /// </summary>
    /// <param name="message">内容</param>
    /// <param name="url"></param>
    protected void AlertInforAndRedirect(string message, string url)
    {
        FineuiProHelper.Alert.AlertInforAndRedirect(message,  url );
    }

    /// <summary>
    /// 提示信息(弹层用)
    /// </summary>
    /// <param name="message">内容</param>
    /// <param name="isPostBackReference">是否回发刷新页面</param>
    protected void AlertInfor(string message, bool isPostBackReference)
    {
        FineuiProHelper.Alert.AlertInfor(message, isPostBackReference);
    }
    
    /// <summary>
    /// 提示信息（单页用 并刷新当前页）
    /// </summary>
    /// <param name="message">内容</param>
    /// <param name="isPostBackReference">是否回发刷新页面</param>
    protected void AlertInforBySingerPage(string message, bool isPostBackReference)
    {
        FineuiProHelper.Alert.AlertInforBySingerPage(message, isPostBackReference);

    }

    /// <summary>
    /// 报错信息
    /// </summary>
    /// <param name="message">内容</param>
    /// <param name="isPostBackReference">是否回发刷新页面</param>
    protected void AlertError(string message, bool isPostBackReference)
    {
        FineuiProHelper.Alert.AlertError(message, isPostBackReference);
    }

    /// <summary>
    /// 疑问信息
    /// </summary>
    /// <param name="message">内容</param>
    /// <param name="isPostBackReference">是否回发刷新页面</param>
    protected void AlertQuestion(string message, bool isPostBackReference)
    {
        FineuiProHelper.Alert.AlertQuestion(message, isPostBackReference);
    }

    /// <summary>
    /// 警告信息
    /// </summary>
    /// <param name="message">内容</param>
    /// <param name="isPostBackReference">是否回发刷新页面</param>
    protected void AlertWarning(string message, bool isPostBackReference)
    {
        FineuiProHelper.Alert.AlertWarning(message, isPostBackReference);
    }

    /// <summary>
    /// 子页面关闭并在父业面跳转
    /// </summary>
    /// <param name="url"></param>
    protected void ParentRedirect(string url)
    {
        FineuiProHelper.Alert.ParentRedirect(url);
    }

    #endregion

    #region Notify 消息框

    /// <summary>
    /// 警告消息框
    /// </summary>
    /// <param name="message">警告信息</param>
    /// <param name="js">然后执行的js代码</param>
    public void NotifyInformation(string message,string js=null)
    {
        Notify nf=new Notify();
        nf.GetShowNotify();
        nf.Message = message;
        nf.MessageBoxIcon = MessageBoxIcon.Information;
        if (!string.IsNullOrEmpty(js)) nf.HideScript = js;
        nf.Show();
    }

    /// <summary>
    /// 警告消息框
    /// </summary>
    /// <param name="message">警告信息</param>
    /// <param name="js">然后执行的js代码</param>
    public void NotifyWarning(string message,string js=null)
    {
        Notify nf=new Notify();
        nf.GetShowNotify();
        nf.Message = message;
        nf.MessageBoxIcon = MessageBoxIcon.Warning;
        if (!string.IsNullOrEmpty(js)) nf.HideScript = js;
        nf.Show();
    }

    /// <summary>
    /// 错误消息框
    /// </summary>
    /// <param name="message">错误信息</param>
    /// <param name="js">然后执行的js代码</param>
    public void NotifyError(string message,string js=null)
    {
        Notify nf=new Notify();
        nf.GetShowNotify();
        nf.Message = message;
        nf.MessageBoxIcon = MessageBoxIcon.Error;
        if (!string.IsNullOrEmpty(js)) nf.HideScript = js;
        nf.Show();
    }

    #endregion

    #region grid

    /// <summary>
    /// 获取选中行的主id，第一主键
    /// </summary>
    /// <param name="grid">FineUIPro.Grid</param>
    /// <returns></returns>
    public static string GetDataKeysBySelectedRow(FineUIPro.Grid grid)
    {
        return FineuiProHelper.Grid.GetDataKeysBySelectedRow(grid, 0);
    }

    /// <summary>
    /// 获取选中行的主id
    /// </summary>
    /// <param name="grid">FineUIPro.Grid</param>
    /// <param name="keyNumIndex">第几个主键（从0开始）</param>
    /// <returns></returns>
    public static string GetDataKeysBySelectedRow(FineUIPro.Grid grid, int keyNumIndex)
    {
        return FineuiProHelper.Grid.GetDataKeysBySelectedRow(grid, keyNumIndex);
    }
    #endregion
    
    #endregion

   

}
