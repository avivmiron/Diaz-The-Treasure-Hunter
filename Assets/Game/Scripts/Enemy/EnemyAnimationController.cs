/***************************************************************
* file: EnemyAnimationController.cs
* author: Aviv Miron, Ofir Miron
* class: CS470 Game Development
*
* assignment: Final Project
* date last modified: 5/23/2017
*
* purpose: This class is responsible for controlling the enemy animations
*
****************************************************************/ 

using UnityEngine;

public class EnemyAnimationController : MonoBehaviour {

	// List of all enemy animations
	public RuntimeAnimatorController idle;
	public RuntimeAnimatorController attack;
	public RuntimeAnimatorController hit;
	public RuntimeAnimatorController fly;
	public RuntimeAnimatorController die;

	// The animator object used to change the animation of the enemy
	private Animator animator;

	// Change to idle animation (enemy is idle)
	void IdleAnimation() {
		animator = gameObject.GetComponent<Animator>();
		animator.runtimeAnimatorController = idle;
	}

	// Change to attack animation (enemy is attacking player)
	void AttackAnimation() {
		animator = gameObject.GetComponent<Animator>();
		animator.runtimeAnimatorController = attack;
	}

	// Change to hit animation (enemy is shot)
	void HitAnimation() {
		animator = gameObject.GetComponent<Animator>();
		animator.runtimeAnimatorController = hit;
	}

	// Change to die animation (enemy dies)
	void DieAnimation() {
		animator = gameObject.GetComponent<Animator>();
		animator.runtimeAnimatorController = die;
	}

	// Change to fly animation (enemy is chasing player)
	void FlyAnimation() {
		animator = gameObject.GetComponent<Animator>();
		animator.runtimeAnimatorController = fly;
	}
}
