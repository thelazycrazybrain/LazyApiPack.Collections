namespace LazyApiPack.Collections.Extensions
{
    /// <summary>
    /// Provides extensions for Arrays
    /// </summary>
    public static class ArrayExtensions
    {
        /// <summary>
        /// Adds a list of items to a given array.
        /// </summary>
        /// <typeparam name="TSource">Type of the items.</typeparam>
        /// <param name="source">Source array.</param>
        /// <param name="elements">Items that will be added.</param>
        public static TSource[] Append<TSource>(this TSource[] source, TSource[] elements)
        {
            if (elements == null || elements.Length == 0) return source;
            var newLength = source.Length + elements.Length;
            var previousLength = source.Length;
            Array.Resize(ref source, newLength);
            for (int s = previousLength, t = 0; s < newLength; s++, t++)
            {
                source[s] = elements[t];
            }
            return source;
        }

        /// <summary>
        /// Inserts a list of new items at a given index and resizes the array.
        /// </summary>
        /// <typeparam name="TSource">Type of the items.</typeparam>
        /// <param name="source">Source array.</param>
        /// <param name="elements">New items.</param>
        /// <param name="index">Index at which the items will be inserted.</param>
        public static TSource[] Insert<TSource>(this TSource[] source, TSource[] elements, int index)
        {
            if (elements == null || elements.Length == 0) return source;
            if (index < 0 || index > source.Length)
            {
                throw new IndexOutOfRangeException("Index is not within the sources range.");
            }

            var target = new TSource[source.Length + elements.Length];

            for (int i = 0; i < index; i++)
            {
                target[i] = source[i];
            }

            for (int i = index, j = 0; j < elements.Length; i++, j++)
            {
                target[i] = elements[j];
            }
            for (int i = index + elements.Length, j = index; i < target.Length; i++, j++)
            {
                target[i] = source[j];
            }

            return target;
        }

        /// <summary>
        /// Removes n items from start index and resizes the array.
        /// </summary>
        /// <param name="source">Source array</param>
        /// <param name="startIndex">Start index</param>
        /// <param name="length">Amount of items that will be removed.</param>
        public static TSource[] RemoveRange<TSource>(this TSource[] source, int startIndex, int length)
        {

            var target = new TSource[source.Length - length];
            for (int i = 0; i < startIndex; i++)
            {
                target[i] = source[i];
            }
            for (int i = startIndex + length, j = startIndex; i < source.Length; i++, j++)
            {
                target[j] = source[i];
            }

            return target;
        }

    }
}