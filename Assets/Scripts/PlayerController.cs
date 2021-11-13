using UnityEngine;
using System.Collections;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private StageData stageData;
    [SerializeField]
    private KeyCode keyCodeAttack = KeyCode.Space;
    [SerializeField]
    private KeyCode keyCodeBomb = KeyCode.Z;
    [SerializeField]
    private float speed;
    
    private JoyPad joypad;

    private Movement2D movement2D;
    private Weapon weapon;

    private int score;
    [SerializeField] private string nextSceneName;

    private bool isDie = false;
    private Animator animator;

    public int Score
    {
        set => score = Mathf.Max(0, value);
        get => score;
    }

    private void Awake()
    {
        movement2D = GetComponent<Movement2D>();
        weapon = GetComponent<Weapon>();
        animator = GetComponent<Animator>();
        
        joypad = GameObject.FindObjectOfType<JoyPad>();
    }

    private void Start()
    {
        
        weapon.StartFiring(); 
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
        if (isDie) return;
        
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        movement2D.MoveTo(new Vector3(x, y, 0));

        if(Input.GetKeyDown(keyCodeAttack))
        {
            weapon.StartFiring(); 
        } else if (Input.GetKeyUp(keyCodeAttack))
        {
            weapon.StopFiring();
        }
        
        
        if(Input.GetKeyDown(keyCodeBomb))
        {
            weapon.StartBoom();
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
}
