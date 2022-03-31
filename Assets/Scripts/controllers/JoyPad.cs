using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

    public class JoyPad : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
    {
        [SerializeField] private RectTransform recFront;
        private float radius;

        private Vector3 input = Vector3.zero;

        public float Horizontal => input.x;
        public float Vertical => input.y;

        public void OnDrag(PointerEventData eventData)
        {
            input = Vector2.ClampMagnitude(
                eventData.position - (Vector2)transform.position,
                radius
                );
            recFront.localPosition = input;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            recFront.localPosition = input = Vector3.zero;
        }

        // Start is called before the first frame update
        private void Start()
        {
            radius =  (transform as RectTransform).rect.width * 0.5F;

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
