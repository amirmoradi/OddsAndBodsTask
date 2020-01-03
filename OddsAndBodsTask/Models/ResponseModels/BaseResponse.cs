using System;
using System.Collections.Generic;
using System.Text;

namespace OddsAndBodsTask.Models.ResponseModels
{
    public class BaseResponse
    {
        public int count { get; set; }
        public string next { get; set; }
        public string previous { get; set; }
    }
}
