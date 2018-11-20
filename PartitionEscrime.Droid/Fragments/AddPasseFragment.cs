
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using PartitionEscrime.Droid.Activities;

namespace PartitionEscrime.Droid.Fragments
{
    public class AddPasseFragment : DialogFragment
    {
        private TextView A;
        private TextView B;

        private int _row;

        public AddPasseFragment() : base()
        {
            _row = -1;
        }
        public AddPasseFragment(int row) : base()
        {
            _row = row;
        }

        public override Dialog OnCreateDialog(Bundle savedInstanceState)
        {
            AlertDialog.Builder builder = new AlertDialog.Builder(Activity);
            // Get the layout inflater
            LayoutInflater inflater = Activity.LayoutInflater;

            var view = inflater.Inflate(Resource.Layout.add_alert_layout, null);

            A = view.FindViewById<TextView>(Resource.Id.action_A);
            B = view.FindViewById<TextView>(Resource.Id.action_B);

            // Inflate and set the layout for the dialog
            // Pass null as the parent view because its going in the dialog layout
            builder.SetView(view)
                .SetPositiveButton("VALIDE", (s, e) =>
                {
                    ((PartitionDisplayActivity)Activity).AddPasse(A.Text, B.Text, _row);
                })
                .SetNegativeButton("ANNULE", (s, e) =>
                {
                    Dialog.Cancel();
                });

            return builder.Create();
        }
    }
}