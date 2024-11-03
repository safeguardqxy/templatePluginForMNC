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
        /// </summary>
        /// <remarks>
        /// 返回null表示不处理，交由下一个处理器继续处理
        /// 返回其他值（包括空）会拦截信息处理
        /// </remarks>
        /// <param name="qq"></param>
        /// <param name="group"></param>
        /// <param name="order"></param>
        /// <param name="rawMsg"></param>
        /// <param name="paras"></param>
        /// <returns></returns>
        Task<string?> ReceiveMsgHandler(long qq, long group, string order, string rawMsg, List<string> paras);

        /// <summary>
        /// 收到的群事件处理
        /// </summary>
        /// <remarks></remarks>
        /// <param name="qq">来源ID</param>
        /// <param name="group">来源群</param>
        /// <param name="eventName">事件名称</param>
        /// <param name="rawMsg">可能有的原始数据</param>
        /// <returns></returns>
        Task<string?> GroupEventHandler(long qq, long group, string eventName, string rawMsg);

        /// <summary>
        /// 插件要求类
        /// </summary>
        /// <remarks>尽可能少，特别是尽可能少的权限和.NET包依赖</remarks>
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
            /// 是否需要监听群聊信息
            /// </summary>
            public bool ListenGroupMsg { get; set; } = true;

            /// <summary>
            /// 是否需要监听私聊信息
            /// </summary>
            public bool ListenPrivateMsg { get; set; } = false;

            /// <summary>
            /// 是否需要监听群聊信息
            /// </summary>
            public bool ListenGroupEvent { get; set; } = false;

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
            /// (尽可能不要直接使用SendMsg发送信息,在处理器中返回你想发送的信息,多个信息可以使用信息分隔符)
            /// </summary>
            /// <remarks>
            /// 请参考文档,基本和OnebotV11相同,但api命名均为驼峰法,参数命名为下划线法
            /// 建议重载这个方法以便你自己使用
            /// </remarks>
            /// <param name="type">api类型
            /// 参考ApiType，请转换为int;
            /// 如:(int)ApiType.Action</param>
            /// <param name="name">api名称
            /// 参考ActionType,RequestType;
            /// 如:Enum.GetName(ActionType.DeleteMsg)</param>
            /// <param name="paras">api参数</param>
            /// <returns>结果json值或信息ID</returns>
            public Task<string> Execute(int type, string name, Dictionary<string, string> paras);

            /// <summary>
            /// 请求数据
            /// </summary>
            /// <remarks>相当于Execute的参数为(int)ApiType.Request，并且赋值user_id和group_id</remarks>
            /// <param name="name">同Execute</param>
            /// <param name="id">赋值user_id</param>
            /// <param name="group">赋值group_id</param>
            /// <param name="paras">同Execute</param>
            /// <returns></returns>
            public Task<string> RequsetData(string name, long id, long group, Dictionary<string, string> paras);

            /// <summary>
            /// 执行操作
            /// (尽可能不要直接使用SendMsg发送信息,在处理器中返回你想发送的信息,多个信息可以使用信息分隔符)
            /// </summary>
            /// <remarks>相当于Execute的参数为(int)ApiType.Action，并且赋值user_id和group_id</remarks>
            /// <param name="name">同Execute</param>
            /// <param name="id">赋值user_id</param>
            /// <param name="group">赋值group_id</param>
            /// <param name="paras">同Execute</param>
            public Task<string> ExecuteAction(string name, long id, long group, Dictionary<string, string> paras);

            /// <summary>
            /// 获取用户昵称
            /// </summary>
            /// <param name="id">用户ID</param>
            /// <param name="group">群聊ID,0则为用户昵称,传入则为对应群聊群名片</param>
            /// <returns></returns>
            public Task<string> GetUserName(long id, long group = 0);

            /// <summary>
            /// 获取用户身份标识,含系统身份SysAdmin,BotAdmin等
            /// </summary>
            /// <param name="id">用户ID</param>
            /// <param name="group">群聊ID</param>
            /// <returns></returns>
            public Task<List<string>> GetUserMarks(long id, long group);

            /// <summary>
            /// 执行禁言
            /// </summary>
            /// <remarks>单位为秒,请不要太大,至多30天,0表示取消禁言</remarks>
            /// <param name="id">被禁言的用户</param>
            /// <param name="groupid">所在群聊</param>
            /// <param name="time">时长,秒,请不要太大,至多30天,0表示取消禁言</param>
            /// <returns></returns>
            public Task ShutUp(long id, long groupid, long time = 0);

            //--------------------以下为预留枚举,【部分暂未实装】----------------------
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
            /// <remarks>
            /// 格式:[MNC|Text|ContentType|参数名=参数值,参数名=参数值]
            /// 如:[MNC|Text|ImgMsg|file=https://www.baidu.com/img/PCfb_5bf082d29588c07f842ccde3f97243ea.png]
            /// MNC码功能更强,支持嵌套、扩展等，也会不断扩展功能，信息参数参考CQ码
            /// ----->支持CQ码，不需要什么扩展的，直接使用CQ码
            /// </remarks>
            public enum ContentType
            {
                UnknownMsg,
                /// <summary>
                /// 信息分隔符
                /// </summary>
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
                /// <summary>
                /// 禁用
                /// </summary>
                XmlMsg,
                /// <summary>
                /// 禁用
                /// </summary>
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
