using System;

namespace dark_manor.Casting
{
    /// <summary>
    /// Defines an artifact, which is an actor that also has a description.
    /// </summary>
    public class TextBox : Actor
    {
        public TextBox()
        {
            _position = new Point(100, 300);
            SetText("");
        }
        
    }
}