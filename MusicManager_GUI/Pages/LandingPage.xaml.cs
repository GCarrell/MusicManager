﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MusicManagerBusiness;

namespace MusicManager_GUI
{
    /// <summary>
    /// Interaction logic for LandingPage.xaml
    /// </summary>
    public partial class LandingPage : Page
    {
        CRUDManager crudManager;
        public LandingPage( CRUDManager managerOfCrud)
        {
            crudManager = managerOfCrud;
            InitializeComponent();
            PopulateListBox();
        }
        private void PopulateListBox()
        {
            TabList.ItemsSource = crudManager.RetrieveAllTabs();
        }
        private void ListSorter(object sender, RoutedEventArgs e)
        {
            switch ((sender as Button).Tag)
            {
                case "Bass":
                    TabList.ItemsSource = crudManager.RetrieveBassTabs();
                    break;
                case "Drums":
                    TabList.ItemsSource = crudManager.RetrieveDrumTabs();
                    break;
                case "Guitar":
                    TabList.ItemsSource = crudManager.RetrieveGuitarTabs();
                    break;
                case "Reset":
                    PopulateListBox();
                    break;
            }
        }
        private void TabList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var window = (MainWindow)Application.Current.MainWindow;
            crudManager.SetTab(TabList.SelectedItem);
            TabInformation tabInformation = new TabInformation(crudManager);
            window.PageDisplayFrame.NavigationService.Navigate(tabInformation);
        }
    }
}
