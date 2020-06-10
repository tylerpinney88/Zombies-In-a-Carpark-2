using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableWallController : MonoBehaviour
{
    public GameObject[] RemoveableObjects;
    bool breaking;
    public bool fixing;
    public float BarrierHealth;
    public int BarrierCount;
    bool canBreak;
    public bool canFix;
    // Start is called before the first frame update
    void Start()
    {
        RemoveableObjects = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            RemoveableObjects[i] = transform.GetChild(i).gameObject;
        }
        BarrierHealth = 10 * transform.childCount;
        BarrierCount = transform.childCount;
        canBreak = true;
        canFix = false;
    }

    // Update is called once per frame
    void Update()
    {
        BarrierCheck();
        BreakWall();
        FixWall();
        TestControls();
        if (BarrierHealth <= 0)
        {
            canBreak = false;
        }

        if (BarrierHealth >= 0)
        {
            canBreak = true;
        }


        if (BarrierHealth <= 10 * transform.childCount)
        {
            canFix = true;
        }

        if (BarrierHealth >= 10 * transform.childCount)
        {
            canFix = false;
            fixing = false;
        }
    }

    void BreakWall()
    {
        if (BarrierHealth <= 10 * (BarrierCount - 1))
        {
            RemoveableObjects[BarrierCount - 1].SetActive(false);
            BarrierCount -= 1; 
        }
    }

    void FixWall()
    {
        if (fixing == true)
        {
            if (BarrierHealth >= 10 * BarrierCount && BarrierHealth <= 10 * transform.childCount)
            {
                RemoveableObjects[BarrierCount].SetActive(true);
                BarrierCount += 1;
            }
        }
    }


    void BarrierCheck()
    {
        if (breaking == true)
        {
            BarrierHealth = BarrierHealth -= (Time.deltaTime * 2);       
        } 

        if (fixing == true && canFix == true)
        {
            BarrierHealth = BarrierHealth += (Time.deltaTime * 2);
        }
    }


    void OnTriggerEnter(Collider col)
    {
        if (canBreak == true)
        {
            if (col.gameObject.tag == "Enemy")
            {
                breaking = true;
            }
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            breaking = false;
        }
    }








    //Testing Controls


    void TestControls()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            breaking = !breaking;
        }

        if (Input.GetKey(KeyCode.E))
        {
            if (canFix == true)
            {
                fixing = !fixing;
            }
        }
    }
}
