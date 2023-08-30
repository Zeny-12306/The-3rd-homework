using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace AeraCalc
{
    public class CustomCircle : FrameworkElement
    {
        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            int Width = 100;
            int Height = 100;
            int location_x = 100, location_y = 100;


            // 绘制圆形
            var ellipseGeometry = new EllipseGeometry(new System.Windows.Rect(location_x, location_y, Width, Height));

            // 绘制箭头
            var arrowGeometry = new StreamGeometry();
            using (var context = arrowGeometry.Open())
            {
                context.BeginFigure(new Point(location_x + Width / 2 - 5, location_y + 5), true, false);
                context.LineTo(new Point(location_x + Width / 2 + 5, location_y + 5), true, false);
                context.LineTo(new Point(location_x + Width / 2, location_y), true, false);
            }
            arrowGeometry.Freeze();
            
            // 绘制椭圆边框和箭头
            var pen = new Pen(Brushes.Black, 2);
            drawingContext.DrawGeometry(null, pen, ellipseGeometry);
            drawingContext.DrawLine(pen, new Point(location_x + Width / 2, location_y + Height / 2), new Point(location_x + Width / 2, location_y));
            drawingContext.DrawGeometry(Brushes.Black, null, arrowGeometry);

            // 变量标注
            var text = new FormattedText("半径r", System.Globalization.CultureInfo.CurrentCulture,FlowDirection.LeftToRight, new Typeface("Arial"), 12, Brushes.Black);
            drawingContext.DrawText(text, new Point(location_x + Width / 2 - text.Width / 2, location_y + Height / 4 - text.Height / 2));

            // 绘制圆形
            //var pen = new Pen(Brushes.Black, 2);
            //drawingContext.DrawEllipse(null,pen, new Point(100, 150), 50, 50);

        }
    }
    public class CustomRect : FrameworkElement
    {
        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext); 
            int Width = 150;
            int Height = 80;
            int location_x = 100, location_y = 100;


            // 绘制矩形
            var rectGeometry = new RectangleGeometry(new System.Windows.Rect(location_x, location_y, Width, Height));

            // 绘制箭头
            var arrowGeometry1 = new StreamGeometry();
            using (var context = arrowGeometry1.Open())
            {
                context.BeginFigure(new Point(location_x + Width + 5, location_y + 5), true, false);
                context.LineTo(new Point(location_x + Width + 15, location_y + 5), true, false);
                context.LineTo(new Point(location_x + Width + 10, location_y), true, false);
            }
            arrowGeometry1.Freeze();

            var arrowGeometry2 = new StreamGeometry();
            using (var context = arrowGeometry2.Open())
            {
                context.BeginFigure(new Point(location_x + Width + 5, location_y + Height - 5), true, false);
                context.LineTo(new Point(location_x + Width + 15, location_y + Height - 5), true, false);
                context.LineTo(new Point(location_x + Width + 10, location_y + Height), true, false);
            }
            arrowGeometry2.Freeze();

            var arrowGeometry3 = new StreamGeometry();
            using (var context = arrowGeometry3.Open())
            {
                context.BeginFigure(new Point(location_x + 5 , location_y + Height + 5), true, false);
                context.LineTo(new Point(location_x + 5, location_y + Height + 15), true, false);
                context.LineTo(new Point(location_x , location_y+ Height + 10), true, false);
            }
            arrowGeometry3.Freeze();

            var arrowGeometry4 = new StreamGeometry();
            using (var context = arrowGeometry4.Open())
            {
                context.BeginFigure(new Point(location_x + Width - 5, location_y + Height + 5), true, false);
                context.LineTo(new Point(location_x + Width - 5, location_y + Height + 15), true, false);
                context.LineTo(new Point(location_x + Width , location_y + Height + 10), true, false);
            }
            arrowGeometry4.Freeze();

            // 绘制椭圆边框和箭头
            var pen = new Pen(Brushes.Black, 2);
            drawingContext.DrawGeometry(null, pen, rectGeometry);
            drawingContext.DrawLine(pen, new Point(location_x + Width + 10, location_y ), new Point(location_x + Width + 10, location_y + Height));
            drawingContext.DrawLine(pen, new Point(location_x , location_y + Height + 10), new Point(location_x + Width, location_y + Height + 10));
            drawingContext.DrawGeometry(Brushes.Black, null, arrowGeometry1);
            drawingContext.DrawGeometry(Brushes.Black, null, arrowGeometry2);
            drawingContext.DrawGeometry(Brushes.Black, null, arrowGeometry3);
            drawingContext.DrawGeometry(Brushes.Black, null, arrowGeometry4);

            // 变量标注
            var text1 = new FormattedText("长度a", System.Globalization.CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface("Arial"), 12, Brushes.Black);
            drawingContext.DrawText(text1, new Point(location_x + Width / 2 - text1.Width / 2, location_y + Height - text1.Height / 2 + 20));

            var text2 = new FormattedText("宽度b", System.Globalization.CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface("Arial"), 12, Brushes.Black);
            //drawingContext.DrawText(text2, new Point(location_x + Width + 10 - text2.Width / 2 , location_y + Height / 2  - text2.Height / 2));
            // 旋转文本
            //var rotateTransform = new RotateTransform(-90, ActualWidth / 2, ActualHeight / 2);
            //drawingContext.PushTransform(rotateTransform);
            //drawingContext.DrawText(text2, new Point(location_x + Width + 10 - text2.Width / 2, location_y + Height / 2 - text2.Height / 2));
            //drawingContext.Pop();
            // 计算纵向文本位置和变换
            var rotateTransform = new RotateTransform(-90);
            var translateTransform = new TranslateTransform(location_x + Width + 10 - text2.Width / 2 - 10, location_y + Height / 2 - text2.Height / 2 + 20);
            var transformGroup = new TransformGroup();
            transformGroup.Children.Add(rotateTransform);
            transformGroup.Children.Add(translateTransform);

            // 应用变换并绘制文本
            drawingContext.PushTransform(transformGroup);
            drawingContext.DrawText(text2, new Point(0, 0));
            drawingContext.Pop();

            // 绘制矩形
            // drawingContext.DrawRectangle(null, new Pen(Brushes.Black, 2), new System.Windows.Rect(100, 150, 150, 80));
        }
    }
    public class CustomTrig : FrameworkElement
    {
        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            int location_x = 100, location_y = 100;
            int s = 120, h = 90;

            // 绘制箭头
            var triangleGeometry = new StreamGeometry();
            using (var context = triangleGeometry.Open())
            {
                context.BeginFigure(new Point(location_x , location_y + h), true, false);
                context.LineTo(new Point(location_x + 30, location_y ), true, false);
                context.LineTo(new Point(location_x + s, location_y + h), true, false);
                context.LineTo(new Point(location_x, location_y + h), true, false);
            }
            triangleGeometry.Freeze();

            var arrowGeometry1 = new StreamGeometry();
            using (var context = arrowGeometry1.Open())
            {
                context.BeginFigure(new Point(location_x + 5, location_y + h + 5), true, false);
                context.LineTo(new Point(location_x + 5, location_y + h + 15), true, false);
                context.LineTo(new Point(location_x, location_y + h + 10), true, false);
            }
            arrowGeometry1.Freeze();

            var arrowGeometry2 = new StreamGeometry();
            using (var context = arrowGeometry2.Open())
            {
                context.BeginFigure(new Point(location_x + s - 5, location_y + h + 5), true, false);
                context.LineTo(new Point(location_x + s - 5, location_y + h + 15), true, false);
                context.LineTo(new Point(location_x + s , location_y + h + 10), true, false);
            }
            arrowGeometry2.Freeze();

            var arrowGeometry3 = new StreamGeometry();
            using (var context = arrowGeometry3.Open())
            {
                context.BeginFigure(new Point(location_x + s + 5, location_y + h - 5), true, false);
                context.LineTo(new Point(location_x + s + 15, location_y + h - 5), true, false);
                context.LineTo(new Point(location_x + s + 10, location_y + h ), true, false);
            }
            arrowGeometry3.Freeze();

            var arrowGeometry4 = new StreamGeometry();
            using (var context = arrowGeometry4.Open())
            {
                context.BeginFigure(new Point(location_x + s + 5, location_y  + 5), true, false);
                context.LineTo(new Point(location_x + s + 15, location_y + 5), true, false);
                context.LineTo(new Point(location_x + s + 10, location_y ), true, false);
            }
            arrowGeometry4.Freeze();

            // 绘制椭圆边框和箭头
            var pen = new Pen(Brushes.Black, 2);
            drawingContext.DrawLine(pen, new Point(location_x + s + 10, location_y), new Point(location_x + s + 10, location_y + h));
            drawingContext.DrawLine(pen, new Point(location_x, location_y + h + 10), new Point(location_x + s, location_y + h + 10));
            //drawingContext.DrawGeometry(Brushes.Black, null, triangleGeometry);
            drawingContext.DrawGeometry(null, pen, triangleGeometry);
            drawingContext.DrawGeometry(Brushes.Black, null, arrowGeometry1);
            drawingContext.DrawGeometry(Brushes.Black, null, arrowGeometry2);
            drawingContext.DrawGeometry(Brushes.Black, null, arrowGeometry3);
            drawingContext.DrawGeometry(Brushes.Black, null, arrowGeometry4);

            // 变量标注
            var text1 = new FormattedText("底s", System.Globalization.CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface("Arial"), 12, Brushes.Black);
            drawingContext.DrawText(text1, new Point(location_x + s / 2 - text1.Width / 2, location_y + h - text1.Height / 2 + 20));

            var text2 = new FormattedText("高h", System.Globalization.CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface("Arial"), 12, Brushes.Black);
            //drawingContext.DrawText(text2, new Point(location_x + s + 10 - text2.Width / 2, location_y + h / 2 - text2.Height / 2));
            var rotateTransform = new RotateTransform(-90);
            var translateTransform = new TranslateTransform(location_x + s + 10 - text2.Width / 2 - 10, location_y + h / 2 - text2.Height / 2 + 20);
            var transformGroup = new TransformGroup();
            transformGroup.Children.Add(rotateTransform);
            transformGroup.Children.Add(translateTransform);
            drawingContext.PushTransform(transformGroup);
            drawingContext.DrawText(text2, new Point(0, 0));
            drawingContext.Pop();
        }
    }
    public class CustomSquare : FrameworkElement
    {
        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            int Width = 100;
            int Height = 100;
            int location_x = 100, location_y = 100;


            // 绘制矩形
            var rectGeometry = new RectangleGeometry(new System.Windows.Rect(location_x, location_y, Width, Height));

            // 绘制箭头
            
            var arrowGeometry1 = new StreamGeometry();
            using (var context = arrowGeometry1.Open())
            {
                context.BeginFigure(new Point(location_x + 5, location_y + Height + 5), true, false);
                context.LineTo(new Point(location_x + 5, location_y + Height + 15), true, false);
                context.LineTo(new Point(location_x, location_y + Height + 10), true, false);
            }
            arrowGeometry1.Freeze();

            var arrowGeometry2 = new StreamGeometry();
            using (var context = arrowGeometry2.Open())
            {
                context.BeginFigure(new Point(location_x + Width - 5, location_y + Height + 5), true, false);
                context.LineTo(new Point(location_x + Width - 5, location_y + Height + 15), true, false);
                context.LineTo(new Point(location_x + Width, location_y + Height + 10), true, false);
            }
            arrowGeometry2.Freeze();

            // 绘制椭圆边框和箭头
            var pen = new Pen(Brushes.Black, 2);
            drawingContext.DrawGeometry(null, pen, rectGeometry);
            drawingContext.DrawLine(pen, new Point(location_x, location_y + Height + 10), new Point(location_x + Width, location_y + Height + 10));

            drawingContext.DrawGeometry(Brushes.Black, null, arrowGeometry1);
            drawingContext.DrawGeometry(Brushes.Black, null, arrowGeometry2);

            // 变量标注
            var text1 = new FormattedText("长度a", System.Globalization.CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface("Arial"), 12, Brushes.Black);
            drawingContext.DrawText(text1, new Point(location_x + Width / 2 - text1.Width / 2, location_y + Height - text1.Height / 2 + 20));

        }
    }
}
