using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;

namespace ColorProgressBar
{
    [Description("Color Progress Bar")]
    [ToolboxBitmap(typeof(ProgressBar))]
    [Designer(typeof(ColorProgressBarDesigner))]
    public class ColorProgressBar : System.Windows.Forms.Control
    {

        private int _Value = 0;
        private int _Minimum = 0;
        private int _Maximum = 100;
        private int _Step = 10;

        private Color _BarColor = Color.Green;
        private Color _BorderColor = Color.Black;

        public ColorProgressBar()
        {
            base.Size = new Size(200, 20);
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.DoubleBuffer, true);
        }

        [Description("Progress bar color")]
        [Category("ColorProgressBar")]
        public Color BarColor
        {
            get
            {
                return _BarColor;
            }
            set
            {
                _BarColor = value;
                this.Invalidate();
            }
        }

        [Description("The current value for the progres bar. Must be between Minimum and Maximum.")]
        [Category("ColorProgressBar")]
        [RefreshProperties(RefreshProperties.All)]
        public int Value
        {
            get
            {
                return _Value;
            }
            set
            {
                if (value < _Minimum)
                {
                    throw new ArgumentException($"'{value}' is not a valid 'Value'.\n'Value' must be between 'Minimum' and 'Maximum'.");
                }

                if (value > _Maximum)
                {
                    throw new ArgumentException($"'{value}' is not a valid 'Value'.\n'Value' must be between 'Minimum' and 'Maximum'.");
                }

                _Value = value;
                this.Invalidate();
            }
        }

        [Description("The lower bound of the range.")]
        [Category("ColorProgressBar")]
        [RefreshProperties(RefreshProperties.All)]
        public int Minimum
        {
            get
            {
                return _Minimum;
            }
            set
            {
                _Minimum = value;

                if (_Minimum > _Maximum)
                    _Maximum = _Minimum;
                if (_Minimum > _Value)
                    _Value = _Minimum;

                this.Invalidate();
            }
        }

        [Description("The uppper bound of the range.")]
        [Category("ColorProgressBar")]
        [RefreshProperties(RefreshProperties.All)]
        public int Maximum
        {
            get
            {
                return _Maximum;
            }
            set
            {
                _Maximum = value;

                if (_Maximum < _Value)
                    _Value = _Maximum;
                if (_Maximum < _Minimum)
                    _Minimum = _Maximum;

                this.Invalidate();
            }
        }

        [Description("The value to move the progess bar when the Step() method is called.")]
        [Category("ColorProgressBar")]
        public int Step
        {
            get
            {
                return _Step;
            }
            set
            {
                _Step = value;
                this.Invalidate();
            }
        }

        [Description("The border color")]
        [Category("ColorProgressBar")]
        public Color BorderColor
        {
            get
            {
                return _BorderColor;
            }
            set
            {
                _BorderColor = value;
                this.Invalidate();
            }
        }

        ///
        /// <summary>Call the PerformStep() method to increase the value displayed by the value set in the Step property</summary>
        ///
        public void PerformStep()
        {
            if (_Value < _Maximum)
                _Value += _Step;
            else
                _Value = _Maximum;

            this.Invalidate();
        }

        ///
        /// <summary>Call the PerformStepBack() method to decrease the value displayed by the value set in the Step property</summary>
        ///
        public void PerformStepBack()
        {
            if (_Value > _Minimum)
                _Value -= _Step;
            else
                _Value = _Minimum;

            this.Invalidate();
        }

        ///
        /// <summary>Call the Increment() method to increase the value displayed by the passed value</summary>
        /// 
        public void Increment(int value)
        {
            if (_Value < _Maximum)
                _Value += value;
            else
                _Value = _Maximum;

            this.Invalidate();
        }

        //
        // <summary>Call the Decrement() method to decrease the value displayed by the passed value</summary>
        // 
        public void Decrement(int value)
        {
            if (_Value > _Minimum)
                _Value -= value;
            else
                _Value = _Minimum;

            this.Invalidate();
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            // 
            // Check for value
            //
            if (_Maximum == _Minimum || _Value == 0)
            {
                // Draw border only and exit;
                DrawBorder(e.Graphics);
                return;
            }

            //
            // The following is the width of the bar. This will vary with each value.
            //
            int fillWidth = (this.Width * _Value) / (_Maximum - _Minimum);

            //
            // Rectangles for upper and lower half of bar
            //
            Rectangle rect = new Rectangle(0, 0, fillWidth, this.Height);

            //
            // The brush
            //
            SolidBrush brush = new SolidBrush(_BarColor);
            e.Graphics.FillRectangle(brush, rect);
            brush.Dispose();

            //
            // Draw border and exit
            DrawBorder(e.Graphics);
        }

        protected void DrawBorder(Graphics g)
        {
            Rectangle borderRect = new Rectangle(0, 0, ClientRectangle.Width - 1, ClientRectangle.Height - 1);
            g.DrawRectangle(new Pen(_BorderColor, 1), borderRect);
        }
    }
}