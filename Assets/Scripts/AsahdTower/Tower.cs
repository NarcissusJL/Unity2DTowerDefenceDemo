using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour{

    [SerializeField] GameObject Circle;
    //[SerializeField] private float projectileSpeed = 1f; 
    [SerializeField] private float areaSize = 10 ; // Initialize to zero so you can set it to default in Start()
    //[SerializeField] private int projectileDamage = 4; //Make it flat for now, but maybe I'll implement critical hits later, who knows lol
   // [SerializeField] private float attackSpeed = 1f; //Make it flat for now, but maybe I'll implement critical hits later, who knows lol
    [SerializeField] private List<Enemy> _enemies ;

    public Enemy CurrentEnemyTarget;
    private void checkEnemiesWithinRange(){
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(Circle.transform.position, Circle.GetComponent<CircleCollider2D>().radius, 1 << LayerMask.GetMask("Enemy"));
          for(int i=0; i<hitColliders.Length; i++){
            if(hitColliders[i].CompareTag("Enemy")){
            Enemy newEnemy = hitColliders[i].GetComponent<Enemy>();
            _enemies.Add(newEnemy);
            }

        }
    }
    private void GetCurrentEnemyTarget(){
        if (_enemies.Count <= 0){
            CurrentEnemyTarget = null;
            return ;
        }
        CurrentEnemyTarget = _enemies[_enemies.Count-1];
        
    }
    // private void OnTriggerEnter2D(Collider2D other) {

    //     if (other.CompareTag("Enemy")){
    //         Enemy newEnemy = other.GetComponent<Enemy>();
    //         Debug.Log("ENEMY ENTERED");
    //         _enemies.Add(newEnemy);

    //     }
    // }
    // private void OnTriggerExit2D(Collider2D other){
    //     if( other.CompareTag("Enemy"))
    //     {
    //         Enemy enemy = other.GetComponent<Enemy>();
    //         if(_enemies.Contains(enemy))
    //         {
    //             _enemies.Remove(enemy);
    //         }
    //     }
    // }



    // Start is called before the first frame update
    void Start()
    {
       
        areaSize= Circle.GetComponent<CircleCollider2D>().radius;
    }

    // Update is called once per frame
    void Update()
    {
        _enemies = new List<Enemy>();
        checkEnemiesWithinRange() ; 
        GetCurrentEnemyTarget();


        // for(int i=0; i<enemiesInRange.Length; i++){
        //     enemiesInRange[i].SendMessage("dealDamage", projectileDamage);
        // }
    }
}
