using System;
using AlienEngine.Core.Physics.BroadPhaseEntries.MobileCollidables;
using AlienEngine.Core.Physics.OtherSpaceStages;

namespace AlienEngine.Core.Physics.BroadPhaseEntries.Events
{
    /// <summary>
    /// Event manager for use with the CompoundCollidable.
    /// It's possible to use the ContactEventManager directly with a compound,
    /// but without using this class, any child event managers will fail to dispatch
    /// deferred events.
    /// </summary>
    public class CompoundEventManager : ContactEventManager<EntityCollidable>
    {

        protected override void DispatchEvents()
        {
            //Go through all children and dispatch events.
            //They won't be touched by the primary event manager otherwise.
            var compound = this.owner as CompoundCollidable;
            if (compound != null)
            {
                foreach (var child in compound.children)
                {
                    var deferredEventCreator = child.CollisionInformation.events as IDeferredEventCreator;
                    if (deferredEventCreator.IsActive)
                        deferredEventCreator.DispatchEvents();
                }
            }
            else
            {
                throw new InvalidOperationException("Cannot use a CompoundEventManager with anything but a CompoundCollidable.");
            }
            base.DispatchEvents();
        }
    }

}
