namespace AlienEngine.Core.Physics.DeactivationManagement
{
    /// <summary>
    /// Defines an object which owns a SimulationIslandMember.
    /// </summary>
    public interface ISimulationIslandMemberOwner
    {
        /// <summary>
        /// Gets the simulation island member associated with the object.
        /// </summary>
        SimulationIslandMember ActivityInformation { get; }
    }
}
