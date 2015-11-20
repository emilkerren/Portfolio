using Android.Widget;
using System;
using System.Collections.Generic;
using Android.Views;
using System.Linq;
using Android.Content;

namespace KnowledgeMe.Droid
{
    public class MenuListAdapter : BaseAdapter<string>
    {
        private Context _context;
        private List<string> _mItems;

        //int[] _mnuUrl;
        //action event to pass selected menu item to main activity
        internal event Action<string> actionMenuSelected;
        public MenuListAdapter(Context context, List<string> mItems/*, int[] intImage*/)
        {
            _context = context;
            _mItems = mItems;
            //_mnuUrl = intImage;
        }
        public override string this[int position]
        {
            get { return this._mItems[position]; }
        }

        public override int Count
        {
            get { return this._mItems.Count(); }
        }

        public override long GetItemId(int position)
        {
            return position;
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            //MenuListViewHolder objMenuListViewHolderClass;
            View row = convertView;
            if (row == null)
            {
                row = LayoutInflater.From(_context).Inflate(Resource.Layout.Listview_row, null, false);
            }
            TextView txtView = row.FindViewById<TextView>(Resource.Id.txtName);
            txtView.Text = _mItems[position];
            return row;
        }
    }
        
    //Viewholder class
    /*internal class MenuListViewHolder : Object
    {
        internal Action viewClicked { get; set; }
        internal TextView txtMnuText;
        internal ImageView ivMenuImg;
        public void initialize(View view)
        {
            view.Click += delegate
            {
                viewClicked();
            };
        }

    }*/
}
