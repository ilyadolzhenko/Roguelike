﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class EnemyBase : MonoBehaviour
{
    private SpriteRenderer sr;
    protected Animator anim;
    protected Transform target;
    [Header("Характеристики врага")]
    public float HP;
    public float speed;
    public float damage;
    public int maxDrop;
    public GameObject damageText;
    public GameObject explosion;
    public Slider sl;
    

    void Start()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();   
        sl.maxValue = HP;
        sl.value = HP;
    }

    protected abstract void Following();

    protected void FlipX(float other)
    {
        if (other < transform.position.x)
        {
            sr.flipX=true;
        } else {
            sr.flipX=false;
        }
    }

    protected abstract void Attack();

    public void TakeDamage(int damage)
    {
        HP -= damage;
        sl.value = HP;
    }

    public void ShowDamage(int damage)
    {
        damageText.GetComponent<TextMesh>().text = "-" + damage;
        Instantiate(damageText, transform.position, Quaternion.identity);
    }

    protected void CheckDeath()
    {
        if (HP<=0)
        {
            FindObjectOfType<AudioManager>().Play("EnemyDeath");
            Destroy(Instantiate(explosion, transform.position, Quaternion.identity), 0.45f);
            int numberDrop = Random.Range(0, maxDrop);
            GameObject drop = GameObject.Find("GOManager").GetComponent<GOManager>().drop[numberDrop];
            Instantiate(drop, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}