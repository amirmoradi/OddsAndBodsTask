using System;
using System.Collections.Generic;
using System.Text;

namespace OddsAndBodsTask.Models.ResponseModels
{
    public class FilmsResponse: BaseResponse
    {
        public List<FilmResponseItemModel> results { get; set; }
    }
}
