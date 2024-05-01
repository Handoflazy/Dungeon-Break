using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIState : MonoBehaviour
{
    private EnemyAIBrain enemyAIBrain = null;
    [SerializeField]
    private List<AIAction> actions = null;
    [SerializeField]
    private List<AITransition> transitions = null;


    private void Awake()
    {
        enemyAIBrain = transform.root.GetComponent<EnemyAIBrain>();

    }

    public void UpdateState()
    {
        foreach (var action in actions)
        {
            action.TakeAction();
        }
        foreach (var transition in transitions)
        {
            bool result = false;
            foreach (var decision  in transition.Decisions) {
                result = decision.MakeDecision();
                if (result == false)
                {
                    break;
                }   
            }
            if (result)
            {
                if(transition.PositiveResult!=null)
                {
                    enemyAIBrain.ChangeToState(transition.PositiveResult);
                }
            }
            else
            {
                if(transition.NegativeResult!=null)
                {
                    enemyAIBrain.ChangeToState(transition.NegativeResult);
                    return;
                }
            }
        }
    }

}
