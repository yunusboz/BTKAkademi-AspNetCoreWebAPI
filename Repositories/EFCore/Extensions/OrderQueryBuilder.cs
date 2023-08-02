using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore.Extensions
{
    public static class OrderQueryBuilder
    {
        public static String CreateOrderQuery<T>(String orderByQueryString)
        {
            // Kullanıcının orderBy query'si ile gönderdiği değerleri orderParams arrayine taşıyor.
            // Query Ex: books?orderBy=title, price desc, id asc -> orderParams[] = [title,price desc,id asc]
            var orderParams = orderByQueryString.Trim().Split(',');

            // T içerisinde verilen sınıfın Public ve Instance olan property bilgilerini alıyor.
            var propertyInfos = typeof(T)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance);

            var orderQueryBuilder = new StringBuilder();

            // after foreach -> title asceding, price descending, id ascending,
            foreach (var param in orderParams)
            {
                if (string.IsNullOrWhiteSpace(param))
                    continue;
                // orderParams[] = [title,price desc,id asc] -> title,price,id
                var propertyFromQueryName = param.Split(' ')[0];

                // Query'den gelen string ile objenin ilişkilendirilir ve objectProperty'e atanır.
                var objectProperty = propertyInfos
                    .FirstOrDefault(pi => pi.Name.Equals(propertyFromQueryName,
                    StringComparison.InvariantCultureIgnoreCase));

                if (objectProperty is null)
                    continue;

                var direction = param.EndsWith(" desc") ? "descending" : "ascending";

                orderQueryBuilder.Append($"{objectProperty.Name.ToString()} {direction},");

            }

            var orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');

            return orderQuery;
        }
    }
}
