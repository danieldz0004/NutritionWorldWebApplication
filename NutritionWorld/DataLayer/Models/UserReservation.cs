using System;
namespace NutritionWorld.DataLayer.Models
{
    /// <summary>
    /// UserReservation
    /// </summary>
    [Serializable]
    public partial class UserReservation
    {
        public UserReservation()
        { }
        #region Model
        private int _id;
        private int _restId;
        private string _username;
        private string _restname;
        private DateTime? _reservedate;
        private string _reservestatus;
        /// <summary>
        /// 
        /// </summary>
        public int Id
        {
            set { _id = value; }
            get { return _id; }
        }
        public int RestId
        {
            set { _restId = value; }
            get { return _restId; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RestName
        {
            set { _restname = value; }
            get { return _restname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? ReserveDate
        {
            set { _reservedate = value; }
            get { return _reservedate; }
        }
        /// <summary>
        /// '1'为初始状态：未处理
        /// '2'为：餐馆已处理
        /// '3'为：已用餐
        /// '4'为：用户取消
        /// '5'为：管理员取消
        /// </summary>
        public string ReserveStatus
        {
            set { _reservestatus = value; }
            get { return _reservestatus; }
        }
        #endregion Model

    }
}

