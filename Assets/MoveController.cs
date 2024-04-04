using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera _camera;
    public CharacterController _characterController;
    public int _moveSpeed;

    private Vector2 _rotation;
    private float _velocity = 0f;
    public int _lookSpeedMouse;
    public float _gravity;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CameraController();
        Move();
    }
    private void CameraController()
    {
        float mouseX = Input.GetAxis("Mouse X") * _lookSpeedMouse * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * _lookSpeedMouse * Time.deltaTime;

        _rotation.y += mouseX;
        _rotation.x -= mouseY;

        _rotation.x = Mathf.Clamp(_rotation.x, -90, 90);

        _camera.transform.eulerAngles = new Vector3(_rotation.x, _rotation.y, 0);
    }
    private void Move()
    {
        float horizontal = Input.GetAxis("Horizontal") * _moveSpeed * Time.deltaTime;
        float vertical = Input.GetAxis("Vertical") * Time.deltaTime * _moveSpeed    ;

        _velocity += -_gravity * Time.deltaTime;

        _characterController.Move((_camera.transform.right * horizontal + _camera.transform.forward * vertical + new Vector3(0, _velocity, 0)) * Time.deltaTime);
    }
}
