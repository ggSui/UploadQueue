using System.Collections.Generic;

namespace UploadQueue.Service
{
    /// <summary>
    /// 控制服务的开始 暂停
    /// </summary>
    public interface IUploadService
    {
        /// <summary>
        /// 获取当前任务状态
        /// </summary>
        /// <returns></returns>
        UploadServiceState GetState();

        /// <summary>
        /// 开始任务
        /// </summary>
        /// <returns></returns>
        bool Start();

        /// <summary>
        /// 停止服务
        /// </summary>
        /// <returns></returns>
        bool Stop();

        /// <summary>
        /// 停止后，在使用Start,Stop就报错
        /// </summary>
        void Exit();

        /// <summary>
        /// 添加任务集合
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        bool AddUploads(List<PhotoUpload> list);

        /// <summary>
        /// 添加任务
        /// </summary>
        /// <param name="photoUpload"></param>
        /// <returns></returns>
        bool AddUpload(PhotoUpload photoUpload);
    }
}
