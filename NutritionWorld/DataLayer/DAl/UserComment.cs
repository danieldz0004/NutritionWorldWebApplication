using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using NutritionWorld.DataLayer.DBUtility;
using System.Collections.Generic;

namespace NutritionWorld.DataLayer.DAl
{
    /// <summary>
    /// 数据访问类:UserComment
    /// </summary>
    public partial class UserComment
	{
		public UserComment()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "UserComment"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from UserComment");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Models.UserComment model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into UserComment(");
			strSql.Append("RestaurantID,UserName,Comment)");
			strSql.Append(" values (");
			strSql.Append("@RestaurantID,@UserName,@Comment)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@RestaurantID", SqlDbType.Int,4),
					new SqlParameter("@UserName", SqlDbType.NVarChar,100),
					new SqlParameter("@Comment", SqlDbType.NVarChar,200)};
			parameters[0].Value = model.RestaurantID;
			parameters[1].Value = model.UserName;
			parameters[2].Value = model.Comment;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
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
		public bool Update(Models.UserComment model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update UserComment set ");
			strSql.Append("RestaurantID=@RestaurantID,");
			strSql.Append("UserName=@UserName,");
			strSql.Append("Comment=@Comment");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@RestaurantID", SqlDbType.Int,4),
					new SqlParameter("@UserName", SqlDbType.NVarChar,100),
					new SqlParameter("@Comment", SqlDbType.NVarChar,200),
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = model.RestaurantID;
			parameters[1].Value = model.UserName;
			parameters[2].Value = model.Comment;
			parameters[3].Value = model.ID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from UserComment ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public Models.UserComment GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,RestaurantID,UserName,Comment from UserComment ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			Models.UserComment model=new Models.UserComment();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
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
		public Models.UserComment DataRowToModel(DataRow row)
		{
			Models.UserComment model=new Models.UserComment();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["RestaurantID"]!=null && row["RestaurantID"].ToString()!="")
				{
					model.RestaurantID=int.Parse(row["RestaurantID"].ToString());
				}
				if(row["UserName"]!=null)
				{
					model.UserName=row["UserName"].ToString();
				}
				if(row["Comment"]!=null)
				{
					model.Comment=row["Comment"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,RestaurantID,UserName,Comment ");
			strSql.Append(" FROM UserComment ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

        public List<Models.UserComment> GetModelList(string where)
        {
            DataSet ds = GetList(where);
            return DataTableToList(ds.Tables[0]);
        }

        public List<Models.UserComment> DataTableToList(DataTable dt)
        {
            List<Models.UserComment> modelList = new List<Models.UserComment>();
            int rowCount = dt.Rows.Count;
            if (rowCount > 0)
            {
                Models.UserComment model;
                for (int i = 0; i < rowCount; i++)
                {
                    model = new Models.UserComment();
                    if (dt.Rows[i]["Id"] != null && dt.Rows[i]["Id"].ToString() != "")
                    {
                        model.ID = int.Parse(dt.Rows[i]["Id"].ToString());
                    }
                    if (dt.Rows[i]["RestaurantID"] != null && dt.Rows[i]["RestaurantID"].ToString() != "")
                    {
                        model.RestaurantID = (int)dt.Rows[i]["RestaurantID"];
                    }
                    if (dt.Rows[i]["UserName"] != null && dt.Rows[i]["UserName"].ToString() != "")
                    {
                        model.UserName = dt.Rows[i]["UserName"].ToString();
                    }
                    if (dt.Rows[i]["Comment"] != null && dt.Rows[i]["Comment"].ToString() != "")
                    {
                        model.Comment = dt.Rows[i]["Comment"].ToString();
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        #endregion  BasicMethod
    }
}

