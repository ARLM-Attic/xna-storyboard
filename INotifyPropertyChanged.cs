using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XNAStoryboard
{
    public delegate void PropertyChangedEventHandler( string propertyName );

    public interface INotifyPropertyChanged
    {        
        event PropertyChangedEventHandler PropertyChanged;
    }
}