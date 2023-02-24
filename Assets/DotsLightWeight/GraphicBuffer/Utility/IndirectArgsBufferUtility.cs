using UnityEngine;
using Unity.Collections;
using System;
using System.Runtime.CompilerServices;

namespace DotsLite.Draw
{

    static public class ComputeShaderUtility
    {



        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static public GraphicsBuffer CreateIndirectArgumentsBuffer() =>
            new GraphicsBuffer(
                GraphicsBuffer.Target.IndirectArguments,
                //GraphicsBuffer.UsageFlags.LockBufferForWrite,
                1,
                sizeof(uint) * 5);

    }


    public struct IndirectArgumentsForInstancing
    {
        public uint MeshIndexCount;
        public uint InstanceCount;
        public uint MeshBaseIndex;
        public uint MeshBaseVertex;
        public uint BaseInstance;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IndirectArgumentsForInstancing(
            Mesh mesh, int instanceCount = 0, int submeshId = 0, int baseInstance = 0)
        {
            //if( mesh == null ) return;

            this.MeshIndexCount = mesh.GetIndexCount(submeshId);
            this.InstanceCount = (uint)instanceCount;
            this.MeshBaseIndex = mesh.GetIndexStart(submeshId);
            this.MeshBaseVertex = mesh.GetBaseVertex(submeshId);
            this.BaseInstance = (uint)baseInstance;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public NativeArray<uint> ToNativeArray(Allocator allocator)
        {
            var arr = new NativeArray<uint>(5, allocator);
            arr[0] = this.MeshIndexCount;
            arr[1] = this.InstanceCount;
            arr[2] = this.MeshBaseIndex;
            arr[3] = this.MeshBaseVertex;
            arr[4] = this.BaseInstance;
            return arr;
        }
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public void WriteTo(NativeArray<uint> arr)
        //{
        //    arr[0] = this.MeshIndexCount;
        //    arr[1] = this.InstanceCount;
        //    arr[2] = this.MeshBaseIndex;
        //    arr[3] = this.MeshBaseVertex;
        //    arr[4] = this.BaseInstance;
        //}
    }

    static public class IndirectArgumentsExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static public GraphicsBuffer SetData(
            this GraphicsBuffer cbuf,
            ref IndirectArgumentsForInstancing args)
        {
            using var nativebuf = args.ToNativeArray(Allocator.Temp);

            cbuf.SetData(nativebuf);

            return cbuf;
        }
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //static public GraphicsBuffer SetData(
        //    this GraphicsBuffer cbuf,
        //    ref IndirectArgumentsForInstancing args)
        //{
        //    var na = cbuf.LockBufferForWrite<uint>(0, 5);
        //    args.WriteTo(na);
        //    cbuf.UnlockBufferAfterWrite<uint>(5);

        //    return cbuf;
        //}
    }


}