using System;
namespace NutritionWorld.DataLayer.Models
{
	/// <summary>
	/// AspNetUsers
	/// </summary>
	[Serializable]
	public partial class AspNetUsers
	{
		public AspNetUsers()
		{}
		#region Model
		private string _id;
		private string _email;
		private bool _emailconfirmed;
		private string _passwordhash;
		private string _securitystamp;
		private string _phonenumber;
		private bool _phonenumberconfirmed;
		private bool _twofactorenabled;
		private DateTime? _lockoutenddateutc;
		private bool _lockoutenabled;
		private int? _accessfailedcount;
		private string _username;
		private string _firstname;
		private string _lastname;
		private DateTime _birthday;
		
		public string Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		
		public string Email
		{
			set{ _email=value;}
			get{return _email;}
		}
		
		public bool EmailConfirmed
		{
			set{ _emailconfirmed=value;}
			get{return _emailconfirmed;}
		}
		
		public string PasswordHash
		{
			set{ _passwordhash=value;}
			get{return _passwordhash;}
		}
		
		public string SecurityStamp
		{
			set{ _securitystamp=value;}
			get{return _securitystamp;}
		}
		
		public string PhoneNumber
		{
			set{ _phonenumber=value;}
			get{return _phonenumber;}
		}
		
		public bool PhoneNumberConfirmed
		{
			set{ _phonenumberconfirmed=value;}
			get{return _phonenumberconfirmed;}
		}
		
		public bool TwoFactorEnabled
		{
			set{ _twofactorenabled=value;}
			get{return _twofactorenabled;}
		}
		
		public DateTime? LockoutEndDateUtc
		{
			set{ _lockoutenddateutc=value;}
			get{return _lockoutenddateutc;}
		}
		
		public bool LockoutEnabled
		{
			set{ _lockoutenabled=value;}
			get{return _lockoutenabled;}
		}
		
		public int? AccessFailedCount
		{
			set{ _accessfailedcount=value;}
			get{return _accessfailedcount;}
		}
		
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
		}
		
		public string FirstName
		{
			set{ _firstname=value;}
			get{return _firstname;}
		}
		
		public string LastName
		{
			set{ _lastname=value;}
			get{return _lastname;}
		}
		
		public DateTime Birthday
		{
			set{ _birthday=value;}
			get{return _birthday;}
		}
		#endregion Model

	}
}

