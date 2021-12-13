using System;
using Raylib_cs;
using dark_manor.Casting;
using System.Collections.Generic;

namespace dark_manor.Services
{
    /// <summary>
    /// Handles all the physics related parts of the game such as
    /// determining collisions.
    /// </summary>
    public class PhysicsService
    {
        public PhysicsService()
        {

        }

        /// <summary>
        /// Returns true if the two actors overlap.
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public bool IsCollision(Actor first, Actor second)
        {
            int x1 = first.GetX();
            int y1 = first.GetY();
            int width1 = first.GetWidth();
            int height1 = first.GetHeight();

            Raylib_cs.Rectangle rectangle1
                = new Raylib_cs.Rectangle(x1, y1, width1, height1);

            int x2 = second.GetX();
            int y2 = second.GetY();
            int width2 = second.GetWidth();
            int height2 = second.GetHeight();

            Raylib_cs.Rectangle rectangle2
                = new Raylib_cs.Rectangle(x2, y2, width2, height2);

            return Raylib.CheckCollisionRecs(rectangle1, rectangle2);
        }

        public string GetCollisionEdge(Actor first, Actor second)
        {
            int xMiddle1 = first.GetMiddleX();
            int yMiddle1 = first.GetMiddleY();

            int xMiddle2 = second.GetMiddleX();
            int yMiddle2 = second.GetMiddleY();

            if (xMiddle1 >= xMiddle2 && yMiddle1 >= yMiddle2)
            {
                int left1 = first.GetLeftEdge();
                int top1 = first.GetTopEdge();

                int right2 = second.GetRightEdge();
                int bottom2 = second.GetBottomEdge();

                int xOverlap = right2 - left1;
                int yOverlap = bottom2 - top1;

                if(xOverlap > yOverlap)
                {
                    return "beneath";
                }

                else
                {
                    return "right";
                }
            }

            else if (xMiddle1 < xMiddle2 && yMiddle1 > yMiddle2)
            {
                int right1 = first.GetRightEdge();
                int top1 = first.GetTopEdge();

                int left2 = second.GetLeftEdge();
                int bottom2 = second.GetBottomEdge();

                int xOverlap = right1 - left2;
                int yOverlap = bottom2 - top1;

                if (xOverlap > yOverlap)
                {
                    return "beneath";
                }

                else
                {
                    return "left";
                }
            }

            else if (xMiddle1 <= xMiddle2 && yMiddle1 <= yMiddle2)
            {
                int right1 = first.GetRightEdge();
                int bottom1 = first.GetBottomEdge();

                int left2 = second.GetLeftEdge();
                int top2 = second.GetTopEdge();

                int xOverlap = right1 - left2;
                int yOverlap = bottom1 - top2;

                if (xOverlap > yOverlap)
                {
                    return "above";
                }

                else
                {
                    return "left";
                }
            }

            else
            {
                int left1 = first.GetLeftEdge();
                int bottom1 = first.GetBottomEdge();

                int right2 = second.GetRightEdge();
                int top2 = second.GetTopEdge();

                int xOverlap = right2 - left1;
                int yOverlap = bottom1 - top2;

                if (xOverlap > yOverlap)
                {
                    return "above";
                }

                else
                {
                    return "right";
                }
            }

        }
    }

}