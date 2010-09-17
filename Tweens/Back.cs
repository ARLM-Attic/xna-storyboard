using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XNAStoryboard.Tweens
{
    public class Back : BaseTween
    {
        #region Amplitude
        public double Amplitude
        {
            get;
            set;
        }
        #endregion

        public Back()
        {
            this.Amplitude = 1.70158;
        }

        internal override double Tween( double timeElapsed, double startValue, double totalValueChange, double totalDuration )
        {
            if ( this.EasingMode == EasingModes.EaseIn )
            {
                return totalValueChange * ( timeElapsed /= totalDuration ) * timeElapsed * ( ( this.Amplitude + 1 ) * timeElapsed - this.Amplitude ) + startValue;
            }
            else if ( this.EasingMode == EasingModes.EaseOut )
            {
                return totalValueChange * ( ( timeElapsed = timeElapsed / totalDuration - 1 ) * timeElapsed * ( ( this.Amplitude + 1 ) * timeElapsed + this.Amplitude ) + 1 ) + startValue;
            }
            else if ( this.EasingMode == EasingModes.EaseInOut )
            {
                double s = this.Amplitude;

                if ( ( timeElapsed /= totalDuration / 2 ) < 1 )
                    return totalValueChange / 2 * ( timeElapsed * timeElapsed * ( ( ( s *= ( 1.525f ) ) + 1 ) * timeElapsed - s ) ) + startValue;

                return totalValueChange / 2 * ( ( timeElapsed -= 2 ) * timeElapsed * ( ( ( s *= ( 1.525f ) ) + 1 ) * timeElapsed + s ) + 2 ) + startValue;
            }

            throw new NotSupportedException( "EasingMode not supported" );
        }
    }
}