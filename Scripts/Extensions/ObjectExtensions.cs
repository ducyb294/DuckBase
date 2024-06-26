namespace TheOneStudio.DuckBase.Scripts.Extensions
{
    using System.Collections.Generic;

    public static class ObjectExtensions
    {
        public static bool DeepEquals<T>(this IEnumerable<T> obj, IEnumerable<T> another)
        {
            if (ReferenceEquals(obj, another)) return true;
            if ((obj == null) || (another == null)) return false;

            var       result      = true;
            using var enumerator1 = obj.GetEnumerator();
            using var enumerator2 = another.GetEnumerator();
            while (true)
            {
                var hasNext1 = enumerator1.MoveNext();
                var hasNext2 = enumerator2.MoveNext();

                if (hasNext1 != hasNext2 || !enumerator1.Current.DeepEquals(enumerator2.Current))
                {
                    result = false;

                    break;
                }

                if (!hasNext1) break;
            }

            return result;
        }

        public static bool DeepEquals(this object obj, object another)
        {
            if (ReferenceEquals(obj, another)) return true;
            if ((obj == null) || (another == null)) return false;
            if (obj.GetType() != another.GetType()) return false;

            if (!obj.GetType().IsClass) return obj.Equals(another);

            var result = true;
            foreach (var property in obj.GetType().GetProperties())
            {
                var objValue                                   = property.GetValue(obj);
                var anotherValue                               = property.GetValue(another);
                if (!objValue.DeepEquals(anotherValue)) result = false;
            }

            return result;
        }
    }
}