using System;
using HotChocolate.Types;

namespace HotChocolate
{
    public static class TimeSpanSchemaBuilderExtensions
    {
        /// <summary>
        /// Add the <see cref="TimeSpanType"/> scalar to the schema builder.
        /// </summary>
        /// <param name="builder">The schema builder.</param>
        /// <returns>The schema builder.</returns>
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
