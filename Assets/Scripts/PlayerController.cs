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
