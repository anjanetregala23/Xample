

using Android.App;
using Android.OS;
using Android.Views;
using Android.Support.V7.App;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using V7Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Support.V4.App;

namespace MyXamarinApplication.Resources
{
    [Activity(Label = "About", Theme = "@style/Theme.DesignDemo")]
    public class AboutActivity : AppCompatActivity
    {

        private TabLayout tabLayout;
        private ViewPager viewPager;
        private Explore exploreFrg;
        private Featured featuredFrg;
        private More moreFrg;
        private Todo todoFrg;

        private int[] tabIcons = { Resource.Drawable.explore_black, Resource.Drawable.featured_play_black, Resource.Drawable.favorite_black, Resource.Drawable.more_black};
        
        

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.ActivityAbout);

            var toolbar = FindViewById<V7Toolbar>(Resource.Id.toolbar);

            SetSupportActionBar(toolbar);
            SupportActionBar.SetTitle(Resource.String.about);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetDisplayShowTitleEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);

            tabLayout = FindViewById<TabLayout>(Resource.Id.slidingTabs);
            viewPager = FindViewById<ViewPager>(Resource.Id.viewPager);
            setupViewPager(viewPager);

            tabLayout.SetupWithViewPager(viewPager);
            setupTabIcons();

        }

       
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item) {

            switch (item.ItemId) {
                case Android.Resource.Id.Home:
                    OnBackPressed();
                    break;
            }
            return base.OnOptionsItemSelected(item);
        }

        private void setupTabIcons()
        {
            tabLayout.GetTabAt(0).SetIcon(tabIcons[0]);
            tabLayout.GetTabAt(1).SetIcon(tabIcons[1]);
            tabLayout.GetTabAt(2).SetIcon(tabIcons[2]);
            tabLayout.GetTabAt(3).SetIcon(tabIcons[3]);
        }         

        private void InditialFragment()
        {
            exploreFrg = new Explore();
            featuredFrg = new Featured();
            moreFrg = new More();
            todoFrg = new Todo();
        }
        public void setupViewPager(ViewPager viewPager)
        {
            InditialFragment();
            ViewPagerAdapter adapter = new ViewPagerAdapter(SupportFragmentManager);
            // adapter.addFragment(exploreFrg, "Explore");
            // adapter.addFragment(featuredFrg, "Featured");
            // adapter.addFragment(todoFrg, "Favorite");
            // adapter.addFragment(moreFrg, "More");

            adapter.addFragmentIconOnly(exploreFrg);
            adapter.addFragmentIconOnly(featuredFrg);
            adapter.addFragmentIconOnly(todoFrg);
            adapter.addFragmentIconOnly(moreFrg);

            viewPager.Adapter = adapter;
        }


    }







}