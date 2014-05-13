﻿using OpenTK;
using OpenTK.Graphics.OpenGL;
using SphFluid.Core.Buffers;

namespace SphFluid.Core.Shapes
{
    public abstract class TexturedShape
        : Shape
    {
        public Vector2[] TexCoords { get; protected set; }
        public Vbo<Vector2> TexCoordBuffer { get; protected set; }

        public override void UpdateBuffers()
        {
            base.UpdateBuffers();
            TexCoordBuffer = new Vbo<Vector2>();
            TexCoordBuffer.Init(BufferTarget.ArrayBuffer, TexCoords);
        }
    }
}