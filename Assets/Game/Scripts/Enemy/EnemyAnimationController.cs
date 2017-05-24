using UnityEngine;

// This class is responsible for controlling the enemy animations
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
