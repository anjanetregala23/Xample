using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Android.Util;

namespace MyXamarinApplication.CSharp.Class
{

    public class MyAlarmReceiver 
        
    {
       /* public override void OnReceive(Context context, Intent intent)
        {
           var myAlarmIntent = new Intent
        }*/

        public void showNotification(string message, string title) {

            Intent alarmIntent = new Intent(Forms.Context, typeof(SettingsActivity));
            alarmIntent.PutExtra("message", message);
            alarmIntent.PutExtra("title", title);

            Log.Debug("MyAlarmReceiver", "alarmIntetn values : " + alarmIntent);

            PendingIntent pendingIntent = PendingIntent.GetBroadcast(Forms.Context, 0, alarmIntent, PendingIntentFlags.UpdateCurrent);
            AlarmManager alarmManager = (AlarmManager)Forms.Context.GetSystemService(Context.AlarmService);

            alarmManager.Set(AlarmType.RtcWakeup, DateTime.Now.Millisecond + 10000, pendingIntent);

        }
    }
}

/* [Service]
[IntentFilter(new[] { MyService.ToUploadCountNotification })]
public class MyService : IntentService
{
    public const string ToUploadCountNotification = "MyService.ToUploadCountNotification";
    public const string ToUploadCount = "MyService.ToUploadCount";

    protected override void OnHandleIntent(Intent intent)
    {
        while (Count > 0)
        {
            var uploadCount = new Intent();
            uploadCount.SetAction(ToUploadCountNotification);
            uploadCount.PutExtra(ToUploadCount, localHarryys.Count);
            Log.Debug("Sync service", "sending broadcast");
            SendBroadcast(intent, null);
        }
    }
}

public class MyServiceBroadcastReceiver : BroadcastReceiver
{
    public override void OnReceive(Context context, Intent intent)
    {
        //throw new NotImplementedException();
        Toast.MakeText(context,
                       string.Format("Uploading...({0})", intent.Extras.GetInt(MyService.ToUploadCount)),
                       ToastLength.Short).Show();
    }
} */
