using System;
using Unity.Mathematics;

namespace Common.Math
{
    public static class Random
    {
        public static double Double(double x, double y)
        {
            return math.frac(math.sin(math.dot(new double2(x, y), new double2(12.9898, 78.233))) * 43758.5453);
        }
        public static long Long(long x, long y)
        {
            return Convert.ToInt64(Double(x % 1000000000000000, y % 1000000000000000) * long.MaxValue);
        }
    }
}