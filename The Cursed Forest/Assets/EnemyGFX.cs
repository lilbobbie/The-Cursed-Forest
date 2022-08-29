using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyGFX : MonoBehaviour
{
    public AIPath aiPath;
    public Animator animator;

    void Update()
    {
        if(aiPath.desiredVelocity.x >= 0.01f)
        {
            animator.SetTrigger("Right");
        }
        if (aiPath.desiredVelocity.x <= 0.01f)
        {
            animator.SetTrigger("Left");
        }
        if (aiPath.desiredVelocity.y >= 0.01f)
        {
            animator.SetTrigger("Up");
        }
        if (aiPath.desiredVelocity.y <= 0.01f)
        {
            animator.SetTrigger("Down");
        }
    }
}
