using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace BobaTea {

    public class Timer : MonoBehaviour
    {
        public GameController GameController;
        public PostProcessVolume PostProcessVolume; 

        [Tooltip("Number of seconds it takes a day to complete.")]
        public float TimeScale = 60.0f;
        [Tooltip("Time of day (in hours) for the game to start at.")]
        public float StartTime = 12.0f;
        
        private DayCycleSettings _dayCycleSettings;

        private const float _maxTime = 24.0f;

        private float _timeReal;
        private bool _runTimer;
        
        public float TimeHours {
            get { return (_timeReal / TimeScale) * _maxTime; }
        }

        void Awake()
        {
            GameController.GameStart += HandleGameStart;
            GameController.GamePause += HandleGamePause;
            GameController.GameEnd += HandleGameEnd;

            PostProcessProfile profile = PostProcessVolume.sharedProfile;
            _dayCycleSettings = profile.GetSetting<DayCycleSettings>();
        }

        void Update()
        {
            if(!_runTimer) {
                return;
            }

            _timeReal += Time.deltaTime;
            //Debug.Log("time, seconds: " + _timeReal);
            //Debug.Log("time, in-game hours: " + TimeHours);

            // I wish the pp effect could query the timer, but whatever
            _dayCycleSettings.time.Override(new FloatParameter{value = TimeHours});

            if(TimeHours > _maxTime) {
                _timeReal = 0.0f;
                //Debug.Log("new day");
            }
        }

        private void HandleGameStart() {
            _timeReal = StartTime / TimeScale;
            _runTimer = true;
        }

        private void HandleGamePause () {
            _runTimer = false;
        }

        private void HandleGameEnd () {
            _runTimer = false;
        }

        private void RestartTimer () {
            _timeReal = 0.0f;
        }

    }

}
