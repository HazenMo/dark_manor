using System.Collections.Generic;
using dark_manor.Casting;
using dark_manor.Services;
using System;


namespace dark_manor.Scripting
{
    /// <summary>
    /// An action to move all actors forward according to their current velocities.
    /// </summary>
    public class HandleCollisionsAction : Action
    {
        PhysicsService _physicsService = new PhysicsService();
        List<Actor> _removalList = new List<Actor>();
        

        public HandleCollisionsAction(PhysicsService physicsService)
        {
            _physicsService = physicsService;
        }

        public override void Execute(Dictionary<string, List<Actor>> cast)
        {
        
        }        
    }
}