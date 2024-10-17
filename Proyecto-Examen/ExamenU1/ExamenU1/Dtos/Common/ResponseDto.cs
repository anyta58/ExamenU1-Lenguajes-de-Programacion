using Newtonsoft.Json;

namespace ExamenU1.Dtos.Common;
public class ResponseDto<T>
{
     public  T Data { get; set; }
     public string Message { get; set; }

     [JsonIgnore]
     public int StatusCode { get; set; }
     public int Status { get; set; }
}
