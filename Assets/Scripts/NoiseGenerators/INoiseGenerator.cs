public interface INoiseGenerator
{
    public float Generate(float x)
    {
        return Generate(x, 0f);
    }

    public float Generate(float x, float y);
}
