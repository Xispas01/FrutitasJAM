//Por favor firmar las modificacions para saber a quien preguntar si se tienen dudas
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementSwapkey : MonoBehaviour
{

    public float speed = 2.0f;                                                                          //Fuerza de movimiento

    public GameObject goh;

    public bool MA;
    public bool MB;
    public bool MD=true;
    public bool MI;
    public float fuerza;
    public float tiea;
                                                                         //Ubicacion lado Izquierdo                                                                                 //AirJumps actuales

    //Otro                                                                      //Contador de muertes
    public Transform SpawnPoint;                                                                        //Coordenadas para Respawn

    private Animator Animator;
    //El Animador del Jugador


    private bool canControl = true;                                                                     //Cooldown Control WallJump (Sirve para ser lanzado sin control)
                                                                       //Permite flipear el personaje a la direccion que se esta moviendo

    private Vector2 aux2D;                                                                              //Vector 2D auxiliar

    public Dictionary<string,KeyCode> inputs = new Dictionary<string, KeyCode>();                                //Diccionario para controles configurables

    private Rigidbody2D rb;                                                                             //CuerpoRigido (Fisicas basada en fuerza y gravedad)


    void Start()                                                                                        //Inicio Start()
    {                   
        rb = gameObject.GetComponent<Rigidbody2D>();
        //Asigna el CuerpoRigido del objeto
        //otro
        Animator = GetComponent<Animator>();
        //Xispas01

        //Asignacion controles
        inputs.Add("Left", SettingsSaving.keys["Left"]);
        inputs.Add("Right", SettingsSaving.keys["Right"]);                                             
        inputs.Add("Up", SettingsSaving.keys["Up"]);
        inputs.Add("Down", SettingsSaving.keys["Down"]);
        inputs.Add("Attack", SettingsSaving.keys["Attack"]);

        canControl = true;                                                                              //Inicializa a true
    }

    // Update is called once per frame
    void FixedUpdate()                                                                                       //Inicio Update()
    {


        if (PauseMenu.IsPaused == false && canControl == true)                                            //Revision de pausa Y control
        {
            if (Input.GetKey(inputs["Right"]))                                                        //Movimiento Derecha
            {
                rb.velocity = Vector2.right * speed;

                if (MD != true)
                {
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                    MA = false;
                    MI = false;
                    MD = true;
                    MB = false;
                }

            }


            if (Input.GetKey(inputs["Left"]))                                                         //Movimiento Izquierda
            {
                rb.velocity = Vector2.left * speed;
                if (MI != true)
                {
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                    MA = false;
                    MI = true;
                    MD = false;
                    MB = false;
                }


            }


            if (Input.GetKey(inputs["Up"]))                                                         //Movimiento Izquierda
            {
                rb.velocity = Vector2.up * speed;
                if (MA != true)
                {
                    transform.rotation = Quaternion.Euler(0, 0, 90);
                    MA = true;
                    MI = false;
                    MD = false;
                    MB = false;
                }


            }


            if (Input.GetKey(inputs["Down"]))                                                         //Movimiento Izquierda
            {
                rb.velocity = Vector2.down * speed;
                if (MB != true)
                {
                    transform.rotation = Quaternion.Euler(0, 0, -90);
                    MA = false;
                    MI = false;
                    MD = false;
                    MB = true;
                }

            }

            if (Input.GetKey(inputs["Attack"]))                                                         //Movimiento Izquierda
            {
                goh.SetActive(true);
                CancelInvoke();
                Invoke("desactivar", tiea);

            }


            //Reinicio velocidad eje X
            if (Input.GetKeyUp(inputs["Right"]) || Input.GetKeyUp(inputs["Left"])                        //Revision soltar teclas movimiento
                || (Input.GetKey(inputs["Right"]) && Input.GetKey(inputs["Left"])))                             //Revision pulsar simultaneas teclas movimiento
            {
                Vector2 aux2D = rb.velocity;                                                            //Reinicio velocidad horizontal
                rb.velocity = Vector2.zero;
            }
            if (Input.GetKeyUp(inputs["Up"]) || Input.GetKeyUp(inputs["Down"])                        //Revision soltar teclas movimiento
           || (Input.GetKey(inputs["Up"]) && Input.GetKey(inputs["Down"])))                             //Revision pulsar simultaneas teclas movimiento
            {
                Vector2 aux2D = rb.velocity;                                                            //Reinicio velocidad horizontal
                rb.velocity = Vector2.zero;
            }
        }

    }

    private void PlaySFX(string name)
    {
        float v = SettingsSaving.sfxV;
        //FindObjectOfType<AudioManager>().Play(name, v);
    }

    //otro
    /**Esto requiere poner el tag "Respawn" en la capa donde est?? las colisiones*/
    public void OnTriggerEnter2D(Collider2D collision) {                                                //Colisi??n con las paredes o el suelo
        if (collision.CompareTag("Respawn")) {

            transform.position = SpawnPoint.position ;
        }

    }

    private void desactivar()
    {
        goh.SetActive(false);
    }
   
}
