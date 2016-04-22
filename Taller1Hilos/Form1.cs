using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Taller1Hilos
{
    public partial class Form1 : Form
    {

        private int posx1;
        private int posx2;
        private int posx3;
        private int posx4;

        private int posy1;       
        private int posy2;
        private int posy3;
        private int posy4;

        private int ancho;
        private int alto;

        Thread hilo1;
        Thread hilo2;
        Thread hilo3;
        Thread hilo4;

        private Position posicion;
        private Position posicion2;
        private Position posicion3;
        private Position posicion4;

        private int ganador;

        public int aux =1000;
        public int acomulado = 1000;

        Random aletorio = new Random();
        public Form1()
        {
            InitializeComponent();
            txtAcumulado.Text = acomulado + "";
            valorText.Text = aux + "";

            posy1 = 25;
            posy2 = 125;
            posy3 = 225;
            posy4 = 325;

            ancho = 100;
            alto = 100;
          
            posicion = Position.down;
            posicion2 = Position.down;
            posicion3 = Position.down;
            posicion4 = Position.down;


            hilo1 = new Thread(movCaballo1);
            hilo2 = new Thread(movCaballo2);
            hilo3 = new Thread(movCaballo3);
            hilo4 = new Thread(movCaballo4);

            ganador = 0;
        }

        private void posXInicial()
        {
            posx1 = 10;
            posx2 = 10;
            posx3 = 10;
            posx4 = 10;
        }
        enum Position
        {
            left, right, up, down
        }

        private void movCaballo1()
        {
            while (true)
            {
                if (posicion == Position.down && posx1 > 0)
                {
                    posx1 = posx1 + aletorio.Next(15);
                    if (posx1 > 1000 && ganador == 1 && posx1 > posx2 && posx1 > posx3 && posx1 > posx4)
                    {  
                        acomulado = acomulado + aux;
                        hilo2.Suspend();
                        hilo3.Suspend();
                        hilo4.Suspend();
                        MessageBox.Show(" WINNER HORSE 1 Tu saldo es: " + acomulado);
                        posXInicial();
                        hilo1.Suspend();
                    }
                    else if (posx2 > 1000 || posx3 > 1000 || posx4 > 1000)
                    {
                        MessageBox.Show(" Perdiste ");
                        hilo1.Suspend();
                        hilo2.Suspend();
                        hilo3.Suspend();
                        hilo4.Suspend();
                    }

                }
                Invalidate();
                Thread.Sleep(75);
            }
            }

        private void movCaballo2()
        {
            while (true)
            {
                if (posicion2 == Position.down && posx2 > 0)
                {
                    posx2 = posx2 + aletorio.Next(15);
                    if (posx2 > 1000 && ganador == 2 && posx2 > posx1 && posx2 > posx3 && posx2 > posx4)
                    {
                        hilo1.Suspend();
                        hilo3.Suspend();
                        hilo4.Suspend();
                        acomulado = acomulado + aux;
                        MessageBox.Show(" WINNER HORSE 2 Tu saldo es: " + acomulado);
                        posXInicial();
                        hilo2.Suspend();
                    }
                    else if (posx1 > 1000 || posx3 > 1000 || posx4 > 1000)
                    {
                        MessageBox.Show(" Perdiste ");
                        hilo2.Suspend();
                        hilo1.Suspend();
                        hilo3.Suspend();
                        hilo4.Suspend();
                    }
                }
                Invalidate();
                Thread.Sleep(75);
            }
        }


        private void movCaballo3()
        {
            while (true)
            {
                if (posicion3 == Position.down && posx3 > 0)
                {
                    posx3 = posx3 + aletorio.Next(15);
                    if (posx3 > 1000 && ganador == 3 && posx3 > posx1 && posx3 > posx2 && posx3 > posx4)
                    {
                        hilo1.Suspend();
                        hilo2.Suspend();
                        hilo4.Suspend();
                        acomulado = acomulado + aux;
                        MessageBox.Show(" WINNER HORSE 3 Tu saldo es: " + acomulado);
                        posXInicial();
                        hilo3.Suspend();
                    }
                    else if (posx1 > 1000 || posx2 > 1000 || posx4 > 1000)
                    {
                        MessageBox.Show(" Perdiste ");
                        hilo3.Suspend();
                        hilo1.Suspend();
                        hilo2.Suspend();
                        hilo4.Suspend();
                    }
                }
                Invalidate();
                Thread.Sleep(75);
            }
        }

        private void movCaballo4()
        {
            while (true)
            {
                if (posicion4 == Position.down && posx4 > 0)
                {
                    posx4 = posx4 + aletorio.Next(15);
                    if (posx4 > 1000 && ganador == 4 && posx4 > posx1 && posx4 > posx2 && posx4 > posx3)
                    {
                        hilo1.Suspend();
                        hilo2.Suspend();
                        hilo3.Suspend();
                        acomulado = acomulado + aux;
                        MessageBox.Show(" WINNER HORSE 4 Tu saldo es: " + acomulado);                        
                        posXInicial();
                        hilo4.Suspend();
                    }
                    else if (posx1 > 1000 || posx2 > 1000 || posx3 > 1000)
                    {
                        MessageBox.Show(" Perdiste");
                        hilo4.Suspend();
                        hilo1.Suspend();
                        hilo2.Suspend();
                        hilo3.Suspend();
                    }
                }
                Invalidate();
                Thread.Sleep(75);
            }
        }


        private void correrHilos()
        {
            if (acomulado >= aux)
            {
                hilo1.Start();
                hilo2.Start();
                hilo3.Start();
                hilo4.Start();
            }
            else
            {
                MessageBox.Show("No tiene saldo suficiente, Ingrese un monto que no supere " + acomulado);
            }
        }


        private void definirGanador()
        {
           acomulado = acomulado - aux;
           MessageBox.Show("Perdiste, ahora tu saldo es " + acomulado);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(new Bitmap("caballo1.png"), posx1, posy1, ancho, alto);
            e.Graphics.DrawImage(new Bitmap("caballo2.png"), posx2, posy2, ancho, alto);
            e.Graphics.DrawImage(new Bitmap("caballo3.png"), posx3, posy3, ancho, alto);
            e.Graphics.DrawImage(new Bitmap("caballo4.png"), posx4, posy4, ancho, alto);
            txtAcumulado.Text = acomulado + "";
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            ganador = 1;
            posXInicial();
            aux = Convert.ToInt16(valorText.Text);
            correrHilos();
         }
       
        private void btn2_Click(object sender, EventArgs e)
        {
            ganador = 2;
            posXInicial();
            aux = Convert.ToInt16(valorText.Text);
            correrHilos();
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            ganador = 3;
            posXInicial();
            aux = Convert.ToInt16(valorText.Text);
            correrHilos();
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            ganador = 4;
            posXInicial();
            aux = Convert.ToInt16(valorText.Text);
            correrHilos();
        }
    }
}
