using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManager.Application.ModelsDTO
{
  public class ResultViewModel
  {
    public ResultViewModel(bool isSuccess = true, string message = "")
    {
      IsSuccess = isSuccess;
      Message = message;
    }

    public bool IsSuccess { get; set; }
    public string Message { get; set; }
    public static ResultViewModel Success() => new();

    public static ResultViewModel Error(string message) => new(false, message);
  }

  public class ResultViewModel<T> : ResultViewModel
  {
    public T? Data { get; set; }
    public ResultViewModel(T? data, bool isSuccess = true, string message = "") : base(isSuccess, message)
    {

      Data = data;
    }

    //Expression-Bodied Member Definition
    public static ResultViewModel<T> Success(T data) => new ResultViewModel<T>(data);
    //Expression-Bodied Member Definition
    public static ResultViewModel<T> Error(string message) => new(default, false, message);
  }




}
