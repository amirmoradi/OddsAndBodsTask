using System;
using System.Collections.Generic;
using System.Text;

namespace OddsAndBodsTask.Models.ResponseModels
{
    public class PlanetsResponse : BaseResponse
    {
        public List<PlanetResponseItemModel> results { get; set; }
    }
}
