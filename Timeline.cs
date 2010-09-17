using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XNAStoryboard.Tweens;

namespace XNAStoryboard
{
    public class Timeline<T> : ITimeline
    {
        #region Target
        public DependencyObject Target
        {
            get;
            set;
        }
        #endregion

        #region TargetProperty
        public DependencyProperty TargetProperty
        {
            get;
            set;
        }
        #endregion

        #region Duration
        public TimeSpan Duration
        {
            get;
            set;
        }
        #endregion

        #region IsFinished
        internal bool IsFinished
        {
            get;
            set;
        }
        #endregion

        #region EasingFunction
        public BaseTween EasingFunction
        {
            get;
            set;
        }
        #endregion

        #region TargetAction
        public Action<T> TargetAction
        {
            get;
            set;
        }
        #endregion

        public Timeline()
        {
            this.EasingFunction = new Linear()
            {
                EasingMode = EasingModes.EaseIn
            };
        }

        public virtual void Begin()
        {
            throw new NotImplementedException();
        }

        public virtual void Update( TimeSpan timePast )
        {
            throw new NotImplementedException();
        }

        public bool GetIsFinisihed()
        {
            return this.IsFinished;
        }
    }
}
