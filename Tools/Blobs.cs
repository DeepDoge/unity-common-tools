using Unity.Entities;

namespace Game
{
    public static class Overwrites
    {
        public static bool Contains<T>(this BlobArray<T> buffer, T thing) where T : struct
        {
            for (var i = 0; i < buffer.Length; i++)
                if (buffer[i].Equals(thing))
                    return true;

            return false;
        }
    }
}