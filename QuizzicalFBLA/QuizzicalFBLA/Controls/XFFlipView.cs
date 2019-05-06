﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace QuizzicalFBLA.Controls
{
    /// <summary>
    /// Flip View Animation Control built with pure Xamarin.Forms 
    /// </summary>
    public class XFFlipView : ContentView
    {
        private readonly RelativeLayout _contentHolder;

        public XFFlipView()
        {
            _contentHolder = new RelativeLayout();
            Content = _contentHolder;
        }

        public static readonly BindableProperty FrontViewProperty =
        BindableProperty.Create(
            nameof(FrontView),
            typeof(View),
            typeof(XFFlipView),
            null,
            BindingMode.Default,
            null,
            FrontViewPropertyChanged);

        private static void FrontViewPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                ((XFFlipView)bindable)
                    ._contentHolder
                    .Children
                    .Add(((XFFlipView)bindable).FrontView,
                        Constraint.Constant(0),
                        Constraint.Constant(0),
                        Constraint.RelativeToParent((parent) => parent.Width),
                        Constraint.RelativeToParent((parent) => parent.Height)
                    );
            }
        }

        /// <summary>
        /// Gets or Sets the front view
        /// </summary>
        public View FrontView
        {
            get { return (View)this.GetValue(FrontViewProperty); }
            set { this.SetValue(FrontViewProperty, value); }
        }



        public static readonly BindableProperty BackViewProperty =
        BindableProperty.Create(
            nameof(BackView),
            typeof(View),
            typeof(XFFlipView),
            null,
            BindingMode.Default,
            null,
            BackViewPropertyChanged);

        private static void BackViewPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            //Set BackView Rotation before rotating
            if (newvalue != null)
            {
                ((XFFlipView)bindable)
                    ._contentHolder
                    .Children
                    .Add(((XFFlipView)bindable).BackView,
                        Constraint.Constant(0),
                        Constraint.Constant(0),
                        Constraint.RelativeToParent((parent) => parent.Width),
                        Constraint.RelativeToParent((parent) => parent.Height)
                     );

                ((XFFlipView)bindable).BackView.IsVisible = false;
            }
        }

        /// <summary>
        /// Gets or Sets the back view
        /// </summary>
        public View BackView
        {
            get { return (View)this.GetValue(BackViewProperty); }
            set { this.SetValue(BackViewProperty, value); }
        }



        public static readonly BindableProperty IsFlippedProperty =
        BindableProperty.Create(
            nameof(IsFlipped),
            typeof(bool),
            typeof(XFFlipView),
            false,
            BindingMode.Default,
            null,
            IsFlippedPropertyChanged);

        public bool Animate { get; set; } = true;

        /// <summary>
        /// Gets or Sets whether the view is already flipped
        /// ex : 
        /// </summary>
        public bool IsFlipped
        {
            get { return (bool)this.GetValue(IsFlippedProperty); }
            set { this.SetValue(IsFlippedProperty, value); }
        }

        private static void IsFlippedPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            XFFlipView view = ((XFFlipView)bindable);
            bool val = (bool)newValue;

            if (!view.Animate)
            {
                // Change the visible content
                view.FrontView.IsVisible = !val;
                view.BackView.IsVisible = val;
                return;
            }

            if (val)
            {
                view.FlipFromFrontToBack();
            }
            else
            {
                view.FlipFromBackToFront();
            }
        }

        /// <summary>
        /// Performs the flip
        /// </summary>
        private async void FlipFromFrontToBack()
        {
            await FrontToBackRotate();

            // Change the visible content
            this.FrontView.IsVisible = false;
            this.BackView.IsVisible = true;

            await BackToFrontRotate();
        }

        /// <summary>
        /// Performs the flip
        /// </summary>
        private async void FlipFromBackToFront()
        {
            await FrontToBackRotate();

            // Change the visible content
            this.BackView.IsVisible = false;
            this.FrontView.IsVisible = true;

            await BackToFrontRotate();
        }

        #region Animation Stuff

        private async Task<bool> FrontToBackRotate()
        {
            ViewExtensions.CancelAnimations(this);

            this.RotationY = 360;

            await this.RotateYTo(270, 125, Easing.Linear);

            return true;
        }

        private async Task<bool> BackToFrontRotate()
        {
            ViewExtensions.CancelAnimations(this);

            this.RotationY = 90;

            await this.RotateYTo(0, 125, Easing.Linear);

            return true;
        }

        #endregion
    }
}
