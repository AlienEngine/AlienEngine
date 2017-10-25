namespace AlienEngine.Core.Physics.Materials
{
    ///<summary>
    /// Defines an object that has a material.
    ///</summary>
    public interface IPhysicsMaterialOwner
    {
        ///<summary>
        /// Gets or sets the material of the object.
        ///</summary>
        PhysicsMaterial Material { get; set; }
    }
}
