using UnityEngine;
using System.Collections;
using RAIN.Core;
public class EthanAI : MonoBehaviour {
	public float _moveMultiplier = 1;
	public GameObject _fireball;
	public Transform _fireballSpawnPoint;

	private Animator _animator;
	private Rigidbody _rigidbody;

	private AIRig _ai;
	// Use this for initialization
	void Start () {
		//obtenemos el componente animator
		_animator = GetComponent<Animator>();
		//obtenemos el componente rigidbody
		_rigidbody = GetComponent<Rigidbody>();

		_ai = GetComponentInChildren<AIRig>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void CreateFireball(){
		GameObject theTarget = _ai.AI.WorkingMemory.GetItem<GameObject>("playerPos");
		Vector3 dir = theTarget.transform.position - transform.position;
		GameObject fireball = Instantiate (_fireball,_fireballSpawnPoint.position,_fireballSpawnPoint.rotation) as GameObject;
		fireball.transform.forward = dir;	
	}

	public void OnAnimatorMove()
	{
		// we implement this function to override the default root motion.
		// this allows us to modify the positional speed before it's applied.
		if (Time.deltaTime > 0)
		{
			Vector3 v = (_animator.deltaPosition * _moveMultiplier) / Time.deltaTime;
			
			// we preserve the existing y part of the current velocity.
			v.y = _rigidbody.velocity.y;
			_rigidbody.velocity = v;
		}
	}
}
