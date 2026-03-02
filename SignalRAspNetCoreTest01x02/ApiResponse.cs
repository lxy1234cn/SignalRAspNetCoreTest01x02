namespace SignalRAspNetCoreTest01x02
{
    public class ApiResponse<T>
    {
        public int Code { get; set; }    // 200 400 …
        public string Msg { get; set; } = string.Empty;
        public T? Data { get; set; }
        public static ApiResponse<T> Ok(T? data = default, string msg = "success")//这里T? 表示T可以为null,可以不使用形参T,也可以使用形参T。
            => new() { Code = 200, Msg = msg, Data = data };
        public static ApiResponse<T> Fail(string msg, int code = 400)
            => new() { Code = code, Msg = msg, Data = default };
    }
}
