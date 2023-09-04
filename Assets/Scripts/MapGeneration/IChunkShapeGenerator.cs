using UnityEngine;

public interface IChunkShapeGenerator
{
    public Vector3[] GenerateChunkShape(Vector3[] surfacePoints);
}
