﻿using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using web = global::Android;

namespace Tangent.Controls.WebViewAuthExample.Droid
{
    [Activity(Label = "Tangent.Controls.WebViewAuthExample", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            Tangent.Controls.Android.WebViewAuth.RendererInitializar.Init(this, savedInstanceState);
            LoadApplication(new App());
        }
    }
}