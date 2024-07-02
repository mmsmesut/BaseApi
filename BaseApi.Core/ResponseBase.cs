namespace BaseApi.Core
{
    public class Response<T>
    {
        public bool Success { get; set; }

        public string? Message { get; set; }
        public T Data { get; set; }
        public int StatusCode { get; set; } // HTTP status code


        public Response()
        {
            this.Success = true;
            this.Message = null;
            this.Data = default!; //default(T)
            this.StatusCode = 200; //Default to OK
        }

        public Response(T data)
        {
            this.Success = true;
            this.Message = null;
            this.Data = data;
            this.StatusCode = 200; //Default to OK
        }
        public Response(string? message, int statusCode)
        {
            this.Success = true;
            this.Message = message;
            this.Data = default!; //default(T)
            this.StatusCode = statusCode;
        }
    }
}

/*
 
ChatGPT
default! ifadesi, C# 8.0'dan itibaren gelen bir özelliktir ve nullable reference types 
(null kabul edilebilir referans tipleri) için kullanılır. 
Bu ifade, nullable bir türde varsayılan değeri ifade etmek için kullanılırken, 
C# 8.0 öncesinde kullanılan default(T) ifadesinin yerini almıştır
 
default(T): T türünde nullable olmayan bir değişkenin varsayılan değerini 
(örneğin, null değilse, 0 veya false gibi) döndürür.

default!: T türünde nullable olan bir değişkenin varsayılan değerini döndürür. 
Bu, nullable bir türün varsayılan değerinin null olabileceğini, 
ancak programcının bu durumu garanti altına almak istediğini belirtir.

string? nullableString = default!; // nullableString değişkeni null olacaktır

 */