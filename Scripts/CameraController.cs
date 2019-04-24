using UnityEngine;
using System.Collections;
using RRG.InputHandling.player;

namespace Assets.Scripts
{
	/* ----------------------
	 * - Copyright of Road Roach Games
	 * - 
	 * ----------------------
	 * 
	 * Author: Mats Harwiss
	 * @ RRG
	 * 
	 * 
	 * 
	 * A smooth camera following script for 2D
	 * Slap this script onto a camera and change
	 * the smoothing time to whatever feels right
	 */

    public class CameraController : MonoBehaviour
    {
        #region Fields
		// The target to follow
        public Transform _target;

		// Change SmoothTime to alter camera following speed.
		// The higher the number the slower the following speed.
		public float _SmoothTime = 0.05f;

		// A Offset form target position
		public Vector3 _offset;
        public bool shakeCamera;
        public Vector2 shakeAmount;
        //time between each shake extreme;
        public float shakeTime;
        private Vector3 _velocity = Vector3.zero;
        private bool needsNewPos=true;

        public float _min = 20f;
        public float _max = 100f;
        public float _ZoomAmount = 1f;
        public float _distance = 20f;
        public float _smoothing = 20f;
        #endregion

        #region Methods

        // Must be fixedUpdate else the camera will look like its stuttering.
        private void FixedUpdate()
        {
            this.GetComponent<Camera>().orthographicSize = Mathf.Lerp(this.GetComponent<Camera>().orthographicSize, _distance, Time.smoothDeltaTime * _smoothing);
            if (shakeCamera && needsNewPos)
            {
                needsNewPos = false;
                //new shakepos
                float x =Mathf.Lerp(Random.Range(-shakeAmount.x, shakeAmount.x), _offset.x, Time.smoothDeltaTime * _SmoothTime);
                float y =Mathf.Lerp(Random.Range(-shakeAmount.y, shakeAmount.y), _offset.y, Time.smoothDeltaTime * _SmoothTime);
                _offset = new Vector3(x, y) ;
                //cooldoqwnthis
                StartCoroutine(ShakeCooldown());
            }
			// Get target pos.
			Vector3 destination = this.transform.position + _offset;

            if (this._target != null)
            {
				// Set Delta Position for the Camera
                Vector3 point = this.GetComponent<Camera>().WorldToViewportPoint(this._target.position);
                Vector3 delta = this._target.position - this.GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z));
                destination += delta;
			}else{
				//Find Player and set as target
				this._target = (Transform) GameObject.Find("player").transform;
			}
			// Set Camera position
            this.transform.position = Vector3.SmoothDamp(
                this.transform.position,
                destination,
                ref this._velocity,
                this._SmoothTime);
        }

        IEnumerator ShakeCooldown ()
        {
            yield return new WaitForSeconds(shakeTime);
            needsNewPos = true;
        }


        private void OnEnable()
        {
            InputController.OnScrollEvent += ScrollEvent;
        }

        void ScrollEvent(InputController.ScrollDirection dir)
        {
            if (dir == InputController.ScrollDirection.UP)
            {
                _distance += _max/_ZoomAmount;
                _distance = Mathf.Clamp(_distance, _min, _max);

            }
            else
            {
                _distance -= _max / _ZoomAmount;
                _distance = Mathf.Clamp(_distance, _min, _max);
            }
            
        }
        #endregion
    }
}