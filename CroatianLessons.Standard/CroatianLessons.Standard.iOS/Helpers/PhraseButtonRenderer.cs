using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CroatianLessons.Standard.Helpers.Custom;
using CroatianLessons.Standard.iOS.Helpers;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(PhraseButton), typeof(PhraseButtonRenderer))]
namespace CroatianLessons.Standard.iOS.Helpers
{
    class PhraseButtonRenderer : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.TitleLabel.LineBreakMode = UILineBreakMode.WordWrap;
                Control.TitleLabel.Lines = 0;
                Control.TitleLabel.TextAlignment = UITextAlignment.Center;
            }
        }
    }

}