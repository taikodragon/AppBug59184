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

            // Insert data
            try
            {
                await dbConn.NullableEntities.AddAsync(new Model.NullableEntity());
                await dbConn.NullableEntities.AddAsync(new Model.NullableEntity());
                await dbConn.NullableEntities.AddAsync(new Model.NullableEntity());
                await dbConn.NullableEntities.AddAsync(new Model.NullableEntity());
                await dbConn.NullableEntities.AddAsync(new Model.NullableEntity());
                await dbConn.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", "Can't insert data !\n\n" + ex.ToString(), "OK");
                return;
            }

            // Read data
            try
            {
                var x = await dbConn.Database.ExecuteSqlCommandAsync(new RawSqlString("SELECT COUNT(*) FROM NullableEntities"));
                await App.Current.MainPage.DisplayAlert("Success", "Row count = " + x.ToString(), "OK");
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", "Can't read data !\n\n" + ex.ToString(), "OK");
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
