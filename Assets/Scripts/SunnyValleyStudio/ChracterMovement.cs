using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SunnyValleyVersion
{
    public class PlayerMover : MonoBehaviour
    {
        private Rigidbody2D rb2d;
        [SerializeField]
        private float maxSpeed = 2, acceleration = 50, deacceleration = 100;
        [SerializeField]
        private float currentSpeed = 0;
        private Vector2 oldMovementInput;
        public Vector2 MovementInput { get; set; }
        private float speedLimitActor = 1f;
        public Vector2 PushForce { get; set; }
        public bool isUsingMoveSkill { get; set; }

        [Range(0, 1), SerializeField] float pushResist;
        private void Awake()
        {
            rb2d = transform.parent.GetComponent<Rigidbody2D>();
        }
        private void Start()
        {
            isUsingMoveSkill = false;
        }
        public void OnUsingWeaponEvent(bool isUsing)
        {
            if (isUsing)
            {
                speedLimitActor = 0.3f;
            }
            else
            {
                speedLimitActor = 1;
            }
        }
        private void FixedUpdate()
        {
            if (isUsingMoveSkill)
            {
                return;
            }
            PushForce = Vector3.Lerp(PushForce, Vector3.zero, pushResist);
            if (MovementInput.magnitude > 0 && currentSpeed >= 0)
            {
                oldMovementInput = MovementInput*speedLimitActor + PushForce;
                currentSpeed += acceleration * maxSpeed * Time.deltaTime;
            }
            else
            {
                currentSpeed -= deacceleration * maxSpeed * Time.deltaTime;
            }
            currentSpeed = Mathf.Clamp(currentSpeed, 0, maxSpeed);
            rb2d.velocity = oldMovementInput * currentSpeed;

        }
    }
}
