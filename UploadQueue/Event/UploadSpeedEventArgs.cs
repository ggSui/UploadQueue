using System;

namespace UploadQueue.Event
{
    /// <summary>
    /// 上传网速事件参数
    /// </summary>
    public class UploadSpeedEventArgs : EventArgs
    {
        public UploadSpeedEventArgs(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
    }
}
