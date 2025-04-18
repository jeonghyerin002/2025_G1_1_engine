using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 3.5f;

    private Rigidbody2D  rb;
    private bool isMovingRigjt = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isMovingRigjt)
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        else
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Boundary"))
        {
            isMovingRigjt = !isMovingRigjt;

            Vector3 localscale = transform.localScale;    //ĳ���͸� x������ �¿���� (1 * -1= -1 / -1 * -1= 1 �ݺ�)
            localscale.x *= -1;
            transform.localScale = localscale;
        }
    }
}
