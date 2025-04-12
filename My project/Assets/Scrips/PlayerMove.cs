using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Animator myAnimator;
    public float speed = 3.5f;
    // Start is called before the first frame update
    private void Start()
    {
        myAnimator.SetBool("move", false);
    }

    // Update is called once per frame
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
        

        transform.Translate(Vector3.right * direction *speed * Time.deltaTime);
    }
}
