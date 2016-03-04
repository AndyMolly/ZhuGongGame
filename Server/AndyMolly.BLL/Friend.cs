using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AndyMolly.BLL
{
    /// <summary>
    /// 用户信息
    /// </summary>
   public partial class Friend
    {
       private readonly DAL.Friend dal;
        public Friend()
        {
            dal = new DAL.Friend("mb_");
        }

        #region 基本方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int uid, int friend_id)
        {
            return dal.Exists(uid, friend_id);
        }

        /// <summary>
        /// 添加一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(Model.Friend model)
        {
            return dal.Add(model);
        }

        #endregion
    }
}
