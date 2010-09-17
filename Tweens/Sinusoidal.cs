using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XNAStoryboard.Tweens
{
    public class Sinusoidal : BaseTween
    {
        internal override double Tween( double timeElapsed, double startValue, double totalValueChange, double totalDuration )
        {
            if ( this.EasingMode == EasingModes.EaseIn )
            {
                return -totalValueChange * Math.Cos( timeElapsed / totalDuration * ( Math.PI / 2 ) ) + totalValueChange + startValue;
            }
            else if ( this.EasingMode == EasingModes.EaseOut )
            {
                return totalValueChange * Math.Sin( timeElapsed / totalDuration * ( Math.PI / 2 ) ) + startValue;
            }
            else if ( this.EasingMode == EasingModes.EaseInOut )
            {
                return -totalValueChange / 2 * ( Math.Cos( Math.PI * timeElapsed / totalDuration ) - 1 ) + startValue;
            }

            throw new NotSupportedException( "EasingMode not supported" );
        }
    }
}