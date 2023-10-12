using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class enemyGunController : MonoBehaviour
{
    public GameObject enemyBulletPrefab;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("FireEnemyBullet",2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FireEnemyBullet()
    {
        
        GameObject playerShip = GameObject.Find("PlayerShip");

        if (playerShip!=null)
        {
            GameObject bullet = (GameObject) Instantiate(enemyBulletPrefab);
            bullet.transform.position = transform.position;
            Vector2 direction = playerShip.transform.position - transform.position;
            bullet.GetComponent<enemyBulletController>().SetDirection(direction);
        }
    }
}
