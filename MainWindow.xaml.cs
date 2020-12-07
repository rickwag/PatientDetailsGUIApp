﻿using System.Windows;
using PatientDetails.ViewModels;

namespace PatientDetails
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            new PatientViewModel();
        }
    }
}
