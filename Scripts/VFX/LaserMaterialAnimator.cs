using UnityEngine;


namespace Assets.Scripts.VFX
{
    public class LaserMaterialAnimator:MonoBehaviour
    {
        public LineRenderer renderer;
        public float scrollSpeed=0.5f;
        public float maxLaserSize = 2.2f;
        public float minLaserSize=0.1f;

        private void LateUpdate()
        {
            float offset = Time.time * scrollSpeed;
            renderer.material.SetTextureOffset("_MainTex", new Vector2(-offset, 0));
            renderer.startWidth  = Random.Range(minLaserSize,maxLaserSize);
            renderer.endWidth = Random.Range(minLaserSize, maxLaserSize/2);
        }

    }
}
