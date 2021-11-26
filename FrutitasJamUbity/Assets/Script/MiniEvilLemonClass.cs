using System.Collections;
using UnityEngine;

public class MiniEvilLemonClass : FruitClass
{

    public GameObject playerPosition_;
    private float originalAngle_;
    private float maxAngle_;

    MiniEvilLemonClass(){
      speed_ = 2.0f;
      life_ = 100.0f;
      damage_ = 100.0f;
    }

    ~MiniEvilLemonClass(){}

    void Start()
    {
      rb_ = GetComponent<Rigidbody2D>();
      playerPosition_ = GameObject.FindWithTag("Player");
      originalAngle_ = transform.rotation.z;
    }

    // Update is called once per frame
    void Update()
    {
      move();
    }

    public override void move(){
      originalAngle_ += Time.deltaTime * speed_;
      originalAngle_ = Mathf.Clamp(originalAngle_, 0.0f, 1.0f);
      transform.Rotate(0.0f, 0.0f, originalAngle_, Space.Self);
      
    }

    public override void attack(){

      //TODO tirar la cum

    }

}
