using AndyMolly.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AndyMolly.Web.Logic
{
   public class Logic102
    {
       public byte[] Init(Stream inputStream, string httpMethod, uint user_id)
       {
           byte[] bytes = new byte[inputStream.Length];
           inputStream.Read(bytes, 0, bytes.Length);

           //设置当前流的位置为流的开始
           inputStream.Seek(0, SeekOrigin.Begin);

           object obj = SerializationHelper.Deserialize(NetMessageDef.RequestLogin, bytes);

           protos.Login.RequestLogin requestLogin = new protos.Login.RequestLogin();

           protos.ReturnMessage.ResDefaultInfo resInfo = new protos.ReturnMessage.ResDefaultInfo();

           if (string.IsNullOrEmpty(requestLogin.account))
           {
               resInfo.results = 0;
               resInfo.details = "账号不能为空";
           }
           else if (string.IsNullOrEmpty(requestLogin.password))
           {
               resInfo.results = 0;
               resInfo.details = "密码不能为空";
           }

           Model.Users userModle = new BLL.Users().GetModel(requestLogin.account,requestLogin.password);
           if (userModle != null)
           {
               resInfo.results = 1;
               resInfo.details = userModle.ID.ToString();
           }
           else
           {
               resInfo.results = 0;
               resInfo.details = "账号或密码错误";
           }

           return SerializationHelper.Serialize(new MuffinMsg(NetMessageDef.ResponseReturnDefaultInfo, resInfo));
       }
    }
}
