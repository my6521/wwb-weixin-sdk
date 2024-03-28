using Newtonsoft.Json;

namespace WWB.Weixin.Work.Apis
{
    public class ApiResultBase
    {
        [JsonProperty("errcode")]
        public int ErrCode { get; set; }

        [JsonProperty("errmsg")]
        public string ErrMsg { get; set; }

        public bool IsSuccess()
        {
            return ErrCode == 0;
        }
    }
}