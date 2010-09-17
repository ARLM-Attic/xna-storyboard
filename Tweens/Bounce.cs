using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XNAStoryboard.Tweens
{
    public class Bounce : BaseTween
    {
        #region Bounciness
        private double Bounciness
        {
            get;
            set;
        }
        #endregion

        public Bounce()
        {
            this.Bounciness = 7.5625;
        }

        internal override double Tween( double timeElapsed, double startValue, double totalValueChange, double totalDuration )
        {
            if ( this.EasingMode == EasingModes.EaseIn )
            {
                return this.EaseIn( timeElapsed, startValue, totalValueChange, totalDuration );
            }
            else if ( this.EasingMode == EasingModes.EaseOut )
            {
                return this.EaseOut( timeElapsed, startValue, totalValueChange, totalDuration );
            }
            else if ( this.EasingMode == EasingModes.EaseInOut )
            {
                if ( timeElapsed < totalDuration * 0.5 )
                    return EaseIn( timeElapsed * 2, 0, totalValueChange, totalDuration ) * 0.5 + startValue;
                else
                    return EaseOut( timeElapsed * 2 - totalDuration, 0, totalValueChange, totalDuration ) * 0.5 + totalValueChange * 0.5 + startValue;
            }

            throw new NotSupportedException( "EasingMode not supported" );
        }

        private double EaseIn( double timeElapsed, double startValue, double totalValueChange, double totalDuration )
        {
            return totalValueChange - EaseOut( totalDuration - timeElapsed, 0, totalValueChange, totalDuration ) + startValue;
        }

        private double EaseOut( double timeElapsed, double startValue, double totalValueChange, double totalDuration )
        {
            if ( ( timeElapsed /= totalDuration ) < ( 1 / 2.75 ) )
            {
                return totalValueChange * ( this.Bounciness * timeElapsed * timeElapsed ) + startValue;
            }
            else if ( timeElapsed < ( 2 / 2.75 ) )
            {
                return totalValueChange * ( this.Bounciness * ( timeElapsed -= ( 1.5 / 2.75 ) ) * timeElapsed + 0.75 ) + startValue;
            }
            else if ( timeElapsed < ( 2.5 / 2.75 ) )
            {
                return totalValueChange * ( this.Bounciness * ( timeElapsed -= ( 2.25 / 2.75 ) ) * timeElapsed + 0.9375 ) + startValue;
            }
            else
            {
                return totalValueChange * ( this.Bounciness * ( timeElapsed -= ( 2.625 / 2.75 ) ) * timeElapsed + 0.984375 ) + startValue;
            }

        }
    }
}
