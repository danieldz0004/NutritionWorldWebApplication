using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using NutritionWorld.DataLayer.DBUtility;
using System.Collections.Generic;

namespace NutritionWorld.DataLayer.DAl
{
	/// <summary>
	/// 数据访问类:Restaurant
	/// </summary>
	public partial class Restaurant
	{
		public Restaurant()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("Id", "Restaurant"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Restaurant");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Models.Restaurant model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Restaurant(");
			strSql.Append("Name,Address,Photo_Path)");
			strSql.Append(" values (");
			strSql.Append("@Name,@Address,@Photo_Path)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.NVarChar,50),
					new SqlParameter("@Address", SqlDbType.NVarChar,100),
					new SqlParameter("@Photo_Path", SqlDbType.NVarChar,1000)};
			parameters[0].Value = model.Name;
			parameters[1].Value = model.Address;
			parameters[2].Value = model.Photo_Path;

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
		public bool Update(Models.Restaurant model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Restaurant set ");
			strSql.Append("Name=@Name,");
			strSql.Append("Address=@Address,");
			strSql.Append("Photo_Path=@Photo_Path");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.NVarChar,50),
					new SqlParameter("@Address", SqlDbType.NVarChar,100),
					new SqlParameter("@Photo_Path", SqlDbType.NVarChar,1000),
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = model.Name;
			parameters[1].Value = model.Address;
			parameters[2].Value = model.Photo_Path;
			parameters[3].Value = model.Id;

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
		public bool Delete(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Restaurant ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

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
		public Models.Restaurant GetModel(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Id,Name,Address,Photo_Path from Restaurant ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			Models.Restaurant model=new Models.Restaurant();
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

        public List<Models.Restaurant> GetModelList()
        {
            DataSet ds = GetList("");
            return DataTableToList(ds.Tables[0]);
        }

        public List<Models.Restaurant> DataTableToList(DataTable dt)
        {
            List<Models.Restaurant> modelList = new List<Models.Restaurant>();
            int rowCount = dt.Rows.Count;
            if (rowCount > 0)
            {
                Models.Restaurant model;
                for (int i = 0; i < rowCount; i++)
                {
                    model = new Models.Restaurant();
                    if (dt.Rows[i]["Id"] != null && dt.Rows[i]["Id"].ToString() != "")
                    {
                        model.Id = int.Parse(dt.Rows[i]["Id"].ToString());
                    }
                    if (dt.Rows[i]["Name"] != null && dt.Rows[i]["Name"].ToString() != "")
                    {
                        model.Name = dt.Rows[i]["Name"].ToString();
                    }
                    if (dt.Rows[i]["Address"] != null && dt.Rows[i]["Address"].ToString() != "")
                    {
                        model.Address = dt.Rows[i]["Address"].ToString();
                    }
                    if (dt.Rows[i]["Photo_Path"] != null && dt.Rows[i]["Photo_Path"].ToString() != "")
                    {
                        model.Photo_Path = dt.Rows[i]["Photo_Path"].ToString();
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Models.Restaurant DataRowToModel(DataRow row)
		{
			Models.Restaurant model=new Models.Restaurant();
			if (row != null)
			{
				if(row["Id"]!=null && row["Id"].ToString()!="")
				{
					model.Id=int.Parse(row["Id"].ToString());
				}
				if(row["Name"]!=null)
				{
					model.Name=row["Name"].ToString();
				}
				if(row["Address"]!=null)
				{
					model.Address=row["Address"].ToString();
				}
				if(row["Photo_Path"]!=null)
				{
					model.Photo_Path=row["Photo_Path"].ToString();
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
			strSql.Append("select Id,Name,Address,Photo_Path ");
			strSql.Append(" FROM Restaurant ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}
		#endregion  BasicMethod
	}
}

