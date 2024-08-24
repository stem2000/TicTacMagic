using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TicTacMagic
{
    public class MainMenuManager : MonoBehaviour
    {
        [SerializeField] private Button continueButton;
        private string lastLvlKey = "lastLvl";
        private int lastLvlNumber = 1;

        private void Start()
        {
            if(PlayerPrefs.HasKey(lastLvlKey))
                lastLvlNumber = PlayerPrefs.GetInt(lastLvlKey);

            continueButton.onClick.AddListener(LoadLastLevel);
        }

        private void LoadLastLevel()
        {
            SceneManager.LoadScene(lastLvlNumber, LoadSceneMode.Single);
        }


    }
}
