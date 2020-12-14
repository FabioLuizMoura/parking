using Parking.Domain.Dtos;
using System.Runtime.Serialization;

namespace Parking.API.Models
{
    [DataContract]
    public class ResponseModel<T>
    {
        public ResponseModel(bool success, T data)
        {
            Success = success;
            Data = data;
        }

        [DataMember]
        public bool Success { get; set; }

        [DataMember]
        public T Data { get; set; }
    }
}
