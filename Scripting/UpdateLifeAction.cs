using System.Collections.Generic;
using dark_manor.Casting;
using dark_manor.Services;


namespace dark_manor.Scripting
{
    /// <summary>
    /// An action to draw all of the actors in the game.
    /// </summary>
    public class UpdateLifeAction : Action
    {
        private ManageLivesService _manageLivesService;

        public UpdateLifeAction(ManageLivesService manageLivesService)
        {
            _manageLivesService = manageLivesService;
        }

        public override void Execute(Dictionary<string, List<Actor>> cast)
        {
            cast["lives"] = _manageLivesService.GetLives();
        }

    }
}