using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AndyMolly.Model
{
   public partial class Users
    {
       public Users() { }

       #region 属性
       /// <summary>
       /// 自增ID
       /// </summary>
       private int _id;
       public int ID
       {
           get { return _id; }
           set { _id = value; }
       }
       /// <summary>
       /// 用户账号
       /// </summary>
       private string _user_account;
       public string UserAccount
       {
           get { return _user_account; }
           set { _user_account = value; }
       }

       /// <summary>
       /// 用户密码
       /// </summary>
       private string _user_passworld;
       public string UserPassworld
       {
           get { return _user_passworld; }
           set { _user_passworld = value; }
       }

       /// <summary>
       /// 注册时间
       /// </summary>
       private DateTime _reg_time;
       public DateTime RegTime
       {
           get { return _reg_time; }
           set { _reg_time = value; }
       }

       /// <summary>
       /// 最后登录时间
       /// </summary>
       private DateTime _login_time;
       public DateTime LoginTime
       {
           get { return _login_time; }
           set { _login_time = value; }
       }

       /// <summary>
       /// 用户名
       /// </summary>
       private string _user_name;
       public string UserName
       {
           get { return _user_name; }
           set { _user_name = value; }
       }

       /// <summary>
       /// 体力
       /// </summary>
       private int _endurance;
       public int Endurance
       {
           get { return _endurance; }
           set { _endurance = value; }
       }

       /// <summary>
       /// 金币
       /// </summary>
       private int _gold;
       public int Gold
       {
           get { return _gold; }
           set { _gold = value; }
       }

       /// <summary>
       /// 元宝
       /// </summary>
       private int _wing;
       public int Wing
       {
           get { return _wing; }
           set { _wing = value; }
       }

       /// <summary>
       /// 等级
       /// </summary>
       private int _lv;
       public int Lv
       {
           get { return _lv; }
           set { _lv = value; }
       }

       /// <summary>
       /// Vip等级
       /// </summary>
       private int _vip;
       public int Vip
       {
           get { return _vip; }
           set { _vip = value; }
       }
       /// <summary>
       /// 头衔
       /// </summary>
       private string _head;
       public string Head
       {
           get { return _head; }
           set { _head = value; }
       }

       /// <summary>
       /// 经验
       /// </summary>
       private int _exp;
       public int Exp
       {
           get { return _exp; }
           set { _exp = value; }
       }
       #endregion
    }
}
