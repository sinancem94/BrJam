using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RewindEngine
{
    [RequireComponent(typeof(Timeline))]
    public abstract class Rewindable : MonoBehaviour
    {
        public Timeline time
        {
            get { return GetComponent<Timeline>(); }
        }

        public Clock clock
        {
            get { return GetComponent<Clock>(); }
        }

        protected enum State
        {
            Rewinding,
            GoindNormal,
            Normal
        }

        protected State rewindState = State.Normal;

        protected virtual void Update()
        {
            if (rewindState == State.Rewinding)
            {
                if (lastHittedTime < Time.time - 0.5f)
                    rewindState = State.GoindNormal;
            }
            else if (rewindState == State.GoindNormal)
            {
                if (clock.localTimeScale < 1f)
                    clock.localTimeScale += 0.05f;
                else
                {
                    clock.localTimeScale = 1f;
                    rewindState = State.Normal;
                }
            }
        }

        private float lastHittedTime = 0f;
        
        public void GetHit(float ratio)
        {
            if (rewindState != State.Rewinding)
                rewindState = State.Rewinding;
            
            //Debug.Log("hitted");
            
            if (clock.localTimeScale - ratio >= -1f)
            {
                clock.localTimeScale -= ratio;
            }

            lastHittedTime = Time.time;
        }
    }
}
