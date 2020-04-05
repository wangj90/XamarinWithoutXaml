using ReactiveUI;
using ReactiveUI.XamForms;
using System;
using Xamarin.Forms;

namespace XamarinWithoutXaml
{
    public class MainPage :
        ReactiveContentPage<PersonViewModel>
    //ContentPage
    {

        private readonly Editor editorId = new Editor();
        private readonly Label labelId = new Label();
        private readonly Editor editorName = new Editor();
        private readonly Label labelName = new Label();
        private readonly Editor editorAge = new Editor();
        private readonly Label labelAge = new Label();
        public MainPage()
        {
            Content = new StackLayout
            {
                Margin = new Thickness(30),
                Children =
                    {
                        new Grid
                        {
                            RowDefinitions =
                            {
                                new RowDefinition(),
                                new RowDefinition(),
                                new RowDefinition()
                            },
                            ColumnDefinitions =
                            {
                                new ColumnDefinition(),
                                new ColumnDefinition()
                            },
                            Children =
                            {
                                { editorId, 0, 0},
                                { labelId, 1, 0},
                                { editorName, 0, 1},
                                { labelName, 1, 1},
                                { editorAge, 0, 2},
                                { labelAge, 1, 2},
                            }
                        }
                    }
            };
            #region ReactiveUI
            this.WhenActivated(a =>
            {
                a(this.Bind(ViewModel, vm => vm.Id, v => v.editorId.Text, vmp => Convert.ToString(vmp), vp =>
                {
                    if (int.TryParse(vp, out int result))
                    {
                        return result;
                    }
                    return default;
                }));
                a(this.OneWayBind(ViewModel, vm => vm.Id, v => v.labelId.Text));
                a(this.Bind(ViewModel, vm => vm.Name, v => v.editorName.Text));
                a(this.OneWayBind(ViewModel, vm => vm.Name, v => v.labelName.Text));
                a(this.Bind(ViewModel, vm => vm.Age, v => v.editorAge.Text, vmp => Convert.ToString(vmp), vp =>
                {
                    if (int.TryParse(vp, out int result))
                    {
                        return result;
                    }
                    return default;
                }));
                a(this.OneWayBind(ViewModel, vm => vm.Age, v => v.labelAge.Text));
            });
            ViewModel = new PersonViewModel();
            #endregion

            #region Normal
            //editorId.SetBinding(Editor.TextProperty, "Id", BindingMode.TwoWay);
            //labelId.SetBinding(Label.TextProperty, "Id", BindingMode.OneWay);
            //editorName.SetBinding(Editor.TextProperty, "Name", BindingMode.TwoWay);
            //labelName.SetBinding(Label.TextProperty, "Name", BindingMode.OneWay);
            //editorAge.SetBinding(Editor.TextProperty, "Age", BindingMode.TwoWay);
            //labelAge.SetBinding(Label.TextProperty, "Age", BindingMode.OneWay);
            //BindingContext = new PersonViewModel();
            #endregion
        }
    }
}
