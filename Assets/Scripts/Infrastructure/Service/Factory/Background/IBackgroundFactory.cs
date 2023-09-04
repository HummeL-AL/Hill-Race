using UnityEngine;

public interface IBackgroundFactory : IFactory
{
    public ObjectFollower Create();
}