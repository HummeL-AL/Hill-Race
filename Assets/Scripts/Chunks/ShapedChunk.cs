using UnityEngine;
using UnityEngine.U2D;

public class ShapedChunk : MonoBehaviour, IShapedChunk
{
    [SerializeField] private SpriteShapeController _shapeController;
    public SpriteShapeController ShapeController => _shapeController;

    public virtual void Load()
    {
        gameObject.SetActive(true);
    }

    public virtual void Unload()
    {
        gameObject.SetActive(false);
    }

    public void SetShape(Vector3[] shapePoints)
    {
        if (ShapeController == null)
            return;

        UpdateShape(shapePoints);
    }

    private void UpdateShape(Vector3[] shapePoints)
    {
        ShapeController.spline.Clear();

        for (int i = 0; i < shapePoints.Length; i++)
        {
            ApplyPoint(i, shapePoints[i]);

            if (IsNeedToGenerateTangent(i - 1, shapePoints.Length))
            {
                CreatePointTangents(i - 1);
            }
        }
    }

    private void ApplyPoint(int index, Vector3 point)
    {
        Vector3 realtivePosition = point - transform.position;
        ShapeController.spline.InsertPointAt(index, realtivePosition);
    }

    private bool IsNeedToGenerateTangent(int index, int shapeLength, int offset = 2)
    {
        int minId = offset;
        int maxId = shapeLength - 1 - offset;
        if (index >= minId && index <= maxId)
            return true;

        return false;
    }

    private void CreatePointTangents(int pointId)
    {
        Vector3 previousPoint = ShapeController.spline.GetPosition(pointId - 1);
        Vector3 currentPoint = ShapeController.spline.GetPosition(pointId);
        Vector3 nextPoint = ShapeController.spline.GetPosition(pointId + 1);

        Vector3 previousPointDirection = previousPoint - currentPoint;
        Vector3 nextPointDirection = nextPoint - currentPoint;
        Vector3 tangentDirection = nextPointDirection - previousPointDirection;

        float distanceBeetweenPoints = nextPoint.x - previousPoint.x;

        CreateTangents(pointId, tangentDirection.normalized, distanceBeetweenPoints / 4f);
    }

    private void CreateTangents(int pointId, Vector3 direction, float scale)
    {
        ShapeController.spline.SetTangentMode(pointId, ShapeTangentMode.Continuous);
        ShapeController.spline.SetLeftTangent(pointId, -direction * scale);
        ShapeController.spline.SetRightTangent(pointId, direction * scale);
    }
}
