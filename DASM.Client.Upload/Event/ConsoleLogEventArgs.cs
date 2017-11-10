using System;

namespace UploadQueue.Event
{
    /// <summary>
    /// 输出日志事件参数
    /// </summary>
    public class ConsoleLogEventArgs : EventArgs
    {
        public ConsoleLogEventArgs(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
    }
}
