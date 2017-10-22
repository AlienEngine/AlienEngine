namespace AlienEngine.Core.Physics.CollisionTests.Manifolds
{
    internal struct TerrainVertexIndices
    {
        public int ColumnIndex;
        public int RowIndex;

        public int ToSequentialIndex(int terrainWidth)
        {
            return RowIndex * terrainWidth + ColumnIndex;
        }
    }
}
