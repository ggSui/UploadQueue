using DASM.Client.Upload.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DASM.Client.Upload.Service
{
    /// <summary>
    /// 上传图片处理类
    /// </summary>
    public abstract class UploadPhotoHandler
    {
        /// <summary>
        /// 上传图片执行方法
        /// </summary>
        /// <param name="photoUpload">图片信息</param>
        /// <param name="eventBus">事件</param>
        public abstract void Execute(PhotoUpload photoUpload, EventBus eventBus);
    }
}
