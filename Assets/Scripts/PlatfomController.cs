using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class PlatfomController : MonoBehaviour
{

	private Vector3 posA;
	private Vector3 posB;
	private Vector3 nexPos;
	[SerializeField] private Transform transformB;
	[SerializeField] private Transform childTransform;
	[SerializeField] private float speed;
	
	public float fireDelay = 3.0f; // Seconds to wait

	private float fireTimestamp = 0.0f;
	
	void Start ()
	{
		posA = childTransform.localPosition;
		posB = transformB.localPosition;
		nexPos = posB;
		fireTimestamp = Time.realtimeSinceStartup + fireDelay;
	}

	void Update()
	{
		if (Time.realtimeSinceStartup > fireTimestamp)
		{
			MovePlatform();
			if (Vector3.Distance(childTransform.localPosition, nexPos) <= 0.1)
				ChangeDestination();
		}
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
