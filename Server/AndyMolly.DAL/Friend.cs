using AndyMolly.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace AndyMolly.DAL
{
    /// <summary>
    /// 数据访问类:用户
    /// </summary>
   public partial class Friend
    {
        private string databaseprefix; //数据库表名前缀
        public Friend(string _databaseprefix)
        {
            databaseprefix = _databaseprefix;
        }

        #region 基本方法
        /// <summary>
        /// 是否已经是好友了
        /// </summary>
        public bool Exists(int uid, int friend_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from " + databaseprefix + "friend");
            strSql.Append(" where uid=@uid and friend_id=@friend_id");
            SqlParameter[] parameters = {
					new SqlParameter("@uid", SqlDbType.Int,4),
                    new SqlParameter("@friend_id", SqlDbType.Int,4)};
            parameters[0].Value = uid;
            parameters[1].Value = friend_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.Friend model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into " + databaseprefix + "friend(");
            strSql.Append("uid,friend_id)");
            strSql.Append(" values (");
            strSql.Append("@uid,@friend_id)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@uid", SqlDbType.Int,4),
                    new SqlParameter("@friend_id", SqlDbType.Int,4)};
            parameters[0].Value = model.UId;
            parameters[1].Value = model.FriendId;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        #endregion

        #region 扩展方法

        /// <summary>
        /// 修改一列数据
        /// </summary>
        public int UpdateField(int id, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + databaseprefix + "users set " + strValue);
            strSql.Append(" where id=" + id);
            return DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.Users DataRowToModel(DataRow row)
        {
            Model.Users model = new Model.Users();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.ID = int.Parse(row["id"].ToString());
                }
                if (row["user_account"] != null)
                {
                    model.UserAccount = row["user_account"].ToString();
                }
                if (row["user_passworld"] != null)
                {
                    model.UserPassworld = row["user_passworld"].ToString();
                }
                if (row["reg_time"] != null && row["reg_time"].ToString() != "")
                {
                    model.RegTime = DateTime.Parse(row["reg_time"].ToString());
                }
                if (row["login_time"] != null && row["login_time"].ToString() != "")
                {
                    model.LoginTime = DateTime.Parse(row["login_time"].ToString());
                }
                if (row["user_name"] != null)
                {
                    model.UserName = row["user_name"].ToString();
                }
                if (row["endurance"] != null && row["endurance"].ToString() != "")
                {
                    model.Endurance = int.Parse(row["endurance"].ToString());
                }
                if (row["gold"] != null && row["gold"].ToString() != "")
                {
                    model.Gold = int.Parse(row["gold"].ToString());
                }
                if (row["wing"] != null && row["wing"].ToString() != "")
                {
                    model.Wing = int.Parse(row["wing"].ToString());
                }
                if (row["lv"] != null && row["lv"].ToString() != "")
                {
                    model.Lv = int.Parse(row["lv"].ToString());
                }
                if (row["vip"] != null && row["vip"].ToString() != "")
                {
                    model.Vip = int.Parse(row["vip"].ToString());
                }
                if (row["head"] != null)
                {
                    model.Head = row["head"].ToString();
                }
                if (row["exp"] != null && row["exp"].ToString() != "")
                {
                    model.Exp = int.Parse(row["exp"].ToString());
                }

            }
            return model;
        }
        #endregion
    }
}