using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementSystem : MonoBehaviour
{
    public GameObject fighterPlacementMarker;
    public GameObject fighterToBeBuilt;
    public List<GameObject> fighters = new List<GameObject>();
    public bool movingFighterPlacementMarker = true;
    public bool canMove = true;

    // Start is called before the first frame update
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {

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

    public void ResetFighterPlacementMarker()
    {
        fighterPlacementMarker.GetComponent<SpriteRenderer>().enabled = false;
        fighterPlacementMarker.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;

        movingFighterPlacementMarker = false;
    }

    public void MakeFighterPlacementMarkerVisible()
    {
        fighterPlacementMarker.GetComponent<SpriteRenderer>().enabled = true;
        fighterPlacementMarker.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
    }

    public void ChangeFighterPlacementMarkerPosition(Vector3 position)
    {
        fighterPlacementMarker.transform.position = position;
    }

    public void PlaceFighter()
    {
        fighters.Add(Instantiate(fighterToBeBuilt, fighterPlacementMarker.transform.position, fighterPlacementMarker.transform.rotation));

        fighterPlacementMarker.GetComponent<SpriteRenderer>().enabled = false;
        fighterPlacementMarker.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
    }

    public void SetMovingFighterPlacementMarkerToTrue()
    {
        movingFighterPlacementMarker = true;
    }

    public void SetCanMoveToTrue()
    {
        canMove = true;
    }
}
