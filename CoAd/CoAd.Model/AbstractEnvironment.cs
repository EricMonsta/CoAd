using System;

namespace CoAd.Model
{
    public abstract class AbstractEnvironment
    {
        protected readonly object Sync = new object();

        /// <summary>
        /// Активность окружения, неактивное окружение не используется
        /// </summary>
        public bool IsActive { get; protected set; }

        /// <summary>
        /// Пользовательское имя
        /// </summary>
        public abstract string FriendlyName { get; }

        /// <summary>
        /// Действие запуска окружения
        /// </summary>
        protected abstract Action StartAction { get; }

        /// <summary>
        /// Действие остановки окружения
        /// </summary>
        protected abstract Action StopAction { get; }

        public virtual void Start()
        {
            if (StartAction == null)
            {
                throw new Exception("No start action realization");
            }

            IsActive = false;
            Watch.Instance.Time(() => StartAction.Invoke());
            IsActive = true;
        }

        public virtual void Stop()
        {
            if (StopAction == null) throw new Exception("No stop action realization");

            Watch.Instance.Time(() => StopAction.Invoke());
            IsActive = false;
        }

        public virtual void Restart()
        {
            Stop();
            Start();
        }

        public override string ToString()
        {
            return FriendlyName;
        }

    }
}