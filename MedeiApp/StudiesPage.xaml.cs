using System;
using System.Collections.Generic;

using Plugin.Connectivity;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using MedeiApp.Models;
using MedeiApp.Data;
using SQLite;
using MedeiApp.Sqlite;
using MedeiApp.WebService;
using System.Diagnostics;

namespace MedeiApp
{
    public partial class StudiesPage : ContentPage
    {
        private ObservableCollection<Study> studiesList;
        private IRestService postsRest;
        private SQLiteAsyncConnection _connection;

        public StudiesPage()
        {
            InitializeComponent();

            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();

            //Hardcoded data

            /*StudyData sD = new StudyData();
            bool withTrialData = true;
            List<Study> studyList = sD.GetStudies(withTrialData);
            studiesList = new ObservableCollection<Study>(studyList);

            this.studies.ItemsSource = studiesList;*/

        }


        //Fejl pga List<Trial>
        protected override async void OnAppearing()
        {
            //await _connection.CreateTableAsync<Study>();

            //if (CrossConnectivity.Current.IsConnected)
            //{
                //try
                //{

                    postsRest = new RestService();

                    var studyList = await postsRest.RefreshDataAsync();

                    studiesList = new ObservableCollection<Study>(studyList);

                    this.studies.ItemsSource = studiesList;

                    base.OnAppearing();
                //}
                //catch (Exception ex)
                //{
                //    Debug.WriteLine("Request error");
                //}

                /*var SQLstudyList = await _connection.Table<Study>().ToListAsync();
                studiesList = new ObservableCollection<Study>(SQLstudyList);
                this.studies.ItemsSource = studiesList;

                base.OnAppearing();

            } else
            {
                var SQLstudyList = await _connection.Table<Study>().ToListAsync();
                studiesList = new ObservableCollection<Study>(SQLstudyList);
                this.studies.ItemsSource = studiesList;

                base.OnAppearing();*/
            //}

            /*var SQLstudyList = await _connection.Table<Study>().ToListAsync();
            studiesList = new ObservableCollection<Study>(SQLstudyList);
            this.studies.ItemsSource = studiesList;*/

            //base.OnAppearing();

        }

        async void OnStudySelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {

            // We need to check if SelectedItem is null because further below we de-select the selected item.
            if (studies.SelectedItem == null)
                return;

            Study currentStudy = e.SelectedItem as Study;

            // We de-select the selected item, so when we come back to the Studies page we can tap it again and navigate to StudyDetail. 
            studies.SelectedItem = null;

            //// Creates page with reference to an existing Contact object
            var detailPage = new StudyDetail(currentStudy);

            await Navigation.PushAsync(detailPage);
        }

        async void OpenAboutPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AboutPage());
        }
    }
}
