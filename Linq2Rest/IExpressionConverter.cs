using System;
using System.Linq.Expressions;

namespace Linq2Rest {
    /// <summary>
    /// IExpressionConverter
    /// </summary>
    public interface IExpressionConverter 
        {
        /// <summary>
        /// Converts the given expression into a OData string
        /// </summary>
        string ConvertFilter<T>(Expression<Func<T, bool>> filter);

        /// <summary>
        /// Converts the given expression into a OData string
        /// </summary>
        string ConvertOrder<T>(Expression<Func<T, object>> order);
    }
}
