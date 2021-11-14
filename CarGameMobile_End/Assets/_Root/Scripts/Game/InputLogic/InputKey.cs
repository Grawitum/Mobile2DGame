using JoostenProductions;
using UnityEngine;

namespace Game.InputLogic
{
    internal class InputKey : BaseInputView
    {
        [SerializeField] private float _inputMultiplier = 0.05f;


        private void Start() =>
            UpdateManager.SubscribeToUpdate(Move);

        private void OnDestroy() =>
            UpdateManager.UnsubscribeFromUpdate(Move);


        private void Move()
        {
            //Vector3 direction = CalcDirection();
            //float moveValue = direction.sqrMagnitude * _inputMultiplier * _speed;
            //Debug.Log(moveValue + "MV");
            //float abs = Mathf.Abs(moveValue);
            //Debug.Log(abs + "ABS");
            //float sign = Mathf.Sign(moveValue);
            //Debug.Log(sign + "SING");
            if (Input.GetAxis(AxisManager.HORIZONTAL) > 0)
                OnRightMove(Input.GetAxis(AxisManager.HORIZONTAL)*_inputMultiplier);
            else
                OnLeftMove(-Input.GetAxis(AxisManager.HORIZONTAL)*_inputMultiplier);
        }

        //private Vector3 CalcDirection()
        //{
        //    const float normalizedMagnitude = 1;

        //    Vector3 direction = Vector3.zero;
        //    //direction.x = -Input.acceleration.y;
        //    //direction.z = Input.acceleration.x;

        //    direction.x = Input.GetAxis(AxisManager.HORIZONTAL);
        //    //Debug.Log(Input.GetAxis(AxisManager.HORIZONTAL));
        //    //direction.z = Input.GetAxis(AxisManager.VERTICAL);
        //    //Debug.Log(Input.GetAxis(AxisManager.VERTICAL));
        //    if (direction.sqrMagnitude > normalizedMagnitude)
        //        direction.Normalize();

        //    return direction;
        //}
    }
}
