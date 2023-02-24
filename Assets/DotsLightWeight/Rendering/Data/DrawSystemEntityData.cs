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
    using DotsLite.Memory;

    //using DotsLite.Misc;

    //// インターフェースでは列挙できない
    ////public interface IPract : IComponentData
    ////{ }
    ////public struct PractData1
    ////{ }
    ////public struct PractData2
    ////{ }
    ////public partial struct PractSystem : ISystem
    ////{
    ////    public void OnStartRunning(ref SystemState state)
    ////    {
    ////        foreach(var c in SystemAPI.Query<IPract>())
    ////        {
    ////            Debug.Log(c);
    ////        }
    ////    }

    ////    public void OnUpdate(ref SystemState state)
    ////    {
    ////    }

    ////    public void OnDestroy(ref SystemState state)
    ////    {
    ////    }
    ////}

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
