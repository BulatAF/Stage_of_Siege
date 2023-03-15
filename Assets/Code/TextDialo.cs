using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TextDialo : MonoBehaviour
{
    string[] evgen =  new[]{"Нет","Но","Пап, можно я гулять пойду?"};
	string[] evgen2 =  new[]{"Помогу, дед.","Геша","Да. Конечно хочу!"};
	string[] ded =  new[]{"Внучок, будь добр ","помоги мне старому муку до мельницы донести.","Спасибо тебе, внучок. Как звать то тебя?","Хорошее имя. Мельницу то хочешь увидеть?","Дойдем, покажу как она работает."};
	string[] mat =  new[]{"Ты что со стула упал! Не ушибся?","Говорила тебе, не качайся на стуле!"};
	string[] otets =  new[]{"Да, иди"," "};
	public static int replWhat;
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
		/*switch(Dialog.whatDialog){
			case 1:
				
			
			break;
			
			case 2:
			
			break;
		}*/
		
        if(Dialog.whatDialog == 1)
		{
			
			if(Input.GetKeyDown(KeyCode.E))
			{
				replWhat += 1;
			}
			if(replWhat == 1){text2.text = mat[0];Dialog.whoSay = 2;}
			if(replWhat == 2){text2.text = evgen[0];Dialog.whoSay = 1;}
			if(replWhat == 3){text2.text = mat[1];Dialog.whoSay = 2;}
			if(replWhat == 4){text2.text = evgen[1];Dialog.whoSay = 1;}
			if(replWhat == 5){text2.text = evgen[2];Dialog.whoSay = 1;}
			if(replWhat == 6){text2.text = otets[0];Dialog.whoSay = 3;}
			if(replWhat == 7){text2.text = otets[1];Dialog.whatDialog = 0;replWhat = 0;}
		}
		if(Dialog.whatDialog == 2)
		{
			
			if(Input.GetKeyDown(KeyCode.E))
			{
				replWhat += 1;
			}
			if(replWhat == 0){text2.text = ded[0];Dialog.whoSay = 4;}
			if(replWhat == 1){text2.text = ded[1];Dialog.whoSay = 4;}
			if(replWhat == 2){text2.text = evgen2[0];Dialog.whoSay = 1;}
			if(replWhat == 3){text2.text = ded[2];Dialog.whoSay = 4;}
			if(replWhat == 4){text2.text = evgen2[1];Dialog.whoSay = 1;TimeLine.DialogDed = 1;}
			if(replWhat == 5){text2.text = ded[3];Dialog.whoSay = 4;}
			if(replWhat == 6){text2.text = evgen2[2];Dialog.whoSay = 1;}
			if(replWhat == 7){text2.text = ded[4];Dialog.whoSay = 4;}
			if(replWhat == 8){text2.text = otets[1];Dialog.whatDialog = 0;}
		}
		
    }
	
}
