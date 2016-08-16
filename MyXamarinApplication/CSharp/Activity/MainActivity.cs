using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;

namespace MyXamarinApplication
{
    [Activity(Label = "MyXamarinApplication", Theme = "@style/PrimaryThemes", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : AppCompatActivity
    {
        int count = 1;
        private String strUsername, strPassword;

        EditText edtUsername, edtPassword;
        Button btnLogin;
     
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.ActivityMain);

            // Get our button from the layout resource,
            // and attach an event to it
            // Button button = FindViewById<Button>(Resource.Id.MyButton);
            edtUsername = FindViewById<EditText>(Resource.Id.edt_username);
            edtPassword = FindViewById<EditText>(Resource.Id.edt_password);
            btnLogin = FindViewById<Button>(Resource.Id.btn_login);
            

            //button.Click += delegate { button.Text = string.Format("{0} clicks!", count++); };
            btnLogin.Click += delegate
            {
                loginUser();                
            };
        }

        private void loginUser() {
            String username = "janet";
            String password = "regala";

            strUsername = edtUsername.Text.ToString();
            strPassword = edtPassword.Text.ToString();


            

            if ((String.IsNullOrEmpty(strUsername) || String.IsNullOrEmpty(strPassword)) ||
                (String.IsNullOrEmpty(strUsername) && (String.IsNullOrEmpty(strPassword)))){
                Toast.MakeText(this, "Both fields cannot be empty", ToastLength.Short).Show();
            }
            else if (strUsername != username)
            {
                Toast.MakeText(this, "Username is incorrect!", ToastLength.Short).Show();
            }

            else if (strPassword != password)
            {
                Toast.MakeText(this, "Password is incorrect!", ToastLength.Short).Show();
            }
          
            else
            {
                var intent = new Intent(this, typeof(MainScreenActivity));
                intent.PutExtra("userData", strUsername);
                StartActivity(intent);
            }
        }
    }
}

