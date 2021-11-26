//Por favor firmar las modificacions para saber a quien preguntar si se tienen dudas
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementSwapkey : MonoBehaviour
{
    //Xispas01
    //variables
    /*public float jump = 400.0f;                                                                         //Fuerza de salto*/
    public float speed = 2.0f;                                                                          //Fuerza de movimiento
    public float speedLimit = 5.0f;                                                                     //Limite de velocidad
   // public float Wj = 300.0f;                                                                           //Fuerza lateral de WallJump

    public Transform pies;                                                                              //Ubicacion Pies
    public Transform ladoD;                                                                             //Ubicacion lado Derecho
    public Transform ladoI;                                                                             //Ubicacion lado Izquierdo
    public int jumpsMax = 1;                                                                            //Maximos AirJumps
    int jumpsN;                                                                                         //AirJumps actuales

    //Otro
    public int Death_Count;                                                                             //Contador de muertes
    public Transform SpawnPoint;                                                                        //Coordenadas para Respawn
    /*Esto es para que el Death_Count cuente con cierto retraso**/
    /*private float LastRespawn = 0.0f;                                                                   
    private float NextRespawn = 0.1f;*/
    /*Necesidad de adaptar el código de animación del jugador a las necesidades del proyecto**/
    private Animator Animator;                                                                          //El Animador del Jugador

    //Xispas01
    /*public Vector2 limSuelo = new Vector2(0.5f, 0f);                                                    //Tamaños de boxcast Techo/suelo
    public Vector2 limLado = new Vector2(0f, 0.5f);                                                     //Tamaños de boxcast Lados*/

    /*private int ground;                                                                                 //Mascaras para raycast
    private int wall;                                                                                   //Mascaras para raycast
    private int wallJump;                                                                               //Mascaras para raycast*/

    private bool canControl = true;                                                                     //Cooldown Control WallJump (Sirve para ser lanzado sin control)
    
    private SpriteRenderer sprite;                                                                      //Permite flipear el personaje a la direccion que se esta moviendo

    private Vector2 aux2D;                                                                              //Vector 2D auxiliar

    public Dictionary<string,KeyCode> inputs = new Dictionary<string, KeyCode>();                                //Diccionario para controles configurables

    public int player;

    private Rigidbody2D rb;                                                                             //CuerpoRigido (Fisicas basada en fuerza y gravedad)


    void Start()                                                                                        //Inicio Start()
    {                   
        rb = gameObject.GetComponent<Rigidbody2D>();                                                    //Asigna el CuerpoRigido del objeto
        //otro
        Animator = GetComponent<Animator>();
        //Xispas01
        sprite =gameObject.GetComponent<SpriteRenderer>(); 

        //Asignacion controles
        inputs.Add("Left", SettingsSaving.keys["Left"]);
        inputs.Add("Right", SettingsSaving.keys["Right"]);                                             
        inputs.Add("Up", SettingsSaving.keys["Up"]);
        inputs.Add("Down", SettingsSaving.keys["Down"]);

        canControl = true;                                                                              //Inicializa a true
    }

    // Update is called once per frame
    void Update()                                                                                       //Inicio Update()
    {
        
        SettingsSaving.deathsP1 = Death_Count;
          

        if (PauseMenu.IsPaused==false && canControl == true)                                            //Revision de pausa Y control
        {                                                                                         
                if (Input.GetKey(inputs["Right"]))                                                        //Movimiento Derecha
                {                                                                                 
                    rb.AddForce(Vector2.right * speed, ForceMode2D.Impulse);
                    
                    if(sprite.flipX){                                                                   //Flipea el personaje a la direccion que va a moverse
                        sprite.flipX = false;
                    }

                    if (rb.velocity.x >= speedLimit)                                                    //Limitacion de velocidad
                    {                                                                                   
                        aux2D = rb.velocity;                                                              
                        rb.velocity = new Vector2(speedLimit, aux2D.y);                                   
                    }                                                                                   
                }                                                                                       
            }
            
           if (Input.GetKey(inputs["Left"]))                                                         //Movimiento Izquierda
                {                                                                                       
                    rb.AddForce(Vector2.left * speed, ForceMode2D.Impulse);     

                    if(!sprite.flipX){                                                                  //Flipea el personaje a la direccion que va a moverse
                        sprite.flipX = true;
                    }                      

                    if (rb.velocity.x <= speedLimit)                                                    //Limitacion de velocidad
                    {                                                                                   
                        aux2D = rb.velocity;                                                              
                        rb.velocity = new Vector2(-speedLimit, aux2D.y);                                  
                    }                                                                                   
            }                                                                                       
          

           if (Input.GetKey(inputs["Up"]))                                                         //Movimiento Izquierda
                {
                    rb.AddForce(Vector2.up * speed, ForceMode2D.Impulse);

                    if (!sprite.flipX)
                    {                                                                  //Flipea el personaje a la direccion que va a moverse
                        sprite.flipX = true;
                    }

                    if (rb.velocity.x <= speedLimit)                                                    //Limitacion de velocidad
                    {
                        aux2D = rb.velocity;
                        rb.velocity = new Vector2(-speedLimit, aux2D.y);
                    }
            }

           
           if (Input.GetKey(inputs["Down"]))                                                         //Movimiento Izquierda
                {
                    rb.AddForce(Vector2.down * speed, ForceMode2D.Impulse);

                    if (!sprite.flipX)
                    {                                                                  //Flipea el personaje a la direccion que va a moverse
                        sprite.flipX = true;
                    }

                    if (rb.velocity.y <= -speedLimit)                                                    //Limitacion de velocidad
                    {
                        aux2D = rb.velocity;
                        rb.velocity = new Vector2( aux2D.y, - speedLimit);
                    }
            }
           

            //Reinicio velocidad eje X
            if (Input.GetKeyUp(inputs["Right"]) || Input.GetKeyUp(inputs["Left"])                           //Revision soltar teclas movimiento
            || (Input.GetKey(inputs["Right"]) && Input.GetKey(inputs["Left"])))                             //Revision pulsar simultaneas teclas movimiento
            {
                Vector2 aux2D = rb.velocity;                                                            //Reinicio velocidad horizontal
                rb.velocity = Vector2.zero;                                                 
            }
        
    }

    private void PlaySFX(string name)
    {
        float v = SettingsSaving.sfxV;
        FindObjectOfType<AudioManager>().Play(name, v);
    }

    //otro
    /**Esto requiere poner el tag "Respawn" en la capa donde esté las colisiones*/
    public void OnTriggerEnter2D(Collider2D collision) {                                                //Colisión con las paredes o el suelo
        if (collision.CompareTag("Respawn")) {

            transform.position = SpawnPoint.position ;
        }

    }
   
}
