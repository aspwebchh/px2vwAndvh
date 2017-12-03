using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Forms = System.Windows.Forms;

namespace px2vwAndvh {
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window {
        private PsdWidthAndHeight pwh;

        private Forms.NotifyIcon notifyIcon;

        public void ForceShow()
        {
            this.Show();
            this.WindowState = WindowState.Normal;
            this.Visibility = System.Windows.Visibility.Visible;
            this.Activate();
        }

        private void Show( object sender, EventArgs e ) {
            this.ForceShow();
        }
        

        private void Close( object sender, EventArgs e ) {
            this.Close();
           // System.Windows.Application.Current.Shutdown();
        }


        private void InitNotifyIcon() {
            this.notifyIcon = new Forms.NotifyIcon();
            this.notifyIcon.BalloonTipText = "px转vw/vh工具";
            this.notifyIcon.ShowBalloonTip(2000);
            this.notifyIcon.Text = "px转vw/vh工具";
            this.notifyIcon.Icon = System.Drawing.Icon.ExtractAssociatedIcon(System.Windows.Forms.Application.ExecutablePath);
            this.notifyIcon.Visible = true;
            //打开菜单项
            System.Windows.Forms.MenuItem open = new System.Windows.Forms.MenuItem("打开");
            open.Click += new EventHandler(Show);
            //退出菜单项
            System.Windows.Forms.MenuItem exit = new System.Windows.Forms.MenuItem("退出");
            exit.Click += new EventHandler(Close);
            //关联托盘控件
            System.Windows.Forms.MenuItem [] childen = new System.Windows.Forms.MenuItem [] { open, exit };
            notifyIcon.ContextMenu = new System.Windows.Forms.ContextMenu(childen);

            this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(( o, e ) => {
                if( e.Button == Forms.MouseButtons.Left )
                    this.Show(o, e);
            });
        }



        public MainWindow() {
            InitializeComponent();

            pwh = Config.GetPsdWidthAndHeight();

            this.FillPsdPixedTextBox();

            this.InitNotifyIcon();

            this.Closed += MainWindow_Closed;

            this.Topmost = true;
        }

        private void MainWindow_Closed(object sender, EventArgs e)
        {
            notifyIcon.Visible = false;
        }

        private void FillPsdPixedTextBox() {
            if( pwh.IsValid ) {
                PsdWidth.Text = pwh.Width.ToString();
                PsdHeight.Text = pwh.Height.ToString();
            }
        }


        private PsdWidthAndHeight getPsdWidthAndHeight() {
            var psdWidth = PsdWidth.Text;
            var psdHeight = PsdHeight.Text;
            if( Common.IsNumeric(psdWidth) && Common.IsNumeric(psdHeight) ) {
                return new PsdWidthAndHeight(float.Parse(psdWidth), float.Parse(psdHeight));
            } else {
                return new PsdWidthAndHeight();
            }
        }

        private void PsdInputLoseFocus() {
            var wh = getPsdWidthAndHeight();
            if( wh.IsValid ) {
                Config.SavePsdWidthAndHeight(wh);
                pwh = Config.GetPsdWidthAndHeight();
            }
        }

        private void PsdWidth_LostFocus( object sender, RoutedEventArgs e ) {
            PsdInputLoseFocus();
        }

        private void PsdHeight_LostFocus( object sender, RoutedEventArgs e ) {
            PsdInputLoseFocus();
        }

        private void PsdWidth_KeyUp( object sender, KeyEventArgs e ) {
            ValidTextBoxInputNum.Create(sender).Validate();
        }

        private void PsdHeight_KeyUp( object sender,KeyEventArgs e ) {
            ValidTextBoxInputNum.Create(sender).Validate();
        }

        private void Process( TextBox pxTextBox, TextBlock resultText , float scale ) {
            if( !pwh.IsValid ) {
                MessageBox.Show("请设置首选项");
                return;
            }
            ValidTextBoxInputNum.Create(pxTextBox).Validate();
            var px = pxTextBox.Text;
            float val;
            if( float.TryParse(px, out val) ) {
                resultText.Text = ( Math.Round(scale * val, 1) ).ToString();
            } else {
                resultText.Text = "0";
            }
        }

        private void Width_KeyUp( object sender, KeyEventArgs e ) {
            Process(sender as TextBox, ResultWidth, pwh.WidthScale());
        }

        private void Height_KeyUp( object sender, KeyEventArgs e ) {
            Process(sender as TextBox, ResultHeight, pwh.HeightScale());
        }
    }
}
