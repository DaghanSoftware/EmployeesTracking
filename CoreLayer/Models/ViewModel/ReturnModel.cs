﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Libraries.EmployeesTracking.Core.Models.ViewModel
{
    public class ReturnModel
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
        public List<string> Message2 { get; set; }
    }
}
