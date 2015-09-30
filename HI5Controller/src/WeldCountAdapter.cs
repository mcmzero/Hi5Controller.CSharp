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
using Java.Lang;

namespace Com.Changyoung.HI5Controller
{
	class WeldCountAdapter : ArrayAdapter<JobFile>
	{
		public WeldCountAdapter(Context context, int textViewResourceId) : base(context, textViewResourceId)
		{
		}

		public WeldCountAdapter(IntPtr handle, JniHandleOwnership transfer) : base(handle, transfer)
		{
		}

		public WeldCountAdapter(Context context, int textViewResourceId, IList<JobFile> objects) : base(context, textViewResourceId, objects)
		{
		}

		public WeldCountAdapter(Context context, int textViewResourceId, JobFile[] objects) : base(context, textViewResourceId, objects)
		{
		}

		public WeldCountAdapter(Context context, int resource, int textViewResourceId) : base(context, resource, textViewResourceId)
		{
		}

		public WeldCountAdapter(Context context, int resource, int textViewResourceId, IList<JobFile> objects) : base(context, resource, textViewResourceId, objects)
		{
		}

		public WeldCountAdapter(Context context, int resource, int textViewResourceId, JobFile[] objects) : base(context, resource, textViewResourceId, objects)
		{
		}

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			View row;
			WeldCountRowViewHolder viewHolder;

			if (convertView == null) {
				row = LayoutInflater.From(Context).Inflate(Resource.Layout.WeldCountRow, null, false);
				viewHolder = new WeldCountRowViewHolder(row);
				row.Tag = viewHolder;
			} else {
				row = convertView;
				viewHolder = (WeldCountRowViewHolder)row.Tag;
			}

			viewHolder.Update(GetItem(position));

			return row;
		}
	}
}