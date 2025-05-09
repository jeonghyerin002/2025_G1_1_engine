using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public Animator myAnimator;
    public float speed = 4.5f;
    public float jumpForce = 4.25f;

    public AudioClip jumpSound;

    public bool isNeverDie;
    public bool isplusSpeed;
    public bool isplusJump;

    private Rigidbody2D rb;
    private bool isGrounded;
    private AudioSource audioSource;

    float score;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        myAnimator.SetBool("move", false);

        audioSource = GetComponent<AudioSource>();

        score = 1000f;
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

            audioSource.PlayOneShot(jumpSound);
        }

        transform.Translate(Vector3.right * direction * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
            rb.AddForce(Vector2.up * 100);

        score -= Time.deltaTime;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
        Debug.Log("顶");
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
        Debug.Log("痢橇");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
            if (collision.CompareTag("Respawn") && !isNeverDie && !isplusSpeed)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            if (collision.CompareTag("Finish"))
            {
            HighScore.TrySet(SceneManager.GetActiveScene().buildIndex, (int)score);
                collision.GetComponent<LevelObject>().MoveToNextLevel();
            }

            if (collision.CompareTag("NeverDie"))
            {
                Invoke("MustEat", 5.0f);
                isNeverDie = true;
                Destroy(collision.gameObject);

            }

            if (collision.CompareTag("plusSpeed"))
            {
                Invoke("ShouldEat", 4.0f);
                speed += 5;
                Destroy(collision.gameObject);
            }

             if (collision.CompareTag("plusJump"))
            {
                Invoke("HaveToEat", 4.0f);
                jumpForce += 5;
                Destroy(collision.gameObject);

            Debug.Log("啊涵款 个");
            }
               


        

    }
    void MustEat()
    {
        isNeverDie = false;

        Debug.Log("公利秒家");
    }

    void ShouldEat()
    {
        speed -= 4;
        Debug.Log("捞加秒家");
    }

    void HaveToEat()
    {
        jumpForce -= 5;
        Debug.Log("公芭款 个");
    }


}
