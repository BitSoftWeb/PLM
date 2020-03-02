
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PLM_BusinessRlues;
using PLM_Model;
using MvcGuestBook.Common;
using ThoughtWorks.QRCode.Codec;
using System.Drawing;
using System.Text;
namespace FineUIPro.EmptyProjectNet40.PLM设备信息
{

    public partial class 设备台账 : System.Web.UI.Page
    {
        设备台账BLL bll = new 设备台账BLL();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)//是否是客户端回发而加载
            {
                //绑定树
                LoadData();
                BindEnumrable();
            }
        }

        #region JQueryFeature

        public class JQueryFeature
        {
            private string _id;

            public string Id
            {
                get { return _id; }
                set { _id = value; }
            }
            private string _name;

            public string Name
            {
                get { return _name; }
                set { _name = value; }
            }

            private int _level;

            public int Level
            {
                get { return _level; }
                set { _level = value; }
            }

            private bool _enableSelect;

            public bool EnableSelect
            {
                get { return _enableSelect; }
                set { _enableSelect = value; }
            }

            public JQueryFeature(string id, string name, int level, bool enableSelect)
            {
                _id = id;
                _name = name;
                _level = level;
                _enableSelect = enableSelect;
            }

            public override string ToString()
            {
                return String.Format("Name:{0}+Id:{1}", Name, Id);
            }
        }
        #endregion

        #region BindEnumrable

        private void BindEnumrable()
        {
            List<AM_部门级别汇总> listonejg = bll.查询部门汇总();
            List<JQueryFeature> myList = new List<JQueryFeature>();

            foreach (AM_部门级别汇总 item in listonejg)
            {
                myList.Add(new JQueryFeature(item.ID.ToString(), item.部门名称, 0, true));
                List<用户单位表> listyhdw = bll.查询二级结构(item.ID);
                foreach (var itemtwo in listyhdw)
                {
                    myList.Add(new JQueryFeature(itemtwo.ID.ToString(), itemtwo.名称, 1, true));
                    List<部门表> listbm = bll.查询三级结构(itemtwo.ID);
                    foreach (var items in listbm)
                    {
                        myList.Add(new JQueryFeature(items.ID.ToString(), items.名称, 2, true));
                    }
                }
            }

            ddlBox.DataTextField = "Name";
            ddlBox.DataValueField = "Id";
            ddlBox.DataSimulateTreeLevelField = "Level";
            ddlBox.DataEnableSelectField = "EnableSelect";
            ddlBox.DataSource = myList;
            ddlBox.DataBind();
            ddlBox.SelectedValue = "0";
        }
        #endregion

        private void LoadData()
        {
            // 从数据库返回数据表
            List<Z_一级结构表> listonejg = bll.查询一级结构();
            //查询设备总数
            设备总数.Text = "设备总数：" + bll.查询设备总数().ToString() + "台";

            设备总数.Text = "<span style='color:blue;font-weight:bold;'><H2><b>" + "设备总数：" + bll.查询设备总数().ToString() + "台" + "</b></H2></span>";
            故障总数.Text = "<span style='color:red;font-weight:bold;'><H2><b>" + "当前故障设备：" + bll.查询故障设备总数().ToString() + "台" + "</b></H2></span>";
            //故障总数.Text = "当前故障设备：" + bll.查询故障设备总数().ToString() + "台";
            foreach (Z_一级结构表 row in listonejg)
            {
                if (row.ID > 0)
                {
                    TreeNode node = new TreeNode();
                    node.IconUrl = @"~/res/icon/asterisk_orange.png";
                    node.Text = row.程序显示名称;
                    node.NodeID = row.ID + "-一级";
                    Tree1.Nodes.Add(node);
                    node.EnableClickEvent = true;
                    ResolveSubTwo(row, node);
                }
            }
        }

        private void ResolveSubTwo(Z_一级结构表 Row, TreeNode treeNode)
        {
            if (Row.ID > 0)
            {
                // 如果是目录，则默认展开
                //treeNode.Expanded = true;
                //treeNode.NodeID = "123";
                List<用户单位表> listyhdw = bll.查询二级结构(Row.ID);
                foreach (用户单位表 row in listyhdw)
                {
                    if (row.ID > 0)
                    {
                        TreeNode node = new TreeNode();
                        node.IconUrl = @"~/res/icon/asterisk_yellow.png";
                        node.Text = row.名称;
                        node.EnableClickEvent = true;
                        //node.NodeID = ;
                        node.NodeID = row.ID + "-二级";
                        treeNode.Nodes.Add(node);
                        ResolveSubTree(row, node);
                    }
                }
            }
        }

        private void ResolveSubTree(用户单位表 Row, TreeNode treeNode)
        {
            if (Row.ID > 0)
            {
                // 如果是目录，则默认展开
                List<部门表> listbm = bll.查询三级结构(Row.ID);
                foreach (部门表 row in listbm)
                {
                    if (row.ID > 0)
                    {
                        TreeNode node = new TreeNode();
                        node.IconUrl = @"~/res/icon/asterisk_red.png";
                        node.EnableClickEvent = true;
                        node.Text = row.名称;
                        node.NodeID = row.ID + "-三级";
                        treeNode.Nodes.Add(node);

                        //ResolveSubTree(row, node);
                    }
                }

            }
        }

        private void BindGrid()
        {

        }

        protected void Tree1_NodeCommand(object sender, TreeCommandEventArgs e)
        {

            //labResult.Text = "<span style='color:blue;font-weight:bold;'><H2>" + "设备总数:5000" + "</H2></span>";

            string nodeid = e.Node.NodeID;
            //Label1.Text = nodeid;

            string rank = "";//级别
            int ID = 0;
            if (nodeid.Length > 0)
            {
                string[] sArray = nodeid.Split('-');
                ID = Convert.ToInt32(sArray[0]);
                rank = sArray[1].ToString();
                // 3.绑定到Grid
                Grid1.DataSource = bll.查询树结构设备台账(ID, rank);
                Grid1.DataBind();
                if (rank == "二级")
                {
                    设备总数.Text = "<span style='color:blue;font-weight:bold;'><H2><b>" + "设备总数：" + bll.树形结构查询设备总数(ID, rank).ToString() + "台" + "</b></H2></span>";
                    故障总数.Text = "<span style='color:red;font-weight:bold;'><H2><b>" + "当前故障设备：" + bll.树形结构查询设备故障总数(ID, rank).ToString() + "台" + "</b></H2></span>";

                }
                else if (rank == "三级")
                {
                    设备总数.Text = "<span style='color:blue;font-weight:bold;'><H2><b>" + "设备总数：" + bll.树形结构查询设备总数(ID, rank).ToString() + "台" + "</b></H2></span>";
                    故障总数.Text = "<span style='color:red;font-weight:bold;'><H2><b>" + "当前故障设备：" + bll.树形结构查询设备故障总数(ID, rank).ToString() + "台" + "</b></H2></span>";
                }


            }



        }

        private void CreateQRImg(string str)
        {
            //Image2.Visible = true;
            Bitmap bt;
            string enCodeString = str;
            //生成设置编码实例
            QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
            //设置二维码的规模，默认4
            qrCodeEncoder.QRCodeScale = 4;
            //设置二维码的版本，默认7
            qrCodeEncoder.QRCodeVersion = 7;
            //设置错误校验级别，默认中等
            qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
            //生成二维码图片
            bt = qrCodeEncoder.Encode(enCodeString, Encoding.UTF8);
            //二维码图片的名称
            string filename = DateTime.Now.ToString("yyyyMMddHHmmss");
            //保存二维码图片在photos路径下
            bt.Save(Server.MapPath("~/photos/") + filename + ".jpg");
            //图片控件要显示的二维码图片路径
            this.Image3.ImageUrl = "~/photos/" + filename + ".jpg";
        }

        protected void Grid1_RowCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Action1")
            {
                object[] keys = Grid1.DataKeys[e.RowIndex];
                int ID = Convert.ToInt32(keys[0].ToString());//获取ID
                if (ID > 0)
                {
                    //ID,SBID,SAP编号,设备编号,设备名称,设备规格,设备型号,投产时间,部门名称,单位名称
                    SAP编号.Text = keys[2].ToString();
                    设备编号.Text = keys[3].ToString();
                    设备名称.Text = keys[4].ToString();

                    try
                    {
                        设备规格.Text = keys[5].ToString();
                    }
                    catch (Exception)
                    {
                        设备规格.Text = "";
                        //throw;
                    }
                    设备型号.Text = keys[6].ToString();
                    投产时间.Text = keys[7].ToString();
                    所属部门.Text = keys[8].ToString();
                    所属单位.Text = keys[9].ToString();

                    TabStrip1.ActiveTabIndex = 0;
                    string xx = 设备编号.Text + "," + 设备名称.Text;
                    CreateQRImg(xx);

                    Window1.Hidden = false;
                }
            }
            else if (e.CommandName == "Action2")
            {
                //Window2.Hidden = false;
                JsObjectBuilder joBuilder = new JsObjectBuilder();
                joBuilder.AddProperty("id", "grid_newtab_sametab_addnew");
                joBuilder.AddProperty("title", "新增人员");
                joBuilder.AddProperty("iframeUrl", ResolveUrl("~/PLM设备信息/设备履历.aspx"));
                joBuilder.AddProperty("refreshWhenExist", true);
                joBuilder.AddProperty("iconFont", "plus");
                String.Format("parent.addExampleTab({0});", joBuilder);

            }
        }

        protected string GetEditUrl(object id, object name, object tcsj)
        {
            JsObjectBuilder joBuilder = new JsObjectBuilder();
            joBuilder.AddProperty("设备编号", "设备编号" + id);
            joBuilder.AddProperty("title", "设备履历时间轴 - " + name);
            joBuilder.AddProperty("iframeUrl", ResolveUrl(String.Format("~/PLM设备信息/设备履历.aspx?SBBH={0}&tcsj={1}", id, HttpUtility.UrlEncode(tcsj.ToString()))));
            joBuilder.AddProperty("refreshWhenExist", true);
            joBuilder.AddProperty("iconFont", "pencil");

            // addExampleTab函数定义在default.aspx addExampleTab
            return String.Format("parent.addExampleTab({0});", joBuilder);
        }
        protected string GetEditUrls(object id)
        {
            JsObjectBuilder joBuilder = new JsObjectBuilder();
            joBuilder.AddProperty("设备编号", "设备编号" + id);
            joBuilder.AddProperty("title", "设备全生命周期 - " + id);
            joBuilder.AddProperty("iframeUrl", ResolveUrl(String.Format("~/PLM设备信息/全生命周期页面.aspx?SBBH={0}", id)));
            joBuilder.AddProperty("refreshWhenExist", true);
            joBuilder.AddProperty("iconFont", "pencil");
            // addExampleTab函数定义在default.aspx addExampleTab
            return String.Format("parent.addExampleTab({0});", joBuilder);
        }


        protected void TabStrip1_TabIndexChanged(object sender, EventArgs e)
        {
            if (TabStrip1.ActiveTabIndex == 0)
            {



            }
            else if (TabStrip1.ActiveTabIndex == 1)
            {
                //查询关联备件
                string sbmc = "";
                int 所属单位 = 0;
                int[] selections = Grid1.SelectedRowIndexArray;
                foreach (int rowIndex in selections)
                {
                    sbmc = Grid1.DataKeys[rowIndex][4].ToString();
                    所属单位 = Convert.ToInt16(Grid1.DataKeys[rowIndex][10]);
                }
                Grid2.DataSource = bll.设备名称关联备件(sbmc, 所属单位);
                Grid2.DataBind();

            }
            else if (TabStrip1.ActiveTabIndex == 2)
            {

                //维修情况
                //string sbbh = "";
                //int[] selections = Grid1.SelectedRowIndexArray;
                //foreach (int rowIndex in selections)
                //{
                //    sbbh = Grid1.DataKeys[rowIndex][3].ToString();
                //}
                Grid3.DataSource = bll.设备编号关联维修情况(设备编号.Text);
                Grid3.DataBind();
            }
            else if (TabStrip1.ActiveTabIndex == 3)
            {
                //设备BOM
            }
            else if (TabStrip1.ActiveTabIndex == 4)
            {
                //备件消耗
                Grid4.DataSource = bll.设备编号查询备件消耗(设备编号.Text);
                Grid4.DataBind();
            }
            else if (TabStrip1.ActiveTabIndex == 5)
            {
                //预防性维修
                string sbbc = 设备名称.Text;

                //text.Text = bll.查询单台设备平均故障时间("999-1252", "喷枪");
                List<预防性维修> listmodel = bll.查询设备平均故障时间(sbbc);
                Grid5.DataSource = listmodel;
                Grid5.DataBind();

                //List<预防性维修> listmodel = bll.查询设备平均故障时间("车体喷砂系统");

            }
        }









    }
}