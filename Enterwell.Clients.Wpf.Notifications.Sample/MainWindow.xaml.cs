﻿using System;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Enterwell.Clients.Wpf.Notifications.Controls;

namespace Enterwell.Clients.Wpf.Notifications.Sample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();
            this.DataContext = this;
        }


        private void ButtonBaseErrorOnClick(object sender, RoutedEventArgs e)
        {
            this.Manager
                .CreateMessage()
                .Accent("#F15B19")
                .Background("#F15B19")
                .HasHeader("Lost connection to server")
                .HasMessage("Reconnecting...")
                .WithOverlay(new ProgressBar
                {
                    VerticalAlignment = VerticalAlignment.Bottom,
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    Height = 3,
                    BorderThickness = new Thickness(0),
                    Foreground = new SolidColorBrush(Color.FromArgb(128, 255, 255, 255)),
                    Background = Brushes.Transparent,
                    IsIndeterminate = true,
                    IsHitTestVisible = false
                })
                .Queue();
        }

        private void ButtonBaseWarningOnClick(object sender, RoutedEventArgs e)
        {
            this.Manager
                .CreateMessage()
                .Accent("#E0A030")
                .Background("#333")
                .HasBadge("Warn")
                .HasHeader("Error")
                .HasMessage("Failed to retrieve data.")
                .WithButton("Try again", button => { })
                .Dismiss().WithButton("Ignore", button => { })
                .Queue();
        }

        private void ButtonBaseInfoOnClick(object sender, RoutedEventArgs e)
        {
            this.Manager
                .CreateMessage()
                .Accent("#1751C3")
                .Background("#333")
                .HasBadge("Info")
                .HasMessage("Update will be installed on next application restart.")
                .Dismiss().WithButton("Update now", button => { })
                .Dismiss().WithButton("Release notes", button => { })
                .Dismiss().WithButton("Later", button => { })
                .Queue();
        }

        private void ButtonBaseInfoDelayOnClick(object sender, RoutedEventArgs e)
        {
            this.Manager
                .CreateMessage()
                .Accent("#1751C3")
                .Animates(true)
                .AnimationInDuration(0.75)
                .AnimationOutDuration(2)
                .Background("#333")
                .HasBadge("Info")
                .HasMessage("Update will be installed on next application restart. This message will be dismissed after 5 seconds.")
                .Dismiss().WithButton("Update now", button => { })
                .Dismiss().WithButton("Release notes", button => { })
                .Dismiss().WithDelay(TimeSpan.FromSeconds(5))
                .Queue();
        }

        private void ButtonBaseAdditionalContentOnClick(object sender, RoutedEventArgs e)
        {
            Thickness margin = new Thickness();
            margin.Top = margin.Bottom = margin.Left = margin.Right = 5;
            this.Manager
                .CreateMessage()
                .Accent("#1751C3")
                .Animates(true)
                .AnimationInDuration(0.5)
                .AnimationOutDuration(0.5)
                .Background("#333")
                .Foreground("#000")
                .HasBadge("Info")
                .HasHeader("Header")
                .HasMessage("This is the message!")
                .WithAdditionalContent(ContentLocation.Top, new Border
                {
                    Height = 25,
                    VerticalAlignment = VerticalAlignment.Stretch,
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    Background = Brushes.Red
                })
                .WithAdditionalContent(ContentLocation.Bottom, new Border
                {
                    Height = 25,
                    VerticalAlignment = VerticalAlignment.Stretch,
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    Background = Brushes.Green
                })
                .WithAdditionalContent(ContentLocation.Left, new Border
                {
                    Width = 25,
                    VerticalAlignment = VerticalAlignment.Stretch,
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    Background = Brushes.Yellow
                })
                .WithAdditionalContent(ContentLocation.Right, new Border
                {
                    Width = 25,
                    VerticalAlignment = VerticalAlignment.Stretch,
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    Background = Brushes.Violet
                })
                .WithAdditionalContent(ContentLocation.Main, new Border
                {
                    MinHeight = 50,
                    VerticalAlignment = VerticalAlignment.Stretch,
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    Background = Brushes.Orange
                })
                .WithAdditionalContent(ContentLocation.OverBadge, new Border
                {
                    Height = 40,
                    Width = 40,
                    Background = Brushes.Indigo
                })
                .WithOverlay(new ProgressBar
                {
                    VerticalAlignment = VerticalAlignment.Bottom,
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    Height = 3,
                    BorderThickness = new Thickness(0),
                    Foreground = new SolidColorBrush(Color.FromArgb(128, 255, 255, 255)),
                    Background = Brushes.Transparent,
                    IsIndeterminate = true,
                    IsHitTestVisible = false
                })
                .Dismiss().WithButton("Dismiss", button => { })
                .Queue();
        }

        /// <summary>
        /// Gets the notification message manager.
        /// </summary>
        /// <value>
        /// The notification message manager.
        /// </value>
        public INotificationMessageManager Manager { get; } = new NotificationMessageManager();
    }
}
