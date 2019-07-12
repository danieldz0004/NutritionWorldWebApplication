using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using NutritionWorld.DataLayer.DBUtility;
namespace NutritionWorld.DataLayer.DAl
{
	/// <summary>
	/// 数据访问类:AspNetUsers
	/// </summary>
	public partial class AspNetUsers
	{
		public AspNetUsers()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string Id,string UserName)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from AspNetUsers");
			strSql.Append(" where Id=@Id and UserName=@UserName ");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.NVarChar,128),
					new SqlParameter("@UserName", SqlDbType.NVarChar,256)			};
			parameters[0].Value = Id;
			parameters[1].Value = UserName;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Models.AspNetUsers model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into AspNetUsers(");
			strSql.Append("Id,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName,FirstName,LastName,Birthday)");
			strSql.Append(" values (");
			strSql.Append("@Id,@Email,@EmailConfirmed,@PasswordHash,@SecurityStamp,@PhoneNumber,@PhoneNumberConfirmed,@TwoFactorEnabled,@LockoutEndDateUtc,@LockoutEnabled,@AccessFailedCount,@UserName,@FirstName,@LastName,@Birthday)");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.NVarChar,128),
					new SqlParameter("@Email", SqlDbType.NVarChar,256),
					new SqlParameter("@EmailConfirmed", SqlDbType.Bit,1),
					new SqlParameter("@PasswordHash", SqlDbType.NVarChar,-1),
					new SqlParameter("@SecurityStamp", SqlDbType.NVarChar,-1),
					new SqlParameter("@PhoneNumber", SqlDbType.NVarChar,-1),
					new SqlParameter("@PhoneNumberConfirmed", SqlDbType.Bit,1),
					new SqlParameter("@TwoFactorEnabled", SqlDbType.Bit,1),
					new SqlParameter("@LockoutEndDateUtc", SqlDbType.DateTime),
					new SqlParameter("@LockoutEnabled", SqlDbType.Bit,1),
					new SqlParameter("@AccessFailedCount", SqlDbType.Int,4),
					new SqlParameter("@UserName", SqlDbType.NVarChar,256),
					new SqlParameter("@FirstName", SqlDbType.NVarChar,100),
					new SqlParameter("@LastName", SqlDbType.NVarChar,100),
					new SqlParameter("@Birthday", SqlDbType.Date,3)};
			parameters[0].Value = model.Id;
			parameters[1].Value = model.Email;
			parameters[2].Value = model.EmailConfirmed;
			parameters[3].Value = model.PasswordHash;
			parameters[4].Value = model.SecurityStamp;
			parameters[5].Value = model.PhoneNumber;
			parameters[6].Value = model.PhoneNumberConfirmed;
			parameters[7].Value = model.TwoFactorEnabled;
			parameters[8].Value = model.LockoutEndDateUtc;
			parameters[9].Value = model.LockoutEnabled;
			parameters[10].Value = model.AccessFailedCount;
			parameters[11].Value = model.UserName;
			parameters[12].Value = model.FirstName;
			parameters[13].Value = model.LastName;
			parameters[14].Value = model.Birthday;

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
		/// 更新一条数据
		/// </summary>
		public bool Update(Models.AspNetUsers model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update AspNetUsers set ");
			strSql.Append("Email=@Email,");
			strSql.Append("EmailConfirmed=@EmailConfirmed,");
			strSql.Append("PasswordHash=@PasswordHash,");
			strSql.Append("SecurityStamp=@SecurityStamp,");
			strSql.Append("PhoneNumber=@PhoneNumber,");
			strSql.Append("PhoneNumberConfirmed=@PhoneNumberConfirmed,");
			strSql.Append("TwoFactorEnabled=@TwoFactorEnabled,");
			strSql.Append("LockoutEndDateUtc=@LockoutEndDateUtc,");
			strSql.Append("LockoutEnabled=@LockoutEnabled,");
			strSql.Append("AccessFailedCount=@AccessFailedCount,");
			strSql.Append("FirstName=@FirstName,");
			strSql.Append("LastName=@LastName,");
			strSql.Append("Birthday=@Birthday");
			strSql.Append(" where Id=@Id and UserName=@UserName ");
			SqlParameter[] parameters = {
					new SqlParameter("@Email", SqlDbType.NVarChar,256),
					new SqlParameter("@EmailConfirmed", SqlDbType.Bit,1),
					new SqlParameter("@PasswordHash", SqlDbType.NVarChar,-1),
					new SqlParameter("@SecurityStamp", SqlDbType.NVarChar,-1),
					new SqlParameter("@PhoneNumber", SqlDbType.NVarChar,-1),
					new SqlParameter("@PhoneNumberConfirmed", SqlDbType.Bit,1),
					new SqlParameter("@TwoFactorEnabled", SqlDbType.Bit,1),
					new SqlParameter("@LockoutEndDateUtc", SqlDbType.DateTime),
					new SqlParameter("@LockoutEnabled", SqlDbType.Bit,1),
					new SqlParameter("@AccessFailedCount", SqlDbType.Int,4),
					new SqlParameter("@FirstName", SqlDbType.NVarChar,100),
					new SqlParameter("@LastName", SqlDbType.NVarChar,100),
					new SqlParameter("@Birthday", SqlDbType.Date,3),
					new SqlParameter("@Id", SqlDbType.NVarChar,128),
					new SqlParameter("@UserName", SqlDbType.NVarChar,256)};
			parameters[0].Value = model.Email;
			parameters[1].Value = model.EmailConfirmed;
			parameters[2].Value = model.PasswordHash;
			parameters[3].Value = model.SecurityStamp;
			parameters[4].Value = model.PhoneNumber;
			parameters[5].Value = model.PhoneNumberConfirmed;
			parameters[6].Value = model.TwoFactorEnabled;
			parameters[7].Value = model.LockoutEndDateUtc;
			parameters[8].Value = model.LockoutEnabled;
			parameters[9].Value = model.AccessFailedCount;
			parameters[10].Value = model.FirstName;
			parameters[11].Value = model.LastName;
			parameters[12].Value = model.Birthday;
			parameters[13].Value = model.Id;
			parameters[14].Value = model.UserName;

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
		public bool Delete(string Id,string UserName)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from AspNetUsers ");
			strSql.Append(" where Id=@Id and UserName=@UserName ");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.NVarChar,128),
					new SqlParameter("@UserName", SqlDbType.NVarChar,256)			};
			parameters[0].Value = Id;
			parameters[1].Value = UserName;

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
		public Models.AspNetUsers GetModel(string Id,string UserName)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Id,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName,FirstName,LastName,Birthday from AspNetUsers ");
			strSql.Append(" where Id=@Id and UserName=@UserName ");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.NVarChar,128),
					new SqlParameter("@UserName", SqlDbType.NVarChar,256)			};
			parameters[0].Value = Id;
			parameters[1].Value = UserName;

			Models.AspNetUsers model=new Models.AspNetUsers();
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
		public Models.AspNetUsers DataRowToModel(DataRow row)
		{
			Models.AspNetUsers model=new Models.AspNetUsers();
			if (row != null)
			{
				if(row["Id"]!=null)
				{
					model.Id=row["Id"].ToString();
				}
				if(row["Email"]!=null)
				{
					model.Email=row["Email"].ToString();
				}
				if(row["EmailConfirmed"]!=null && row["EmailConfirmed"].ToString()!="")
				{
					if((row["EmailConfirmed"].ToString()=="1")||(row["EmailConfirmed"].ToString().ToLower()=="true"))
					{
						model.EmailConfirmed=true;
					}
					else
					{
						model.EmailConfirmed=false;
					}
				}
				if(row["PasswordHash"]!=null)
				{
					model.PasswordHash=row["PasswordHash"].ToString();
				}
				if(row["SecurityStamp"]!=null)
				{
					model.SecurityStamp=row["SecurityStamp"].ToString();
				}
				if(row["PhoneNumber"]!=null)
				{
					model.PhoneNumber=row["PhoneNumber"].ToString();
				}
				if(row["PhoneNumberConfirmed"]!=null && row["PhoneNumberConfirmed"].ToString()!="")
				{
					if((row["PhoneNumberConfirmed"].ToString()=="1")||(row["PhoneNumberConfirmed"].ToString().ToLower()=="true"))
					{
						model.PhoneNumberConfirmed=true;
					}
					else
					{
						model.PhoneNumberConfirmed=false;
					}
				}
				if(row["TwoFactorEnabled"]!=null && row["TwoFactorEnabled"].ToString()!="")
				{
					if((row["TwoFactorEnabled"].ToString()=="1")||(row["TwoFactorEnabled"].ToString().ToLower()=="true"))
					{
						model.TwoFactorEnabled=true;
					}
					else
					{
						model.TwoFactorEnabled=false;
					}
				}
				if(row["LockoutEndDateUtc"]!=null && row["LockoutEndDateUtc"].ToString()!="")
				{
					model.LockoutEndDateUtc=DateTime.Parse(row["LockoutEndDateUtc"].ToString());
				}
				if(row["LockoutEnabled"]!=null && row["LockoutEnabled"].ToString()!="")
				{
					if((row["LockoutEnabled"].ToString()=="1")||(row["LockoutEnabled"].ToString().ToLower()=="true"))
					{
						model.LockoutEnabled=true;
					}
					else
					{
						model.LockoutEnabled=false;
					}
				}
				if(row["AccessFailedCount"]!=null && row["AccessFailedCount"].ToString()!="")
				{
					model.AccessFailedCount=int.Parse(row["AccessFailedCount"].ToString());
				}
				if(row["UserName"]!=null)
				{
					model.UserName=row["UserName"].ToString();
				}
				if(row["FirstName"]!=null)
				{
					model.FirstName=row["FirstName"].ToString();
				}
				if(row["LastName"]!=null)
				{
					model.LastName=row["LastName"].ToString();
				}
				if(row["Birthday"]!=null && row["Birthday"].ToString()!="")
				{
					model.Birthday=DateTime.Parse(row["Birthday"].ToString());
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
			strSql.Append("select Id,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName,FirstName,LastName,Birthday ");
			strSql.Append(" FROM AspNetUsers ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}
		#endregion  BasicMethod
	}
}

