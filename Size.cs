using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XNAStoryboard
{
    public struct Size
    {
        #region Height
        private float height;
        public float Height
        {
            get
            {
                return this.height;
            }
            set
            {
                this.height = value;
            }
        }
        #endregion

        #region Width
        private float width;
        public float Width
        {
            get
            {
                return this.width;
            }
            set
            {
                this.width = value;
            }
        }
        #endregion

        public Size( float width, float height )
        {
            this.height = height;
            this.width = width;
        }
    }
}
