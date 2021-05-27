using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LAB4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BitArray lfsr = new BitArray(28, true);
        

        public MainWindow()
        {
            InitializeComponent();
        }



        //private void OutLFSR()
        //{
        //    for (int i = 28; i >= 0; i--)
        //    {
        //        if (lfsr[i] == true)
        //            txtBoxText.Text += '1';
        //        else
        //            txtBoxText.Text += '0';

        //    }
        //    txtBoxText.Text += "\n";
        //}

        private byte LFSR()
        {
            bool outBit, newBit;
            string newByte = "";            

            for (int j = 0; j < 8; j++)
            {
                outBit = lfsr[27];
                newBit = lfsr[2] ^ lfsr[27];
                for (int i = 27; i > 0; i--)
                {
                    lfsr[i] = lfsr[i - 1];
                }
                lfsr[0] = newBit;

                if (outBit)
                    newByte = '1' + newByte;
                else
                    newByte = '0' + newByte;

                //if (outBit)
                //    newByte += '1';
                //else
                //    newByte += '0';
            }
            
            return Convert.ToByte(newByte, 2);
        }

        private void ButtonDe_Click(object sender, RoutedEventArgs e)
        {
            lfsr.SetAll(true);

            byte textByte, outByte;
            string text = txtBoxEn.Text;
            txtBoxDe.Text = "";

            for (int i = 0; i < text.Length; i++)
            {
                textByte = Convert.ToByte(text[i]);
                outByte = (byte)(textByte ^ LFSR());
                txtBoxDe.Text += (char)Convert.ToInt32(outByte);

            }
        }

        private void ButtonEn_Click(object sender, RoutedEventArgs e)
        {
            lfsr.SetAll(true);

            byte textByte, outByte;
            string text = txtBoxText.Text;
            txtBoxEn.Text = "";

            for (int i = 0; i < text.Length; i++)
            {
                textByte = Convert.ToByte(text[i]);
                byte lfsr = LFSR();
                //txtBoxEn.Text += Convert.ToString(lfsr, 2) + "\n";
                outByte = (byte)(textByte ^ lfsr);
                txtBoxEn.Text += (char)Convert.ToInt32(outByte);

            }

        }
    }
}
