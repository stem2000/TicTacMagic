using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacMagic {
    public abstract class UiPanel : MonoBehaviour
    {
        public abstract void Open();
        public abstract void Close();
    }
}
