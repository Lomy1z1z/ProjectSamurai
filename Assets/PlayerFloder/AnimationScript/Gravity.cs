using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
     override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
     {

       PlayerJump.instance.gravity = -5f;
       PlayerJump.instance.fallSpeed.y = 0.5f; 
       animator.SetBool("doubleJumpBool" , true);

     }

     // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
     override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
     {
     PlayerJump.instance.fallSpeed.y = -0.5f; 
     }

     // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
     override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
     {
        PlayerJump.instance.gravity = -20f;
        PlayerJump.instance.fallSpeed.y = -0.1f; 
        animator.SetBool("doubleJumpBool" , false);
    
     }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
        // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
