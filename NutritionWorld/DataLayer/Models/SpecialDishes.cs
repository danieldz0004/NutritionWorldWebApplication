using System;
namespace NutritionWorld.DataLayer.Models
{
    /// <summary>
    /// SpecialDishes
    /// </summary>
    [Serializable]
	public partial class SpecialDishes
	{
		public SpecialDishes()
		{}
		#region Model
		private int _id;
		private int? _restaurantid;
		private string _dishesname;
		private string _photopath;
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
		public int? RestaurantId
		{
			set{ _restaurantid=value;}
			get{return _restaurantid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DishesName
		{
			set{ _dishesname=value;}
			get{return _dishesname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PhotoPath
		{
			set{ _photopath=value;}
			get{return _photopath;}
		}
		#endregion Model

	}
}

