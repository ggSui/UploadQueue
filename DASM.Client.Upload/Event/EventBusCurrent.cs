using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DASM.Client.Upload.Event
{

    public static class EventBusCurrent
    {
        /// <summary>
        /// 获取当前实例
        /// </summary>
        public static EventBus Current
        {
            get
            {
                return new EventBus();
            }
        }
    }
}
