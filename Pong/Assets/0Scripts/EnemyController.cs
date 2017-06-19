using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    public float speed = 3.5F;
    public float upLimit = 2.75F;
    public float vertical;
    public GameObject ball;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //hacemos como con el player, lo que tenemos en cuenta aqui, a 
        //diferencia de con el player, es la posicion de la pelota, entonces
        //lo que hacemoms es segun donde se encuentre esta, le damos velocidad
        // + o - y aplicamos el movimiento.
        Vector3 pos = transform.position;
        if (transform.position.y > ball.transform.position.y)
        {
            vertical = - speed * Time.deltaTime;

        }else if(transform.position.y < ball.transform.position.y)
        {
            vertical = + speed * Time.deltaTime;
        }
        pos.y = Mathf.Clamp(pos.y+vertical, -upLimit, upLimit);
        transform.position = pos;
    }
}
