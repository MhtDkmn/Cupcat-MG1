using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    bool camCanMove = true;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (camCanMove)
        {
            CameraMove();
        }
    }

    public float camMoveSpeed;
    public float camMaxPos;

    void CameraMove()
    {
        float inputX = Input.GetAxis("Horizontal");
        transform.position += Vector3.right * inputX * camMoveSpeed * Time.deltaTime;
        float xPos = Mathf.Clamp(transform.position.x, -camMaxPos, camMaxPos);
        transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
    }
}




