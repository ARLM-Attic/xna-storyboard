using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XNAStoryboard
{
    public interface ITimeline
    {
        bool GetIsFinisihed();
        void Begin();
        void Update( TimeSpan timePast );
    }
}