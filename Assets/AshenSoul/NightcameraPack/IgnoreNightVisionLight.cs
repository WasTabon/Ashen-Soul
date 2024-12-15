using UnityEngine;
using UnityEngine.Rendering;

namespace AshenSoul.Scripts.Items.NightCamera
{
    public class IgnoreNightVisionLight : MonoBehaviour
    {
         [SerializeField] private Camera _camera;
                    [SerializeField] private Light _light;
                    
                    void OnEnable()
                    {
                        RenderPipelineManager.beginCameraRendering += OnBeginCameraRendering;
                        RenderPipelineManager.endCameraRendering += OnEndCameraRendering;
                    }
                    
                    void OnDisable()
                    {
                        RenderPipelineManager.beginCameraRendering -= OnBeginCameraRendering;
                        RenderPipelineManager.endCameraRendering -= OnEndCameraRendering;
                    }
                    
                    void OnBeginCameraRendering(ScriptableRenderContext context, Camera cam)
                    {
                        if (cam == _camera)
                        {
                            _light.enabled = false;
                        }
                    }
                    
                    void OnEndCameraRendering(ScriptableRenderContext context, Camera cam)
                    {
                        if (cam == _camera)
                        {
                            _light.enabled = true;
                        }
                    }
    }
}
