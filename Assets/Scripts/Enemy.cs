using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] GameObject levelManager;
    [SerializeField] private float _speed = 1f;
    [SerializeField] private Waypoint _waypoint;


   // [SerializeField] private int onDeathCoinReward = 2;
    [SerializeField] GameObject FloatingTextPrefab;

    private SpriteRenderer _spriteRenderer;
    // [SerializeField] private int enemyHealth= 20;
    public int maxHealth;
    public int enemyHealth;
    public int enemyGoldValue;

    public int dmgToPlayer;

    public HealthBar healthBar;
    public PlayerHealthBar playerBar;

    private Vector3 _lastPointPosition;
    private Vector3 currentPointPosition;

    private Animator myAnimator;

    // [SerializeField]
    //private Stat health;

    public int  _currentPointIndex = 0;

    // Start is called before the first frame update

      void ShowFloatingText(int damage){
        //  Instatiates the floating text prefab in the middle of the screen
        if(enemyHealth > 0){
            var t = Instantiate(FloatingTextPrefab, transform.position, Quaternion.identity);
            t.transform.localScale = new Vector3(0.07f,0.07f,0.07f);
            t.GetComponent<TextMesh>().text = damage.ToString() ;
            t.GetComponent<TextMesh>().fontStyle = FontStyle.BoldAndItalic;
        }

    }
    IEnumerator changeColor(){
        GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.3f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    public void dealDamage(int damage){
        healthBar.TakeDamage(damage);
        // enemyHealth -= damage;
        if(FloatingTextPrefab){
                    ShowFloatingText(damage);
        }
        StartCoroutine(changeColor());
        if ( healthBar.healthM <= 0) {  //if enemy dies
            Destroy(gameObject);
            levelManager.SendMessage("addGold",enemyGoldValue);
        }


    }
    void Start()
    {
      myAnimator = GetComponent<Animator>();
      enemyHealth = maxHealth;
      healthBar.SetMaxHealth(maxHealth);


        Rotate();
        // _spriteRenderer = GetComponent<SpriteRenderer>();
        _lastPointPosition = transform.position;
        currentPointPosition = _waypoint.GetWaypoint(_currentPointIndex);
        // Debug.Log("Enemy.cs: Start() called");

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
          dealDamage(4);
        }
        Move();
        Rotate();

        if(CurrentPointPositionReached())
        {
            UpdateCurrentPointIndex();
        }

    }
    private void Move()
    {


        transform.position = Vector3.MoveTowards(transform.position, currentPointPosition, _speed * Time.deltaTime);
    }
/*
    private void Rotate(){
        if(_waypoint.GetWaypoint(_currentPointIndex).x > _lastPointPosition.x)
        {
            // flip
            // _spriteRenderer.flipX = false;
           _speed = 2;
           onDeathCoinReward = 5;
        }
        else
        {
            // flip
            //   _spriteRenderer.flipX = true;
            _speed =3;
            onDeathCoinReward = 10;
        }
    }
*/
    private void Rotate(){
      if(_waypoint.GetWaypoint(_currentPointIndex).y > _lastPointPosition.y) //moving up
      {
        myAnimator.SetInteger("Horizontal",0);
        myAnimator.SetInteger("Vertical",1);
      }
      if(_waypoint.GetWaypoint(_currentPointIndex).y < _lastPointPosition.y)//moving down
      {
        myAnimator.SetInteger("Horizontal",0);
        myAnimator.SetInteger("Vertical",-1);
      }
      if(_waypoint.GetWaypoint(_currentPointIndex).y == _lastPointPosition.y)
      {
        //Debug.Log("Hi inside left and right ");
        if(_waypoint.GetWaypoint(_currentPointIndex).x > _lastPointPosition.x)//moving right
        {
          myAnimator.SetInteger("Horizontal",1);
          myAnimator.SetInteger("Vertical",0);
            // flip
            // _spriteRenderer.flipX = false;
            // _speed = 2;
            // onDeathCoinReward = 5;
        }
        else if(_waypoint.GetWaypoint(_currentPointIndex).x < _lastPointPosition.x)//moving left
        {
          myAnimator.SetInteger("Horizontal",-1);
          myAnimator.SetInteger("Vertical",0);
            // flip
            //   _spriteRenderer.flipX = true;
            // _speed =3;
            // onDeathCoinReward = 10;
        }
      }
    }
    private void EndPointReached()
    {
        // ObjectPooler.ReturnToPool
        playerBar.TakeDamage(dmgToPlayer);
        Destroy(gameObject);
        // if(playerBar <= 0)
        // {
        //   SceneManager.LoadScene("EndGame");
        // }
    }

    private void UpdateCurrentPointIndex()
    {
        int lastWaypointIndex = _waypoint.Points.Length - 1;

        if( _currentPointIndex < lastWaypointIndex)
        {
            _currentPointIndex++;
        }
        else
        {
           EndPointReached();
        }
        currentPointPosition = _waypoint.GetWaypoint(_currentPointIndex);
    }
    private bool CurrentPointPositionReached(){
        float distance = (transform.position - _waypoint.GetWaypoint(_currentPointIndex)).magnitude;
        if(distance < 0.1f){
            _lastPointPosition = transform.position;
            return true;
        }
        return false;

    }


}
