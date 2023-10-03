using DotNetStarter.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;

namespace DotNetStarter.Extensions
{
    public static class IQueryableExtensions
    {
        public static IQueryable<TEntity> OrderBy<TEntity>(this IQueryable<TEntity> @this, string? orderBy)
            where TEntity : BaseEntity
        {
            if (string.IsNullOrEmpty(orderBy))
            {
                return @this;
            }

            var pairs = orderBy
                .Split(';', StringSplitOptions.RemoveEmptyEntries)
                .Select(stringPair =>
                {
                    var arrayPair = stringPair.Split(",");
                    var propertyName = arrayPair[0];

                    var sortOrder = SortOrder.Unspecified;
                    if (arrayPair.Length > 1)
                    {
                        Enum.TryParse(arrayPair[1], true, out sortOrder);
                    }

                    return (propertyName, sortOrder);
                })
                .Where(pair => typeof(TEntity).GetProperty(pair.propertyName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.IgnoreCase) != null)
                .ToList();

            foreach (var pair in pairs.Select((value, index) => new { index, value }))
            {
                if (pair.value.sortOrder == SortOrder.Ascending)
                {
                    @this = pair.index == 0
                        ? @this.OrderByPropertyName(pair.value.propertyName)
                        : ((IOrderedQueryable<TEntity>)@this).ThenByPropertyName(pair.value.propertyName);
                }

                if (pair.value.sortOrder == SortOrder.Descending)
                {
                    @this = pair.index == 0
                        ? @this.OrderByPropertyNameDescending(pair.value.propertyName)
                        : ((IOrderedQueryable<TEntity>)@this).ThenByPropertyNameDescending(pair.value.propertyName);
                }
            }

            return @this;
        }

        public static IQueryable<TEntity> IncludeProperties<TEntity>(this IQueryable<TEntity> @this, string? includeProperties)
            where TEntity : BaseEntity
        {
            if (string.IsNullOrEmpty(includeProperties))
            {
                return @this;
            }

            var properties = includeProperties
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Where(property => typeof(TEntity).GetProperty(property, BindingFlags.Instance | BindingFlags.Public | BindingFlags.IgnoreCase) != null)
                .ToList();

            foreach (var includeProperty in properties)
            {
                @this = @this.Include(includeProperty);
            }

            return @this;
        }

        public static IOrderedQueryable<TEntity> OrderByPropertyName<TEntity>(this IQueryable<TEntity> @this, string propertyName)
            where TEntity : BaseEntity => @this.OrderBy(ToLambda<TEntity>(propertyName));

        public static IOrderedQueryable<TEntity> OrderByPropertyNameDescending<TEntity>(this IQueryable<TEntity> @this, string propertyName)
            where TEntity : BaseEntity => @this.OrderByDescending(ToLambda<TEntity>(propertyName));

        public static IOrderedQueryable<TEntity> ThenByPropertyName<TEntity>(this IOrderedQueryable<TEntity> @this, string propertyName)
            where TEntity : BaseEntity => @this.ThenBy(ToLambda<TEntity>(propertyName));

        public static IOrderedQueryable<TEntity> ThenByPropertyNameDescending<TEntity>(this IOrderedQueryable<TEntity> @this, string propertyName)
            where TEntity : BaseEntity => @this.ThenByDescending(ToLambda<TEntity>(propertyName));

        private static Expression<Func<TEntity, object>> ToLambda<TEntity>(string propertyName)
            where TEntity : BaseEntity
        {
            var parameter = Expression.Parameter(typeof(TEntity));
            var property = Expression.Property(parameter, propertyName);
            var propAsObject = Expression.Convert(property, typeof(object));

            return Expression.Lambda<Func<TEntity, object>>(propAsObject, parameter);
        }
    }
}