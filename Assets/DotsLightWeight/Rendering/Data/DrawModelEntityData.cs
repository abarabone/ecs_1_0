﻿using System.Collections;
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



    // メッシュごと -----------------------

    static public partial class DrawModel
    {

        //public struct BufferLinkerData : IComponentData
        //{
        //    public Entity BufferEntity;
        //}

        public struct BoneVectorSettingData : IComponentData
        {
            public int VectorLengthInBone;
            public int BoneLength;
        }

        public struct InstanceCounterData : IComponentData
        {
            //public UnsafeList<> InstanceCounter;
            public ThreadSafeCounter<Persistent> InstanceCounter;
        }
        public unsafe struct VectorIndexData : IComponentData
        {
            //public float4* pVectorOffsetPerModelInBuffer;
            public int ModelStartIndex;
            public int OptionalVectorLengthPerInstance;
        }

        public struct BoundingBoxData : IComponentData
        {
            public AABB localBbox;
        }


        public struct SortSettingData : IComponentData
        {
            public SortOrder Order;
        }
        public enum SortOrder
        {
            none,
            acs,    // 奥から
            desc,   // 手前側から
        }


        public struct ExcludeDrawMeshCsTag : IComponentData
        { }


        public class ComputeArgumentsBufferData : IComponentData
        {
            public GraphicsBuffer InstancingArgumentsBuffer;
        }

        public class GeometryData : IComponentData
        {
            public Mesh Mesh;
            public Material Material;
        }

        public struct InitializeTag : IComponentData
        { }
    }

}
