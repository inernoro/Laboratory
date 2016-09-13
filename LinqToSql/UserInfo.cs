using System;

namespace LinqToSql
{
    [Serializable]
    public class UserInfo 
    {
       
        public  int Id { get; set; }
        public int AbpUserId { get; set; }
        public string UserCode { get; set; }
        public string WebServerCode { get; set; }
        public string UserLoginName { get; set; }
        public string UserLoginPwd { get; set; }
        public string UserNName { get; set; }
        public string UserName { get; set; }
        public string UserPhone { get; set; }
        public string UserEmal { get; set; }
        public string UserHidImgUrl { get; set; }
        public int? UserSex { get; set; }
        public string DesignerStyle { get; set; }
        public string CertificateImg { get; set; }
        public int? CityInfoCid { get; set; }
        public string UserLiving { get; set; }
        public string UserHometown { get; set; }
        public string Company { get; set; }
        public string School { get; set; }
        public int? UserRole { get; set; }
        public int? Seniority { get; set; }
        public int? IsLogin { get; set; }
        public string Profile { get; set; }
        public decimal? UserRolePic { get; set; }
        public int? UserPRole { get; set; }
        public decimal? UserLevel { get; set; }
        public int? Remove { get; set; }
        public int? Recommend { get; set; }
        public int? Credits { get; set; }
        public int? Star { get; set; }
        public DateTime? CrTime { get; set; }
    }
}