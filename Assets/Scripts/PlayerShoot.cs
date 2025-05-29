using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject bulletGO;
    Transform bulletSpawnPos;

    private void Start()
    {
        bulletSpawnPos = bulletGO.transform;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Instantiate(bulletPrefab, bulletSpawnPos.position, bulletSpawnPos.rotation);
        }
    }
}
