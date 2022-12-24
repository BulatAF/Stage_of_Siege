using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour
{
    [SerializeField] Transform Target;
	[SerializeField, Range(0f,1f)]	float streng = 0.1f;
	[SerializeField] bool Vert;
	private Vector3 delta;
	private Vector3 targetPreviousPosition;
    void Start()
    {
        if(Target != null)
		{
			Target = Camera.main.transform;
		}
		targetPreviousPosition = Target.position;
    }

    
    void Update()
    {
        delta = Target.position - targetPreviousPosition;
		if(Vert == true)
		{
			delta.y = 0f;
		}
		targetPreviousPosition = Target.position;
		transform.position += delta * streng; 
    }
}
