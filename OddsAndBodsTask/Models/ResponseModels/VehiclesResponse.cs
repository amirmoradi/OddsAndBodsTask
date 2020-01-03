using System;
using System.Collections.Generic;
using System.Text;

namespace OddsAndBodsTask.Models.ResponseModels
{
    public class VehiclesResponse : BaseResponse
    {
        public List<VehicleResponseItemModel> results { get; set; }
    }
    
}
