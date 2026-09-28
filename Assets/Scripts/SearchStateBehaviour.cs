using UnityEngine;
using UnityEngine.AI;

public class SearchStateBehaviour : StateMachineBehaviour
{
    public float searchRadius = 10f;
    public float detectionRadius = 5f;

    private NavMeshAgent agent;
    private GameObject target;

    override public void OnStateEnter(
        Animator animator,
        AnimatorStateInfo stateInfo,
        int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();

        SetRandomDestination(animator);
    }

    override public void OnStateUpdate(
        Animator animator,
        AnimatorStateInfo stateInfo,
        int layerIndex)
    {
        FindCollectible(animator);

        if (!agent.pathPending &&
            agent.remainingDistance <= 0.5f)
        {
            SetRandomDestination(animator);
        }
    }

    private void SetRandomDestination(Animator animator)
    {
        Vector3 randomDirection =
            Random.insideUnitSphere * searchRadius;

        randomDirection += animator.transform.position;

        NavMeshHit hit;

        if (NavMesh.SamplePosition(
            randomDirection,
            out hit,
            searchRadius,
            NavMesh.AllAreas))
        {
            agent.SetDestination(hit.position);
        }
    }

    private void FindCollectible(Animator animator)
    {
        Collider[] objects = Physics.OverlapSphere(
            animator.transform.position,
            detectionRadius
        );

        foreach (Collider obj in objects)
        {
            if (obj.CompareTag("Collectible"))
            {
                CharacterAI characterAI = animator.GetComponent<CharacterAI>();

                characterAI.Target = obj.gameObject;

                animator.SetTrigger("StartCollect");

                return;
            }
        }
    }
}