using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XNAStoryboard.Tweens
{
    public class Exponential : BaseTween
    {
        internal override double Tween( double timeElapsed, double startValue, double totalValueChange, double totalDuration )
        {
            if ( this.EasingMode == EasingModes.EaseIn )
            {
                return ( timeElapsed == 0 ) ? startValue : totalValueChange * Math.Pow( 2, 10 * ( timeElapsed / totalDuration - 1 ) ) + startValue;
            }
            else if ( this.EasingMode == EasingModes.EaseOut )
            {
                return ( timeElapsed == totalDuration ) ? startValue + totalValueChange : totalValueChange * ( -Math.Pow( 2, -10 * timeElapsed / totalDuration ) + 1 ) + startValue;
            }
            else if ( this.EasingMode == EasingModes.EaseInOut )
            {
                if ( timeElapsed == 0 )
                    return startValue;

                if ( timeElapsed == totalDuration )
                    return startValue + totalValueChange;

                if ( ( timeElapsed /= totalDuration / 2 ) < 1 )
                    return totalValueChange * 0.5 * Math.Pow( 2, 10 * ( timeElapsed - 1 ) ) + startValue;

                return totalValueChange * 0.5 * ( -Math.Pow( 2, -10 * --timeElapsed ) + 2 ) + startValue;
            }

            throw new NotSupportedException( "EasingMode not supported" );
        }
    }
}