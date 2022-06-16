using Unity.Mathematics;

namespace Common.Math
{
    public static class Random
    {
        public static double RandomDouble(double2 input)
        {
            return math.frac(math.sin(math.dot(input.xy, new double2(12.9898, 78.233))) * 43758.5453);
        }

        public static double RandomDouble(double x, double y)
        {
            return RandomDouble(new double2(x, y));
        }
    }
}