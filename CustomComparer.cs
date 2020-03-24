using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Tutorial2
{
    class CustomComparer : IEqualityComparer<Student>
    {
        public bool Equals( Student x,  Student y)
        {
            return StringComparer
                .InvariantCultureIgnoreCase
                .Equals($"{x.Email} {x.StudentIndex} {x.FirstName} {x.LastName}",
                        $"{y.Email} {y.StudentIndex} {y.FirstName} {y.LastName}");
        }

        public int GetHashCode([DisallowNull] Student obj)
        {
            return StringComparer
                .InvariantCultureIgnoreCase
                .GetHashCode($"{obj.Email} {obj.StudentIndex} {obj.FirstName} {obj.LastName}");
        }
    }
}
