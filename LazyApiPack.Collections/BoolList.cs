using LazyApiPack.Collections.Extensions;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazyApiPack.Collections
{
    /// <summary>
    /// List of named booleans.
    /// </summary>
    public struct BoolList
    {
        public BoolList()
        {
            _bools = new Dictionary<string, bool>();
            Mode = BoolListMode.AllTrue;
        }
        public BoolList(BoolListMode mode) : this()
        {
            Mode = mode;
        }

        private readonly Dictionary<string, bool> _bools;

        /// <summary>
        /// Adds, Upserts or gets the value of the bool item.
        /// </summary>
        /// <param name="key">Name of the bool item.</param>
        /// <returns>Value of the item with the given key (Or KeyNotFoundException).</returns>
        public bool this[string key]
        {
            get => _bools[key];
            set => _bools.Upsert(key, value);
        }

        public BoolListMode Mode { get; set; }
        /// <summary>
        /// Gets the value (Unary operators are also supported).
        /// </summary>
        public bool Value
        {
            get => Mode switch
            {
                BoolListMode.AllTrue => _bools.All(b => b.Value),
                BoolListMode.AtLeastOneTrue => _bools.ContainsValue(true),
                BoolListMode.ExactlyOneTrue => _bools.Count(b => b.Value) == 1,
                _ => throw new NotSupportedException($"{Mode} is not supported."),
            };
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Value: {Value}");
            sb.AppendLine($"Mode: {Mode}");
            sb.AppendLine("Values:");
            foreach (var item in _bools)
            {
                sb.AppendLine($"{item.Key}: {item.Value}");
            }
            return sb.ToString();
        }




        public static bool operator ==(BoolList a, bool b)
        {
            return a.Value == b;
        }

        public static bool operator !=(BoolList a, bool b)
        {
            return a.Value != b;
        }

        public static bool operator false(BoolList item)
        {
            return !item.Value;
        }
        public static bool operator true(BoolList item)
        {
            return item.Value;
        }

        public static bool operator !(BoolList item)
        {
            return !item.Value;
        }
        public static implicit operator bool(BoolList item) => item.Value;


        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj is bool b)
            {
                return b == Value;
            }
            else if (obj is BoolList bl)
            {
                return bl.Value == Value;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    public enum BoolListMode
    {
        /// <summary>
        /// And.
        /// </summary>
        AllTrue,
        /// <summary>
        /// Or.
        /// </summary>
        AtLeastOneTrue,
        /// <summary>
        /// Xor.
        /// </summary>
        ExactlyOneTrue
    }
}
