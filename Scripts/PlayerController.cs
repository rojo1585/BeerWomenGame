using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2D;
    
    [Header("PlayerStatus")]
    public float healt;
    [Header("Movimiento")]

    private float horizontalMovement = 0f;
    //velocidad de movimiento s
    [SerializeField] private float speedMovement;
    //suavisado del movimiento
    [Range (0, 1)][SerializeField] private float motionSmoot;
    //iniciar velocidad en z en cero
    private Vector3 speed = Vector3.zero;
    private bool lookRight = true;
    
    [Header("Jump")]
    [SerializeField] private float jumpForce;
    [SerializeField] private LayerMask isFloor;
    [SerializeField] private Transform floorController;
    [SerializeField] private Vector3 boxZize;
    [SerializeField] private bool onTheFloor;
    private bool jump;

    [Header("Atack")]
    private float basicAtack;
    private float dashAtack;
    private float slide;
    
    [Header("Life")]
    public bool life = true;

 
    [Header("Animations")]
    private Animator animator;
 

    // Start is called before the first frame update
    void Start()
    {   
        //instacia de los objetos 
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        healt = 100;
        speedMovement = 100;
        motionSmoot = 0.1f;
        jumpForce = 199;
        animator.SetBool("IsDead", false);

       
    }

    // Update is called once per frame
    void Update()
    {
        //Tomar la direccione del control izquierda = -1 derecha 1
        horizontalMovement = Input.GetAxisRaw("Horizontal") * speedMovement;
        //tomar control atacke basico
        basicAtack = Input.GetAxisRaw("Fire1");
        dashAtack = Input.GetAxisRaw("Fire2");
        slide = Input.GetAxisRaw("Vertical");
        //atack
        
        //SelectAtack();

        //mandar al animator la velocidad para que reconosca que se esta moviendo y ejecute la animacion de correr
        animator.SetFloat("Horizontal", Mathf.Abs(horizontalMovement));
        //mandar al animator la velocidad en y para saber si esta subiendo o bajando y ejecutar las animaciones saltar o caer
        animator.SetFloat("SpeedY",rb2D.velocity.y);
        
        
        //Salto
        if(Input.GetButtonDown("Jump")){
            jump = true;
        }
    }

    private void FixedUpdate(){
        //conmdicion para saber que estamos en el suelo mieentra que el controlador de piso es te tocando el piso 
        onTheFloor = Physics2D.OverlapBox(floorController.position, boxZize, 0f, isFloor);
        animator.SetBool("OnFloor",onTheFloor);
        //ataque
        
        //slide
        animator.SetFloat("IsSlide",slide);

        //Mover
        Move(horizontalMovement * Time.fixedDeltaTime, jump);

        //evitar que siempre se mande la opcion saltar    
        jump = false;
    }

    private void Move(float move, bool jump){
        //para no alterar la velocidad cuando se salta o se caiga 
        Vector3 targetSpeed = new Vector2(move, rb2D.velocity.y);
        //obtener un suavizado al acelerar o frenar el persoange teniendo en cuenta la velocidad en la que esta el personaje, a l aque quiere llega y que tan rapido  
        //rb3d.velocity = velocidad del personaje
        //targetSpeed = velocidad a la que se quiere llegar
        //motionSmoot = veolidad del suavizado
        rb2D.velocity = Vector3.SmoothDamp(rb2D.velocity, targetSpeed, ref speed, motionSmoot);

        if (move > 0 && !lookRight){
            Turn();
        } else if(move < 0 && lookRight){
            Turn();
        }

        if(onTheFloor && jump){
            onTheFloor = false;
            rb2D.AddForce(new Vector2(0f, jumpForce));
        }

    }
    //girar personaje
    private void Turn(){
        //colocar la variable en sentido contrario a la que se tiene y cmabiar la direcion del personaje en la escala
        lookRight = !lookRight;
        Vector3 escale = transform.localScale;
        escale.x *= -1;
        transform.localScale = escale;
    }

    //selecciona el tipo de ataque impidiendo realizar dos animiciones a la vez y evalua el tiempo para realizar el proixmo ataqu
   // public void SelectAtack(){
     //   if(Input.GetButtonDown("Fire1") && timeNextHit <= 0){ animator.SetTrigger("BasicAtack"); timeNextHit = timeBetweenHit;}
       // else if(Input.GetButtonDown("Fire2") && timeNextHitDash <=0){ animator.SetTrigger("DashAtack"); timeNextHitDash = timeBetweenHitDash;}
    //}

    //toma el daño del jugador para evaluar su muerte
    public void TakeDamagePlayer(float damage){
        healt -= damage;
        GetComponent<HealtContrroller>().ChangeSlider(damage * 0.01f);
        if(healt <= 0){
            DeadPlayer();
        }
        
    }
    public void AtackOne(){
        animator.SetTrigger("BasicAtack");
    }

    public void AtackDash(){
        animator.SetTrigger("DashAtack");
    }



    public void TakeHitPlayer(){
        animator.SetTrigger("TakeHit");
    }
    public void DeadPlayer(){
        animator.SetBool("IsDead",true); 
        life = false;
    }

    public bool IsPlayerAlive(){
        if(healt > 0){
            animator.SetTrigger("IsPlayeAlive");
            life = true;
            return true;
        }else{life = false; return false;}
        
    }

    
    
    private void OnDrawGizmos(){
     Gizmos.color = Color.green;
        Gizmos.DrawWireCube(floorController.position, boxZize);
    }

}
