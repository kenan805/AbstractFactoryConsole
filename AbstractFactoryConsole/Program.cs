using System;

namespace AbstractFactoryConsole
{
    abstract class Button
    {
        public abstract void Paint();
    }
    class WinButton : Button
    {
        public override void Paint()
        {
            Console.WriteLine("Windows button painted");
        }
    }
    class MacButton : Button
    {
        public override void Paint()
        {
            Console.WriteLine("Mac button painted");
        }
    }


    abstract class CheckBox
    {
        public abstract void Paint();
    }
    class WinCheckBox : CheckBox
    {
        public override void Paint()
        {
            Console.WriteLine("Windows check box painted");
        }
    }
    class MacCheckBox : CheckBox
    {
        public override void Paint()
        {
            Console.WriteLine("Windows check box painted");
        }
    }


    interface IGUIFactory
    {
        Button CreateButton();
        CheckBox CreateCheckBox();
    }
    class WinFactory : IGUIFactory
    {
        public Button CreateButton()
        {
            Console.WriteLine("Windows button created.");
            return new WinButton();
        }

        public CheckBox CreateCheckBox()
        {
            Console.WriteLine("Windows checkbox created.");
            return new WinCheckBox();
        }
    }
    class MacFactory : IGUIFactory
    {
        public Button CreateButton()
        {
            Console.WriteLine("Mac button created.");
            return new MacButton();
        }

        public CheckBox CreateCheckBox()
        {
            Console.WriteLine("Mac checkbox created.");
            return new MacCheckBox();
        }
    }


    class Application
    {
        private IGUIFactory _factory { get; set; }
        private Button _button { get; set; }
        private CheckBox _checkBox { get; set; }

        public Application(IGUIFactory factory)
        {
            _factory = factory;
        }

        public void CreateUI()
        {
            _button = _factory.CreateButton();
            _checkBox = _factory.CreateCheckBox();
        }

        public void Paint()
        {
            _button.Paint();
            _checkBox.Paint();
        }

    }



    class Program
    {
        static void Main(string[] args)
        {
            IGUIFactory factory = new WinFactory();
            Application app = new Application(factory);
            app.CreateUI();
            app.Paint();
        }
    }
}
