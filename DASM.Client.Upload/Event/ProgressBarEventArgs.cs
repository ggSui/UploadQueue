using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DASM.Client.Upload.Event
{
    /// <summary>
    /// 进度条事件参数
    /// </summary>
    public class ProgressBarEventArgs : EventArgs
    {
        public int count;
    }
}
