using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AndyMolly.Web.Logic
{
   public class Logic201
    {
       public byte[] Init(Stream inputSteam, string httpMethod, uint user_id)
       {

           byte[] bytes = new byte[inputSteam.Length];
           inputSteam.Read(bytes, 0, bytes.Length);
           // 设置当前流的位置为流的开始
           inputSteam.Seek(0, SeekOrigin.Begin);

           //object obj = SerializationHelper.Deserialize(NetMessageDef.ReqGetFriendList, bytes);

           //protos.friend.ReqGetFriendList reqCreateAccount = obj as protos.friend.ReqGetFriendList;





           return null;
       }
    }
}
