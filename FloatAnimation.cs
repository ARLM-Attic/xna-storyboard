using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XNAStoryboard.Tweens;

namespace XNAStoryboard
{
    public class FloatAnimation : Timeline<float>
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

        public override void Begin()
        {
            if ( this.TargetProperty != null )
            {
                this.currentValue = ( this.From.HasValue ? this.From.Value : this.Target.GetValue<float>( this.TargetProperty ) );
                this.From = this.currentValue;
            }
        }

        public override void Update( TimeSpan timePast )
        {
            TimeSpan timeElapsed = timePast + this.lastTime;

            if ( timeElapsed > this.Duration )
            {
                timeElapsed = this.Duration;
                this.IsFinished = true;
            }

            this.currentValue = this.EasingFunction.Tween( timeElapsed.TotalSeconds, this.From.Value, this.To - this.From.Value, this.Duration.TotalSeconds );

            if ( this.Target != null )
                this.Target.SetValue( this.TargetProperty, this.currentValue );
            else if ( this.TargetAction != null )
                this.TargetAction.Invoke( this.currentValue );


            this.lastTime = timeElapsed;
        }
    }
}