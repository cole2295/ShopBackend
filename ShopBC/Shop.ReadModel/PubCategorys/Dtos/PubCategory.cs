﻿using System;

namespace Shop.ReadModel.PubCategorys.Dtos
{
    public class PubCategory
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Thumb { get; set; }
        public bool IsShow { get; set; }
        public int Sort { get; set; }

    }
}
