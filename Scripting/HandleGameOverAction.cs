using System.Collections.Generic;
using dark_manor.Casting;
using dark_manor.Services;


namespace dark_manor.Scripting
{
    /// <summary>
    /// An action to draw all of the actors in the game.
    /// </summary>
    public class HandleGameOverAction : Action
    {
        AudioService audioService = new AudioService();
        bool _game_over;
        public HandleGameOverAction()
        {
            _game_over = false;
        }

        public override void Execute(Dictionary<string, List<Actor>> cast)
        {
            if (cast["lives"].Count <= 0)
            {
                if(cast["hero"].Count > 0)
                {
                    audioService.PlaySound(Constants.SOUND_OVER);
                }
                cast["textBox"][0].SetText("GAME OVER");
                cast["hero"].Clear();
                
            }

            else if (cast["characters"].Count == 0)
            {
                if(_game_over == false)
                {
                    audioService.PlaySound(Constants.SOUND_WIN);
                }
                cast["textBox"][0].SetText("YOU WIN!");
                _game_over = true;
            }
        }

    }
}