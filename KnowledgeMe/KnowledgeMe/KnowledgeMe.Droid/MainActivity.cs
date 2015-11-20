
using Android.App;
using Android.Content;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
//using KnowledgeMe.Droid.Views;

namespace KnowledgeMe.Droid
{
    [Activity(Label = "KnowledgeMe.Droid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        //int count = 1;
        private ListView mListView;
        private MyClass mClass;
        private List<string> mListItems;
        private UserTestPreferences mTestPreferences;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            mClass = new MyClass();
            mTestPreferences = new UserTestPreferences();

            mListItems = mClass.MenuItems();
            // Set our view from the "main" layout resource

            /*FragmentTransaction transaction = FragmentManager.BeginTransaction();
            SlidingTabsFragment fragment = new SlidingTabsFragment();
            transaction.Replace(Resource.Id.sample_content_fragment, fragment);
            transaction.Commit();*/
            
            mListView = FindViewById<ListView>(Resource.Id.menuListView);
            MenuListAdapter mListAdaptor = new MenuListAdapter(this, mListItems);
            // Get our button from the layout resource,
            // and attach an event to it
            mListView.Adapter = mListAdaptor;
            mListView.ItemClick += MListView_ItemClick;

            /*  Button button = FindViewById<Button> (Resource.Id.menuListView);
              button.Click += delegate
              {
                  button.Text = _class.IncreaseCount();
              };
                  button.Click += delegate {
                      button.Text = string.Format ("{0} click!", count++);
                  };
                }*/
            
        }
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            //MenuInflater.Inflate(Resource.Menu.actionbar_main_menu);
            return base.OnCreateOptionsMenu(menu);
        }
        private void MListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            //Console.WriteLine("you clicked: " + mListItems[e.Position]);
            Intent intent = new Intent(this, typeof(PreferenceActivity));
            mTestPreferences.Language = mListItems[e.Position].ToUpper().ToString();
            //intent.PutExtra("UserPref", JsonConvert.SerializeObject( mTestPreferences));
            intent.PutExtra("Language",  mTestPreferences.Language);
            StartActivity(intent);
            
        }
        
    }
}


