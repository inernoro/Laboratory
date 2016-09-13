using System;
using Abp.Domain.Entities;

namespace TestRedis
{
    [Serializable]
    public class UserInfo : Entity
    {
       
        public override int Id { get; set; }
        public virtual int AbpUserId { get; set; }
        public virtual string UserCode { get; set; }
        public virtual string WebServerCode { get; set; }
        public virtual string UserLoginName { get; set; }
        public virtual string UserLoginPwd { get; set; }
        public virtual string UserNName { get; set; }
        public virtual string UserName { get; set; }
        public virtual string UserPhone { get; set; }
        public virtual string UserEmal { get; set; }
        public virtual string UserHidImgUrl { get; set; }
        public virtual int? UserSex { get; set; }
        public virtual string DesignerStyle { get; set; }
        public virtual string CertificateImg { get; set; }
        public virtual int? CityInfoCid { get; set; }
        public virtual string UserLiving { get; set; }
        public virtual string UserHometown { get; set; }
        public virtual string Company { get; set; }
        public virtual string School { get; set; }
        public virtual int? UserRole { get; set; }
        public virtual int? Seniority { get; set; }
        public virtual int? IsLogin { get; set; }
        public virtual string Profile { get; set; }
        public virtual decimal? UserRolePic { get; set; }
        public virtual int? UserPRole { get; set; }
        public virtual decimal? UserLevel { get; set; }
        public virtual int? Remove { get; set; }
        public virtual int? Recommend { get; set; }
        public virtual int? Credits { get; set; }
        public virtual int? Star { get; set; }
        public virtual DateTime? CrTime { get; set; }
    }
}