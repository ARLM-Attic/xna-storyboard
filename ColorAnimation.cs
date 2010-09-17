using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XNAStoryboard.Tweens;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace XNAStoryboard
{
    public class ColorAnimation : Timeline<Color>
    {
        #region To
        public Color To
        {
            get;
            set;
        }
        #endregion

        #region From
        public Color? From
        {
            get;
            set;
        }
        #endregion

        TimeSpan lastTime;
        Color currentValue = Color.White;

        public ColorAnimation()
        {
            this.IsFinished = false;
        }

        public override void Begin()
        {
            this.currentValue = ( this.From.HasValue ? this.From.Value : this.Target.GetValue<Color>( this.TargetProperty ) );
            this.From = this.currentValue;
        }

        public override void Update( TimeSpan timePast )
        {
            TimeSpan timeElapsed = timePast + this.lastTime;

            if ( timeElapsed > this.Duration )
            {
                timeElapsed = this.Duration;
                this.IsFinished = true;
            }
            
            Vector4 toValues = this.To.ToVector4();
            Vector4 fromValues = this.From.Value.ToVector4();

            this.currentValue = new Color( this.EasingFunction.Tween( timeElapsed.TotalSeconds, fromValues.X, toValues.X - fromValues.X, this.Duration.TotalSeconds ),
                                           this.EasingFunction.Tween( timeElapsed.TotalSeconds, fromValues.Y, toValues.Y - fromValues.Y, this.Duration.TotalSeconds ),
                                           this.EasingFunction.Tween( timeElapsed.TotalSeconds, fromValues.Z, toValues.Z - fromValues.Z, this.Duration.TotalSeconds ),
                                           this.EasingFunction.Tween( timeElapsed.TotalSeconds, fromValues.W, toValues.W - fromValues.W, this.Duration.TotalSeconds ) );

            this.Target.SetValue( this.TargetProperty, this.currentValue );

            this.lastTime = timeElapsed;
        }
    }
}