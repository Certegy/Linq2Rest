// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IExpressionProcessor.cs" company="Reimers.dk">
//   Copyright � Reimers.dk 2014
//   This source is subject to the Microsoft Public License (Ms-PL).
//   Please see http://go.microsoft.com/fwlink/?LinkID=131993 for details.
//   All other rights reserved.
// </copyright>
// <summary>
//   Defines the IExpressionProcessor type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Linq2Rest.Provider
{
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Diagnostics.Contracts;
	using System.Linq.Expressions;

    /// <summary>
    /// IExpressionProcessor Externally Visible
    /// </summary>
    public interface IExpressionProcessorExt {

        /// <summary>
        /// Converts the given expression into a OData string
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="methodCall"></param>
        /// <returns></returns>
        string Convert<T>(MethodCallExpression methodCall);
    }

    [ContractClass(typeof(ExpressionProcessorContracts))]
	internal interface IExpressionProcessor
	{
		object ProcessMethodCall<T>(MethodCallExpression methodCall, ParameterBuilder builder, Func<ParameterBuilder, IEnumerable<T>> resultLoader, Func<Type, ParameterBuilder, IEnumerable> intermediateResultLoader);
	}

	[ContractClassFor(typeof(IExpressionProcessor))]
	internal abstract class ExpressionProcessorContracts : IExpressionProcessor
	{
		public object ProcessMethodCall<T>(MethodCallExpression methodCall, ParameterBuilder builder, Func<ParameterBuilder, IEnumerable<T>> resultLoader, Func<Type, ParameterBuilder, IEnumerable> intermediateResultLoader)
		{
			//Contract.Requires(builder != null);
			//Contract.Requires(resultLoader != null);
			//Contract.Requires(intermediateResultLoader != null);

			throw new NotImplementedException();
		}
	}
}