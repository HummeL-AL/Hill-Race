using UnityEngine;

[CreateAssetMenu(fileName = "ChunkData", menuName = "GenerationDatas/ChunkData", order = 0)]
public class ChunkGenerationData : ScriptableObject
{
    [SerializeField] private float _chunkLength;
    [Min(2)]
    [SerializeField] private int _chunkSections;
    [SerializeField] private float _chunkDepth;
    [SerializeField] private bool _depthIsStatic;

    public float ChunkLength => _chunkLength;
    public int ChunkSections => _chunkSections;
    public float ChunkDepth => _chunkDepth;
    public bool DepthIsStatic => _depthIsStatic;
}
