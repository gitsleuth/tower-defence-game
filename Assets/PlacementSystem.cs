using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementSystem : MonoBehaviour
{
    public GameObject fighterPlacementMarker;
    public GameObject fighterToBeBuilt;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved) {
                if (touch.phase == TouchPhase.Began)
                {
                    fighterPlacementMarker.GetComponent<SpriteRenderer>().enabled = true;
                    fighterPlacementMarker.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
                }

                Vector3 touchedPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));
                fighterPlacementMarker.transform.position = touchedPos;
            } else if (touch.phase == TouchPhase.Ended)
            {
                Instantiate(fighterToBeBuilt, fighterPlacementMarker.transform.position, fighterPlacementMarker.transform.rotation);
                fighterPlacementMarker.GetComponent<SpriteRenderer>().enabled = false;
                fighterPlacementMarker.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
            }
        }
    }
}
