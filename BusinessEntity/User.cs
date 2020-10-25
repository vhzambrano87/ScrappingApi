﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessEntity
{
    public class User
    {
        public int id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public bool active { get; set; }
        public DateTime created { get; set; }
    }
}
