using System;
using System.Collections.Generic;
using System.Text;

namespace Data.ViewModels
{
    public class ResultModel
    {
        public string ErrorMessage { get; set; }
        public bool Success { get; set; } = false;
        public object Data { get; set; }
    }
}
