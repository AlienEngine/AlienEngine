namespace AlienEngine.Core.Physics.Character
{
    /// <summary>
    /// State of a contact relative to a speculative character position.
    /// </summary>
    public enum CharacterContactPositionState
    {
        Accepted,
        Rejected,
        TooDeep,
        Obstructed,
        HeadObstructed,
        NoHit
    }
}
