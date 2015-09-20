using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Graphics;

namespace Com.Changmin.HI5Controller.src
{
	class WcdListAdapter : BaseAdapter<WeldConditionData>
	{
		private List<WeldConditionData> mItems;
		private Context mContent;

		private readonly Color defaultBackgroundColor = Color.Transparent;
		private Color selectedBackGroundColor = Color.LightGray;

		public WcdListAdapter(Context context, List<WeldConditionData> items)
		{
			mItems = items;
			mContent = context;
			selectedBackGroundColor = Color.ParseColor("#F48FB1");
		}

		public override WeldConditionData this[int position]
		{
			get
			{
				return mItems[position];
			}
		}

		public override int Count
		{
			get
			{
				return mItems.Count;
			}
		}

		public override long GetItemId(int position)
		{
			return position;
		}

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			View row = convertView;

			if (row == null) {
				row = LayoutInflater.From(mContent).Inflate(Resource.Layout.WcdListRow, null, false);
			}

			if (mItems[position].ItemChecked) {
				row.SetBackgroundColor(selectedBackGroundColor);
			} else {
				row.SetBackgroundColor(defaultBackgroundColor);
			}

			TextView tvOutputData = row.FindViewById<TextView>(Resource.Id.tvOutputData);
			tvOutputData.Text = mItems[position].OutputData;

			TextView tvOutputType = row.FindViewById<TextView>(Resource.Id.tvOutputType);
			tvOutputType.Text = mItems[position].OutputType;

			TextView tvSqueezeForce = row.FindViewById<TextView>(Resource.Id.tvSqueezeForce);
			tvSqueezeForce.Text = mItems[position].SqueezeForce;

			TextView tvMoveTipClearance = row.FindViewById<TextView>(Resource.Id.tvMoveTipClearance);
			tvMoveTipClearance.Text = mItems[position].MoveTipClearance;

			TextView tvFixedTipClearance = row.FindViewById<TextView>(Resource.Id.tvFixedTipClearance);
			tvFixedTipClearance.Text = mItems[position].FixedTipClearance;

			TextView tvPannelThickness = row.FindViewById<TextView>(Resource.Id.tvPannelThickness);
			tvPannelThickness.Text = mItems[position].PannelThickness;

			TextView tvCommandOffset = row.FindViewById<TextView>(Resource.Id.tvCommandOffset);
			tvCommandOffset.Text = mItems[position].CommandOffset;

			return row;
		}
	}
}