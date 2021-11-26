using UnityEngine;

public class StrawberryClass : FruitClass
{

    public GameObject playerPosition_;
    public GameObject bulletPrefab_;
    private Rigidbody2D bulletRB_;
    private GameObject GO;

    public int force_;
    public float fearRadius_;
    private float fireRate_;

    private bool run_;
    private float runTime_;
    private float stopTime_;
    private float nextTime_;

    StrawberryClass(){
      speed_ = 10.0f;
      life_ = 1.0f;
      damage_ = 10.0f;
      fireRate_ = 1.0f;
      fearRadius_ = 3.0f;
      force_ = 10;
      runTime_ = 0.0f;
      stopTime_ = 2.0f;
      nextTime_ = 0.0f;
      run_ = false;
    }

    ~StrawberryClass(){} 

    void Start()
    {
        GO = GetComponent<GameObject>();
      rb_ = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
      RaycastHit2D fearHit = Physics2D.CircleCast(transform.position, fearRadius_, transform.right, fearRadius_);

      if(fearHit.collider.tag == "Player"){
        run_ = true;
      } else {
      if(Time.time >= nextTime_){
        nextTime_ = Time.time + 1.0f / fireRate_;
        attack();
        }
      }
      
      if(run_) move();
      rotateToPlayer();

    }

    public override void move(){
      
      runTime_ += Time.deltaTime;
      transform.position = Vector2.MoveTowards(transform.position, -playerPosition_.transform.position, speed_ * Time.deltaTime);
      if(runTime_ >= stopTime_){
        run_ = false;
        runTime_ = 0.0f;
      }
    }

    public override void attack(){
      GameObject tmp = Instantiate(bulletPrefab_, transform.position, transform.rotation);
      bulletRB_ = tmp.GetComponent<Rigidbody2D>();
      bulletRB_.AddForce(transform.right * force_, ForceMode2D.Impulse);
    }

    public void rotateToPlayer(){
      Vector3 target = transform.InverseTransformPoint(playerPosition_.transform.position);
      float angle = Mathf.Atan2(target.y, target.x);
      transform.Rotate(0.0f, 0.0f, angle);
    }
    private void TakeDamage()
    {
        life_ = life_ - 1;
    }
    private void OnDie()
    {
        Destroy(GO);
    }
   
}
