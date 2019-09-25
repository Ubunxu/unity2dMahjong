using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace util.net
{
    /// <summary>
    /// 消息队列
    /// 不断的从队列中读取消息，
    /// 当需要停止的时候 ，就暂停执行
    /// 当开启读取的时候 ，就恢复读取执行
    /// </summary>
    public class MessageQueue
    {
        //消息队列
        private Queue<ByteBuffer> queue = new Queue<ByteBuffer>();
        //信号
        //是否等待
        private bool isWait = false;

        private static MessageQueue _mq = null;
        public static MessageQueue shareMessageQueue()
        {
            if (_mq == null) _mq = new MessageQueue();
            return _mq;
        }

        public void AddTask(ByteBuffer buffer)
        {
            lock(this)
            {
                this.queue.Enqueue(buffer);
            }      
        }  

        public void RunTask()//1001,6551,5550,6210
        {
            if (this.queue.Count <= 0) return;
            if (this.isWait) return;//防止事情没做完
            lock (this)
            {                
                if (this.queue.Count <= 0) return;
                this.isWait = true;
                //UnityEngine.Debug.Log("ok");
                ByteBuffer buf = queue.Dequeue();
                // //1001
                util.core.EventDispatch.dispatchEvent(buf.Type, buf);
                this.isWait = false;
            }            
        }
        
    }
}
