using System.Collections.Generic;
using UnityEngine;

public class LandscapeChunkFactory : IChunkFactory<LandscapeChunk>
{
    public const string LandscapeChunkPath = "Chunks/LandscapeChunk";

    public Dictionary<int, LandscapeChunk> Chunks { get; }

    private IAssetsProvider _assetsProvider;
    private LandscapeChunk _landscapeChunkPrefab;

    public LandscapeChunkFactory()
    {
        Chunks = new Dictionary<int, LandscapeChunk>();

        _assetsProvider = ServiceProvider.Container.Single<AssetsProvider>();
        _landscapeChunkPrefab = _assetsProvider.LoadAsset<LandscapeChunk>(LandscapeChunkPath);
    }

    public LandscapeChunk Create(int id, Transform parent = null, Vector3 spawnPosition = default)
    {
        LandscapeChunk chunk = GameObject.Instantiate(_landscapeChunkPrefab, spawnPosition, Quaternion.identity, parent);
        chunk.name = $"Chunk {id}";
        Chunks.Add(id, chunk);

        return chunk;
    }
}
