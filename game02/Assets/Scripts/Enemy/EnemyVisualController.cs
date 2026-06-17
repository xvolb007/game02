using UnityEngine;

public class EnemyVisualController : MonoBehaviour
{
    private EnemyAIController _enemyAIController;

    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private const string IS_RUNNING = "IsRunning";
    private const string CHASING_SPEED_MULTIPLIER = "ChasingSpeed";
    private const string ATTACK = "Attack";

    private void Awake()
    {
        _enemyAIController = GetComponentInParent<EnemyAIController>();

        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }
    private void Start()
    {
        _enemyAIController.OnEnemyAttack += _enemyAI_OnEnemyAttack;
    }
    private void OnDestroy()
    {
        _enemyAIController.OnEnemyAttack -= _enemyAI_OnEnemyAttack;
    }

    private void Update()
    {
        HandleFlip();
        _animator.SetBool(IS_RUNNING, _enemyAIController.IsMoving);
        _animator.SetFloat(CHASING_SPEED_MULTIPLIER, _enemyAIController.RoamingAnimationSpeed);
    }
    private void HandleFlip()
    {
        Vector2 velocity = _enemyAIController.MovementDirection;

        if (velocity.x > 0.1f)
        {
            _spriteRenderer.flipX = false;
        }
        else if (velocity.x < -0.1f)
        {
            _spriteRenderer.flipX = true;
        }
    }
    private void _enemyAI_OnEnemyAttack(object sender, System.EventArgs e)
    {
        _animator.SetTrigger(ATTACK);
    }
}
