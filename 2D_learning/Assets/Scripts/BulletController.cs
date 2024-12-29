using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{/**
  * 子弹的移动碰撞
  */
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(this.gameObject, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //移动
    public void Move(Vector2 moveDir, float moveForce) {
        rb.AddForce(moveDir*moveForce);
    }

    void OnCollisionEnter2D(Collision2D other) {
        EnemyController ec = other.gameObject.GetComponent<EnemyController>();
        if (ec != null)
        {
            Debug.Log("碰到敌人了");
            ec.Fixed();
        }

        Destroy(this.gameObject);
    }
}
