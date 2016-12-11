﻿using Android.Graphics;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using ACanvas = Android.Graphics.Canvas;
using Color = Android.Graphics.Color;
 
[assembly: ExportRenderer(typeof(Frame), typeof(FrameBugPoc.Droid.FrameRenderer))]
namespace FrameBugPoc.Droid
{
	public class FrameRenderer : Xamarin.Forms.Platform.Android.FrameRenderer
	{
		public override void Draw(ACanvas canvas)
		{
			base.Draw(canvas);

			DrawOutline(canvas, canvas.Width, canvas.Height, 4f);//set corner radius
		}


		void DrawOutline(ACanvas canvas, int width, int height, float cornerRadius)
		{
			using (var paint = new Paint { AntiAlias = true })
			using (var path = new Path())
			using (Path.Direction direction = Path.Direction.Cw)
			using (Paint.Style style = Paint.Style.Stroke)
			using (var rect = new RectF(0, 0, width, height))
			{
				float rx = Forms.Context.ToPixels(cornerRadius);
				float ry = Forms.Context.ToPixels(cornerRadius);
				path.AddRoundRect(rect, rx, ry, direction);

				paint.StrokeWidth = 2f;  //set outline stroke
				paint.SetStyle(style);
				paint.Color = Color.ParseColor("#A7AE22");//set outline color //_frame.OutlineColor.ToAndroid(); 
				canvas.DrawPath(path, paint);
			}
		} 
	}
}