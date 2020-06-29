using CalculaJuros.Manager.Models.Error;
using System;

namespace CalculaJuros.Manager.Models.WS
{
    public class ResultCoreModel
    {
        public Boolean Success { get; set; }
        public ErrorModel Error { get; set; }
        public dynamic ResultData { get; set; }
    }
}
