using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using XNAStoryboard.Tweens;

namespace XNAStoryboard
{
    public class Vector2Animation : Timeline<Vector2>
    {
        #region To
        public Vector2 To
        {
            get;
            set;
        }
        #endregion

        #region From
        public Vector2? From
        {
            get;
            set;
        }
        #endregion

        TimeSpan lastTime;
        Vector2 currentValue = Vector2.Zero;

        public Vector2Animation()
        {
            this.IsFinished = false;
        }

        public override void Begin()
        {
            this.currentValue = ( this.From.HasValue ? this.From.Value : this.Target.GetValue<Vector2>( this.TargetProperty ) );
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

            this.currentValue = new Vector2( this.EasingFunction.Tween( timeElapsed.TotalSeconds, this.From.Value.X, this.To.X - this.From.Value.X, this.Duration.TotalSeconds ),
                                             this.EasingFunction.Tween( timeElapsed.TotalSeconds, this.From.Value.Y, this.To.Y - this.From.Value.Y, this.Duration.TotalSeconds ) );

            if ( this.Target != null )
                this.Target.SetValue( this.TargetProperty, this.currentValue );
            else if ( this.TargetAction != null )
                this.TargetAction.Invoke( this.currentValue );

            this.lastTime = timeElapsed;
        }
    }
}
