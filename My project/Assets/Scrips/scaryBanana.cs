using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scaryBanana : MonoBehaviour
{
    public float speed = 5f; // 발사체가 움직이는 속도

    void Update()
    {
        // 매 프레임마다 오른쪽으로 이동
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // 다른 무언가에 닿으면 자기 자신을 파괴
        Destroy(gameObject);
    }
}
