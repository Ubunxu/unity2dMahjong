using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class Protocol
{
    public const int 错误指令 = 120;
    public const int 登录指令 = 1001;
    public const int 创建房间指令 = 8000;
    public const int 加入房间指令 = 8001;
    public const int 加入房间成功 = 7901;
    public const int 房间内所有信息发送给某个玩家 = 7000;
    public const int 把某个玩家的消息发送房间其他所有人 = 7001;
    public const int 玩家退出房间 = 7999;
    public const int 准备或取消指令 = 8006;
    public const int 游戏开始指令 = 8110;
    public const int 发牌指令 = 8112;
}

