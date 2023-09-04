using UnityEngine;

public interface IShapedChunk : IChunk
{
    public void SetShape(Vector3[] surfacePoints);
}