using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float speed = 3.0F;
    public float upLimit = 2.75F;
    public float vertical;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       //capturamos el movimiento:
        vertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        //guardamos la posicion anterior del object
        Vector3 pos = transform.position;
        //y hacemos un clamp de la posicion que tenia mas donde deberia de estar con los 
        //limites establecidos
        pos.y = Mathf.Clamp(pos.y + vertical, -upLimit, upLimit);
        //y entonces le aplicamos la nueva posicion
        transform.position = pos;
        /*
         * podriamos hacerlo a mano, con ifs, pero unity tiene sus metodos para 
         * acotar los movimientos, como detallamos despues del codigo comentado 
        if (transform.position.y >= upLimit)
        {
            transform.Translate(0, upLimit, 0);
        }
        if (transform.position.y < dwLimit)
        {
            transform.Translate(0, dwLimit, 0);
        }*/
	}
}
