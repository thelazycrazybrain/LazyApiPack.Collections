using System.Diagnostics.CodeAnalysis;

namespace LazyApiPack.Collections.Extensions
{
    /// <summary>
    /// Provdies extensions for collections 
    /// </summary>
    public static class CollectionExtensions
    {
        /// <summary>
        /// Updates the target list only with new items form list. 
        /// </summary>
        /// <param name="target">The target list.</param>
        /// <param name="source">The list that is added to target</param>
        public static void Upsert<T>(this IList<T> target, IEnumerable<T> source)
        {
            if (source == null || !source.Any()) return;

            var unique = source.Except(target);
            if (!unique.Any()) return;

            foreach (var item in unique)
            {
                target.Add(item);
            }
        }

    }
}