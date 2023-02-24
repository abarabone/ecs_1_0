using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;
using Unity.Entities;
using Unity.Collections;
using Unity.Transforms;
using Unity.Mathematics;

namespace DotsLite.Draw
{

    public static partial class ShaderBuffer
    {

        /// <summary>
        /// コンバージョン時に作成するソースデータ
        /// </summary>
        public class ConversionSrcData : IComponentData
        {
            public NativeArray<byte> SrcData;
            public int 
            public int NameId;
        }

        /// <summary>
        /// グラフィックバッファ
        /// </summary>
        public class BufferData : IComponentData
        {
            public GraphicsBuffer Buffer;
            public int NameId;
        }

    }


    /// <summary>
    /// draw model 向け　カラーパレット関係のデータ
    /// </summary>
    public static partial class DrawMode
    {
        /// <summary>
        /// カラーパレットのグラフィックバッファへのリンク
        /// </summary>
        public class ColorPaletteLinkData : IComponentData
        {
            public Entity ShaderBufferEntity;
        }

        /// <summary>
        /// ＵＶパレットのグラフィックバッファへのリンク
        /// </summary>
        public class UvPaletteLinkData : IComponentData
        {
            public Entity ShaderBufferEntity;
        }
    }
}
