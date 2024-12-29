using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour

    /**
     * 控制角色移动
     */
{
    public float speed = 5f;
    private int maxHealth = 5;
    private int currentHealth;
    Rigidbody2D rigidbody2D;
    public GameObject bulletObject;//子弹

    //玩家朝向
    private Vector2 lookingDir = new Vector2 (1, 0);
    Animator anim;

    Boolean isClick = false;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = 5;
        rigidbody2D = GetComponent<Rigidbody2D>();
        currentHealth = 5;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(transform.right * speed * Time.deltaTime);
        float moveX = Input.GetAxisRaw("Horizontal");//水平
        float moveY = Input.GetAxisRaw("Vertical");

        Vector2 moveVector = new Vector2(moveX, moveY);
        if (moveVector.x != 0 || moveVector.y != 0) {
            lookingDir = moveVector;
        }
        anim.SetFloat("Look X", lookingDir.x);
        anim.SetFloat("Look Y", lookingDir.y);
        anim.SetFloat("Speed", moveVector.magnitude);//根据是否移动来看移动速度
        //anim.SetTrigger();

        Vector2 position = rigidbody2D.position;
        position.x += moveX*speed*Time.fixedDeltaTime;
        position.y += moveY*speed*Time.fixedDeltaTime;
        rigidbody2D.MovePosition(position);

        //子弹：
        if (Input.GetMouseButtonDown(0)) {
            anim.SetTrigger("Launch");
            GameObject bullet = Instantiate(bulletObject, rigidbody2D.position, Quaternion.identity);
            //Quarternion.identity:默认方向
            BulletController bc = bullet.GetComponent<BulletController>();
            if (bc != null)
            {
                bc.Move(lookingDir, 300);
            }
        }

        if (Input.GetKeyDown(KeyCode.E)) {
            //Debug.Log("?");
            RaycastHit2D hit = Physics2D.Raycast(rigidbody2D.position, lookingDir, 2f, LayerMask.GetMask("NPC"));
            if (hit.collider != null) {
                Debug.Log("NPC!");
                NPCController npc = hit.collider.GetComponent<NPCController>();
                if (npc != null)
                {
                    npc.ShowDialog();
                }
            }
            //发射射线
        }
    }
    /*
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isClick = true;
        }
        else {
            isClick = false;
        }
    }
    */
    public void setHealth(int newHealth) {
        currentHealth = newHealth > 5 ? 5 : newHealth;
    }
    public void addHealth(int additionalHealth) { 
        currentHealth += additionalHealth;
        currentHealth = currentHealth >= 5 ? 5 : currentHealth;
        UIManager.instance.UpdateHealthBar(currentHealth, maxHealth);
        if (additionalHealth < 0) {
            anim.SetTrigger("Hit");
        }
    }
    public int getHealth()
    {
        return currentHealth;
    }
    public int getMaxHealth()
    {
        return maxHealth;
    }
}
