using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class TimeLine : MonoBehaviour
{
	public PlayableDirector director;
	public PlayableDirector director2;
	public PlayableDirector director3;
	public PlayableDirector director4;
	public PlayableDirector directorDed;
	public Animator anim;
	public RuntimeAnimatorController plCntr;
	public static int quithome;
	public static int DialogDed;
	private bool one;
    
	void Awake()
	{
		plCntr = anim.runtimeAnimatorController;
	}
    void Start()
    {
      // anim.runtimeAnimatorController = null;
	}
	void OnEnable()
	{
		plCntr = anim.runtimeAnimatorController;
		anim.runtimeAnimatorController = null;
	}	
	
	
   
    void Update()
    {
		if(directorDed.state != PlayState.Playing)
		{
			anim.runtimeAnimatorController = plCntr;
		}
		if(DialogDed == 1 && one == false)
		{
			StartCoroutine(Ded());
				IEnumerator Ded()
			{
				one = true;
				directorDed.Play();
				yield return  new WaitForSeconds(30.2f);
				directorDed.Stop();
				anim.runtimeAnimatorController = null;
			}
		}
		anim.runtimeAnimatorController = plCntr;
    
		plCntr = anim.runtimeAnimatorController;
		if(director2.state != PlayState.Playing)
		{
			anim.runtimeAnimatorController = plCntr;
		}
		if(director.state != PlayState.Playing)
		{
			anim.runtimeAnimatorController = plCntr;
		}
		if(quithome == 1)
		{
			 director.Play();
			 
		}
		if(quithome == 2)
		{
			StartCoroutine(ComeIn());
		}
		
        
    IEnumerator ComeIn()
	{
		director2.Play();
		anim.runtimeAnimatorController = null;
		yield return  new WaitForSeconds(2f);
		director2.Stop();
		quithome = 0;
		
	}
	if(quithome == 3)
		{
			 director3.Play();
			 anim.runtimeAnimatorController = null;
		}
		if(quithome == 4)
		{
			
			StartCoroutine(ComeIn2());
		}
		IEnumerator ComeIn2()
	{
		director4.Play();
		anim.runtimeAnimatorController = null;
		yield return  new WaitForSeconds(1.47f);
		quithome = 0;
		 director4.Stop();
	}
        if(director4.state != PlayState.Playing)
		{
			anim.runtimeAnimatorController = plCntr;
		}
    }
}
