using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Drawing;

namespace silppm_v1e2.UI
{
    public partial class WebFormExcel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = GetDataTableFromExcel("",true);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        public static DataTable GetDataTableFromExcel(string path, bool hasHeader = true)
        {
            path = "C:\\Users\\Administrator\\Downloads\\pengabdian.xlsx";
            using (var pck = new OfficeOpenXml.ExcelPackage())
            {
                using (var stream = File.OpenRead(path))
                {
                    pck.Load(stream);
                }
                var ws = pck.Workbook.Worksheets.First();
                DataTable tbl = new DataTable();
                foreach (var firstRowCell in ws.Cells[1, 1, 1, ws.Dimension.End.Column])
                {
                    tbl.Columns.Add(hasHeader ? firstRowCell.Text : string.Format("Column {0}", firstRowCell.Start.Column));
                }
                var startRow = hasHeader ? 2 : 1;
                for (int rowNum = startRow; rowNum <= ws.Dimension.End.Row; rowNum++)
                {
                    var wsRow = ws.Cells[rowNum, 1, rowNum, ws.Dimension.End.Column];
                    DataRow row = tbl.Rows.Add();
                    foreach (var cell in wsRow)
                    {
                        row[cell.Start.Column - 1] = cell.Text;
                    }
                }
                return tbl;
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
//        static string[,] ClassNames =
//{
//   {"A","Red"},
//   {"B","Blue"},
//   {"C","Pink"},
//   {"D","Green"},
//   // and so on
//};
//        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
//        {
//            string className = e.Row.Cells[4].Text;
//            string color = "Black";
//            for (int i = 0; i <= ClassNames.GetUpperBound(0); i++)
//            {
//                if (ClassNames[i, 0] == className)
//                {
//                    color = ClassNames[i, 1];
//                    e.Row.Cells[2].ForeColor = Color.FromName(color);
//                    e.Row.Cells[2].BorderColor = Color.Black;
//                    break;
//                }
//            }
//        }
    }
}