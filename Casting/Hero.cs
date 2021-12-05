using System;

namespace dark_manor.Casting
{
    /// <summary>
    /// Defines an artifact, which is an actor that also has a description.
    /// </summary>
    public class Hero : Actor
    {
        public Hero(int x, int y)
        {
            _height = Constants.HERO_HEIGHT;
            _width = Constants.HERO_WIDTH;
            _position = new Point(x, y);
        }
        
    }
}