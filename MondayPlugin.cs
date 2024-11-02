using MondayPluginLib;

namespace PluginForMonday
{
    public class MondayPlugin : IMondayPlugin
    {
        //------------------------------->在这里发挥你的想法！！！！！<-----------------------------------
        #region 发挥想法的区域
        /// <summary>
        /// 收到信息后调用
        /// </summary>
        /// <remarks>
        /// 比如：复读 你好，order="复读"，rawMsg="复读 你好"，paras=["你好"]，只是简单解析，可以自己处理
        /// </remarks>
        /// <param name="qq">发送方QQ号</param>
        /// <param name="group">发送方群聊账号，私聊则为0</param>
        /// <param name="order">去除参数后的命令主文本</param>
        /// <param name="rawMsg">原始文本（如果含有表情、图片、位置、音乐卡等非纯文本信息，将尽可能转换为可视的文本）
        /// 比如：[ReplyMsg|id:2072803349;][AtMsg|qq:2787592125;][ImgMsg|file:F07FEA9B54082D2F85E2CEA83E659AA1.jpg;url:...;]
        /// </param>
        /// <param name="paras">简单解析得到的参数列表</param>
        /// <returns></returns>
        public string? ReceiveMsgHandler(long qq, long group, string order, string rawMsg, List<string> paras)
        {
            //在控制台显示信息，请不要直接使用Console!!!
            //coreApi?.PrintMsg($"你想显示的东西")
            coreApi?.PrintMsg($">>>收到群{group}成员{qq}的信息:{rawMsg}");

            //返回你想回复的信息
            //【使用你喜欢的格式，做你想做的事情】<---------------------------------------<<<<<<<<<<<<<<<<<<
            //return "你好啊"
            //那么机器人就好回复“你好啊”
            //记得在下面的插件基本信息Keys里面加入关键词哦！

            //举例：这是根据发来的信息进行回复
            return order switch
            {
                "你好" => $"你好啊{coreApi?.GetUserName(qq, group)}",
                "hi" => "Hi, my friend",
                "复读" => string.Join(" ", paras),
                _ => null,//返回null表示交给其他插件处理，返回其他值则拦截
            };
        }
        #endregion

        //-------------------------下面是你的插件的基本信息，根据实际情况填写-------------------------
        #region 基本信息
        /// <summary>
        /// 插件标识的名称
        /// </summary>
        /// <remarks>建议使用作者名称缩写-插件名称，避免与其他人插件同名导致无法加载</remarks>
        public string Name => "作者名称缩写 - 插件名称";//比如QXY-templatePluginForMNC

        /// <summary>
        /// 插件主页
        /// </summary>
        /// <remarks>【没有就不用填】</remarks>
        public string Url => "https://github.com/safeguardqxy/templatePluginForMNC/";

        /// <summary>
        /// 作者列表
        /// </summary>
        public Dictionary<string, string> Authors => new() {
            { "safeguardqxy","https://github.com/safeguardqxy/"},
            { "作者1名称","作者1主页Url"},
            { "作者2名称","作者2主页Url"},
            { "以此类推","不需要这么多就按行删"},
        };

        /// <summary>
        /// 插件介绍
        /// </summary>
        /// <remarks>方便大家知道你的作用</remarks>
        public string Description => "插件介绍";

        /// <summary>
        /// 插件类型
        /// </summary>
        /// <remarks>这个暂时不需要改</remarks>
        public string PluginType => "simple";

        /// <summary>
        /// 插件标签
        /// </summary>
        /// <remarks>指出你的插件主要特点或功能</remarks>
        public List<string> Tags => ["插件标签"];

        /// <summary>
        /// 插件版本
        /// </summary>
        /// <remarks>如果你的插件大版本更新了，就+1，如2.0.0</remarks>
        public string Version => "1.0.0";

        /// <summary>
        /// Manifest版本
        /// </summary>
        /// <remarks>预留，【不用管】</remarks>
        public string ManifestVersion => "1.0.0";

        /// <summary>
        /// 插件优先级
        /// </summary>
        /// <remarks>如果你有前置的插件，优先级低于它就行，【不需要就不用管】</remarks>
        public int Priority => 0;

        /// <summary>
        /// 触发回复的关键词
        /// </summary>
        public List<string> Keys => ["你好", "hi", "复读"];

        /// <summary>
        /// 插件运行要求
        /// 包括前置和依赖等
        /// </summary>
        /// <remarks>如果api或者接口更新了，就改对应的版本号，【不需要就不用管】</remarks>
        public IMondayPlugin.PluginRequirement Requirement => new()
        {
            //最低接口版本
            InterfaceVersion = 1,
            //最低api版本
            ApiVersion = 1,
        };
        #endregion

        //-------------------------下面的你不清楚就不用管，大多数情况用不上------------------------
        #region 初始化和释放
        /// <summary>
        /// 主程序Api
        /// </summary>
        /// <remarks>用于调用主程序功能</remarks>
        private IMondayPlugin.IMondayCoreApi? coreApi;

        /// <summary>
        /// 初始化
        /// </summary>
        /// <remarks>加载插件时首先调用</remarks>
        /// <param name="mondayCoreApi">主程序在初始化时给予</param>
        /// <returns></returns>
        public Task InitializeAsync(IMondayPlugin.IMondayCoreApi mondayCoreApi)
        {
            coreApi = mondayCoreApi;
            coreApi.PrintMsg($"{Name}初始化完成");
            coreApi.PrintMsg($"Api版本:{coreApi.Version}");
            coreApi.PrintMsg($"插件版本:{Version}");
            coreApi.PrintMsg($"关注的指令:{string.Join(',', Keys)}");

            //初始化代码位置
            //.............
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            //程序卸载插件时会显式调用这个
            //如果你需要释放一些资源或者做什么。。。
            GC.SuppressFinalize(this);
        }
        #endregion

    }
}