using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    GameObject BG1, BG2;

    [HideInInspector]
    public Transform player;

    [HideInInspector]
    public Vector3 tempPos;

    public float minX, maxX;

    public float originalX, currentX;

    private float bgwidth = 153.5f;

    [SerializeField]
    Transform collectorLeft, collectorRight;
    // Start is called before the first frame update
    void Start()
    {
        originalX = tempPos.x;
        PlayerActive();
    }

    public void PlayerActive()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        collectorLeft.position =  new Vector3(tempPos.x - 80, tempPos.y, tempPos.z);
        collectorRight.position = new Vector3(tempPos.x + 80, tempPos.y, tempPos.z);
        SwitchBG();
    }

    void LateUpdate()
    {
        if (originalX != currentX)
            currentX = originalX;

        if (!player)
            return;

        tempPos = transform.position;
        tempPos.x = player.position.x;

        if (tempPos.x <= minX)
            minX -= bgwidth;

        if (tempPos.x >= maxX)
            maxX += bgwidth;

        transform.position = tempPos;
    }

    private void SwitchBG()
    {
        if (tempPos.x < BG1.transform.position.x && BG2.transform.position.x > BG1.transform.position.x)
        {
            BG2.transform.position = new Vector3(BG2.transform.position.x - bgwidth * 2, BG2.transform.position.y, BG2.transform.position.z);
        }

        else if (tempPos.x > BG1.transform.position.x && BG2.transform.position.x < BG1.transform.position.x)
        {
            BG2.transform.position = new Vector3(BG2.transform.position.x + bgwidth * 2, BG2.transform.position.y, BG2.transform.position.z);
        }

        if (tempPos.x < BG2.transform.position.x && BG2.transform.position.x < BG1.transform.position.x)
        {
            BG1.transform.position = new Vector3(BG1.transform.position.x - bgwidth * 2, BG1.transform.position.y, BG1.transform.position.z);
        }

        else if (tempPos.x > BG2.transform.position.x && BG2.transform.position.x > BG1.transform.position.x)
        {
            BG1.transform.position = new Vector3(BG1.transform.position.x + bgwidth * 2, BG1.transform.position.y, BG1.transform.position.z);
        }
    }
}