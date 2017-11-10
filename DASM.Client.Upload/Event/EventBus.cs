using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DASM.Client.Upload.Event
{
    public class EventBus
    {
        public event EventHandler<ConsoleLogEventArgs> ConsoleLogEvent;
        public event EventHandler<AllUploadSuccessEventArgs> AllUploadSuccessEvent;
        public event EventHandler<ProgressBarEventArgs> ProgressBarEvent;
        public event EventHandler<SuccessEventArgs> SuccessEvent;
        public event EventHandler<UploadSpeedEventArgs> UploadSpeedEvent;

        /// <summary>
        /// 输出日志
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public virtual void OnConsoleLog(object sender, ConsoleLogEventArgs args)
        {
            if (ConsoleLogEvent != null)
            {
                ConsoleLogEvent(sender, args);
            }
        }

        /// <summary>
        /// 所有上传成功
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public virtual void OnAllUploadSuccess(object sender, AllUploadSuccessEventArgs args)
        {
            if (AllUploadSuccessEvent != null)
            {
                AllUploadSuccessEvent(sender, args);
            }
        }

        /// <summary>
        /// 进度条更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public virtual void OnProgressBar(object sender, ProgressBarEventArgs args)
        {
            if (ProgressBarEvent != null)
            {
                ProgressBarEvent(sender, args);
            }
        }

        /// <summary>
        /// 上传成功
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public virtual void OnSuccess(object sender, SuccessEventArgs args)
        {
            if (SuccessEvent != null)
            {
                SuccessEvent(sender, args);
            }
        }

        /// <summary>
        /// 输出上传速度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public virtual void OnUploadSpeedEventArgs(object sender, UploadSpeedEventArgs args)
        {
            if (UploadSpeedEvent != null)
            {
                UploadSpeedEvent(sender, args);
            }
        }
    }
}
