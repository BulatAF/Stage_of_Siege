using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VideoText : MonoBehaviour
{
    [SerializeField] private GameObject Agr;
	[SerializeField] private GameObject Pas;
	[SerializeField] Text text;
	[SerializeField] Text text2;
	string[] Black =  new[]{"На дальнем холме,"," стоит старый увесистый дуб.","Лежат у его корней два брата.","Нашли они богатства несметные, ","и решил тогда старший брат Каин забрать их жене да детям,","а младший, Авель, хотел родителям отдать."};
	string[] White =  new[]{"Не смогли договориться братья, и начали сечу жестокую,","забил досмерти Каин брата своего, раны его кровью истекали, горестно стало ему на душе.","Открыл он сундук с золотом и упал в него замертво.","Так и лежат они под тем дубом старым..."};
    void Start()
    {
        StartCoroutine(ComeIn());
		StartCoroutine(PasNo());
		StartCoroutine(Repl());
		
    }

    IEnumerator ComeIn() 
	{
		yield return  new WaitForSeconds(42f);
		SceneManager.LoadScene(1);
	}
	IEnumerator PasNo() 
	{
		yield return  new WaitForSeconds(20f);
		StartCoroutine(Repl2());
		Pas.SetActive(false);
		Agr.SetActive(true);
	}
	IEnumerator Repl() 
	{
		yield return  new WaitForSeconds(3f);
		text.text = Black[0];
		yield return  new WaitForSeconds(1.5f);
		text.text = Black[1];
		yield return  new WaitForSeconds(3f);
		text.text = Black[2];
		yield return  new WaitForSeconds(2.5f);
		text.text = Black[3];
		yield return  new WaitForSeconds(2.5f);
		text.text = Black[4];
		yield return  new WaitForSeconds(4f);
		text.text = Black[5];
	}
	IEnumerator Repl2() 
	{
		text2.text = White[0];
		yield return  new WaitForSeconds(4f);
		text2.text = White[1];
		yield return  new WaitForSeconds(7f);
		text2.text = White[2];
		yield return  new WaitForSeconds(4f);
		text2.text = White[3];
		
	}
    void Update()
    {
        
    }
}
