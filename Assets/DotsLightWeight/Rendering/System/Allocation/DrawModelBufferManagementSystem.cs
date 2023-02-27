using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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

using Collider = Unity.Physics.Collider;
using SphereCollider = Unity.Physics.SphereCollider;

using DotsLite.Memory;
using Unity.Burst.Intrinsics;
//using DotsLite.Utilities;
//using DotsLite.SystemGroup;

namespace DotsLite.Draw
{

    //[DisableAutoCreation]
    [UpdateInGroup(typeof(SystemGroup.Presentation.Render.DrawPrev))]
    public partial struct DrawModelBufferManagementSystem : ISystem
    {


        public void OnCreate(ref SystemState state)
        {
            state.Enabled = false;

            foreach (var buf in SystemAPI.Query<
                DrawModel.ComputeArgumentsBufferData>())
            {
                buf.InstancingArgumentsBuffer = ComputeShaderUtility.CreateIndirectArgumentsBuffer();
            }
        }



        public void OnUpdate(ref SystemState state)
        { }



        public void OnDestroy(ref SystemState state)
        {
            foreach(var buf in SystemAPI.Query<
                DrawModel.ComputeArgumentsBufferData>())
            {
                buf.InstancingArgumentsBuffer?.Dispose();
            }
        }


    }
}
