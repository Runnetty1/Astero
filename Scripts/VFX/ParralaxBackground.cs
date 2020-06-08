using UnityEngine;
namespace Assets.Scripts.VFX
{
    public class ParralaxBackground : MonoBehaviour
    {
        public GameObject camera;
        public float parralax = 2f;
        public float size = 10;
        public float minSize;
        public float maxSize;
        public Vector2 tiling;

        public bool scaleBG;

        private void Start()
        {
            
        }

        private void Update()
        {
            MeshRenderer mr = GetComponent<MeshRenderer>();
            Material mat = mr.material;
            Vector2 offset = mat.mainTextureOffset;
            Vector2 scale = new Vector2(camera.GetComponent<Camera>().orthographicSize, camera.GetComponent<Camera>().orthographicSize);
            float orto = camera.GetComponent<Camera>().orthographicSize;
            offset.y = (camera.transform.position.y / parralax);
            offset.x = (camera.transform.position.x / parralax);

            mat.mainTextureOffset = offset;

            if (scaleBG == false)
            {
                scale.y = Mathf.Clamp((camera.GetComponent<Camera>().scaledPixelHeight + orto) * (size* orto), minSize, maxSize);
                scale.x = Mathf.Clamp((camera.GetComponent<Camera>().scaledPixelWidth+ orto) *(size* orto),minSize,maxSize);
                this.transform.localScale = scale;
                //mat.mainTextureScale = ;
            }
            
            //Fade while standing still


        }
    }
}
