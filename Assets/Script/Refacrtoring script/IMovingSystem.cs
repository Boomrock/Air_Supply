using System;
using UnityEngine;

namespace Controller
{
    public interface IMovingSystem
    {
        /// <summary>
        /// transform - двигающиеся тело
        /// vector - направление движение 
        /// </summary>
        Action<Transform, Vector2> MoveAlgoritm { get; set; }
        void SetMove(Action<Transform, Vector2> move);

    }
}