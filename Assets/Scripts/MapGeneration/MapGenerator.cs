using UnityEngine;

public class MapGenerator
{
    private MapGenerationData _mapGenerationData;
    private Transform _chunksParent;

    private IChunkFactory<LandscapeChunk> _chunkFactory;
    private ILandscapeGenerator _landscapeGenerator;
    private IChunkShapeGenerator _chunkShapeGenerator;

    public MapGenerator(MapGenerationData mapGenerationData, Transform chunksParent)
    {
        _mapGenerationData = mapGenerationData;
        _chunksParent = chunksParent;

        _chunkFactory = ServiceProvider.Container.Single<LandscapeChunkFactory>();
        _landscapeGenerator = new LandscapeGenerator(_mapGenerationData.LandscapeGenerationData);
        _chunkShapeGenerator = new ChunkShapeGenerator(_mapGenerationData.ChunkGenerationData);
    }

    public LandscapeChunk GenerateChunk(int chunkId)
    {
        Vector3 spawnPosition = Vector3.right * _mapGenerationData.ChunkGenerationData.ChunkLength * chunkId;
        LandscapeChunk chunk = _chunkFactory.Create(chunkId, _chunksParent, spawnPosition);

        Vector3[] chunkShape = GetChunkShape(chunkId);
        chunk.SetShape(chunkShape);
        chunk.ShapeController.enabled = true;

        return chunk;
    }

    private Vector3[] GetChunkShape(int chunkId)
    {
        float chunkLength = _mapGenerationData.ChunkGenerationData.ChunkLength;
        float initialDistance = -chunkLength / 2f + chunkLength * chunkId;
        int surfacePointCount = _mapGenerationData.ChunkGenerationData.ChunkSections;

        Vector3[] surfacePoints = _landscapeGenerator.Generate(initialDistance, chunkLength, surfacePointCount);
        return _chunkShapeGenerator.GenerateChunkShape(surfacePoints);
    }
}