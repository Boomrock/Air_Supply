using System;
using UnityEngine;

namespace Controller
{
    internal class PlayerController : MonoBehaviour, ICharacterController
    {
        Action<Transform, Vector2> _move;
        public Action<Transform, Vector2> MoveAlgoritm { get => _move; set => _move = value; }
        delegate void InputDelegate(Vector2 vector2);
        InputDelegate InputEvents;
        public void SetMove(Action<Transform, Vector2> move)
        {
            MoveAlgoritm = move;
        }
        void Move(Vector2 vector2)
        {
            MoveAlgoritm?.Invoke(transform, vector2);

        }
        float speed = 3;
        void MoveAlg(Transform transform, Vector2 direction)
        {
            transform.GetComponent<Rigidbody2D>().velocity = new Vector2(direction.x * speed, direction.y * speed);
            if (direction.x > 0)
            {
                Quaternion rot = transform.rotation;
                rot.y = 0;
                transform.rotation = rot;
            }

            if (direction.x < 0)
            {
                Quaternion rot = transform.rotation;
                rot.y = 180;
                transform.rotation = rot;
            }
        }
        void Start()
        {
            InputEvents += Move;
            SetMove(MoveAlg);
        }
        void Update()
        {
            Vector2 direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            if(direction != Vector2.zero)
            {
                InputEvents.Invoke(direction);
            }
        }


    }
}
