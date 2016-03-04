
using AndyMolly.Common;
using AndyMolly.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace AndyMolly.DAL
{
   public partial class Users
    {
        private string databaseprefix; //数据库表名前缀
        public Users(string _databaseprefix)
        {
            databaseprefix = _databaseprefix;
        }

        #region 基本方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from " + databaseprefix + "users");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 检查用户名是否存在
        /// </summary>
        public bool Exists(string user_name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from " + databaseprefix + "users");
            strSql.Append(" where user_name=@user_name ");
            SqlParameter[] parameters = {
					new SqlParameter("@user_name", SqlDbType.NVarChar,100)};
            parameters[0].Value = user_name;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 检查账号是否存在
        /// </summary>
        public bool ExistsAcc(string user_account)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from " + databaseprefix + "users");
            strSql.Append(" where user_account=@user_account ");
            SqlParameter[] parameters = {
					new SqlParameter("@user_account", SqlDbType.NVarChar,100)};
            parameters[0].Value = user_account;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.Users model)
        {
            //user_account,user_passworld,reg_time,login_time,user_name,endurance,gold,wing,lv,vip,head,exp

            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into " + databaseprefix + "users(");
            strSql.Append("user_account,user_passworld,reg_time,login_time,user_name,endurance,gold,wing,lv,vip,head,exp)");
            strSql.Append(" values (");
            strSql.Append("@user_account,@user_passworld,@reg_time,@login_time,@user_name,@endurance,@gold,@wing,@lv,@vip,@head,@exp)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@user_account", SqlDbType.NVarChar,50),
					new SqlParameter("@user_passworld", SqlDbType.NVarChar,50),
					new SqlParameter("@reg_time", SqlDbType.DateTime),
					new SqlParameter("@login_time", SqlDbType.DateTime),
					new SqlParameter("@user_name", SqlDbType.NVarChar,50),
					new SqlParameter("@endurance", SqlDbType.Int,4),
					new SqlParameter("@gold", SqlDbType.Int,4),
					new SqlParameter("@wing", SqlDbType.Int,4),
					new SqlParameter("@lv", SqlDbType.Int,4),
					new SqlParameter("@vip", SqlDbType.Int,4),
					new SqlParameter("@head", SqlDbType.NVarChar,50),
                    new SqlParameter("@exp", SqlDbType.Int,4)};
            parameters[0].Value = model.UserAccount;
            parameters[1].Value = model.UserPassworld;
            parameters[2].Value = model.RegTime;
            parameters[3].Value = model.LoginTime;
            parameters[4].Value = model.UserName;
            parameters[5].Value = model.Endurance;
            parameters[6].Value = model.Gold;
            parameters[7].Value = model.Wing;
            parameters[8].Value = model.Lv;
            parameters[9].Value = model.Vip;
            parameters[10].Value = model.Head;
            parameters[11].Value = model.Exp;

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

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.Users model)
        {
            //user_account,user_passworld,reg_time,login_time,user_name,endurance,gold,wing,lv,vip,head,exp
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + databaseprefix + "users set ");
            strSql.Append("user_account=@user_account,");
            strSql.Append("user_passworld=@user_passworld,");
            strSql.Append("reg_time=@reg_time,");
            strSql.Append("login_time=@login_time,");
            strSql.Append("user_name=@user_name,");
            strSql.Append("gold=@gold,");
            strSql.Append("wing=@wing,");
            strSql.Append("lv=@lv,");
            strSql.Append("vip=@vip,");
            strSql.Append("head=@head,");
            strSql.Append("exp=@exp ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@user_account", SqlDbType.NVarChar,50),
					new SqlParameter("@user_passworld", SqlDbType.NVarChar,50),
					new SqlParameter("@reg_time", SqlDbType.DateTime),
					new SqlParameter("@login_time", SqlDbType.DateTime),
					new SqlParameter("@user_name", SqlDbType.NVarChar,50),
					new SqlParameter("@endurance", SqlDbType.Int,4),
					new SqlParameter("@gold", SqlDbType.Int,4),
					new SqlParameter("@wing", SqlDbType.Int,4),
					new SqlParameter("@lv", SqlDbType.Int,4),
					new SqlParameter("@vip", SqlDbType.Int,4),
					new SqlParameter("@head", SqlDbType.NVarChar,50),
                    new SqlParameter("@exp", SqlDbType.Int,4)};
            parameters[0].Value = model.UserAccount;
            parameters[1].Value = model.UserPassworld;
            parameters[2].Value = model.RegTime;
            parameters[3].Value = model.LoginTime;
            parameters[4].Value = model.UserName;
            parameters[5].Value = model.Endurance;
            parameters[6].Value = model.Gold;
            parameters[7].Value = model.Wing;
            parameters[8].Value = model.Lv;
            parameters[9].Value = model.Vip;
            parameters[10].Value = model.Head;
            parameters[11].Value = model.Exp;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {
            //获取用户旧数据
            Model.Users model = GetModel(id);
            if (model == null)
            {
                return false;
            }

            List<CommandInfo> sqllist = new List<CommandInfo>();

            CommandInfo cmd = new CommandInfo();
            //sqllist.Add(cmd);


            //删除用户主表
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + databaseprefix + "users ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;
            cmd = new CommandInfo(strSql.ToString(), parameters);
            sqllist.Add(cmd);

            int rowsAffected = DbHelperSQL.ExecuteSqlTran(sqllist);
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.Users GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 id,user_account,user_passworld,reg_time,login_time,user_name,endurance,gold,wing,lv,vip,head,exp");
            strSql.Append(" from " + databaseprefix + "users");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 根据账号密码返回一个实体
        /// </summary>
        public Model.Users GetModel(string user_account, string user_passworld)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 id,user_account,user_passworld,reg_time,login_time,user_name,endurance,gold,wing,lv,vip,head,exp");
            strSql.Append(" from " + databaseprefix + "users");
            strSql.Append(" where user_account=@user_account");

            strSql.Append(" and user_passworld=@user_passworld");

            SqlParameter[] parameters = {
					    new SqlParameter("@user_account", SqlDbType.NVarChar,100),
                        new SqlParameter("@user_passworld", SqlDbType.NVarChar,100)};
            parameters[0].Value = user_account;
            parameters[1].Value = user_passworld;

            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 根据用户名返回一个实体
        /// </summary>
        public Model.Users GetModel(string user_name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 id,user_account,user_passworld,reg_time,login_time,user_name,endurance,gold,wing,lv,vip,head,exp");
            strSql.Append(" from " + databaseprefix + "users");
            strSql.Append(" where user_name=@user_name");
            SqlParameter[] parameters = {
					new SqlParameter("@user_name", SqlDbType.NVarChar,100)};
            parameters[0].Value = user_name;

            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" id,user_account,user_passworld,reg_time,login_time,user_name,endurance,gold,wing,lv,vip,head,exp");
            strSql.Append(" FROM " + databaseprefix + "users ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM " + databaseprefix + "users");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
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
            //user_account,user_passworld,reg_time,login_time,user_name,endurance,gold,wing,lv,vip,head,exp
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
