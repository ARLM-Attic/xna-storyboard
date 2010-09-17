using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XNAStoryboard.Tweens
{
    public class Circular : BaseTween
    {
        internal override double Tween( double timeElapsed, double startValue, double totalValueChange, double totalDuration )
        {
            if ( this.EasingMode == EasingModes.EaseIn )
            {
                return -totalValueChange * ( Math.Sqrt( 1 - ( timeElapsed /= totalDuration ) * timeElapsed ) - 1 ) + startValue;
            }
            else if ( this.EasingMode == EasingModes.EaseOut )
            {
                return totalValueChange * Math.Sqrt( 1 - ( timeElapsed = timeElapsed / totalDuration - 1 ) * timeElapsed ) + startValue;
            }
            else if ( this.EasingMode == EasingModes.EaseInOut )
            {
                if ( ( timeElapsed /= totalDuration / 2 ) < 1 )
                {
                    return -totalValueChange / 2 * ( Math.Sqrt( 1 - timeElapsed * timeElapsed ) - 1 ) + startValue;
                }
                return totalValueChange * 0.5 * ( (float) Math.Sqrt( 1 - ( timeElapsed -= 2 ) * timeElapsed ) + 1 ) + startValue;

            }

            throw new NotSupportedException( "EasingMode not supported" );
        }
    }
}