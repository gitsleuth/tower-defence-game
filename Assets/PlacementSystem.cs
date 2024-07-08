using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementSystem : MonoBehaviour
{
    [SerializeField] PlayerCharacterController playerCharacterController;
    [SerializeField] FighterObjectController fighterObjectController;

    public GameObject fighterPlacementMarker;
    public GameObject fighter;

    private Transform fighterPlacementMarkerTrans;

    public bool placingFighter = false;

    // Start is called before the first frame update
    private void Start()
    {
        fighterPlacementMarkerTrans = fighterPlacementMarker.transform;
    }

    // Update is called once per frame
    private void Update()
    {
        if (placingFighter)
        {
            fighterPlacementMarkerTrans.position = playerCharacterController.GetPlayerPosition() + playerCharacterController.GetPlayerDirection() * 1;
        }
    }

    public void StartPlacingFighter()
    {
        fighterPlacementMarker.GetComponent<SpriteRenderer>().enabled = true;
        fighterPlacementMarkerTrans.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
        placingFighter = true;
    }

    public void PlaceFighter()
    {
        placingFighter = false;
        GameObject newFighter = Instantiate(fighter, fighterPlacementMarkerTrans.position, fighterPlacementMarkerTrans.rotation);
        newFighter.GetComponent<SpriteRenderer>().enabled = true;
        fighterObjectController.RegisterFighterObject(newFighter);

        fighterPlacementMarker.GetComponent<SpriteRenderer>().enabled = false;
        fighterPlacementMarkerTrans.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
    }
}
