using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DebugNavMeshAgent : MonoBehaviour
{
    //[SerializeField] private bool _velocity;
    //[SerializeField] private bool _desiredVelocity;
    //[SerializeField] private bool _path;

    //private NavMeshAgent _agent;

    //private void Start()
    //{
    //    _agent = GetComponent<NavMeshAgent>();
    //}

    //private void OnDrawGizmos()
    //{
    //    if(_velocity)
    //    {
    //        Gizmos.color = Color.green;
    //        Gizmos.DrawLine(transform.position, transform.position + _agent.velocity);
    //    }

    //    if( _desiredVelocity)
    //    {
    //        Gizmos.color = Color.red;
    //        Gizmos.DrawLine(transform.position, transform.position + _agent.desiredVelocity);
    //    }

    //    if(_path)
    //    {
    //        Gizmos.color = Color.black;
    //        var agentPath = _agent.path;

    //        Vector3 preevCorner = transform.position;

    //        foreach (var corner in agentPath.corners)
    //        {
    //            Gizmos.DrawLine(preevCorner, corner);
    //            Gizmos.DrawSphere(corner, 0.1f);
    //            preevCorner = corner;
    //        }
    //    }
//}
}
