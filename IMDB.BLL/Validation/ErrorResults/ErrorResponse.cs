using System;
using System.Collections.Generic;
using System.Text;

namespace IMDB.BLL.Validation.ErrorResults
{
  public class ErrorResponse
    {
        public List<ErrorModel> Errors { get; set; } = new List<ErrorModel>();
    }
}
