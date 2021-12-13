using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalConditionCheck : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.name=="Ball")
        {
            GameManager.Goal = true;
            Debug.Log("Goal!!!!!!");
            GameManager.instance.onGoal();

        }
    }
}
