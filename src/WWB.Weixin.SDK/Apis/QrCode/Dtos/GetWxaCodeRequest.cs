namespace WWB.Weixin.SDK.Apis.QrCode.Dtos
{
    public class GetWxaCodeRequest
    {
        public string path { get; set; }
        public int? width { get; set; }
        public bool auto_color { get; set; }
        public object line_color { get; set; }
        public bool is_hyaline { get; set; }
    }
}