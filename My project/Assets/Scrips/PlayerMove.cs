using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public Animator myAnimator;
    public float speed = 4.5f;
    public float jumpForce = 4.25f;
    private Rigidbody2D rb;
    private bool isGrounded;
    public bool isNeverDie;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        myAnimator.SetBool("move", false);
    }


    void Update()
    {
        float direction = Input.GetAxis("Horizontal");

        if (direction > 0)
        {
            transform.localScale = new Vector3(5, 5, 1);
            myAnimator.SetBool("move", true);

        }
        else if (direction < 0)
        {
            transform.localScale = new Vector3(-5, 5, 1);
            myAnimator.SetBool("move", true);
        }
        else
        {
            myAnimator.SetBool("move", false);
        }

        
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        transform.Translate(Vector3.right * direction *speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
            rb.AddForce(Vector2.up * 100);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
        Debug.Log("¶¥");
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
        Debug.Log("Á¡ÇÁ");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Respawn") && !isNeverDie)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (collision.CompareTag("Finish"))
        {
            collision.GetComponent<LevelObject>().MoveToNextLevel();
        }

        if (collision.CompareTag("NeverDie"))
        {
            Invoke("MustEat", 5.0f);
            isNeverDie = true;
            Destroy(collision.gameObject);
        }
    }

    void MustEat()
    {
        isNeverDie = false;
    }

}
