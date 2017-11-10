using System;

namespace UploadQueue.Event
{
    /// <summary>
    /// 进度条事件参数
    /// </summary>
    public class ProgressBarMaxEventArgs : EventArgs
    {
        public ProgressBarMaxEventArgs(int count)
        {
            Count = count;
        }
        public int Count { get; set; }
    }
}
