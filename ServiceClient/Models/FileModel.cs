﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceClient.Models
{
    public class FileModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public byte[] data { get; set; }
        public string Courses { get; set; }
    }
}