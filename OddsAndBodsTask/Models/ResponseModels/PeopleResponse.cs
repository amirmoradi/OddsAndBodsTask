using System;
using System.Collections.Generic;
using System.Text;

namespace OddsAndBodsTask.Models.ResponseModels
{
    public class PeopleResponse: BaseResponse
    {
        public List<PeopleResponseItemModel> results { get; set; }
    }
}
