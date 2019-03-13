using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manreverse : MonoBehaviour

{
    public Vector2 spawnpoint;
    [SerializeField]

    public Vector2 endpoint;
    [SerializeField]


    // Start  is called before the first frame update
    private float a;
    private float b;
    [SerializeField]
    private int speed = 4;

   

    void Start()
    {
        // this.gameObject.transform.position = new Vector3(1.87f, 2.87f, 0);
        this.gameObject.transform.position = spawnpoint;

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate((speed) * new Vector2(1, 0) * Time.deltaTime);
        //  Instantiate(levelcom, transform.position, transform.rotation);

        if ((gameObject.transform.position.x) < endpoint.x)
        {
            respawn();

        }
       
    }
    void OnCollisionEnter2D(Collision2D collision)

    {
        if ((collision.gameObject.tag == "human"))//if its not baseblock
        {
            Debug.Log("collison");
            Destroy(this.gameObject);
        }
    }
    void respawn()
    {
        this.gameObject.transform.position = spawnpoint;

    }

}