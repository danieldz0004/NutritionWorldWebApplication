using System;
namespace NutritionWorld.DataLayer.Models
{
	/// <summary>
	/// UserComment:实体类
	/// </summary>
	[Serializable]
	public partial class UserComment
	{
		public UserComment()
		{}
		#region Model
		private int _id;
		private int? _restaurantid;
		private string _username;
		private string _comment;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? RestaurantID
		{
			set{ _restaurantid=value;}
			get{return _restaurantid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Comment
		{
			set{ _comment=value;}
			get{return _comment;}
		}
		#endregion Model

	}
}

