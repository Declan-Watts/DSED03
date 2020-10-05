using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Widget;
using DSED03.Data;
using System;
using System.Collections.Generic;

namespace DSED03
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Button btnPlay;
        EditText nameEditText;

        List<Users> activeUser;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            Init();
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        private void Init()
        {
            //Checking if User is Logged In
            activeUser = Database.LoadActiveUser();

            if (activeUser.Count < 1)
            {
                btnPlay = FindViewById<Button>(Resource.Id.btnPlay);
                nameEditText = FindViewById<EditText>(Resource.Id.nameEditText);
                btnPlay.Click += btnPlay_Click;
            }
            else
            {
                var hangManActivity = new Intent(this, typeof(HangManActivity));
                hangManActivity.PutExtra("Name", activeUser[0].username);
                StartActivity(hangManActivity);
                Finish();
            }


        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (nameEditText.Text != "")
            {
                activeUser = Database.loginActiveUser(nameEditText.Text);
                var hangManActivity = new Intent(this, typeof(HangManActivity));
                hangManActivity.PutExtra("Name", activeUser[0].username);
                StartActivity(hangManActivity);
            }
            else
            {
                Toast.MakeText(this, "Mate, do you have a name or not?", ToastLength.Long).Show();
            }
        }
    }
}