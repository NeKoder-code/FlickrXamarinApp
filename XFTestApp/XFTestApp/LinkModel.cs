using System.ComponentModel;

namespace XFTestApp
{
    class LinkModel: INotifyPropertyChanged
    {
        string link;

        public event PropertyChangedEventHandler PropertyChanged;


        public string Link
        {
            set
            {
                if (link != value)
                {
                    link = value;

                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Name"));
                }
            }
            get
            {
                return link;
            }
        }
    }
}
