using ReactiveUI;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace XamarinWithoutXaml
{
    public class PersonViewModel :
        ReactiveObject
    //INotifyPropertyChanged
    {
        private int _id;
        private string _name;
        private int _age;

        public PersonViewModel()
        {
            Id = 1;
            Name = "张三";
            Age = 18;
        }

        public int Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public int Age
        {
            get => _age;
            set => SetProperty(ref _age, value);
        }

        #region ReactiveUI
        public void SetProperty<T>(ref T t, T value, [CallerMemberName] string propertyName = "")
        {
            this.RaiseAndSetIfChanged(ref t, value, propertyName);
        }
        #endregion

        #region Normal
        //public event PropertyChangedEventHandler PropertyChanged;
        //public void SetProperty<T>(ref T t, T value, [CallerMemberName] string propertyName = "")
        //{
        //    if (Equals(t, value))
        //    {
        //        return;
        //    }
        //    t = value;
        //    if (null == PropertyChanged)
        //    {
        //        return;
        //    }
        //    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        //}
        #endregion
    }
}