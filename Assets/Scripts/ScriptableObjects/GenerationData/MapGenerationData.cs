using UnityEngine;

[CreateAssetMenu(fileName = "MapData", menuName = "GenerationDatas/MapData", order = 0)]
public class MapGenerationData : ScriptableObject
{
    [SerializeField] private ChunkGenerationData _chunkGenerationData;
    [SerializeField] private LandscapeGenerationData _landscapeGenerationData;

    public ChunkGenerationData ChunkGenerationData => _chunkGenerationData;
    public LandscapeGenerationData LandscapeGenerationData => _landscapeGenerationData;
}
