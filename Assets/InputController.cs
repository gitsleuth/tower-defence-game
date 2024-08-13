using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] FighterObjectController fighterObjectController;
    [SerializeField] VirtualJoystickController virtualJoystickController;
    [SerializeField] PlacementSystem placementSystem;
    [SerializeField] UIController uIController;

    public GameObject fireRadius;
    public UnityEngine.EventSystems.EventSystem eventSystem;

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            float dt = Time.deltaTime;

            if (touch.phase == TouchPhase.Began)
            {
                Vector3 touchPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));

                if (virtualJoystickController.CheckIfTouchIsOnJoystickHolder(touchPos))
                {
                    virtualJoystickController.beganOnJoystick = true;

                    virtualJoystickController.SetPostionOfJoystick(touchPos, dt);
                } else if (placementSystem.placingFighter)
                {
                    placementSystem.PlaceFighter();
                }
            } else if (touch.phase == TouchPhase.Moved)
            {
                if (virtualJoystickController.beganOnJoystick)
                {
                    Vector3 touchPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));

                    virtualJoystickController.SetPostionOfJoystick(touchPos, dt);
                }
            } else if (touch.phase == TouchPhase.Stationary)
            {
                if (virtualJoystickController.beganOnJoystick)
                {
                    Vector3 touchPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));

                    virtualJoystickController.SetPostionOfJoystick(touchPos, dt);
                }
            } else if (touch.phase == TouchPhase.Ended)
            {
                virtualJoystickController.beganOnJoystick = false;

                virtualJoystickController.ResetJoystick();
            }
        }
    }
}
