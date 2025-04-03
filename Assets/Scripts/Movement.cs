using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public static Movement Instance;
    private float speed =100f;
    private Rigidbody2D rb;

    public Transform dropper;
    public Sprite[] fruitImg;
    public GameObject[] Fruits;

    private GameObject prefab;
    private SpriteRenderer ren;
    private Sprite _randomFruit;
    private bool alreadyDropped;
    private float moveInput;

    private void Awake()
    {
        Instance = this;
    }
    public void nextFruity()
    {
        var randomFruit = fruitImg[Random.Range(0, fruitImg.Length)];
        _randomFruit = randomFruit;
    }
    public void spawnFruit()
    {   
        if(alreadyDropped == false)
        {
            nextFruity();
            ren.sprite = _randomFruit;
        }  
    }

    public void dropFruit()
    {
        if(_randomFruit == fruitImg[0])
        {
           
             prefab = Fruits[0];
            Instantiate(prefab,dropper.position, Quaternion.identity);
            
        }
        else if(_randomFruit == fruitImg[1])
        {
           
            prefab = Fruits[1];
            Instantiate(prefab, dropper.position, Quaternion.identity);
         
        }
    
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ren = GetComponentInChildren<SpriteRenderer>();

        alreadyDropped = false;
        spawnFruit();
    }

    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            dropFruit();
            alreadyDropped = true;
        }

        if (alreadyDropped == true) 
        {
            alreadyDropped = false;
            spawnFruit();
            
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput * speed * Time.deltaTime, rb.velocity.y);
    }

}
