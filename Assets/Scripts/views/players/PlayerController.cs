using UnityEngine;
using System.Collections;
using DefaultNamespace;
using UniRx;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerHpViewController playerHpViewController;
    [SerializeField] private PlayerScoreViewController playerScoreViewController;
    [SerializeField] private PlayerBombCountViewController playerBombCountViewController;

    [SerializeField] private StageData stageData;
    [SerializeField] private KeyCode keyCodeAttack = KeyCode.Space;
    [SerializeField] private KeyCode keyCodeBomb = KeyCode.Z;
    [SerializeField] private float speed;

    private JoyPad joypad;

    private SpriteRenderer spriteRenderer;
    private Movement2D movement2D;
    private WeaponMissile _weaponMissile;

    private int score;
    [SerializeField] private string nextSceneName;

    private bool isDie = false;
    private Animator animator;


    private void Awake()
    {
        movement2D = GetComponent<Movement2D>();
        _weaponMissile = GetComponent<WeaponMissile>();
        animator = GetComponent<Animator>();

        joypad = FindObjectOfType<JoyPad>();
        
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        _weaponMissile.SetOwenerGameObjectId(gameObject.GetInstanceID());
        
        playerHpViewController.SetOwenerGameObjectId(gameObject.GetInstanceID());
        playerScoreViewController.SetOwenerGameObjectId(gameObject.GetInstanceID());
        playerBombCountViewController.SetOwenerGameObjectId(gameObject.GetInstanceID());
        
    }

    private void Start()
    {
        _weaponMissile.StartFiring();

        playerHpViewController.IsDie.Where(x => x).Subscribe(value => OnDie()).AddTo(this);
        playerHpViewController.IsDamaged.Subscribe (value =>
            {
                    StopCoroutine("HitColorAnimation");
                    StartCoroutine("HitColorAnimation");
            }
        ).AddTo(this);

    }

    private void FixedUpdate()
    {
        if (joypad.Horizontal != 0 || joypad.Vertical != 0)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            MoveControl();
        }
    }

    private void MoveControl()
    {
        transform.position += new Vector3(
            Time.deltaTime * speed * joypad.Horizontal * 0.01f,
            Time.deltaTime * speed * joypad.Vertical * 0.01f,
            0);
        print(Time.deltaTime * speed * joypad.Horizontal * 0.01f);
    }


    // Update is called once per frame
    void Update()
    {
        //print(gameObject.GetInstanceID());
        if (isDie) return;

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        movement2D.MoveTo(new Vector3(x, y, 0));

        if (Input.GetKeyDown(keyCodeAttack))
        {
            _weaponMissile.StartFiring();
        }
        else if (Input.GetKeyUp(keyCodeAttack))
        {
            _weaponMissile.StopFiring();
        }


        if (Input.GetKeyDown(keyCodeBomb))
        {
            _weaponMissile.StartBoom();
        }
    }

    private void LateUpdate()
    {
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, stageData.LimitMin.x, stageData.LimitMax.x),
            Mathf.Clamp(transform.position.y, stageData.LimitMin.y, stageData.LimitMax.y)
        );
    }

    public void OnDie()
    {
        movement2D.MoveTo(Vector3.zero);
        animator.SetTrigger("onDie");
        Destroy(GetComponent<CircleCollider2D>());
        isDie = true;
    }

    public void OnDieEvent()
    {
        PlayerPrefs.SetInt("Score", score);
        SceneManager.LoadScene(nextSceneName);
    }
    
    

    private IEnumerator HitColorAnimation()
    {
            
        spriteRenderer.color = Color.yellow;
        yield return new WaitForSeconds(0.1f);

        spriteRenderer.color = Color.white;
    }

    public void TakeDamage(int damage)
    {
        playerHpViewController.TakeDamage(damage);
    }
}