using UnityEngine;

public interface ILandscapeGenerator
{
    public Vector3[] Generate(float initialDistance, float length, int details);
}
