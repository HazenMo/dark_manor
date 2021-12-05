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
        

        public HandleCollisionsAction(PhysicsService physicsService)
        {
            _physicsService = physicsService;
        }

        public override void Execute(Dictionary<string, List<Actor>> cast)
        {
            Actor hero = cast["hero"][0];

            foreach(Actor wall in cast["walls"])
            {
                if(_physicsService.IsCollision(hero, wall))
                {
                    Point axis = _physicsService.GetCollisionEdge(hero, wall);

                    if(axis.GetX() == 1)
                    {
                        Point velocity = hero.GetVelocity();
                        int dy = velocity.GetY();
                        int yHero = hero.GetY();
                        int xWall = wall.GetRightEdge();

                        hero.SetVelocity(new Point(0, dy));                        
                        hero.SetPosition(new Point(xWall, yHero));
                        Console.WriteLine("Ping1");
                    }

                    else if(axis.GetX() == -1)
                    {
                        Point velocity = hero.GetVelocity();
                        int dy = velocity.GetY();
                        int yHero = hero.GetY();
                        int xWall = wall.GetLeftEdge();

                        hero.SetVelocity(new Point(0, dy));                        
                        hero.SetPosition(new Point((xWall - hero.GetWidth()), yHero));
                        Console.WriteLine("Ping2");

                    }

                    else if(axis.GetY() == -1)
                    {
                        Point velocity = hero.GetVelocity();
                        int dx = velocity.GetX();
                        int xHero = hero.GetX();
                        int yWall = wall.GetTopEdge();

                        hero.SetVelocity(new Point(dx, 0));                        
                        Console.WriteLine("Ping3");
                        hero.SetPosition(new Point(xHero, (yWall - hero.GetHeight())));
                    }

                    else
                    {
                        Point velocity = hero.GetVelocity();
                        int dx = velocity.GetX();
                        int xHero = hero.GetX();
                        int yWall = wall.GetBottomEdge();

                        hero.SetVelocity(new Point(dx, 0));                        
                        Console.WriteLine("Ping3");
                        hero.SetPosition(new Point(xHero, yWall));
                    }
                }
            }
        }

        
    }
}