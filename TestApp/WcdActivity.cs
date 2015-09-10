﻿using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Graphics;
using Android.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using Android.Util;
using Java.Util;
using Android.Support.V7.App;
using Android.Support.Design.Widget;
using AlertDialog = Android.Support.V7.App.AlertDialog;
using com.xamarin.recipes.filepicker;
using Android.Support.V4.App;
using System.Text;

namespace HI5Controller
{
	[Activity(Label = "@string/ApplicationName", MainLauncher = true, Icon = "@drawable/robot_industrial", Theme = "@style/MyCustomTheme")]
	public class WcdActivity : AppCompatActivity
	{
		public static string path = string.Empty;

		private EditText dirPath;
		private Button folderPickerButton;
		private Button wcdListViewButton;
		private Button wcdTextButton;

		private void ToastShow(string str)
		{
			Toast.MakeText(this, str, ToastLength.Short).Show();
		}

		protected override void OnCreate(Bundle bundle)
		{
			//Window.RequestFeature(WindowFeatures.NoTitle);
			//Window.AddFlags(WindowManagerFlags.Fullscreen);
			//Window.ClearFlags(WindowManagerFlags.Fullscreen);

			base.OnCreate(bundle);
			SetContentView(Resource.Layout.Wcd);

			EditText dirPath = FindViewById<EditText>(Resource.Id.dirPathTextView);
			dirPath.TextChanged += (sender, e) =>
			{
				WcdActivity.path = e.Text.ToString();
			};

			folderPickerButton = FindViewById<Button>(Resource.Id.folderPickerButton);
			folderPickerButton.Click += (sender, e) =>
			{
				var intent = new Intent(this, typeof(FilePickerActivity));
				//intent.PutExtra("dir_path", WcdActivity.path);
				StartActivityForResult(intent, 1);
			};

			wcdListViewButton = FindViewById<Button>(Resource.Id.button1);
			wcdListViewButton.Click += (sender, e) =>
			{
				var intent = new Intent(this, typeof(WcdListViewActivity));
				intent.PutExtra("dir_path", WcdActivity.path);
				StartActivity(intent);
			};

			wcdTextButton = FindViewById<Button>(Resource.Id.button2);
			wcdTextButton.Click += (sender, e) =>
			{
				var intent = new Intent(this, typeof(WcdTextViewActivity));
				intent.PutExtra("dir_path", WcdActivity.path);
				StartActivity(intent);
			};

			try {
				//using (var sr = new StreamReader(OpenFileInput("dirpath_file"))) {
				//	WcdActivity.path = sr.ReadToEnd();
				//	sr.Close();
				//	dirPath.Text = WcdActivity.path;
				//}
				using (var prefs = Application.Context.GetSharedPreferences(Application.PackageName, FileCreationMode.Private)) {
					dirPath.Text = prefs.GetString("dirpath_file", string.Empty);
				}
			} catch {
				dirPath.Text = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath;
				Toast.MakeText(this, path, ToastLength.Short).Show();
			}
		}

		protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
		{
			base.OnActivityResult(requestCode, resultCode, data);
			if (resultCode == Result.Ok) {
				if (requestCode == 1) {
					dirPath.Text = data.GetStringExtra("dir_path") ?? path;
					ToastShow(resultCode.ToString() + ", " + requestCode.ToString());
				}
			} else {
				dirPath.Text = path;
			}
			ToastShow(path);
		}
	}
}
