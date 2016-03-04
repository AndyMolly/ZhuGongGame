using AndyMolly.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AndyMolly.Web.Logic
{
   public class Logic101
    {
       public byte[] Init(Stream inputStream, string httpMethod, uint user_id)
       {
           byte[] bytes = new byte[inputStream.Length];

           inputStream.Read(bytes, 0, bytes.Length);
           //设置当前流的位置为流的开始
           inputStream.Seek(0, SeekOrigin.Begin);

           object obj = SerializationHelper.Deserialize(NetMessageDef.RequestCreateAccount, bytes);
           protos.Login.RequestCreateAccount requestCreateAccount = obj as protos.Login.RequestCreateAccount;

           protos.ReturnMessage.ResDefaultInfo resInfo = new protos.ReturnMessage.ResDefaultInfo();

           if (string.IsNullOrEmpty(requestCreateAccount.account))
           {
               resInfo.results = 0;
               resInfo.details = "账号不能为空";
           }
           else if (string.IsNullOrEmpty(requestCreateAccount.password))
           {
               resInfo.results = 0;
               resInfo.details = "密码不能为空";
           }

           if (new BLL.Users().ExistsAcc(requestCreateAccount.account))
           {
               resInfo.results = 0;
               resInfo.details = "账号已存在";
           }
           else
           {
               Model.Users newUser = new Model.Users();
               newUser.UserAccount = requestCreateAccount.account;
               newUser.UserPassworld = requestCreateAccount.password;
               newUser.RegTime = DateTime.Now;
               newUser.LoginTime = DateTime.Now;
               newUser.Endurance = 100;
               newUser.Exp = 0;
               newUser.Gold = 1000;
               newUser.Head = "";
               newUser.Lv = 1;
               newUser.UserName = "";
               newUser.Vip = 0;
               newUser.Wing = 0;


               if (new BLL.Users().Add(newUser) > 0)
               {
                   resInfo.results = 2;
                   resInfo.details = "注册成功";
               }
               else
               {
                   resInfo.results = 0;
                   resInfo.details = "注册失败";
               }
           }

           return SerializationHelper.Serialize(new MuffinMsg(NetMessageDef.ResponseReturnDefaultInfo, resInfo));
       }
    }
}
