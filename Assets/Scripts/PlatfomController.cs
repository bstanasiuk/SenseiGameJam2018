using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatfomController : MonoBehaviour
{

	private Vector3 posA;
	private Vector3 posB;
	private Vector3 nexPos;
	[SerializeField] private Transform transformB;
	[SerializeField] private Transform childTransform;
	[SerializeField] private float speed;
	
	void Start ()
	{
		posA = childTransform.localPosition;
		posB = transformB.localPosition;
		nexPos = posB;
	}
	
	void Update ()
	{
		MovePlatform();
		if (Vector3.Distance(childTransform.localPosition, nexPos) <= 0.1)
			ChangeDestination();
	}

	private void MovePlatform()
	{
		childTransform.localPosition =
			Vector3.MoveTowards(childTransform.localPosition, nexPos, speed * Time.deltaTime);
	}

	private void ChangeDestination()
	{
		if (nexPos != posA)
		{
			nexPos = posA;
		}
		else
		{
			nexPos = posB;
		}
	}
}
