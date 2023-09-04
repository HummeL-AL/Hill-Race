using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Vector2 _scrollSpeed;
    [SerializeField] private Vector2 _tiling;

    private Vector3 _compensationOffset;
    private float _width;
    private float _height;

    private void Awake()
    {
        Vector2 size = CalculateSize();
        UpdateTiling(size);
    }

    private void LateUpdate()
    {
        UpdatePosition();
    }

    private Vector2 CalculateSize()
    {
        Sprite sprite = _spriteRenderer.sprite;
        Texture2D texture = sprite.texture;

        _width = texture.width / sprite.pixelsPerUnit;
        _height = texture.height / sprite.pixelsPerUnit;

        return new Vector2(_width, _height);
    }

    private void UpdateTiling(Vector2 size)
    {
        Vector2 tiledSize = new Vector2(size.x * _tiling.x, size.y * _tiling.y);
        _spriteRenderer.size = tiledSize;
    }

    private void UpdatePosition()
    {
        Vector3 originPosition = transform.parent.position;
        Vector3 absolutePosition = new Vector3(originPosition.x * _scrollSpeed.x, originPosition.y * _scrollSpeed.y);
        Vector3 compensatedPosition = absolutePosition + _compensationOffset;
        Vector3 delta = transform.parent.position - compensatedPosition;

        UpdateHorizontalOffset(delta.x);
        UpdateVerticalOffset(delta.y);
        transform.position = compensatedPosition;
    }

    private void UpdateHorizontalOffset(float delta)
    {
        if(delta == 0f)
            return;

        if (delta > _width)
        {
            _compensationOffset += Vector3.right * _width;
        }
        else if (delta < -_width)
        {
            _compensationOffset += Vector3.left * _width;
        }
    }

    private void UpdateVerticalOffset(float delta)
    {
        if (delta == 0f)
            return;

        if (delta > _height)
        {
            _compensationOffset += Vector3.up * _height;
        }
        else if (delta < -_height)
        {
            _compensationOffset += Vector3.down * _height;
        }
    }
}
