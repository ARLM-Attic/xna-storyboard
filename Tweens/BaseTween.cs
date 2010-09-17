using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XNAStoryboard.Tweens
{
    public class BaseTween
    {
        #region EasingMode
        public EasingModes EasingMode
        {
            get;
            set;
        }
        #endregion

        public BaseTween()
        {
            this.EasingMode = EasingModes.EaseIn;
        }

        internal virtual double Tween( double timeElapsed, double startValue, double totalValueChange, double totalDuration )
        {
            throw new NotImplementedException();
        }

        internal virtual float Tween( double timeElapsed, float startValue, float totalValueChange, double totalDuration )
        {
            return (float) this.Tween( timeElapsed, (double) startValue, (double) totalValueChange, totalDuration );
        }
    }
}
