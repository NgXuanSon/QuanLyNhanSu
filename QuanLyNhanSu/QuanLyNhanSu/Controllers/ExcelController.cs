using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyNhanSu.Controllers
{
    public class ExcelController : Controller
    {
        // GET: Excel
        //upload file
        private void UploadExcelFile(HttpPostedFileBase file)
        {
            //dat ten cho file
            string fileName = "File Name";
            //duong dan luu file
            string path = Path.Combine(Server.MapPath("~/Uploads/Excels"), fileName);
            //luu file len server
            file.SaveAs(path);
        }

        //download file
        public ActionResult DownloadFile()
        {
            //duong dan chua file muon download
            string path = AppDomain.CurrentDomain.BaseDirectory + "Uploads/Excels/";
            //chuyen file sang dang byte
            byte[] fileBytes = System.IO.File.ReadAllBytes(path + "FileMau.xlsx");
            //ten file khi download ve
            string fileName = "FileDownLoad.xlsx";
            //tra ve file
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }

        //doc file excel tra ve du lieu dang datatable
        public DataTable ReadDataFromExcelFile(string filepath)
        {
            string connectionString = "";
            string fileExtention = filepath.Substring(filepath.Length - 4).ToLower();
            if (fileExtention.IndexOf("xlsx") == 0)
            {
                connectionString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source =" + filepath + ";Extended Properties=\"Excel 12.0 Xml;HDR=NO\"";
            }
            else if (fileExtention.IndexOf("xls") == 0)
            {
                connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filepath + ";Extended Properties=Excel 8.0";
            }

            // Tạo đối tượng kết nối
            OleDbConnection oledbConn = new OleDbConnection(connectionString);
            DataTable data = null;
            try
            {
                // Mở kết nối
                oledbConn.Open();

                // Tạo đối tượng OleDBCommand và query data từ sheet có tên "Sheet1"
                OleDbCommand cmd = new OleDbCommand("SELECT * FROM [Sheet1$]", oledbConn);

                // Tạo đối tượng OleDbDataAdapter để thực thi việc query lấy dữ liệu từ tập tin excel
                OleDbDataAdapter oleda = new OleDbDataAdapter();
                oleda.SelectCommand = cmd;

                // Tạo đối tượng DataSet để hứng dữ liệu từ tập tin excel
                DataSet ds = new DataSet();

                // Đổ đữ liệu từ tập excel vào DataSet
                oleda.Fill(ds);
                data = ds.Tables[0];
            }
            catch
            {
            }
            finally
            {
                // Đóng chuỗi kết nối
                oledbConn.Close();
            }
            return data;
        }

        //copy large data from datatable to sqlserver
        private void CopyDataByBulk(DataTable dt)
        {
            //lay ket noi voi database luu trong file webconfig
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["QuanLyNhanSuDbContext"].ConnectionString);
            SqlBulkCopy bulkcopy = new SqlBulkCopy(con);
            bulkcopy.DestinationTableName = "Ten bang";
            bulkcopy.ColumnMappings.Add(0, "ten cot 1");
            bulkcopy.ColumnMappings.Add(1, "ten cot 2");
            bulkcopy.ColumnMappings.Add(2, "ten cot 3");
            con.Open();
            bulkcopy.WriteToServer(dt);
            con.Close();
        }

        //upload file excel
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file)
        {
            try
            {
                //upload file thanh cong va file co du lieu
                if (file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Uploads/Excels"), fileName);
                    file.SaveAs(path);
                    ViewBag.Success = "Uploaded";
                }
                else
                {
                    ViewBag.Error = "You need select file";
                }
            }
            catch (Exception ex)
            {
                //neu upload file that bai
                ViewBag.Error = "Error" + ex;
            }
            return View();
        }
    }
}