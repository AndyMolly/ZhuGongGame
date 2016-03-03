using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AndyMolly.Common
{
    public class MuffinMsg
    {
        public uint cmdId = 0;
        /// <summary>
        /// ProtocalBuffer的数据类
        /// </summary>
        public object pBObject = null;

        public MuffinMsg(uint cmd, object pb)
        {
            cmdId = cmd;
            pBObject = pb;
        }
    }
   public class SerializationHelper
   {
       #region 序列化proto
       /// <summary>
       /// 序列化成proto
       /// </summary>
       /// <param name="msg"></param>
       /// <returns></returns>
       public static byte[] Serialize(MuffinMsg msg)
       {
           switch (msg.cmdId)
           {
               case NetMessageDef.RequestLogin:
                   {
                       protos.Login.RequestLogin request = msg.pBObject as protos.Login.RequestLogin;
                       MemoryStream memStream = new MemoryStream();
                       ProtoBuf.Serializer.Serialize<protos.Login.RequestLogin>(memStream, request);
                       byte[] x = memStream.ToArray();
                       memStream.Close();
                       return x;
                   }
               case NetMessageDef.RequestCreateAccount:
                   {
                       protos.Login.RequestCreateAccount request = msg.pBObject as protos.Login.RequestCreateAccount;
                       MemoryStream memStream = new MemoryStream();
                       ProtoBuf.Serializer.Serialize<protos.Login.RequestCreateAccount>(memStream, request);
                       byte[] x = memStream.ToArray();
                       memStream.Close();
                       return x;
                   }
               case NetMessageDef.RequestGetRole:
                   {
                       protos.Login.RequestGetRole request = msg.pBObject as protos.Login.RequestGetRole;
                       MemoryStream memStream = new MemoryStream();
                       ProtoBuf.Serializer.Serialize<protos.Login.RequestGetRole>(memStream, request);
                       byte[] x = memStream.ToArray();
                       memStream.Close();
                       return x;
                   }
               case NetMessageDef.ResponseGetRole:
                   {
                       protos.Login.ResponseGetRole request = msg.pBObject as protos.Login.ResponseGetRole;
                       MemoryStream memStream = new MemoryStream();
                       ProtoBuf.Serializer.Serialize<protos.Login.ResponseGetRole>(memStream, request);
                       byte[] x = memStream.ToArray();
                       memStream.Close();
                       return x;
                   }
               case NetMessageDef.ResponseReturnDefaultInfo:
                   {
                       protos.ReturnMessage.ResDefaultInfo request = msg.pBObject as protos.ReturnMessage.ResDefaultInfo;
                       MemoryStream memStream = new MemoryStream();
                       ProtoBuf.Serializer.Serialize<protos.ReturnMessage.ResDefaultInfo>(memStream, request);
                       byte[] x = memStream.ToArray();
                       memStream.Close();
                       return x;
                   }
               case NetMessageDef.RequestGetFriendList:
                   {
                       protos.friend.ReqGetFriendList request = msg.pBObject as protos.friend.ReqGetFriendList;
                       MemoryStream memStream = new MemoryStream();
                       ProtoBuf.Serializer.Serialize<protos.friend.ReqGetFriendList>(memStream, request);
                       byte[] x = memStream.ToArray();
                       memStream.Close();
                       return x;
                   }
               case NetMessageDef.ResponseFriendList:
                   {
                       protos.friend.ResFriendList request = msg.pBObject as protos.friend.ResFriendList;
                       MemoryStream memStream = new MemoryStream();
                       ProtoBuf.Serializer.Serialize<protos.friend.ResFriendList>(memStream, request);
                       byte[] x = memStream.ToArray();
                       memStream.Close();
                       return x;
                   }
               default:
                   {
                       Console.WriteLine("MuffinMsg.Serialize: unhandled cmdId->" + msg.cmdId.ToString());
                       return null;
                   }
           }
       }
       #endregion

       #region 反序列化
       public static object Deserialize(uint cmdId, byte[] bytes)
       {
           switch (cmdId)
           {
               case NetMessageDef.RequestLogin:
                   {
                       return ProtoBuf.Serializer.Deserialize<protos.Login.RequestLogin>(new MemoryStream(bytes));
                   }
               case NetMessageDef.RequestCreateAccount:
                   {
                       return ProtoBuf.Serializer.Deserialize<protos.Login.RequestCreateAccount>(new MemoryStream(bytes));
                   }
               case NetMessageDef.RequestGetRole:
                   {
                       return ProtoBuf.Serializer.Deserialize<protos.Login.RequestGetRole>(new MemoryStream(bytes));
                   }
               case NetMessageDef.ResponseGetRole:
                   {
                       return ProtoBuf.Serializer.Deserialize<protos.Login.ResponseGetRole>(new MemoryStream(bytes));
                   }
               case NetMessageDef.ResponseReturnDefaultInfo:
                   {
                       return ProtoBuf.Serializer.Deserialize<protos.ReturnMessage.ResDefaultInfo>(new MemoryStream(bytes));
                   }
               case NetMessageDef.RequestGetFriendList:
                   {
                       return ProtoBuf.Serializer.Deserialize<protos.friend.ReqGetFriendList>(new MemoryStream(bytes));
                   }
               case NetMessageDef.ResponseFriendList:
                   {
                       return ProtoBuf.Serializer.Deserialize<protos.friend.ResFriendList>(new MemoryStream(bytes));
                   }
               default:
                   {
                       Console.WriteLine("MuffinMsg.Deserialize: unhandled cmdId->" + cmdId.ToString());
                       return null;
                   }
           }
       }
       #endregion


       /// <summary>
       /// 反序列化
       /// </summary>
       /// <param name="type">对象类型</param>
       /// <param name="filename">文件路径</param>
       /// <returns></returns>
       public static object Load(Type type, string filename)
       {
           FileStream fs = null;
           try
           {
               fs = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
               XmlSerializer serializer = new XmlSerializer(type);
               return serializer.Deserialize(fs);
           }
           catch (Exception ex)
           {
               throw ex;
           }
           finally 
           {
               if (fs != null)
                   fs.Close();
           }
       }

       /// <summary>
       /// 序列化
       /// </summary>
       /// <param name="obj">对象</param>
       /// <param name="filename">文件路径</param>
       public static void Save(object obj, string filename)
       {
           FileStream fs = null;
           try
           {
               fs = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
               XmlSerializer serializer = new XmlSerializer(obj.GetType());
               serializer.Serialize(fs, obj);
           }
           catch (Exception ex)
           {
               throw ex;
           }
           finally
           {
               if (fs != null)
                   fs.Close();
           }
       }
   }
}
