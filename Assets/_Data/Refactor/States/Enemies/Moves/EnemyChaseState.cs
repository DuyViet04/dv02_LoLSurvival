using _Data.Refactor.Controllers.Enemies;
using _Data.Refactor.Enums.Enemies;
using Base.Core.StateMachine;
using Base.Systems.Combat;
using UnityEngine;

namespace _Data.Refactor.States.Enemies.Moves
{
    public class EnemyChaseState : BaseEnemyState
    {
        private float attackTimer;

        private readonly ICombatService combatService = new CombatService();

        public EnemyChaseState(EnemyController controller, StateMachine<EnemyState> stateMachine) : base(controller,
            stateMachine)
        {
        }

        public override void OnEnter()
        {
        }

        public override void OnUpdate()
        {
            if (CanAttack())
            {
                Attack();
            }
        }

        public override void OnFixedUpdate()
        {
            var moveSpeed = runtime.UtilityData.MoveSpeed;
            MoveToTarget(target, moveSpeed);
        }

        public override void OnExit()
        {
        }

        void MoveToTarget(Transform target, float moveSpeed)
        {
            var dir = (target.position - self.position).normalized;
            LookTarget(dir);
            rigidbody.linearVelocity = moveSpeed * new Vector3(dir.x, 0, dir.z);
        }

        void LookTarget(Vector3 dir)
        {
            self.rotation = Quaternion.LookRotation(dir);
        }

        bool CanAttack()
        {
            var enemyType = runtime.EnemyData.EnemyType;
            if (enemyType == EnemyType.CannonEnemy || enemyType == EnemyType.RangeEnemy)
            {
                return true;
            }

            return false;
        }

        void Attack()
        {
            var attackDelay = combatService.AttackDelayCalculate(runtime.OffensiveData.AttackSpeed);
            attackTimer += Time.deltaTime;
            if (attackTimer < attackDelay) return;
            attackTimer = 0f;
            Vector3 spawnPos = new Vector3(self.position.x, self.position.y + .5f, self.position.z);
            bulletSpawner.Spawn("Bullet", spawnPos, self.rotation);
            // Debug.Log(runtime.EnemyData.EnemyType + " Attack");
        }
    }
}