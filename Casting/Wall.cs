using System;
using System.Collections.Generic;

namespace dark_manor.Casting
{
    /// <summary>
    /// Defines an artifact, which is an actor that also has a description.
    /// </summary>
    public class Wall : Actor
    {
        
        public Wall(int x, int y)
        {
            _height = Constants.WALL_HEIGHT;
            _width = Constants.WALL_WIDTH;
            _position = new Point(x, y);
            SetImage(Constants.IMAGE_WALL);
        }
        
        public override bool HasGravity()
        {
            return false;
        }

        public void createEnviromentSection(Dictionary<string, List<Actor>> cast, int section)
        {
            for (int xIndex = 0; xIndex < 2; xIndex++)
            {
                for (int yIndex = 0; yIndex < 4; yIndex++)
                {
                    Wall wall = new Wall(xIndex * Constants.WALL_WIDTH, yIndex * Constants.WALL_HEIGHT);
                    cast["walls"].Add(wall);
                }
            }
        }
    }
}