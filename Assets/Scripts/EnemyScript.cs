using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    System.Random rand = new System.Random();
    [SerializeField] private float _enemySpeed = 3.0f;


    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3((rand.Next(-9, 9)), 9, 0);

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _enemySpeed * Time.deltaTime);

        if (transform.position.y <= -6.68f)
        {
            Start();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Laser")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
        else if (other.tag == "Player")
        {
            Destroy(this.gameObject);
            other.transform.GetComponent<FirstScript>().Damage();
        }
    }
}
