using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour

{
    // public static Action<Enemy, float> OnEnemyHit;

    [SerializeField] protected float moveSpeed = 10f;
    [SerializeField] private float minDisToDealDam = 4f;
    [SerializeField] private  ObjectPooler _pooler;

    public TurretProjectile TurretOwner {get;set;}
    public Projectile  _currentProjectileLoaded;

    public float Damage {get;set;}

    protected Enemy _enenmyTarget;

    
    // Start is called before the first frame update
    void Start()
    {
        _pooler = GetComponent<ObjectPooler>();
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if(_enenmyTarget != null)
        {
            MoveProjectile();
            RotateProjectile();
        }
    }
    protected virtual void MoveProjectile()
    {
        transform.position = Vector2.MoveTowards(transform.position, _enenmyTarget.transform.position, moveSpeed * Time.deltaTime);
        float distanceToTarget = (_enenmyTarget.transform.position - transform.position).magnitude;
        // Debug.Log(distanceToTarget);
        if( distanceToTarget < minDisToDealDam){
            // Debug.Log("Enemy Hit");
            // OnEnemyHit?.Invoke(_enenmyTarget, Damage);
            _enenmyTarget.dealDamage((int)Damage);
            ResetTurretProjectile();
            TurretOwner.ResetTurretProjectile();
            // _pooler.ReturnToPool(gameObject);
        }
}
   public void ResetTurretProjectile()
    {
        // disable the projectile and reset the position of the projectile
        Destroy(gameObject);
        _currentProjectileLoaded= null;
    }
    
        protected virtual void RotateProjectile(){
            Vector3 enemyPos = _enenmyTarget.transform.position - transform.position;
            float angle = Vector3.SignedAngle(transform.up, enemyPos, transform.forward);
            transform.Rotate(0f,0f,angle);
        }
        public void SetTarget(Enemy enemy){
            _enenmyTarget = enemy;
        }
}
