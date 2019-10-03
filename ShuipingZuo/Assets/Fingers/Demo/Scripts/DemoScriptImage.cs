//
// Fingers Gestures
// (c) 2015 Digital Ruby, LLC
// http://www.digitalruby.com
// Source code may be used for personal or commercial projects.
// Source code may NOT be redistributed or sold.
// 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DigitalRubyShared
{
    public class DemoScriptImage : MonoBehaviour
    {
        public FingersImageGestureHelperComponentScript ImageScript;
        public ParticleSystem MatchParticleSystem;
        public AudioSource AudioSourceOnMatch;
        Touch touch1 = new Touch();
        private int ismove = 0;

        private void LinesUpdated(object sender, System.EventArgs args)
        {
            Debug.LogFormat("Lines updated, new point: {0},{1}", ImageScript.Gesture.FocusX, ImageScript.Gesture.FocusY);
        }

        private void LinesCleared(object sender, System.EventArgs args)
        {
            Debug.LogFormat("Lines cleared!");
        }

        private void Start()
        {
            ImageScript.LinesUpdated += LinesUpdated;
            ImageScript.LinesCleared += LinesCleared;
            touch1.phase = 0;
        }

        private  void Update()
        {
            if (Input.touchCount > 0)
            {
                touch1 = Input.touches[0];

            }
            if (touch1.phase.ToString() == TouchPhase.Moved.ToString())
            {
                ismove ++;
            }
        }

        private void LateUpdate()
        {
            
            if (Input.touchCount > 0)
            {
                touch1 = Input.touches[0];

            }
            

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                ImageScript.Reset();
            }
            else if (ismove > 5 && (Input.GetMouseButtonUp(0) || touch1.phase.ToString() == TouchPhase.Ended.ToString()))
            {
                Debug.Log("ismove:" + ismove);
                ImageGestureImage match = ImageScript.CheckForImageMatch();
                if (match != null)
                {
                    Debug.Log("Found image match: " + match.Name);
                    MatchParticleSystem.Play();
                    AudioSourceOnMatch.Play();
                }
                else
                {
                    Debug.Log("No match found!");
                }
                ismove = 0;
                
                ImageScript.Reset();
                // TODO: Do something with the match
                // You could get a texture from it:
                // Texture2D texture = FingersImageAutomationScript.CreateTextureFromImageGestureImage(match);
            }
        }
    }
}
