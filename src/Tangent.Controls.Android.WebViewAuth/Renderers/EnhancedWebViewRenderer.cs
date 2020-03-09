using Android.Content;
using System.Collections.Generic;
using Tangent.Controls.Android.WebViewAuth.Renderers;
using Tangent.Controls.WebViewAuth;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using web = global::Android;

[assembly: ExportRenderer(typeof(EnhancedWebView), typeof(EnhancedWebViewRenderer))]

namespace Tangent.Controls.Android.WebViewAuth.Renderers
{
    public class EnhancedWebViewRenderer : ViewRenderer<EnhancedWebView, web.Webkit.WebView>
    {
        private web.Content.Context _localContext;

        public EnhancedWebViewRenderer(Context context) : base(context)
        {
            _localContext = context;
        }

        public static void Init()
        {
            EnhancedWebViewRenderer.Init();
        }

        protected override void OnElementChanged(ElementChangedEventArgs<EnhancedWebView> e)
        {
            base.OnElementChanged(e);

            web.Webkit.WebView webView = Control as web.Webkit.WebView;

            if (Control == null)
            {
                webView = new web.Webkit.WebView(_localContext);
                SetNativeControl(webView);
            }

            if (e.OldElement != null)
            {
                // ...
            }

            if (e.NewElement != null)
            {
                Dictionary<string, string> headers = Element.CustomHeaders;
                webView.Settings.JavaScriptEnabled = true;
                webView.Settings.BuiltInZoomControls = false;
                webView.Settings.SetSupportZoom(true);
                EnhancedWebViewClient webViewClient = new EnhancedWebViewClient();
                webViewClient.Username = Element.Username;
                webViewClient.Password = Element.Password;
                webViewClient.Headers = headers;
                webView.SetWebViewClient(webViewClient);
                if (Element.Source != null)
                {
                    if (Element.Source.GetType() == typeof(UrlWebViewSource))
                    {
                        UrlWebViewSource source = Element.Source as UrlWebViewSource;
                        webView.LoadUrl(source.Url, headers);
                    }
                }
            }
        }
    }
}