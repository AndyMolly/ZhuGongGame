using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AndyMolly.Model
{
    [Serializable]
   public partial class Friend
    {
       public Friend() { }

       #region 属性
       private int _uid;
       private int _friend_id;
       /// <summary>
       /// uID
       /// </summary>
       public int UId
       {
           set { _uid = value; }
           get { return _uid; }
       }

       /// <summary>
       /// 好友id
       /// </summary>
       public int FriendId
       {
           set { _friend_id = value; }
           get { return _friend_id; }
       }
       #endregion
    }
}
