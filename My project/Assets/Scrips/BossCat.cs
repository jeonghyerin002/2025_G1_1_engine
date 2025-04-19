using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCat : MonoBehaviour
{
    public int maxHealth = 100;       // ������ �ִ� ü��
    private int CatHealth;        // ���� ü��

    public float attackBanana = 3.5f; // ���� ����
    public GameObject throwBanana; // �߻�ü ������
    public Transform throwBananaPos;         // �߻� ��ġ

    private Animator animator;
    private void Start()
    {
        CatHealth = maxHealth;     // ���� �� ü�� �ʱ�ȭ
        animator = GetComponent<Animator>();
        InvokeRepeating("Attack", 2f, attackBanana); // �ֱ������� ����
    }

    public void TakeDamage(int amount)
    {
        CatHealth -= amount;       // ü�� ����
        Debug.Log("���� ü��: " + CatHealth);

        if (CatHealth <= 0)
        {
            Die();
        }
    }

    void Attack()
    {
        // �߻�ü ����
        animator.SetTrigger("attack");
        Instantiate(throwBanana, throwBananaPos.position, throwBananaPos.rotation);
        Debug.Log("�ٳ��� ������");
    }

    void Die()
    {
        CancelInvoke("Attack");  // ���� ���߱�
        Destroy(gameObject); // ���� ����
    }
}