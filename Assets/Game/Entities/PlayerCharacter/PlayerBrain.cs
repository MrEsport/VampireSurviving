using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBrain : BrainEntityController
{
    private void Update()
    {
        entity.Move();
    }

    public void MoveInput(InputAction.CallbackContext context)
    {
        if(!context.performed && !context.canceled) return;

        entity.SetDirection(context.ReadValue<Vector2>());
    }
}
