using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using NutritionWorld.DataLayer.DBUtility;
using System.Collections.Generic;

namespace NutritionWorld.DataLayer.DAl
{
    /// <summary>
    /// 数据访问类:UserReservation
    /// </summary>
    public partial class UserReservation
    {
        public UserReservation()
        { }
        #region  BasicMethod

        public bool IsHaveUserRecord(string userName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from UserReservation");
            strSql.Append(" where UserName=@userName and ReserveStatus='3'");
            SqlParameter[] parameters = {
                new SqlParameter("@userName", SqlDbType.NVarChar, 100)
            };
            parameters[0].Value = userName;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("Id", "UserReservation");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from UserReservation");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.Int,4)
            };
            parameters[0].Value = Id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Models.UserReservation model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into UserReservation(");
            strSql.Append("UserName,RestName,ReserveDate,ReserveStatus)");
            strSql.Append(" values (");
            strSql.Append("@UserName,@RestName,@ReserveDate,@ReserveStatus)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@UserName", SqlDbType.NVarChar,100),
                    new SqlParameter("@RestName", SqlDbType.NVarChar,100),
                    new SqlParameter("@ReserveDate", SqlDbType.Date,3),
                    new SqlParameter("@ReserveStatus", SqlDbType.NVarChar,10)};
            parameters[0].Value = model.UserName;
            parameters[1].Value = model.RestName;
            parameters[2].Value = model.ReserveDate;
            parameters[3].Value = model.ReserveStatus;

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
        public bool Update(Models.UserReservation model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update UserReservation set ");
            strSql.Append("UserName=@UserName,");
            strSql.Append("RestName=@RestName,");
            strSql.Append("ReserveDate=@ReserveDate,");
            strSql.Append("ReserveStatus=@ReserveStatus");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
                    new SqlParameter("@UserName", SqlDbType.NVarChar,100),
                    new SqlParameter("@RestName", SqlDbType.NVarChar,100),
                    new SqlParameter("@ReserveDate", SqlDbType.Date,3),
                    new SqlParameter("@ReserveStatus", SqlDbType.NVarChar,10),
                    new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = model.UserName;
            parameters[1].Value = model.RestName;
            parameters[2].Value = model.ReserveDate;
            parameters[3].Value = model.ReserveStatus;
            parameters[4].Value = model.Id;

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
        public bool Delete(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from UserReservation ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.Int,4)
            };
            parameters[0].Value = Id;

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
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string Idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from UserReservation ");
            strSql.Append(" where Id in (" + Idlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
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
        /// 得到一个对象实体
        /// </summary>
        public Models.UserReservation GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,UserName,RestName,ReserveDate,ReserveStatus from UserReservation ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.Int,4)
            };
            parameters[0].Value = Id;

            Models.UserReservation model = new Models.UserReservation();
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
        /// 得到一个对象实体
        /// </summary>
        public Models.UserReservation DataRowToModel(DataRow row)
        {
            Models.UserReservation model = new Models.UserReservation();
            if (row != null)
            {
                if (row["Id"] != null && row["Id"].ToString() != "")
                {
                    model.Id = int.Parse(row["Id"].ToString());
                }
                if (row["UserName"] != null)
                {
                    model.UserName = row["UserName"].ToString();
                }
                if (row["RestName"] != null)
                {
                    model.RestName = row["RestName"].ToString();
                }
                if (row["ReserveDate"] != null && row["ReserveDate"].ToString() != "")
                {
                    model.ReserveDate = DateTime.Parse(row["ReserveDate"].ToString());
                }
                if (row["ReserveStatus"] != null)
                {
                    model.ReserveStatus = row["ReserveStatus"].ToString();
                }
            }
            return model;
        }

        /// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id,UserName,RestName,ReserveDate,ReserveStatus ");
            strSql.Append(" FROM UserReservation ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        public List<Models.UserReservation> GetModelList(string where)
        {
            DataSet ds = GetList(where);
            return DataTableToList(ds.Tables[0]);
        }

        public List<Models.UserReservation> DataTableToList(DataTable dt)
        {
            List<Models.UserReservation> modelList = new List<Models.UserReservation>();
            int rowCount = dt.Rows.Count;
            if (rowCount > 0)
            {
                Models.UserReservation model;
                for (int i = 0; i < rowCount; i++)
                {
                    model = new Models.UserReservation();
                    if (dt.Rows[i]["Id"] != null && dt.Rows[i]["Id"].ToString() != "")
                    {
                        model.Id = int.Parse(dt.Rows[i]["Id"].ToString());
                    }
                    if (dt.Rows[i]["UserName"] != null && dt.Rows[i]["UserName"].ToString() != "")
                    {
                        model.UserName = dt.Rows[i]["UserName"].ToString();
                    }
                    if (dt.Rows[i]["RestName"] != null && dt.Rows[i]["RestName"].ToString() != "")
                    {
                        model.RestName = dt.Rows[i]["RestName"].ToString();
                    }
                    if (dt.Rows[i]["ReserveDate"] != null && dt.Rows[i]["ReserveDate"].ToString() != "")
                    {
                        model.ReserveDate = (DateTime)dt.Rows[i]["ReserveDate"];
                    }
                    if (dt.Rows[i]["ReserveStatus"] != null && dt.Rows[i]["ReserveStatus"].ToString() != "")
                    {
                        model.ReserveStatus = dt.Rows[i]["ReserveStatus"].ToString();
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        #endregion  BasicMethod
    }
}

