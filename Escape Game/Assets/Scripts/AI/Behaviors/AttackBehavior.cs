using Assets.Scripts.AI;
using Assets.Scripts.Game;
using UnityEngine;

public class AttackBehavior : StateMachineBehaviour
{
    private AnimatorParametersUpdater _animatorParametersUpdater;
    private IHealthSystem _healthSystem;

    [SerializeField]
    private float _attackCooldown = 1f;

    [SerializeField]
    private int _damage = 5;

    [Header("Debug")]
    [SerializeField]
    private float _remaining;

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        this._animatorParametersUpdater = animator.GetComponent<AnimatorParametersUpdater>();
        this._healthSystem = this._animatorParametersUpdater.Sensor.Player.GetComponent<IHealthSystem>();
        this.TryAttack();
        Debug.Log("Enterted Attack");
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        this.TryAttack();
    }

    private void TryAttack()
    {
        this._remaining = Mathf.Max(0, this._attackCooldown - (Time.time - this._animatorParametersUpdater.LastAttackTime));
        if (this._remaining > 0)
            return;
        this._healthSystem.Damage(this._damage);
        this._animatorParametersUpdater.LastAttackTime = Time.time;
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
