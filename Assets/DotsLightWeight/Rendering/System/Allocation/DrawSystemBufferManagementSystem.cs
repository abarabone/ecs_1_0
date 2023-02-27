using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using UnityEngine;
using Unity.Entities;
using Unity.Jobs;
using Unity.Collections;
using Unity.Burst;
using Unity.Mathematics;
using Unity.Transforms;
using Unity.Physics;
using Unity.Physics.Systems;
using UnityEngine.InputSystem;
using Unity.Collections.LowLevel.Unsafe;

using Collider = Unity.Physics.Collider;
using SphereCollider = Unity.Physics.SphereCollider;

using DotsLite.Memory;
//using DotsLite.Utilities;
//using DotsLite.SystemGroup;

namespace DotsLite.Draw
{

    //[DisableAutoCreation]
    [UpdateInGroup(typeof(SystemGroup.Presentation.Render.DrawPrev))]
    public partial struct DrawSystemBufferManagementSystem : ISystem
    {

        public void OnCreate(ref SystemState state)
        {
            state.Enabled = false;

            foreach (var (buf, info) in SystemAPI.Query<
                DrawSystem.GraphicTransformBufferData,
                DrawSystem.BufferInfoData>())
            {
                var stride = Marshal.SizeOf(typeof(float4));

                buf.Transforms = new GraphicsBuffer(
                    GraphicsBuffer.Target.Structured,
                    //GraphicsBuffer.UsageFlags.LockBufferForWrite,
                    info.VectorLength,
                    stride);
            }

            foreach (var (buf, info) in SystemAPI.Query<
                RefRW<DrawSystem.NativeTransformBufferData>,
                DrawSystem.BufferInfoData>()
                .WithNone<DrawSystem.TransformBufferUseTempJobTag>())
            {
                buf.ValueRW.Transforms = new UnsafeList<float4>(
                    info.VectorLength,
                    Allocator.Persistent,
                    NativeArrayOptions.UninitializedMemory);
            }

            //foreach (var (buf, info) in SystemAPI.Query<
            //    RefRW<DrawSystem.SortingNativeTransformBufferData>,
            //    DrawSystem.BufferInfoData>())
            //{
            //    buf.ValueRW.Transforms = new UnsafeList<float4>(
            //        info.VectorLength,
            //        Allocator.Persistent,
            //        NativeArrayOptions.UninitializedMemory);
            //}
        }



        public void OnUpdate(ref SystemState state)
        { }



        public void OnDestroy(ref SystemState state)
        {
            foreach (var buf in
                SystemAPI.Query<DrawSystem.GraphicTransformBufferData>())
            {
                buf.Transforms?.Dispose();
            }

            foreach (var buf in
                SystemAPI.Query<
                    RefRW<DrawSystem.NativeTransformBufferData>>()
                    .WithNone<DrawSystem.TransformBufferUseTempJobTag>())
            {
                buf.ValueRW.Transforms.Dispose();
            }

            //foreach (var buf in
            //    SystemAPI.Query<RefRW<DrawSystem.SortingNativeTransformBufferData>>())
            //{
            //    buf.ValueRW.Transforms.Dispose();
            //}
        }
        //public void OnDestroy(ref SystemState state)
        //{
        //    disposeTransformComputeBuffer_(ref state);
        //    disposeTransformNativeBuffer_();
        //    disposeSortNativeBuffer_();
        //    return;

        //    [MethodImpl(MethodImplOptions.AggressiveInlining)]
        //    static void disposeTransformComputeBuffer_(ref SystemState state)
        //    {
        //        foreach (var buf in
        //            SystemAPI.Query<DrawSystem.GraphicTransformBufferData>())
        //        {
        //            buf.Transforms?.Dispose();
        //        }
        //    }

        //    void disposeTransformNativeBuffer_()
        //    {
        //        foreach (var buf in
        //            SystemAPI.Query<RefRW<DrawSystem.NativeTransformBufferData>>())
        //        {
        //            buf.ValueRW.Transforms.Dispose();
        //        }
        //    }

        //    void disposeSortNativeBuffer_()
        //    {
        //        foreach (var buf in
        //            SystemAPI.Query<RefRW<DrawSystem.SortingNativeTransformBufferData>>())
        //        {
        //            buf.ValueRW.Transforms.Dispose();
        //        }
        //    }
        //}


    }
}
