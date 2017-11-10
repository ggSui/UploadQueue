using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DASM.Client.Upload.Service
{
    /// <summary>
    /// 控制服务的开始 暂停
    /// </summary>
    public interface IService
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
        bool StartService();

        /// <summary>
        /// 停止服务
        /// </summary>
        /// <returns></returns>
        bool StopService();
    }
}
