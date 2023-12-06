using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBrain : MonoBehaviour
{
    [SerializeField] private Entity entity;

    private void Update()
    {
        entity.Move();
    }

    public void MoveInput(InputAction.CallbackContext context)
    {
        if(!context.performed && !context.canceled) return;

        Debug.DrawRay(transform.position, context.ReadValue<Vector2>() * 2, Color.green, Time.deltaTime);
        entity.SetDirection(context.ReadValue<Vector2>());
    }
}
