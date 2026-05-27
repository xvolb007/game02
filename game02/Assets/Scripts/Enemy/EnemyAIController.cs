using Assets.Scripts.Enums;
using UnityEngine;
using UnityEngine.AI;


public class EnemyAIController : MonoBehaviour
{
    [SerializeField] private float _roamingDistanceMax;
    [SerializeField] private float _roamingDistanceMin;
    [SerializeField] private State startingState;
    [SerializeField] private float _roamingTimerMax;

    private UnityEngine.AI.NavMeshAgent navMeshAgent;
    private State currentState;
    private float currentRoamingTimer;
    private Vector3 roamPosition;
    private Vector3 startingPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
