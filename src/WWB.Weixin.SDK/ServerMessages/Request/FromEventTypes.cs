﻿namespace WWB.Weixin.SDK.ServerMessages.Request
{
    using System.Xml.Serialization;

    /// <summary>
    ///     事件类型
    /// </summary>
    public enum FromEventTypes
    {
        /// <summary>
        ///     关注
        /// </summary>
        [XmlEnum(Name = "subscribe")]
        subscribe = 0,

        /// <summary>
        ///     取消关注
        /// </summary>
        [XmlEnum(Name = "unsubscribe")]
        unsubscribe = 1,

        /// <summary>
        ///     扫描带参数二维码
        /// </summary>
        [XmlEnum(Name = "scan")]
        scan = 2,

        /// <summary>
        ///     上报地理位置
        /// </summary>
        [XmlEnum(Name = "location")]
        location = 3,

        /// <summary>
        ///     点击菜单拉取消息时的事件推送
        /// </summary>
        [XmlEnum(Name = "click")]
        click = 4,

        /// <summary>
        ///     点击菜单跳转链接时的事件推送
        /// </summary>
        [XmlEnum(Name = "view")]
        view = 5,

        /// <summary>
        /// 模板消息发送完成
        /// </summary>
        [XmlEnum(Name = "templatesendjobfinish")]
        templatesendjobfinish = 6,

        /// <summary>
        ///     点击菜单跳转小程序的事件推送
        /// </summary>
        [XmlEnum(Name = "view_miniprogram")]
        view_miniprogram = 7
    }
}