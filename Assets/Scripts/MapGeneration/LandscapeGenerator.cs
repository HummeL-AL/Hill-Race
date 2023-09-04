using UnityEngine;

public class LandscapeGenerator : ILandscapeGenerator
{
    private LandscapeGenerationData _landscapeGenerationData;
    private INoiseGenerator _noiseGenerator;

    public LandscapeGenerator(LandscapeGenerationData landscapeGenerationData)
    {
        _landscapeGenerationData = landscapeGenerationData;

        _noiseGenerator = new PerlinNoiseGenerator(landscapeGenerationData.NoiseGenerationData);
    }

    public Vector3[] Generate(float initialDistance, float length, int details)
    {
        Vector3[] surfacePoints = new Vector3[details];
        float step = length / (details - 1);

        for (int i = 0; i < details; i++)
        {
            surfacePoints[i] = GetPointPosition(i, initialDistance, step);
        }

        return surfacePoints;
    }

    private Vector3 GetPointPosition(int pointId, float initialDistance, float stepBetweenPoints)
    {
        float horizontalPosition = initialDistance + stepBetweenPoints * pointId;
        float verticalPosition = GetVerticalPosition(horizontalPosition);

        return new Vector3(horizontalPosition, verticalPosition);
    }

    private float GetVerticalPosition(float distance)
    {
        float rawHeight = _noiseGenerator.Generate(distance);
        float noiseHeight = rawHeight * _landscapeGenerationData.LandscapeHeightMultiplier;
        float basicHeight = noiseHeight + _landscapeGenerationData.LandscapeLevel;
        
        float heightLimit = _landscapeGenerationData.HeightLimit.Evaluate(distance);
        float limitedHeight = Mathf.Min(basicHeight, heightLimit);

        return limitedHeight;
    }
}
