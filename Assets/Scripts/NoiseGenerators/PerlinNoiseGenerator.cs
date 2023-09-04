using UnityEngine;

public class PerlinNoiseGenerator : INoiseGenerator
{
    private const float _randomTilingRange = 9999f;

    private NoiseGenerationData _noiseGenerationData;
    private Vector2 _randomOffset;

    public PerlinNoiseGenerator(NoiseGenerationData noiseGenerationData)
    {
        _noiseGenerationData = noiseGenerationData;
        _randomOffset = GenerateOffset();
    }

    public float Generate(float x, float y)
    {
        Vector2 coordinates = new Vector2(x * _noiseGenerationData.Scale.x + _randomOffset.x, y * _noiseGenerationData.Scale.y + _randomOffset.y);
        float noiseValue = 0f;

        for(int i = 0; i < _noiseGenerationData.Octaves; i++)
        {
            float octaveMultiplier = Mathf.Pow(_noiseGenerationData.OctavePower, i);
            noiseValue += Mathf.PerlinNoise(coordinates.x, coordinates.y) * octaveMultiplier;
            coordinates *= _noiseGenerationData.OctaveScale;
        }

        return noiseValue;
    }

    private Vector2 GenerateOffset()
    {
        int seed = Random.Range(int.MinValue, int.MaxValue);
        return GenerateOffset(seed);
    }

    private Vector2 GenerateOffset(int seed)
    {
        Random.State oldState = Random.state;
        Random.InitState(seed);

        float xOffset = Random.Range(-_randomTilingRange, _randomTilingRange) * _noiseGenerationData.Scale.x;
        float yOffset = Random.Range(-_randomTilingRange, _randomTilingRange) * _noiseGenerationData.Scale.y;
        Vector2 offset = new Vector2(xOffset, yOffset);

        Random.state = oldState;

        return offset;
    }
}
