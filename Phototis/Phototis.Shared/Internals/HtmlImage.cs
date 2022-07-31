﻿using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using System;
using System.Collections.Generic;
using System.Text;
using Uno.Foundation;
using Uno.UI.Runtime.WebAssembly;

namespace Phototis
{
    [HtmlElement("img")]
    public sealed class HtmlImage : FrameworkElement
    {
        private double grayscale = 0;
        private double contrast = 100;
        private double brightness = 100;
        private double saturation = 100;
        private double sepia = 0;
        private double invert = 0;
        private double hue_rotate = 0;
        private double blur = 0;

        public HtmlImage()
        {
            this.SetCssStyle("border-radius", "25px");            
        }

        public string Source
        {
            get => (string)GetValue(SourceProperty);
            set => SetValue(SourceProperty, value);
        }

        public static readonly DependencyProperty SourceProperty = DependencyProperty.Register(
           "Source", typeof(string), typeof(HtmlImage), new PropertyMetadata(default(string), OnSourceChanged));

        private static void OnSourceChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
        {
            if (dependencyObject is HtmlImage image)
            {
                var encodedSource = WebAssemblyRuntime.EscapeJs("" + args.NewValue);
                image.SetHtmlAttribute("src", encodedSource);
                image.SetCssStyle(("object-fit", "contain"), ("border-radius", "25px"));
            }
        }

        public new string Height
        {
            get => (string)GetValue(HeightProperty);
            set => SetValue(HeightProperty, value);
        }

        public static readonly new DependencyProperty HeightProperty = DependencyProperty.Register(
          "Height", typeof(string), typeof(HtmlImage), new PropertyMetadata(default(string), OnHeightChanged));

        private static void OnHeightChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
        {
            if (dependencyObject is HtmlImage image)
            {
                image.SetHtmlAttribute("height", $"{args.NewValue}");
            }
        }

        public new string Width
        {
            get => (string)GetValue(WidthProperty);
            set => SetValue(WidthProperty, value);
        }

        public static readonly new DependencyProperty WidthProperty = DependencyProperty.Register(
         "Width", typeof(string), typeof(HtmlImage), new PropertyMetadata(default(string), OnWidthChanged));

        private static void OnWidthChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
        {
            if (dependencyObject is HtmlImage image)
            {
                image.SetHtmlAttribute("width", $"{args.NewValue}");
            }
        }

        public void SetGrayScale(double value)
        {
            grayscale = value;
            SetFilter();
        }

        public void SetContrast(double value)
        {
            contrast = value;
            SetFilter();
        }

        public void SetBrightness(double value)
        {
            brightness = value;
            SetFilter();
        }

        public void SetSaturation(double value)
        {
            saturation = value;
            SetFilter();
        }

        public void SetSepia(double value)
        {
            sepia = value;
            SetFilter();
        }

        public void SetInvert(double value)
        {
            invert = value;
            SetFilter();
        }

        public void SetHueRotate(double value)
        {
            hue_rotate = value;
            SetFilter();
        }

        public void SetBlur(double value)
        {
            blur = value;
            SetFilter();
        }

        private void SetFilter()
        {
            this.SetCssStyle("filter", $"grayscale({grayscale}%) contrast({contrast}%) brightness({brightness}%) saturate({saturation}%) sepia({sepia}%) invert({invert}%) hue-rotate({hue_rotate}deg) blur({blur}px)");
        }
    }
}
