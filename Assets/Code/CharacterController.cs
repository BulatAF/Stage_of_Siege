using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class CharacterController : MonoBehaviour // объявление скрипта
{
	private Animator anim; // аниматор = аним
	[SerializeField] private float speed;// открытая переменная скорость
	[SerializeField] BoxCollider2D target;// открытый объект таргет
	private bool facingRight = true; // лицо вправо = правда
	private Rigidbody2D rb; //  рб = компонент риджет бади
	public static int cherch;
	private Vector2 moveVector; //б приватная переменная вектор 2д moveVector 
	private bool cortan;// бул накортанах
	private bool run;// бул бег
	private bool jump;// бул прыжок
	public static float ypos;// открытая переменная  Y  позиция
	public static int jumpP; // открытая переменная прыжок
	private bool isobject; // бул есть объект
	private bool isHome;// бул есть дом
	private bool isHome2;// бул есть дом(с улицы)
	private bool isCherch;// бул есть церковь
	private bool isCherch2;// бул есть церковь(с улицы)
	private bool isUl;// бул есть улицы
	public Transform CheckPos;// объект проверка позиции
	public float CheckRadius;// публичная переменная проверочный радиус 
	public LayerMask whatIsTable;// слой что есть стол, печь
	public LayerMask whatIsHome;// слой что есть дом
	public LayerMask whatIsHome2; // слой что есть вход в дом с улицы
	public LayerMask whatIsUl; // слой что есть выход из дом 
	public LayerMask whatIsCherch; // слой что есть выход из церкви 
	public LayerMask whatIsCherch2; // слой что есть вход в церковь 
    private bool oneComeinCherch;
	public PlayableDirector director;
	public bool pod;
     void Start()// начало программы
    {
		if(Dialog.whatDialog == 1)
		{
			pod = true;
		}
		anim = GetComponent<Animator>();// амин = аниматор
		rb = GetComponent<Rigidbody2D>();// рб = риджет бади
		target = GetComponent<BoxCollider2D>();// таргет = бокс коллайдер
		if(cherch == 2 )
		{
			cherch = 0;
			transform.position = new Vector3(-58.7f, -5f, 0f);
		}
    }
	private void FixedUpdate()// постоянный покадровый цикл
	{
		if( pod == true)
		{
			StartCoroutine(Pod());
			IEnumerator Pod() 
		{
			anim.StopPlayback();
			anim.Play("lesgit"); 
			yield return  new WaitForSeconds(3.38f);
			pod = false;
		}
		}
		if (jump == true && isobject == true) // если прыжок правда и есть объект(стол или печь)
		{
			moveVector.x = 0f; // прекратить передвижение по оси x
		}
		else{ // иначе 
		moveVector.x = Input.GetAxis("Horizontal");// движение по горизонтали на клавиатуре = движ по x
		}
		if( isobject == false){
		moveVector.y = Input.GetAxis("Vertical");
		}
		else{moveVector.y = 0f;}
		if(facingRight == false && moveVector.x > 0 )
			{
				Flip();
				
			}
			else if(facingRight == true && moveVector.x < 0   )
			{
				Flip();
				
			}
			if(cortan == false && run == false && jump == false)
			{
				rb.velocity = new Vector2(moveVector.x * speed, moveVector.y * speed);
			}
			if(cortan == false && run == false && jump == false)
		{
		
			if(moveVector.x == 0f && moveVector.y == 0f && pod == false)
			{
				anim.StopPlayback();
				anim.Play("IDLE"); 
			}
			if(moveVector.x > 0f || moveVector.x < 0f || moveVector.y > 0f || moveVector.y < 0f) 
			{
			
				anim.StopPlayback();
				anim.Play("Walk");
			}
		}
		 else if(cortan == true && run == false && jump == false)
		{
			
			rb.velocity = new Vector2(moveVector.x * speed * 0.6f, moveVector.y * speed * 0.6f);
		
		if(moveVector.x == 0f && moveVector.y == 0f)
		{
			
			anim.StopPlayback();
			anim.Play("IDLEPris"); 
		}
		if(moveVector.x > 0f || moveVector.x < 0f || moveVector.y > 0f || moveVector.y < 0f) 
		{
			
			anim.StopPlayback();
			anim.Play("WalkPris");
		}
		}
	}
    IEnumerator Quit()
	{
		yield return  new WaitForSeconds(1.6f);
		SceneManager.LoadScene(2);
	}
	IEnumerator ComeIn() 
	{
		cherch = 0;
		SceneManager.LoadScene(1);
		TimeLine.quithome = 2;
		yield return  new WaitForSeconds(1.47f);
		TimeLine.quithome = 0;
		
	}
	IEnumerator ComeIn2()// В церковь
	{
		rb.velocity = new Vector2(0f,0f);
		if(oneComeinCherch == false)
		{
			
			director.Play();
			TimeLine.quithome = 2;
			yield return  new WaitForSeconds(3f);
			SceneManager.LoadScene(3);
			TimeLine.quithome = 0;
			
		}
	}
    void Update()
    {
		
		isobject = Physics2D.OverlapCircle(CheckPos.position,CheckRadius,whatIsTable);
		isHome = Physics2D.OverlapCircle(CheckPos.position,CheckRadius,whatIsHome);
		isHome2 = Physics2D.OverlapCircle(CheckPos.position,CheckRadius,whatIsHome2);
		isCherch = Physics2D.OverlapCircle(CheckPos.position,CheckRadius,whatIsCherch);
		isCherch2 = Physics2D.OverlapCircle(CheckPos.position,CheckRadius,whatIsCherch2);
		isUl = Physics2D.OverlapCircle(CheckPos.position,CheckRadius,whatIsUl);
		ypos = transform.position.y;
		if(run == true && (moveVector.x > 0f || moveVector.x < 0f || moveVector.y > 0f || moveVector.y < 0f) )
		{
			anim.StopPlayback();
			anim.Play("Run");
			rb.velocity = new Vector2(moveVector.x * speed * 1.6f, moveVector.y * speed * 1.6f);
		}
		else if(moveVector.x == 0f && moveVector.y == 0f && cortan == false && pod == false)
			{
				anim.StopPlayback();
				anim.Play("IDLE"); 
			}
		if(Input.GetKey(KeyCode.LeftControl))
		{
			cortan = true;
		}
		else {cortan = false;}
		if(Input.GetKey(KeyCode.LeftShift) && jump == false)
		{
			run = true;
		}
		else {run = false;}
		if(Input.GetKeyDown(KeyCode.Space)&& jump == false && isobject == false && ypos < -2.29f)   
		{
			run = false;
			jump = true;
			StartCoroutine(Jump());
		}
       if(isHome2 == true)// если на улице подошёл к дому
	   {
		  StartCoroutine(ComeIn());
		   SceneManager.LoadScene(1);
		  
		}
	   if(isUl == true && Dialog.whoSay > 2)// если в доме подошёл к двери
	   {
		  StartCoroutine(Quit());
		  TimeLine.quithome = 1;
	   }
	    if(isCherch2 == true)// если на улице подошёл к церкви
	   {
		  rb.velocity = new Vector2(0f,0f);
		  StartCoroutine(ComeIn2());
		  cherch = 1;
		  
		}
	   if(isCherch == true)// если в церкви подошёл к двери
	   {
		  StartCoroutine(Quit());
		  TimeLine.quithome = 1;
		  cherch = 2;
	   }
    }
	void Flip()
	{
		facingRight = !facingRight;
		Vector3 Scaler = transform.localScale;
		Scaler.x *= -1;
		transform.localScale = Scaler;
	}
	IEnumerator Jump()
		{
			if(jump == true){
			jumpP = 1;	
			GetComponent<BoxCollider2D>().enabled = false;
			if(isHome == false)
			{
				rb.velocity = new Vector2(moveVector.x * speed *1.5f,3f);
			}
			else{rb.velocity = new Vector2(0f,3f);}
			anim.StopPlayback();
			anim.Play("Jump");
			yield return  new WaitForSeconds(0.25f);
			if(isHome == false)
			{
				rb.velocity = new Vector2(moveVector.x * speed *1.5f,-3f);
			}
			else{rb.velocity = new Vector2(0f,-3f);}
	
			yield return  new WaitForSeconds(0.25f);
			GetComponent<BoxCollider2D>().enabled = true;
			jumpP = 0;
			jump = false;
			}
	
		
		}
}

