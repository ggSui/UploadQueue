using System.Collections.Concurrent;
using System.Collections.Generic;

namespace UploadQueue
{
    /// <summary>
    /// 上传事件队列
    /// </summary>
    public class PhotoUploadController
    {
        private ConcurrentQueue<PhotoUpload> mUploadingList;
        public PhotoUploadController()
        {
            mUploadingList = new ConcurrentQueue<PhotoUpload>();
        }

        /// <summary>
        /// 添加任务集合
        /// </summary>
        /// <param name="selection"></param>
        /// <returns></returns>
        public bool AddUploads(List<PhotoUpload> uploads)
        {
            if (uploads != null)
            {
                foreach (var item in uploads)
                {
                    mUploadingList.Enqueue(item);
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// 添加任务
        /// </summary>
        /// <param name="upload"></param>
        /// <returns></returns>
        public bool AddUpload(PhotoUpload upload)
        {
            if (upload == null) return false;

            mUploadingList.Enqueue(upload);
            return true;
        }

        /// <summary>
        /// 获取上传信息
        /// </summary>
        /// <returns></returns>
        public List<PhotoUpload> GetUploadingUploads()
        {
            return new List<PhotoUpload>(mUploadingList);
        }

        /// <summary>
        /// 获取待上传数量
        /// </summary>
        /// <returns></returns>
        public int GetUploadsCount()
        {
            return mUploadingList.Count;
        }

        /// <summary>
        /// 获取下一个获取上传信息
        /// </summary>
        /// <returns></returns>
        public PhotoUpload GetNextUpload()
        {
            if (mUploadingList.IsEmpty) return null;
            PhotoUpload value = null;
            mUploadingList.TryDequeue(out value);
            return value;
        }
    }
}
