using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using PartitionEscrime.Common.ViewModels;
using Android.Content;
using PartitionEscrime.Droid.Activities;

namespace PartitionEscrime.Droid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private Button _partition;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            _partition = FindViewById<Button>(Resource.Id.ToPartition);
            _partition.Click += ToPartitionClick;
        }

        private void ToPartitionClick(object sender, System.EventArgs e)
        {
            var intent = new Intent(this, typeof(PartitionDisplayActivity));

            StartActivity(intent);
        }
    }
}