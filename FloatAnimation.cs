using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XNAStoryboard.Tweens;

namespace XNAStoryboard
{
    public class FloatAnimation : Timeline
    {
        #region To
        public float To
        {
            get;
            set;
        }
        #endregion

        #region From
        public float? From
        {
            get;
            set;
        }
        #endregion

        TimeSpan lastTime;
        float currentValue = 0.0f;

        public FloatAnimation()
        {
            this.IsFinished = false;
        }

        override internal void Begin()
        {
            this.currentValue = ( this.From.HasValue ? this.From.Value : this.Target.GetValue<float>( this.TargetProperty ) );
            this.From = this.currentValue;
        }

        override internal void Update( TimeSpan timePast )
        {
            TimeSpan timeElapsed = timePast + this.lastTime;

            if ( timeElapsed > this.Duration )
            {
                timeElapsed = this.Duration;
                this.IsFinished = true;
            }

            this.currentValue = this.EasingFunction.Tween( timeElapsed.TotalSeconds, this.From.Value, this.To - this.From.Value, this.Duration.TotalSeconds );
            this.Target.SetValue( this.TargetProperty, this.currentValue );

            this.lastTime = timeElapsed;
        }
    }
}