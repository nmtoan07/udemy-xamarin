using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using HelloWorld.Annotations;
using Xamarin.Forms;

namespace HelloWorld.ViewModels
{
    public class GreetPageViewModel : BaseViewModel
    {
        private readonly string[] _quoteStrings = {
            "Quote1",
            "Quote2",
            "Quote3"
        };

        private int _currentQuoteIndex;
        private string _fontSizeText;
        private string _quoteText;
        private int _sliderValue;

        public GreetPageViewModel()
        {
            _currentQuoteIndex = 0;
            _quoteText = _quoteStrings[_currentQuoteIndex];
            _sliderValue = 16;
            _fontSizeText = $"Font Size: {_sliderValue}";
        }

        public ICommand NextCommand => new Command(DoNext);

        public int SliderValue
        {
            get => _sliderValue;
            set
            {
                _sliderValue = value;
                OnPropertyChanged();
                UpdateFontSizeText();
            }
        }

        public string FontSizeText
        {
            get => _fontSizeText;
            set
            {
                _fontSizeText = value;
                OnPropertyChanged();
            }
        }

        public string QuoteText
        {
            get => _quoteText;
            set
            {
                _quoteText = value;
                OnPropertyChanged();
            }
        }

        private void DoNext()
        {
            if (_currentQuoteIndex < _quoteStrings.Length - 1)
            {
                _currentQuoteIndex++;
            }
            else
            {
                _currentQuoteIndex = 0;
            }

            QuoteText = _quoteStrings[_currentQuoteIndex];
        }

        private void UpdateFontSizeText()
        {
            FontSizeText = $"Font Size: {SliderValue}";
        }
    }
}