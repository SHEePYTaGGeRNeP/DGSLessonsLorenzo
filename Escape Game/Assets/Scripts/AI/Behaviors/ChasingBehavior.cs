using Assets.Scripts.AI;
using Assets.Scripts.Game;
using UnityEngine;

public class ChasingBehavior : StateMachineBehaviour
{
    private AnimatorParametersUpdater _animatorParametersUpdater;
    private SimpleMovement simpleMovement;
    private Transform _target;

    [Header("Debug")]
    [SerializeField]
    private Vector3 _remaining;

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        this._animatorParametersUpdater = animator.GetComponent<AnimatorParametersUpdater>();
        this.simpleMovement = animator.GetComponent<SimpleMovement>();
        this._target = this._animatorParametersUpdater.Sensor.Player.transform;
        Debug.Log("Entered Chase");
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        this._remaining = Utils.ObjectSide(animator.transform, this._target.position);
        this.simpleMovement.MoveByInput(_remaining.x, 1);
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
