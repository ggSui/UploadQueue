using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Concurrent;
using DASM.Client.Upload.Event;
using System.Threading;

namespace DASM.Client.Upload.Service
{
    /// <summary>
    /// 上传服务
    /// </summary>
    public class UploadService : IService
    {
        private Thread thread = null;

        private UploadServiceState state = UploadServiceState.未开始;//当前任务状态

        private UploadPhotoHandler uploadPhotoHandler; //上传具体方法

        private ManualResetEvent manualResetEvent = new ManualResetEvent(false);//等待

        /// <summary>
        /// 上传队列
        /// </summary>
        public PhotoUploadController UploadController { get; private set; }

        /// <summary>
        /// 事件总栈
        /// </summary>
        public EventBus EventBus { get; private set; }

        public UploadService(UploadPhotoHandler uploadPhotoHandler) : this(uploadPhotoHandler, EventBusCurrent.Current) { }

        public UploadService(UploadPhotoHandler uploadPhotoHandler, EventBus eventBus)
        {
            this.EventBus = eventBus;
            this.uploadPhotoHandler = uploadPhotoHandler;
            this.UploadController = new PhotoUploadController();

            StartThread();
        }

        /// <summary>
        /// 获取当前状态
        /// </summary>
        /// <returns></returns>
        public UploadServiceState GetState()
        {
            return this.state;
        }

        /// <summary>
        /// 开启服务
        /// </summary>
        /// <returns></returns>
        public bool StartService()
        {
            state = UploadServiceState.已启动;
            manualResetEvent.Set();
            return true;
        }

        /// <summary>
        /// 停止服务
        /// </summary>
        /// <returns></returns>
        public bool StopService()
        {
            state = UploadServiceState.已停止;
            this.manualResetEvent.Reset();
            return true;
        }

        /// <summary>
        /// 开启线程
        /// </summary>
        private void StartThread()
        {
            thread = new Thread(new ThreadStart(ThreadExecute))
            {
                IsBackground = true,
                Name = "UploadPhoto" + DateTime.Now.ToLongDateString()
            };
            StopService();
        }

        /// <summary>
        /// 线程执行方法
        /// </summary>
        protected virtual void ThreadExecute()
        {
            while (true)
            {
                try
                {
                    manualResetEvent.WaitOne();
                    PhotoUpload photoUpload = this.UploadController.GetNextUpload();
                    if (photoUpload != null)
                    {
                        uploadPhotoHandler.Execute(photoUpload, this.EventBus);
                    }
                    else
                    {
                        EventBus.OnAllUploadSuccess(photoUpload, new AllUploadSuccessEventArgs() { });
                        manualResetEvent.Reset();
                    }
                }
                catch (Exception ex)
                {
                    EventBus.OnConsoleLog(this, new ConsoleLogEventArgs() { log = ex.Message });
                }
            }
        }
    }
}
