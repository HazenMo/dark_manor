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
        }

        
    }
}