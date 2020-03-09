using Android.Content;
using Android.OS;

namespace Tangent.Controls.Android.WebViewAuth
{
    public class RendererInitializar
    {
        public static void Init(Context context, Bundle bundle)
        {
            Renderers.EnhancedWebViewRenderer.Init();
        }
    }
}