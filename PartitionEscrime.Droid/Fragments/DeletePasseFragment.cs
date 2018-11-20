
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using PartitionEscrime.Droid.Activities;

namespace PartitionEscrime.Droid.Fragments
{
    public class DeletePasseFragment : DialogFragment
    {
        private int _row;

        public DeletePasseFragment(int row) : base()
        {
            _row = row;
        }

        public override Dialog OnCreateDialog(Bundle savedInstanceState)
        {
            AlertDialog.Builder builder = new AlertDialog.Builder(Activity);
            // Get the layout inflater
            LayoutInflater inflater = Activity.LayoutInflater;

            var view = inflater.Inflate(Resource.Layout.delete_alert_layout, null);

            // Inflate and set the layout for the dialog
            // Pass null as the parent view because its going in the dialog layout
            builder.SetView(view)
                .SetPositiveButton("VALIDE", (s, e) =>
                {
                    ((PartitionDisplayActivity)Activity).DeletePasse(_row);
                })
                .SetNegativeButton("ANNULE", (s, e) =>
                {
                    Dialog.Cancel();
                });

            return builder.Create();
        }
    }
}