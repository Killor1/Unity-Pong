using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public GameObject ball;
    public GameObject jugador, enemy;
    public GameObject pText, eText;
    public float upLimit = 3.25F;
    public float sideLimit = 4.25F;
    public float bspeed = 4;

    private float yDir = 1F;//1 up, -1 dw
    private float xDir = 1F; //-1 left, 1 right;

    public float hitDist = 1.25F;

    public float speedInc = 1.1F;

    private int ppoints = 0, epoints = 0;

    // Use this for initialization
    void Start () {
       // Debug.Log("Player :"+ppoints+" Enemy :"+epoints);
	}

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 bpos = ball.transform.position;
        //Controlamos las verticales de la pelota:
        float bvertical = bspeed * yDir * Time.deltaTime;
        bpos.y = bpos.y + bvertical;
        if (ball.transform.position.y > upLimit)
        {
            bpos.y = upLimit;
            yDir = -1;
        }
        else if (ball.transform.position.y < -upLimit)
        {
            bpos.y = -upLimit;
            yDir = 1;
        }
            //Y las horizontales:
        float bhorizontal = bspeed * xDir * Time.deltaTime;
        bpos.x = bpos.x + bhorizontal;
        if (ball.transform.position.x >= sideLimit)
        {
            //hay que controlar si toca el enemigo
            if (Mathf.Abs(ball.transform.position.y - enemy.transform.position.y) < hitDist)
            {
                xDir = -1;
            }
            else{
                bpos.x = 0;
                bpos.y = 0;
                bpos.z = 0;
                ppoints++;
               // Debug.Log("Player :" + ppoints + " Enemy :" + epoints);
                pText.GetComponent<TextMesh>().text = "Player : " + ppoints;
                //Time.timeScale *= speedInc;
            }
        }
        else if (ball.transform.position.x <= -sideLimit)
        {
            //hay que controlar si toca el jugador
            if (Mathf.Abs(ball.transform.position.y - jugador.transform.position.y) < hitDist)
            {
                xDir = 1;
            }
            else{
                bpos.x = 0;
                bpos.y = 0;
                bpos.z = 0;
                epoints++;
                eText.GetComponent<TextMesh>().text = "Enemy : " + epoints;
                //Time.timeScale *= speedInc;
            }
        }
        ball.transform.position = bpos;
    }
}
