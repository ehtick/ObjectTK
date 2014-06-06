﻿using DerpGL.Buffers;
using OpenTK.Graphics.OpenGL;

namespace DerpGL.Shapes
{
    public abstract class IndexedShape
        : Shape
    {
        public int[] Indices { get; protected set; }
        public Buffer<int> IndexBuffer { get; protected set; }

        public override void UpdateBuffers()
        {
            base.UpdateBuffers();
            IndexBuffer = new Buffer<int>();
            IndexBuffer.Init(BufferTarget.ElementArrayBuffer, Indices);
        }

        protected override void OnRelease()
        {
            base.OnRelease();
            if (IndexBuffer != null) IndexBuffer.Release();
        }

        public override void RenderImmediate(PrimitiveType mode)
        {
            GL.Begin(mode);
            foreach (var index in Indices)
            {
                GL.Vertex3(Vertices[index]);
            }
            GL.End();
        }
    }
}