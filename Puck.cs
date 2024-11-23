using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puck : MonoBehaviour
{
    public GameManager gameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -0.9f)
        {
            Destroy(gameObject);
        }

        if (transform.position.z > 0.138)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 0.16f);
        }

        if (transform.position.z < -0.138)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -0.16f);
        }

        if (transform.position.x < 0.43f && gameManager.GetComponent<GameManager>().isPlacingPuck)
        {
            transform.position = new Vector3(0.43f, transform.position.y, transform.position.z);
        }
    }
}
