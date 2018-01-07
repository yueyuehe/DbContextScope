using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Ticket
{
    /// <summary>
    /// 淘宝联盟商品
    /// </summary>
    public class Goods
    {
        /// <summary>
        /// 商品id
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// 商品ID
        /// </summary>
        public string GoodsNumber { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 商品主图
        /// </summary>
        public string ImageUrl { get; set; }
        /// <summary>
        /// 商品详情页链接地址
        /// </summary>
        public string DescriptionUrl { get; set; }
        /// <summary>
        /// 商品一级类目
        /// </summary>
        public string Category { get; set; }
        /// <summary>
        /// 淘宝客链接
        /// </summary>
        public string TaoBaoKe { get; set; }
        /// <summary>
        /// 淘宝客短连接
        /// </summary>
        public string TaoBaoKeShortUrl { get; set; }
        /// <summary>
        /// 淘口令
        /// </summary>
        public string TaoBaoToken { get; set; }
        /// <summary>
        /// 商品价格(单位：元)
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// 商品月销量
        /// </summary>
        public int SalesVolume { get; set; }
        /// <summary>
        /// 收入比率(%)
        /// </summary>
        public decimal CommissionRatio { get; set; }
        /// <summary>
        /// 佣金
        /// </summary>
        public decimal Commission { get; set; }
        /// <summary>
        /// 卖家旺旺
        /// </summary>
        public string SaleMan { get; set; }
        /// <summary>
        /// /卖家id
        /// </summary>
        public string SaleManID { get; set; }
        /// <summary>
        /// 店铺名称
        /// </summary>
        public string ShopName { get; set; }
        /// <summary>
        /// 平台类型
        /// </summary>
        public string ShopType { get; set; }
        /// <summary>
        /// 优惠券id
        /// </summary>
        public string TicketId { get; set; }
        /// <summary>
        /// 优惠券总量
        /// </summary>
        public int TicketTotalNum { get; set; }
        /// <summary>
        /// 优惠券剩余量
        /// </summary>
        public int TicketNum { get; set; }
        /// <summary>
        /// 优惠券说明
        /// </summary>
        public string TicketDescription { get; set; }
        /// <summary>
        /// 优惠券说明
        /// </summary>
        public decimal TicketPrice { get; set; }
        /// <summary>
        /// 优惠券开始时间
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// 优惠券结束时间
        /// </summary>
        public DateTime EndDate { get; set; }
        /// <summary>
        /// 优惠券链接
        /// </summary>
        public string TicketUrl { get; set; }
        /// <summary>
        /// 优惠券推广链接
        /// </summary>
        public string TicketPutUrl { get; set; }
        /// <summary>
        /// 优惠券短连接
        /// </summary>
        public string TicketPutShortUrl { get; set; }
        /// <summary>
        /// 优惠券淘口令
        /// </summary>
        public string TicketPutToken { get; set; }
        /// <summary>
        /// 是否为营销计划商品
        /// </summary>
        public string GoodsType { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdateTime { get; set; }
        /// <summary>
        /// 下载时间
        /// </summary>
        public DateTime DownDateTime { get; set; }
    }
}
