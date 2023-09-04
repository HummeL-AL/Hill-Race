using System.Collections.Generic;
using UnityEngine;

public class MapLoader : MonoBehaviour
{
    [SerializeField] private MapGenerationData _mapGenerationData;
    [SerializeField] private Transform _chunksParent;
    [SerializeField] private float _generationDistance;

    private IChunkFactory<LandscapeChunk> _chunkFactory;
    private MapGenerator _mapGenerator;
    private List<int> _loadedChunks = new();

    private void Start()
    {
        _chunkFactory = ServiceProvider.Container.Single<LandscapeChunkFactory>();
        _mapGenerator = new MapGenerator(_mapGenerationData, _chunksParent);

        UpdateForDistance(transform.position.z);
    }

    public void UpdateForDistance(float distance)
    {
        UpdateForPoint(Vector3.right * distance);
    }

    public void UpdateForPoint(Vector3 point)
    {
        int minVisibleChunk = Mathf.FloorToInt((point.x - _generationDistance) / _mapGenerationData.ChunkGenerationData.ChunkLength);
        int maxVisibleChunk = Mathf.CeilToInt((point.x + _generationDistance) / _mapGenerationData.ChunkGenerationData.ChunkLength);

        LoadMissingChunks(minVisibleChunk, maxVisibleChunk);
        UnloadInvisibleChunkes(minVisibleChunk, maxVisibleChunk);
    }

    private void LoadMissingChunks(int minId, int maxId)
    {
        for (int i = minId; i <= maxId; i++)
        {
            if (_loadedChunks.Contains(i))
                continue;

            GetChunk(i);
        }
    }

    private void UnloadInvisibleChunkes(int minId, int maxId)
    {
        List<int> _chunksToUnload = new();
        foreach(int chunkId in  _loadedChunks)
        {
            if(chunkId < minId ||  chunkId > maxId)
                _chunksToUnload.Add(chunkId);
        }

        foreach(int chunkId in _chunksToUnload)
        {
            UnloadChunk(chunkId);
        }
    }

    private LandscapeChunk GetChunk(int id)
    {
        LandscapeChunk chunk = IsChunkGenerated(id) ? LoadChunk(id) : GenerateChunk(id);
        _loadedChunks.Add(id);

        return chunk;
    }

    private LandscapeChunk GenerateChunk(int id)
    {
        return _mapGenerator.GenerateChunk(id);
    }

    private LandscapeChunk LoadChunk(int id)
    {
        LandscapeChunk chunk = _chunkFactory.Chunks[id];
        chunk.Load();

        return chunk;
    }

    private void UnloadChunk(int id)
    {
        LandscapeChunk chunk = _chunkFactory.Chunks[id];
        chunk.Unload();
        _loadedChunks.Remove(id);
    }

    private bool IsChunkGenerated(int id)
    {
        return _chunkFactory.Chunks.ContainsKey(id);
    }
}
