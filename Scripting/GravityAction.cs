using System.Collections.Generic;
using dark_manor.Casting;
using dark_manor.Services;


namespace dark_manor.Scripting
{
    /// <summary>
    /// An action to move all actors forward according to their current velocities.
    /// </summary>
    public class GravityAction : Action
    {

        public GravityAction()
        {
        }

        public override void Execute(Dictionary<string, List<Actor>> cast)
        {
            foreach (List<Actor> group in cast.Values)
            {
                foreach (Actor actor in group)
                {
                    if (actor.HasGravity())
                    {
                        DragDown(actor);
                    }
                }
            }
        }

        private void DragDown(Actor actor)
        {
            int dx = actor.GetVelocity().GetX();
            int dy = actor.GetVelocity().GetY();

            int newDy = dy + 1;

            actor.SetVelocity(new Point(dx, newDy));
        }
        

    }
}