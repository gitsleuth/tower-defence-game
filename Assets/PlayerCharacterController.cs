using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterController : MonoBehaviour
{
    public Transform playerCharacterTrans;
    public float playerMaxSpeed = 5;

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    public void MovePlayer(Vector3 direction, float dt)
    {
        playerCharacterTrans.position += direction * dt * playerMaxSpeed;
    }
}
