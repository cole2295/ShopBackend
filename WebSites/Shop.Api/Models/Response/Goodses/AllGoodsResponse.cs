﻿using System;
using System.Collections.Generic;

namespace Shop.Api.Models.Response.Goodses
{
    public class AllGoodsResponse:BaseApiResponse
    {
        public int Total { get; set; }
        public IList<GoodsDetails> Goodses { get; set; }
    }

    public class GoodsDetails
    {
        public Guid Id { get; set; }
        public Guid StoreId { get; set; }
        public IList<string> Pics { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal OriginalPrice { get; set; }
        public int Stock { get; set; }
        public decimal Surrender { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsPayOnDelivery { get; set; }
        public bool IsInvoice { get; set; }
        public bool Is7SalesReturn { get; set; }

        public Single Rate { get;  set; }
        public Single PriceRate { get;  set; }
        public Single DescribeRate { get;  set; }
        public Single QualityRate { get;  set; }
        public Single ExpressRate { get;  set; }
        public int RateCount { get;  set; }

        public int Sort { get; set; }
    }
}