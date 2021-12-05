using System.Collections.Generic;
using dark_manor.Casting;
using dark_manor.Services;
using System;


namespace dark_manor.Services
{
    /// <summary>
    /// An action to move all actors forward according to their current velocities.
    /// </summary>
    public class MapScrollerService
    {
        public MapScrollerService()
        {
        }

        public void ScrollMapRight(Actor hero, Dictionary<string, List<Actor>> cast)
        {
            int yHero = hero.GetY();

            int dxHero = hero.GetVelocity().GetX();
            int dyHero = hero.GetVelocity().GetY();

            int newY = (yHero + dyHero);

            hero.SetPosition(new Point(Constants.SCREEN_SECTION_THREE, newY));

            foreach (Actor wall in cast["walls"])
            {
            int xWall = wall.GetX();
            int yWall = wall.GetY();

            int newX = (xWall + (dxHero * -1));

            wall.SetPosition(new Point(newX, yWall));
            }
        }

        public void ScrollMapLeft(Actor hero, Dictionary<string, List<Actor>> cast)
        {
            int yHero = hero.GetY();

            int dxHero = hero.GetVelocity().GetX();
            int dyHero = hero.GetVelocity().GetY();

            int newY = (yHero + dyHero);

            hero.SetPosition(new Point(Constants.SCREEN_SECTION_ONE, newY));

            foreach (Actor wall in cast["walls"])
            {
            int xWall = wall.GetX();
            int yWall = wall.GetY();

            int newX = (xWall + (dxHero * -1));

            wall.SetPosition(new Point(newX, yWall));
            }
        }
        
    }
}