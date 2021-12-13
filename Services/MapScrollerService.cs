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

            hero.SetPosition(new Point(Constants.SCREEN_SECTION_THREE + 1, newY));

            foreach (Actor wall in cast["walls"])
            {
            int xWall = wall.GetX();
            int yWall = wall.GetY();

            int newX = (xWall + (dxHero * -1));

            wall.SetPosition(new Point(newX, yWall));
            }

            foreach (Actor character in cast["characters"])
            {
            int xCharacter = character.GetX();
            int yCharacter = character.GetY();

            int newX = (xCharacter + (dxHero * -1));

            character.SetPosition(new Point(newX, yCharacter));
            }
        }

        public void ScrollMapLeft(Actor hero, Dictionary<string, List<Actor>> cast)
        {
            int yHero = hero.GetY();

            int dxHero = hero.GetVelocity().GetX();
            int dyHero = hero.GetVelocity().GetY();

            int newY = (yHero + dyHero);

            hero.SetPosition(new Point(Constants.SCREEN_SECTION_ONE - 1, newY));

            foreach (Actor wall in cast["walls"])
            {
            int xWall = wall.GetX();
            int yWall = wall.GetY();

            int newX = (xWall + (dxHero * -1));

            wall.SetPosition(new Point(newX, yWall));
            }

            foreach (Actor character in cast["characters"])
            {
            int xCharacter = character.GetX();
            int yCharacter = character.GetY();

            int newX = (xCharacter + (dxHero * -1));

            character.SetPosition(new Point(newX, yCharacter));
            }
        }

        public void mapScrollToStart(Dictionary<string, List<Actor>> cast)
        {
            Actor baseWall = cast["walls"][0];
            int difference = baseWall.GetX();

            foreach (Actor wall in cast["walls"])
            {
            int xWall = wall.GetX();
            int yWall = wall.GetY();

            int newX = xWall - difference;

            wall.SetPosition(new Point(newX, yWall));
            }

            foreach (Actor character in cast["characters"])
            {
            int xCharacter = character.GetX();
            int yCharacter = character.GetY();

            int newX = xCharacter - difference;

            character.SetPosition(new Point(newX, yCharacter));
            }

        }

    }
}