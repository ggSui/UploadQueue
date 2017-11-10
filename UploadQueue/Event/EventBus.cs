using System;

namespace UploadQueue.Event
{
    public class EventBus
    {
        public event EventHandler<ConsoleLogEventArgs> ConsoleLogEvent;
        public event EventHandler<AllUploadSuccessEventArgs> AllUploadSuccessEvent;
        public event EventHandler<ProgressBarMaxEventArgs> ProgressBarEvent;
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
        /// 队列添加数量通知
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public virtual void OnProgressBarMax(object sender, ProgressBarMaxEventArgs args)
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
