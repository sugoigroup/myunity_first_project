using System;
using System.Collections;
using DefaultNamespace.domain.valueobject;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public enum BossState { MoveToAppearPoint = 0, Phase01, Phase02, Phase03, }
    public class Boss : MonoBehaviour
    {
        [SerializeField] private BossHpViewController _bossHpViewController;
        private BossWeaponViewController _bossWeaponController;
        
        [SerializeField] private StageData stageData;
        [SerializeField] private float bossAppearPoint = 2.5f;
        [SerializeField] private GameObject explosionPrefab;
        [SerializeField] private string nextSceneName;
        
        private BossState bossState = BossState.MoveToAppearPoint;
        private Movement2D movement2D;
        private SpriteRenderer spriteRenderer;
        


        private void Awake()
        {
            movement2D = GetComponent<Movement2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            
            _bossWeaponController= GetComponent<BossWeaponViewController>();
            _bossWeaponController.setOwenerGameObjectId(gameObject.GetInstanceID());
            
            _bossHpViewController.setOwenerGameObjectId(gameObject.GetInstanceID());
            
            
        }

        private void Start()
        {
            MessageBroker.Default.Receive<BombExplodeByOutside>().Subscribe(whoShooted =>
            {
               
                _bossHpViewController.TakeDamage(whoShooted.plusMinusCount);
            }).AddTo(this);
            //
            //
            _bossHpViewController.IsDie.Where(x => x).Subscribe(value => OnDie()).AddTo(this);
            _bossHpViewController.IsDamaged.Subscribe (value =>
                {
                    StopCoroutine("HitColorAnimation");
                    StartCoroutine("HitColorAnimation");
                }
            ).AddTo(this);
        }

        public void OnDie()
        {
            MessageBroker.Default.Publish(new ScorePlusByOutside(_bossHpViewController.LastFromGameObjectId(), 1000));
            
            GameObject clone = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            clone.GetComponent<BossExplosion>().Setup(nextSceneName);
            Destroy(gameObject);
        }

        public void ChangeState(BossState newState)
        {
            StopCoroutine(bossState.ToString());
            bossState = newState;
            StartCoroutine(bossState.ToString());
            
        }

        private IEnumerator MoveToAppearPoint()
        {
            movement2D.MoveTo(Vector3.down);
            while(true)
            {
                if (transform.position.y <= bossAppearPoint)
                {
                    movement2D.MoveTo(Vector3.zero);
                   ChangeState(BossState.Phase01);
                }

                yield return null;
            }
            
        }

        private IEnumerator Phase01()
        {
            _bossWeaponController.StartFiring(AttackType.CircleFire);
            while (true)
            {
                if (_bossHpViewController.HpPercentage() < 0.7f)
                {
                    _bossWeaponController.StopFiring(AttackType.CircleFire);
                    ChangeState(BossState.Phase02);
                }
                yield return null;
            }
        }

        private IEnumerator Phase02()
        {
            _bossWeaponController.StartFiring(AttackType.SingleFireToCenterPosition);
            
            Vector3 direction = Vector3.right;
            movement2D.MoveTo(direction);
            while (true)
            {
                if (transform.position.x <= stageData.LimitMin.x ||
                    transform.position.x >= stageData.LimitMax.x 
                )
                {
                    transform.position = new Vector3(
                        Mathf.Clamp(transform.position.x, stageData.LimitMin.x, stageData.LimitMax.x), 
                        transform.position.y);
                    
                    direction *= -1;
                    movement2D.MoveTo(direction);
                }
                
                if (_bossHpViewController.HpPercentage() < 0.3f)
                {
                    _bossWeaponController.StopFiring(AttackType.CircleFire);
                    ChangeState(BossState.Phase03);
                }
                yield return null;
            }
        }
        private IEnumerator Phase03()
        {
            _bossWeaponController.StartFiring(AttackType.CircleFire);
            _bossWeaponController.StartFiring(AttackType.SingleFireToCenterPosition);
    
            Vector3 direction = Vector3.right;
            movement2D.MoveTo(direction);
            while (true)
            {
                if (transform.position.x <= stageData.LimitMin.x ||
                    transform.position.x >= stageData.LimitMax.x 
                )
                {

                    transform.position = new Vector3(
                        Mathf.Clamp(transform.position.x, stageData.LimitMin.x, stageData.LimitMax.x), 
                        transform.position.y);
                    
                    direction *= -1;
                    movement2D.MoveTo(direction);
                }
                yield return null;
            }
        }
        

        private IEnumerator HitColorAnimation()
        {
            spriteRenderer.color = Color.red;
            yield return new WaitForSeconds(0.05f);
            spriteRenderer.color = Color.white;
        }
    }
    
    
}