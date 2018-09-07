using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Benefits.Shared.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;
using Benefits.Shared.Infrastructure;
using Benefits.Shared.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Benefits.Shared.ExtensionMethods
{
    /// <summary>
    /// Credit to Pete Montgomery
    /// https://petemontgomery.wordpress.com/2008/08/07/caching-the-results-of-linq-queries/
    /// Provides linq expression parser to create unique unique cache key based on query expression
    /// Modified by Greg Hardin to work with .Net Core
    /// </summary>
    public static class LinqCacheExtensionMethods
    {
        /// <summary>
        /// Returns the result of the query; if possible from the cache, otherwise
        /// the query is materialized and the result cached before being returned.
        /// </summary>
        public static IList<T> FromCacheToList<T>(this IQueryable<T> query, int cacheForSeconds = 1)
        {
            string key = query.GetCacheKey();

            //Get instance of Cache service
            ICache cache = StaticServiceProvider.Instance.GetService<ICache>();

            // try to get the query result from the cache
            var result = cache.Get<List<T>>(key);

            if (result == null)
            {
                // materialize the query
                result = query.ToList();
                cache.Set(key, result, cacheForSeconds);
            }
            return result;
        }

        
        public static async Task<IList<T>> FromCacheToListAsync<T>(this IQueryable<T> query, int cacheForSeconds = 1)
        {
            //Get instance of Cache service
            ICache cache = StaticServiceProvider.Instance.GetService<ICache>();

            string key = query.GetCacheKey();

            // try to get the query result from the cache
            var result = cache.Get<List<T>>(key);

            if (result == null)
            {
                // materialize the query
                result = await query.ToListAsync();

                cache.Set(key, result, cacheForSeconds);
            }

            return result;
        }

        public static T FromCacheFirstOrDefault<T>(this IQueryable<T> query, int cacheForSeconds = 1)
        {
            string key = query.GetCacheKey();

            //Get instance of Cache service
            ICache cache = StaticServiceProvider.Instance.GetService<ICache>();

            // try to get the query result from the cache
            var result = cache.Get<T>(key);

            if (result == null)
            {
                // materialize the query
                result = query.FirstOrDefault();

                cache.Set(key, result, cacheForSeconds);
            }

            return result;
        }

        public static async Task<T> FromCacheFirstOrDefaultAsync<T>(this IQueryable<T> query, int cacheForSeconds = 1)
        {
            string key = query.GetCacheKey();

            //Get instance of Cache service
            ICache cache = StaticServiceProvider.Instance.GetService<ICache>();

            // try to get the query result from the cache
            var result = cache.Get<T>(key);

            if (result == null)
            {
                // materialize the query
                result = await query.FirstOrDefaultAsync();

                cache.Set(key, result, cacheForSeconds);
            }
            return result;
        }

        public static string GetCacheKey(this IQueryable query)
        {
            var expression = query.Expression;

            // locally evaluate as much of the query as possible
            expression = Evaluator.PartialEval(expression, CanBeEvaluatedLocally);

            // support local collections
            expression = LocalCollectionExpander.Rewrite(expression);

            // use the string representation of the expression for the cache key
            string key = expression.ToString();

            // the key is potentially very long, so use an md5 fingerprint
            // (fine if the query result data isn't critically sensitive)
            key = key.ToMd5Fingerprint();

            return key;
        }  

        static Func<Expression, bool> CanBeEvaluatedLocally
        {
            get
            {
                return expression =>
                {
                    // don't evaluate parameters
                    if (expression.NodeType == System.Linq.Expressions.ExpressionType.Parameter)
                        return false;

                    // can't evaluate queries
                    if (typeof(IQueryable).IsAssignableFrom(expression.Type))
                        return false;

                    return true;
                };
            }
        }

    }

}