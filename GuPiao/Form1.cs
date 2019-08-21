using GP;
using HWAdmin.Common.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GuPiao
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_select_Click(object sender, EventArgs e)
        {
            //创建文件弹出选择窗口（包括文件名）对象
            OpenFileDialog ofd = new OpenFileDialog();
            //判断选择的路径
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                this.fileInput.Text = ofd.FileName.ToString();
            }
        }

        private void btn_FileUpload_Click(object sender, EventArgs e)
        {
            //上传
            var dt = NPOIHelper.ImportExceltoDt(fileInput.Text);
            DBContext db = new DBContext();

            foreach (DataRow item in dt.Rows)
            {
                T_SHISHU_INFO model = new T_SHISHU_INFO();
                model.Date = Convert.ToDateTime(item[0]);
                model.Code = item[1].ToString();
                model.Name = item[2].ToString();
                model.ClosePrice = Convert.ToDecimal(item[3]);
                model.MaxPrice = Convert.ToDecimal(item[4]);
                model.MinPrice = Convert.ToDecimal(item[5]);
                model.OpenPrice = Convert.ToDecimal(item[6]);
                model.PreClosePrice = Convert.ToDecimal(item[7]);
                model.RiseFallAmount = Convert.ToDecimal(item[8]);
                model.Risefall = Convert.ToDecimal(item[9]);
                model.BusinessQuantity = Convert.ToInt32(item[10]);
                model.BusinessAmount = Convert.ToDecimal(item[11]);
                db.Insert(model);
            }

            string s = "";
        }

        private void btn_compute_Click(object sender, EventArgs e)
        {
            //获取时间
            var start = txt_DateStart.Text;
            var end = txt_DateEnd.Text;
            //获取定投金额
            var tempAmount = Convert.ToInt32(txt_itemAmount.Text);
            var jx = 180;

            var list = GetData(start, end);
            //总金额
            decimal totalAmount = 0;
            //成本
            decimal cbAmount = 0;
            foreach (var item in list)
            {


            }



        }

        private List<T_SHISHU_INFO> GetData(string start, string end)
        {
            var sql = "SELECT * FROM dbo.T_SHISHU_INFO WHERE [Date] BETWEEN @0 AND  @1  ORDER BY [Date] ASC ";
            return new DBContext().Query<T_SHISHU_INFO>(sql, start, end).ToList();
        }
    }
}
