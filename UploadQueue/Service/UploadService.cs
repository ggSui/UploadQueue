using System;
using System.Collections.Generic;
using System.Threading;
using UploadQueue.Event;

namespace UploadQueue.Service
{
    /// <summary>
    /// 上传服务
    /// </summary>
    public class UploadService : IUploadService
    {
        private Thread thread = null;

        private UploadServiceState state = UploadServiceState.未开始;//当前任务状态

        private UploadPhotoHandler uploadPhotoHandler; //上传具体方法

        private ManualResetEvent manualResetEvent = new ManualResetEvent(false);//等待

        /// <summary>
        /// 上传队列
        /// </summary>
        private PhotoUploadController uploadController;

        /// <summary>
        /// 事件总栈
        /// </summary>
        public EventBus EventBus { get; private set; }

        public UploadService(UploadPhotoHandler uploadPhotoHandler) : this(uploadPhotoHandler, EventBusCurrent.Current) { }

        public UploadService(UploadPhotoHandler uploadPhotoHandler, EventBus eventBus)
        {
            this.EventBus = eventBus;
            this.uploadPhotoHandler = uploadPhotoHandler;
            this.uploadController = new PhotoUploadController();
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
        public bool Start()
        {
            state = UploadServiceState.已启动;
            manualResetEvent.Set();
            return true;
        }

        /// <summary>
        /// 停止服务
        /// </summary>
        /// <returns></returns>
        public bool Stop()
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
            Stop();
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
                    PhotoUpload photoUpload = this.uploadController.GetNextUpload();
                    if (photoUpload != null)
                    {
                        uploadPhotoHandler.Execute(photoUpload, EventBus);
                    }
                    else
                    {
                        EventBus.OnAllUploadSuccess(photoUpload, new AllUploadSuccessEventArgs() { });
                        manualResetEvent.Reset();
                    }
                }
                catch (Exception ex)
                {
                    EventBus.OnConsoleLog(this, new ConsoleLogEventArgs(ex.Message));
                }
            }
        }

        /// <summary>
        /// 退出服务
        /// </summary>
        public void Exit()
        {
            if (thread != null)
            {
                thread.Abort();
            }
        }

        /// <summary>
        /// 添加任务
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public virtual bool AddUploads(List<PhotoUpload> list)
        {
            bool result = uploadController.AddUploads(list);
            if (result)
            {
                EventBus.OnProgressBarMax(null, new ProgressBarMaxEventArgs(list.Count));
            }
            return result;
        }

        /// <summary>
        /// 添加任务
        /// </summary>
        /// <param name="photoUpload"></param>
        /// <returns></returns>
        public bool AddUpload(PhotoUpload photoUpload)
        {
            bool result = uploadController.AddUpload(photoUpload);
            if (result)
            {
                EventBus.OnProgressBarMax(null, new ProgressBarMaxEventArgs(1));
            }
            return result;
        }
    }
}
