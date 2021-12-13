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
            if (cast["hero"].Count > 0)
            {
                Actor hero = cast["hero"][0];

                int heroRight = hero.GetRightEdge();
                int heroLeft = hero.GetLeftEdge();

                if (heroLeft < Constants.SCREEN_SECTION_ONE && hero.GetVelocity().GetX() < 0)
                {
                    mapScrollerService.ScrollMapLeft(hero, cast);
                }

                else if (heroLeft > Constants.SCREEN_SECTION_THREE && hero.GetVelocity().GetX() > 0)
                {
                    mapScrollerService.ScrollMapRight(hero, cast);
                }

                else
                {
                    MoveActor(hero);
                }
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