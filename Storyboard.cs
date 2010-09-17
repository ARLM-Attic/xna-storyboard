using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace XNAStoryboard
{
    public class Storyboard : GameComponent
    {
        #region Children
        public List<ITimeline> Children
        {
            get;
            private set;
        }
        #endregion

        public delegate void CompletedEventHandler( Storyboard sender );
        public event CompletedEventHandler Completed;

        private bool isPlaying = false;

        public Storyboard( Game game )
            : base( game )
        {
            game.Components.Add( this );
            this.Children = new List<ITimeline>();
        }

        public void Begin()
        {
            this.isPlaying = true;
            this.Children.ForEach( a => a.Begin() );
        }

        public override void Update( GameTime gameTime )
        {
            if ( !this.isPlaying )
                return;
            
            int finishedCount = 0;

            this.Children.ForEach( a =>
            {
                if ( a.GetIsFinisihed() )
                    finishedCount++;
                else
                    a.Update( gameTime.ElapsedGameTime );
            } );

            if ( this.Children.Count == finishedCount )
            {
                if ( this.Completed != null )
                {
                    this.Completed( this );
                    this.isPlaying = false;
                }
            }

            base.Update( gameTime );
        }
    }
}
