using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Collections;
using Unity.Mathematics;
using Unity.Transforms;
using System.Runtime.InteropServices;
using Unity.Collections.LowLevel.Unsafe;

namespace DotsLite.Draw.Authoring
{
    public class DrawTransformBufferDefineAuthoring : MonoBehaviour
    {

        public int TransformBufferMaxVectorLength;

        public bool UseTempJobNativeBuffer;// コンピュートバッファーは TransformBufferMaxVectorLength 固定なのでいまいち感ある
        public bool UseDrawInstanceSort;

    }

    public class DrawTransformBufferDefineAuthoringBaker : Baker<DrawTransformBufferDefineAuthoring>
    {
        public override void Bake(DrawTransformBufferDefineAuthoring authoring)
        {
            //if (!this.isActiveAndEnabled) { conversionSystem.DstEntityManager.DestroyEntity(entity); return; }

            initEntity_(this, authoring.UseTempJobNativeBuffer, authoring.UseDrawInstanceSort);

            //initNativeBufferComponent_(entity, dstManager, this.TransformBufferMaxVectorLength, this.UseTempJobNativeBuffer);

            //initComputeBufferComponent_(entity, dstManager, this.TransformBufferMaxVectorLength);

            //initSortingBufferComponent_(entity, dstManager, this.TransformBufferMaxVectorLength, this.UseTempJobNativeBuffer, this.UseDrawInstanceSort);
            
            return;


            static void initEntity_(IBaker baker,bool useTempBuffer, bool useSort)
            {
                baker.AddTransformUsageFlags(TransformUsageFlags.ManualOverride);


                var types = new FixedList128Bytes<ComponentType>
                {
                    typeof(DrawSystem.GraphicTransformBufferData),
                    typeof(DrawSystem.NativeTransformBufferData),
                    typeof(DrawSystem.TransformBufferInfoData)// temp buffer では現状不要（毎フレームで使用分しか確保しないため）
                };
                if (useTempBuffer) types.Add(typeof(DrawSystem.TransformBufferUseTempJobTag));
                //if (!useTempBuffer) types.Add(typeof(DrawSystem.TransformBufferInfoData));
                if (useSort) types.Add(typeof(DrawSystem.SortingNativeTransformBufferData));

                baker.AddComponent(new ComponentTypeSet(types));
            }

            //static void initNativeBufferComponent_(
            //    Entity ent, EntityManager em, int vectorLength, bool useTempBuffer)
            //{
            //    if (useTempBuffer) return;

            //    em.SetComponentData(ent,
            //        new DrawSystem.NativeTransformBufferData
            //        {
            //            Transforms = new SimpleNativeBuffer<float4>(vectorLength, Allocator.Persistent),
            //        }
            //    );
            //}

            //static void initComputeBufferComponent_(Entity ent, EntityManager em, int vectorLength)
            //{
            //    var stride = Marshal.SizeOf(typeof(float4));

            //    em.SetComponentData(ent,
            //        new DrawSystem.ComputeTransformBufferData
            //        {
            //            Transforms = new ComputeBuffer
            //                (vectorLength, stride, ComputeBufferType.Default, ComputeBufferMode.Immutable),
            //        }
            //    );
            //}

            //static void initSortingBufferComponent_(
            //    Entity ent, EntityManager em, int vectorLength, bool useTempBuffer, bool useSort)
            //{
            //    if (!useSort) return;
            //    if (useTempBuffer) return;

            //    em.SetComponentData(ent,
            //        new DrawSystem.SortingNativeTransformBufferData
            //        {
            //            Transforms = new SimpleNativeBuffer<float4>(vectorLength, Allocator.Persistent)
            //        }
            //    );
            //}

        }
    }
}