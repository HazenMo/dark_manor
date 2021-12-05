using System.Collections.Generic;
using dark_manor.Casting;
using dark_manor.Services;


namespace dark_manor.Scripting
{
    /// <summary>
    /// An action to move all actors forward according to their current velocities.
    /// </summary>
    public class ControlActorsAction : Action
    {
        InputService _inputService;

        public ControlActorsAction(InputService inputService)
        {
            _inputService = inputService;
        }

        public override void Execute(Dictionary<string, List<Actor>> cast)
        {
            Point direction = _inputService.GetDirection();

            Actor hero = cast["hero"][0];

            Point velocityAdder = direction.Scale(Constants.HERO_SPEED);
            Point newVelocity = hero.GetVelocity().Add(velocityAdder);
                
            hero.SetVelocity(newVelocity);

        }

        
    }
}