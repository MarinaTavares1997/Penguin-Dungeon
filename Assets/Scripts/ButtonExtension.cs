﻿using System;
using UnityEngine.UI;

namespace PenguinDungeon
{
    public static class ButtonExtension
    {
        public static void AddEventListener<T>(this Button button, T param, Action<T> OnClick)
        {
            button.onClick.AddListener(delegate()
            {
                OnClick(param);
            });
        }
    }
}
