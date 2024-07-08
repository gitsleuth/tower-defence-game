using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementSystem : MonoBehaviour
{
    [SerializeField] PlayerCharacterController playerCharacterController;

    public GameObject fighterPlacementMarker;

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
}
