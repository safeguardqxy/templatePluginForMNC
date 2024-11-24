namespace PluginForMonday
{
    public partial class MondayPlugin
    {
        /// <summary>
        /// 收到信息后调用
        /// </summary>
        /// <remarks>
        /// 比如：复读 你好，order="复读"，rawMsg="复读 你好"，paras=["你好"]，我会将这些信息作为参数传递给这个函数，将结果作为机器人的回复
        /// !建议自己解析rawMsg，这样最可靠!
        /// </remarks>
        /// <param name="botid">机器人ID</param>
        /// <param name="id">发送方ID</param>
        /// <param name="group">发送方群聊账号，私聊则为0</param>
        /// <param name="order">去除参数后的命令主文本</param>
        /// <param name="rawMsg">原始文本(CQ码)
        /// </param>
        /// <param name="rawJsonMsg">解析的json信息，预留</param>
        /// <param name="paras">简单解析得到的参数列表</param>
        /// <param name="ats">信息内容中At的ID号列表，是字符串</param>
        /// <returns>你要回复的信息（支持CQ码）或返回Null表示忽略</returns>
        /// <returns></returns>
        public async Task<string?> ReceiveMsgHandler(long botid, long id, long group, string order, string rawMsg, string rawJsonMsg, List<string> paras, List<string> ats)
        {
            await Task.CompletedTask;//如果你不需要异步的话【看不懂就不动它】

            //在控制台显示信息，请不要直接使用Console!!!
            //coreApi?.PrintMsg($"你想显示的东西")

            //举例，这里显示一下收到的信息情况
            coreApi?.PrintMsg($">>>收到群{group}成员{id}的信息:{rawMsg}");


            //返回你想回复的信息
            //【使用你喜欢的格式，做你想做的事情】<---------------------------------------<<<<<<<<<<<<<<<<<<
            //return "你好啊"
            //那么机器人就好回复“你好啊”
            //记得在下面的插件基本信息Keys里面加入关键词哦！

            //举例：这是根据发来的信息进行回复
            return order switch
            {
                "你好" => $"你好啊{coreApi?.GetUserName(id, group)}",
                "hi" => "Hi, my friend",
                "复读" => string.Join(" ", paras),
                _ => null,//返回null表示交给其他插件处理，返回其他值则拦截
            };
        }
    }
}
