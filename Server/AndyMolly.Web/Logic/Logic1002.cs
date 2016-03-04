using AndyMolly.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AndyMolly.Web.Logic
{
    /// <summary>
    /// 获取角色信息
    /// </summary>
   public class Logic1002
    {
       public byte[] Init(Stream inputStream, string httpMethod, uint user_id)
       {
           Model.Users userModel = new BLL.Users().GetModel(user_id);

           protos.Login.ResponseGetRole responeMessageGetRole = new protos.Login.ResponseGetRole();
           if (userModel != null)
           {
               responeMessageGetRole.uid = userModel.ID.ToString();
               responeMessageGetRole.gold = userModel.Gold;
               responeMessageGetRole.endurance = userModel.Endurance;
               responeMessageGetRole.head = 0;// userModel.Head;
               responeMessageGetRole.lv = userModel.Lv;
               responeMessageGetRole.user_name = userModel.UserName;
               responeMessageGetRole.vip = userModel.Vip;
               responeMessageGetRole.wing = userModel.Wing;
           }

           return SerializationHelper.Serialize(new MuffinMsg(NetMessageDef.ResponseGetRole, responeMessageGetRole));
       }
    }
}
