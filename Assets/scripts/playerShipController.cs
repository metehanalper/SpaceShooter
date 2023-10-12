using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class playerShipController : MonoBehaviour
{
    public float speed;

    public GameObject playerBulletPrefab;

    public GameObject leftGun;

    public GameObject rightGun;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            GetComponent<AudioSource>().Play();
            GameObject bullet1 = (GameObject) Instantiate(playerBulletPrefab);
            bullet1.transform.position = leftGun.transform.position;
            
            GameObject bullet2 = (GameObject) Instantiate(playerBulletPrefab);
            bullet2.transform.position = rightGun.transform.position;
        }
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector2 direction = new Vector2(x, y).normalized;
        Move(direction);
    }

    void Move(Vector2 dir)
    {
        Vector2 pos = transform.position;
        pos += dir * speed * Time.deltaTime;
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        max.x = max.x - 0.225f;
        min.x = min.x + 0.225f;

        max.y = max.y - 0.285f;
        min.y = min.y + 0.285f;
        
        
        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);
        
        
        transform.position = pos;
    }
}
