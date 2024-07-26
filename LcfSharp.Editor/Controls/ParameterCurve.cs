using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
using System.Collections.Generic;

namespace LcfSharp.Editor.Controls
{
    public class ParameterCurve : Control
    {
        static ParameterCurve( )
        {
            DefaultStyleKeyProperty.OverrideMetadata( typeof( ParameterCurve ), new FrameworkPropertyMetadata( typeof( ParameterCurve ) ) );
        }

        public static readonly DependencyProperty DataProperty = DependencyProperty.Register(
            nameof( Data ), typeof( List<short> ), typeof( ParameterCurve ), new PropertyMetadata( new List<short>( ), OnDataChanged ) );

        public List<short> Data
        {
            get => ( List<short> ) GetValue( DataProperty );
            set => SetValue( DataProperty, value );
        }

        public static readonly DependencyProperty CurveBrushProperty = DependencyProperty.Register(
           nameof( CurveBrush ), typeof( Brush ), typeof( ParameterCurve ), new PropertyMetadata( Brushes.Magenta ) );

        public Brush CurveBrush
        {
            get => ( Brush ) GetValue( CurveBrushProperty );
            set => SetValue( CurveBrushProperty, value );
        }

        public static readonly DependencyProperty MaxValueProperty = DependencyProperty.Register(
           nameof( MaxValue ), typeof( int ), typeof( ParameterCurve ), new PropertyMetadata( 999 ) );

        public int MaxValue
        {
            get => ( int ) GetValue( MaxValueProperty );
            set => SetValue( MaxValueProperty, value );
        }

        private static void OnDataChanged( DependencyObject d, DependencyPropertyChangedEventArgs e )
        {
            var control = ( ParameterCurve ) d;
            control.InvalidateVisual( ); // Redraw the control when data changes
        }

        protected override void OnRender( DrawingContext drawingContext )
        {
            base.OnRender( drawingContext );

            if ( Data == null || Data.Count == 0 )
                return;

            double width = ActualWidth;
            double height = ActualHeight;
            double columnWidth = width / 50;

            var xOffset = 1;
            var yOffset = -1;

            drawingContext.DrawRectangle( Brushes.Black, null, new Rect( 0, 0, width, height ) );

            var pen = new Pen( CurveBrush, 2 );
            var geometry = new StreamGeometry( );

            using ( var context = geometry.Open( ) )
            {
                if ( Data.Count > 0 )
                {
                    double firstColumnHeight = height * Data[0] / MaxValue;
                    double firstX = 0;
                    double firstY = height - firstColumnHeight;

                    context.BeginFigure( new Point( firstX + xOffset, height + yOffset ), true, true ); // Start at the bottom left corner
                    context.LineTo( new Point( firstX + xOffset, firstY + yOffset ), true, true ); // Move to the first data point

                    for ( int i = 1; i < Data.Count && i < 50; i++ )
                    {
                        double columnHeight = height * Data[i] / MaxValue;
                        double x = i * columnWidth;
                        double y = height - columnHeight;
                        context.LineTo( new Point( x + xOffset, y + yOffset ), true, true );
                    }

                    double lastX = ( Data.Count - 1 ) * columnWidth;
                    context.LineTo( new Point( lastX + xOffset, height + yOffset ), true, true ); // Line to the bottom of the last column
                    context.LineTo( new Point( 0 + xOffset, height + yOffset ), true, true ); // Close the figure by drawing to the bottom left corner
                }
            }

            drawingContext.DrawGeometry( CurveBrush, pen, geometry );
        }
    }
}