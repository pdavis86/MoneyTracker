using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace MoneyTracker.CustomControls
{
    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
    public partial class DecimalBoxControl : TextBox
    {
        public DecimalBoxControl()
        {
            InitializeComponent();
            TextAlign = HorizontalAlignment.Right;
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
            {
                base.OnKeyPress(e);
                return;
            }

            if (char.IsDigit(e.KeyChar))
            {
                base.OnKeyPress(e);
                return;
            }

            if (e.KeyChar == '.' && !Text.Contains('.'))
            {
                base.OnKeyPress(e);
                return;
            }

            if (e.KeyChar == '-' && SelectionStart == 0 && !Text.Contains('-'))
            {
                base.OnKeyPress(e);
                return;
            }

            e.Handled = true;
            base.OnKeyPress(e);
        }

        protected override void OnGotFocus(EventArgs e)
        {
            ResetValueOnFocus();
            base.OnGotFocus(e);
        }

        protected override void OnValidating(CancelEventArgs e)
        {
            base.OnValidating(e);

            if (!string.IsNullOrWhiteSpace(Text))
            {
                decimal.TryParse(Text, out decimal value);
                Text = value.ToString("N2");
            }
        }

        private void ResetValueOnFocus()
        {
            if (IsDecimal())
            {
                if (!IsDecimalZero())
                    return;
            }
            Text = "";
        }

        private bool IsDecimal()
        {
            return decimal.TryParse(Text, out _);
        }

        private bool IsDecimalZero()
        {
            return decimal.TryParse(Text, out var value) && value == 0;
        }

        public decimal? Value
        {
            get
            {
                return decimal.TryParse(Text, out var value)
                    ? value
                    : null;
            }
        }

        public decimal ValueDecimal
        {
            get
            {
                return decimal.TryParse(Text, out var value)
                    ? value
                    : 0;
            }
        }
    }
}
