# templatePluginForMNC
MNC的插件模板
=

写在前面：
-
本来想法是希望和我一样的小白可以用，体验机器人的小小快乐，但写到最后，发现C#上手还是有些难度。没办法，我就这个能力了，有机会或者时间再写易语言吧。<br>
最基本的一些功能，初始版，毕竟非专业人员ԅ(¯﹃¯ԅ)（版本号我都简化成数字了）<br>
`有很多信息参考了OnebotV11文档，在此说明:https://github.com/botuniverse/onebot-11/`
* Plugin文件夹内是模板插件，复制这个文件夹改名即可
* Temp文件夹内是缓存文件，即编译的dll，如果你了解的话，编译失败，你可以查看里面检查错误
* Helper文件夹存放api的一些说明
* Interface文件夹存放接口的原始CS文件，内有注释
* Lib文件夹存放需要的一些dll，更新版本主要就是更新这个文件夹的东西以及MondayCoreForPluginDebug.exe，直接覆盖就好
* MondayCoreForPluginDebug.exe供简单调试所用，现功能简单，主要是编译cs文件，加载，模拟信息输入和返回

食用方法：
-
* 点击右边Release，选择最新的版本Zip文件（比如：mncp-V1.zip）并下载<br>
  * 一般大版本更新，如v1,v2,v3，前后不兼容；如果有小修改，不会有明显影响的，会予v2.0.2这样
* 解压到合适的文件夹<br>
* 打开：`Plugin`文件夹<br>
* 复制`模板插件`文件夹，并改名为你的`插件名称`<br>
* 打开`MondayPlugin.cs`文件<br>
* 编写你的代码<br>
* 运行`MondayCoreForPluginDebug.exe`<br>
* 按提示操作<br>
* 确认没有问题后将`插件名称`这个文件夹压缩发给我就行<br>

提示：
-
* 需要安装.net,[传送门](https://dotnet.microsoft.com/zh-cn/download)<br>
建议使用自己喜欢的编辑器<br>
* 比如VS code,[传送门](https://code.visualstudio.com/download)--->`最好选择System版本而不是User`<br>
  * VS code提示:
    * 安装后选择左边的扩展，搜索`Chinese`安装一个汉化包
    * 安装一些合适的C#扩展
    * 扩展尽量选择下载人数多的[](url)
* 如果访问Git困难，可以尝试：[开发者快车](https://github.com/docmirror/dev-sidecar)
