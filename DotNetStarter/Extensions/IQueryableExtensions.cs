using DotNetStarter.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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
                .Where(pair => typeof(TEntity).GetProperty(pair.propertyName) != null)
                .ToList();

            foreach (var pair in pairs)
            {
                if (pair.sortOrder == SortOrder.Ascending)
                {
                    @this = @this.OrderByPropertyName(pair.propertyName);
                }

                if (pair.sortOrder == SortOrder.Descending)
                {
                    @this = @this.OrderByPropertyNameDescending(pair.propertyName);
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
                .Where(property => typeof(TEntity).GetProperty(property) != null)
                .ToList();

            foreach (var includeProperty in properties)
            {
                @this = @this.Include(includeProperty);
            }

            return @this;
        }

        public static IOrderedQueryable<TEntity> OrderByPropertyName<TEntity>(this IQueryable<TEntity> @this, string propertyName)
            where TEntity : BaseEntity
        {
            return @this.OrderBy(ToLambda<TEntity>(propertyName));
        }

        public static IOrderedQueryable<TEntity> OrderByPropertyNameDescending<TEntity>(this IQueryable<TEntity> @this, string propertyName)
            where TEntity : BaseEntity
        {
            return @this.OrderByDescending(ToLambda<TEntity>(propertyName));
        }

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