﻿using Newtonsoft.Json;

namespace WWB.Weixin.SDK.Apis.User.Dtos
{
    /// <summary>
    /// https://developers.weixin.qq.com/doc/offiaccount/User_Management/Get_users_basic_information_UnionID.html#UinonId
    /// </summary>
    public class UserInfoApiResult : ApiResultBase
    {
        [JsonProperty("subscribe")]
        public int Subscribe { get; set; }

        [JsonProperty("openid")]
        public string OpenId { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("subscribe_time")]
        public int SubscribeTime { get; set; }

        [JsonProperty("unionid")]
        public string UnionId { get; set; }

        [JsonProperty("remark")]
        public string Remark { get; set; }

        [JsonProperty("groupid")]
        public int GroupId { get; set; }

        [JsonProperty("tagid_list")]
        public int[] TagIdList { get; set; }

        [JsonProperty("subscribe_scene")]
        public string SubscribeScene { get; set; }

        [JsonProperty("qr_scene")]
        public int QrScene { get; set; }

        [JsonProperty("qr_scene_str")]
        public string QrSceneStr { get; set; }
    }
}