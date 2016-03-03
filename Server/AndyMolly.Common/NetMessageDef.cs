using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndyMolly.Common
{
   public class NetMessageDef
    {
       /// <summary>
       /// 创建账号请求
       /// </summary>
       public const uint RequestCreateAccount = 101;
       /// <summary>
       /// 登录请求
       /// </summary>
       public const uint RequestLogin = 102;

       /// <summary>
       /// 创建角色请求
       /// </summary>
       public const uint RequestCreateRole = 1001;
       /// <summary>
       /// 角色基本信息请求
       /// </summary>
       public const uint RequestGetRole = 1002;
       /// <summary>
       /// 返回角色信息
       /// </summary>
       public const uint ResponseGetRole = 1003;

       /// <summary>
       /// 响应结果
       /// </summary>
       public const uint ResponseReturnDefaultInfo = 6001;

       /// <summary>
       /// 请求好友列表
       /// </summary>
       public const uint RequestGetFriendList = 201;

       /// <summary>
       /// 返回好友列表
       /// </summary>
       public const uint ResponseFriendList = 202;
    }
}
