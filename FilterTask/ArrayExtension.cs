using System;
using System.Collections.Generic;

namespace FilterTask
{
    public static class ArrayExtension
    {
        /// <summary>
        /// Returns new array of elements that contain expected digit from source array.
        /// </summary>
        /// <param name="source">Source array.</param>
        /// <param name="digit">Expected digit.</param>
        /// <returns>Array of elements that contain expected digit.</returns>
        /// <exception cref="ArgumentNullException">Thrown when array is null.</exception>
        /// <exception cref="ArgumentException">Thrown when array is empty.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when digit value is out of range (0..9).</exception>
        /// <example>
        /// {1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17}  => { 7, 70, 17 } for digit = 7.
        /// </example>
        public static int[] FilterByDigit(int[] source, int digit)
        {
            if (source is null)
            {
                throw new ArgumentNullException($"Thrown when array is null. {nameof(source)}");
            }

            if (source.Length == 0)
            {
                throw new ArgumentException($"Thrown when array is empty. {nameof(source)}");
            }

            if (digit < 0 || digit > 9)
            {
                throw new ArgumentOutOfRangeException($"Thrown when digit value is out of range (0..9). {nameof(digit)}");
            }

            List<int> result = new List<int>();
            foreach (var number in source)
            {
                int temp = Math.Abs(number);
                do
                {
                    var rem = temp % 10;
                    temp /= 10;
                    if (rem == digit)
                    {
                        result.Add(number);
                        break;
                    }
                }
                while (temp > 0);
            }

            return result.ToArray();
        }
    }
}
