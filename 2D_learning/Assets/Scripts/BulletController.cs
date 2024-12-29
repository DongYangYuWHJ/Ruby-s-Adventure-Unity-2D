using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{/**
  * �ӵ����ƶ���ײ
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

    //�ƶ�
    public void Move(Vector2 moveDir, float moveForce) {
        rb.AddForce(moveDir*moveForce);
    }

    void OnCollisionEnter2D(Collision2D other) {
        EnemyController ec = other.gameObject.GetComponent<EnemyController>();
        if (ec != null)
        {
            Debug.Log("����������");
            ec.Fixed();
        }

        Destroy(this.gameObject);
    }
}
