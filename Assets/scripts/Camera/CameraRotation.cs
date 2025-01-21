using UnityEngine;
using Zenject;

public class CameraRotation : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 2.0f;
    [SerializeField] private Transform cameraTransform;

    [SerializeField] private float minVerticalAngle = -30f;
    [SerializeField] private float maxVerticalAngle = 60f;
    private Vector2 _lastTouchPosition;
    private bool _isRotating;
    private float _verticalRotation = 0f;
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.position.x > Screen.width / 2)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    _isRotating = true;
                    _lastTouchPosition = touch.position;
                }
                else if (touch.phase == TouchPhase.Moved && _isRotating)
                {
                    Vector2 delta = touch.position - _lastTouchPosition;

                    transform.Rotate(Vector3.up, delta.x * rotationSpeed * Time.deltaTime);

                    _verticalRotation -= delta.y * rotationSpeed * Time.deltaTime;
                    _verticalRotation = Mathf.Clamp(_verticalRotation, minVerticalAngle, maxVerticalAngle);
                    cameraTransform.localRotation = Quaternion.Euler(_verticalRotation, 0, 0);

                    _lastTouchPosition = touch.position;
                }
                else if (touch.phase == TouchPhase.Ended)
                {
                    _isRotating = false;
                }
            }
        }
    }
}
