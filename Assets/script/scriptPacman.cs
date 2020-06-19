using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptPacman : MonoBehaviour
{
    private float velocidade;
    //private float velRot;
    private Rigidbody rbd;
    private Quaternion rotOriginal;
    private float rotMX = 0;
    private float rotMY = 0;
    private Vector3 pos;
    private Vector3 ghost1;
    private Vector3 ghost2;
    private Vector3 ghost3;
    private Vector3 ghost4;
    public GameObject Pinky;
    public GameObject Blinky;
    public GameObject Clyde;
    public GameObject Inky;

    public static int vida = 3;
    // Start is called before the first frame update
    void Start()
    {        
        velocidade = 18;
        rotOriginal = transform.localRotation;
        rbd = GetComponent<Rigidbody>();        
    }

    // Update is called once per frame
    void Update()
    {
        float moveL = Input.GetAxis("Horizontal");
        float moveF = Input.GetAxis("Vertical");

        rotMX += Input.GetAxis("Mouse X");
        rotMY += Input.GetAxis("Mouse Y");

        Quaternion lado = Quaternion.AngleAxis(rotMX, Vector3.up);
        Quaternion cimabaixo = Quaternion.AngleAxis(rotMY, Vector3.left);

        transform.localRotation = rotOriginal * lado;

        rbd.velocity = transform.TransformDirection(new Vector3(moveL * velocidade, rbd.velocity.y, moveF * velocidade));

        if(transform.position.x < -75)
        {
            pos = new Vector3(75f,transform.position.y,-7f);
            transform.position = pos;
        }else if(transform.position.x > 75)
        {
            pos = new Vector3(-75f, transform.position.y, -7.5f);
            transform.position = pos;
        }       
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            /*ghost1 = new Vector3(80f, Inky.transform.position.y, 0f);
            Inky.transform.position = ghost1;

            ghost2 = new Vector3(70f, Pinky.transform.position.y, 0f);
            Pinky.transform.position = ghost2;

            ghost3 = new Vector3(60f, Clyde.transform.position.y, 0f);
            Clyde.transform.position = ghost3;

            ghost4 = new Vector3(70f, Blinky.transform.position.y, -18f);
            Blinky.transform.position = ghost4;*/

            if (vida > 1)
            {
                vida--;
                pos = new Vector3(0, transform.position.y, 10.8f);
                transform.position = pos;                
            }
            else
            {
                Destroy(this.gameObject);
            }
            
        }
    }
}
