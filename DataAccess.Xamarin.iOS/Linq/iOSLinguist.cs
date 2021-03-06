﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Core.Linq.Common.Language;
using DataAccess.Core.Linq;
using System.Linq.Expressions;
using DataAccess.Core.Linq.Common.Translation;
using DataAccess.Core.Linq.Common;

namespace DataAccess.Xamarin.iOS.Linq
{
    /// <summary>
    /// 
    /// </summary>
    public class iOSLinguist : QueryLinguist
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SQLiteLinguist"/> class.
        /// </summary>
        /// <param name="language">The language.</param>
        /// <param name="translator">The translator.</param>
        public iOSLinguist(iOSLanguage language, QueryTranslator translator)
            : base(language, translator)
        {
        }

        /// <summary>
        /// Provides language specific query translation.  Use this to apply language specific rewrites or
        /// to make assertions/validations about the query.
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public override Expression Translate(Expression expression)
        {
            expression = OrderByRewriter.Rewrite(this.Language, expression);

            expression = base.Translate(expression);
            expression = UnusedColumnRemover.Remove(expression);

            return expression;
        }

        /// <summary>
        /// Converts the query expression into text of this query language
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public override string Format(Expression expression)
        {
            return iOSFormatter.Format(expression);
        }
    }
}
