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
        InputService _inputService = new InputService();
        MapScrollerService _mapScrollerService = new MapScrollerService();
        ManageLivesService _manageLivesService = new ManageLivesService();
        List<Actor> removalList = new List<Actor>();
        AudioService _audioService = new AudioService();

        public HandleCollisionsAction(PhysicsService physicsService, InputService inputService, 
                                      ManageLivesService manageLivesService, MapScrollerService mapScrollerService)
        {
            _physicsService = physicsService;
            _inputService = inputService;
            _manageLivesService = manageLivesService;
            _mapScrollerService = mapScrollerService;
        }

        public override void Execute(Dictionary<string, List<Actor>> cast)
        {
            Actor hero = new Actor();
            if(cast["hero"].Count > 0)
            {
                hero = cast["hero"][0];
            }

            Point heroVelocity = hero.GetVelocity();


            foreach(Actor wall in cast["walls"])
            {
                if(_physicsService.IsCollision(hero, wall))
                {
                    string position = _physicsService.GetCollisionEdge(hero, wall);

                    if(position == "right")
                    {
                        Point velocity = hero.GetVelocity();
                        int dy = velocity.GetY();
                        int yHero = hero.GetY();
                        int xWall = wall.GetRightEdge();

                        if(dy > 0)
                        {
                            dy--;
                        }
                        else if(dy < 0)
                        {
                            dy++;
                        }

                        hero.SetVelocity(new Point(0, dy));                        
                        hero.SetPosition(new Point(xWall, yHero));

                        
                        _inputService.setCanJump(true);
                    }

                    else if(position == "left")
                    {
                        Point velocity = hero.GetVelocity();
                        int dy = velocity.GetY();
                        int yHero = hero.GetY();
                        int xWall = wall.GetLeftEdge();

                        if(dy > 0)
                        {
                            dy--;
                        }
                        else if(dy < 0)
                        {
                            dy++;
                        }

                        hero.SetVelocity(new Point(0, dy));                        
                        hero.SetPosition(new Point((xWall - hero.GetWidth()), yHero));
                        
                        _inputService.setCanJump(true);

                    }

                    else if(position == "above")
                    {
                        Point velocity = hero.GetVelocity();
                        int dx = velocity.GetX();
                        int xHero = hero.GetX();
                        int yWall = wall.GetTopEdge();

                        if(dx > 0)
                        {
                            dx--;
                        }
                        else if(dx < 0)
                        {
                            dx++;
                        }

                        hero.SetVelocity(new Point(dx, 0));
                        hero.SetPosition(new Point(xHero, (yWall - hero.GetHeight())));
                        
                        _inputService.setCanJump(true);
                    }

                    else
                    {
                        Point velocity = hero.GetVelocity();
                        int dx = velocity.GetX();
                        int xHero = hero.GetX();
                        int yWall = wall.GetBottomEdge();

                        if(dx > 0)
                        {
                            dx--;
                        }
                        else if(dx < 0)
                        {
                            dx++;
                        }

                        hero.SetVelocity(new Point(dx, 0));
                        hero.SetPosition(new Point(xHero, yWall));
                        
                        _inputService.setCanJump(true);
                    }
                }

                if(heroVelocity.GetY() < 0)
                {
                    _inputService.setCanJump(false);
                }
                
            }

            foreach(Actor character in cast["characters"])
            {
                if(_physicsService.IsCollision(hero, character))
                {
                    string position = _physicsService.GetCollisionEdge(hero, character);

                    if(position == "right")
                    {
                        _manageLivesService.RemoveLife();
                        _mapScrollerService.mapScrollToStart(cast);
                    }

                    else if(position == "left")
                    {
                        _manageLivesService.RemoveLife();
                        _mapScrollerService.mapScrollToStart(cast);

                    }

                    else if(position == "above")
                    {
                        _audioService.PlaySound(Constants.SOUND_KILL);
                        removalList.Add(character);
                        
                        int dx = hero.GetVelocity().GetX();
                        hero.SetVelocity(new Point(dx, -10));
                    }

                    
                }


                
            }

            foreach (Actor actor in removalList)
            {
                cast["characters"].Remove(actor);
            }
            
        }

        
    }
}