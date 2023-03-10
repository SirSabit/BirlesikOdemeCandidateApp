using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Boca.Dtos.ResponseDtos
{
    public class BaseResponseDto
    {
        [JsonIgnore]
        public int StatusCode { get; set; }
        public string Message { get; set; }
    }
}
