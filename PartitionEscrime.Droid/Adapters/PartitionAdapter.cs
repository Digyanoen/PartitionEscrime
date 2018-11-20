using Android.Graphics;
using Android.Support.V7.Widget;
using Android.Views;
using PartitionEscrime.Common.Models;
using PartitionEscrime.Droid.ViewHolder;
using System;
using System.Collections.Generic;

namespace PartitionEscrime.Droid.Adapters
{
    public class PartitionAdapter : RecyclerView.Adapter
    {
        private int _nbEscrimeur;

        private List<Passe> _partition;

        public PartitionAdapter(List<Passe> partition)
        {
            _partition = partition;
            _nbEscrimeur = 2;
            ItemSelected = -1;
            NotifyItemChanged(0);
        }

        public override int ItemCount
        {
            get { return _partition.Count; }
        }

        public int ItemSelected { get; private set; }

        public event EventHandler SelectionChanged;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            PasseViewHolder vh = holder as PasseViewHolder;
            vh.A.Text = _partition[position].ActionA;
            vh.B.Text = _partition[position].ActionB;

            if(position == ItemSelected)
            {
                vh.ItemView.SetBackgroundColor(Color.Rgb(0, 0, 250));
            }
            else
            {
                vh.ItemView.SetBackgroundColor(Color.Rgb(250, 250, 250));
            }
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).
                    Inflate(Resource.Layout.passe_view_holder, parent, false);
            PasseViewHolder vh = new PasseViewHolder(itemView);

            vh.ItemClick += Vh_ItemClick;

            return vh;
        }

        private void Vh_ItemClick(object sender, EventArgs e)
        {
            var vh = (PasseViewHolder)sender;

            var tmp = ItemSelected;
            if (ItemSelected == vh.AdapterPosition)
            {
                ItemSelected = -1;
            }
            else
            {
                ItemSelected = vh.AdapterPosition;
            }

            NotifyItemChanged(tmp);
            NotifyItemChanged(ItemSelected);

            SelectionChanged?.Invoke(this, e);
        }
    }
}