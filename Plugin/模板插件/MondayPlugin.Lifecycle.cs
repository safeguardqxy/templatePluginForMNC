using MondayPluginLib;

namespace PluginForMonday
{
    public partial class MondayPlugin
    {
        /// <summary>
        /// 初始化
        /// </summary>
        /// <remarks>加载插件时首先调用</remarks>
        /// <param name="mondayCoreApi">主程序在初始化时给予</param>
        /// <returns></returns>
        public Task InitializeAsync(IMondayCoreApi mondayCoreApi)
        {
            coreApi = mondayCoreApi;
            coreApi.PrintMsg($"{Name}初始化完成");
            coreApi.PrintMsg($"Api版本:{coreApi.Version};插件版本:{Version}");
            coreApi.PrintMsg($"监听私聊：{Requirement.ListenPrivateMsg}；监听群信息：{Requirement.ListenGroupMsg}；监听群事件{Requirement.ListenGroupEvent}");
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
    }
}
