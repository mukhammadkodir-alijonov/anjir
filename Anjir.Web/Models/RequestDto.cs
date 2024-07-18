﻿using static Anjir.Web.Utility.SD;

namespace Anjir.Web.Models
{
    public class RequestDto
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string Url { get; set; } = string.Empty;
        public object Data { get; set; }
        public string AccessToken { get; set; } = string.Empty;
    }
}
