using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretProjectile : MonoBehaviour
{
    [SerializeField] public Transform projectSpawnPos;
    [SerializeField] private float delayBtwShots = 1f;
    [SerializeField] private int damage = 5;

    public float Damage {get; set;}
    public float DelayPerShot {get; set;}
    protected float _nextAttackTime;
    protected ObjectPooler _pooler;
    protected Tower _turret;
    protected Projectile _currentProjectileLoaded;


    // Start is called before the first frame update
    private void Start()
    {
        _turret = GetComponent<Tower>();
        _pooler = GetComponent<ObjectPooler>();

        Damage = damage;
        DelayPerShot = delayBtwShots;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if(IsTurretEmpty())
        {
            LoadProjectile();

        }
        if( Time.time > _nextAttackTime)
        {
            if(_turret.CurrentEnemyTarget != null && _currentProjectileLoaded != null && _turret.CurrentEnemyTarget.enemyHealth > 0f)
            
            {
                _currentProjectileLoaded.transform.parent = null;
                _currentProjectileLoaded.SetTarget(_turret.CurrentEnemyTarget);
            }
            _nextAttackTime = Time.time + DelayPerShot;
        }
    }
    protected virtual void LoadProjectile()
    {
        // Debug.Log("Loading Projectile Called");
        GameObject newInstance = _pooler.GetInstanceFromPool();
        newInstance.transform.localPosition = projectSpawnPos.position;
        newInstance.transform.SetParent(projectSpawnPos);
        _currentProjectileLoaded = newInstance.GetComponent<Projectile>();
        _currentProjectileLoaded.TurretOwner = this;
        _currentProjectileLoaded.Damage = Damage;
        newInstance.SetActive(true);
        
    }
    public void ResetTurretProjectile()
    {
        // Debug.Log("Resetting Projectile Called");
        // _currentProjectileLoaded.SetActive(false);
        _currentProjectileLoaded.ResetTurretProjectile();
        _currentProjectileLoaded = null;
        
    }
    bool IsTurretEmpty(){
        if (_currentProjectileLoaded == null)
        {
            return true;
        }else{

        return false;
        }
    }
}
