using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody2D rBody;
    public bool isVertical; //水平/垂直移动
    private Vector2 moveDir;
    public const float changeDirTime = 2f;//改变方向时间
    private float changeDirTimer;
    Animator animator;
    private Boolean isFixed;
    public ParticleSystem brokenEffect;


    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        moveDir = isVertical ? Vector2.up : Vector2.right;
        changeDirTimer = changeDirTime;
        animator = GetComponent<Animator>();
        //brokenEffect = GetComponent<ParticleSystem>();
        isFixed = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isFixed) {
            return;
        }
        changeDirTimer -= Time.deltaTime;
        if (changeDirTimer < 0) {
            moveDir *= -1;
            changeDirTimer = changeDirTime;
        }

        Vector2 position = rBody.position;
        position.x += moveDir.x * speed * Time.deltaTime;
        position.y += moveDir.y * speed * Time.deltaTime;
        rBody.MovePosition(position);

       
            animator.SetFloat("moveX", moveDir.x);
            animator.SetFloat("moveY", moveDir.y);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        PlayerController pc = other.gameObject.GetComponent<PlayerController>();
        if (pc != null) {
            pc.addHealth(-1);
        }
    }

    public void Fixed() {
        rBody.simulated = false;//禁用物理
        animator.SetTrigger("fix");
        isFixed = true;
        if (brokenEffect.isPlaying == true) { 
            brokenEffect.Stop();
        }
    }
}
