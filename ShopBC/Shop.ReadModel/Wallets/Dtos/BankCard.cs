﻿using System;

namespace Shop.ReadModel.Wallets.Dtos
{
    public class BankCard
    {
        public Guid Id { get; set; }
        public Guid WalletId { get; set; }
        public string BankName { get; set; }
        public string OwnerName { get; set; }
        public string Number { get; set; }
    }
}
