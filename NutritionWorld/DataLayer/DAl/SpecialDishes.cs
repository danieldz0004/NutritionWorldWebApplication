using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using NutritionWorld.DataLayer.DBUtility;
using System.Collections.Generic;

namespace NutritionWorld.DataLayer.DAl
{
    /// <summary>
    /// 数据访问类:SpecialDishes
    /// </summary>
    public partial class SpecialDishes
	{
		public SpecialDishes()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "SpecialDishes"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from SpecialDishes");
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
		public int Add(Models.SpecialDishes model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SpecialDishes(");
			strSql.Append("RestaurantId,DishesName,PhotoPath)");
			strSql.Append(" values (");
			strSql.Append("@RestaurantId,@DishesName,@PhotoPath)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@RestaurantId", SqlDbType.Int,4),
					new SqlParameter("@DishesName", SqlDbType.NVarChar,100),
					new SqlParameter("@PhotoPath", SqlDbType.NVarChar,200)};
			parameters[0].Value = model.RestaurantId;
			parameters[1].Value = model.DishesName;
			parameters[2].Value = model.PhotoPath;

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
		public bool Update(Models.SpecialDishes model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SpecialDishes set ");
			strSql.Append("RestaurantId=@RestaurantId,");
			strSql.Append("DishesName=@DishesName,");
			strSql.Append("PhotoPath=@PhotoPath");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@RestaurantId", SqlDbType.Int,4),
					new SqlParameter("@DishesName", SqlDbType.NVarChar,100),
					new SqlParameter("@PhotoPath", SqlDbType.NVarChar,200),
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = model.RestaurantId;
			parameters[1].Value = model.DishesName;
			parameters[2].Value = model.PhotoPath;
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
			strSql.Append("delete from SpecialDishes ");
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
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SpecialDishes ");
			strSql.Append(" where ID in ("+IDlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
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
		public Models.SpecialDishes GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,RestaurantId,DishesName,PhotoPath from SpecialDishes ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			Models.SpecialDishes model=new Models.SpecialDishes();
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
		public Models.SpecialDishes DataRowToModel(DataRow row)
		{
			Models.SpecialDishes model=new Models.SpecialDishes();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["RestaurantId"]!=null && row["RestaurantId"].ToString()!="")
				{
					model.RestaurantId=int.Parse(row["RestaurantId"].ToString());
				}
				if(row["DishesName"]!=null)
				{
					model.DishesName=row["DishesName"].ToString();
				}
				if(row["PhotoPath"]!=null)
				{
					model.PhotoPath=row["PhotoPath"].ToString();
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
			strSql.Append("select ID,RestaurantId,DishesName,PhotoPath ");
			strSql.Append(" FROM SpecialDishes ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

        public List<Models.SpecialDishes> GetModelList(int restId)
        {
            DataSet ds = GetList(string.Format("RestaurantId={0}", restId));
            return DataTableToList(ds.Tables[0]);
        }

        public List<Models.SpecialDishes> DataTableToList(DataTable dt)
        {
            List<Models.SpecialDishes> modelList = new List<Models.SpecialDishes>();
            int rowCount = dt.Rows.Count;
            if (rowCount > 0)
            {
                Models.SpecialDishes model;
                for (int i = 0; i < rowCount; i++)
                {
                    model = new Models.SpecialDishes();
                    if (dt.Rows[i]["ID"] != null && dt.Rows[i]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(dt.Rows[i]["ID"].ToString());
                    }
                    if (dt.Rows[i]["RestaurantId"] != null && dt.Rows[i]["RestaurantId"].ToString() != "")
                    {
                        model.RestaurantId = (int)dt.Rows[i]["RestaurantId"];
                    }
                    if (dt.Rows[i]["DishesName"] != null && dt.Rows[i]["DishesName"].ToString() != "")
                    {
                        model.DishesName = dt.Rows[i]["DishesName"].ToString();
                    }
                    if (dt.Rows[i]["PhotoPath"] != null && dt.Rows[i]["PhotoPath"].ToString() != "")
                    {
                        model.PhotoPath = dt.Rows[i]["PhotoPath"].ToString();
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        #endregion  BasicMethod
    }
}

