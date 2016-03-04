using AndyMolly.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AndyMolly.Web.Logic
{
    /// <summary>
    /// 创建角色
    /// </summary>
   public class Logic1001
    {
       public byte[] Init(Stream inputStream, string httpMethod, string user_id)
       {
           byte[] bytes = new byte[inputStream.Length];
           inputStream.Read(bytes, 0, bytes.Length);

           inputStream.Seek(0, SeekOrigin.Begin);

           object obj = SerializationHelper.Deserialize(NetMessageDef.ResponseGetRole, bytes);

           protos.Login.RequestCreateRole requestCreateRole = obj as protos.Login.RequestCreateRole;

           protos.ReturnMessage.ResDefaultInfo resInfo = new protos.ReturnMessage.ResDefaultInfo();

           if (string.IsNullOrEmpty(requestCreateRole.user_name))
           {
               resInfo.results = 0;
               resInfo.details = "昵称不能为空";
           }

           Model.Users mUser = new BLL.Users().GetModel(user_id);

           if (mUser != null)
           {
               mUser.UserName = requestCreateRole.user_name;
               resInfo.results = 2;
               resInfo.details = "创建角色成功";
           }
           else
           {
               resInfo.results = 0;
               resInfo.details = "账号不存在";
           }

           return SerializationHelper.Serialize(new MuffinMsg(NetMessageDef.ResponseReturnDefaultInfo, resInfo));
       }
    }
}
