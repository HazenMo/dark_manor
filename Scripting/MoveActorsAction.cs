using System.Collections.Generic;
using dark_manor.Casting;
using dark_manor.Services;


namespace dark_manor.Scripting
{
    /// <summary>
    /// An action to move all actors forward according to their current velocities.
    /// </summary>
    public class MoveActorsAction : Action
    {
        MapScrollerService mapScrollerService = new MapScrollerService();
        public MoveActorsAction()
        {
            
        }

        public override void Execute(Dictionary<string, List<Actor>> cast)
        {
            Actor hero = cast["hero"][0];

            int heroRight = hero.GetRightEdge();
            int heroLeft = hero.GetLeftEdge();
            if (heroLeft >= Constants.SCREEN_SECTION_ONE && heroLeft <= Constants.SCREEN_SECTION_THREE)
            {
                MoveActor(hero);
            }

            else if (heroLeft < Constants.SCREEN_SECTION_ONE)
            {
                mapScrollerService.ScrollMapLeft(hero, cast);
            }

            else if (heroRight > Constants.SCREEN_SECTION_THREE)
            {
                mapScrollerService.ScrollMapRight(hero, cast);
            }

        }
        
        private void MoveActor(Actor actor)
        {
            int x = actor.GetX();
            int y = actor.GetY();

            int dx = actor.GetVelocity().GetX();
            int dy = actor.GetVelocity().GetY();

            int newX = (x + dx);
            int newY = (y + dy);

            actor.SetPosition(new Point(newX, newY));
        }

    }
}