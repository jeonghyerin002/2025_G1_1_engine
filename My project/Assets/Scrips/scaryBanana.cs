using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scaryBanana : MonoBehaviour
{
    public float speed = 6f; // 바나나가 움직이는 속도

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
    }
}
