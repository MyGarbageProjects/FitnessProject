using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FitnessDesktop.Models
{
    /// <summary>
    /// Extracts the property name from a property expression.
    /// </summary>
    /// <typeparam name="T">The object type containing the property specified in the expression.</typeparam>
    /// <param name="propertyExpression">The property expression (e.g. p =&gt; p.PropertyName)</param>
    /// <returns>The name of the property.</returns>
    /// <exception cref="T:System.ArgumentNullException">Thrown if the <paramref name="propertyExpression" /> is null.</exception>
    /// <exception cref="T:System.ArgumentException">Thrown when the expression is:<br />
    ///     Not a <see cref="T:System.Linq.Expressions.MemberExpression" /><br />
    ///     The <see cref="T:System.Linq.Expressions.MemberExpression" /> does not represent a property.<br />
    ///     Or, the property is static.
    /// </exception>
    class PropertySupport
    {
        public static string ExtractPropertyName<T>(Expression<Func<T>> propertyExpression)
        {
            if (propertyExpression == null)
            {
                throw new ArgumentNullException("propertyExpression");
            }
            MemberExpression body = propertyExpression.Body as MemberExpression;
            if (body == null)
            {
                throw new ArgumentException();
            }
            PropertyInfo member = body.Member as PropertyInfo;
            if (member == null)
            {
                throw new ArgumentException();
            }
            if (member.GetGetMethod(true).IsStatic)
            {
                throw new ArgumentException();
            }
            return body.Member.Name;
        }
    }
}
