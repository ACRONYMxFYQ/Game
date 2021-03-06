﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LS
{
    public class PlayerInput : MonoBehaviour
    {

        [Header("key board axis")]
        public string HorizontalAxis;
        public string VerticalAxis;

        [Header("Press Buttons")]
        public string AttackButton;

        //key board axis value
        [HideInInspector] public float HorizontalValue;
        [HideInInspector] public float VerticalValue;

        //触发信号，是否按下按钮
        [HideInInspector] public bool IsAttack;

        //持续型号，是否持续按压一个键

        /// <summary>
        /// 移动的Vector2的方向信号
        /// </summary>
        public Vector2 InputVec => new Vector2(HorizontalValue, VerticalValue);

        private void Awake()
        {
            IsAttack = false;
        }

        private void Update()
        {
            HorizontalValue = Input.GetAxisRaw(HorizontalAxis);
            //HorizontalValue = Input.GetAxis(HorizontalAxis); 浮点数不行 所以用GetAxisRaw 区别一个 -1~0~1小数变化 一个只有 0 1 -1
            VerticalValue = Input.GetAxisRaw(VerticalAxis);

            IsAttack = Input.GetButtonDown("Attack");
        }
    }


}