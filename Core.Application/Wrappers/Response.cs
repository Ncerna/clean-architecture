using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Application.Wrappers;

public class Response<T>
{
    public bool Success { get; set; }

    public string? Message { get; set; }

    public T? Data { get; set; }

    public static Response<T> Ok(T data)
        => new Response<T> { Success = true, Data = data };

    public static Response<T> Fail(string message)
        => new Response<T> { Success = false, Message = message };
}

public class Response
{
    public bool Success { get; set; }

    public string? Message { get; set; }

    public static Response Ok()
        => new Response { Success = true };

    public static Response Fail(string message)
        => new Response { Success = false, Message = message };
}
