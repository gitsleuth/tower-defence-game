using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualJoystickController : MonoBehaviour
{
    [SerializeField] PlayerCharacterController playerCharacterController;

    public Transform VirtualJoystickTrans;
    public Transform VirtualJoystickHolderTrans;
    public bool beganOnJoystick = false;

    private float radius;

    // Start is called before the first frame update
    private void Start()
    {
        radius = VirtualJoystickHolderTrans.localScale.x / 2;
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    public bool CheckIfTouchIsOnJoystick(Vector3 touchPos)
    {
        return (touchPos - VirtualJoystickHolderTrans.position).magnitude <= radius;
    }

    public void SetPostionOfJoystick(Vector3 touchPos, float dt)
    {
        Vector3 direction = touchPos - VirtualJoystickHolderTrans.position;

        float speed = Mathf.Clamp(direction.magnitude / radius, 0, 1) * playerCharacterController.playerMaxSpeed;

        direction.Normalize();

        playerCharacterController.MovePlayer(direction, dt, speed);

        if (CheckIfTouchIsOnJoystick(touchPos))
        {
            VirtualJoystickTrans.position = touchPos;
        } else
        {
            VirtualJoystickTrans.position = VirtualJoystickHolderTrans.position + direction * radius;
        }
    }

    public void ResetJoystick()
    {
        VirtualJoystickTrans.position = VirtualJoystickHolderTrans.position;
    }
}
