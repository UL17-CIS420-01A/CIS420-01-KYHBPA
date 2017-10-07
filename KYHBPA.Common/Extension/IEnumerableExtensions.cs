namespace KYHBPA
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class LinqExtensions
    {
        /// <summary>
        /// Flattens a tree to a plain enumerable for querying.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="values">Enumeration to work on</param>
        /// <param name="f">Expression that points at the element list to select from</param>
        /// <returns></returns>
        /// <example>
        /// var topics = topicTree.FlattenTree(t=> t.Topics);
        /// </example>
        public static IEnumerable<T> FlattenTree<T>(this IEnumerable<T> values, Func<T, IEnumerable<T>> f) =>
            values.IsEmptyArray() ? values : values.SelectMany(c => f(c).FlattenTree(f)).Concat(values);


        public static string ToConcatenatedString<T>(this IEnumerable<T> values, string separator = ",") =>
            values.IsEmptyArray() ? string.Empty : string.Join(separator, values.Select((o) => o.ToString()));

        public static string ToConcatenatedString<T>(this IEnumerable<T> values, char separator) =>
            values?.ToConcatenatedString(separator.ToString());

        public static bool LengthIs<T>(this IEnumerable<T> values, long length) => !values.IsNull() && values.LongCount() == length;

        public static bool IsEmptyArray<T>(this IEnumerable<T> values) => values.IsNull() || values.LengthIs(0);
    }
}