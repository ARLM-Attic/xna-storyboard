using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XNAStoryboard.Tweens
{
    public class Quadradic : BaseTween
    {
        internal override double Tween( double timeElapsed, double startValue, double totalValueChange, double totalDuration )
        {
            if ( this.EasingMode == EasingModes.EaseIn )
            {
                return totalValueChange * ( timeElapsed /= totalDuration ) * timeElapsed + startValue;
            }
            else if ( this.EasingMode == EasingModes.EaseOut )
            {
                return -totalValueChange * ( timeElapsed /= totalDuration ) * ( timeElapsed - 2 ) + startValue;
            }
            else if ( this.EasingMode == EasingModes.EaseInOut )
            {
                if ( ( timeElapsed /= totalDuration / 2 ) < 1 )
                    return totalValueChange / 2 * timeElapsed * timeElapsed + startValue;

                return -totalValueChange / 2 * ( ( --timeElapsed ) * ( timeElapsed - 2 ) - 1 ) + startValue;
            }

            throw new NotSupportedException( "EasingMode not supported" );
        }
    }
}