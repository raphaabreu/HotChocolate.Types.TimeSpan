using System;
using HotChocolate.Types;

namespace HotChocolate
{
    public static class TimeSpanSchemaBuilderExtensions
    {
        public static ISchemaBuilder AddTimeSpanScalar(this ISchemaBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            return builder.AddType(typeof(TimeSpanType));
        }
    }
}
