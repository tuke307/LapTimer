using LapTimer.Core.Models;
using LapTimer.Core.Services;
using LapTimer.SkiaSharp.Helpers;
using LapTimer.SkiaSharp.Images;
using LapTimer.SkiaSharp.Presentation.ViewModels.SessionMap;
using MvvmCross;
using MvvmCross.Plugin.Messenger;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using SkiaSharpnado.SkiaSharp;
using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using SKSvg = SkiaSharp.Extended.Svg.SKSvg;

namespace LapTimer.SkiaSharp.Presentation.Views.SessionMap
{
    public partial class SessionMap : ContentView
    {
        #region BindableProperties

        public static readonly BindableProperty InfoColorProperty = BindableProperty.Create(
            nameof(InfoColor),
            typeof(Color),
            typeof(SessionMap),
            defaultValue: Color.Default);

        public static readonly BindableProperty MapTypeProperty = BindableProperty.Create(
            nameof(MapType),
            typeof(MapType),
            typeof(SessionMap),
            defaultValue: MapType.Satellite);

        public static readonly BindableProperty MaxTimeProperty = BindableProperty.Create(
            nameof(MaxTime),
            typeof(TimeSpan),
            typeof(SessionMap),
            defaultValue: TimeSpan.MaxValue);

        public static readonly BindableProperty PathThicknessProperty = BindableProperty.Create(
            nameof(PathThickness),
            typeof(int),
            typeof(SessionMap),
            defaultValue: 2,
            propertyChanged: InvalidateSurface);

        public static readonly BindableProperty SessionMapInfoProperty = BindableProperty.Create(
            nameof(SessionMapInfo),
            typeof(SessionMapInfo),
            typeof(SessionMap),
            propertyChanged: SessionMapInfoChanged);

        public static readonly BindableProperty ShowCurrentPositionProperty = BindableProperty.Create(
           nameof(ShowCurrentPosition),
           typeof(bool),
           typeof(SessionMap),
           defaultValue: false,
           propertyChanged: InvalidateSurface);

        public Color InfoColor
        {
            get => (Color)GetValue(InfoColorProperty);
            set => SetValue(InfoColorProperty, value);
        }

        public MapType MapType
        {
            get => (MapType)GetValue(MapTypeProperty);
            set => SetValue(MapTypeProperty, value);
        }

        public TimeSpan MaxTime
        {
            get => (TimeSpan)GetValue(MaxTimeProperty);
            set => SetValue(MaxTimeProperty, value);
        }

        public int PathThickness
        {
            get => (int)GetValue(PathThicknessProperty);
            set => SetValue(PathThicknessProperty, value);
        }

        public SessionMapInfo SessionMapInfo
        {
            get => (SessionMapInfo)GetValue(SessionMapInfoProperty);
            set => SetValue(SessionMapInfoProperty, value);
        }

        public bool ShowCurrentPosition
        {
            get => (bool)GetValue(ShowCurrentPositionProperty);
            set => SetValue(ShowCurrentPositionProperty, value);
        }

        #endregion BindableProperties

        #region PrivateProperties

        private LatLong _bottomRightPosition;
        private LatLong _centerPosition;
        private SKMatrix _currentMatrix = SKMatrix.CreateIdentity();

        //private SKPaint _distanceTextPaint;
        private int _drawingCount = 0;

        private bool _isCameraInitialized;
        private ILocationService _locationService;
        private IMvxMessenger _messenger;
        private float _pictureSize;
        private PositionConverter _positionConverter;
        private SKPoint _previousCenter;
        private double _previousTopLeftBottomRightSquareDistance;
        private TextShapeLayer _textDistanceLayer;
        private MvxSubscriptionToken _token;

        #region Images

        private Position _currentPosition;
        private SKSvg _endImage;
        private SKColor _firstImageColor;
        private bool _forceInvalidation;
        private SKPaint _gradientPathPaint;
        private SKColor _lastImageColor;
        private SKPaint _lastMarkerPaint;
        private SKSvg _locationImage;
        private int _markerArrowSize;
        private MarkerShapeLayer _markerLayer;
        private SKPaint _markerPaint;
        private SKPicture _overlayPicture;
        private SKColor _positionImageColor = new SKColor(74, 142, 228);
        private SKSvg _startImage;

