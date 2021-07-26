using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.ViewModel
{
    public class ResponseAPI<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public T Data { get; set; }

        public ResponseAPI(T data, bool success = true, string message = Domain.Model.ViewModel.Message.OperacaoSucesso)
        {
            Data = data;
            Message = message;
            Success = success;
        }
    }
}
