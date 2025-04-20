using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCat : MonoBehaviour
{
    public int maxHealth = 100;       // 보스의 최대 체력
    private int CatHealth;        // 현재 체력

    public float attackBanana = 3.5f; 
    public GameObject throwBanana; 
    public Transform throwBananaPos;                      // 발사 위치

    private Animator animator;
    private void Start()
    {
        CatHealth = maxHealth;     
        animator = GetComponent<Animator>();
        InvokeRepeating("Attack", 2f, attackBanana); 
    }

    public void TakeDamage(int amount)
    {
        CatHealth -= amount;     
        Debug.Log("보스 체력: " + CatHealth);

        if (CatHealth <= 0)
        {
            Die();
        }
    }

    void Attack()
    {
        // 발사체 생성
        animator.SetTrigger("attack");
        Instantiate(throwBanana, throwBananaPos.position, throwBananaPos.rotation);
        Debug.Log("바나나 날리기");
    }

    void Die()
    {
        CancelInvoke("Attack");  
        Destroy(gameObject); 
    }
}