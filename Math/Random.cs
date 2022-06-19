using System;
using Unity.Mathematics;
using UnityEngine;

namespace Common.Math
{
    public static class Random
    {
        public static double Double(double x, double y)
        {
            return math.clamp(Mathf.PerlinNoise(Convert.ToSingle(x % 100000) * 100.1f, Convert.ToSingle(y % 100000) * 100.1f), 0.00000000000001d, .99999999999999d);
        }

        public static long Long(long x, long y)
        {
            var result = Double(x % 1000000000000000, y % 1000000000000000);
            return Convert.ToInt64(result * long.MaxValue);
        }
    }
}