using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;

    private Animator animator;

    public bool canRun = true;
    [SerializeField]
    float moveSpeed;

    [SerializeField]
    float maxPos;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();

        Invoke("MoveSpeedUp", 15f);
        Invoke("MoveSpeedUp", 15f);
    }

    // Update is called once per frame
    void Update()
    {
        if (canRun)
        {
            Move();
        }

        else
        {
            animator.SetBool("IsMoving", false);
        }
    }

    private void Move()
    {

        float inputX = Input.GetAxis("Horizontal");

        transform.position += Vector3.right * inputX * moveSpeed * Time.deltaTime;

        float xPos = Mathf.Clamp(transform.position.x, -maxPos, maxPos);

        transform.position = new Vector3(xPos, transform.position.y, transform.position.z);

        if (Input.GetButton("Horizontal"))
        {
            animator.SetBool("IsMoving", true);
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }

    }

    void MoveSpeedUp()
    {
        moveSpeed++;
    }
}
