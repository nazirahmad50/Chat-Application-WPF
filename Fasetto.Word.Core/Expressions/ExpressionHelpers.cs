using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// A helper for expressions
    /// </summary>
    public static class ExpressionHelpers
    {

        /// <summary>
        /// Compiles an expression and gets the function return value
        /// </summary>
        /// <typeparam name="T">The type of return value</typeparam>
        /// <param name="lambda">the expression to compile</param>
        /// <returns></returns>
        public static T GetPorpertyValue<T>(this Expression<Func<T>> lambda)
        {
            // the compile turns it into function
            // invoke gets the property value
            return lambda.Compile().Invoke();
        }

        /// <summary>
        /// Sets the underlying properties value to a given value
        /// from an expression that contains the property
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="lambda"></param>
        /// <param value="T">the value to set the property to</param>

        public static void SetPropertyValue<T>(this Expression<Func<T>> lambda, T value)
        {
            // converts a lambda () => some.property to some.property
            // basically gets rid of the lambda and turns it into memeber property
            MemberExpression expression = (lambda as LambdaExpression).Body as MemberExpression;

            // get the property informarion so we can set it
            // the memeber is the property itself
            PropertyInfo propertInfo = (PropertyInfo)expression.Member;

            // get the class of the property
            var target = Expression.Lambda(expression.Expression).Compile().DynamicInvoke();

            // set the property value
            propertInfo.SetValue(target, value);
        }
    }
}
