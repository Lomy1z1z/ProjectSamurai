using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        PlayerJump.instance.fallSpeed.y = -3f;
            PlayerJump.instance.gravity = 0;
            animator.SetBool("IsDash",true);
        
            
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        PlayerJump.instance.fallSpeed.y = -3f;
            PlayerJump.instance.gravity = 0;
        
            
            
            
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        PlayerJump.instance.fallSpeed.y = -3;
        PlayerJump.instance.gravity -= PlayerJump.instance.fallSpeed.y;
            animator.SetBool("IsDash",false);
        
            

        
   }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
        // Implement code that processes and affects root motion
        
        //PlayerJump.instance.fallSpeed.y = 0f;
           // PlayerJump.instance.gravity = 0f;
            
   // }

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
