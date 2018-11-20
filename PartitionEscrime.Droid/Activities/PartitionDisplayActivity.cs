using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using PartitionEscrime.Common.ViewModels;
using PartitionEscrime.Droid.Adapters;
using PartitionEscrime.Droid.Fragments;
using System;

namespace PartitionEscrime.Droid.Activities
{
    [Activity(Label = "PartitionDisplay", ScreenOrientation = ScreenOrientation.Landscape)]
    public class PartitionDisplayActivity : Activity
    {
        private PartitionViewModel _vm;
        private RecyclerView _partition;
        private Button _addButton;
        private Button _insertButton;
        private Button _removeButton;
        private PartitionAdapter Adapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            _vm = new PartitionViewModel();
            SetContentView(Resource.Layout.partition_display);

            _partition = FindViewById<RecyclerView>(Resource.Id.partition);
            Adapter = new PartitionAdapter(_vm.Partition);
            Adapter.SelectionChanged += Adapter_SelectionChanged;
            _partition.SetAdapter(Adapter);
            _partition.SetLayoutManager(new LinearLayoutManager(this));

            _addButton = FindViewById<Button>(Resource.Id.add_button);
            _insertButton = FindViewById<Button>(Resource.Id.insert_button);
            _removeButton = FindViewById<Button>(Resource.Id.remove_button);

            _addButton.Click += AddPasse;
            _insertButton.Click += InsertPasse;
            _removeButton.Click += DeletePasse;
        }

        private void Adapter_SelectionChanged(object sender, EventArgs e)
        {
            if (Adapter.ItemSelected == -1)
            {
                _insertButton.Visibility = ViewStates.Gone;
                _removeButton.Visibility = ViewStates.Gone;
            }
            else
            {
                _insertButton.Visibility = ViewStates.Visible;
                _removeButton.Visibility = ViewStates.Visible;
            }
        }

        private void AddPasse(object sender, EventArgs e)
        {
            new AddPasseFragment().Show(FragmentManager, "add");
        }

        private void InsertPasse(object sender, EventArgs e)
        {
            new AddPasseFragment(Adapter.ItemSelected).Show(FragmentManager, "add");
        }

        private void DeletePasse(object sender, EventArgs e)
        {
            new DeletePasseFragment(Adapter.ItemSelected).Show(FragmentManager, "delete");
        }

        public void AddPasse(string A, string B, int row)
        {
            if (row < 0 || row > _vm.Partition.Count) { row = _vm.Partition.Count; }
            _vm.Partition.Insert(row, new Common.Models.Passe()
            {
                ActionA = A,
                ActionB = B
            });

            Adapter.NotifyDataSetChanged();
        }

        public void DeletePasse(int row)
        {
            if (row < 0 || row > _vm.Partition.Count) { row = _vm.Partition.Count; }
            _vm.Partition.RemoveAt(row);

            Adapter.NotifyDataSetChanged();
        }
    }
}