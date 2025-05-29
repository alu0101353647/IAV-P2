using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 3;
    public float damage = 5;

    Vector3? spawnpoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (spawnpoint == null) { spawnpoint = transform.position; }
        if (Vector3.Distance(transform.position, (Vector3)spawnpoint) > 100)
        {
            Destroy(gameObject);
        }
    }
}
