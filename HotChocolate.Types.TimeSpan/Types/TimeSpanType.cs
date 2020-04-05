using System;
using System.Globalization;
using HotChocolate.Language;

namespace HotChocolate.Types
{
    /// <summary>
    /// The `TimeSpan` scalar type represents a period of time represented in the format `[-][d.]hh:mm:ss[.fffffff]`.
    /// </summary>
    public class TimeSpanType : ScalarType
    {
        public TimeSpanType() : base("TimeSpan")
        {
            Description =
                "The `TimeSpan` scalar type represents a period of time represented in the format `[-][d.]hh:mm:ss[.fffffff]`.";
        }

        /// <inheritdoc />
        public override bool IsInstanceOfType(IValueNode literal)
        {
            if (literal == null)
            {
                throw new ArgumentNullException(nameof(literal));
            }

            return literal is StringValueNode || literal is NullValueNode;
        }

        /// <inheritdoc />
        public override object ParseLiteral(IValueNode literal)
        {
            if (literal == null)
            {
                throw new ArgumentNullException(nameof(literal));
            }

            if (literal is NullValueNode)
            {
                return null;
            }

            if (literal is StringValueNode stringLiteral)
            {
                return TimeSpan.ParseExact(stringLiteral.Value, "c", CultureInfo.InvariantCulture);
            }

            throw new ArgumentException(
                "The TimeSpanType can only parse string literals formatted as `[-][d.]hh:mm:ss[.fffffff]`.",
                nameof(literal));
        }

        /// <inheritdoc />
        public override IValueNode ParseValue(object value)
        {
            if (value == null)
            {
                return new NullValueNode(null);
            }

            if (value is TimeSpan t)
            {
                return new StringValueNode(null, t.ToString("c", CultureInfo.InvariantCulture), false);
            }

            throw new ArgumentException(
                "The specified value has to be a TimeSpan in order to be parsed by the TimeSpanType.");
        }

        /// <inheritdoc />
        public override object Serialize(object value)
        {
            if (value == null)
            {
                return null;
            }

            if (value is TimeSpan t)
            {
                return t.ToString("c", CultureInfo.InvariantCulture);
            }

            throw new ArgumentException(
                "The specified value cannot be serialized by the TimeSpanType.");
        }

        /// <inheritdoc />
        public override bool TryDeserialize(object serialized, out object value)
        {
            if (serialized is null)
            {
                value = null;
                return true;
            }

            if (serialized is string s)
            {
                var result = TimeSpan.TryParseExact(s, "c", CultureInfo.InvariantCulture, out var ts);
                value = ts;
                return result;
            }

            value = null;
            return false;
        }

        /// <inheritdoc />
        public override Type ClrType => typeof(TimeSpan);
    }
}
