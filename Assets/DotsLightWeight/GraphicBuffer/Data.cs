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
        /// �R���o�[�W�������ɍ쐬����\�[�X�f�[�^
        /// </summary>
        public class ConversionSrcData : IComponentData
        {
            public NativeArray<byte> SrcData;
            public int 
            public int NameId;
        }

        /// <summary>
        /// �O���t�B�b�N�o�b�t�@
        /// </summary>
        public class BufferData : IComponentData
        {
            public GraphicsBuffer Buffer;
            public int NameId;
        }

    }


    /// <summary>
    /// draw model �����@�J���[�p���b�g�֌W�̃f�[�^
    /// </summary>
    public static partial class DrawMode
    {
        /// <summary>
        /// �J���[�p���b�g�̃O���t�B�b�N�o�b�t�@�ւ̃����N
        /// </summary>
        public class ColorPaletteLinkData : IComponentData
        {
            public Entity ShaderBufferEntity;
        }

        /// <summary>
        /// �t�u�p���b�g�̃O���t�B�b�N�o�b�t�@�ւ̃����N
        /// </summary>
        public class UvPaletteLinkData : IComponentData
        {
            public Entity ShaderBufferEntity;
        }
    }
}
