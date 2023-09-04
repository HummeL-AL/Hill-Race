using UnityEngine;

public class ObjectFollower : MonoBehaviour
{
    [SerializeField] private Vector3 offset;

    private Transform _followedObject;

    public void Follow(Transform followedObject)
    {
        _followedObject = followedObject;
    }

    private void LateUpdate()
    {
        UpdatePosition();
    }

    private void UpdatePosition()
    {
        if (_followedObject == null)
            return;

        transform.position = _followedObject.position + offset;
    }
}
