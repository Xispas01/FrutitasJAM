using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class FruitClass : MonoBehaviour
{

  protected Rigidbody2D rb_;
  protected float speed_;
  protected float life_;
  protected float damage_;

  void Start(){
    rb_ = GetComponent<Rigidbody2D>();
  }

  void Update(){

  }


  void FixedUpdate(){

  }

  public FruitClass(){
    speed_ = 100.0f;
    life_ = 100.0f;
    damage_ = 100.0f;
  }

  ~FruitClass(){

  }

  public virtual void move(){


  }
  public virtual void attack(){


  }

}
