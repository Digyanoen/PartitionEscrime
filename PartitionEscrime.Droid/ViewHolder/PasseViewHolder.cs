using System;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace PartitionEscrime.Droid.ViewHolder
{
    public class PasseViewHolder : RecyclerView.ViewHolder
    {
        public TextView A { get; private set; }
        public TextView B { get; private set; }

        public PasseViewHolder(View itemView) : base(itemView)
        {
            A = itemView.FindViewById<TextView>(Resource.Id.GesteA);
            B = itemView.FindViewById<TextView>(Resource.Id.GesteB);
        }
    }
}