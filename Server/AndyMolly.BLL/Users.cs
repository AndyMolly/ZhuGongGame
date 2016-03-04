using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace AndyMolly.BLL
{
  public partial class Users
    {
      private DAL.Users dal;
      public Users()
      {
          dal = new DAL.Users("mb_");
      }

      #region 基本方法
      /// <summary>
      /// 是否存在该记录
      /// </summary>
      public bool Exists(int id)
      {
          return dal.Exists(id);
      }

      /// <summary>
      /// 检查账号是否存在
      /// </summary>
      public bool ExistsAcc(string user_account)
      {
          return dal.ExistsAcc(user_account);
      }

      /// <summary>
      /// 检查用户名是否存在
      /// </summary>
      public bool Exists(string user_name)
      {
          return dal.Exists(user_name);
      }

      /// <summary>
      /// 增加一条数据
      /// </summary>
      public int Add(Model.Users model)
      {
          return dal.Add(model);
      }

      /// <summary>
      /// 更新一条数据
      /// </summary>
      public bool Update(Model.Users model)
      {
          return dal.Update(model);
      }

      /// <summary>
      /// 删除一条数据
      /// </summary>
      public bool Delete(int id)
      {
          return dal.Delete(id);
      }

      /// <summary>
      /// 得到一个对象实体
      /// </summary>
      public Model.Users GetModel(uint id)
      {
          return dal.GetModel((int)id);
      }
      /// <summary>
      /// 得到一个对象实体
      /// </summary>
      public Model.Users GetModel(int id)
      {
          return dal.GetModel(id);
      }



      /// <summary>
      /// 根据用户名返回一个实体
      /// </summary>
      public Model.Users GetModel(string user_name)
      {
          return dal.GetModel(user_name);
      }

      /// <summary>
      /// 获得前几行数据
      /// </summary>
      public DataSet GetList(int Top, string strWhere, string filedOrder)
      {
          return dal.GetList(Top, strWhere, filedOrder);
      }

      /// <summary>
      /// 获得查询分页数据
      /// </summary>
      public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
      {
          return dal.GetList(pageSize, pageIndex, strWhere, filedOrder, out recordCount);
      }
      #endregion

      #region 扩展方法
      /// <summary>
      /// 修改一列数据
      /// </summary>
      public int UpdateField(int id, string strValue)
      {
          return dal.UpdateField(id, strValue);
      }

      /// <summary>
      /// 根据用户名密码获取Model
      /// </summary>
      /// <param name="acc"></param>
      /// <param name="pass"></param>
      /// <returns></returns>
      public Model.Users GetModel(string acc, string pass)
      {
          return dal.GetModel(acc, pass);
      }
      #endregion
    }
}
