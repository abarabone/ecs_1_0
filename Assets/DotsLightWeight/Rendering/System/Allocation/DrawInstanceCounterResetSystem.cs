using Unity.Entities;

namespace DotsLite.Draw
{
    using DotsLite.Memory;

    ////[UpdateBefore( typeof( DrawCullingSystem ) )]
    ////[UpdateInGroup(typeof( SystemGroup.Presentation.DrawModel.DrawPrevSystemGroup))]
    [UpdateInGroup(typeof(SystemGroup.Presentation.Render.DrawPrev.ResetCounter))]
    //public partial class DrawInstanceCounterResetSystem : SystemBase
    public partial struct DrawInstanceCounterResetSystem : ISystem
    {

        public void OnStartRunning(ref SystemState state)
        {
            foreach((var a, ref var b) in
                SystemAPI.Query<DrawModel.InstanceCounterData, RefRW<DrawModel.SortSettingData>>())
            {
                
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
