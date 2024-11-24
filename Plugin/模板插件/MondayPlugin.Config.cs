using MondayPluginLib;

namespace PluginForMonday
{
    public partial class MondayPlugin
    {
        //-------------------------下面是你的插件的基本信息，根据实际情况填写-------------------------
        /// <summary>
        /// 插件标识的名称
        /// </summary>
        /// <remarks>建议使用作者名称缩写-插件名称，避免与其他人插件同名导致无法加载</remarks>
        public string Name => "作者名称缩写 - 插件名称";//比如:QXY-templatePluginForMNC

        /// <summary>
        /// 插件主页
        /// </summary>
        /// <remarks>【没有就不用填】</remarks>
        public string Url => "";//比如:"https://github.com/safeguardqxy/templatePluginForMNC/";

        /// <summary>
        /// 作者列表
        /// </summary>
        public Dictionary<string, string> Authors => new() {
            //比如:{ "safeguardqxy","https://github.com/safeguardqxy/"},
            { "作者1名称","作者1主页Url"},
            { "作者2名称","作者2主页Url"},
            { "以此类推","不需要这么多就按行删"},
        };

        /// <summary>
        /// 插件介绍
        /// </summary>
        /// <remarks>方便大家知道你的作用</remarks>
        public string Description => "插件介绍";//比如:这是一个模板插件，只作为简单的示例

        /// <summary>
        /// 插件类型
        /// </summary>
        /// <remarks>这个暂时不需要改</remarks>
        public string PluginType => "default";

        /// <summary>
        /// 插件标签
        /// </summary>
        /// <remarks>指出你的插件主要特点或功能</remarks>
        public List<string> Tags => ["插件标签"];//比如:["模板","简单回复","复读功能"]

        /// <summary>
        /// 插件版本
        /// </summary>
        /// <remarks>这是你的插件版本号，用于标识你的版本，建议如果你的插件大版本更新了，就+1，如2.0.0</remarks>
        public string Version => "1.0.0";

        /// <summary>
        /// Manifest版本
        /// </summary>
        /// <remarks>预留</remarks>
        public string ManifestVersion => "1.0.0";

        /// <summary>
        /// 插件优先级
        /// </summary>
        /// <remarks>如果你有前置的插件，优先级低于它就行</remarks>
        public int Priority => 0;

        /// <summary>
        /// 触发回复的关键词
        /// </summary>
        /// <remarks>相当于order，order触发了就会交给你处理，不区分大小写</remarks>
        public List<string> Keys => ["你好", "hi", "复读"];

        /// <summary>
        /// 插件运行要求
        /// 包括前置和依赖等
        /// </summary>
        /// <remarks>如果api或者接口更新了，就改对应的版本号</remarks>
        public IMondayPlugin.PluginRequirement Requirement => new()
        {
            //最低接口版本
            InterfaceVersion = 2,
            //最低api版本
            ApiVersion = 2,
            //监听群聊信息
            ListenGroupMsg = true,
            //监听私聊信息
            ListenPrivateMsg = false,
            //监听群聊事件
            ListenGroupEvent = false,
            //其他的参考接口文档
        };
    }
}
