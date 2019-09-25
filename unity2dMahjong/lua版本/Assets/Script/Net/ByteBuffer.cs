using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace util.net
{
    public class ByteBuffer
    {
        private byte[] buffer;
        private int readIndex = 0;
        private int writeIndex = 0;
        private int _type = 0;


        public static ByteBuffer CreateBufferAndType(int type)
        {
            ByteBuffer buf = new ByteBuffer(type, 1024);
            return buf;
        }
        public static ByteBuffer CreateBufferAndLength(int length)
        {
            ByteBuffer buf = new ByteBuffer(-1, length);
            return buf;
        }
        public static ByteBuffer CreateBufferTypeAndLength(int type,int length)
        {
            ByteBuffer buf = new ByteBuffer(type, length);
            return buf;
        }
        public static ByteBuffer CreateBuffer()
        {
            ByteBuffer buf = new ByteBuffer(-1, 1024);
            return buf;
        }       
        /// <summary>
        /// 注意：不需要类型的时候 ，一定要加 -1,
        /// </summary>
        /// <param name="__type">协议类型</param>
        /// <param name="length">消息长度</param>
        /// 
        private ByteBuffer(int __type=-1,int length = 1024)
        {
            this.buffer = new byte[length];
            this._type = __type;
            if (this._type != -1)
            {
                this.writeInt(this._type);
            }
        }
        public int Type
        {
            get { return this._type; }
            set { this._type = value; }
        }
        public int Length
        {
            get { return this.writeIndex; }
            set { this.writeIndex = value; }
        }
        public int Available
        {
            get { return this.writeIndex - this.readIndex; }
        }
        public byte[] getBuffer()
        {
            return this.buffer;
        }
        public byte[] getBufferAvailable()
        {
            byte[] bs = new byte[this.Length];
            Array.Copy(buffer, 0, bs, 0, this.Length);
            return bs;
        }
        public void writeInt(int value)
        {
            byte[] intbs = BitConverter.GetBytes(value);
            this.writeBytes(intbs);
        }

        public void writeFloat(float value)
        {
            byte[] floatbs = BitConverter.GetBytes(value);
            this.writeBytes(floatbs);
        }
        public void writeBoolean(bool f)
        {
            byte[] fs = BitConverter.GetBytes(f);
            this.writeBytes(fs);
        }
        public void writeBytes(byte[] bytes)
        {
            Array.Copy(bytes, 0, this.buffer, this.writeIndex, bytes.Length);
            this.writeIndex += bytes.Length;
        }
        public void writeBytes(byte[] bytes, int index, int length)
        {
            Array.Copy(bytes, index, this.buffer, this.writeIndex, length);
            this.writeIndex += length;
        }
        public void writeBuffer(ByteBuffer buf, int index)
        {
            this.writeBytes(buf.getBuffer(), index, buf.Length - index);
        }

        public void writeString(string str)
        {
            byte[] strbs = Encoding.UTF8.GetBytes(str);
            this.writeInt(strbs.Length);
            this.writeBytes(strbs);
        }

        public int readInt()
        {
            int value = BitConverter.ToInt32(this.buffer, this.readIndex);
            this.readIndex += 4;
            return value;
        }
        public bool readBoolean()
        {
            bool f = BitConverter.ToBoolean(this.buffer, this.readIndex);
            this.readIndex += 1;
            return f;
        }
        public string readString()
        {
            int len = this.readInt();
            string sv = Encoding.UTF8.GetString(this.buffer, readIndex, len);
            this.readIndex += len;
            return sv;
        }
        public ByteBuffer readBuffer()
        {
            int len = this.readInt();
            ByteBuffer buff = new ByteBuffer(-1, len);
            buff.writeBytes(this.buffer, this.readIndex, len);
            this.readIndex += len;
            return buff; 
        }
        public void Clear()
        {
            Array.Clear(this.buffer, 0, this.writeIndex);
            this.writeIndex = 0;
            this.readIndex = 0;
        }

        public void Send(string key=null)
        {
            U3DSocket.shareSocket().Send(this,key);
        }
    }
}
