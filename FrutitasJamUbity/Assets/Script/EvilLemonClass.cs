using System.Collections.Generic;
using UnityEngine;

public class EvilLemonClass : FruitClass, ITargeteable
{
    public float lemon=0;
    public GameObject evilPrefabRight_;
    public GameObject evilPrefabLeft_;

    private Animator animator;
    private GameObject evilLemonRight_;
    private GameObject evilLemonLeft_;

    private Vector2 lemonLeftPos_;
    private Vector2 lemonRightPos_;

    private int direction_;
    public bool die;

    EvilLemonClass(){
      speed_ = 250.0f;
      life_ = 2.0f;
      damage_ = 1.0f;
    }

    ~EvilLemonClass(){}

    void Start()
    {
      rb_ = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
      direction_ = Random.Range(0, 2);
        switch (direction_)
        {
            case 0: transform.rotation = Quaternion.Euler(0, 0, 90); break;

        }
    }

    void Update()
    {
     move();
     if(die) OnDie();
        
    }

    public override void move(){
      switch(direction_){
        case 0: rb_.velocity = transform.right * speed_ * Time.deltaTime;
                if (rb_.velocity.x > 0)
                {
                    animator.SetInteger("AAAAA", 0);
                }
                else if (rb_.velocity.x < 0)
                    animator.SetInteger("AAAAA", 1);
                break;
        case 1: rb_.velocity = transform.up * speed_ * Time.deltaTime;
                if (rb_.velocity.y> 0)
                {
                    animator.SetInteger("AAAAA", 0);
                }
                else if (rb_.velocity.y < 0)
                    animator.SetInteger("AAAAA", 1);
                break;
        }
    }

    public override void attack(){ }

    public void TakeDamage(){

    }

    public void OnDie(){
      gameObject.SetActive(false);
      switch(direction_){
        case 0: 
          lemonLeftPos_ = new Vector2(transform.position.x, transform.position.y + 1.0f);
          lemonRightPos_ = new Vector2(transform.position.x, transform.position. y - 1.0f);
          break;
        case 1:   
          lemonLeftPos_ = new Vector2(transform.position.x + 1.0f, transform.position.y);
          lemonRightPos_ = new Vector2(transform.position.x - 1.0f, transform.position. y);
          break;
      }
      evilLemonLeft_ = Instantiate(evilPrefabLeft_, lemonLeftPos_, transform.rotation);
      evilLemonRight_ = Instantiate(evilPrefabRight_, lemonRightPos_, transform.rotation);
    }

    void OnCollisionEnter2D(Collision2D collision){
      speed_ *= -1.0f;
    }

}