        #endregion Images

        private LatLong _topLeftPosition;

        #endregion PrivateProperties

        public SessionMap()
        {
            InitializeComponent();

            GoogleMap.CameraIdled += GoogleMapCameraChanged;
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == nameof(MaxTime))
            {
                _forceInvalidation = true;
                MapOverlay.InvalidateSurface();
            }
        }

        private static void InvalidateSurface(BindableObject bindable, object oldvalue, object newvalue)
        {
            ((SessionMap)bindable).MapOverlay.InvalidateSurface();
        }

        private static void SessionMapInfoChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            if (newvalue != null)
            {
                ((SessionMap)bindable).Initialize();
            }
        }

        //private void ApplyTransformation(SKCanvas canvas)
        //{
        //    var centerPoint = _positionConverter[_centerPosition].ToSKPoint();
        //    var topLeftPoint = _positionConverter[_topLeftPosition].ToSKPoint();
        //    var bottomRightPoint = _positionConverter[_bottomRightPosition].ToSKPoint();

        // var translation = centerPoint - _previousCenter;

        // double squaredDistance = SKPoint.DistanceSquared(topLeftPoint,
        // bottomRightPoint); double distanceRatio = squaredDistance /
        // _previousTopLeftBottomRightSquareDistance;

        // if (distanceRatio == 1 && translation == new SKPoint(0, 0)) { return; }

        // canvas.Clear(); _previousCenter = centerPoint;
        // _previousTopLeftBottomRightSquareDistance = squaredDistance;

        // var transformMatrix = SKMatrix.CreateIdentity(); transformMatrix =
        // SKMatrix.CreateScaleTranslation((float)distanceRatio, (float)distanceRatio,
        // translation.X, translation.Y);

        // SKMatrix.Concat(ref _currentMatrix, _currentMatrix, transformMatrix);

        //    canvas.SetMatrix(_currentMatrix);
        //    canvas.DrawPicture(_overlayPicture);
        //}

        //private void DrawDebugInfos(SKCanvas canvas, string toString)
        //{
        //    using (var textPaint = new SKPaint { Color = SKColor.Parse("AAFF66"), TextSize = SkiaHelper.ToPixel(12) })
        //    using (var framePaint = new SKPaint { Color = SKColors.Black })
        //    {
        //        var textBounds = new SKRect();
        //        textPaint.MeasureText(toString, ref textBounds);
        //        textBounds.Inflate(20, 20);

        // canvas.DrawRect(textBounds, framePaint);

        //        canvas.DrawText(
        //            toString,
        //            SkiaHelper.ToPixel(10),
        //            SkiaHelper.ToPixel(10),
        //            textPaint);
        //    }
        //}

        private bool DrawFirstAndLastMarker(SKCanvas canvas, ISessionDisplayablePoint firstSessionPoint, ISessionDisplayablePoint lastSessionPoint)
        {
            var firstPoint = _positionConverter[firstSessionPoint.Position].ToSKPoint();
            var lastPoint = _positionConverter[lastSessionPoint.Position].ToSKPoint();

            float svgStartMax = Math.Max(_startImage.Picture.CullRect.Width, _startImage.Picture.CullRect.Height);
            float startScale = _pictureSize / svgStartMax;

            var startMatrix = SKMatrix.CreateScaleTranslation(
                startScale,
                startScale,
                firstPoint.X - (_pictureSize / 2),
                firstPoint.Y - (_pictureSize / 2));

            using (var picturePaint = new SKPaint()
            {
                ColorFilter = SKColorFilter.CreateBlendMode(
                        InfoColor == Color.Default ? _firstImageColor : InfoColor.ToSKColor(),
                        SKBlendMode.SrcIn)
            })
            {
                canvas.DrawPicture(_startImage.Picture, ref startMatrix, picturePaint);
            }

            if (lastSessionPoint.Time - MaxTime > TimeSpan.FromSeconds(20))
            {
                return false;
            }

            float svgEndMax = Math.Max(_endImage.Picture.CullRect.Width, _endImage.Picture.CullRect.Height);
            float endScale = _pictureSize / svgEndMax;

            var endMatrix = SKMatrix.CreateScaleTranslation(endScale, endScale, lastPoint.X, lastPoint.Y - _pictureSize);

            using (var picturePaint = new SKPaint()
            {
                ColorFilter = SKColorFilter.CreateBlendMode(
                        InfoColor == Color.Default ? _lastImageColor : InfoColor.ToSKColor(),
                        SKBlendMode.SrcIn)
            })
            {
                canvas.DrawPicture(_endImage.Picture, ref endMatrix, picturePaint);
            }

            return true;
        }

        private void DrawLastMarker(SKCanvas canvas, SKPoint lastPoint)
        {
            canvas.DrawCircle(lastPoint.X, lastPoint.Y, SkiaHelper.ToPixel(3), _lastMarkerPaint);
        }

        private bool DrawPositionMarker(SKCanvas canvas)
        {
            var point = _positionConverter[_currentPosition.ToLatLong()].ToSKPoint();

            float svgStartMax = Math.Max(_locationImage.Picture.CullRect.Width, _locationImage.Picture.CullRect.Height);
            float startScale = _pictureSize / svgStartMax;

            var startMatrix = SKMatrix.CreateScaleTranslation(
                startScale,
                startScale,
                point.X - (_pictureSize / 2),
                point.Y - (_pictureSize / 2));

            using (var picturePaint = new SKPaint()
            {
                ColorFilter = SKColorFilter.CreateBlendMode(
                        InfoColor == Color.Default ? _positionImageColor : InfoColor.ToSKColor(),
                        SKBlendMode.SrcIn)
            })
            {
                canvas.DrawPicture(_locationImage.Picture, ref startMatrix, picturePaint);
            }

            return true;
        }

        private void GoogleMapCameraChanged(object sender, CameraIdledEventArgs e)
        {
            Debug.WriteLine($"CameraChanged: pos: {e.Position.Target.Latitude}, {e.Position.Target.Longitude}");

            if (!_isCameraInitialized)
            {
                _isCameraInitialized = true;
            }

            if (_drawingCount == 0)
            {
                MapOverlay.InvalidateSurface();
            }
        }

        private void Initialize()
        {
            Debug.WriteLine($"Initializing {SessionMapInfo.SessionPoints.Count} points");

            _positionConverter = new PositionConverter();

            int markerCount = SessionMapInfo.SessionPoints.Count(p => p.HasMarker);
            int textDistanceCount = SessionMapInfo.SessionPoints.Count(p => !string.IsNullOrEmpty(p.Label));

            MaxTime = TimeSpan.FromSeconds(SessionMapInfo.TotalDurationInSeconds);

            _markerLayer = null;
            _markerLayer = new MarkerShapeLayer(markerCount);

            _textDistanceLayer = null;
            _textDistanceLayer = new TextShapeLayer(textDistanceCount);

            var region = SessionMapInfo.Region;
            _centerPosition = new LatLong(region.Center.Latitude, region.Center.Longitude);
            _topLeftPosition = SessionMapInfo.TopRight.ToLatLong();
            _bottomRightPosition = SessionMapInfo.BottomLeft.ToLatLong();

            _previousCenter = SKPoint.Empty;
            _previousTopLeftBottomRightSquareDistance = 1;

            if (ShowCurrentPosition)
            {
                _locationService = Mvx.IoCProvider.Resolve<ILocationService>();
                _messenger = Mvx.IoCProvider.Resolve<IMvxMessenger>();
                _token = _messenger.Subscribe<MvxLocationMessage>(this.OnLocationUpdated);
            }

            InitializeSvgImages();

            InitializeMap();
        }

        private void InitializeMap()
        {
            GoogleMap.MapType = MapType;

            if (SessionMapInfo != null)
            {
                Debug.WriteLine($"InitializeMap");

                Device.StartTimer(TimeSpan.FromMilliseconds(500), () =>
                {
                    GoogleMap.MoveToRegion(SessionMapInfo.Region, true);
                    return false;
                });
            }
        }

        private void InitializeMapResourcesIfNeeded()
        {
            if (_gradientPathPaint != null)
            {
                return;
            }

            InitializeSvgImages();

            _gradientPathPaint = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                IsAntialias = true,
                StrokeWidth = SkiaHelper.ToPixel(PathThickness),
                StrokeCap = SKStrokeCap.Butt,
                MaskFilter = SKMaskFilter.CreateBlur(SKBlurStyle.Solid, 2),
            };

            _markerPaint = new SKPaint
            {
                IsAntialias = true,
                Color = SKColors.White,
            };

            _lastMarkerPaint = new SKPaint
            {
                Color = SKColors.White,
                StrokeWidth = SkiaHelper.ToPixel(PathThickness * 1.5),
                Style = SKPaintStyle.Stroke,
            };

            //_distanceTextPaint = new SKPaint
            //{
            //    Color = SKColors.White,
            //    TextSize = SkiaHelper.ToPixel(12),
            //    IsAntialias = true,
            //};

            _markerArrowSize = (int)(PathThickness * 1.5);
        }

        private void InitializeSvgImages()
        {
            const string StartImageName = "stopwatch-solid.svg";
            const string EndImageName = "flag-checkered-solid.svg";
            const string LocationImageName = "current_location.svg";

            using (var stream = Embedded.Load(StartImageName))
            {
                _startImage = new SKSvg();
                _startImage.Load(stream);
            }

            using (var stream = Embedded.Load(EndImageName))
            {
                _endImage = new SKSvg();
                _endImage.Load(stream);
            }

            using (var stream = Embedded.Load(LocationImageName))
            {
                _locationImage = new SKSvg();
                _locationImage.Load(stream);
            }

            _pictureSize = SkiaHelper.ToPixel(20);
            _firstImageColor = SessionMapInfo.SessionPoints.First().MapPointColor.ToSKColor();
            _lastImageColor = SessionMapInfo.SessionPoints.Last().MapPointColor.ToSKColor();
        }

        private void MapOnPaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            // var info = e.RenderTarget;
            SKImageInfo info = e.Info;
            SKSurface surface = e.Surface;
            SKCanvas surfaceCanvas = surface.Canvas;

            var stopWatch = Stopwatch.StartNew();

            if (SessionMapInfo == null || !_isCameraInitialized)
            {
                Debug.WriteLine($"RETURNING: SessionMapInfo == null || !_isCameraInitialized");
                return;
            }

            if (_drawingCount > 0)
            {
                return;
            }

            _positionConverter.UpdateCamera(GoogleMap, new Size(info.Width, info.Height), SkiaHelper.PixelPerUnit);

            var centerPoint = _positionConverter[_centerPosition].ToSKPoint();
            var topLeftPoint = _positionConverter[_topLeftPosition].ToSKPoint();
            var bottomRightPoint = _positionConverter[_bottomRightPosition].ToSKPoint();
            double squaredDistance = SKPoint.DistanceSquared(topLeftPoint, bottomRightPoint);

            if (!_forceInvalidation && _previousCenter == centerPoint && _previousTopLeftBottomRightSquareDistance == squaredDistance)
            {
                // Display view didn't changed
                Debug.WriteLine($"RETURNING: Display view didn't changed");
                //return;
            }

            //Debug.WriteLine($"MapOnPaintSurface: pos: {GoogleMap.Camera.Position.Latitude}, {GoogleMap.Camera.Position.Longitude}");

            Interlocked.Increment(ref _drawingCount);

            _previousCenter = centerPoint;
            _previousTopLeftBottomRightSquareDistance = squaredDistance;

            var pictureRecorder = new SKPictureRecorder();
            var canvas = pictureRecorder.BeginRecording(e.Info.Rect);

            InitializeMapResourcesIfNeeded();

            var sessionPoints = SessionMapInfo.SessionPoints;

            _markerLayer.ResetIndex();
            _textDistanceLayer.ResetIndex();

            SKPoint previousPoint = SKPoint.Empty;
            SKColor previousColor = SKColor.Empty;

            int linesDrawnCount = 0;
            for (int index = 0; index < sessionPoints.Count; index++)
            {
                ISessionDisplayablePoint sessionPoint = sessionPoints[index];

                if (sessionPoint.Time > MaxTime)
                {
                    break;
                }

                SKPoint pathPoint = sessionPoint.Position != LatLong.Empty
                    ? _positionConverter[sessionPoint.Position].ToSKPoint()
                    : SKPoint.Empty;

                var pointColor = sessionPoint.MapPointColor.ToSKColor();

                // we won't trace line between points with a distance < 1 dp: this is
                // silly
                bool isDistanceEnough = Math.Abs(pathPoint.X - previousPoint.X) > SkiaHelper.ToPixel(4)
                    || Math.Abs(pathPoint.Y - previousPoint.Y) > SkiaHelper.ToPixel(4);

                // bool isDistanceEnough = true;

                if (previousPoint != SKPoint.Empty
                    && pathPoint != SKPoint.Empty
                    && isDistanceEnough)
                {
                    using (var shader = SKShader.CreateLinearGradient(
                        previousPoint,
                        pathPoint,
                        new[] { previousColor, pointColor },
                        null,
                        SKShaderTileMode.Clamp))
                    {
                        _gradientPathPaint.Shader = shader;

                        canvas.DrawLine(previousPoint.X, previousPoint.Y, pathPoint.X, pathPoint.Y, _gradientPathPaint);

                        _gradientPathPaint.Shader = null;
                    }

                    linesDrawnCount++;
                }

                if (sessionPoint.HasMarker && previousPoint != SKPoint.Empty)
                {
                    if (!_markerLayer.HasShape)
                    {
                        _markerLayer.Add(new MarkerShape(sessionPoint.Time, _markerArrowSize));
                    }

                    _markerLayer
                        .GetCurrentShape()
                        .UpdatePosition(previousPoint, pathPoint)
                        .UpdateArrowLength(_markerArrowSize);

                    _markerLayer.IncrementIndex();
                }

                if (!string.IsNullOrEmpty(sessionPoint.Label))
                {
                    if (!_textDistanceLayer.HasShape)
                    {
                        _textDistanceLayer.Add(new TextShape(sessionPoint.Label, sessionPoint.Time));
                    }

                    _textDistanceLayer
                        .GetCurrentShape()
                        .UpdatePosition(
                            new SKPoint(pathPoint.X, pathPoint.Y + SkiaHelper.ToPixel(14)));

                    _textDistanceLayer.IncrementIndex();
                }

                if (isDistanceEnough)
                {
                    previousPoint = pathPoint;
                    previousColor = pointColor;
                }
            }

            Debug.WriteLine($"MAP: {linesDrawnCount} lines drawn");

            _markerLayer.UpdateMaxTime(MaxTime);
            _markerLayer.Draw(canvas, _markerPaint);

            if (!DrawFirstAndLastMarker(
                canvas,
                sessionPoints.First(),
                sessionPoints.Last()))
            {
                DrawLastMarker(canvas, previousPoint);
            }

            _textDistanceLayer.UpdateMaxTime(MaxTime);
            //_textDistanceLayer.Draw(canvas, _distanceTextPaint);

            //DrawDebugInfos(
            //    canvas,
            //    _positionConverter.ToString());

            if (ShowCurrentPosition)
            {
                DrawPositionMarker(canvas);
            }

            ReleaseMapResources();

            _overlayPicture = pictureRecorder.EndRecording();

            surfaceCanvas.Clear();
            surfaceCanvas.DrawPicture(_overlayPicture);

            _overlayPicture.Dispose();
            pictureRecorder.Dispose();

            _forceInvalidation = false;

            stopWatch.Stop();
            Debug.WriteLine($"END OF => MapOnPaintSurface ({stopWatch.Elapsed})");

            Interlocked.Decrement(ref _drawingCount);
        }

        private void OnLocationUpdated(MvxLocationMessage locationMessage)
        {
            _currentPosition = new Position(locationMessage.Latitude, locationMessage.Longitude);
            MapOverlay.InvalidateSurface();
        }

        private void ReleaseMapResources()
        {
            _markerPaint?.Dispose();
            _markerPaint = null;

            _lastMarkerPaint?.Dispose();
            _lastMarkerPaint = null;

            _gradientPathPaint?.Dispose();
            _gradientPathPaint = null;

            //_distanceTextPaint?.Dispose();
            //_distanceTextPaint = null;
        }
    }
}