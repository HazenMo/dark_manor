using System;

namespace dark_manor.Casting
{
    /// <summary>
    /// Defines an artifact, which is an actor that also has a description.
    /// </summary>
    public class TextBox : Actor
    {
        public TextBox(int x, int y)
        {
            _height = Constants.BALL_HEIGHT;
            _width = Constants.BALL_WIDTH;
            _position = new Point(x, y);
        }
        
    }
}