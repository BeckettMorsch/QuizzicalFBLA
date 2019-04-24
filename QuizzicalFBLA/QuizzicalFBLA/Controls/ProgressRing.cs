using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace QuizzicalFBLA.Controls
{
    public class ProgressRing : SKCanvasView, IAnimatable
    {
        #region Properties

        public static readonly BindableProperty HideNumberProperty = BindableProperty.Create("HideNumber", typeof(bool), typeof(ProgressRing), false);

        public bool HideNumber
        {
            get { return (bool)GetValue(HideNumberProperty); }
            set
            {
                SetValue(HideNumberProperty, value); InvalidateSurface();
            }
        }

        // Source: https://www.jimbobbennett.io/animating-xamarin-forms-progress-bars/
        /// <summary>
        /// Let's you animate from the current progress to a new progress using
        /// the values of the properties AnimationLength and AnimationEasing.
        /// </summary>
        public static readonly BindableProperty AnimatedProgressProperty = BindableProperty.Create("AnimatedProgress", typeof(double),
                                                                                                   typeof(ProgressRing), 0.0,
                                                                                                   propertyChanged: HandleAnimatedProgressChanged);
        public double AnimatedProgress
        {
            get { return (double)base.GetValue(AnimatedProgressProperty); }
            set
            {
                base.SetValue(AnimatedProgressProperty, value);

                StartProgressToAnimation();
            }
        }

        /// <summary>
        /// Set's the animation length that is used when using the AnimatedProgress
        /// property to animate to a certain progress.
        /// </summary>
        public static readonly BindableProperty AnimationLengthProperty = BindableProperty.Create("AnimationLength", typeof(uint),
                                                                                                  typeof(ProgressRing), (uint)800,
                                                                                                  propertyChanged: HandleAnimationLengthChanged);
        public uint AnimationLength
        {
            get { return (uint)base.GetValue(AnimationLengthProperty); }
            set { base.SetValue(AnimationLengthProperty, value); }
        }

        /// <summary>
        /// Set's the easing function that is used when using the AnimatedProgress
        /// property to animate to a certain progress.
        /// </summary>
        public static readonly BindableProperty AnimationEasingProperty = BindableProperty.Create("AnimationEasing", typeof(uint),
                                                                                                  typeof(ProgressRing), (uint)0,
                                                                                                  propertyChanged: HandleAnimationEasingChanged);

        public Easing AnimationEasing
        {
            get
            {
                var intValue = (uint)base.GetValue(AnimationEasingProperty);
                var easingMethod = ProgressRingUtils.IntToEasingMethod((int)intValue);

                return easingMethod;
            }
            set
            {
                var easingMethod = ProgressRingUtils.EasingMethodToInt(value);

                base.SetValue(AnimationEasingProperty, easingMethod);
            }
        }

        /// <summary>
        /// Sets the ring's progress color. 
        /// HINT: The ring progress color covers the ring base color
        /// </summary>
        public static readonly BindableProperty RingProgressStartColorProperty = BindableProperty.Create("RingProgressStartColor", typeof(Color),
                                                                                                    typeof(ProgressRing), Color.FromRgb(234, 105, 92));
        public Color RingProgressStartColor
        {
            get { return (Color)base.GetValue(RingProgressStartColorProperty); }
            set { base.SetValue(RingProgressStartColorProperty, value); InvalidateSurface(); }
        }

        /// <summary>
        /// Sets the ring's progress color. 
        /// HINT: The ring progress color covers the ring base color
        /// </summary>
        public static readonly BindableProperty RingProgressEndColorProperty = BindableProperty.Create("RingProgressEndColor", typeof(Color),
                                                                                                    typeof(ProgressRing), Color.FromRgb(234, 105, 92));
        public Color RingProgressEndColor
        {
            get { return (Color)base.GetValue(RingProgressEndColorProperty); }
            set { base.SetValue(RingProgressEndColorProperty, value); InvalidateSurface(); }
        }


        /// <summary>
        /// Sets the ring's base (background) color.
        /// </summary>
        public static readonly BindableProperty RingBaseColorProperty = BindableProperty.Create("RingBaseColor", typeof(Color),
                                                                                                typeof(ProgressRing), Color.FromRgb(46, 60, 76));
        public Color RingBaseColor
        {
            get { return (Color)base.GetValue(RingBaseColorProperty); }
            set { base.SetValue(RingBaseColorProperty, value); InvalidateSurface(); }
        }

        /// <summary>
        /// Sets the ring's center background color.
        /// </summary>
        public static readonly BindableProperty RingBackgroundColorProperty = BindableProperty.Create("RingBackgroundColor", typeof(Color),
                                                                                                typeof(ProgressRing), Color.FromRgb(0,0,0));
        public Color RingBackgroundColor
        {
            get { return (Color)base.GetValue(RingBackgroundColorProperty); }
            set { base.SetValue(RingBackgroundColorProperty, value); InvalidateSurface(); }
        }

        /// <summary>
        /// Sets the thickness of the progress Ring. The thickness "grows" into the
        /// center of the ring (so the outer dimensions are not incluenced by the
        /// ring thickess.
        /// </summary>
        public static readonly BindableProperty RingThicknessProperty = BindableProperty.Create("RingThickness", typeof(double),
                                                                                                typeof(ProgressRing), 5.0);
        public double RingThickness
        {
            get { return (double)base.GetValue(RingThicknessProperty); }
            set { base.SetValue(RingThicknessProperty, value); InvalidateSurface(); }
        }

        #endregion

        #region Animation

        public static readonly BindableProperty ProgressProperty = BindableProperty.Create(nameof(Progress), typeof(double), typeof(ProgressRing), 0d, coerceValue: (bo, v) => ((double)v).Clamp(0, 1));

        public double Progress
        {
            get { return (double)GetValue(ProgressProperty); }
            set {
                SetValue(ProgressProperty, value);
                InvalidateSurface();

                if (OnProgressChanged != null)
                {
                    OnProgressChanged(this, new EventArgs());
                }
            }
        }

        public Task<bool> StartProgressToAnimation()
        {
            var length = base.GetValue(AnimationLengthProperty);
            Progress = 0;
            
            //ProgressTo(AnimatedProgress, AnimationLength, AnimationEasing);
            
            var tcs = new TaskCompletionSource<bool>();

            this.Animate("Progress", d => Progress = d, 
                                     Progress, 
                                     AnimatedProgress, 
                                     length: AnimationLength, 
                                     easing: AnimationEasing, 
                                     finished: (d, finished) => {
                                         tcs.SetResult(finished);
                                         if (OnAnimationCompleted != null)
                                             OnAnimationCompleted(this, new EventArgs());
                                     });
            
            return tcs.Task;

        }

        public void StopAnimation ()
        {
            this.AbortAnimation("Progress");

            if (OnAnimationCompleted != null)
                OnAnimationCompleted(this, new EventArgs());
        }

        public EventHandler OnAnimationCompleted;
        public EventHandler OnProgressChanged;


        #endregion

        #region static handlers

        static void HandleAnimatedProgressChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var progress = (ProgressRing)bindable;
            progress.AnimatedProgress = (double)newValue;
        }

        static void HandleAnimationLengthChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var progressRing = (ProgressRing)bindable;

            var animationIsRunning = progressRing.AnimationIsRunning("Progress");

            // If the progress animation is already running
            // rerun it with the new length value.
            if (animationIsRunning)
                progressRing.StartProgressToAnimation();
        }

        static void HandleAnimationEasingChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var progressRing = (ProgressRing)bindable;
            var animationIsRunning = progressRing.AnimationIsRunning("Progress");

            // If the progress animation is already running
            // rerun it with the new length value.
            if (animationIsRunning)
                progressRing.StartProgressToAnimation();
        }



        #endregion

        /*
        public static Color LerpHSV(Color ar, Color br, float t)
        {
            ColorHSV a = ColorHSV.FromRgb(ar);
            ColorHSV b = ColorHSV.FromRgb(br);

            // Hue interpolation
            double h;
            double d = b.H - a.H;
            if (a.H > b.H)
            {
                // Swap (a.h, b.h)
                var h3 = b.H;
                b.H = a.H;
                a.H = h3;

                d = -d;
                t = 1 - t;
            }

            if (d > 0.5) // 180deg
            {
                a.H = a.H + 1; // 360deg
                h = (a.H + t * (b.H - a.H)) % 1; // 360deg
            }
            if (d <= 0.5) // 180deg
            {
                h = a.H + t * d;
            }

            // Interpolates the rest
            return new ColorHSV
            (
            h, // H
            a.S + t * (b.S - a.S), // S
            a.V + t * (b.V - a.V) // V            
            );
        }
        */
        private Color Interpolate(Color source, Color target, double percent)
        {
            var r = (source.R + (target.R - source.R) * percent);
            var g = (source.G + (target.G - source.G) * percent);
            var b = (source.B + (target.B - source.B) * percent);

            return Color.FromRgba(r, g, b, 1.0).WithLuminosity(0.6);
        }

        protected override void OnPaintSurface(SKPaintSurfaceEventArgs e)
        {
            base.OnPaintSurface(e);

            SKImageInfo info = e.Info;
            SKSurface surface = e.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear(Color.Transparent.ToSKColor());

            SKPaint paint = new SKPaint
            {
                Style = SKPaintStyle.Fill,
                TextSize = 48,
                StrokeWidth = (float)RingThickness,
                IsAntialias = true
            };

            // RingBaseColor, RingProgressColor

            var circleRadius = (float)Math.Min(info.Width - RingThickness, info.Height - RingThickness) / 2;
            var circleMiddle = circleRadius + (float)RingThickness / 2;
            paint.Color = RingBackgroundColor.ToSKColor();
            canvas.DrawCircle(circleMiddle, circleMiddle, circleRadius, paint);

            paint.Style = SKPaintStyle.Stroke;
            paint.Color = RingBaseColor.ToSKColor();
            paint.StrokeWidth = (float)RingThickness;

            SKRect rect = new SKRect((float)RingThickness, (float)RingThickness, circleRadius*2, circleRadius*2);
            float startAngle = -90f, sweepAngle = (float)Progress*360;

            using (SKPath path = new SKPath())
            {
                path.AddArc(rect, startAngle, 360);
                canvas.DrawPath(path, paint);
            }

            //canvas.DrawCircle(circleMiddle, circleMiddle, circleRadius, paint);

            paint.Color = Interpolate(RingProgressStartColor, RingProgressEndColor, Progress).ToSKColor();

            using (SKPath path = new SKPath())
            {
                path.AddArc(rect, startAngle, sweepAngle);
                canvas.DrawPath(path, paint);
            }

            string num = (int)Math.Ceiling(AnimationLength / 1000.0 - Progress * (AnimationLength / 1000.0)) + "";

            if (!HideNumber)
            {
                var textPaint = new SKPaint
                {
                    IsAntialias = true,
                    Style = SKPaintStyle.Fill,
                    Color = SKColors.White,
                    TextSize = circleRadius * 1.2f,
                    FakeBoldText = true
                };


                //float textWidth = textPaint.MeasureText(num);
                //textPaint.TextSize = circleRadius * textPaint.TextSize / textWidth;

                SKRect textBounds = new SKRect();
                textPaint.MeasureText(num, ref textBounds);

                float xText = circleMiddle - textBounds.MidX;
                float yText = circleMiddle - textBounds.MidY;

                textPaint.Style = SKPaintStyle.Stroke;
                textPaint.Shader = null;
                textPaint.Color = SKColors.Black;
                textPaint.StrokeWidth = 3f;
                textPaint.IsStroke = true;
                textPaint.IsAntialias = true;

                canvas.DrawText(num, xText, yText, textPaint);

                textPaint.Style = SKPaintStyle.Fill;
                textPaint.Shader = SKShader.CreateLinearGradient(new SKPoint(0, 0),
                                                                         new SKPoint(0, circleRadius * 2),
                                                                         new SKColor[] { SKColors.White, SKColors.LightGray },
                                                                         null,
                                                                         SKShaderTileMode.Clamp);

                canvas.DrawText(num, xText, yText, textPaint);

                if (num != "0")
                {
                    paint.Shader = SKShader.CreateRadialGradient(
                                        new SKPoint((float)(circleMiddle - circleRadius * Math.Cos((sweepAngle + 90) * Math.PI / 180)),
                                                    (float)(circleMiddle - circleRadius * Math.Sin((sweepAngle + 90) * Math.PI / 180))),
                                        circleRadius / 2,
                                        new SKColor[] { SKColors.White, SKColors.Transparent },
                                        null,
                                        SKShaderTileMode.Clamp);

                    paint.BlendMode = SKBlendMode.Lighten;
                    paint.Style = SKPaintStyle.Fill;
                    paint.Color = RingBackgroundColor.ToSKColor();
                    canvas.DrawCircle(circleMiddle, circleMiddle, circleRadius, paint);
                }

            }
        }
    }
}
