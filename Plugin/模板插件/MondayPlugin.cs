using MondayPluginLib;

namespace PluginForMonday
{
    /// <summary>
    /// MondayCore插件CS示例文件
    /// 版本2
    /// </summary>
    public partial class MondayPlugin : IMondayPlugin
    {
        /// <summary>
        /// 主程序Api
        /// </summary>
        /// <remarks>用于调用主程序功能，参考接口文档</remarks>
        private IMondayCoreApi? coreApi;
    }
}