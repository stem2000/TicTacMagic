using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace TicTacMagic
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] Button resumeButton;
        [SerializeField] Button exitButton;

        public void AddListenerToResumeButtonOnClick(UnityAction action)
        {
            resumeButton.onClick.AddListener(action);
        }

        public void RemoveListenerFromResumeButtonOnClick(UnityAction action)
        {
            resumeButton.onClick.RemoveListener(action);
        }
    }
}
