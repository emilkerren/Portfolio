using System;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
namespace KnowledgeMe.Droid
{
    [Activity(Label = "PreferenceActivity")]
    public class PreferenceActivity : Activity
    {
        private UserTestPreferences user;
        private Button startTestBtn;
        private Button gotoTestQuestionActivityBtn;
        private RadioGroup radioGrp;
        private RadioButton radio;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.StartPage);
            //user = new UserTestPreferences();
            // Create your application here

            /*if (Intent.Extras.ContainsKey("UserPref"))
             {
                 user = JsonConvert.DeserializeObject<UserTestPreferences> (Intent.GetStringExtra("UserPref"));
             }*/
            user = new UserTestPreferences();

            TextView langText = FindViewById<TextView>(Resource.Id.languageText);
            if (Intent.GetStringExtra("Language") != null)
                user.Language = Intent.GetStringExtra("Language");
                langText.Text = user.Language;

            radioGrp = FindViewById<RadioGroup>(Resource.Id.radioGroupDifficulty);
            //mTestPreferences.Difficulty = radio
            

            startTestBtn = FindViewById<Button>(Resource.Id.BtnStartTest);
            startTestBtn.Click += StartTestBtn_Click;

            gotoTestQuestionActivityBtn = FindViewById<Button>(Resource.Id.BtnGotoAddTestQuestionPage);
            gotoTestQuestionActivityBtn.Click += gotoTestQuestionBtn_Click;
        }

        private void gotoTestQuestionBtn_Click(object sender, EventArgs e)
        {
            radio = FindViewById<RadioButton>(radioGrp.CheckedRadioButtonId);
            user.Difficulty = radio.Text;

            Intent intent = new Intent(this, typeof(AddQuestionActivity));
            intent.PutExtra("Difficulty", user.Difficulty);
            intent.PutExtra("Language", user.Language);
            //intent.PutExtra("UserPref", JsonConvert.SerializeObject(user));
            StartActivity(intent);
        }

        private void StartTestBtn_Click(object sender, EventArgs e)
        {
            radio = FindViewById<RadioButton>(radioGrp.CheckedRadioButtonId);
            user.Difficulty = radio.Text;

            Intent intent = new Intent(this, typeof(TestActivity));
            intent.PutExtra("Difficulty", user.Difficulty);
            intent.PutExtra("Language", user.Language);
            //intent.PutExtra("UserPref", JsonConvert.SerializeObject(user));
            StartActivity(intent);
        }
    }
}