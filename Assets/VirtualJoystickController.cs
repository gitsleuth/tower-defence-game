using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualJoystickController : MonoBehaviour
{
    [SerializeField] PlayerCharacterController playerCharacterController;

    public Transform VirtualJoystickTrans;
    public Transform VirtualJoystickHolderTrans;
    public bool beganOnJoystick = false;

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    public bool CheckIfTouchIsOnJoystick(Vector3 touchPos)
    {
        return (touchPos - VirtualJoystickHolderTrans.position).magnitude <= VirtualJoystickHolderTrans.localScale.x / 2;
    }

    public void SetPostionOfJoystick(Vector3 touchPos, float dt)
    {
        if (CheckIfTouchIsOnJoystick(touchPos))
        {
            VirtualJoystickTrans.position = touchPos;

            Vector3 direction = touchPos - VirtualJoystickHolderTrans.position;
            direction.Normalize();

            playerCharacterController.MovePlayer(direction, dt);
        } else
        {
            Vector3 direction = touchPos - VirtualJoystickHolderTrans.position;
            direction.Normalize();
            VirtualJoystickTrans.position = VirtualJoystickHolderTrans.position + direction * direction.magnitude;

            playerCharacterController.MovePlayer(direction, dt);
        }
    }

    public void ResetJoystick()
    {
        VirtualJoystickTrans.position = VirtualJoystickHolderTrans.position;
    }
}
