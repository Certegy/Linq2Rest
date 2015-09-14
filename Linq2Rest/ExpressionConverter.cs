// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ODataExpressionConverter.cs" company="Reimers.dk">
//   Copyright © Reimers.dk 2014
//   This source is subject to the Microsoft Public License (Ms-PL).
//   Please see http://go.microsoft.com/fwlink/?LinkID=131993 for details.
//   All other rights reserved.
// </copyright>
// <summary>
//   Converts LINQ expressions to OData queries.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Linq2Rest
{
	using System;
	using System.Collections.Generic;
	using System.Diagnostics.CodeAnalysis;
	using System.Diagnostics.Contracts;
	using System.Linq;
	using System.Linq.Expressions;
	using Linq2Rest.Parser;
	using Linq2Rest.Parser.Readers;
	using Linq2Rest.Provider;
	using Linq2Rest.Provider.Writers;

	/// <summary>
	/// Converts LINQ expressions to OData queries.
	/// </summary>
	public class ExpressionConverter: IExpressionConverter
	{
        private readonly IExpressionWriter _writer;

		/// <summary>
		/// Initializes a new instance of the <see cref="ODataExpressionConverter"/> class.
		/// </summary>
		public ExpressionConverter()
			: this(new IValueWriter[0], new IValueExpressionFactory[0])
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ODataExpressionConverter"/> class.
		/// </summary>
		/// <param name="valueWriters">The custom value writers to use.</param>
		/// <param name="valueExpressionFactories">The custom expression writers to use.</param>
		/// <param name="memberNameResolver">The custom <see cref="IMemberNameResolver"/> to use.</param>
		public ExpressionConverter(IEnumerable<IValueWriter> valueWriters, IEnumerable<IValueExpressionFactory> valueExpressionFactories, IMemberNameResolver memberNameResolver = null)
		{
			var writers = (valueWriters ?? Enumerable.Empty<IValueWriter>()).ToArray();
			var expressionFactories = (valueExpressionFactories ?? Enumerable.Empty<IValueExpressionFactory>()).ToArray();
			var nameResolver = memberNameResolver ?? new MemberNameResolver();
			_writer = new ExpressionWriter(nameResolver, writers);
		}

        /// <summary>
        /// Converts an expression into an OData formatted query.
        /// </summary>
        /// <param name="filter">The expression to convert.</param>
        /// <typeparam name="T">The parameter type.</typeparam>
        /// <returns>An OData <see cref="string"/> representation.</returns>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Restriction is intended.")]
		public string ConvertFilter<T>(Expression<Func<T, bool>> filter) {
            return _writer.Write(filter, typeof(T));
        }

        /// <summary>
        /// Converts an expression into an OData formatted query.
        /// </summary>
        /// <param name="order">The expression to convert.</param>
        /// <typeparam name="T">The parameter type.</typeparam>
        /// <returns>An OData <see cref="string"/> representation.</returns>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Restriction is intended.")]
        public string ConvertOrder<T>(Expression<Func<T, object>> order) {
            return _writer.Write(order, typeof(T));
        }

        [ContractInvariantMethod]
		private void Invariants()
		{
			Contract.Invariant(_writer != null);
		}
	}
}
