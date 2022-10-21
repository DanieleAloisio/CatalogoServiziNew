using CatalogoServizi.Common.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoServizi.Common.Data
{
    /// <summary>
    /// Linq Extensions
    /// </summary>
    public static class LinqExtension
    {
        /// <summary>
        /// Converts to lambda.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns>Expression</returns>
        private static Expression<Func<T, object>> ToLambda<T>(string propertyName)
        {
            var parameter = Expression.Parameter(typeof(T));
            var property = Expression.Property(parameter, propertyName);
            var propAsObject = Expression.Convert(property, typeof(object));

            return Expression.Lambda<Func<T, object>>(propAsObject, parameter);
        }


        /// <summary>
        /// Orders by.
        /// </summary>
        /// <typeparam name="T">Tipo</typeparam>
        /// <param name="source">Source.</param>
        /// <param name="propertyName">Nome della proprietà</param>
        /// <returns>Queryable</returns>
        public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> source, string propertyName)
        {
            return source.OrderBy(ToLambda<T>(propertyName));
        }

        /// <summary>
        /// Order by consecutive
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="source">Source</param>
        /// <param name="propertyName">Property name</param>
        /// <returns></returns>
        public static IOrderedQueryable<T> ThenBy<T>(this IOrderedQueryable<T> source, string propertyName)
        {
            return source.ThenBy(ToLambda<T>(propertyName));
        }

        /// <summary>
        /// Orders by descending
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="source">Source</param>
        /// <param name="propertyName">Property Name</param>
        /// <returns>Queryable</returns>
        public static IOrderedQueryable<T> OrderByDescending<T>(this IQueryable<T> source, string propertyName)
        {
            return source.OrderByDescending(ToLambda<T>(propertyName));
        }

        /// <summary>
        /// Orders Consecutive by descending
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="source">Source</param>
        /// <param name="propertyName">Property name</param>
        /// <returns>Queryable</returns>
        public static IOrderedQueryable<T> ThenByDescending<T>(this IOrderedQueryable<T> source, string propertyName)
        {
            return source.ThenByDescending(ToLambda<T>(propertyName));
        }

        /// <summary>
        /// Order and paging
        /// </summary>
        /// <typeparam name="DataType">Type of Data</typeparam>
        /// <param name="source">Source</param>
        /// <param name="filter">Filter</param>
        /// <returns>Data source</returns>
        public static DataSource<DataType> Filter<DataType>(this IQueryable<DataType> source, DataFilter filter)
            where DataType : class, new()
        {
            if (string.IsNullOrEmpty(filter.SortBy))
            {
                throw new Exception("Sort Column Required");
            }

            source = source.OrderByName(filter.SortBy);

            DataSource<DataType> ds = new()
            {
                RowCount = source.Count(),
                Data = source.Skip(filter.Offset).Take(filter.Limit).ToList()
            };

            return ds;

        }

        /// <summary>
        /// Order and paging async
        /// </summary>
        /// <typeparam name="DataType">Type of Data</typeparam>
        /// <param name="source">Source</param>
        /// <param name="filter">Filter</param>
        /// <returns>Data source</returns>
        public async static Task<DataSource<DataType>> FilterAsync<DataType>(this IQueryable<DataType> source, DataFilter filter) 
            where DataType : class, new()
        {
            if (string.IsNullOrEmpty(filter.SortBy))
            {
                throw new Exception("Sort Column Required");
            }

            source = source.OrderByName(filter.SortBy);

            var c = await source.CountAsync();
            var data = await source.Skip(filter.Offset).Take(filter.Limit).ToListAsync();

            return new DataSource<DataType>
            {
                RowCount = c,
                Data = data
            };
        }


        /// <summary>
        /// Order by column name
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="source">Source</param>
        /// <param name="columnName">Column Name</param>
        /// <returns>IQueryable</returns>
        public static IQueryable<T> OrderByName<T>(this IQueryable<T> source, string columnName)
        {
            var type = typeof(T);

            bool ascending = true;
            var parts = columnName.Trim().Split(" ");
            columnName = parts[0];

            var property = type.GetProperty(columnName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
            if (property == null)
                throw new Exception("Invalid Column");

            var parameter = Expression.Parameter(type, "p");
            var propertyAccess = Expression.MakeMemberAccess(parameter, property);
            var orderByExp = Expression.Lambda(propertyAccess, parameter);

            MethodCallExpression resultExp;

            if (parts.Length > 1 && parts[1].ToUpper() == "DESC")
                ascending = false;

            if (ascending)
                resultExp = Expression.Call(typeof(Queryable), "OrderBy", new Type[] { type, property.PropertyType }, source.Expression, Expression.Quote(orderByExp));
            else
                resultExp = Expression.Call(typeof(Queryable), "OrderByDescending", new Type[] { type, property.PropertyType }, source.Expression, Expression.Quote(orderByExp));

            return source.Provider.CreateQuery<T>(resultExp);


        }

        /// <summary>
        /// Filter by data
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="source">Source</param>
        /// <param name="expression">Expression</param>
        /// <param name="from">From</param>
        /// <param name="to">To</param>
        /// <param name="dateOnly">If true consider only date part</param>
        /// <returns>IQueryable</returns>
        public static IQueryable<T> BetweenDate<T>(this IQueryable<T> source, Expression<Func<T, DateTime>> expression, DateTime? from, DateTime? to, bool dateOnly = false)
        {
            var p = expression.Parameters.Single();
            Expression member = p;

            if (expression.Body is not MemberExpression expressionBody)
                throw new Exception("Invalid");

            Expression dateExpression = Expression.Property(member, expressionBody.Member.Name);

            Expression<Func<T, bool>> predicate;

            if (dateOnly)
            {
                if (from.HasValue)
                    from = from.Value.Date;
                if (to.HasValue)
                    to = to.Value.EndDay();
            }

            if (from.HasValue && to.HasValue)
            {
                BinaryExpression after = Expression.GreaterThanOrEqual(dateExpression, Expression.Constant(from.Value, typeof(DateTime)));
                BinaryExpression before = Expression.LessThanOrEqual(dateExpression, Expression.Constant(to.Value, typeof(DateTime)));
                Expression body = Expression.And(after, before);
                predicate = Expression.Lambda<Func<T, bool>>(body, p);
            }
            else if (from.HasValue)
            {
                BinaryExpression after = Expression.GreaterThanOrEqual(dateExpression, Expression.Constant(from.Value, typeof(DateTime)));
                predicate = Expression.Lambda<Func<T, bool>>(after, p);
            }
            else if (to.HasValue)
            {
                BinaryExpression before = Expression.LessThanOrEqual(dateExpression, Expression.Constant(to.Value, typeof(DateTime)));
                predicate = Expression.Lambda<Func<T, bool>>(before, p);
            }
            else
            {
                return source;
            }

            return source.Where(predicate);
        }

        /// <summary>
        /// Filter by data
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="source">Source</param>
        /// <param name="expression">Expression</param>
        /// <param name="range">Date Range</param>
        /// <param name="dateOnly">If true consider only date part</param>
        /// <returns>IQueryable</returns>
        public static IQueryable<T> BetweenDate<T>(this IQueryable<T> source, Expression<Func<T, DateTime>> expression, DateRange range, bool dateOnly = false)
        {
            if (range == null)
                return source;
            return source.BetweenDate<T>(expression, range.From, range.To, dateOnly);
        }

        /// <summary>
        /// Return begin of a day
        /// </summary>
        /// <param name="date">DateTime</param>
        /// <returns>Date</returns>
        public static DateTime EndDay(this DateTime date)
        {
            return date.Date.AddDays(1).AddSeconds(-1);
        }

        /// <summary>
        /// Return end of day
        /// </summary>
        /// <param name="date">DateTime</param>
        /// <returns>Date</returns>
        public static DateTime? EndDay(this DateTime? date)
        {
            if (date.HasValue)
                return date.Value.Date.AddDays(1).AddSeconds(-1);
            else
                return date;
        }


        /// <summary>
        /// Delete entity based on expression
        /// </summary>
        /// <typeparam name="T">Entity Type</typeparam>
        /// <param name="dbset">DBSet</param>
        /// <param name="expression">Expression</param>
        /// <returns>Number of data removed</returns>
        public static int DeleteRange<T>(this DbSet<T> dbset, Expression<Func<T, bool>> expression) where T : class
        {
            var range = dbset.Where(expression).ToList();
            dbset.RemoveRange(range);
            return range.Count;
        }

        /// <summary>
        /// Update a list of entity based on an expression
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="dbset">DBSet</param>
        /// <param name="expression">Selection Expression</param>
        /// <param name="updateAction">Update Expression</param>
        /// <returns>Number of data removed</returns>
        public static int UpdateRange<T>(this DbSet<T> dbset, Expression<Func<T, bool>> expression, Action<T> updateAction) where T : class
        {
            var range = dbset.Where(expression).ToList();
            range.ForEach(updateAction);
            return range.Count;
        }

        /// <summary>
        /// Clear a relation
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="collection">Collection</param>
        public static void ClearRelation<T>(this ICollection<T> collection)
        {
            collection.ToList().ForEach(i => collection.Remove(i));
        }

        /// <summary>
        /// To Key Value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static IQueryable<KeyValue<int, string>> ToKeyValue<T>(this ICollection<T> source, Expression<Func<T, KeyValue<int, string>>> expression)
        {
            return source.AsQueryable().Select(expression);
        }

        /// <summary>
        /// To Key Value
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="source">Source</param>
        /// <param name="expression">Expression</param>
        /// <returns>Result</returns>
        public static IQueryable<KeyValue<int, string>> ToKeyValue<T>(this IQueryable<T> source, Expression<Func<T, KeyValue<int, string>>> expression)
        {
            return source.Select(expression);
        }

    }
}
