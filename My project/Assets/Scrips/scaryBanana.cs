using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scaryBanana : MonoBehaviour
{
    public float speed = 5f; // �߻�ü�� �����̴� �ӵ�

    void Update()
    {
        // �� �����Ӹ��� ���������� �̵�
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // �ٸ� ���𰡿� ������ �ڱ� �ڽ��� �ı�
        Destroy(gameObject);
    }
}
