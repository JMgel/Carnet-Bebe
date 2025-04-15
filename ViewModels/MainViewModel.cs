namespace Carnet_Bebe.ViewModels
{
    public class MainViewModel 
    {
        public Command Button1Command { get; }
        public Command Button2Command { get; }

        public MainViewModel()
        {
            Button1Command = new Command(ExecuteButton1);
            Button2Command = new Command(ExecuteButton2);
        }


        private void ExecuteButton1()
        {
            //Test
        }

        private void ExecuteButton2()
        {
            //Test2
        }
    }
}
