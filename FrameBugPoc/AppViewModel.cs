using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace FrameBugPoc
{
	public class AppViewModel : INotifyPropertyChanged
	{
	    ICommand _changeColor;

		public event PropertyChangedEventHandler PropertyChanged;

		public ICommand ChangeColor => _changeColor ?? (_changeColor = new Command(OnChangeColor));

		public Color LineColor { get; set; } = Color.White;

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		void OnChangeColor()
		{
			LineColor = Color.Transparent;
			OnPropertyChanged("LineColor");
		}
	}
}


