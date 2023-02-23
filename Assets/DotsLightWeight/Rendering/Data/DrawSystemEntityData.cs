using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Jobs;
using Unity.Mathematics;
using Unity.Collections;
using Unity.Jobs;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Transforms;
//using Unity.Rendering;
using Unity.Properties;
using Unity.Burst;
using System.Runtime.InteropServices;
using System;

namespace DotsLite.Draw
{

    using DotsLite.Geometry;
    //using DotsLite.Misc;



    // シングルトン -----------------------

    static public partial class DrawSystem
    {
        public class GraphicTransformBufferData : IComponentData
        {
            public ComputeBuffer Transforms;
        }

        [ChunkSerializable]
        public struct NativeTransformBufferData : IComponentData
        {
            public UnsafeList<float4> Transforms;
            //public SimpleNativeBuffer<float4> Transforms;
        }

        public struct TransformBufferInfoData : IComponentData
        {
            public int CurrentVectorLength;
        }


        public struct TransformBufferUseTempJobTag : IComponentData
        { }


        [ChunkSerializable]
        public struct SortingNativeTransformBufferData : IComponentData
        {
            public UnsafeList<float4> Transforms;
            //public SimpleNativeBuffer<float4> Transforms;
        }
    }

}
