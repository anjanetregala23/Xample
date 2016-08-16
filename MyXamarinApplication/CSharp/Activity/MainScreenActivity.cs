using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;


using V7Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Support.V7.App;
using Android.Support.V4.Widget;
using Android.Support.Design.Widget;
using Android.Widget;
using Android.Util;
using Android.Support.V4.App;
using MyXamarinApplication.Resources;
using System.Collections.Generic;
using System;

namespace MyXamarinApplication
{
    [Activity(Label = "MainScreen", Theme = "@style/Theme.DesignDemo")]
    public class MainScreenActivity : AppCompatActivity
    {
        string strUsernameData;
        DrawerLayout drawerLayout;
        NavigationView navigationView;
        MyActionBarDrawerToggle drawerToggle;
        ListView leftDrawer;
        ArrayAdapter leftAdapter;
        List<string> leftDataSet;
        TextView tvHome, tvLogout, tvUsername;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ActivityMainScreen);

            var toolbar = FindViewById<V7Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetDisplayShowTitleEnabled(false);
            SupportActionBar.SetHomeButtonEnabled(true);

            drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            //navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            leftDrawer = FindViewById<ListView>(Resource.Id.left_drawer);

            tvUsername = FindViewById<TextView>(Resource.Id.tv_username);
            leftDataSet = new List<string>();
            leftDataSet.Add("Home");        //0
            leftDataSet.Add("About");       //1
            leftDataSet.Add("Settings");    //2
            leftDataSet.Add("Notification");//3
            leftDataSet.Add("Logout");      //4
            leftAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, leftDataSet);
            leftDrawer.Adapter = leftAdapter;
            leftDrawer.ItemClick += MenuListView_ItemClick;

       
            /* tvHome = FindViewById<TextView>(Resource.Id.menu_home);
             tvLogout = FindViewById<TextView>(Resource.Id.menu_logout);
             tvLogout.Click += delegate
             {
                 alertDialog();
             */

            // Create your application here
            strUsernameData = Intent.GetStringExtra("userData");
            Log.Debug("Log", "strUsernameData : " + strUsernameData);

            // tvUsername.Text = strUsernameData;
            // Log.Debug("Log", "tvUsername : " + tvUsername);

           drawerToggle = new MyActionBarDrawerToggle(
                this, 
                drawerLayout, 
                Resource.String.navigation_drawer_open, 
                Resource.String.navigation_drawer_close
                );

            drawerLayout.SetDrawerListener(drawerToggle);
            SupportActionBar.SetHomeButtonEnabled(true);
            SupportActionBar.SetDisplayShowTitleEnabled(true);
            SupportActionBar.SetTitle(Resource.String.home);
            drawerToggle.SyncState();

            if (savedInstanceState != null)
            {
                if (savedInstanceState.GetString("DrawerState") == "Opened")
                {
                    SupportActionBar.SetTitle(Resource.String.navigation_drawer_open);
                }

                else
                {
                    SupportActionBar.SetTitle(Resource.String.navigation_drawer_close);
                }
            }

         /*  else
            {
                //This is the first the time the activity is ran
                SupportActionBar.SetTitle(Resource.String.navigation_drawer_close);
            }*/
        }

        private void MenuListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
           
            switch (e.Id) {
                case 0:
                    break;
                case 1:
                    StartActivity(new Intent(this, typeof(AboutActivity)));
                    break;
                case 2:
                    StartActivity(new Intent(this, typeof(SettingsActivity)));
                    break;
                case 4:
                    alertDialog();
                    break;
            }
           // throw new NotImplementedException();
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {

                case Android.Resource.Id.Home:
                    //The hamburger icon was clicked which means the drawer toggle will handle the event
                    //all we need to do is ensure the right drawer is closed so the don't overlap
                    //drawerLayout.CloseDrawer(mRightDrawer);
                    drawerToggle.OnOptionsItemSelected(item);
                    return true;

                case Resource.Id.nav_home:
                    OnNavigationItemSelected(item);
                    //Refresh
                    return true;
                case Resource.Id.nav_messages:
                    break;
                case Resource.Id.nav_about:
                    StartActivity(new Intent(this, typeof(AboutActivity)));
                    break;
                case Resource.Id.nav_feedBack:
                    break;            

                default:
                    return base.OnOptionsItemSelected(item);
            }
            return base.OnOptionsItemSelected(item);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.main_menu, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        protected override void OnSaveInstanceState(Bundle outState)
        {
            if (drawerLayout.IsDrawerOpen((int)GravityFlags.Left))
            {
                outState.PutString("DrawerState", "Opened");
            }

            else
            {
                outState.PutString("DrawerState", "Closed");
            }

            base.OnSaveInstanceState(outState);
        }

        protected override void OnPostCreate(Bundle savedInstanceState)
        {
            base.OnPostCreate(savedInstanceState);
            drawerToggle.SyncState();
        }

        public override void OnConfigurationChanged(Android.Content.Res.Configuration newConfig)
        {
            base.OnConfigurationChanged(newConfig);
            drawerToggle.OnConfigurationChanged(newConfig);
        }
    


   /* public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId) {
                case Android.Resource.Id.Home:
                    drawerLayout.OpenDrawer(Android.Support.V4.View.GravityCompat.Start);
                    return true;
                
            }
            return base.OnOptionsItemSelected(item);
        }*/

        private void alertDialog() {
            Log.Debug("Log", "Alert Dialog !!!");
            Android.Support.V7.App.AlertDialog.Builder alert = new Android.Support.V7.App.AlertDialog.Builder(this);
            alert.SetTitle("Logout");
            alert.SetMessage("Are you sure you want to log out?");
            alert.SetPositiveButton("Logout", (senderAlert, args) =>
            {
                StartActivity(new Intent(this, typeof(MainActivity)));
            });
            alert.SetNegativeButton("Cancel", (senderAlert, args) =>
            {
                alert.SetCancelable(true);
            });

            Dialog dialog = alert.Create();
            dialog.Show();
        }

        public bool OnNavigationItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            var toolbar = FindViewById<V7Toolbar>(Resource.Id.toolbar);
            if (id == Resource.Id.nav_about)
            {
                StartActivity(new Intent(this, typeof(AboutActivity)));
                SetSupportActionBar(toolbar);

                drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
                drawerToggle = new MyActionBarDrawerToggle(
                this,
                drawerLayout,
                Resource.String.navigation_drawer_open,
                Resource.String.navigation_drawer_close
                );

                drawerLayout.SetDrawerListener(drawerToggle);
                drawerToggle.SyncState();
               // selectDrawerMenu(id);

            }

            
                drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
                drawerLayout.CloseDrawers();         
                return true;
        }

        private void selectDrawerMenu(int id)
        {
            switch (id)
            {
                case Resource.Id.nav_home:
                    break;
                case Resource.Id.nav_about:
                    StartActivity(new Intent(this, typeof(AboutActivity)));
                    break;
                case Resource.Id.nav_messages:
                   // startActivity(new Intent(this, MapActivity.class));
                    break;
                case Resource.Id.nav_feedBack:
                    break;
               
                default:
                    break;
              }
        }


    }
}