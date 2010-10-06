using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;

namespace XNAStoryboard
{
    public sealed class DependencyProperty
    {
        #region Name
        public string Name
        {
            get;
            set;
        }
        #endregion

        #region PropertyType
        public Type PropertyType
        {
            get;
            set;
        }
        #endregion

        #region OwnerType
        public Type OwnerType
        {
            get;
            set;
        }
        #endregion

        internal DependencyProperty()
        {

        }

        static public DependencyProperty Register( string name, Type propertyType, Type ownerType )
        {
            return new DependencyProperty()
            {
                Name = name,
                PropertyType = propertyType,
                OwnerType = ownerType
            };
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals( object obj )
        {
            if ( obj == null )
                return false;

            DependencyProperty dp = obj as DependencyProperty;

            if ( dp == null )
                return false;

            return ( dp.Name == this.Name && dp.OwnerType == this.OwnerType && dp.PropertyType == dp.PropertyType );
        }

        public override string ToString()
        {
            return this.Name + " : " + this.PropertyType.ToString();
        }
    }
}