using UnityEngine;
using UnityEngine.AI;

public class CollectStateBehaviour : StateMachineBehaviour
{
    public float collectDistance = 1.5f;
    public float collectTime = 2f;

    private NavMeshAgent agent;
    private GameObject target;

    private float timer;

    override public void OnStateEnter(Animator animator,AnimatorStateInfo stateInfo,int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();

        CharacterAI characterAI = animator.GetComponent<CharacterAI>();

        target = characterAI.Target;

        timer = 0f;
    }

    override public void OnStateUpdate(Animator animator,AnimatorStateInfo stateInfo,int layerIndex)
    {
        if (target == null)
        {
            animator.SetTrigger("FinishCollect");
            return;
        }

        agent.SetDestination(target.transform.position);

        float distance = Vector3.Distance(animator.transform.position,target.transform.position
        );

        if (distance <= collectDistance)
        {
            timer += Time.deltaTime;

            if (timer >= collectTime)
            {
                CharacterAI characterAI =animator.GetComponent<CharacterAI>();

                Destroy(target);

                characterAI.Target = null;
                target = null;

                animator.SetTrigger("FinishCollect");
            }
        }
    }
}