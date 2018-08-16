using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace AppBug59184
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

            MainPage = new AppBug59184.MainPage();
		}

		protected override async void OnStart ()
		{
            // Handle when your app starts


            var dbConn = new DbContext();

            // Delete database if exists
            try
            {
                if (File.Exists(dbConn.DatabasePath))
                    File.Delete(dbConn.DatabasePath);
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", "Can't delete old database !\n\n" + ex.ToString(), "OK");
                return;
            }

            // Initialize database
            try
            {
                await dbConn.Database.MigrateAsync();
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", "Can't create new database !\n\n" + ex.ToString(), "OK");
                return;
            }

            // Insert data in OkNullableEntities
            try
            {
                await dbConn.OkNullableEntities.AddAsync(new Model.OkNullableEntity());
                await dbConn.SaveChangesAsync();
                await App.Current.MainPage.DisplayAlert("Success", "Adding data to OkNullableEntities (4 fields with nullable) : OK", "OK");
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Success", "Adding data to OkNullableEntities (4 fields with nullable) : ERROR\n\n" + ex.ToString(), "OK");
                return;
            }

            // Insert data in OkNotNullableEntities
            try
            {
                await dbConn.OkNotNullableEntities.AddAsync(new Model.OkNotNullableEntity());
                await dbConn.SaveChangesAsync();
                await App.Current.MainPage.DisplayAlert("Success", "Adding data to OkNullableEntities (14 fields without nullable) : OK", "OK");
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Success", "Adding data to OkNotNullableEntities (14 fields without nullable) : ERROR\n\n" + ex.ToString(), "OK");
                return;
            }

            // Insert data in BuggedNullableEntities
            try
            {
                await dbConn.BuggedNullableEntities.AddAsync(new Model.BuggedNullableEntity());
                await dbConn.SaveChangesAsync();
                await App.Current.MainPage.DisplayAlert("Success", "Adding data to BuggedNullableEntities (5 fields with nullable) : OK", "OK");
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Success", "Adding data to BuggedNullableEntities (5 fields with nullable) : ERROR\n\n" + ex.ToString(), "OK");
                return;
            }

            // Insert data in BuggedNotNullableEntities
            try
            {
                await dbConn.BuggedNullableEntities.AddAsync(new Model.BuggedNullableEntity());
                await dbConn.SaveChangesAsync();
                await App.Current.MainPage.DisplayAlert("Success", "Adding data to BuggedNotNullableEntities (15 fields without nullable) : OK", "OK");
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Success", "Adding data to BuggedNotNullableEntities (15 fields without nullable) : ERROR\n\n" + ex.ToString(), "OK");
                return;
            }
            // Insert data in BuggedLargerNullableEntities
            try
            {
                await dbConn.BuggedLargerNullableEntities.AddAsync(new Model.BuggedLargerNullableEntity());
                await dbConn.SaveChangesAsync();
                await App.Current.MainPage.DisplayAlert("Success", "Adding data to BuggedLargerNullableEntities (5 fields without nullable + 7 field with nullable) : OK", "OK");
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Success", "Adding data to BuggedLargerNullableEntities (5 fields without nullable + 7 field with nullable) : ERROR\n\n" + ex.ToString(), "OK");
                return;
            }
        }

        protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
