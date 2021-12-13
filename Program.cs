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

            CreateEnviromentService createEnviromentService = new CreateEnviromentService();
            ManageLivesService manageLivesService = new ManageLivesService();

            // Bricks
            cast["walls"] = new List<Actor>();
            for (int i = 0; i < Constants.NUMBER_OF_SECTIONS; i++)
            {
                createEnviromentService.createEnviromentSection(cast, i);
            }

            cast["lives"] = new List<Actor>();
            
            for(int i = 0; i < 3; i++)
            {
                manageLivesService.AddLife();
            }

            cast["textBox"] = new List<Actor>();
            TextBox textBox = new TextBox();
            cast["textBox"].Add(textBox);

            cast["characters"] = new List<Actor>();
            Character character = new Character(3600, 250 - Constants.HERO_HEIGHT);
            cast["characters"].Add(character);

            cast["hero"] = new List<Actor>();
            Hero _hero = new Hero(Constants.HERO_X, Constants.HERO_Y);
            cast["hero"].Add(_hero);


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
            HandleCollisionsAction handleCollisionsAction = new HandleCollisionsAction(physicsService, inputService,
                                                                                       manageLivesService, mapScrollerService);
            script["update"].Add(handleCollisionsAction);
            ControlActorsAction controlActorsAction = new ControlActorsAction(inputService);
            script["input"].Add(controlActorsAction);
            GravityAction gravityAction = new GravityAction();
            script["update"].Add(gravityAction);
            HandleOffScreenAction handleOffScreenAction = new HandleOffScreenAction(mapScrollerService, manageLivesService);
            script["update"].Add(handleOffScreenAction);
            UpdateLifeAction updateLifeAction = new UpdateLifeAction(manageLivesService);
            script["update"].Add(updateLifeAction);
            HandleGameOverAction handleGameOverAction = new HandleGameOverAction();
            script["update"].Add(handleGameOverAction);
        

            // Start up the game
            outputService.OpenWindow(Constants.MAX_X, Constants.MAX_Y, "Dark Manor", Constants.FRAME_RATE);
            audioService.StartAudio();
            audioService.PlaySound(Constants.SOUND_START);

            Director theDirector = new Director(cast, script);
            theDirector.Direct();

            audioService.StopAudio();
        }
    }
}
