using UnityEngine;

namespace BobaTea {

    public class GameController : MonoBehaviour
    {
        public delegate void GameStartDelegate();
        public event GameStartDelegate GameStart;

        public delegate void GamePauseDelegate();
        public event GamePauseDelegate GamePause;

        public delegate void GameEndDelegate();
        public event GameEndDelegate GameEnd;

        // don't throw any events before Start()
        // to allow objs to subscribe on Awake()
        void Start () {
            GameStart();
        }

        public void PauseGame () {
            GamePause();
        }

        public void EndGame () {
            GameEnd();
        }
    }

}