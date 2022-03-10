using ReactiveUI;

namespace AvaloniaApplication1.ViewModels
{
	public class MainWindowViewModel : ViewModelBase
	{
		string outPanel = "";
		string operat = "";
		string firstNum = "";
		string secondNum = "";
		

		public MainWindowViewModel()
		{
			OnClickValue = ReactiveCommand.Create<string, string>((str) => Output += str);
			OnClickOper = ReactiveCommand.Create<string, string>((str) => Output = str);
		}

		public string Output
		{
			set
			{
				if ((value == "+" || value == "-" || value == "*" || value == "/") && operat == "")
				{
					firstNum = outPanel;
					operat = value;
					this.RaiseAndSetIfChanged(ref outPanel, "");
				}
				else if (value == "=" && operat != "")
				{
					secondNum = outPanel;
					var firststr = new RomanNumberExtend(firstNum);
					var secondstr = new RomanNumberExtend(secondNum);

					switch (operat)
					{
						case ("+"):
							value = (firststr + secondstr).ToString();
							break;
						case ("-"):
							value = (firststr - secondstr).ToString();
							break;
						case ("*"):
							value = (firststr * secondstr).ToString();
							break;
						case ("/"):
							value = (firststr / secondstr).ToString();
							break;
					}
					operat = "";
					this.RaiseAndSetIfChanged(ref outPanel, value);
				}
				else if ((value == "+" || value == "-" || value == "*" || value == "/") && operat != "")
				{
					secondNum = outPanel;
					var firststr = new RomanNumberExtend(firstNum);
					var secondstr = new RomanNumberExtend(secondNum);
					var tmp = value;

					switch (operat)
					{
						case ("+"):
							firstNum = (firststr + secondstr).ToString();
							break;
						case ("-"):
							firstNum = (firststr - secondstr).ToString();
							break;
						case ("*"):
							firstNum = (firststr * secondstr).ToString();
							break;
						case ("/"):
							firstNum = (firststr / secondstr).ToString();
							break;
					}
					operat = tmp;
					this.RaiseAndSetIfChanged(ref outPanel, "");
				}
                else
                {
					this.RaiseAndSetIfChanged(ref outPanel, value);
                }
			}
			get
			{
				return outPanel;
			}
		}
		public ReactiveCommand<string, string> OnClickValue { get; }
		public ReactiveCommand<string, string> OnClickOper { get; }
	}

}
