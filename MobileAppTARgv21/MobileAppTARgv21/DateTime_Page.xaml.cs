﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileAppTARgv21
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DateTime_Page : ContentPage
    {

        DatePicker dp;
        TimePicker tp;
        Label lbl;
        public DateTime_Page()
        {
            dp = new DatePicker
            {
                Format="D",
                MinimumDate = DateTime.Now.AddDays(-7),
                MaximumDate = DateTime.Now.AddDays(7)
            };
            dp.DateSelected += Dp_DateSelected;

            tp = new TimePicker
            {
                Format = "D",
                Time = new TimeSpan(12, 30, 0)
            };
            tp.PropertyChanged += Tp_PropertyChanged;

            lbl = new Label
            {
                Text = "..."
            };

            AbsoluteLayout abs = new AbsoluteLayout { Children = { dp, tp, lbl } };
            AbsoluteLayout.SetLayoutBounds(dp, new Rectangle(0.2, 0.2, 300, 100));
            AbsoluteLayout.SetLayoutFlags(dp, AbsoluteLayoutFlags.PositionProportional);

            AbsoluteLayout.SetLayoutBounds(tp, new Rectangle(0.6, 0.5, 300, 100));
            AbsoluteLayout.SetLayoutFlags(tp, AbsoluteLayoutFlags.PositionProportional);

            AbsoluteLayout.SetLayoutBounds(lbl, new Rectangle(0.6, 0.8, 300, 100));
            AbsoluteLayout.SetLayoutFlags(lbl, AbsoluteLayoutFlags.PositionProportional);
            Content = abs;
        }

        private void Tp_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            lbl.Text ="Time: " + tp.Time.ToString();
        }
         
        private void Dp_DateSelected(object sender, DateChangedEventArgs e)
        {
            lbl.Text = "Date: " + e.NewDate.ToString();
        }
    }
}