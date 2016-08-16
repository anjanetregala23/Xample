
using Android.App;

using Android.OS;

using Android.Views;
using Android.Widget;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using V7Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Content;
using System;
using Android.Support.V4.App;
using Android.Util;
using MyXamarinApplication.CSharp.Class;

namespace MyXamarinApplication
{
    [Activity(Label = "Settings", Theme = "@style/Theme.DesignDemo")]
    public class SettingsActivity : AppCompatActivity
    {

        Button btnSettings;
        public MyAlarmReceiver myAlarmReceiver;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ActivitySettings);

            var toolbar = FindViewById<V7Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            SupportActionBar.SetTitle(Resource.String.settings);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetDisplayShowTitleEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);

            btnSettings = FindViewById<Button>(Resource.Id.btnSettings);
         
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {

            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    OnBackPressed();
                    break;
            }
            return base.OnOptionsItemSelected(item);
        }

    }

    public class AlarmReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            var message = intent.GetStringExtra("message");
            var title = intent.GetStringExtra("title");

            var notIntent = new Intent(context, typeof(MyAlarmReceiver));
            var contentIntent = PendingIntent.GetActivity(context, 0, notIntent, PendingIntentFlags.CancelCurrent);
            var manager = NotificationManagerCompat.From(context);

            var style = new Android.Support.V4.App.NotificationCompat.BigTextStyle();
            style.BigText(message);

            Log.Debug("SettingActivity", "message : " + message);
            Log.Debug("SettingActivity", "title : " + title);

            //Generate a notification with just short text and small icon
            var builder = new Android.Support.V4.App.NotificationCompat.Builder(context)
                .SetContentIntent(contentIntent)
                .SetSmallIcon(Resource.Drawable.Icon)
                .SetContentTitle(title)
                .SetContentText(message)
                .SetStyle(style)
                .SetWhen(Java.Lang.JavaSystem.CurrentTimeMillis())
                .SetAutoCancel(true);

            var notification = builder.Build();
            manager.Notify(0, notification);
            throw new NotImplementedException();
        }
    }
}

/*protected override IntentFilter Filter {
            get {
                var filter = new IntentFilter (Intent.ActionPowerConnected);
                filter.AddAction (Intent.ActionPowerDisconnected);
                return filter;
            }
        }

        public override void OnReceive (Context context, Intent intent)
        {
            this.battery.Charging = intent.Action.Equals (Intent.ActionPowerConnected);
        }
        
     
    ////////////////////////////////////////////////////////
    
    
   
     
     
     

     */

