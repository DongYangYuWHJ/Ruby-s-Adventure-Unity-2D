using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Collectables : MonoBehaviour
    /**
     * ��ݮ��ͨ��ʱ
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
            Debug.Log("���������ݮ " + pc.getHealth());
            if (pc.getHealth() < 5) { 
                pc.addHealth(1);
                Instantiate(collectableEffect, transform.position, Quaternion.identity);//������Ч
                Destroy(this.gameObject);
              
            }
            Debug.Log("���������ݮ�� " + pc.getHealth());

        }
    }
}
