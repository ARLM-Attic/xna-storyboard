using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XNAStoryboard.Tweens
{
    public class Linear : BaseTween
    {
        internal override double Tween( double timeElapsed, double startValue, double totalValueChange, double totalDuration )
        {
            return ( ( totalValueChange * timeElapsed ) / totalDuration ) + startValue;
        }
    }
}
