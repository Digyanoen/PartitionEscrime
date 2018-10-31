using Android.App;
using Android.Graphics;
using Android.OS;
using Android.Support.V7.Widget;
using PartitionEscrime.Common.ViewModels;
using PartitionEscrime.Droid.Adapters;

namespace PartitionEscrime.Droid.Activities
{
    [Activity(Label = "PartitionDisplay")]
    public class PartitionDisplayActivity : Activity
    {
        private PartitionViewModel _vm;
        private RecyclerView _partition;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            _vm = new PartitionViewModel();
            SetContentView(Resource.Layout.partition_display);

            _partition = FindViewById<RecyclerView>(Resource.Id.partition);
            var adapter = new PartitionAdapter(_vm.Partition);
            _partition.SetAdapter(adapter);
            _partition.SetLayoutManager(new LinearLayoutManager(this));
        }
    }
}