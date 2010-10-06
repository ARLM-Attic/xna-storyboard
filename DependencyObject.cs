using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;

namespace XNAStoryboard
{
    public class DependencyObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Dictionary<object, object> properties = new Dictionary<object, object>();

        public DependencyObject()
        {
        }

        public object GetValue( DependencyProperty property )
        {
            return this.GetValue<object>( property );
        }

        public T GetValue<T>( DependencyProperty property )
        {
            if ( this.properties == null )
                return default( T );

            if ( !this.properties.ContainsKey( property ) )
                return default( T );

            return (T) this.properties[ property ];
        }

        public void SetValue( DependencyProperty property, object value )
        {
            if ( this.properties.ContainsKey( property ) )
            {
                this.properties[ property ] = value;
                this.NotifyPropertyChanged( property.Name );

                return;
            }

            this.properties.Add( property, value );
            this.NotifyPropertyChanged( property.Name );
        }

        protected void NotifyPropertyChanged( string propertyName )
        {
            if ( this.PropertyChanged != null )
                this.PropertyChanged( propertyName );
        }
    }
}