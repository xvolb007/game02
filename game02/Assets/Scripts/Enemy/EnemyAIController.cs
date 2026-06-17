using Assets.Scripts.Enums;
using System;
using UnityEngine;
using UnityEngine.AI;


public class EnemyAIController : MonoBehaviour
{
    [SerializeField] private float _roamingDistanceMax = 7f;
    [SerializeField] private float _roamingDistanceMin = 3f;
    [SerializeField] private State startingState;
    [SerializeField] private float _roamingTimerMax = 5f;
    [SerializeField] private float _chasingDistance = 5f;
    [SerializeField] private float _chansingSpeedMultiplier = 2f;

    [SerializeField] private float attackDistance = 1f;
    [SerializeField] private float attackRate = 2f;
    [SerializeField] private float nextAttackTime = 0f;
    public event EventHandler OnEnemyAttack;

    public bool IsMoving => navMeshAgent.velocity.magnitude > 0.1f;
    public float RoamingAnimationSpeed => navMeshAgent.speed / _roamingSpeed;
    public Vector2 MovementDirection => navMeshAgent.velocity;

    private UnityEngine.AI.NavMeshAgent navMeshAgent;
    private State currentState;
    private float currentRoamingTimer;
    private Vector3 roamPosition;
    private Vector3 startingPosition;
    private float _roamingSpeed;
    private float _chasingSpeed;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.updateRotation = false;
        navMeshAgent.updateUpAxis = false;
        currentState = startingState;
        _roamingSpeed = navMeshAgent.speed;
        _chasingSpeed = navMeshAgent.speed * _chansingSpeedMultiplier;
    }

    // Update is called once per frame
    void Update()
    {
        StateHandler();
        UpdateCurrentState();
    }
    private void StateHandler()
    {
        switch (currentState)
        {
            case State.Idle:
                break;
            case State.Roaming:
                HandleRoaming();
                break;
            case State.Chasing:
                HandleChasing();
                break;
            case State.Attacking:
                HandleAttack();
                break;
        }
    }

    private void HandleRoaming()
    {
        currentRoamingTimer -= Time.deltaTime;

        if (currentRoamingTimer <= 0f)
        {
            startingPosition = transform.position;
            roamPosition = GetRandomRoamingPosition();
            navMeshAgent.SetDestination((Vector2)roamPosition);
            currentRoamingTimer = _roamingTimerMax;
        }
    }
    private void HandleChasing()
    {
        navMeshAgent.SetDestination(PlayerController.Instance.transform.position);
    }
    private void HandleAttack()
    {
        if (Time.time > nextAttackTime)
        {
            OnEnemyAttack.Invoke(this, EventArgs.Empty);
            nextAttackTime = Time.time + attackRate;
        }
    }

    private Vector3 GetRandomRoamingPosition()
    {
        return startingPosition + (Vector3)(UnityEngine.Random.insideUnitCircle.normalized * UnityEngine.Random.Range(_roamingDistanceMin, _roamingDistanceMax));
    }

    private void UpdateCurrentState()
    {
        //if (IsAttackAnimationPlaying) return;
        float distanceToPlayer = Vector3.Distance(transform.position, PlayerController.Instance.transform.position);
        if (distanceToPlayer <= attackDistance)
        {
            ChangeState(State.Attacking);
            return;
        }
        if (distanceToPlayer <= _chasingDistance)
        {
            ChangeState(State.Chasing);
            return;
        }
        ChangeState(State.Roaming);
    }
    private void ChangeState(State newState)
    {
        if (currentState == newState) return;
        currentState = newState;

        switch (newState)
        {
            case State.Chasing:
                navMeshAgent.ResetPath();
                navMeshAgent.speed = _chasingSpeed;
                break;

            case State.Roaming:
                currentRoamingTimer = 0f;
                navMeshAgent.speed = _roamingSpeed;
                break;
            case State.Attacking:
                navMeshAgent.ResetPath();
                break;

        }
    }
}