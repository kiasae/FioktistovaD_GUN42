using UnityEngine;
using UnityEngine.AI;

public class CollectStateBehaviour : StateMachineBehaviour
{
    public float collectDistance = 1.5f;
    public float collectTime = 2f;

    private NavMeshAgent agent;
    private GameObject target;

    private float timer;

    override public void OnStateEnter(
        Animator animator,
        AnimatorStateInfo stateInfo,
        int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();

        timer = 0f;

        FindTarget(animator);
    }

    override public void OnStateUpdate(
        Animator animator,
        AnimatorStateInfo stateInfo,
        int layerIndex)
    {
        if (target == null)
        {
            animator.SetTrigger("FinishCollect");
            return;
        }

        agent.SetDestination(target.transform.position);

        float distance = Vector3.Distance(
            animator.transform.position,
            target.transform.position
        );

        if (distance <= collectDistance)
        {
            timer += Time.deltaTime;

            if (timer >= collectTime)
            {
                Destroy(target);

                target = null;

                animator.SetTrigger("FinishCollect");
            }
        }
    }

    private void FindTarget(Animator animator)
    {
        Collider[] objects = Physics.OverlapSphere(
            animator.transform.position,
            5f
        );

        foreach (Collider obj in objects)
        {
            if (obj.CompareTag("Collectible"))
            {
                target = obj.gameObject;
                return;
            }
        }
    }
}