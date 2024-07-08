using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] PlacementSystem placementSystem;

    public UnityEngine.UI.Button placeBasicFighterButton;

    // Start is called before the first frame update
    void Start()
    {
        placeBasicFighterButton.onClick.AddListener(() => placementSystem.StartPlacingFighter());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
