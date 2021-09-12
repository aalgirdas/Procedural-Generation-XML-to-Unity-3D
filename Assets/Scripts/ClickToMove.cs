// ClickToMove.cs
using UnityEngine;

[RequireComponent (typeof (UnityEngine.AI.NavMeshAgent))]
public class ClickToMove : MonoBehaviour {
	RaycastHit hitInfo = new RaycastHit();
	UnityEngine.AI.NavMeshAgent agent;

	void Start () {
		agent = GetComponent<UnityEngine.AI.NavMeshAgent> ();
	}
	void Update () {
		if(Input.GetMouseButtonDown(0)) {
			Vector3 mousePos = Input.mousePosition;
			Debug.Log("mousePos : " + mousePos);
			Ray ray = Camera.main.ScreenPointToRay(mousePos);
			//if (Physics.Raycast(ray.origin, ray.direction, out hitInfo))
				//agent.destination = hitInfo.point;
		}
	}
}
