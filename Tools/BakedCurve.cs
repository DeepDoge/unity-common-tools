using System;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace Game.Util
{
    public partial struct BakedCurve : IDisposable
    {
        private const int Size = 512;
        private BlobAssetReference<BlobArray<float>> _curveSamples;

        public BakedCurve(AnimationCurve animationCurve)
        {
            using var builder = new BlobBuilder(Allocator.Temp);
            ref var ptr = ref builder.ConstructRoot<BlobArray<float>>();
            var array = builder.Allocate(ref ptr, Size);

            for (var i = 0; i < Size; i++)
                array[i] = animationCurve.Evaluate(Convert.ToSingle(i) / Size);

            _curveSamples = builder.CreateBlobAssetReference<BlobArray<float>>(Allocator.Persistent);
        }

        public float Evaluate(float x)
        {
            ref var curve = ref _curveSamples.Value;
            return curve[Convert.ToInt32(math.clamp(x, 0, 1) * (Size - 1))];
        }

        public void Dispose()
        {
            _curveSamples.Dispose();
        }
    }
}