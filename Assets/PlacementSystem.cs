using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementSystem : MonoBehaviour
{
    [SerializeField] FighterObjectController fighterObjectController;

    public GameObject fighterPlacementMarker;
    public GameObject fighterToBeBuilt;
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
        GameObject fighter = Instantiate(fighterToBeBuilt, fighterPlacementMarker.transform.position, fighterPlacementMarker.transform.rotation);

        fighterObjectController.RegisterFighterObject(fighter);

        fighterPlacementMarker.GetComponent<SpriteRenderer>().enabled = false;
        fighterPlacementMarker.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;

        fighterObjectController.RegisterFighterObject(fighter);
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
