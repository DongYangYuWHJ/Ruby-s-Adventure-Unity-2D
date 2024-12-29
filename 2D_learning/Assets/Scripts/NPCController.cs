using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCController : MonoBehaviour
{
    public GameObject dialogImage;
    public float showTime = 4;
    private float showTimer;
    // Start is called before the first frame update
    void Start()
    {
        //showTimer = showTime;
        (dialogImage).SetActive(false);
        showTimer = -1;
    }

    // Update is called once per frame
    void Update()
    {
        showTimer -= Time.deltaTime;
        if (showTimer < 0)
        {
            dialogImage.SetActive(false);
        }
        else {
            dialogImage.SetActive(true);
        }
    }

    public void ShowDialog() {
        showTimer = showTime;
    }
}
