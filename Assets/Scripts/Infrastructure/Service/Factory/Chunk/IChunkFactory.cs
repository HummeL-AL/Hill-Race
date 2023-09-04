using System.Collections.Generic;
using UnityEngine;

public interface IChunkFactory<TChunk> : IFactory where TChunk : IChunk
{
    public Dictionary<int, LandscapeChunk> Chunks { get; }

    public TChunk Create(int id, Transform parent = null, Vector3 spawnPosition = default);
}