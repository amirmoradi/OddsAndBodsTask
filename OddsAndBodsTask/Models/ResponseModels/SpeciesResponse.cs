using System;
using System.Collections.Generic;
using System.Text;

namespace OddsAndBodsTask.Models.ResponseModels
{
    public class SpeciesResponse : BaseResponse
    {
        public List<SpeciesResponseItemModel> results { get; set; }
    }
}
