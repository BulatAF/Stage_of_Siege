﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TextDialog : MonoBehaviour
{
    string[] evgen =  new[]{"Нет","Но","Пап, можно я гулять пойду?"};
	string[] mat =  new[]{"Ты что со стула упал! Не ушибся?","Говорила тебе, не качайся на стуле!"};
	string[] otets =  new[]{"Да, иди"," "};
	private int replWhat;
	[SerializeField] Text text2;
	
    void Start()
    {
		if(Dialog.whatDialog == 1)
		{
			replWhat = 1;
		}
    }

    
    void Update()
    {
		
        if(Dialog.whatDialog == 1)
		{
			
			if(Input.GetKeyDown(KeyCode.F))
			{
				replWhat += 1;
			}
			if(replWhat == 1){text2.text = mat[0];Dialog.whoSay = 2;}
			if(replWhat == 2){text2.text = evgen[0];Dialog.whoSay = 1;}
			if(replWhat == 3){text2.text = mat[1];Dialog.whoSay = 2;}
			if(replWhat == 4){text2.text = evgen[1];Dialog.whoSay = 1;}
			if(replWhat == 5){text2.text = evgen[2];Dialog.whoSay = 1;}
			if(replWhat == 6){text2.text = otets[0];Dialog.whoSay = 3;}
			if(replWhat == 7){text2.text = otets[1];Dialog.whoSay = 3;Dialog.whatDialog = 0;}
		}
		
    }
	
}
