using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] PlacementSystem placementSystem;
    [SerializeField] FighterObjectController fighterObjectController;
    [SerializeField] VirtualJoystickController virtualJoystickController;

    public GameObject fireRadius;

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

            //if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
            //{
            //    Vector3 touchedPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));

            //    if (touch.phase == TouchPhase.Began) {
            //        bool toggledFireRadius = false;

            //        foreach (GameObject fighter in fighterObjectController.fighters)
            //        {
            //            Transform fighterTransform = fighter.transform;
            //            Vector3 fighterPosition = fighterTransform.position;
            //            float fighterPositionX = fighterPosition.x;
            //            float fighterPositionY = fighterPosition.y;
            //            Vector3 fighterLocalScale = fighterTransform.localScale;
            //            float fighterLocalScaleXHalf = fighterLocalScale.x / 2;
            //            float fighterLocalScaleYHalf = fighterLocalScale.y / 2;

            //            if (touchedPos.x >= fighterPositionX - fighterLocalScaleXHalf && touchedPos.x <= fighterPositionX + fighterLocalScaleXHalf
            //                && touchedPos.y >= fighterPositionY - fighterLocalScaleYHalf && touchedPos.y <= fighterPositionY + fighterLocalScaleYHalf)
            //            {
            //                if (!fighterObjectController.fighterObjectTouchedBefore || fighterObjectController.fighterObjectTouchedBefore != fighter)
            //                {
            //                    fighterObjectController.fighterObjectTouchedBefore = fighter;
            //                    fireRadius.transform.position = fighter.transform.position;
            //                    fireRadius.GetComponent<SpriteRenderer>().enabled = true;
            //                } else if (fighterObjectController.fighterObjectTouchedBefore == fighter)
            //                {
            //                    fighterObjectController.fighterObjectTouchedBefore = null;
            //                    fireRadius.transform.position = fighter.transform.position;
            //                    fireRadius.GetComponent<SpriteRenderer>().enabled = false;
            //                }

            //                toggledFireRadius = true;
            //            }
            //        }

            //        if (toggledFireRadius)
            //        {
            //            placementSystem.movingFighterPlacementMarker = false;
            //            return;
            //        }

            //        if (placementSystem.canMove)
            //        {
            //            placementSystem.MakeFighterPlacementMarkerVisible();

            //            placementSystem.SetCanMoveToTrue();
            //        }

            //        return;
            //    }

            //    if (placementSystem.canMove)
            //    {
            //        placementSystem.ChangeFighterPlacementMarkerPosition(touchedPos);
            //    }
            //} else if (touch.phase == TouchPhase.Ended)
            //{
            //    print("Ended");

            //    if (placementSystem.canMove && placementSystem.movingFighterPlacementMarker)
            //    {
            //        placementSystem.PlaceFighter();
            //    }
            //    else
            //    {
            //        placementSystem.SetMovingFighterPlacementMarkerToTrue();
            //    }
            //}
        }
    }

    private void TouchBegan(Touch touch, float dt)
    {
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
        }
    }
}
