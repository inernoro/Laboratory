using System.Reflection;
using Abp.Modules;

namespace TestRedis
{

    public class CloudRedisModule : AbpModule
    {
        public override void PreInitialize()
        {

        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
