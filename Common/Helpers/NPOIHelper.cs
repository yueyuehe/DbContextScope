using NPOI.HPSF;
using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.SS.Formula.Eval;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace Common.Helpers
{
    /// <summary>
    /// NPOI的工具类
    /// </summary>
    public class NPOIHelper
    {
        /// <summary>
        /// 创建一个新的工作簿，默认有三个sheet
        /// </summary>
        /// <returns></returns>
        public static HSSFWorkbook CreateNewWorkbook()
        {
            HSSFWorkbook hssfworkbook = new HSSFWorkbook();
            ////创建excel基本属性信息
            DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
            dsi.Company = "";
            hssfworkbook.DocumentSummaryInformation = dsi;

            ////create a entry of SummaryInformation
            SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
            si.Subject = "NPOI SDK Example";
            hssfworkbook.SummaryInformation = si;

            ///必须至少创见一个sheet 这里默认创建3个
            //here, we must insert at least one sheet to the workbook. otherwise, Excel will say 'data lost in file'
            //So we insert three sheet just like what Excel does
            hssfworkbook.CreateSheet("Sheet1");
            hssfworkbook.CreateSheet("Sheet2");
            hssfworkbook.CreateSheet("Sheet3");
            ((HSSFSheet)hssfworkbook.GetSheetAt(0)).AlternativeFormula = false;
            ((HSSFSheet)hssfworkbook.GetSheetAt(0)).AlternativeExpression = false;
            return hssfworkbook;
        }


        /// <summary>
        /// 加载文件Excel
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public static HSSFWorkbook CreateNewWorkbook(string filepath)
        {
            using (FileStream file = new FileStream(filepath, FileMode.Open, FileAccess.Read))
            {
                return new HSSFWorkbook(file);
            }
        }


        /// <summary>
        /// 创建新的workbook
        /// </summary>
        /// <returns></returns>
        public static HSSFWorkbook CreateWorkBook()
        {
            return new HSSFWorkbook();
        }
        #region Sheet样式操作相关
        /// <summary>
        /// 改变sheet的颜色
        /// </summary>
        /// <param name="sheet">sheet</param>
        /// <param name="colorIndex">NPOI定义的颜色index的short值 如：HSSFColor.RED.index</param>
        public void ChangeSheetTabColor(ISheet sheet, short colorIndex)
        {
            sheet.TabColorIndex = colorIndex;
        }

        /// <summary>
        /// 隐藏行
        /// </summary>
        /// <param name="row"></param>
        public void HideRow(IRow row)
        {
            if (!row.ZeroHeight)
            {
                row.ZeroHeight = true;
            }
        }

        /// <summary>
        /// 显示行
        /// </summary>
        /// <param name="row"></param>
        public void ShowRow(IRow row)
        {
            if (row.ZeroHeight)
            {
                row.ZeroHeight = false;
            }
        }

        /// <summary>
        /// 隐藏列
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="columnIndex">列索引</param>
        public void HideColumn(ISheet sheet, Int32 columnIndex)
        {
            sheet.SetColumnHidden(columnIndex, true);
        }

        /// <summary>
        /// 显示列
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="columnIndex"></param>
        public void ShowColumn(ISheet sheet, Int32 columnIndex)
        {
            sheet.SetColumnHidden(columnIndex, false);
        }


        /// <summary>
        /// 设置列宽
        /// </summary>
        /// <param name="sheet">sheet</param>
        /// <param name="colIndex">列索引</param>
        /// <param name="width">列宽</param>
        public void SetColumnWidth(ISheet sheet, int colIndex, int width)
        {
            sheet.SetColumnWidth(colIndex, width);
        }

        /// <summary>
        /// 设置列宽
        /// </summary>
        /// <param name="cell">单元格</param>
        /// <param name="width">列宽</param>
        public void SetColumnWidth(ICell cell, int width)
        {
            cell.Sheet.SetColumnWidth(cell.ColumnIndex, width);
        }


        /// <summary>
        /// 设置行高
        /// </summary>
        /// <param name="row">行</param>
        /// <param name="height">行高</param>
        public void SetRowHeight(IRow row, short height)
        {
            row.Height = height;
        }

        /// <summary>
        /// 设置sheet的单元格没有边界
        /// </summary>
        /// <param name="sheet"></param>
        public void DisplayGridlines(ISheet sheet)
        {
            if (sheet.DisplayGridlines)
            {
                sheet.DisplayGridlines = false;
            }
        }

        /// <summary>
        /// 切换是否收缩适应单元格 默认是不收缩
        /// </summary>
        /// <param name="cell"></param>
        public void ToggleShrinkToFit(ICell cell)
        {
            if (cell.CellStyle.ShrinkToFit)
            {
                cell.CellStyle.ShrinkToFit = false;
            }
            else
            {
                cell.CellStyle.ShrinkToFit = true;
            }

        }

        #endregion

        #region 单元格格式设置

        /// <summary>
        /// 设置内容的旋转角度，0不旋转
        /// </summary>
        /// <param name="cell"></param>
        /// <param name="x">旋转角度</param>
        public void SetCellRotation(ICell cell, short x)
        {
            cell.CellStyle.Rotation = x;
        }
        /// <summary>
        /// 设置单元格内容水平位置
        /// </summary>
        /// <param name="cell"></param>
        /// <param name="option"></param>
        public void SetCellHorizontalAlignment(ICell cell, HorizontalAlignment option)
        {
            cell.CellStyle.Alignment = HorizontalAlignment.Left;
        }

        /// <summary>
        /// 设置单元格内容垂直方向位置
        /// </summary>
        /// <param name="cell">单元格</param>
        /// <param name="option">位置</param>
        public void SetCellVerticalAlignment(ICell cell, VerticalAlignment option)
        {
            cell.CellStyle.VerticalAlignment = option;
        }

        /// <summary>
        /// 给单元格设置边框
        /// </summary>
        /// <param name="cell">单元格</param>
        /// <param name="borderStyle">单元格边框类型</param>
        /// <param name="color">单元格边框颜色</param>
        public void SetCellBorder(ICell cell, BorderStyle borderStyle, HSSFColor color)
        {
            cell.CellStyle.BorderBottom = borderStyle;
            cell.CellStyle.BorderLeft = borderStyle;
            cell.CellStyle.BorderRight = borderStyle;
            cell.CellStyle.BorderTop = borderStyle;
            cell.CellStyle.BottomBorderColor = color.Indexed;
            cell.CellStyle.LeftBorderColor = color.Indexed;
            cell.CellStyle.RightBorderColor = color.Indexed;
            cell.CellStyle.TopBorderColor = color.Indexed;
        }

        /// <summary>
        /// 设置单元格边框 黑色 实线
        /// </summary>
        /// <param name="cell"></param>
        public void SetCellBorder(ICell cell)
        {
            cell.CellStyle.BorderBottom = BorderStyle.Thin;
            cell.CellStyle.BorderLeft = BorderStyle.Thin;
            cell.CellStyle.BorderRight = BorderStyle.Thin;
            cell.CellStyle.BorderTop = BorderStyle.Thin;
            cell.CellStyle.BottomBorderColor = HSSFColor.Black.Index;
            cell.CellStyle.LeftBorderColor = HSSFColor.Black.Index;
            cell.CellStyle.RightBorderColor = HSSFColor.Black.Index;
            cell.CellStyle.TopBorderColor = HSSFColor.Black.Index;
        }

        /// <summary>
        /// 给单元格设置字体大小
        /// </summary>
        /// <param name="cell">单元格</param>
        /// <param name="color">颜色</param>
        /// <param name="fontSize">字体大小 </param>
        public void SetFontStyle(ICell cell, HSSFColor color, short fontSize)
        {
            IFont font = cell.Sheet.Workbook.CreateFont();
            font.Color = color.Indexed;
            font.FontHeightInPoints = fontSize;
            font.FontName = "宋体";
            cell.CellStyle.SetFont(font);
        }

        /// <summary>
        /// 单元格内容可换行
        /// </summary>
        /// <param name="cell">单元格</param>
        /// <param name="lines">可见换行数</param>
        public void SetCellNewlines(ICell cell, Int32 lines)
        {
            if (lines < 1)
            {
                lines = 1;
            }
            ICellStyle style = cell.CellStyle;
            style.WrapText = true;
            cell.Row.HeightInPoints = lines * cell.Sheet.DefaultRowHeightInPoints;
        }


        /// <summary>
        /// 设置单元格背景颜色
        /// </summary>
        /// <param name="cell">单元格</param>
        /// <param name="color">背景颜色</param>
        public void SetCellBackgroundColor(ICell cell, HSSFColor color)
        {
            cell.CellStyle.FillForegroundColor = color.Indexed;
        }

        #endregion

        #region 其他操作
        /// <summary>
        /// 设置sheet的页眉
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="leftHeader">左 不设置传空字符或null</param>
        /// <param name="centerHeader">中 不设置传空字符或null</param>
        /// <param name="rightHeader">右 不设置传空字符或null</param>
        public void SetSheetHeader(ISheet sheet, string leftHeader, string centerHeader, string rightHeader)
        {
            //sheet.Header.Left = HSSFHeader.Page;   //Page is a static property of HSSFHeader and HSSFFooter
            if (!string.IsNullOrEmpty(leftHeader))
            {
                sheet.Header.Left = leftHeader;
            }
            if (!string.IsNullOrEmpty(centerHeader))
            {
                sheet.Header.Center = centerHeader;
            }
            if (!string.IsNullOrEmpty(rightHeader))
            {
                sheet.Header.Right = rightHeader;
            }
        }

        /// <summary>
        /// 设置sheet的页脚
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="leftFooter">左 不设置传空字符或null</param>
        /// <param name="centerFooter">中 不设置传空字符或null</param>
        /// <param name="rightFooter">右 不设置传空字符或null</param>
        public void SetSheetFooter(ISheet sheet, string leftFooter, string centerFooter, string rightFooter)
        {
            //sheet.Footer.Left = HSSFFooter.Page;   //返回当前的page页码
            if (!string.IsNullOrEmpty(leftFooter))
            {
                sheet.Footer.Left = leftFooter;
            }
            if (!string.IsNullOrEmpty(centerFooter))
            {
                sheet.Footer.Center = centerFooter;
            }
            if (!string.IsNullOrEmpty(rightFooter))
            {
                sheet.Footer.Right = rightFooter;
            }
        }


        /// <summary>
        /// 设置缩放比例 缩放比例为 x/y
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void SetZoom(ISheet sheet, int x, int y)
        {
            sheet.SetZoom(x, y);
        }
        /// <summary>
        /// 固定行，列
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="colSplit">从第几列固定 如果colSplit小于1 默认列不固定  </param>
        /// <param name="rowSplit">从第行列固定 rowSplit小于1 默认行不固定</param>
        public void CreateFreezePane(ISheet sheet, int colSplit, int rowSplit)
        {
            if (colSplit < 0)
            {
                colSplit = 0;
            }
            if (rowSplit < 0)
            {
                rowSplit = 0;
            }
            sheet.CreateFreezePane(colSplit, rowSplit);
        }

        /// <summary>
        /// 将sheet设置为保护状态
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="parssword">密码 </param>
        public void ProtectSheet(ISheet sheet, string parssword)
        {
            sheet.ProtectSheet(parssword);
        }

        #endregion

        #region 单元格基本操作
        /// <summary>
        /// 对单元格新增超链接 
        /// DOCUMENT:打开本工作簿指定的sheet
        /// </summary>
        /// <param name="cell"></param>
        /// <param name="linkType">DOCUMENT，EMAIL，FILE，URL，Unknown(未知)</param>
        /// <param name="linkAddress">链接地址</param>
        /// <param name="cellValue">单元格显示的值</param>
        public void AddCellLink(ICell cell, HyperlinkType linkType, string linkAddress, string cellValue)
        {
            cell.SetCellValue(cellValue);
            HSSFHyperlink link = new HSSFHyperlink(linkType);
            link.Address = linkAddress;
            if (linkType != HyperlinkType.Unknown)
            {
                cell.Hyperlink = link;
            }
        }

        /// <summary>
        /// 设置时间格式的值
        /// </summary>
        /// <param name="cell"></param>
        /// <param name="dateTime"></param>
        /// <param name="formatStr">格式 null或"" 时格式是yyyy-mm-dd</param>
        public void SetDataTimeValue(ICell cell, DateTime dateTime, string formatStr)
        {
            if (string.IsNullOrEmpty(formatStr))
            {
                formatStr = "yyyy-mm-dd";
            }
            cell.SetCellValue(dateTime);
            CellDataFormat(cell, formatStr);
            ICellStyle cellStyle = cell.CellStyle;
        }

        /// <summary>
        /// 格式化数据
        /// </summary>
        /// <param name="cell"></param>
        /// <param name="formatStr"></param>
        public void CellDataFormat(ICell cell, string formatStr)
        {
            IDataFormat format = cell.Sheet.Workbook.CreateDataFormat();
            ICellStyle cellStyle = cell.CellStyle;
            cellStyle.DataFormat = format.GetFormat(formatStr);
        }

        /// <summary>
        /// 格式化单元格 
        /// formatStr: 常用
        /// "0.00" 保留两位小数
        /// "¥#,##0" 20000 ->  ¥20,000
        /// "0.00%"  0.9933 -> 99.33%
        /// "000-00000000" 02165881234 ->  021-65881234
        /// 0.00E+00  3.151234 -> 3.15E+00
        /// </summary>
        /// <param name="cell"></param>
        /// <param name="value"></param>
        /// <param name="formatStr"></param>
        public void SetNumberValue(ICell cell, double value, string formatStr)
        {
            IDataFormat format = cell.Sheet.Workbook.CreateDataFormat();
            cell.SetCellValue(value);
            CellDataFormat(cell, formatStr);
        }


        /// <summary>
        /// 合并单元格，rowspan 跨行数，colspan跨列数
        /// </summary>
        /// <param name="cell"></param>
        /// <param name="rowSpan"></param>
        /// <param name="columnSpan"></param>
        public void CellMerge(ICell cell, int rowspan, int colspan)
        {
            ///默认不跨列与行
            if (rowspan < 1)
            {
                rowspan = 1;
            }
            if (colspan < 1)
            {
                colspan = 1;
            }
            if (!cell.IsMergedCell)
            {
                int rowIndex = cell.RowIndex;
                int columnIndex = cell.ColumnIndex;
                cell.Sheet.AddMergedRegion(new CellRangeAddress(rowIndex, rowIndex + rowspan - 1, columnIndex, columnIndex + colspan - 1));
            }
        }

        /// <summary>
        /// 得到单元格在sheet中的位置 ;
        /// </summary>
        /// <param name="cell"></param>
        /// <returns>表示单元格在sheet中位置的字符串</returns>
        public string GetCellPosition(ICell cell)
        {
            int row = cell.RowIndex;
            int col = cell.ColumnIndex;
            col = Convert.ToInt32('A') + col;
            row = row + 1;
            return ((char)col) + row.ToString();
        }


        /// <summary>
        /// 给单元格设置公式
        /// </summary>
        /// <param name="cell">单元格</param>
        /// <param name="formulaStr">公式字符</param>
        public void SetCellFormula(ICell cell, string formulaStr)
        {
            cell.CellFormula = formulaStr;
        }
        #endregion

        /****************************----NOPIHelper---**********************************/

        //  private static WriteLog wl = new WriteLog();

        #region 从datatable中将数据导出到excel
        /// <summary>
        /// DataTable导出到Excel的MemoryStream
        /// </summary>
        /// <param name="dtSource">源DataTable</param>
        /// <param name="strHeaderText">表头文本</param>
        static MemoryStream ExportDT(DataTable dtSource, string strHeaderText)
        {
            HSSFWorkbook workbook = new HSSFWorkbook();
            HSSFSheet sheet = workbook.CreateSheet() as HSSFSheet;

            #region 右击文件 属性信息

            //{
            //    DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
            //    dsi.Company = "http://www.yongfa365.com/";
            //    workbook.DocumentSummaryInformation = dsi;

            //    SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
            //    si.Author = "柳永法"; //填加xls文件作者信息
            //    si.ApplicationName = "NPOI测试程序"; //填加xls文件创建程序信息
            //    si.LastAuthor = "柳永法2"; //填加xls文件最后保存者信息
            //    si.Comments = "说明信息"; //填加xls文件作者信息
            //    si.Title = "NPOI测试"; //填加xls文件标题信息
            //    si.Subject = "NPOI测试Demo"; //填加文件主题信息
            //    si.CreateDateTime = DateTime.Now;
            //    workbook.SummaryInformation = si;
            //}

            #endregion

            HSSFCellStyle dateStyle = workbook.CreateCellStyle() as HSSFCellStyle;
            HSSFDataFormat format = workbook.CreateDataFormat() as HSSFDataFormat;
            dateStyle.DataFormat = format.GetFormat("yyyy-mm-dd");

            //取得列宽
            int[] arrColWidth = new int[dtSource.Columns.Count];
            foreach (DataColumn item in dtSource.Columns)
            {
                arrColWidth[item.Ordinal] = Encoding.GetEncoding(936).GetBytes(item.ColumnName.ToString()).Length;
            }
            for (int i = 0; i < dtSource.Rows.Count; i++)
            {
                for (int j = 0; j < dtSource.Columns.Count; j++)
                {
                    int intTemp = Encoding.GetEncoding(936).GetBytes(dtSource.Rows[i][j].ToString()).Length;
                    if (intTemp > arrColWidth[j])
                    {
                        arrColWidth[j] = intTemp;
                    }
                }
            }
            int rowIndex = 0;

            foreach (DataRow row in dtSource.Rows)
            {
                #region 新建表，填充表头，填充列头，样式

                if (rowIndex == 65535 || rowIndex == 0)
                {
                    if (rowIndex != 0)
                    {
                        sheet = workbook.CreateSheet() as HSSFSheet;
                    }

                    #region 表头及样式

                    {
                        HSSFRow headerRow = sheet.CreateRow(0) as HSSFRow;
                        headerRow.HeightInPoints = 25;
                        headerRow.CreateCell(0).SetCellValue(strHeaderText);

                        HSSFCellStyle headStyle = workbook.CreateCellStyle() as HSSFCellStyle;
                        headStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
                        HSSFFont font = workbook.CreateFont() as HSSFFont;
                        font.FontHeightInPoints = 20;
                        font.Boldweight = 700;
                        headStyle.SetFont(font);

                        headerRow.GetCell(0).CellStyle = headStyle;
                        sheet.AddMergedRegion(new CellRangeAddress(0, 0, 0, dtSource.Columns.Count - 1));
                        //sheet.AddMergedRegion(new Region(0, 0, 0, dtSource.Columns.Count - 1));
                        //headerRow.Dispose();
                    }

                    #endregion


                    #region 列头及样式

                    {
                        HSSFRow headerRow = sheet.CreateRow(1) as HSSFRow;


                        HSSFCellStyle headStyle = workbook.CreateCellStyle() as HSSFCellStyle;
                        headStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
                        HSSFFont font = workbook.CreateFont() as HSSFFont;
                        font.FontHeightInPoints = 10;
                        font.Boldweight = 700;
                        headStyle.SetFont(font);


                        foreach (DataColumn column in dtSource.Columns)
                        {
                            headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);
                            headerRow.GetCell(column.Ordinal).CellStyle = headStyle;

                            //设置列宽
                            sheet.SetColumnWidth(column.Ordinal, (arrColWidth[column.Ordinal] + 1) * 256);

                        }
                        //headerRow.Dispose();
                    }

                    #endregion

                    rowIndex = 2;
                }

                #endregion

                #region 填充内容

                HSSFRow dataRow = sheet.CreateRow(rowIndex) as HSSFRow;
                foreach (DataColumn column in dtSource.Columns)
                {
                    HSSFCell newCell = dataRow.CreateCell(column.Ordinal) as HSSFCell;

                    string drValue = row[column].ToString();

                    switch (column.DataType.ToString())
                    {
                        case "System.String": //字符串类型
                            double result;
                            if (isNumeric(drValue, out result))
                            {

                                double.TryParse(drValue, out result);
                                newCell.SetCellValue(result);
                                break;
                            }
                            else
                            {
                                newCell.SetCellValue(drValue);
                                break;
                            }

                        case "System.DateTime": //日期类型
                            DateTime dateV;
                            DateTime.TryParse(drValue, out dateV);
                            newCell.SetCellValue(dateV);

                            newCell.CellStyle = dateStyle; //格式化显示
                            break;
                        case "System.Boolean": //布尔型
                            bool boolV = false;
                            bool.TryParse(drValue, out boolV);
                            newCell.SetCellValue(boolV);
                            break;
                        case "System.Int16": //整型
                        case "System.Int32":
                        case "System.Int64":
                        case "System.Byte":
                            int intV = 0;
                            int.TryParse(drValue, out intV);
                            newCell.SetCellValue(intV);
                            break;
                        case "System.Decimal": //浮点型
                        case "System.Double":
                            double doubV = 0;
                            double.TryParse(drValue, out doubV);
                            newCell.SetCellValue(doubV);
                            break;
                        case "System.DBNull": //空值处理
                            newCell.SetCellValue("");
                            break;
                        default:
                            newCell.SetCellValue("");
                            break;
                    }

                }

                #endregion

                rowIndex++;
            }
            using (MemoryStream ms = new MemoryStream())
            {
                workbook.Write(ms);
                ms.Flush();
                ms.Position = 0;

                //sheet.Dispose();
                //workbook.Dispose();

                return ms;
            }
        }

        /// <summary>
        /// DataTable导出到Excel的MemoryStream
        /// </summary>
        /// <param name="dtSource">源DataTable</param>
        /// <param name="strHeaderText">表头文本</param>
        static void ExportDTI(DataTable dtSource, string strHeaderText, FileStream fs)
        {
            XSSFWorkbook workbook = new XSSFWorkbook();
            XSSFSheet sheet = workbook.CreateSheet() as XSSFSheet;

            #region 右击文件 属性信息

            //{
            //    DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
            //    dsi.Company = "http://www.yongfa365.com/";
            //    workbook.DocumentSummaryInformation = dsi;

            //    SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
            //    si.Author = "柳永法"; //填加xls文件作者信息
            //    si.ApplicationName = "NPOI测试程序"; //填加xls文件创建程序信息
            //    si.LastAuthor = "柳永法2"; //填加xls文件最后保存者信息
            //    si.Comments = "说明信息"; //填加xls文件作者信息
            //    si.Title = "NPOI测试"; //填加xls文件标题信息
            //    si.Subject = "NPOI测试Demo"; //填加文件主题信息
            //    si.CreateDateTime = DateTime.Now;
            //    workbook.SummaryInformation = si;
            //}

            #endregion

            XSSFCellStyle dateStyle = workbook.CreateCellStyle() as XSSFCellStyle;
            XSSFDataFormat format = workbook.CreateDataFormat() as XSSFDataFormat;
            dateStyle.DataFormat = format.GetFormat("yyyy-mm-dd");

            //取得列宽
            int[] arrColWidth = new int[dtSource.Columns.Count];
            foreach (DataColumn item in dtSource.Columns)
            {
                arrColWidth[item.Ordinal] = Encoding.GetEncoding(936).GetBytes(item.ColumnName.ToString()).Length;
            }
            for (int i = 0; i < dtSource.Rows.Count; i++)
            {
                for (int j = 0; j < dtSource.Columns.Count; j++)
                {
                    int intTemp = Encoding.GetEncoding(936).GetBytes(dtSource.Rows[i][j].ToString()).Length;
                    if (intTemp > arrColWidth[j])
                    {
                        arrColWidth[j] = intTemp;
                    }
                }
            }
            int rowIndex = 0;

            foreach (DataRow row in dtSource.Rows)
            {
                #region 新建表，填充表头，填充列头，样式

                if (rowIndex == 0)
                {
                    #region 表头及样式
                    //{
                    //    XSSFRow headerRow = sheet.CreateRow(0) as XSSFRow;
                    //    headerRow.HeightInPoints = 25;
                    //    headerRow.CreateCell(0).SetCellValue(strHeaderText);

                    //    XSSFCellStyle headStyle = workbook.CreateCellStyle() as XSSFCellStyle;
                    //    headStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.CENTER;
                    //    XSSFFont font = workbook.CreateFont() as XSSFFont;
                    //    font.FontHeightInPoints = 20;
                    //    font.Boldweight = 700;
                    //    headStyle.SetFont(font);

                    //    headerRow.GetCell(0).CellStyle = headStyle;

                    //    //sheet.AddMergedRegion(new Region(0, 0, 0, dtSource.Columns.Count - 1));
                    //    //headerRow.Dispose();
                    //}

                    #endregion


                    #region 列头及样式

                    {
                        XSSFRow headerRow = sheet.CreateRow(0) as XSSFRow;
                        XSSFCellStyle headStyle = workbook.CreateCellStyle() as XSSFCellStyle;
                        headStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
                        XSSFFont font = workbook.CreateFont() as XSSFFont;
                        font.FontHeightInPoints = 10;
                        font.Boldweight = 700;
                        headStyle.SetFont(font);


                        foreach (DataColumn column in dtSource.Columns)
                        {
                            headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);
                            headerRow.GetCell(column.Ordinal).CellStyle = headStyle;

                            //设置列宽
                            sheet.SetColumnWidth(column.Ordinal, (arrColWidth[column.Ordinal] + 1) * 256);

                        }
                        //headerRow.Dispose();
                    }

                    #endregion

                    rowIndex = 1;
                }

                #endregion

                #region 填充内容

                XSSFRow dataRow = sheet.CreateRow(rowIndex) as XSSFRow;
                foreach (DataColumn column in dtSource.Columns)
                {
                    XSSFCell newCell = dataRow.CreateCell(column.Ordinal) as XSSFCell;

                    string drValue = row[column].ToString();

                    switch (column.DataType.ToString())
                    {
                        case "System.String": //字符串类型
                            double result;
                            if (isNumeric(drValue, out result))
                            {

                                double.TryParse(drValue, out result);
                                newCell.SetCellValue(result);
                                break;
                            }
                            else
                            {
                                newCell.SetCellValue(drValue);
                                break;
                            }

                        case "System.DateTime": //日期类型
                            DateTime dateV;
                            DateTime.TryParse(drValue, out dateV);
                            newCell.SetCellValue(dateV);

                            newCell.CellStyle = dateStyle; //格式化显示
                            break;
                        case "System.Boolean": //布尔型
                            bool boolV = false;
                            bool.TryParse(drValue, out boolV);
                            newCell.SetCellValue(boolV);
                            break;
                        case "System.Int16": //整型
                        case "System.Int32":
                        case "System.Int64":
                        case "System.Byte":
                            int intV = 0;
                            int.TryParse(drValue, out intV);
                            newCell.SetCellValue(intV);
                            break;
                        case "System.Decimal": //浮点型
                        case "System.Double":
                            double doubV = 0;
                            double.TryParse(drValue, out doubV);
                            newCell.SetCellValue(doubV);
                            break;
                        case "System.DBNull": //空值处理
                            newCell.SetCellValue("");
                            break;
                        default:
                            newCell.SetCellValue("");
                            break;
                    }

                }

                #endregion

                rowIndex++;
            }
            workbook.Write(fs);
            fs.Close();
        }

        /// <summary>
        /// DataTable导出到Excel文件
        /// </summary>
        /// <param name="dtSource">源DataTable</param>
        /// <param name="strHeaderText">表头文本</param>
        /// <param name="strFileName">保存位置</param>
        public static void ExportDTtoExcel(DataTable dtSource, string strHeaderText, string strFileName)
        {
            string[] temp = strFileName.Split('.');

            if (temp[temp.Length - 1] == "xls" && dtSource.Columns.Count < 256 && dtSource.Rows.Count < 65536)
            {
                using (MemoryStream ms = ExportDT(dtSource, strHeaderText))
                {
                    using (FileStream fs = new FileStream(strFileName, FileMode.Create, FileAccess.Write))
                    {
                        byte[] data = ms.ToArray();
                        fs.Write(data, 0, data.Length);
                        fs.Flush();
                    }
                }
            }
            else
            {
                if (temp[temp.Length - 1] == "xls")
                    strFileName = strFileName + "x";

                using (FileStream fs = new FileStream(strFileName, FileMode.Create, FileAccess.Write))
                {
                    ExportDTI(dtSource, strHeaderText, fs);
                }
            }
        }
        #endregion

        #region 从excel中将数据导出到datatable


        /// <summary>
        /// 读取Excel流到DataSet
        /// </summary>
        /// <param name="stream">Excel流</param>
        /// <returns>Excel中的数据</returns>
        public static DataSet ImportExceltoDs(Stream stream)
        {
            try
            {
                DataSet ds = new DataSet();
                IWorkbook wb;
                using (stream)
                {
                    wb = WorkbookFactory.Create(stream);
                }
                for (int i = 0; i < wb.NumberOfSheets; i++)
                {
                    DataTable dt = new DataTable();
                    ISheet sheet = wb.GetSheetAt(i);
                    dt = ImportDt(sheet, 0, true);
                    ds.Tables.Add(dt);
                }
                return ds;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// 读取Excel流到DataSet
        /// </summary>
        /// <param name="stream">Excel流</param>
        /// <param name="dict">字典参数，key：sheet名，value：列头所在行号，-1表示没有列头</param>
        /// <returns>Excel中的数据</returns>
        public static DataSet ImportExceltoDs(Stream stream, Dictionary<string, int> dict)
        {
            try
            {
                DataSet ds = new DataSet();
                IWorkbook wb;
                using (stream)
                {
                    wb = WorkbookFactory.Create(stream);
                }
                foreach (string key in dict.Keys)
                {
                    DataTable dt = new DataTable();
                    ISheet sheet = wb.GetSheet(key);
                    dt = ImportDt(sheet, dict[key], true);
                    ds.Tables.Add(dt);
                }
                return ds;
            }
            catch (Exception)
            {

                throw;
            }
        }



        /// <summary>
        /// 将制定sheet中的数据导出到datatable中
        /// </summary>
        /// <param name="sheet">需要导出的sheet</param>
        /// <param name="HeaderRowIndex">列头所在行号，-1表示没有列头</param>
        /// <returns></returns>
        static DataTable ImportDt(ISheet sheet, int HeaderRowIndex, bool needHeader)
        {
            DataTable table = new DataTable();
            IRow headerRow;
            int cellCount;
            try
            {
                if (HeaderRowIndex < 0 || !needHeader)
                {
                    headerRow = sheet.GetRow(0);
                    cellCount = headerRow.LastCellNum;

                    for (int i = headerRow.FirstCellNum; i <= cellCount; i++)
                    {
                        DataColumn column = new DataColumn(Convert.ToString(i));
                        table.Columns.Add(column);
                    }
                }
                else
                {
                    headerRow = sheet.GetRow(HeaderRowIndex);
                    cellCount = headerRow.LastCellNum;

                    for (int i = headerRow.FirstCellNum; i <= cellCount; i++)
                    {
                        if (headerRow.GetCell(i) == null)
                        {
                            if (table.Columns.IndexOf(Convert.ToString(i)) > 0)
                            {
                                DataColumn column = new DataColumn(Convert.ToString("重复列名" + i));
                                table.Columns.Add(column);
                            }
                            else
                            {
                                DataColumn column = new DataColumn(Convert.ToString(i));
                                table.Columns.Add(column);
                            }

                        }
                        else if (table.Columns.IndexOf(headerRow.GetCell(i).ToString()) > 0)
                        {
                            DataColumn column = new DataColumn(Convert.ToString("重复列名" + i));
                            table.Columns.Add(column);
                        }
                        else
                        {
                            DataColumn column = new DataColumn(headerRow.GetCell(i).ToString());
                            table.Columns.Add(column);
                        }
                    }
                }
                int rowCount = sheet.LastRowNum;
                for (int i = (HeaderRowIndex + 1); i <= sheet.LastRowNum; i++)
                {
                    try
                    {
                        IRow row;
                        if (sheet.GetRow(i) == null)
                        {
                            row = sheet.CreateRow(i);
                        }
                        else
                        {
                            row = sheet.GetRow(i);
                        }

                        DataRow dataRow = table.NewRow();

                        for (int j = row.FirstCellNum; j <= cellCount; j++)
                        {
                            try
                            {
                                if (row.GetCell(j) != null)
                                {
                                    switch (row.GetCell(j).CellType)
                                    {
                                        case CellType.String:
                                            string str = row.GetCell(j).StringCellValue;
                                            if (str != null && str.Length > 0)
                                            {
                                                dataRow[j] = str.ToString();
                                            }
                                            else
                                            {
                                                dataRow[j] = null;
                                            }
                                            break;
                                        case CellType.Numeric:
                                            if (DateUtil.IsCellDateFormatted(row.GetCell(j)))
                                            {
                                                dataRow[j] = DateTime.FromOADate(row.GetCell(j).NumericCellValue);
                                            }
                                            else
                                            {
                                                dataRow[j] = Convert.ToDouble(row.GetCell(j).NumericCellValue);
                                            }
                                            break;
                                        case CellType.Boolean:
                                            dataRow[j] = Convert.ToString(row.GetCell(j).BooleanCellValue);
                                            break;
                                        case CellType.Error:
                                            dataRow[j] = ErrorEval.GetText(row.GetCell(j).ErrorCellValue);
                                            break;
                                        case CellType.Formula:
                                            switch (row.GetCell(j).CachedFormulaResultType)
                                            {
                                                case CellType.String:
                                                    string strFORMULA = row.GetCell(j).StringCellValue;
                                                    if (strFORMULA != null && strFORMULA.Length > 0)
                                                    {
                                                        dataRow[j] = strFORMULA.ToString();
                                                    }
                                                    else
                                                    {
                                                        dataRow[j] = null;
                                                    }
                                                    break;
                                                case CellType.Numeric:
                                                    dataRow[j] = Convert.ToString(row.GetCell(j).NumericCellValue);
                                                    break;
                                                case CellType.Boolean:
                                                    dataRow[j] = Convert.ToString(row.GetCell(j).BooleanCellValue);
                                                    break;
                                                case CellType.Error:
                                                    dataRow[j] = ErrorEval.GetText(row.GetCell(j).ErrorCellValue);
                                                    break;
                                                default:
                                                    dataRow[j] = "";
                                                    break;
                                            }
                                            break;
                                        default:
                                            dataRow[j] = "";
                                            break;
                                    }
                                }
                            }
                            catch (Exception exception)
                            {
                                throw new Exception(exception.ToString());
                            }
                        }
                        table.Rows.Add(dataRow);
                    }
                    catch (Exception exception)
                    {
                        throw new Exception(exception.ToString());
                    }
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.ToString());
            }
            return table;
        }

        #endregion

        public static void InsertSheet(string outputFile, string sheetname, DataTable dt)
        {
            FileStream readfile = new FileStream(outputFile, FileMode.Open, FileAccess.Read);
            IWorkbook hssfworkbook = WorkbookFactory.Create(readfile);
            //HSSFWorkbook hssfworkbook = new HSSFWorkbook(readfile);
            int num = hssfworkbook.GetSheetIndex(sheetname);
            ISheet sheet1;
            if (num >= 0)
                sheet1 = hssfworkbook.GetSheet(sheetname);
            else
            {
                sheet1 = hssfworkbook.CreateSheet(sheetname);
            }


            try
            {
                if (sheet1.GetRow(0) == null)
                {
                    sheet1.CreateRow(0);
                }
                for (int coluid = 0; coluid < dt.Columns.Count; coluid++)
                {
                    if (sheet1.GetRow(0).GetCell(coluid) == null)
                    {
                        sheet1.GetRow(0).CreateCell(coluid);
                    }

                    sheet1.GetRow(0).GetCell(coluid).SetCellValue(dt.Columns[coluid].ColumnName);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
                throw;
            }


            for (int i = 1; i <= dt.Rows.Count; i++)
            {
                try
                {
                    if (sheet1.GetRow(i) == null)
                    {
                        sheet1.CreateRow(i);
                    }
                    for (int coluid = 0; coluid < dt.Columns.Count; coluid++)
                    {
                        if (sheet1.GetRow(i).GetCell(coluid) == null)
                        {
                            sheet1.GetRow(i).CreateCell(coluid);
                        }

                        sheet1.GetRow(i).GetCell(coluid).SetCellValue(dt.Rows[i - 1][coluid].ToString());
                    }
                }
                catch (Exception exception)
                {
                    throw new Exception(exception.ToString());
                    //throw;
                }
            }
            try
            {
                readfile.Close();

                FileStream writefile = new FileStream(outputFile, FileMode.OpenOrCreate, FileAccess.Write);
                hssfworkbook.Write(writefile);
                writefile.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        #region 更新excel中的数据
        /// <summary>
        /// 更新Excel表格
        /// </summary>
        /// <param name="outputFile">需更新的excel表格路径</param>
        /// <param name="sheetname">sheet名</param>
        /// <param name="updateData">需更新的数据</param>
        /// <param name="coluid">需更新的列号</param>
        /// <param name="rowid">需更新的开始行号</param>
        public static void UpdateExcel(string outputFile, string sheetname, string[] updateData, int coluid, int rowid)
        {
            //FileStream readfile = new FileStream(outputFile, FileMode.Open, FileAccess.Read);
            IWorkbook hssfworkbook = null;// WorkbookFactory.Create(outputFile);
                                          //HSSFWorkbook hssfworkbook = new HSSFWorkbook(readfile);
            ISheet sheet1 = hssfworkbook.GetSheet(sheetname);
            for (int i = 0; i < updateData.Length; i++)
            {
                try
                {
                    if (sheet1.GetRow(i + rowid) == null)
                    {
                        sheet1.CreateRow(i + rowid);
                    }
                    if (sheet1.GetRow(i + rowid).GetCell(coluid) == null)
                    {
                        sheet1.GetRow(i + rowid).CreateCell(coluid);
                    }

                    sheet1.GetRow(i + rowid).GetCell(coluid).SetCellValue(updateData[i]);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
            }
            try
            {
                //readfile.Close();
                FileStream writefile = new FileStream(outputFile, FileMode.OpenOrCreate, FileAccess.Write);
                hssfworkbook.Write(writefile);
                writefile.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

        }

        /// <summary>
        /// 更新Excel表格
        /// </summary>
        /// <param name="outputFile">需更新的excel表格路径</param>
        /// <param name="sheetname">sheet名</param>
        /// <param name="updateData">需更新的数据</param>
        /// <param name="coluids">需更新的列号</param>
        /// <param name="rowid">需更新的开始行号</param>
        public static void UpdateExcel(string outputFile, string sheetname, string[][] updateData, int[] coluids, int rowid)
        {
            FileStream readfile = new FileStream(outputFile, FileMode.Open, FileAccess.Read);

            HSSFWorkbook hssfworkbook = new HSSFWorkbook(readfile);
            readfile.Close();
            ISheet sheet1 = hssfworkbook.GetSheet(sheetname);
            for (int j = 0; j < coluids.Length; j++)
            {
                for (int i = 0; i < updateData[j].Length; i++)
                {
                    try
                    {
                        if (sheet1.GetRow(i + rowid) == null)
                        {
                            sheet1.CreateRow(i + rowid);
                        }
                        if (sheet1.GetRow(i + rowid).GetCell(coluids[j]) == null)
                        {
                            sheet1.GetRow(i + rowid).CreateCell(coluids[j]);
                        }
                        sheet1.GetRow(i + rowid).GetCell(coluids[j]).SetCellValue(updateData[j][i]);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.ToString());
                    }
                }
            }
            try
            {
                FileStream writefile = new FileStream(outputFile, FileMode.Create);
                hssfworkbook.Write(writefile);
                writefile.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        /// <summary>
        /// 更新Excel表格
        /// </summary>
        /// <param name="outputFile">需更新的excel表格路径</param>
        /// <param name="sheetname">sheet名</param>
        /// <param name="updateData">需更新的数据</param>
        /// <param name="coluid">需更新的列号</param>
        /// <param name="rowid">需更新的开始行号</param>
        public static void UpdateExcel(string outputFile, string sheetname, double[] updateData, int coluid, int rowid)
        {
            FileStream readfile = new FileStream(outputFile, FileMode.Open, FileAccess.Read);

            HSSFWorkbook hssfworkbook = new HSSFWorkbook(readfile);
            ISheet sheet1 = hssfworkbook.GetSheet(sheetname);
            for (int i = 0; i < updateData.Length; i++)
            {
                try
                {
                    if (sheet1.GetRow(i + rowid) == null)
                    {
                        sheet1.CreateRow(i + rowid);
                    }
                    if (sheet1.GetRow(i + rowid).GetCell(coluid) == null)
                    {
                        sheet1.GetRow(i + rowid).CreateCell(coluid);
                    }

                    sheet1.GetRow(i + rowid).GetCell(coluid).SetCellValue(updateData[i]);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
            }
            try
            {
                readfile.Close();
                FileStream writefile = new FileStream(outputFile, FileMode.Create, FileAccess.Write);
                hssfworkbook.Write(writefile);
                writefile.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        /// <summary>
        /// 读取模板更新数据，保存文件到新的路径
        /// </summary>
        /// <param name="outputFile">模板数据源</param>
        /// <param name="outputFile">导出excel保存的位置</param>
        /// <param name="dt">数据源</param>
        /// <param name="startColIndex">开始列索引位置</param>
        /// <param name="startRowIndex">开始的行索引位置</param>
        public static void ExportToExcel(string fileSources, string outputFile, DataTable dt, int startColIndex, int startRowIndex)
        {
            FileStream readfile = new FileStream(fileSources, FileMode.Open, FileAccess.Read);
            HSSFWorkbook hssfworkbook = new HSSFWorkbook(readfile);
            ISheet sheet = hssfworkbook.GetSheetAt(0);
            //将datatable数据填充到excel中
            for (var i = 0; i < dt.Rows.Count; i++)
            {
                IRow row = sheet.GetRow(i + startRowIndex) ?? sheet.CreateRow(i + startRowIndex);
                for (var j = 0; j < dt.Columns.Count; j++)
                {
                    ICell cell = row.GetCell(i + startColIndex) ?? row.CreateCell(i + startColIndex);
                    cell.SetCellValue(dt.Rows[i][j].ToString());
                }
            }

            try
            {
                readfile.Close();
                FileStream writefile = new FileStream(outputFile, FileMode.Create, FileAccess.Write);
                hssfworkbook.Write(writefile);
                writefile.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }


        /// <summary>
        /// 读取模板更新数据，保存文件到新的路径
        /// </summary>
        /// <param name="outputFile">模板数据源</param>
        /// <param name="outputFile">导出excel保存的位置</param>
        /// <param name="dt">数据源</param>
        /// <param name="position">位置 如 A1</param>
        public static void ExportToExcel(string fileSources, string outputFile, DataTable dt, string startposition)
        {
            FileStream readfile = new FileStream(fileSources, FileMode.Open, FileAccess.Read);
            HSSFWorkbook hssfworkbook = new HSSFWorkbook(readfile);
            ExportToExcel(hssfworkbook, outputFile, dt, startposition);
            try
            {
                FileStream writefile = new FileStream(outputFile, FileMode.Create, FileAccess.Write);
                hssfworkbook.Write(writefile);
                writefile.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        /// <summary>
        /// 将内存中的hssfworkbook，填充数据后，保存文件到新的路径
        /// </summary>
        /// <param name="hssfworkbook">将内存中的hssfworkbook</param>
        /// <param name="outputFile">导出excel保存的位置</param>
        /// <param name="dt">数据源</param>
        /// <param name="position">位置 如 A1</param>
        public static void ExportToExcel(IWorkbook hssfworkbook, string outputFile, DataTable dt, string startposition)
        {
            ISheet sheet = hssfworkbook.GetSheetAt(0);
            int[] startIndex = GetRowAndColIndex(startposition);
            //将datatable数据填充到excel中
            for (var i = 0; i < dt.Rows.Count; i++)
            {
                IRow row = sheet.GetRow(i + startIndex[1]) ?? sheet.CreateRow(i + startIndex[1]);
                for (var j = 0; j < dt.Columns.Count; j++)
                {
                    ICell cell = row.GetCell(j + startIndex[0]) ?? row.CreateCell(j + startIndex[0]);
                    //根据datatable数据的值类型判断数据的类型
                    if (DataHelper.TryToDateTime(dt.Rows[i][j]))
                    {
                        cell.SetCellValue(DataHelper.ToDateTime(dt.Rows[i][j]));
                    }
                    else if (DataHelper.TryToDouble(dt.Rows[i][j]))
                    {
                        cell.SetCellValue(DataHelper.ToDouble(dt.Rows[i][j]));
                    }
                    else if (DataHelper.TryToBoolean(dt.Rows[i][j]))
                    {
                        cell.SetCellValue(DataHelper.ToBoolean(dt.Rows[i][j]));
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(dt.Rows[i][j].ToString()))
                        {
                            cell.SetCellValue(dt.Rows[i][j].ToString());
                        }
                    }
                }
            }

            try
            {
                FileStream writefile = new FileStream(outputFile, FileMode.Create, FileAccess.Write);
                hssfworkbook.Write(writefile);
                writefile.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }


        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="hssfworkbook"></param>
        /// <param name="dt"></param>
        /// <param name="startposition"></param>
        public static void ExportToExcel(IWorkbook hssfworkbook, DataTable dt, string startposition)
        {
            ExportToExcel(hssfworkbook, 0, dt, startposition, false);
        }


        public static void ExportToExcel(IWorkbook hssfworkbook, int sheetindex, DataTable dt, string startposition, bool havehead)
        {
            UpdateExcel(hssfworkbook.GetSheetAt(sheetindex), dt, startposition, havehead);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="dt"></param>
        /// <param name="startposition"></param>
        /// <param name="head"></param>
        public static void UpdateExcel(ISheet sheet, DataTable dt, string startposition, bool head)
        {
            int[] startIndex = GetRowAndColIndex(startposition);
            int havehead = 0;
            if (head)
            {
                havehead = 1;
                IRow row = sheet.GetRow(startIndex[1]) ?? sheet.CreateRow(startIndex[1]);
                for (var i = 0; i < dt.Columns.Count; i++)
                {
                    ICell cell = row.GetCell(i + startIndex[0]) ?? row.CreateCell(i + startIndex[0]);
                    cell.SetCellValue(dt.Columns[i].ColumnName);
                }
            }
            //将datatable数据填充到excel中
            for (var i = 0; i < dt.Rows.Count; i++)
            {
                IRow row = sheet.GetRow(i + startIndex[1] + havehead) ?? sheet.CreateRow(i + startIndex[1] + havehead);
                for (var j = 0; j < dt.Columns.Count; j++)
                {
                    ICell cell = row.GetCell(j + startIndex[0]) ?? row.CreateCell(j + startIndex[0]);
                    //根据datatable数据的值类型判断数据的类型
                    if (DataHelper.TryToDouble(dt.Rows[i][j]))
                    {
                        cell.SetCellValue(DataHelper.ToDouble(dt.Rows[i][j]));
                    }
                    else if (DataHelper.TryToDateTime(dt.Rows[i][j]))
                    {
                        cell.SetCellValue(DataHelper.ToDateTime(dt.Rows[i][j]));
                    }
                    else if (DataHelper.TryToBoolean(dt.Rows[i][j]))
                    {
                        cell.SetCellValue(DataHelper.ToBoolean(dt.Rows[i][j]));
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(dt.Rows[i][j].ToString()))
                        {
                            cell.SetCellValue(dt.Rows[i][j].ToString());
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="dt"></param>
        /// <param name="startposition"></param>
        public static void UpdateExcel(ISheet sheet, DataTable dt, string startposition)
        {
            UpdateExcel(sheet, dt, startposition, false);
        }


        /// <summary>
        /// 更新Excel表格
        /// </summary>
        /// <param name="outputFile">需更新的excel表格路径</param>
        /// <param name="sheetname">sheet名</param>
        /// <param name="updateData">需更新的数据</param>
        /// <param name="coluids">需更新的列号</param>
        /// <param name="rowid">需更新的开始行号</param>
        public static void UpdateExcel(string outputFile, string sheetname, double[][] updateData, int[] coluids, int rowid)
        {
            FileStream readfile = new FileStream(outputFile, FileMode.Open, FileAccess.Read);

            HSSFWorkbook hssfworkbook = new HSSFWorkbook(readfile);
            readfile.Close();
            ISheet sheet1 = hssfworkbook.GetSheet(sheetname);
            for (int j = 0; j < coluids.Length; j++)
            {
                for (int i = 0; i < updateData[j].Length; i++)
                {
                    try
                    {
                        if (sheet1.GetRow(i + rowid) == null)
                        {
                            sheet1.CreateRow(i + rowid);
                        }
                        if (sheet1.GetRow(i + rowid).GetCell(coluids[j]) == null)
                        {
                            sheet1.GetRow(i + rowid).CreateCell(coluids[j]);
                        }
                        sheet1.GetRow(i + rowid).GetCell(coluids[j]).SetCellValue(updateData[j][i]);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.ToString());
                    }
                }
            }
            try
            {
                FileStream writefile = new FileStream(outputFile, FileMode.Create);
                hssfworkbook.Write(writefile);
                writefile.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        #endregion

        /// <summary>
        /// 获取sheet的个数
        /// </summary>
        /// <param name="outputFile"></param>
        /// <returns></returns>
        public static int GetSheetNumber(string outputFile)
        {
            int number = 0;
            try
            {
                FileStream readfile = new FileStream(outputFile, FileMode.Open, FileAccess.Read);

                HSSFWorkbook hssfworkbook = new HSSFWorkbook(readfile);
                number = hssfworkbook.NumberOfSheets;

            }
            catch (Exception exception)
            {
                throw new Exception(exception.ToString());
            }
            return number;
        }

        /// <summary>
        /// 获取sheet的name数组
        /// </summary>
        /// <param name="outputFile"></param>
        /// <returns></returns>
        public static ArrayList GetSheetName(string outputFile)
        {
            ArrayList arrayList = new ArrayList();
            try
            {
                FileStream readfile = new FileStream(outputFile, FileMode.Open, FileAccess.Read);

                HSSFWorkbook hssfworkbook = new HSSFWorkbook(readfile);
                for (int i = 0; i < hssfworkbook.NumberOfSheets; i++)
                {
                    arrayList.Add(hssfworkbook.GetSheetName(i));
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.ToString());
            }
            return arrayList;
        }

        public static bool isNumeric(String message, out double result)
        {
            Regex rex = new Regex(@"^[-]?\d+[.]?\d*$");
            result = -1;
            if (rex.IsMatch(message))
            {
                result = double.Parse(message);
                return true;
            }
            else
                return false;

        }

        #region  web导出

        /// <summary>
        /// 用于Web导出                                                                                             第一步
        /// </summary>
        /// <param name="dtSource">源DataTable</param>
        /// <param name="strHeaderText">表头文本</param>
        /// <param name="strFileName">文件名</param>
        public static void ExportByWeb(DataTable dtSource, string strHeaderText, string strFileName)
        {
            HttpContext curContext = HttpContext.Current;
            // 设置编码和附件格式
            curContext.Response.ContentType = "application/vnd.ms-excel";
            curContext.Response.ContentEncoding = Encoding.UTF8;
            curContext.Response.Charset = "";
            curContext.Response.AppendHeader("Content-Disposition",
            "attachment;filename=" + HttpUtility.UrlEncode(strFileName, Encoding.UTF8));

            curContext.Response.BinaryWrite(HWExport(dtSource, strHeaderText).GetBuffer());
            curContext.Response.End();
        }

        #endregion
        /// <summary>
        /// 导出到excel 改变列头
        /// </summary>
        /// <param name="dtSource"></param>
        /// <param name="strHeaderText"></param>
        /// <param name="strFileName"></param>
        /// <param name="strArr">列头数组</param>
        public static void HWExportByWeb(DataTable dtSource, string strHeaderText, string strFileName, string[] strArr)
        {
            HttpContext curContext = HttpContext.Current;
            // 设置编码和附件格式
            curContext.Response.ContentType = "application/vnd.ms-excel";
            curContext.Response.ContentEncoding = Encoding.UTF8;
            curContext.Response.Charset = "";
            curContext.Response.AppendHeader("Content-Disposition",
            "attachment;filename=" + HttpUtility.UrlEncode(strFileName, Encoding.UTF8));
            dtSource = ChangeDataTableColumnName(dtSource, strArr);
            curContext.Response.BinaryWrite(HWExport(dtSource, strHeaderText).GetBuffer());
            curContext.Response.End();
        }

        /// <summary>
        /// DataTable导出到Excel的MemoryStream                                                                      第二步
        /// </summary>
        /// <param name="dtSource">源DataTable</param>
        /// <param name="strHeaderText">表头文本</param>
        public static MemoryStream Export(DataTable dtSource, string strHeaderText)
        {
            HSSFWorkbook workbook = new HSSFWorkbook();
            HSSFSheet sheet = workbook.CreateSheet() as HSSFSheet;

            #region 右击文件 属性信息
            {
                DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
                dsi.Company = "NPOI";
                workbook.DocumentSummaryInformation = dsi;

                SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
                si.Author = "文件作者信息"; //填加xls文件作者信息
                si.ApplicationName = "创建程序信息"; //填加xls文件创建程序信息
                si.LastAuthor = "最后保存者信息"; //填加xls文件最后保存者信息
                si.Comments = "作者信息"; //填加xls文件作者信息
                si.Title = "标题信息"; //填加xls文件标题信息
                si.Subject = "主题信息";//填加文件主题信息

                si.CreateDateTime = DateTime.Now;
                workbook.SummaryInformation = si;
            }
            #endregion

            HSSFCellStyle dateStyle = workbook.CreateCellStyle() as HSSFCellStyle;
            HSSFDataFormat format = workbook.CreateDataFormat() as HSSFDataFormat;
            dateStyle.DataFormat = format.GetFormat("yyyy-mm-dd");

            //取得列宽
            int[] arrColWidth = new int[dtSource.Columns.Count];
            foreach (DataColumn item in dtSource.Columns)
            {
                arrColWidth[item.Ordinal] = Encoding.GetEncoding(936).GetBytes(item.ColumnName.ToString()).Length;
            }
            for (int i = 0; i < dtSource.Rows.Count; i++)
            {
                for (int j = 0; j < dtSource.Columns.Count; j++)
                {
                    int intTemp = Encoding.GetEncoding(936).GetBytes(dtSource.Rows[i][j].ToString()).Length;
                    if (intTemp > arrColWidth[j])
                    {
                        arrColWidth[j] = intTemp;
                    }
                }
            }
            int rowIndex = 0;
            foreach (DataRow row in dtSource.Rows)
            {
                #region 新建表，填充表头，填充列头，样式
                if (rowIndex == 65535 || rowIndex == 0)
                {
                    if (rowIndex != 0)
                    {
                        sheet = workbook.CreateSheet() as HSSFSheet;
                    }

                    #region 表头及样式
                    {
                        if (string.IsNullOrEmpty(strHeaderText))
                        {
                            HSSFRow headerRow = sheet.CreateRow(0) as HSSFRow;
                            headerRow.HeightInPoints = 25;
                            headerRow.CreateCell(0).SetCellValue(strHeaderText);
                            HSSFCellStyle headStyle = workbook.CreateCellStyle() as HSSFCellStyle;
                            //headStyle.Alignment = CellHorizontalAlignment.CENTER;
                            HSSFFont font = workbook.CreateFont() as HSSFFont;
                            font.FontHeightInPoints = 20;
                            font.Boldweight = 700;
                            headStyle.SetFont(font);
                            headerRow.GetCell(0).CellStyle = headStyle;
                            sheet.AddMergedRegion(new CellRangeAddress(0, 0, 0, dtSource.Columns.Count - 1));
                            //sheet.AddMergedRegion(new Region(0, 0, 0, dtSource.Columns.Count - 1));
                            //headerRow.Dispose();
                        }
                    }
                    #endregion

                    #region 列头及样式
                    {
                        HSSFRow headerRow = sheet.CreateRow(0) as HSSFRow;
                        HSSFCellStyle headStyle = workbook.CreateCellStyle() as HSSFCellStyle;
                        //headStyle.Alignment = CellHorizontalAlignment.CENTER;
                        HSSFFont font = workbook.CreateFont() as HSSFFont;
                        font.FontHeightInPoints = 10;
                        font.Boldweight = 700;
                        headStyle.SetFont(font);
                        foreach (DataColumn column in dtSource.Columns)
                        {
                            headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);
                            headerRow.GetCell(column.Ordinal).CellStyle = headStyle;

                            //设置列宽
                            sheet.SetColumnWidth(column.Ordinal, (arrColWidth[column.Ordinal] + 1) * 256);
                        }
                        //headerRow.Dispose();
                    }
                    #endregion

                    rowIndex = 1;
                }
                #endregion


                #region 填充内容
                HSSFRow dataRow = sheet.CreateRow(rowIndex) as HSSFRow;
                foreach (DataColumn column in dtSource.Columns)
                {
                    HSSFCell newCell = dataRow.CreateCell(column.Ordinal) as HSSFCell;

                    string drValue = row[column].ToString();

                    switch (column.DataType.ToString())
                    {
                        case "System.String"://字符串类型
                            newCell.SetCellValue(drValue);
                            break;
                        case "System.DateTime"://日期类型
                            DateTime dateV;
                            DateTime.TryParse(drValue, out dateV);
                            newCell.SetCellValue(dateV);

                            newCell.CellStyle = dateStyle;//格式化显示
                            break;
                        case "System.Boolean"://布尔型
                            bool boolV = false;
                            bool.TryParse(drValue, out boolV);
                            newCell.SetCellValue(boolV);
                            break;
                        case "System.Int16"://整型
                        case "System.Int32":
                        case "System.Int64":
                        case "System.Byte":
                            int intV = 0;
                            int.TryParse(drValue, out intV);
                            newCell.SetCellValue(intV);
                            break;
                        case "System.Decimal"://浮点型
                        case "System.Double":
                            double doubV = 0;
                            double.TryParse(drValue, out doubV);
                            newCell.SetCellValue(doubV);
                            break;
                        case "System.DBNull"://空值处理
                            newCell.SetCellValue("");
                            break;
                        default:
                            newCell.SetCellValue("");
                            break;
                    }
                }
                #endregion

                rowIndex++;
            }
            using (MemoryStream ms = new MemoryStream())
            {
                workbook.Write(ms);
                ms.Flush();
                ms.Position = 0;

                //sheet.Dispose();
                //workbook.Dispose();//一般只用写这一个就OK了，他会遍历并释放所有资源，但当前版本有问题所以只释放sheet
                return ms;
            }
        }




        /// <summary>
        /// 向workbook中写入数据 by 何伟
        /// </summary>
        /// <param name="workbook"></param>
        /// <param name="sheetName"></param>
        /// <param name="data"></param>
        /// <param name="opsition"></param>
        /// <returns></returns>
        public static HSSFWorkbook inportToWorkbook(HSSFWorkbook workbook, string sheetName, DataTable data, string opsition)
        {
            ISheet sheet = workbook.CreateSheet(sheetName);
            InportToSheet(sheet, data, opsition);
            return workbook;
        }

        /// <summary>
        /// 向workbook中写入数据 by 何伟
        /// </summary>
        /// <param name="workbook"></param>
        /// <param name="sheetName"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static HSSFWorkbook inportToWorkbook(HSSFWorkbook workbook, string sheetName, DataTable data)
        {
            ISheet sheet = workbook.CreateSheet(sheetName);
            InportToSheet(sheet, data);
            return workbook;
        }

        /// <summary>
        /// 向sheet中写入datatable数据 by 何伟
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ISheet InportToSheet(ISheet sheet, DataTable data)
        {
            //遍历
            for (var i = 0; i < data.Rows.Count; i++)
            {
                IRow row = sheet.CreateRow(i);
                for (var j = 0; j < data.Rows[i].ItemArray.Length; j++)
                {
                    ICell cell = row.CreateCell(j);
                    double result = 0;
                    if (double.TryParse(data.Rows[i][j].ToString(), out result))
                    {
                        cell.SetCellValue(result);
                    }
                    else
                    {
                        cell.SetCellValue(data.Rows[i][j].ToString());
                    }

                }
            }
            return sheet;
        }

        /// <summary>
        /// 向sheet 中写入数据
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="data"></param>
        /// <param name="opsition"></param>
        /// <returns></returns>
        public static ISheet InportToSheet(ISheet sheet, DataTable data, string opsition)
        {
            var opsitionIndex = GetRowAndColIndex(opsition);
            var startRowIndex = opsitionIndex[1];
            var startColIndex = opsitionIndex[0];
            //遍历
            for (var i = 0; i < data.Rows.Count; i++)
            {
                IRow row = sheet.CreateRow(i + startRowIndex);
                for (var j = 0; j < data.Rows[i].ItemArray.Length; j++)
                {
                    ICell cell = row.CreateCell(j + startColIndex);
                    cell.SetCellValue(data.Rows[i][j].ToString());
                }
            }
            return sheet;
        }

        /// <summary>
        /// DataTable导出到Excel的MemoryStream (by何伟)
        /// </summary>
        /// <param name="dtSource">DataTable</param>
        /// <param name="strHeaderText">表头名称</param>
        /// <returns></returns>
        public static MemoryStream HWExport(DataTable dtSource, string strHeaderText)
        {
            HSSFWorkbook workbook = new HSSFWorkbook();
            HSSFSheet sheet = workbook.CreateSheet() as HSSFSheet;

            #region 右击文件 属性信息
            {
                DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
                dsi.Company = "NPOI";
                workbook.DocumentSummaryInformation = dsi;

                SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
                si.Author = "文件作者信息"; //填加xls文件作者信息
                si.ApplicationName = "创建程序信息"; //填加xls文件创建程序信息
                si.LastAuthor = "最后保存者信息"; //填加xls文件最后保存者信息
                si.Comments = "作者信息"; //填加xls文件作者信息
                si.Title = "标题信息"; //填加xls文件标题信息
                si.Subject = "主题信息";//填加文件主题信息

                si.CreateDateTime = DateTime.Now;
                workbook.SummaryInformation = si;
            }
            #endregion

            HSSFCellStyle dateStyle = workbook.CreateCellStyle() as HSSFCellStyle;
            HSSFDataFormat format = workbook.CreateDataFormat() as HSSFDataFormat;
            dateStyle.DataFormat = format.GetFormat("yyyy-mm-dd");

            //取得列宽
            int[] arrColWidth = new int[dtSource.Columns.Count];
            foreach (DataColumn item in dtSource.Columns)
            {
                arrColWidth[item.Ordinal] = Encoding.GetEncoding(936).GetBytes(item.ColumnName.ToString()).Length;
            }
            for (int i = 0; i < dtSource.Rows.Count; i++)
            {
                for (int j = 0; j < dtSource.Columns.Count; j++)
                {
                    int intTemp = Encoding.GetEncoding(936).GetBytes(dtSource.Rows[i][j].ToString()).Length;
                    if (intTemp > arrColWidth[j])
                    {
                        arrColWidth[j] = intTemp;
                    }
                }
            }
            int rowIndex = 0;

            #region 新建表，填充表头，填充列头，样式
            #region 表头及样式
            {
                if (!string.IsNullOrEmpty(strHeaderText))
                {
                    HSSFRow headerRow = sheet.CreateRow(rowIndex++) as HSSFRow;
                    headerRow.HeightInPoints = 25;
                    headerRow.CreateCell(0).SetCellValue(strHeaderText);
                    HSSFCellStyle headStyle = workbook.CreateCellStyle() as HSSFCellStyle;
                    //headStyle.Alignment = CellHorizontalAlignment.CENTER;
                    HSSFFont font = workbook.CreateFont() as HSSFFont;
                    font.FontHeightInPoints = 20;
                    font.Boldweight = 700;
                    headStyle.SetFont(font);
                    headerRow.GetCell(0).CellStyle = headStyle;
                    sheet.AddMergedRegion(new CellRangeAddress(0, 0, 0, dtSource.Columns.Count - 1));
                    //sheet.AddMergedRegion(new Region(0, 0, 0, dtSource.Columns.Count - 1));
                    //headerRow.Dispose();
                }
            }
            #endregion

            #region 列头及样式
            {
                HSSFRow headerRow = sheet.CreateRow(rowIndex++) as HSSFRow;
                HSSFCellStyle headStyle = workbook.CreateCellStyle() as HSSFCellStyle;
                //headStyle.Alignment = CellHorizontalAlignment.CENTER;
                HSSFFont font = workbook.CreateFont() as HSSFFont;
                font.FontHeightInPoints = 10;
                font.Boldweight = 700;
                headStyle.SetFont(font);
                foreach (DataColumn column in dtSource.Columns)
                {
                    headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);
                    headerRow.GetCell(column.Ordinal).CellStyle = headStyle;
                    //设置列宽
                    sheet.SetColumnWidth(column.Ordinal, (arrColWidth[column.Ordinal] + 1) * 256);
                }
                //headerRow.Dispose();
            }
            #endregion

            //  rowIndex = 1;

            #endregion
            foreach (DataRow row in dtSource.Rows)
            {
                #region 填充内容
                HSSFRow dataRow = sheet.CreateRow(rowIndex) as HSSFRow;
                foreach (DataColumn column in dtSource.Columns)
                {
                    HSSFCell newCell = dataRow.CreateCell(column.Ordinal) as HSSFCell;

                    string drValue = row[column].ToString();

                    switch (column.DataType.ToString())
                    {
                        case "System.String"://字符串类型
                            newCell.SetCellValue(drValue);
                            break;
                        case "System.DateTime"://日期类型
                            DateTime dateV;
                            DateTime.TryParse(drValue, out dateV);
                            newCell.SetCellValue(dateV);

                            newCell.CellStyle = dateStyle;//格式化显示
                            break;
                        case "System.Boolean"://布尔型
                            bool boolV = false;
                            bool.TryParse(drValue, out boolV);
                            newCell.SetCellValue(boolV);
                            break;
                        case "System.Int16"://整型
                        case "System.Int32":
                        case "System.Int64":
                        case "System.Byte":
                            int intV = 0;
                            int.TryParse(drValue, out intV);
                            newCell.SetCellValue(intV);
                            break;
                        case "System.Decimal"://浮点型
                        case "System.Double":
                            double doubV = 0;
                            double.TryParse(drValue, out doubV);
                            newCell.SetCellValue(doubV);
                            break;
                        case "System.DBNull"://空值处理
                            newCell.SetCellValue("");
                            break;
                        default:
                            newCell.SetCellValue("");
                            break;
                    }
                }
                #endregion

                rowIndex++;
            }
            using (MemoryStream ms = new MemoryStream())
            {
                workbook.Write(ms);
                ms.Flush();
                ms.Position = 0;
                //sheet.Dispose();
                //workbook.Dispose();//一般只用写这一个就OK了，他会遍历并释放所有资源，但当前版本有问题所以只释放sheet
                return ms;
            }
        }

        /// <summary>
        /// /注：分浏览器进行编码（IE必须编码，FireFox不能编码，Chrome可编码也可不编码）
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="strHeaderText"></param>
        /// <param name="strFileName"></param>
        public static void ExportByWeb(DataSet ds, string strHeaderText, string strFileName)
        {
            HttpContext curContext = HttpContext.Current;
            curContext.Response.ContentType = "application/vnd.ms-excel";
            curContext.Response.Charset = "";
            if (curContext.Request.UserAgent.ToLower().IndexOf("firefox", System.StringComparison.Ordinal) > 0)
            {
                curContext.Response.AppendHeader("Content-Disposition", "attachment;filename=" + strFileName);
            }
            else
            {
                curContext.Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(strFileName, System.Text.Encoding.UTF8));
            }

            //  curContext.Response.AppendHeader("Content-Disposition", "attachment;filename=" +strFileName);
            curContext.Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
            curContext.Response.BinaryWrite(ExportDataSetToExcel(ds, strHeaderText).GetBuffer());
            curContext.Response.End();
        }

        /// <summary>
        /// 导出下载 by 何伟
        /// </summary>
        /// <param name="workbook"></param>
        /// <param name="filename"></param>
        public static void ExportByWeb(IWorkbook workbook, string filename)
        {
            HttpContext curContext = HttpContext.Current;
            curContext.Response.ContentType = "application/vnd.ms-excel";
            curContext.Response.Charset = "";
            if (curContext.Request.UserAgent.ToLower().IndexOf("firefox", System.StringComparison.Ordinal) > 0)
            {
                curContext.Response.AppendHeader("Content-Disposition", "attachment;filename=" + filename);
            }
            else
            {
                curContext.Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(filename, System.Text.Encoding.UTF8));
            }

            curContext.Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
            MemoryStream me = new MemoryStream();
            workbook.Write(me);
            curContext.Response.BinaryWrite(me.GetBuffer());
            curContext.Response.End();
        }

        public static void ExportByWeb(string filepath, string filename)
        {
            ExportByWeb(CreateNewWorkbook(filepath), filename);
        }

        /// <summary>
        /// 由DataSet导出Excel
        /// </summary>
        /// <param name="sourceTable">要导出数据的DataTable</param>
        /// <param name="sheetName">工作表名称</param>
        /// <returns>Excel工作表</returns>
        private static MemoryStream ExportDataSetToExcel(DataSet sourceDs, string sheetName)
        {
            HSSFWorkbook workbook = new HSSFWorkbook();
            MemoryStream ms = new MemoryStream();
            string[] sheetNames = sheetName.Split(',');
            for (int i = 0; i < sheetNames.Length; i++)
            {
                ISheet sheet = workbook.CreateSheet(sheetNames[i]);

                #region 列头
                IRow headerRow = sheet.CreateRow(0);
                HSSFCellStyle headStyle = workbook.CreateCellStyle() as HSSFCellStyle;
                HSSFFont font = workbook.CreateFont() as HSSFFont;
                font.FontHeightInPoints = 10;
                font.Boldweight = 700;
                headStyle.SetFont(font);

                //取得列宽
                int[] arrColWidth = new int[sourceDs.Tables[i].Columns.Count];
                foreach (DataColumn item in sourceDs.Tables[i].Columns)
                {
                    arrColWidth[item.Ordinal] = Encoding.GetEncoding(936).GetBytes(item.ColumnName.ToString()).Length;
                }

                // 处理列头
                foreach (DataColumn column in sourceDs.Tables[i].Columns)
                {
                    headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);
                    headerRow.GetCell(column.Ordinal).CellStyle = headStyle;
                    //设置列宽
                    sheet.SetColumnWidth(column.Ordinal, (arrColWidth[column.Ordinal] + 1) * 256);

                }
                #endregion

                #region 填充值
                int rowIndex = 1;
                foreach (DataRow row in sourceDs.Tables[i].Rows)
                {
                    IRow dataRow = sheet.CreateRow(rowIndex);
                    foreach (DataColumn column in sourceDs.Tables[i].Columns)
                    {
                        dataRow.CreateCell(column.Ordinal).SetCellValue(row[column].ToString());
                    }
                    rowIndex++;
                }
                #endregion
            }
            workbook.Write(ms);
            ms.Flush();
            ms.Position = 0;
            workbook = null;
            return ms;
        }


        /// <summary>
        /// 验证导入的Excel是否有数据
        /// </summary>
        /// <param name="excelFileStream"></param>
        /// <returns></returns>
        public static bool HasData(Stream excelFileStream)
        {
            using (excelFileStream)
            {
                IWorkbook workBook = new HSSFWorkbook(excelFileStream);
                if (workBook.NumberOfSheets > 0)
                {
                    ISheet sheet = workBook.GetSheetAt(0);
                    return sheet.PhysicalNumberOfRows > 0;
                }
            }
            return false;
        }

        #region 模板加载的方法（待完善） by何伟

        /// <summary>
        /// 根据excel模板填充数据 返回流 模板中一般参数 占位符 ${参数} (参数需与datatable中columnName一致)
        /// list参数 占位符 $List{参数} (参数需与datatable中columnName一致)
        /// </summary>
        /// <param name="filePath">模板文件路径</param>
        /// <param name="dtTeader">头信息，只会读取第一行</param>
        /// <param name="dtBody">列表信息</param>
        /// <returns></returns>
        public static MemoryStream loadExcelTemplet(Stream sreStream, DataTable dtHeader, DataTable dtBody)
        {
            //FileStream fs = new FileStream(filePath, FileMode.Open);
            HSSFWorkbook wk = new HSSFWorkbook(sreStream);
            //遍历sheet
            for (int sheetIndex = 0; sheetIndex < wk.NumberOfSheets; sheetIndex++)
            {
                ISheet sheet = wk.GetSheetAt(sheetIndex);
                var xxx = sheet.LastRowNum;
                //遍历row
                for (var rowIndex = sheet.FirstRowNum; rowIndex <= sheet.LastRowNum; rowIndex++)
                {
                    IRow row = sheet.GetRow(rowIndex);
                    if (row != null)
                    {
                        //遍历row 下的 cell
                        bool isDown = false;
                        for (var cellIndex = row.FirstCellNum; cellIndex <= row.LastCellNum; cellIndex++)
                        {
                            ICell cell = row.GetCell(cellIndex);
                            if (cell != null)
                            {
                                ///得到单元格的值
                                string cellValue = cell.StringCellValue;
                                //判断单元格的值 是否为不为空且是占位符
                                Regex regexH = new Regex(@"\${\w*}");

                                if (!String.IsNullOrEmpty(cellValue) && regexH.IsMatch(cellValue.Trim()))
                                {
                                    Match match = regexH.Match(cellValue);
                                    if (match.Success)
                                    {
                                        string newValue = dtHeader.Rows[0][match.ToString().Substring(2, match.ToString().Length - 3)] == null ? "" : dtHeader.Rows[0][match.ToString().Substring(2, match.ToString().Length - 3)].ToString();
                                        cell.SetCellValue(regexH.Replace(cell.StringCellValue, newValue));
                                    }
                                }
                                //如果是list
                                Regex regexB = new Regex(@"\$List{\w*}");

                                if (!String.IsNullOrEmpty(cellValue) && regexB.IsMatch(cellValue.Trim()))
                                {
                                    //如果是list表，将以后的行下移count
                                    if (!isDown)
                                    {
                                        //向下移动
                                        if (rowIndex + 1 <= sheet.LastRowNum)
                                        {
                                            sheet.ShiftRows(rowIndex + 1, sheet.LastRowNum, dtBody.Rows.Count - 1);
                                        }
                                        isDown = true;

                                    }
                                    //新建变量存储原来的单元格的值
                                    string OldcellValue = cellValue;
                                    //下移后给赋值
                                    for (var dtRowIndex = 0; dtRowIndex < dtBody.Rows.Count; dtRowIndex++)
                                    {
                                        //匹配 $List{XXX}
                                        Match match = regexB.Match(OldcellValue);
                                        if (match.Success)
                                        {
                                            //得到DataTable的值
                                            string newValue = dtBody.Rows[dtRowIndex][match.ToString().Substring(6, match.ToString().Length - 7)] == null ? "" : dtBody.Rows[dtRowIndex][match.ToString().Substring(6, match.ToString().Length - 7)].ToString();
                                            //如果行已存在则get 否则create
                                            if (sheet.GetRow(dtRowIndex + rowIndex) != null)
                                            {
                                                sheet.GetRow(dtRowIndex + rowIndex).CreateCell(cellIndex).SetCellValue(regexB.Replace(OldcellValue, newValue));
                                            }
                                            else
                                            {
                                                sheet.CreateRow(dtRowIndex + rowIndex).CreateCell(cellIndex).SetCellValue(regexB.Replace(OldcellValue, newValue));
                                            }
                                            /*
                                            //string newValue = dtBody.Rows[dtRowIndex][cellValue.Substring(6, cellValue.Length - 7)] == null ? "" : dtBody.Rows[dtRowIndex][cellValue.Substring(6, cellValue.Length - 7)].ToString();
                                            //
                                            //if (sheet.GetRow(dtRowIndex + rowIndex) != null)
                                            //{
                                            //    sheet.GetRow(dtRowIndex + rowIndex).CreateCell(cellIndex).SetCellValue(newValue);
                                            //}
                                            //else
                                            //{
                                            //    sheet.CreateRow(dtRowIndex + rowIndex).CreateCell(cellIndex).SetCellValue(newValue);
                                            //}
                                            */
                                            ///设置样式，与上一行样式相同
                                            if (dtRowIndex > 0)
                                            {
                                                //sheet.GetRow(dtRowIndex + rowIndex).RowStyle = sheet.GetRow(rowIndex).RowStyle;
                                                //样式相同
                                                sheet.GetRow(dtRowIndex + rowIndex).GetCell(cellIndex).CellStyle = sheet.GetRow(rowIndex).GetCell(cellIndex).CellStyle;
                                                //cell.SetCellValue(newValue);
                                                //sheet.GetRow(dtRowIndex + rowIndex).GetCell(cellIndex).ArrayFormulaRange
                                                ///单元格所占列 行相同
                                                int rowSpan = 0;
                                                int cellspan = 0;
                                                bool result = isMergeCell(sheet, sheet.GetRow(rowIndex).GetCell(cellIndex).RowIndex, sheet.GetRow(rowIndex).GetCell(cellIndex).ColumnIndex, out rowSpan, out cellspan);
                                                if (result)
                                                {
                                                    CellRangeAddress celladdress = new CellRangeAddress(rowIndex + dtRowIndex, rowIndex + dtRowIndex + rowSpan - 1, cellIndex, cellIndex + cellspan - 1);
                                                    sheet.AddMergedRegion(celladdress);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            using (MemoryStream steam = new MemoryStream())
            {
                //将数据写入流
                wk.Write(steam);
                //BufferedStream bs = new BufferedStream(new stream);
                //wk.Write(file);
                // MemoryStream stream  = new MemoryStream(wk.GetBytes());
                //FileStream file = new FileStream( @"D:/辅料采购信息.xls", FileMode.Create);
                return steam;
            }
        }

        /// <summary>
        ///  // 判断合并单元格重载
        /// 调用时要在输出变量前加 out
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="rowNum"></param>
        /// <param name="colNum"></param>
        /// <param name="rowSpan"></param>
        /// <param name="colSpan"></param>
        /// <returns></returns>
        public static bool isMergeCell(ISheet sheet, int rowNum, int colNum, out int rowSpan, out int colSpan)
        {
            bool result = false;
            rowSpan = 0;
            colSpan = 0;
            if ((rowNum < 0) || (colNum < 0)) return result;
            int rowIndex = rowNum;
            int colIndex = colNum;
            int regionsCount = sheet.NumMergedRegions;
            rowSpan = 1;
            colSpan = 1;
            for (int i = 0; i < regionsCount; i++)
            {
                CellRangeAddress range = sheet.GetMergedRegion(i);
                sheet.IsMergedRegion(range);
                if (range.FirstRow == rowIndex && range.FirstColumn == colIndex)
                {
                    rowSpan = range.LastRow - range.FirstRow + 1;
                    colSpan = range.LastColumn - range.FirstColumn + 1;
                    break;
                }
            }
            try
            {
                result = sheet.GetRow(rowIndex).GetCell(colIndex).IsMergedCell;
            }
            catch
            {
            }
            return result;
        }

        #endregion



        /// <summary>
        /// 改变DataTable的列名称  by 何伟
        /// </summary>
        /// <param name="dt">表格</param>
        /// <param name="strArr">列名称字符串数组</param>
        public static DataTable ChangeDataTableColumnName(DataTable dt, string[] strArr)
        {
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                if (i < strArr.Length)
                {
                    dt.Columns[i].ColumnName = strArr[i];
                }
            }
            return dt;
        }

        #region 从excel中导出数据

        /// <summary>
        /// 读取excel
        /// </summary>
        /// <param name="strFileName">excel文件路径</param>
        /// <param name="sheet">需要导出的sheet</param>
        /// <param name="HeaderRowIndex">列头所在行号，-1表示没有列头</param>
        /// <returns></returns>
        public static DataTable ImportExceltoDt(string strFileName, string SheetName, int HeaderRowIndex)
        {
            IWorkbook wb;
            using (FileStream file = new FileStream(strFileName, FileMode.Open, FileAccess.Read))
            {
                wb = new HSSFWorkbook(file);
            }
            ISheet sheet = wb.GetSheet(SheetName);
            DataTable table = new DataTable();
            table = ImportDt(sheet, HeaderRowIndex, true);
            //ExcelFileStream.Close();
            return table;
        }

        /// <summary>
        /// 读取excel
        /// </summary>
        /// <param name="strFileName">excel文件路径</param>
        /// <param name="sheet">需要导出的sheet序号</param>
        /// <param name="HeaderRowIndex">列头所在行号，-1表示没有列头</param>
        /// <returns></returns>
        public static DataTable ImportExceltoDt(string strFileName, int SheetIndex, int HeaderRowIndex)
        {
            IWorkbook wb;
            using (FileStream file = new FileStream(strFileName, FileMode.Open, FileAccess.Read))
            {
                wb = WorkbookFactory.Create(file);
            }
            ISheet isheet = wb.GetSheetAt(SheetIndex);
            DataTable table = new DataTable();
            table = ImportDt(isheet, HeaderRowIndex, true);
            //ExcelFileStream.Close();
            return table;
        }

        /// <summary>
        /// 读取excel
        /// </summary>
        /// <param name="strFileName">excel文件路径</param>
        /// <param name="sheet">需要导出的sheet</param>
        /// <param name="HeaderRowIndex">列头所在行号，-1表示没有列头</param>
        /// <returns></returns>
        public static DataTable ImportExceltoDt(string strFileName, string SheetName, int HeaderRowIndex, bool needHeader)
        {
            IWorkbook wb;
            using (FileStream file = new FileStream(strFileName, FileMode.Open, FileAccess.Read))
            {
                wb = WorkbookFactory.Create(file);
            }
            ISheet sheet = wb.GetSheet(SheetName);
            DataTable table = new DataTable();
            table = ImportDt(sheet, HeaderRowIndex, needHeader);
            //ExcelFileStream.Close();
            return table;
        }

        /// <summary>
        /// 读取excel
        /// </summary>
        /// <param name="strFileName">excel文件路径</param>
        /// <param name="sheet">需要导出的sheet序号</param>
        /// <param name="HeaderRowIndex">列头所在行号，-1表示没有列头</param>
        /// <returns></returns>
        public static DataTable ImportExceltoDt(string strFileName, int SheetIndex, int HeaderRowIndex, bool needHeader)
        {
            IWorkbook wb;
            using (FileStream file = new FileStream(strFileName, FileMode.Open, FileAccess.Read))
            {
                wb = WorkbookFactory.Create(file);
            }
            ISheet sheet = wb.GetSheetAt(SheetIndex);
            DataTable table = new DataTable();
            table = ImportDt(sheet, HeaderRowIndex, needHeader);
            //ExcelFileStream.Close();
            return table;
        }

        /// <summary>
        /// 从excel中读取数据到dataTable
        /// </summary>
        /// <param name="strFileName">文件路径</param>
        /// <param name="startPosition">开始的位置 如A1</param>
        /// <param name="endPosition">结束的位置 如F34</param>
        /// <param name="includeHeader">是否包含列头,如果包含，列头将被映射成列明</param>
        /// <param name="sheetIndex">sheet索引</param>
        /// <returns></returns>
        public static DataTable ImportExceltoDt(string strFileName, string startPosition, string endPosition, bool includeHeader, int sheetIndex)
        {
            if (sheetIndex < 0)
            {
                sheetIndex = 0;
            }
            DataTable dt = new DataTable();
            IWorkbook wb;
            using (FileStream file = new FileStream(strFileName, FileMode.Open, FileAccess.Read))
            {
                wb = WorkbookFactory.Create(file);
            }
            ISheet sheet = wb.GetSheetAt(sheetIndex);
            dt = ImportDt(sheet, startPosition, endPosition, includeHeader);
            return dt;
        }

        /// <summary>
        /// excel -> datatable
        /// </summary>
        /// <param name="stram"></param>
        /// <param name="startPosition"></param>
        /// <param name="endPosition"></param>
        /// <returns></returns>
        public static DataTable ImportExceltoDtByHW(Stream stram, string startPosition, int colCount)
        {
            DataTable dt = new DataTable();
            IWorkbook wb = WorkbookFactory.Create(stram);
            ISheet sheet = wb.GetSheetAt(0);
            dt = ImportDt(sheet, startPosition, colCount, false);
            return dt;
        }
        /// <summary>
        /// excel -> datatable
        /// </summary>
        /// <param name="stram"></param>
        /// <param name="startPosition"></param>
        /// <param name="colCount"></param>
        /// <returns></returns>
        public static DataTable ImportExceltoDtByHW(IWorkbook workbook, string startPosition, int colCount)
        {
            DataTable dt = new DataTable();
            ISheet sheet = workbook.GetSheetAt(0);
            dt = ImportDt(sheet, startPosition, colCount, false);
            return dt;
        }

        /// <summary>
        /// 从excel中读取数据到dataTable 不设置行数知道行没有时结束
        /// </summary>
        /// <param name="strFileName">文件路径</param>
        /// <param name="startPosition">开始的位置 如A1</param>
        /// <param name="colCount">读取几列/param>
        /// <param name="includeHeader">是否包含列头,如果包含，列头将被映射成列明</param>
        /// <param name="sheetIndex">sheet索引</param>
        /// <returns></returns>
        public static DataTable ImportExceltoDt(string strFileName, string startPosition, int colCount, bool includeHeader, int sheetIndex)
        {
            if (sheetIndex < 0)
            {
                sheetIndex = 0;
            }
            DataTable dt = new DataTable();
            IWorkbook wb;
            using (FileStream file = new FileStream(strFileName, FileMode.Open, FileAccess.Read))
            {
                wb = WorkbookFactory.Create(file);
            }
            ISheet sheet = wb.GetSheetAt(sheetIndex);
            if (sheet == null)
            {
                return dt;
            }
            dt = ImportDt(sheet, startPosition, colCount, includeHeader);
            return dt;
        }

        /// <summary>
        /// 读取excel 默认第一行为标头
        /// </summary>
        /// <param name="strFileName">excel文档路径</param>
        /// <returns></returns>
        public static DataTable ImportExceltoDt(string strFileName)
        {
            DataTable dt = new DataTable();
            IWorkbook wb;
            using (FileStream file = new FileStream(strFileName, FileMode.Open, FileAccess.Read))
            {
                wb = WorkbookFactory.Create(file);
            }
            ISheet sheet = wb.GetSheetAt(0);
            dt = ImportDt(sheet, 0, true);
            return dt;
        }

        /// <summary>
        /// 读取Excel流到DataTable
        /// </summary>
        /// <param name="stream">Excel流</param>
        /// <returns>第一个sheet中的数据</returns>
        public static DataTable ImportExceltoDt(Stream stream)
        {
            try
            {
                DataTable dt = new DataTable();
                IWorkbook wb;
                using (stream)
                {
                    wb = WorkbookFactory.Create(stream);
                }
                ISheet sheet = wb.GetSheetAt(0);
                dt = ImportDt(sheet, 0, true);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// 读取Excel流到DataTable
        /// </summary>
        /// <param name="stream">Excel流</param>
        /// <param name="sheetName">表单名</param>
        /// <param name="HeaderRowIndex">列头所在行号，-1表示没有列头</param>
        /// <returns>指定sheet中的数据</returns>
        public static DataTable ImportExceltoDt(Stream stream, string sheetName, int HeaderRowIndex)
        {
            try
            {
                DataTable dt = new DataTable();
                IWorkbook wb;
                using (stream)
                {
                    wb = WorkbookFactory.Create(stream);
                }
                ISheet sheet = wb.GetSheet(sheetName);
                dt = ImportDt(sheet, HeaderRowIndex, true);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// 获取excel表格的所有数据 by 何伟
        /// </summary>
        /// <param name="strFileName">文件路径</param>
        /// <param name="sheetIndex">sheet索引</param>
        /// <returns></returns>
        public static DataTable ImportExcelAllDataToDt(string strFileName, int sheetIndex)
        {
            IWorkbook wb;
            using (FileStream file = new FileStream(strFileName, FileMode.Open, FileAccess.Read))
            {
                wb = WorkbookFactory.Create(file);
            }
            ISheet isheet = wb.GetSheetAt(sheetIndex);
            DataTable table = new DataTable();
            table = ImportDt(isheet, -1, false);
            return table;
        }


        /// <summary>
        /// 将sheet数据读取到DataTable
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="startPosition">开始位置</param>
        /// <param name="endPosition">结束位置</param>
        /// <param name="includeHeader">是否包含列头</param>
        /// <returns></returns>
        public static DataTable ImportDt(ISheet sheet, string startPosition, string endPosition, bool includeHeader)
        {
            DataTable table = new DataTable();
            int[] startIndexPosition = GetRowAndColIndex(startPosition);
            int[] endIndexPosition = GetRowAndColIndex(endPosition);
            var colCount = endIndexPosition[0] - startIndexPosition[0] + 1;
            var rowCount = 0;
            if (includeHeader)
            {
                rowCount = endIndexPosition[1] - startIndexPosition[1];
            }
            else
            {
                rowCount = endIndexPosition[1] - startIndexPosition[1] + 1;
                ///不含列头 给列默认列名
                for (int i = 0; i < colCount; i++)
                {
                    table.Columns.Add(i.ToString(), typeof(string));
                }
            }
            bool result = false; ///是否已经将一列赋值给header
            //遍历开始行到结束行
            int dataRowIndex = 0; //DataTable 的行索引
            for (int rowIndex = startIndexPosition[1]; rowIndex < endIndexPosition[1] + 1; rowIndex++)
            {
                IRow row = sheet.GetRow(rowIndex);
                //行为null继续遍历下一行
                if (row == null)
                {
                    continue;
                }

                DataRow dataRow = table.NewRow();
                //遍历开始列到结束列
                int DataColIndex = 0; //DataTable的列索引
                for (int colIndex = startIndexPosition[0]; colIndex < endIndexPosition[0] + 1; colIndex++)
                {
                    ICell cell = row.GetCell(colIndex);
                    string cellValue = GetCellStringValue(cell);
                    dataRow[DataColIndex++] = cellValue;
                }
                //如果需要生成列则生成列
                if (!result && includeHeader)
                {
                    //遍历这一行生成列
                    foreach (var item in dataRow.ItemArray)
                    {
                        //防止列名重复
                        if (table.Columns.IndexOf(item.ToString()) < 0)
                        {
                            table.Columns.Add(item.ToString(), typeof(string));
                        }
                        else
                        {
                            table.Columns.Add(item.ToString() + "-repeat-" + table.Columns.IndexOf(item.ToString()), typeof(string));
                        }

                    }
                    result = true;
                }
                else
                {
                    table.Rows.Add(dataRow);
                    dataRowIndex++;
                }
            }
            return table;
        }

        /// <summary>
        /// 将数据读取到DataTable 
        /// </summary>
        /// <param name="sheet">sheet</param>
        /// <param name="startPosition">开始位置</param>
        /// <param name="colCount">导入的列的列数</param>
        /// <param name="includeHeader">是否包括表头</param>
        /// <returns></returns>
        public static DataTable ImportDt(ISheet sheet, string startPosition, int colCount, bool includeHeader)
        {
            if (colCount < 1)
            {
                throw new Exception("列数必须大于0");
            }
            DataTable table = new DataTable();
            int[] startIndexPosition = GetRowAndColIndex(startPosition);
            if (includeHeader)
            {
            }
            else
            {
                ///不含列头 给列默认列名
                for (int i = 0; i < colCount; i++)
                {
                    table.Columns.Add(i.ToString(), typeof(string));
                }
            }
            bool result = false; ///是否已经将一列赋值给header
            //遍历开始行到结束行
            int dataRowIndex = 0; //DataTable 的行索引
            int rowIndex = startIndexPosition[1];
            while (sheet.GetRow(rowIndex) != null)
            {
                IRow row = sheet.GetRow(rowIndex++);

                //如果需要生成列则生成列
                if (!result && includeHeader)
                {
                    for (int colIndex = startIndexPosition[0]; colIndex < startIndexPosition[0] + colCount; colIndex++)
                    {
                        ICell cell = row.GetCell(colIndex);
                        string cellValue = GetCellStringValue(cell);
                        if (table.Columns.IndexOf(cellValue) < 0)
                        {
                            table.Columns.Add(cellValue, typeof(string));
                        }
                        else
                        {
                            table.Columns.Add(cellValue + "-repeat-" + table.Columns.IndexOf(cellValue), typeof(string));
                        }
                    }
                    result = true;
                }
                else
                {
                    DataRow dataRow = table.NewRow();
                    //遍历开始列到结束列
                    int DataColIndex = 0; //DataTable的列索引
                    for (int colIndex = startIndexPosition[0]; colIndex < startIndexPosition[0] + colCount; colIndex++)
                    {
                        ICell cell = row.GetCell(colIndex);
                        string cellValue = GetCellStringValue(cell);
                        dataRow[DataColIndex++] = cellValue;
                    }
                    table.Rows.Add(dataRow);
                }
                dataRowIndex++;
            }
            return table;
        }
        #endregion







        /// <summary>
        /// 根据位置信息返回单元格在sheet中的行索引与列索引 如 A2 返回[0,1]  
        /// 只支持24列  (by何伟)需完善支持超过24列
        /// 
        /// </summary>
        /// <param name="position">位置字符串 如A1</param>
        /// <returns></returns>
        public static int[] GetRowAndColIndex(string position)
        {
            StringBuilder rowsb = new StringBuilder();
            StringBuilder colsb = new StringBuilder();
            foreach (var item in position)
            {
                if (Char.IsNumber(item))
                {
                    rowsb.Append(item);
                }
                else
                {
                    colsb.Append(item);
                }
            }
            int rowIndex = Convert.ToInt32(rowsb.ToString()) - 1;
            int colIndex = Convert.ToInt32(colsb.ToString().ToCharArray()[0]) - Convert.ToInt32('A');
            return new[] { colIndex, rowIndex };
        }


        /// <summary>
        /// 获取指定excel文件中指定sheet指定位置的string值 by何伟
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="sheetIndex">sheet索引</param>
        /// <param name="position">单元格位置</param>
        /// <returns></returns>
        public static string GetPositionStringValue(string filePath, int sheetIndex, string position)
        {
            if (sheetIndex < 0)
            {
                sheetIndex = 0;
            }
            DataTable dt = new DataTable();
            IWorkbook wb;
            using (FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                wb = WorkbookFactory.Create(file);
            }
            ISheet sheet = wb.GetSheetAt(sheetIndex);
            return GetPositionStringValue(sheet, position);
        }

        /// <summary>
        /// 获取第一个sheet的指定位置的string值
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="opsition"></param>
        /// <returns></returns>
        public static string GetPositionStringValue(Stream stream, string position)
        {
            int[] positionIndex = GetRowAndColIndex(position);
            IWorkbook wb = WorkbookFactory.Create(stream);
            ISheet sheet = wb.GetSheetAt(0);
            var row = sheet.GetRow(positionIndex[1]) ?? sheet.CreateRow(positionIndex[1]);
            ICell cell = row.GetCell(positionIndex[0]) ?? row.CreateCell(positionIndex[0]);
            return GetCellStringValue(cell);
        }
        /// <summary>
        /// 获取workbook的第一个sheet的指定位置position 的string值
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="position"></param>
        /// <returns></returns>
        public static string GetPositionStringValue(IWorkbook workbook, string position)
        {
            int[] positionIndex = GetRowAndColIndex(position);
            ISheet sheet = workbook.GetSheetAt(0);
            var row = sheet.GetRow(positionIndex[1]) ?? sheet.CreateRow(positionIndex[1]);
            ICell cell = row.GetCell(positionIndex[0]) ?? row.CreateCell(positionIndex[0]);
            return GetCellStringValue(cell);
        }

        /// <summary>
        /// 得到单元格的数据
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="position"></param>
        /// <returns></returns>
        public static string GetPositionStringValue(ISheet sheet, string position)
        {
            int[] positionIndex = GetRowAndColIndex(position);
            DataTable dt = new DataTable();
            var row = sheet.GetRow(positionIndex[1]);
            ICell cell = null;
            if (row != null)
            {
                cell = row.GetCell(positionIndex[0]);
            }
            return GetCellStringValue(cell);
        }

        /// <summary>
        /// 向指定单元格保存数据 by 何伟
        /// </summary>
        /// <param name="sheet">sheet</param>
        /// <param name="position">位置</param>
        /// <param name="value">value</param>
        public static void SetPositionStringValue(ISheet sheet, string position, string value)
        {
            int[] positionIndex = GetRowAndColIndex(position);
            var row = sheet.GetRow(positionIndex[1]) ?? sheet.CreateRow(positionIndex[1]);
            ICell cell = row.GetCell(positionIndex[0]) ?? row.CreateCell(positionIndex[0]);
            cell.SetCellValue(value);
        }

        /// <summary>
        /// 指定位置设置值
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="position"></param>
        /// <param name="value"></param>
        public static void SetPositionStringValue(ISheet sheet, string position, decimal value)
        {
            int[] positionIndex = GetRowAndColIndex(position);
            var row = sheet.GetRow(positionIndex[1]) ?? sheet.CreateRow(positionIndex[1]);
            ICell cell = row.GetCell(positionIndex[0]) ?? row.CreateCell(positionIndex[0]);
            cell.SetCellValue(Convert.ToDouble(value));
        }

        /// <summary>
        /// 得到单元格的string值 by何伟
        /// </summary>
        /// <param name="cell"></param>
        /// <returns></returns>
        public static string GetCellStringValue(ICell cell)
        {
            string cellValue = "";
            if (cell != null)
            {
                switch (cell.CellType)
                {
                    case CellType.String:
                        string str = cell.StringCellValue;
                        if (str != null && str.Length > 0)
                        {
                            cellValue = str.ToString();
                        }
                        else
                        {
                            cellValue = "";
                        }
                        break;
                    case CellType.Numeric:
                        if (DateUtil.IsCellDateFormatted(cell))
                        {
                            cellValue = DateTime.FromOADate(cell.NumericCellValue).ToString();
                        }
                        else
                        {
                            cellValue = Convert.ToDouble(cell.NumericCellValue).ToString();
                        }
                        break;
                    case CellType.Boolean:
                        cellValue = Convert.ToString(cell.BooleanCellValue);
                        break;
                    case CellType.Error:
                        cellValue = ErrorEval.GetText(cell.ErrorCellValue);
                        break;
                    case CellType.Formula:
                        switch (cell.CachedFormulaResultType)
                        {
                            case CellType.String:
                                string strFORMULA = cell.StringCellValue;
                                if (strFORMULA != null && strFORMULA.Length > 0)
                                {
                                    cellValue = strFORMULA.ToString();
                                }
                                else
                                {
                                    cellValue = null;
                                }
                                break;
                            case CellType.Numeric:
                                cellValue = Convert.ToString(cell.NumericCellValue);
                                break;
                            case CellType.Boolean:
                                cellValue = Convert.ToString(cell.BooleanCellValue);
                                break;
                            case CellType.Error:
                                cellValue = ErrorEval.GetText(cell.ErrorCellValue);
                                break;
                            default:
                                cellValue = "";
                                break;
                        }
                        break;
                    default:
                        cellValue = "";
                        break;
                }
            }
            return cellValue;
        }


        /// <summary>
        /// 创建workbook by 何伟
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public static HSSFWorkbook CreateWorkBook(string filepath)
        {
            FileStream readfile = null;
            try
            {
                readfile = new FileStream(filepath, FileMode.Open, FileAccess.Read);
                return new HSSFWorkbook(readfile);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (readfile != null)
                {
                    readfile.Close();
                }
            }
        }


        /// <summary>
        /// 复制sheet到另一个workbook
        /// </summary>
        /// <param name="workbook"></param>
        /// <param name="sheet"></param>
        public static ISheet CopySheetToExcel(IWorkbook workbook, ISheet sourceSheet)
        {
            ((HSSFSheet)sourceSheet).CopyTo((HSSFWorkbook)workbook, sourceSheet.SheetName, true, true);
            return workbook.GetSheet(sourceSheet.SheetName);
        }

        /// <summary>
        /// 复制sheet到另一个sheet
        /// </summary>
        /// <param name="workbook"></param>
        /// <param name="sourceSheet"></param>
        /// <param name="newSheetName"></param>
        /// <returns></returns>
        public static ISheet CopySheetToExcel(IWorkbook workbook, ISheet sourceSheet, string newSheetName)
        {
            ((HSSFSheet)sourceSheet).CopyTo((HSSFWorkbook)workbook, newSheetName, true, true);
            return workbook.GetSheet(newSheetName);
        }
    }
}
