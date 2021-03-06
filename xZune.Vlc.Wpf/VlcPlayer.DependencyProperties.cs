﻿//Project: xZune.Vlc (https://github.com/higankanshi/xZune.Vlc)
//Filename: VlcPlayer.DependencyProperties.cs
//Version: 20151220

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Windows.Media;

namespace xZune.Vlc.Wpf
{
    public partial class VlcPlayer
    {
        #region LibVlcPath

        /// <summary>
        /// The path of LibVlc, it is a DependencyProperty.
        /// </summary>
        public String LibVlcPath
        {
            get { return (String)GetValue(LibVlcPathProperty); }
            set { SetValue(LibVlcPathProperty, value); }
        }

        public static readonly DependencyProperty LibVlcPathProperty =
          DependencyProperty.Register("LibVlcPath", typeof(String), typeof(VlcPlayer), null);

        #endregion LibVlcPath

        #region VlcOption

        /// <summary>
        /// The options of LibVlc, it is a DependencyProperty.
        /// </summary>
        public String[] VlcOption
        {
            get { return (String[])GetValue(VlcOptionProperty); }
            set { SetValue(VlcOptionProperty, value); }
        }

        public static readonly DependencyProperty VlcOptionProperty =
          DependencyProperty.Register("VlcOption", typeof(String[]), typeof(VlcPlayer), null);

        #endregion VlcOption

        #region ScaleTransform

        internal static readonly DependencyProperty ScaleTransformProperty =
          DependencyProperty.Register("ScaleTransform", typeof(ScaleTransform), typeof(VlcPlayer),
            new PropertyMetadata(default(ScaleTransform)));

        internal ScaleTransform ScaleTransform
        {
            get { return (ScaleTransform)GetValue(ScaleTransformProperty); }
            set { SetValue(ScaleTransformProperty, value); }
        }

        #endregion ScaleTransform

        #region AspectRatio

        public static readonly DependencyProperty PropertyTypeProperty =
          DependencyProperty.Register("PropertyType", typeof(AspectRatio), typeof(VlcPlayer),
            new PropertyMetadata(AspectRatio.Default, OnAspectRatioChanged));

        /// <summary>
        /// The aspect ratio of video, it is a DependencyProperty.
        /// </summary>
        public AspectRatio AspectRatio
        {
            get { return (AspectRatio)GetValue(PropertyTypeProperty); }
            set { SetValue(PropertyTypeProperty, value); }
        }

        private static void OnAspectRatioChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var vlcPlayer = sender as VlcPlayer;

            var scale = vlcPlayer.GetScaleTransform();
            vlcPlayer.ScaleTransform = new ScaleTransform(scale.Width, scale.Height);
        }

        #endregion AspectRatio

        #region VideoSource

        /// <summary>
        /// The image data of video, it is a DependencyProperty.
        /// </summary>
        public InteropBitmap VideoSource
        {
            get { return (InteropBitmap)GetValue(VideoSourceProperty); }
            private set { SetValue(VideoSourceProperty, value); }
        }

        public static readonly DependencyProperty VideoSourceProperty =
            DependencyProperty.Register("VideoSource", typeof(InteropBitmap), typeof(VlcPlayer), null);

        #endregion VideoSource

        #region Stretch

        /// <summary>
        /// The stretch mode of video.
        /// </summary>
        public Stretch Stretch
        {
            get { return (Stretch)GetValue(StretchProperty); }
            set { SetValue(StretchProperty, value); }
        }

        public static readonly DependencyProperty StretchProperty =
            DependencyProperty.Register("Stretch", typeof(Stretch), typeof(VlcPlayer), new PropertyMetadata(Stretch.Uniform));

        /// <summary>
        /// The stretch direction of video.
        /// </summary>
        public StretchDirection StretchDirection
        {
            get { return (StretchDirection)GetValue(StretchDirectionProperty); }
            set { SetValue(StretchDirectionProperty, value); }
        }

        public static readonly DependencyProperty StretchDirectionProperty =
            DependencyProperty.Register("StretchDirection", typeof(StretchDirection), typeof(VlcPlayer),
              new PropertyMetadata(StretchDirection.Both));

        #endregion Stretch

        #region EndBehavior

        public static readonly DependencyProperty EndBehaviorProperty = DependencyProperty.Register(
            "EndBehavior", typeof(EndBehavior), typeof(VlcPlayer), new PropertyMetadata(EndBehavior.Default));

        public EndBehavior EndBehavior
        {
            get { return (EndBehavior)GetValue(EndBehaviorProperty); }
            set { SetValue(EndBehaviorProperty, value); }
        }

        #endregion EndBehavior
    }
}