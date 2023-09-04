using UnityEngine;

[CreateAssetMenu(fileName = "LandscapeData", menuName = "GenerationDatas/LandscapeData", order = 0)]
public class LandscapeGenerationData : ScriptableObject
{
    [SerializeField] private NoiseGenerationData _noiseGenerationData;
    [SerializeField] private AnimationCurve _heightLimit;
    [SerializeField] private float _landscapeLevel;
    [SerializeField] private float _landscapeHeightMultiplier;

    public NoiseGenerationData NoiseGenerationData => _noiseGenerationData;
    public AnimationCurve HeightLimit => _heightLimit;
    public float LandscapeLevel => _landscapeLevel;
    public float LandscapeHeightMultiplier => _landscapeHeightMultiplier;
}
