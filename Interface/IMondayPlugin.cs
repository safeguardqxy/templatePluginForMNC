namespace MondayPluginLib
{
    /// <summary>
    /// MondayCore插件接口
    /// 版本2
    /// 请尽量使用最新版本接口
    /// </summary>
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
        /// 返回null表示不处理、忽略，交由下一个处理器继续处理
        /// 返回其他值（包括空）会拦截信息处理
        /// </remarks>
        /// <param name="botid">botID号</param>
        /// <param name="id">来源ID</param>
        /// <param name="group">来源群ID</param>
        /// <param name="order">主命令文本，如：复读 啦啦啦，order="复读"，paras=["啦啦啦"]</param>
        /// <param name="rawMsg">原始信息（CQ码）</param>
        /// <param name="rawJsonMsg">解析的原始json信息，预留</param>
        /// <param name="paras">命令参数，如：复读 啦啦啦，order="复读"，paras=["啦啦啦"]</param>
        /// <param name="ats">信息内容中At的id号列表，是字符串</param>
        /// <returns>你要回复的信息（支持CQ码）或返回Null表示忽略</returns>
        Task<string?> ReceiveMsgHandler(long botid, long id, long group, string order, string rawMsg, string rawJsonMsg, List<string> paras, List<string> ats);

        /// <summary>
        /// 收到的群事件处理
        /// </summary>
        /// <remarks></remarks>
        /// <param name="id">主动方ID</param>
        /// <param name="toid">被动方ID</param>
        /// <param name="group">来源群</param>
        /// <param name="eventName">事件名称</param>
        /// <param name="rawJsonMsg">可能有的原始json数据</param>
        /// <returns>你要回复给被动方的信息（支持CQ码）或返回Null表示忽略</returns>
        Task<string?> GroupEventHandler(long id, long toid, long group, string eventName, string rawJsonMsg);

        /// <summary>
        /// 插件要求类
        /// </summary>
        /// <remarks>尽可能少，特别是尽可能少的权限和.NET包依赖</remarks>
        public class PluginRequirement
        {
            /// <summary>
            /// API版本
            /// </summary>
            public int ApiVersion { get; set; } = 2;

            /// <summary>
            /// 接口版本
            /// </summary>
            public int InterfaceVersion { get; set; } = 2;

            /// <summary>
            /// .Net版本
            /// </summary>
            public string NetVersion { get; set; } = "8.0";

            /// <summary>
            /// 是否需要监听群聊信息
            /// </summary>
            public bool ListenGroupMsg { get; set; } = true;

            /// <summary>
            /// 是否需要监听私聊信息
            /// </summary>
            public bool ListenPrivateMsg { get; set; } = false;

            /// <summary>
            /// 是否需要监听群聊事件
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
    }
}
