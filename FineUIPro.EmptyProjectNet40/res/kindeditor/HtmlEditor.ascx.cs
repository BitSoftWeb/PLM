using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class Controls_HtmlEditor : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if(!IsPostBack)
        //初始加载
        FirstLoadStr = firstLoad ? @"<style type='text/css'> textarea { display: block;} </style>
                                    <link rel='stylesheet' href='" + UrLstr + @"/themes/default/default.css' />
	                                <link rel='stylesheet' href='" + UrLstr + @"/plugins/code/prettify.css' />
	                                <script charset='utf-8' src='" + UrLstr + @"/kindeditor.js'></script>
	                                <script charset='utf-8' src='" + UrLstr + @"/lang/zh_CN.js'></script>
	                                <script charset='utf-8' src='" + UrLstr + @"/plugins/code/prettify.js'>
                                    </script>" : string.Empty;


        AllowFileManagerStr = allowFileManager ? "allowFileManager: true," : string.Empty;
        AllowImageUploadStr = allowImageUpload ? string.Empty : "allowImageUpload:false,";
        AllowFlashUploadStr = allowFlashUpload ? string.Empty : "allowFlashUpload:false,";
        AllowMediaUploadStr = allowMediaUpload ? string.Empty : "allowMediaUpload:false,";
        AllowFileUploadStr = allowFileUpload ? string.Empty : "allowFileUpload:false,";
        AllStr =    GetDeliveryLanguage(LanguageType)+
                    AllowFileManagerStr + 
                    AllowImageUploadStr + 
                    AllowFlashUploadStr + 
                    AllowMediaUploadStr +
                    AllowFileUploadStr;

    }



    /// <summary>
    /// 语言类型
    /// </summary>
    public enum LanguageMode
    {
        English,简体中文,繁體中文,Korean,Arabic
    }

    /// <summary>
    /// 默认语言
    /// </summary>
    public LanguageMode language = LanguageMode.简体中文;

    /// <summary>
    /// 国际化
    /// </summary>
    public LanguageMode LanguageType
    {
        get { return language; }
        set { language = value; }
    }

    /// <summary>
    /// 获取国际化
    /// </summary>
    /// <param name="delivery"> 国际化名称</param>
    /// <returns></returns>
    private static string GetDeliveryLanguage(LanguageMode delivery)
    {
        var dic = new Dictionary<string, string>();
        dic.Add("English", "langType:'en',");
        dic.Add("简体中文", string.Empty);//默认zh_CN
        dic.Add("繁體中文", "langType:'zh_TW',");
        dic.Add("Korean", "langType:'ko'");
        dic.Add("Arabic", "langType:'ar',");

        return dic[delivery.ToString()];
    }


    /// <summary>
    /// 宽度
    /// </summary>
    public string Width
    {
        get { return Editor.Width.ToString(); }
        set { Editor.Width = Unit.Parse(value); }
    }

    /// <summary>
    /// 高度
    /// </summary>
    public string Height
    {
        get { return Editor.Height.ToString(); }
        set { Editor.Height = Unit.Parse(value); }
    }

    /// <summary>
    /// 控件值
    /// </summary>
    public string Text
    {
        get { return Editor.Text; }
        set { Editor.Text = value; }
    }
    

    /// <summary>
    /// 控件模式枚举
    /// </summary>
    public enum EditorMode
    {
        仅表情, 高级, 普通, 文本, 视频
    }

    /// <summary>
    /// 默认模式
    /// </summary>
    private EditorMode mode = EditorMode.高级;

    /// <summary>
    /// 模式字符串
    /// </summary>
    protected string modeStr;

    /// <summary>
    /// 控件模式
    /// </summary>
    public EditorMode EditorType
    {
        get { return mode; }
        set
        {
            mode = value;

            switch (mode)
            {
                case EditorMode.普通:
                    modeStr = @"'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor',  'bold', 'italic', 'underline',
                                'removeformat', '|', 'justifyleft', 'justifycenter', 'justifyright',
                               '|', 'emoticons', 'image', 'link', 'fullscreen'";
                    break;

                case EditorMode.仅表情:
                    modeStr = @"'emoticons'";
                    break;

                case EditorMode.高级:
                    modeStr = @" 'source', '|', 'undo', 'redo', '|', 'preview', 'print', 'template', 'code', 'cut', 'copy', 'paste',
		                     'plainpaste', 'wordpaste', '|', 'justifyleft', 'justifycenter', 'justifyright',
		                     'justifyfull', 'insertorderedlist', 'insertunorderedlist', 'indent', 'outdent', 'subscript',
		                     'superscript', 'clearhtml', 'quickformat', 'selectall', '|', 'fullscreen', '/',
		                     'formatblock', 'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold',
		                     'italic', 'underline', 'strikethrough', 'lineheight', 'removeformat', '|', 'image', 'multiimage',
		                     'flash', 'media', 'insertfile', 'table', 'hr', 'emoticons', 'baidumap', 'pagebreak',
		                     'anchor', 'link', 'unlink'";//, '|', 'about'  //去掉关于编辑器说明
                    allowFileManager = true;
                    break;

                case EditorMode.文本:
                    modeStr = @"'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold', 'italic', 'underline',
                             'removeformat', '|', 'justifyleft', 'justifycenter', 'justifyright','link', 'fullscreen'";
                    break;

                case EditorMode.视频:
                    modeStr = @" 'media','|', 'preview'";
                    allowMediaUpload = false;
                    break;
            }
        }
    }

    #region 控件属性

    /// <summary>
    /// 样式
    /// </summary>
    public string StyleCSS
    {
        get { return _style; }
        set { _style = value; }
    }
    private string _style;

    /// <summary>
    /// 路径(默认为../kindeditor),只设置一次就可以。
    /// </summary>
    public string UrLstr
    {
        get { return _Url; }
        set { _Url = value; }
    }
    private string _Url = "../kindeditor";

    /// <summary>
    /// 是否是初始加载，加载多个kindeditor控件时,非第一个控件设置IsFirstLoad="false"属性
    /// </summary>
    public bool IsFirstLoad
    {
        get { return firstLoad; }
        set { firstLoad = value; }
    }
    private bool firstLoad = true;
    protected string FirstLoadStr = string.Empty;

    /// <summary>
    /// true为只读模式
    /// </summary>
    public bool ReadOnly
    {
        get { return readOnly; }
        set
        {
            readOnly = value;
            ReadOnlyStr = readOnly ? "editor.readonly(true);" : string.Empty;
        }
    }
    private bool readOnly = false;
    protected string ReadOnlyStr = string.Empty;

    /// <summary>
    /// 是否可以浏览服务器文件(浏览图片，视频等文件)
    /// </summary>
    public bool AllowFileManager
    {
        get { return allowFileManager; }
        set { allowFileManager = value; }
    }
    private bool allowFileManager = false;
    private string AllowFileManagerStr = string.Empty;

    /// <summary>
    /// true时显示图片上传按钮。
    /// </summary>
    public bool AllowImageUpload
    {
        get { return allowImageUpload; }
        set { allowImageUpload = value; }
    }
    private bool allowImageUpload = true;
    private string AllowImageUploadStr = string.Empty;

    /// <summary>
    /// true时显示Flash上传按钮。
    /// </summary>
    public bool AllowFlashUpload
    {
        get { return allowFlashUpload; }
        set { allowFlashUpload = value; }
    }
    private bool allowFlashUpload = true;
    private string AllowFlashUploadStr = string.Empty;


    /// <summary>
    /// true时显示视音频上传按钮。
    /// </summary>
    public bool AllowMediaUpload
    {
        get { return allowMediaUpload; }
        set { allowMediaUpload = value; }
    }
    private bool allowMediaUpload = true;
    private string AllowMediaUploadStr = string.Empty;

    /// <summary>
    /// true时显示文件上传按钮。
    /// </summary>
    public bool AllowFileUpload
    {
        get { return allowFileUpload; }
        set { allowFileUpload = value; }
    }
    private bool allowFileUpload = true;
    private string AllowFileUploadStr = string.Empty;

    /// <summary>
    /// 设置默认参数
    /// </summary>
    protected string AllStr = string.Empty;
    #endregion
}
