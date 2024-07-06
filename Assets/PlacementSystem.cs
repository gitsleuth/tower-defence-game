using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementSystem : MonoBehaviour
{
    public GameObject fighterPlacementMarker;
    public GameObject fighterToBeBuilt;

    private List<GameObject> fighters = new List<GameObject>();

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
                fighters.Add(Instantiate(fighterToBeBuilt, fighterPlacementMarker.transform.position, fighterPlacementMarker.transform.rotation));
                fighterPlacementMarker.GetComponent<SpriteRenderer>().enabled = false;
                fighterPlacementMarker.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
            }
        }
    }

    public void DestroyAllFighters()
    {
        for (int i = fighters.Count - 1; i >= 0; i--)
        {
            GameObject fighter = fighters[i];

            Destroy(fighter);
            fighters.RemoveAt(i);
        }
    }
}
