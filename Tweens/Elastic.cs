using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XNAStoryboard.Tweens
{
    public class Elastic : BaseTween
    {
        internal override double Tween( double timeElapsed, double startValue, double totalValueChange, double totalDuration )
        {
            if ( this.EasingMode == EasingModes.EaseIn )
            {
                if ( timeElapsed == 0 )
                    return startValue;

                if ( ( timeElapsed /= totalDuration ) == 1 )
                    return startValue + totalValueChange;

                double p = totalDuration * .3f;
                double s = p * 0.25;

                return -( totalValueChange * Math.Pow( 2, 10 * ( timeElapsed -= 1 ) ) * Math.Sin( ( timeElapsed * totalDuration - s ) * ( 2 * Math.PI ) / p ) ) + startValue;
            }
            else if ( this.EasingMode == EasingModes.EaseOut )
            {
                if (timeElapsed==0)
                    return startValue;

                if ((timeElapsed /= totalDuration) == 1) 
                {
                    return startValue+totalValueChange;
                }

                double p = totalDuration * .3f;
                double s = p * 0.25;

                return ( totalValueChange * Math.Pow( 2, -10 * timeElapsed ) * Math.Sin( ( timeElapsed * totalDuration - s ) * ( 2 * Math.PI ) / p ) + totalValueChange + startValue );
            }
            else if ( this.EasingMode == EasingModes.EaseInOut )
            {
                if ( timeElapsed == 0 )
                    return startValue;

                if ( ( timeElapsed /= totalDuration / 2 ) == 2 )
                    return startValue + totalValueChange;

                double p = totalDuration * ( .3f * 1.5f );
                double a = totalValueChange;
                double s = p * 0.25;

                if ( timeElapsed < 1 )
                    return -.5f * ( a * Math.Pow( 2, 10 * ( timeElapsed -= 1 ) ) * Math.Sin( ( timeElapsed * totalDuration - s ) * ( 2 * Math.PI ) / p ) ) + startValue;

                return ( a * Math.Pow( 2, -10 * ( timeElapsed -= 1 ) ) * Math.Sin( ( timeElapsed * totalDuration - s ) * ( 2 * Math.PI ) / p ) * .5 + totalValueChange + startValue );
            }

            throw new NotSupportedException( "EasingMode not supported" );
        }
    }
}