// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.MachineLearning.Models
{
    /// <summary> An enum describing the unit of quota measurement. </summary>
    public readonly partial struct QuotaUnit : IEquatable<QuotaUnit>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="QuotaUnit"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public QuotaUnit(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string CountValue = "Count";

        /// <summary> Count. </summary>
        public static QuotaUnit Count { get; } = new QuotaUnit(CountValue);
        /// <summary> Determines if two <see cref="QuotaUnit"/> values are the same. </summary>
        public static bool operator ==(QuotaUnit left, QuotaUnit right) => left.Equals(right);
        /// <summary> Determines if two <see cref="QuotaUnit"/> values are not the same. </summary>
        public static bool operator !=(QuotaUnit left, QuotaUnit right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="QuotaUnit"/>. </summary>
        public static implicit operator QuotaUnit(string value) => new QuotaUnit(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is QuotaUnit other && Equals(other);
        /// <inheritdoc />
        public bool Equals(QuotaUnit other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
