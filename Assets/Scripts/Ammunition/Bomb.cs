using UnityEngine;

namespace Ammunition
{
    public class Bomb : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 1f;

        private Rigidbody2D rb2d;
        
        private void Start()
        {
            rb2d = GetComponent<Rigidbody2D>();
            transform.rotation = Quaternion.Euler(0f, 0f, -90f);
        }

        private void FixedUpdate()
        {
            rb2d.MovePosition(transform.position + (Vector3.down * (moveSpeed * Time.fixedDeltaTime)));
        }

        public void OnTouch()
        {
            Destroy(gameObject);
        }
    }
}