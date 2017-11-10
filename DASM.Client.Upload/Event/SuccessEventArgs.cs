using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DASM.Client.Upload.Event
{
    /// <summary>
    /// 成功事件参数
    /// </summary>
    public class SuccessEventArgs : EventArgs
    {
        public Guid Id { get; set; }
    }
}
