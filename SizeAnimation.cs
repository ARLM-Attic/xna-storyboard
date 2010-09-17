using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using XNAStoryboard.Tweens;

namespace XNAStoryboard
{
    public class SizeAnimation : Timeline<Size>
    {
        #region To
        public Size To
        {
            get;
            set;
        }
        #endregion

        #region From
        public Size? From
        {
            get;
            set;
        }
        #endregion

        TimeSpan lastTime;
        Size currentValue = new Size( 0, 0 );

        public SizeAnimation()
        {
            this.IsFinished = false;
        }

        public override void Begin()
        {
            this.currentValue = ( this.From.HasValue ? this.From.Value : this.Target.GetValue<Size>( this.TargetProperty ) );
            this.From = this.currentValue;
        }

        public override void Update( TimeSpan timePast )
        {
            TimeSpan timeElapsed = timePast + this.lastTime;

            if (timeElapsed > this.Duration)
            {
                timeElapsed = this.Duration;
                this.IsFinished = true;
            }

            this.currentValue = new Size( this.EasingFunction.Tween( timeElapsed.TotalSeconds, this.From.Value.Width, this.To.Width - this.From.Value.Width, this.Duration.TotalSeconds ),
                                          this.EasingFunction.Tween( timeElapsed.TotalSeconds, this.From.Value.Height, this.To.Height - this.From.Value.Height, this.Duration.TotalSeconds ) );

            this.Target.SetValue( this.TargetProperty, this.currentValue );

            this.lastTime = timeElapsed;
        }
    }
}
