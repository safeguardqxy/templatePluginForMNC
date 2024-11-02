namespace MondayPluginLib
{
    public interface IMondayPlugin : IDisposable
    {
        /// <summary>
        /// 插件名称
        /// </summary>
        string Name { get; }

        /// <summary>
        /// 插件Url
        /// </summary>
        string Url { get; }

        /// <summary>
        /// 插件作者列表
        /// </summary>
        Dictionary<string, string> Authors { get; }

        /// <summary>
        /// 插件描述
        /// </summary>
        string Description { get; }

        /// <summary>
        /// 插件类型
        /// </summary>
        string PluginType { get; }

        /// <summary>
        /// 插件标签
        /// </summary>
        List<string> Tags { get; }

        /// <summary>
        /// 插件版本
        /// </summary>
        string Version { get; }

        /// <summary>
        /// 插件配置版本
        /// </summary>
        string ManifestVersion { get; }

        /// <summary>
        /// 插件的优先等级.
        /// </summary>
        int Priority { get; }

        /// <summary>
        /// 插件需求
        /// </summary>
        PluginRequirement Requirement { get; }

        /// <summary>
        /// 触发的关键词，即信息中开头关键词+空格+其他，则程序会转交给插件执行
        /// </summary>
        List<string> Keys { get; }

        /// <summary>
        /// 初始化插件
        /// 请不要在其他地方初始化任何代码
        /// 程序将提供API参数
        /// </summary>
        /// <returns>异步任务</returns>
        Task InitializeAsync(IMondayCoreApi mondayCoreApi);

        /// <summary>
        /// 接受信息后回复
        /// 返回null表示不处理，交由下一个处理器继续处理
        /// 返回其他值（包括空）会拦截信息处理
        /// </summary>
        /// <param name="qq"></param>
        /// <param name="group"></param>
        /// <param name="order"></param>
        /// <param name="rawMsg"></param>
        /// <param name="paras"></param>
        /// <returns></returns>
        string? ReceiveMsgHandler(long qq, long group, string order, string rawMsg, List<string> paras);

        /// <summary>
        /// 插件要求类
        /// 尽可能少，特别是尽可能少的权限和.NET包依赖
        /// </summary>
        public class PluginRequirement
        {
            /// <summary>
            /// API版本
            /// </summary>
            public int ApiVersion { get; set; } = 1;

            /// <summary>
            /// 接口版本
            /// </summary>
            public int InterfaceVersion { get; set; } = 1;

            /// <summary>
            /// 运行平台
            /// </summary>
            public List<string> Platform { get; set; } = ["win", "linux", "mac"];

            /// <summary>
            /// 请求的权限列表
            /// IO,Network
            /// </summary>
            public List<string> PluginRight { get; set; } = [];

            /// <summary>
            /// 插件依赖列表
            /// </summary>
            public List<string> PluginDependencies { get; set; } = [];

            /// <summary>
            /// .Net包依赖
            /// </summary>
            public List<string> DotnetDependencies { get; set; } = ["Newtonsoft.Json"];
        }

        /// <summary>
        /// 暴露的接口API
        /// 版本1
        /// </summary>
        public interface IMondayCoreApi
        {
            /// <summary>
            /// 提供的API实际版本
            /// </summary>
            public int Version { get; }

            /// <summary>
            /// 在控制台显示信息(会自动在结尾加入换行符)
            /// </summary>
            /// <param name="msg">想显示的信息</param>
            public void PrintMsg(string msg);

            /// <summary>
            /// 调用Api获取结果
            /// </summary>
            /// <param name="type">api类型</param>
            /// <param name="name">api名称</param>
            /// <param name="paras">api参数</param>
            /// <returns>结果json值</returns>
            public string ExecuteApi(int type, string name, Dictionary<string, string> paras);

            /// <summary>
            /// 获取用户昵称
            /// </summary>
            /// <param name="id"></param>
            /// <returns></returns>
            public string GetUserName(long id, long group);

            //--------------------以下为预留枚举，【暂未实装】----------------------
            #region 各类枚举
            /// <summary>
            /// API类型
            /// </summary>
            public enum ApiType
            {
                /// <summary>
                /// 信息，如群聊信息、私聊信息
                /// </summary>
                Message,
                /// <summary>
                /// 事件，如成员增加、发表公告
                /// </summary>
                Event,
                /// <summary>
                /// 指令，如执行禁言、执行发布公告
                /// </summary>
                Action,
                /// <summary>
                /// 请求，如获取成员信息，获取群聊信息
                /// </summary>
                Request
            }

            /// <summary>
            /// 信息类型枚举
            /// </summary>
            public enum ContentType
            {
                UnknownMsg,
                ChainSeparator,
                TextMsg,
                ImgMsg,
                FaceMsg,
                MfaceMsg,
                RecordMsg,
                VideoMsg,
                AtMsg,
                FaceRpsMsg,
                FaceDiceMsg,
                ShakeMsg,
                ShareMsg,
                LocationMsg,
                MusicMsg,
                ReplyMsg,
                XmlMsg,
                JsonMsg,
                EmptyMsg,
                OtherMsg,
            }

            /// <summary>
            /// 事件类型枚举
            /// </summary>
            public enum EventType
            {
                Unknown,
                /// <summary>
                /// 服务器事件
                /// </summary>
                Serveice,
                /// <summary>
                /// 群文件上传
                /// </summary>
                Notice_Group_upload,
                /// <summary>
                /// 设置和取消群管理员
                /// </summary>
                Notice_Group_admin,
                /// <summary>
                /// 成员减少
                /// </summary>
                Notice_Group_decrease,
                /// <summary>
                /// 成员增加
                /// </summary>
                Notice_Group_increase,
                /// <summary>
                /// 群员禁言或解禁
                /// </summary>
                Notice_Group_ban,
                /// <summary>
                /// 增加好友
                /// </summary>
                Notice_Friend_add,
                /// <summary>
                /// 群聊信息撤回
                /// </summary>
                Notice_Group_recall,
                /// <summary>
                /// 私聊信息撤回
                /// </summary>
                Notice_Friend_recall,
                /// <summary>
                /// 弃用
                /// </summary>
                Notice_Notify,
                /// <summary>
                /// 请求加我好友
                /// </summary>
                Request_Friend,
                /// <summary>
                /// 请求加入群聊
                /// </summary>
                Request_Group,
            }

            /// <summary>
            /// 指令类型枚举
            /// </summary>
            public enum ActionType
            {
                /// <summary>
                /// 自定义
                /// </summary>
                Custom,
                /// <summary>
                /// 发送信息
                /// </summary>
                SendMsg,
                /// <summary>
                /// 撤回信息
                /// </summary>
                DeleteMsg,
                /// <summary>
                /// 点赞
                /// </summary>
                SendLike,
                /// <summary>
                /// 群聊请离
                /// </summary>
                SetGroupKick,
                /// <summary>
                /// 群聊禁言
                /// </summary>
                SetGroupBan,
                /// <summary>
                /// 群聊全体禁言
                /// </summary>
                SetGroupWholeBan,
                /// <summary>
                /// 设置或取消群管理员
                /// </summary>
                SetGroupAdmin,
                /// <summary>
                /// 设置或取消群名片
                /// </summary>
                SetGroupCard,
                /// <summary>
                /// 设置群名称
                /// </summary>
                SetGroupName,
                /// <summary>
                /// 离开群聊
                /// </summary>
                SetGroupLeave,
                /// <summary>
                /// 设置群头衔
                /// </summary>
                SetGroupSpecialTitle,
                /// <summary>
                /// 设置好友请求结果
                /// </summary>
                SetFriendAddRequest,
                /// <summary>
                /// 设置群聊加入结果
                /// </summary>
                SetGroupAddRequest,
                /// <summary>
                /// 群聊签到
                /// </summary>
                SetGroupSign,
            }

            /// <summary>
            /// 请求类型枚举
            /// </summary>
            public enum RequestType
            {
                /// <summary>
                /// 获取信息
                /// </summary>
                GetMsg,
                /// <summary>
                /// 获取登陆信息
                /// </summary>
                GetLoginInfo,
                /// <summary>
                /// 获取陌生人信息
                /// </summary>
                GetStrangerInfo,
                /// <summary>
                /// 获取好友列表
                /// </summary>
                GetFriendList,
                /// <summary>
                /// 获取群聊信息
                /// </summary>
                GetGroupInfo,
                /// <summary>
                /// 获取群聊列表
                /// </summary>
                GetGroupList,
                /// <summary>
                /// 获取群成员信息
                /// </summary>
                GetGroupMemberInfo,
                /// <summary>
                /// 获取群成员列表
                /// </summary>
                GetGroupMemberList,
            }
            #endregion
        }
    }
}
