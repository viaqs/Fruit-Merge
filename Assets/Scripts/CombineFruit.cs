using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CombineFruit : MonoBehaviour
{

    private bool isMerged = false;
    public int layer;
    private int point = 5;
    public GameObject pref;
    private void mergeFruit(CombineFruit fruit)
    {
        isMerged = true;
        fruit.isMerged = isMerged;

        Vector3 mPos = (transform.position + fruit.transform.position) / 2;
        Destroy(fruit.gameObject);
        Destroy(gameObject);


        if (pref != null)
        {
            Instantiate(pref,mPos, Quaternion.identity);
          
        }

        FindObjectOfType<Score>().trackScore(point);
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        CombineFruit fruit = collision.gameObject.GetComponent<CombineFruit>();
        if (fruit != null && fruit.layer == layer && !isMerged && !fruit.isMerged)
        {
            mergeFruit(fruit);
        }
    }
}
