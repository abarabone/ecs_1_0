using Unity.Entities;
using System.Runtime.CompilerServices;

namespace DotsLite.Draw
{
    using DotsLite.Memory;
    using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

    //// こういうの作ったけどコンパイルエラーでダメだった
    //public static class RefRwUtility
    //{
    //    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    //    public static ref T rw<T>(this RefRW<T> v) where T : struct, IComponentData => ref v.ValueRW;

    //    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    //    public static T ro<T>(this RefRW<T> v) where T : struct, IComponentData => v.ValueRO;
    //}

    ////[UpdateBefore( typeof( DrawCullingSystem ) )]
    ////[UpdateInGroup(typeof( SystemGroup.Presentation.DrawModel.DrawPrevSystemGroup))]
    [UpdateInGroup(typeof(SystemGroup.Presentation.Render.DrawPrev.ResetCounter))]
    //public partial class DrawInstanceCounterResetSystem : SystemBase
    public partial struct DrawInstanceCounterResetSystem : ISystem
    {

        public void OnStartRunning(ref SystemState state)
        {
            foreach(var counter in SystemAPI.Query<
                RefRW<DrawModel.InstanceCounterData>>())
            {
                counter.ValueRW.InstanceCounter = new ThreadSafeCounter<Persistent>(0);
            }
            //this.Entities
            //    .ForEach(
            //        ( ref DrawModel.InstanceCounterData counter ) =>
            //        {
            //            counter.InstanceCounter = new ThreadSafeCounter<Persistent>(0);
            //        }
            //    );
        }

        public void OnUpdate(ref SystemState state)
        {
            foreach(var counter in SystemAPI.Query<
                RefRW<DrawModel.InstanceCounterData>>())
            {
                counter.ValueRW.InstanceCounter.Reset();
            }
            //this.Entities
            //    .ForEach(
            //        ( ref DrawModel.InstanceCounterData counter ) =>
            //        {
            //            counter.InstanceCounter.Reset();
            //        }
            //    );

        }

        public void OnDestroy(ref SystemState state)
        {
            foreach(var counter in SystemAPI.Query<
                RefRW<DrawModel.InstanceCounterData>>())
            {
                counter.ValueRW.InstanceCounter.Dispose();
            }
            //this.Entities
            //    .ForEach(
            //        ( ref DrawModel.InstanceCounterData counter ) =>
            //        {
            //            counter.InstanceCounter.Dispose();
            //        }
            //    );
        }

    }

}
