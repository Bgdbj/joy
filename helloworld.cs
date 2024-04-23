using System;
using System.Threading;
using System.Windows.Forms;

namespace ClipboardCheck
{
    public partial class Form1 : Form 
    {
        public Form1()
        {
            InitializeComponent();
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                // turn on WS_EX_TOOLWINDOW style bit
                cp.ExStyle |= 0x80;
                return cp;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.ShowInTaskbar = false;
            this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
            this.ShowInTaskbar = false;
            this.FormBorderStyle = FormBorderStyle.None;
            Thread TM = new Thread(Clipboard_Check);
            TM.SetApartmentState(ApartmentState.STA);
            CheckForIllegalCrossThreadCalls = false;
            TM.Start();
        }
            
        private void Clipboard_Check()
        {
            while (true)
            {
                var text = Clipboard.GetText();
                    
                if (text.StartsWith("hello"))
                {
                    Clipboard.SetText("hello world");
                }
            }
        }
    }
}
