using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ChunkShapeGenerator : IChunkShapeGenerator
{
    private ChunkGenerationData _chunkGenerationData;

    public ChunkShapeGenerator(ChunkGenerationData chunkGenerationData)
    {
        _chunkGenerationData = chunkGenerationData;
    }

    public Vector3[] GenerateChunkShape(Vector3[] surfacePoints)
    {
        List<Vector3> shape = new List<Vector3>(surfacePoints.Length + 2);
        shape.Add(GenerateBasePoint(surfacePoints.First()));
        shape.AddRange(surfacePoints);
        shape.Add(GenerateBasePoint(surfacePoints.Last()));

        return shape.ToArray();
    }

    private Vector3 GenerateBasePoint(Vector3 referencePoint)
    {
        float basePointHeight = _chunkGenerationData.DepthIsStatic ? _chunkGenerationData.ChunkDepth : referencePoint.y - _chunkGenerationData.ChunkDepth;

        return new Vector3(referencePoint.x, basePointHeight);
    }
}
