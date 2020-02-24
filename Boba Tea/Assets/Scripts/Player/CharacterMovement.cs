using UnityEngine;

namespace BobaTea {

    public class CharacterMovement : MonoBehaviour {

        public float Speed = 1.0f;

        void Update()
        {
            // MOVEMENT
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            if (Mathf.Abs(vertical) > 0.001) {
                transform.Translate(new Vector3(horizontal, vertical, 0) * Speed * 0.6f * Time.deltaTime );
            } else {
                transform.Translate(new Vector3(horizontal, vertical, 0) * Speed * Time.deltaTime);
            }
        }
    }

}