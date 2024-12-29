using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Collectables : MonoBehaviour
    /**
     * 草莓被通过时
     */
{
    public ParticleSystem collectableEffect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController pc = other.GetComponent<PlayerController>();
        if (pc != null)
        {
            Debug.Log("玩家碰到草莓 " + pc.getHealth());
            if (pc.getHealth() < 5) { 
                pc.addHealth(1);
                Instantiate(collectableEffect, transform.position, Quaternion.identity);//生成特效
                Destroy(this.gameObject);
              
            }
            Debug.Log("玩家碰到草莓后 " + pc.getHealth());

        }
    }
}
