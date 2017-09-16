using BEPUphysics.PositionUpdating;

namespace AlienEngine.Core.Physics
{
    public enum CollisionUpdateMode
    {
        Continuous = PositionUpdateMode.Continuous,
        Discrete = PositionUpdateMode.Discrete,
        Passive = PositionUpdateMode.Passive
    }
}
