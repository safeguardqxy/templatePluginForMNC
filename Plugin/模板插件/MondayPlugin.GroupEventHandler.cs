namespace PluginForMonday
{
    public partial class MondayPlugin
    {
        /// <summary>
        /// 发生群聊事件时调用
        /// 真的需要的话记得打开监听开关
        /// </summary>
        /// <param name="id">来源用户ID</param>
        /// <param name="toid">被动方用户ID</param>
        /// <param name="group">来源群聊ID</param>
        /// <param name="eventName">事件名称,参考接口文档</param>
        /// <param name="rawMsg">可能有的原始数据</param>
        /// <returns>你要回复给被动方的信息（支持CQ码）或返回Null表示忽略</returns>
        public async Task<string?> GroupEventHandler(long id, long toid, long group, string eventName, string rawMsg)
        {
            await Task.CompletedTask;
            //coreApi?.PrintMsg($">>>收到群{group}成员{id}的事件:{eventName}\r\n原始信息:{rawMsg}");
            return null;
        }
    }
}
