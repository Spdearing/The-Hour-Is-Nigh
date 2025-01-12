using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Enemy blob = new Enemy("Blob", 25, 25, 2);
        gameObject.name = blob.EnemyName;
        gameObject.tag = "Enemy";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
