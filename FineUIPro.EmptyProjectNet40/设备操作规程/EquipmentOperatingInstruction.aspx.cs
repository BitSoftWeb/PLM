using PLM.BusinessRlues;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace FineUIPro.EmptyProjectNet40.设备操作规程
{
    public partial class EquipmentOperatingInstruction : PageBase
    {

        设备操作规程_BLL sbczgcbll = new 设备操作规程_BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            
                BindGrid();
            }
        }
        private void BindGrid()
        {
            //List<Z_设备类型表> sbmc = sbczgcbll.查询设备类型();
            //DropDownList1.DataTextField = "设备类型";
            //DropDownList1.DataValueField = "ID";
            //DropDownList1.DataSource = sbmc;
            //DropDownList1.DataBind();
            //DropDownList1.EmptyText = "全部";

            DataSet ds = sbczgcbll.文件上传查询();
            System.Data.DataTable dt = ds.Tables[0].Copy();//复制一份table
            Grid1.DataSource = dt;
            Grid1.DataBind();
        }

        protected bool ValidateFileType(string fType)
        {

            string houzhuiming = Path.GetExtension(filePhoto.PostedFile.FileName).ToLower();


            if (fType == "application/msword" || fType == "application/pdf" || houzhuiming == ".doc" || houzhuiming == ".pdf" || houzhuiming == ".ppt" || houzhuiming == ".pptx" || houzhuiming == ".wps" || houzhuiming == ".et" || houzhuiming
                 == ".dps" || houzhuiming == ".docx")
            {
                if (AddWord() > 0)
                {
                    FineUIPro.Alert.Show("文件上传成功!");
                }
                return true;
            }
            else if (fType == "application/vnd.ms-excel" || fType == "application/pdf" || houzhuiming == ".xlsx" || houzhuiming == ".pdf" || houzhuiming == ".ppt" || houzhuiming == ".pptx" || houzhuiming == ".wps" || houzhuiming == ".et" || houzhuiming
                 == ".dps" || houzhuiming == ".xls" || houzhuiming == ".csv")
            {
                if (AddWord() > 0)
                {
                    FineUIPro.Alert.Show("文件上传成功!");
                }
                return true;
            }
            else if (houzhuiming == ".jpg" || houzhuiming == ".jpeg" || houzhuiming == ".png" || houzhuiming == ".gif" || houzhuiming == ".bmp")
            {
                if (AddWord() > 0)
                {
                    FineUIPro.Alert.Show("文件上传成功!");
                }
                return true;
            }
            else
            {
                return false;
            }

        }

        public string GetNewFileName(string FileName)
        {
            //获取随机文件名称
            Random rand = new Random();
            string newfilename = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + "m" +
             DateTime.Now.Day.ToString() + "d"
            + DateTime.Now.Second.ToString() + DateTime.Now.Minute.ToString()
            + DateTime.Now.Millisecond.ToString()
                + "a" + rand.Next(1000).ToString()
            + FileName.Substring(FileName.LastIndexOf("."), FileName.Length - FileName.LastIndexOf("."));
            return newfilename;
        }

        private int AddWord()
        {
            if (this.filePhoto.HasFile)
            {
                //文件名
                string fileName = this.filePhoto.FileName;
                //文件路径
                string path = "/UploadFile";
                //本地路径
                string localPath = Server.MapPath(Request.ApplicationPath + path);
                //全路径
                string fullPath = localPath + "\\" + fileName;
                this.filePhoto.SaveAs(fullPath);
            }
            string strFileFullName = System.IO.Path.GetFileName(this.filePhoto.PostedFile.FileName);
            if (strFileFullName.Length > 0)
            {
                if (filePhoto.HasFile)
                {
                    //新文件名
                    string newFileName = GetNewFileName(strFileFullName);
                    //路径
                    string path = Server.MapPath(@"~/UploadFile" + "/" + newFileName);
                    //保存路径
                    string pathSaveImg = Server.MapPath(@"~/UploadFile" + "/" + newFileName);
                    if (Directory.Exists(Server.MapPath(@"~/UploadFile")))
                    {
                        Directory.CreateDirectory(Server.MapPath(@"~/UploadFile"));
                    }
                    this.filePhoto.SaveAs(path);
                }
                else
                {
                    Alert.Show("找不到此文档!", MessageBoxIcon.Warning);

                }
                return 1;
            }
            else
            {
                return 0;
            }

        }

        //查询下载方法
        protected void Grid1_RowCommand(object sender, GridCommandEventArgs e)
        {
            
            
            object[] keys = Grid1.DataKeys[e.RowIndex];
            string houzhuiming = keys[6].ToString();
            if (e.CommandName == "Action2")//下载
            {
                string ID = keys[0].ToString();//获取ID
                string fileName = keys[5].ToString();

                if (houzhuiming == ".jpg" || houzhuiming == ".jpeg" || houzhuiming == ".png" || houzhuiming == ".gif" || houzhuiming == ".bmp")
                {
                    string fileName_a = keys[3].ToString();//图片名字
                    string filePath = Server.MapPath("\\UploadFile\\" + keys[3].ToString());//图片路径

                    //以字符流的形式下载文件
                    FileStream fs = new FileStream(filePath, FileMode.Open);
                    byte[] bytes = new byte[(int)fs.Length];
                    fs.Read(bytes, 0, bytes.Length);
                    fs.Close();
                    Response.ContentType = "application/octet-stream";
                    //通知浏览器下载文件而不是打开
                    Response.AddHeader("Content-Disposition", "attachment;  filename=" + HttpUtility.UrlEncode(fileName_a, System.Text.Encoding.UTF8));
                    Response.BinaryWrite(bytes);
                    Response.Flush();
                    Response.End();
                }
                else
                {
                    Response.Redirect(@"\UploadFile\" + fileName);

                }
            }
            else if (e.CommandName == "Action1")//查看详情
            {
                if (houzhuiming == ".jpg" || houzhuiming == ".jpeg" || houzhuiming == ".png" || houzhuiming == ".gif" || houzhuiming == ".bmp")
                {
                    window1.Hidden = false;
                    image_1.ImageUrl = @"\UploadFile\" + keys[5].ToString();
                }
                else
                {
                    string filename = keys[5].ToString();//获取文件名
                    string[] temp = filename.Split('.');
                    string Name = temp[0];
                    string pdfname = @"\PDF\" + Name + ".pdf";

                    Response.Redirect(pdfname, false);
                    
                    //Response.Write("<script>window.open('"+pdfname+"','_blank')</script>");
                    //Respose.Write("<script language='javascript'>window.open('"+ url+"');</script>");
                }

            }
        }

        protected void upFile_Click(object sender, EventArgs e)
        {
            Window2.Hidden = false;
            string s_search = "";
            DataSet ds = sbczgcbll.查询设备类型(s_search);
            System.Data.DataTable dt = ds.Tables[0].Copy();//复制一份table
            Grid2.DataSource = dt;
            Grid2.DataBind();
        }

        protected void ttSearch_Trigger2Click(object sender, EventArgs e)
        {
            string sSearch = ttSearch.Text.ToString(); 
            DataSet ds = sbczgcbll.设备操作规程查询(sSearch);
            DataTable dt = ds.Tables[0].Copy();//复制一份table
            Grid1.DataSource = dt;//DataTable
            Grid1.DataBind();
        }

        
        protected void Grid2_RowClick(object sender, GridRowClickEventArgs e)
        {
            //object[] keys = Grid2.DataKeys[e.RowIndex];
            // IDX = Convert.ToInt32(keys[0].ToString());
        }

        //提交
        protected void Unnamed_Click(object sender, EventArgs e)
        {
            
            //判断是否含有文件
            if (filePhoto.HasFile)
            {
                //文件类型
                string ftyp = filePhoto.PostedFile.ContentType;
                string newfile = GetNewFileName(filePhoto.ShortFileName);
                string fileName = filePhoto.ShortFileName;
                if (!ValidateFileType(fileName))
                {
                    // 清空文件上传控件
                    filePhoto.Reset();
                    Alert.Show("无效的文件类型！", MessageBoxIcon.Warning);
                    return;
                }
                string houzhuiming = Path.GetExtension(filePhoto.PostedFile.FileName).ToLower();
                //文件名
                fileName = this.filePhoto.FileName;
                //文件路径
                string path = "/uploadFile";
                //本地路径
                string localPath = Server.MapPath(Request.ApplicationPath + path);
                //全路径
                string fullPath = localPath + "\\" + fileName;
                string fullPathNew = localPath + "\\" + newfile;
                this.filePhoto.SaveAs(fullPath);
                this.filePhoto.SaveAs(fullPathNew);

                string nowTime = DateTime.Now.ToString();
                int ID = 0;
                int[] setion = Grid2.SelectedRowIndexArray;
                foreach (int item in setion)
                {
                    ID = Convert.ToInt32(Grid2.DataKeys[item][0]);
                    string sblx = Grid2.DataKeys[item][1].ToString();
                }

                int selections=ID;
                Window2.Hidden = true;
                DataSet ds = sbczgcbll.文件上传功能(selections, fileName, newfile, nowTime, houzhuiming);

                string office = @"\UploadFile\" + newfile + "";
                string[] temp = newfile.Split('.');
                string Name = temp[0];
                //string fileNameall = Name;
                //List<Z_设备类型表> listdata = sbczgcbll.设备类型(fileNameall);

                string pdfname = @"\PDF\" + Name + ".pdf";

                if (houzhuiming == ".docx" || houzhuiming == ".doc")
                {

                    PLM_Common.OfficeOfPDF.DOCConvertToPDF(MapPath(office), MapPath(pdfname));
                }
                else if (houzhuiming == ".xlsx" || houzhuiming == ".xls")
                {
                    PLM_Common.OfficeOfPDF.XLSConvertToPDF(MapPath(office), MapPath(pdfname));
                }
                else if (houzhuiming == ".ppt" || houzhuiming == ".pptx")
                {
                    PLM_Common.OfficeOfPDF.PPTConvertToPDF(MapPath(office), MapPath(pdfname));
                }
                
                BindGrid();
            }
            else
            {
                PageContext.RegisterStartupScript("alert('请选中文件')");
            }
        }

        //设备操作规程模糊查询
        protected void tt_Search_Trigger2Click(object sender, EventArgs e)
        {
            string sSearchs = tt_Search.Text.ToString();
            DataSet ds = sbczgcbll.设备操作规程模糊查询(sSearchs);
            DataTable dt = ds.Tables[0].Copy();//复制一份table
            Grid2.DataSource = dt;//DataTable
            Grid2.DataBind();
        }


    }
}