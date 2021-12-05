using System;
using dark_manor.Services;
using dark_manor.Casting;
using dark_manor.Scripting;
using System.Collections.Generic;

namespace dark_manor
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create the cast
            Dictionary<string, List<Actor>> cast = new Dictionary<string, List<Actor>>();

            // Bricks
            cast["walls"] = new List<Actor>();
            Wall _wall = new Wall(400, 500, 400, 100);
            cast["walls"].Add(_wall);
            // TODO: Add your bricks here


            // The Ball (or balls if desired)
            cast["characters"] = new List<Actor>();

            // TODO: Add your ball here

            // The paddle
            cast["hero"] = new List<Actor>();
            Hero _hero = new Hero(600, 400);
            cast["hero"].Add(_hero);

            // TODO: Add your paddle here


            // Create the script
            Dictionary<string, List<Action>> script = new Dictionary<string, List<Action>>();

            OutputService outputService = new OutputService();
            InputService inputService = new InputService();
            PhysicsService physicsService = new PhysicsService();
            AudioService audioService = new AudioService();
            MapScrollerService mapScrollerService = new MapScrollerService();

            script["output"] = new List<Action>();
            script["input"] = new List<Action>();
            script["update"] = new List<Action>();

            DrawActorsAction drawActorsAction = new DrawActorsAction(outputService);
            script["output"].Add(drawActorsAction);

            // TODO: Add additional actions here to handle the input, move the actors, handle collisions, etc.

            MoveActorsAction moveActorsAction = new MoveActorsAction();
            script["update"].Add(moveActorsAction);
            HandleCollisionsAction handleCollisionsAction = new HandleCollisionsAction(physicsService);
            script["update"].Add(handleCollisionsAction);
            ControlActorsAction controlActorsAction = new ControlActorsAction(inputService);
            script["input"].Add(controlActorsAction);
            GravityAction gravityAction = new GravityAction();
            script["update"].Add(gravityAction);
        

            // Start up the game
            outputService.OpenWindow(Constants.MAX_X, Constants.MAX_Y, "Batter", Constants.FRAME_RATE);
            audioService.StartAudio();
            audioService.PlaySound(Constants.SOUND_START);

            Director theDirector = new Director(cast, script);
            theDirector.Direct();

            audioService.StopAudio();
        }
    }
}
