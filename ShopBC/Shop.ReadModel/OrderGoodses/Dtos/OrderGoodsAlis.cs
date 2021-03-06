﻿using Shop.Common.Enums;
using System;

namespace Shop.ReadModel.OrderGoodses.Dtos
{
    public class OrderGoodsAlis
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid GoodsId { get; set; }
        public Guid SpecificationId { get; set; }
        public Guid WalletId { get; set; }
        public Guid StoreOwnerWalletId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal OriginalPrice { get; set; }
        public decimal Total { get; set; }
        public decimal StoreTotal { get; set; }
        public decimal Surrender { get; set; }
        public DateTime ServiceExpirationDate { get; set; }
        public OrderGoodsStatus Status { get; set; }
    }
}
