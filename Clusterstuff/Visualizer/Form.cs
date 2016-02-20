using Clusterstuff;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Visualizer {
    public partial class Form : System.Windows.Forms.Form {
        private Sample[] samples = Sample.Load(@"..\..\..\Clusterstuff\iris.dat");
        private MaxMin maxMin;

        private float scaleFactor = 10.0f;
        private float offsetX = 0, offsetY = 0;

        private Point lastPos;

        public Form() {
            InitializeComponent();

            MouseWheel += new MouseEventHandler(MouseWheelEvent);

            ResizeRedraw = true;
            DoubleBuffered = true;

            Application.Idle += new EventHandler(Repaint);

            Width = Screen.PrimaryScreen.WorkingArea.Width / 2;
            Height = (int)(Screen.PrimaryScreen.WorkingArea.Height / 1.75);

            CenterToScreen();

            maxMin = new MaxMin(samples);
            maxMin.Run();
        }

        private void MouseWheelEvent(object sender, MouseEventArgs e) {
            if (e.Delta > 0)
                scaleFactor *= 1.1f;
            else
                scaleFactor /= 1.1f;
        }

        private void Repaint(object sender, EventArgs e) {
            Invalidate();
        }

        private int MapX(float x) {
            return (int)(scaleFactor * (x + offsetX));
        }

        private int MapY(float y) {
            return (int)(scaleFactor * (-y + offsetY));
        }

        [DllImport("shlwapi.dll")]
        public static extern int ColorHLSToRGB(int H, int L, int S);

        private Color HslColor(int h, int s, int l) {
            return ColorTranslator.FromWin32(ColorHLSToRGB(h, l, s));
        }

        private void PaintEvent(object sender, PaintEventArgs e) {
            e.Graphics.FillRectangle(new SolidBrush(Color.LightGray), ClientRectangle);

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Pen pen = new Pen(Color.Gray);

            int xAxis = ClientSize.Width / 2 + (int)(offsetX * scaleFactor);
            int yAxis = ClientSize.Height / 2 + (int)(offsetY * scaleFactor);

            e.Graphics.DrawLine(pen, new Point(xAxis, 0), new Point(xAxis, ClientSize.Height));
            e.Graphics.DrawLine(pen, new Point(0, yAxis), new Point(ClientSize.Width, yAxis));

            e.Graphics.TranslateTransform(ClientSize.Width / 2, ClientSize.Height / 2);

            SolidBrush brush = new SolidBrush(Color.Red);
            pen.Color = Color.Black;

            const int circleDiameter = 6;

            foreach (Sample s in samples) {
                int x = MapX((float)s.Data[0]);
                int y = MapY((float)s.Data[1]);

                e.Graphics.DrawEllipse(pen, x, y, circleDiameter, circleDiameter);

                brush.Color = HslColor((int)((double)s.Cluster / maxMin.ClusterCount * 239), 239, 120);
                e.Graphics.FillEllipse(brush, x, y, circleDiameter, circleDiameter);
            }
        }

        private bool IsFullscreen() {
            return WindowState == FormWindowState.Maximized;
        }

        private void ShowNormal() {
            FormBorderStyle = FormBorderStyle.Fixed3D;
            WindowState = FormWindowState.Normal;
        }

        private void ShowFullscreen() {
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
        }

        private void MouseDownEvent(object sender, MouseEventArgs e) {
            lastPos = e.Location;
        }

        private void MouseMoveEvent(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                offsetX += (e.Location.X - lastPos.X) / scaleFactor;
                offsetY += (e.Location.Y - lastPos.Y) / scaleFactor;
            }

            lastPos = e.Location;
        }

        private void KeyDownEvent(object sender, KeyEventArgs e) {
            switch (e.KeyCode) {
                case Keys.Escape:
                    if (IsFullscreen())
                        ShowNormal();
                    else
                        Close();
                    break;

                case Keys.F11:
                    if (IsFullscreen())
                        ShowNormal();
                    else
                        ShowFullscreen();
                    break;
            }

            e.Handled = true;
            e.SuppressKeyPress = true;
        }
    }
}
