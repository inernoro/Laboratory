using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ConsoleApplication1
{
    public static class Class1
    {
        public static TResult Get<TModel, TResult>(this TModel entity, Expression<Func<TModel, TResult>> func) where TModel : IEntity
        {
            var member = func.Body as MemberExpression;
            if (member == null)
            {
                throw new Exception("表达式为空");
            }
            Console.WriteLine(member.Member.Name);
            return default(TResult);
        }
        public static TModel Get<TModel>(this TModel entity, Expression<Func<TModel, bool>> func) where TModel : IEntity
        {
            var member = func.Body as MemberExpression;
            if (member != null)
            {
                var name = member.Member.Name;
                Console.WriteLine(name);
            }
            return default(TModel);
        }

    }
}