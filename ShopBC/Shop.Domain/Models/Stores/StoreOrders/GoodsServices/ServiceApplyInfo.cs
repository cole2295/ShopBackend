﻿using System;

namespace Shop.Domain.Models.Stores.StoreOrders.GoodsServices
{
    /// <summary>
    /// 商品服务申请
    /// </summary>
    [Serializable]
    public class ServiceApplyInfo
    {
        /// <summary>
        /// 服务单号
        /// </summary>
        public string ServiceNumber { get;private set; }
        public GoodsServiceType ServiceType { get; private set; }
        public int Quantity { get; private set; }
        public string Reason { get; private set; }
        public string Remark { get; private set; }

        public ServiceApplyInfo(string serviceNumber,
            GoodsServiceType serviceType,
            int quantity,
            string reason,
            string remark)
        {
            ServiceNumber = serviceNumber;
            ServiceType = serviceType;
            Quantity = quantity;
            Reason = reason;
            Remark = remark;
        }
    }

    /// <summary>
    /// 商品服务类型
    /// </summary>
    public enum GoodsServiceType
    {
        /// <summary>
        /// 退货
        /// </summary>
        SalesReturn=1,
        /// <summary>
        /// 退款
        /// </summary>
        Refund=2,
        /// <summary>
        /// 维修
        /// </summary>
        Service=3,
        /// <summary>
        /// 上门服务
        /// </summary>
        ToDoorService=4,
        /// <summary>
        /// 换货
        /// </summary>
        Change=5
    }
}