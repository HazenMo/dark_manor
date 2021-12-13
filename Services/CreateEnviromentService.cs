using System.Collections.Generic;
using dark_manor.Casting;
using dark_manor.Services;
using System;


namespace dark_manor.Scripting
{
    /// <summary>
    /// An action to move all actors forward according to their current velocities.
    /// </summary>
    public class CreateEnviromentService
    {

        public CreateEnviromentService()
        {
        }

        public void createEnviromentSection(Dictionary<string, List<Actor>> cast, int section)
        {
            for (int xIndex = 0; xIndex < Constants.WALL_SECTIONS[section][2]; xIndex++)
            {
                for (int yIndex = 0; yIndex < Constants.WALL_SECTIONS[section][3]; yIndex++)
                {
                    Wall wall = new Wall(xIndex * Constants.WALL_WIDTH + Constants.WALL_SECTIONS[section][0] , yIndex * Constants.WALL_HEIGHT + Constants.WALL_SECTIONS[section][1]);
                    cast["walls"].Add(wall);
                }
            }
        }

    }
}