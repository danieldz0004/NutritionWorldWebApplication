using System;
namespace NutritionWorld.DataLayer.Models
{
	/// <summary>
	/// Restaurant
	/// </summary>
	[Serializable]
	public partial class Restaurant
	{
		public Restaurant()
		{}
		#region Model
		private int _id;
		private string _name;
		private string _address;
		private string _photo_path;
		
		public int Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		
		public string Address
		{
			set{ _address=value;}
			get{return _address;}
		}
		
		public string Photo_Path
		{
			set{ _photo_path=value;}
			get{return _photo_path;}
		}
		#endregion Model

	}
}

