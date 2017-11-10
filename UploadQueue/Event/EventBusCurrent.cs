namespace UploadQueue.Event
{
    public static class EventBusCurrent
    {
        private static object lock_obj = new object();
        private static EventBus eventBus;

        /// <summary>
        /// 获取当前实例
        /// </summary>
        public static EventBus Current
        {
            get
            {
                if (eventBus == null)
                {
                    lock (lock_obj)
                    {
                        if (eventBus == null)
                        {
                            eventBus = new EventBus();
                        }
                    }
                }
                return eventBus;
            }
        }
    }
}
