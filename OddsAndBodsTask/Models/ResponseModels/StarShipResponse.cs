using System;
using System.Collections.Generic;
using System.Text;

namespace OddsAndBodsTask.Models.ResponseModels
{
    public class StarShipResponse : BaseResponse
    {
        public List<StarshipResponseItemModel> results { get; set; }
    }
}
