﻿using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace MoneyTracker.CustomControls
{
    public partial class DecimalBoxControl : TextBox
    {
        public DecimalBoxControl()
        {
            InitializeComponent();
            TextAlign = HorizontalAlignment.Right;
        }

        protected override void OnTextChanged(EventArgs e)
        {
            if (IsDecimal())
                base.OnTextChanged(e);
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar)
                && ((Keys)e.KeyChar != Keys.Back)
                && (e.KeyChar != '.')
                && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' && Text.IndexOf('.') > 0)
            {
                e.Handled = true;

            }

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
            return (decimal.Parse(Text) == 0);
        }

        public decimal? Value
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(Text))
                {
                    return decimal.Parse(Text);
                }
                else
                {
                    return null;
                }
            }
        }

        public decimal ValueDecimal
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(Text))
                {
                    return decimal.Parse(Text);
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}
