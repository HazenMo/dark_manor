using System.Collections.Generic;
using dark_manor.Casting;
using dark_manor.Services;


namespace dark_manor.Scripting
{
    /// <summary>
    /// An action to move all actors forward according to their current velocities.
    /// </summary>
    public class HandleOffScreenAction : Action
    {
        MapScrollerService _mapScrollerService = new MapScrollerService();
        ManageLivesService _manageLivesService = new ManageLivesService();
        public HandleOffScreenAction(MapScrollerService mapScrollerService, ManageLivesService manageLivesService)
        {
            _mapScrollerService = mapScrollerService;
            _manageLivesService = manageLivesService;
        }

        public override void Execute(Dictionary<string, List<Actor>> cast)
        {
            foreach (Actor actor in cast["hero"])
            {
                int x = actor.GetX();
                int y = actor.GetY();
                
                if (y >= Constants.MAX_Y + 25)
                {
                    _manageLivesService.RemoveLife();
                    Point startPosition = new Point(Constants.HERO_X, Constants.HERO_Y);
                    actor.SetPosition(startPosition);
                    Point startVelocity = new Point(0, 0);
                    actor.SetVelocity(startVelocity);

                    _mapScrollerService.mapScrollToStart(cast);
                }
            }
            
        }

        
    }
}