﻿using System;

namespace Narvan.Domains.Commons
{
    public abstract class BaseEntity
    {
        public long Id { get; set; }
        public bool IsDelete { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}