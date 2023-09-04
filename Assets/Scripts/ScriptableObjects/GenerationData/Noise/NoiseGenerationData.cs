using UnityEngine;

[CreateAssetMenu(fileName = "NoiseData", menuName = "GenerationDatas/Noise/NoiseData", order = 0)]
public class NoiseGenerationData : ScriptableObject
{
    [SerializeField] private Vector2 _scale;
    [SerializeField] private int _octaves;
    [SerializeField] private float _octaveScale;
    [SerializeField] private float _octavePower;

    public Vector2 Scale => _scale;
    public int Octaves => _octaves;
    public float OctaveScale => _octaveScale;
    public float OctavePower => _octavePower;
}
