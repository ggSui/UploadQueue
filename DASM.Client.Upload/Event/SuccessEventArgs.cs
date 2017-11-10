using System;

namespace UploadQueue.Event
{
    /// <summary>
    /// 成功事件参数
    /// </summary>
    public class SuccessEventArgs : EventArgs
    {
        public SuccessEventArgs(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
