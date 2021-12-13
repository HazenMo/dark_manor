using System;

namespace dark_manor.Casting
{
    /// <summary>
    /// Defines an artifact, which is an actor that also has a description.
    /// </summary>
    public class Life : Actor
    {
        public Life(int x, int y)
        {
            _height = Constants.LIFE_HEIGHT;
            _width = Constants.LIFE_WIDTH;
            _position = new Point(x, y);
            SetImage(Constants.IMAGE_LIFE);
        }

        public override bool HasGravity()
        {
            return false;
        }
        
    }
}