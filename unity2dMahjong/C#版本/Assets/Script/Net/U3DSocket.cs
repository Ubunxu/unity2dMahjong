using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;
using util.core;

namespace util.net
{
    public class U3DSocket : MonoBehaviour
    {
        private bool isClosed = false;
        private Socket socket = null;
        private static U3DSocket socket_ = null;
        private bool isConnection = false;
        MessageQueue queue = MessageQueue.shareMessageQueue();
        //超时设置
        private readonly ManualResetEvent TimeoutObject = new ManualResetEvent(false);

        void Awake()
        {
            socket_ = this;
        }
        void Start()
        {
            EventDispatch.addEventListener(this, "do");
            this.name = "Socket";
            DontDestroyOnLoad(this);
        }

        public static U3DSocket shareSocket()
        {
            return socket_;
        }

        private U3DSocket()
        {
            this.initSocket();
        }
        private void initSocket()
        {
            //1: 创建一个网络连接[Socket：套接字]对象,-- IPV4      -采用流(字节)传输    -- TCP协议
            this.socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            this.isClosed = false;
        }
        public void ConnectTo(string ip,int port,MyActionOne connOK=null,MyActionOne connNo=null,int outTimer=10)
        {
            try
            {
                if (isClosed) this.initSocket();
                if(isConnection)
                {
                    if (connOK != null) connOK("-1");//没有连接
                    return;
                }
                //2:设置连接 到服务器的IP和端口
                IPEndPoint IpPort = new IPEndPoint(IPAddress.Parse(ip), port);
                //3:开始连接
                if (this.socket.BeginConnect(IpPort, null, this.socket).AsyncWaitHandle.WaitOne(outTimer * 1000))
                {
                    if (this.socket.Connected)
                    {
                        this.isConnection = true;
                        this.BeginReciveMessage();
                        if (connOK != null) connOK("1");
                    }
                    else
                    {
                        if (connNo != null) connNo("远程主机不存在");
                        this.Close();
                    }
                }
                else
                {
                    if (connNo != null)
                    {
                        connNo("连接超时");
                        this.Close();
                    }
                }
            }
            catch (Exception e) { this.isConnection = false; }
        }

        /*
            读取消息
        */
        private int header = 0;
        private int reciveCount = 0;
        byte[] headerByte = new byte[4];
        ByteBuffer buffer = ByteBuffer.CreateBufferAndLength(1000*1000*50);
        private void BeginReciveMessage()
        {
            this.socket.BeginReceive(headerByte, this.reciveCount, 1, SocketFlags.None, CallAsyncCallback, this.socket);
        }
        private void CallAsyncCallback(IAsyncResult ar)
        {
            try
            {
                this.socket = (Socket)ar.AsyncState;
                int c = this.socket.EndReceive(ar);
                if (c == 0)//如果为0表示服务器断开
                {
                    this.Close();
                    return;
                }
                this.reciveCount += c;
                if (this.header == 0)
                {
                    if (this.reciveCount < 4)
                    {
                        this.BeginReciveMessage();
                    }
                    else
                    {
                        buffer.writeBytes(headerByte);
                        header = buffer.readInt();
                        buffer.Clear();
                        this.reciveCount = 0;
                        this.socket.BeginReceive(this.buffer.getBuffer(), this.reciveCount, this.header - this.reciveCount, SocketFlags.None, CallAsyncCallback, this.socket);
                    }
                }
                else
                {
                    if (this.reciveCount >= this.header)
                    {
                        this.CreateMessage(buffer);
                        buffer.Clear();
                        this.header = 0;
                        this.reciveCount = 0;
                        this.BeginReciveMessage();
                    }
                    else
                    {
                        this.socket.BeginReceive(this.buffer.getBuffer(), this.reciveCount, this.header - this.reciveCount, SocketFlags.None, CallAsyncCallback, this.socket);
                    }
                }
            }
            catch (SocketException e) { this.Close(); }
        }

        private void CreateMessage(ByteBuffer buffer)
        {
            int type = buffer.readInt();
            ByteBuffer buf = ByteBuffer.CreateBufferAndLength(header - 4);
            buf.writeBytes(buffer.getBuffer(), 4, this.header - 4);
            buf.Type = type;
            //debug.logf("执行一条消息: " + type + "  长度：" + buf.Length);
            //把消息添加到消息队列
            queue.AddTask(buf);
        }

        private void Close()
        {
            //buffer.Clear();
            //buffer = null;
            this.socket.Close();
            this.isClosed = true;
            this.isConnection = false;
        }

        public void Send(ByteBuffer bufer)
        {

            byte[] lengbs = BitConverter.GetBytes(bufer.Length);
            //ByteBuffer bf = new ByteBuffer(-1,4);
            socket.Send(lengbs, 0, lengbs.Length, 0);//SocketFlags.None
            socket.Send(bufer.getBuffer(), 0, bufer.Length, SocketFlags.None);
        }

        public Socket getSocket()
        {
            return this.socket;
        }

        void Update()
        {            
        }
        void FixedUpdate()
        {
            if (this._stopRead) return;
            queue.RunTask();
        }
        //停止读取消息
        public void StopRead()
        {
            this._stopRead = true;
        }
        //继续读取消息
        public void StartRead()
        {
            this._stopRead = false;
        }
        //是否要阻止消息执行，因为消息要显示的界面可能还正在打开
        private bool _stopRead = false;

        /// <summary>
        /// 为什么是写在这里啊？
        /// </summary>
        /// <param name="buffer"></param>
        public void do120(ByteBuffer buffer)
        {
            Debug.Log(buffer.readString());
        }

        private void OnDestroy()
        {
            this.Close();
        }

    }
   
}
