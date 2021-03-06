﻿using Android.Support.V7.Widget;
using Android.Views;
using PartitionEscrime.Common.Models;
using PartitionEscrime.Droid.ViewHolder;
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
            NotifyItemChanged(0);
        }

        public override int ItemCount
        {
            get { return _partition.Count; }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            PasseViewHolder vh = holder as PasseViewHolder;
            vh.A.Text = _partition[position].ActionA;
            vh.B.Text = _partition[position].ActionB;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).
                    Inflate(Resource.Layout.passe_view_holder, parent, false);
            PasseViewHolder vh = new PasseViewHolder(itemView);
            return vh;
        }
    }
}