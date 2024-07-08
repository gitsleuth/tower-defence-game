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

    private bool startedOverUI = false;

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            print(Input.touchCount);

            Touch touch = Input.GetTouch(0);

            float dt = Time.deltaTime;

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    TouchBegan(touch, dt);
                    break;

                case TouchPhase.Stationary:
                    TouchStationary(touch, dt);
                    break;

                case TouchPhase.Moved:
                    TouchMoved(touch, dt);
                    break;

                case TouchPhase.Ended:
                    TouchEnded(touch);
                    break;
            }
        }
    }

    private void TouchBegan(Touch touch, float dt)
    {
        startedOverUI = eventSystem.IsPointerOverGameObject(touch.fingerId);

        Vector3 touchPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));

        if (virtualJoystickController.CheckIfTouchIsOnJoystick(touchPos))
        {
            virtualJoystickController.beganOnJoystick = true;

            virtualJoystickController.SetPostionOfJoystick(touchPos, dt);
        } else
        {
            virtualJoystickController.beganOnJoystick = false;
        }
    }

    private void TouchStationary(Touch touch, float dt)
    {
        if (virtualJoystickController.beganOnJoystick)
        {
            virtualJoystickController.SetPostionOfJoystick(Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10)), dt);
        }
    }

    private void TouchMoved(Touch touch, float dt)
    {
        if (virtualJoystickController.beganOnJoystick)
        {
            virtualJoystickController.SetPostionOfJoystick(Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10)), dt);
        }
    }

    private void TouchEnded(Touch touch)
    {
        if (virtualJoystickController.beganOnJoystick)
        {
            virtualJoystickController.ResetJoystick();
        } else if (placementSystem.placingFighter && !startedOverUI)
        {
            placementSystem.PlaceFighter();
        }

        startedOverUI = false;
    }
}
