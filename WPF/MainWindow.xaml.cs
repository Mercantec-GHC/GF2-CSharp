﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace WPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ShowFireworks();
        }

        private void ShowFireworks()
        {
            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                Ellipse ellipse = new Ellipse
                {
                    Width = 10,
                    Height = 10,
                    Fill = new SolidColorBrush(Color.FromRgb((byte)random.Next(256), (byte)random.Next(256), (byte)random.Next(256)))
                };

                fireworksCanvas.Children.Add(ellipse);

                double startX = random.Next((int)ActualWidth);
                double startY = random.Next((int)ActualHeight);

                double endX = startX + random.Next(-100, 100);
                double endY = startY + random.Next(-100, 100);

                Canvas.SetLeft(ellipse, startX);
                Canvas.SetTop(ellipse, startY);

                DoubleAnimation animX = new DoubleAnimation(startX, endX, TimeSpan.FromSeconds(1));
                DoubleAnimation animY = new DoubleAnimation(startY, endY, TimeSpan.FromSeconds(1));

                Storyboard.SetTarget(animX, ellipse);
                Storyboard.SetTargetProperty(animX, new PropertyPath("(Canvas.Left)"));
                Storyboard.SetTarget(animY, ellipse);
                Storyboard.SetTargetProperty(animY, new PropertyPath("(Canvas.Top)"));

                Storyboard storyboard = new Storyboard();
                storyboard.Children.Add(animX);
                storyboard.Children.Add(animY);
                storyboard.Completed += (s, e) => fireworksCanvas.Children.Remove(ellipse);
                storyboard.Begin();
            }
        }

        private void NavigateToTaxa(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new Taxa());
            welcomeButton.Visibility = Visibility.Collapsed;
        }

        private void NavigateToHrGran(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new HrGran());
            welcomeButton.Visibility = Visibility.Collapsed;
        }
        private void NavigateToCookieClicker(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new CookieClicker());
            welcomeButton.Visibility = Visibility.Collapsed;
        }

        private void NavigateToBinary(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new Binary());
            welcomeButton.Visibility = Visibility.Collapsed;
        }
        private void NavigateToWordle(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new Wordle());
            welcomeButton.Visibility = Visibility.Collapsed;
        }
        private void NavigateToTypeRacer(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new TypeRacer());
            welcomeButton.Visibility = Visibility.Collapsed;
        }

        private void NavigateToMain(object sender, RoutedEventArgs e)
        {
            mainFrame.Content = null;
            welcomeButton.Visibility = Visibility.Visible;
        }
    }
}
