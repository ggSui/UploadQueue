using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DASM.Client.Upload.Service
{
    /// <summary>
    /// 上传服务状态
    /// </summary>
    public enum UploadServiceState
    {
        未开始 = 10,
        已启动 = 20,
        已停止 = 30
    }
}
