using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterController : MonoBehaviour
{
    public Transform playerCharacterTrans;
    public float playerMaxSpeed = 2;

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        float characterLeft = (playerCharacterTrans.position + Vector3.left * playerCharacterTrans.localScale.x / 2).x;
        float screenLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 10)).x;

        float characterRight = (playerCharacterTrans.position + Vector3.right * playerCharacterTrans.localScale.x / 2).x;
        float screenRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 10)).x;

        float characterTop = (playerCharacterTrans.position + Vector3.up * playerCharacterTrans.localScale.y / 2).y;
        float screenTop = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 10)).y;

        float characterBottom = (playerCharacterTrans.position + Vector3.down * playerCharacterTrans.localScale.x / 2).y;
        float screenBottom = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 10)).y;

        if (characterLeft <= screenLeft)
        {
            playerCharacterTrans.position += Vector3.right * Mathf.Abs(characterLeft - screenLeft);
        } else if (characterRight >= screenRight)
        {
            playerCharacterTrans.position += Vector3.left * Mathf.Abs(characterRight - screenRight);
        }

        if (characterTop >= screenTop)
        {
            playerCharacterTrans.position += Vector3.down * Mathf.Abs(characterTop - screenTop);
        } else if (characterBottom <= screenBottom)
        {
            playerCharacterTrans.position += Vector3.up * Mathf.Abs(characterBottom - screenBottom);
        }
    }

    public void MovePlayer(Vector3 direction, float dt, float speed)
    {
        playerCharacterTrans.position += direction * dt * speed;
    }

    public Vector3 GetPlayerPosition()
    {
        return playerCharacterTrans.position;
    }

    public Vector3 GetPlayerDirection()
    {
        return Vector3.up;
    }
}
