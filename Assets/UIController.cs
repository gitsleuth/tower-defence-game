using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] PlacementSystem placementSystem;

    public GameObject placeBasicFighterButtonGameObject;
    public TMPro.TextMeshProUGUI textObject;

    private UnityEngine.UI.Button placeBasicFighterButton;

    // Start is called before the first frame update
    void Start()
    {
        placeBasicFighterButton = placeBasicFighterButtonGameObject.GetComponent<UnityEngine.UI.Button>();
        placeBasicFighterButton.onClick.AddListener(() => {
            if (!placementSystem.placingFighter)
            {
                placementSystem.StartPlacingFighter();
            } else
            {
                placementSystem.StopPlacingFighter();
            }
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
