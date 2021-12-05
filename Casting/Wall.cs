using System;

namespace dark_manor.Casting
{
    /// <summary>
    /// Defines an artifact, which is an actor that also has a description.
    /// </summary>
    public class Wall : Actor
    {
        public Wall(int x, int y, int width, int height)
        {
            _height = height;
            _width = width;
            _position = new Point(x, y);
        }
        
        public override bool HasGravity()
        {
            return false;
        }
    }
}