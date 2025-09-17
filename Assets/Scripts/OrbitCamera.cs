using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class OrbitCamera : MonoBehaviour
{
    public float rotationSpeed = 90f;
    public float distance = 5f;
    private Vector2 orbitAngles = new Vector2(45f, 0f);
    private Vector2 input;

    public InputAction jetPackAction;
    
    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void OnDisable()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void OnLook(InputValue value)
    {
        input.x = -value.Get<Vector2>().y;
        input.y = value.Get<Vector2>().x;
    }
}
