using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] PlacementSystem placementSystem;

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

            if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
            {
                Vector3 touchedPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));

                if (touch.phase == TouchPhase.Began) {
                    bool toggledFireRadius = false;

                    foreach (GameObject fighter in placementSystem.fighters)
                    {
                        Transform fighterTransform = fighter.transform;
                        Vector3 fighterPosition = fighterTransform.position;
                        float fighterPositionX = fighterPosition.x;
                        float fighterPositionY = fighterPosition.y;
                        Vector3 fighterLocalScale = fighterTransform.localScale;
                        float fighterLocalScaleXHalf = fighterLocalScale.x / 2;
                        float fighterLocalScaleYHalf = fighterLocalScale.y / 2;

                        if (touchedPos.x >= fighterPositionX - fighterLocalScaleXHalf && touchedPos.x <= fighterPositionX + fighterLocalScaleXHalf
                            && touchedPos.y >= fighterPositionY - fighterLocalScaleYHalf && touchedPos.y <= fighterPositionY + fighterLocalScaleYHalf)
                        {
                            fireRadius.GetComponent<SpriteRenderer>().enabled = true;
                            fireRadius.transform.position = fighterPosition;

                            toggledFireRadius = true;
                        }
                    }

                    if (toggledFireRadius)
                    {
                        placementSystem.movingFighterPlacementMarker = false;
                        return;
                    }

                    if (placementSystem.canMove)
                    {
                        placementSystem.MakeFighterPlacementMarkerVisible();

                        placementSystem.SetCanMoveToTrue();
                    }

                    return;
                }

                if (placementSystem.canMove)
                {
                    placementSystem.ChangeFighterPlacementMarkerPosition(touchedPos);
                }
            } else if (touch.phase == TouchPhase.Ended)
            {
                if (placementSystem.canMove && placementSystem.movingFighterPlacementMarker)
                {
                    placementSystem.PlaceFighter();
                }
                else
                {
                    placementSystem.SetMovingFighterPlacementMarkerToTrue();
                }
            }
        }
    }
}
