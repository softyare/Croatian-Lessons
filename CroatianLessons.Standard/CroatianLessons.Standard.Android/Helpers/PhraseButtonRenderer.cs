using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using CroatianLessons.Standard.Droid.Helpers;
using CroatianLessons.Standard.Helpers.Custom;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(PhraseButton), typeof(PhraseButtonRenderer))]
namespace CroatianLessons.Standard.Droid.Helpers
{
    public class PhraseButtonRenderer : ButtonRenderer
    {
        public PhraseButtonRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.SetAllCaps(false);
                Control.SetBackgroundColor(Android.Graphics.Color.Transparent);
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
        }
    }
}