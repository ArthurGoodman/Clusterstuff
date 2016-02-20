using Clusterstuff;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Visualizer {
    public partial class Form : System.Windows.Forms.Form {
        private Sample[] samples = Sample.Load(@"..\..\..\Clusterstuff\iris.dat");
        private MaxMin maxMin;

        private float scaleFactor = 0.0f;
        private float offsetX = 0, offsetY = 0;
        private float alphaX1 = 0, alphaY1 = 0, alphaX2 = 0, alphaY2 = 0;

        private Point lastPos;

        private bool showInfo = true;

        private Font font = new Font("Consolas", 10);

        Sample[] rotated;

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

            Reset();
        }

        private void MouseWheelEvent(object sender, MouseEventArgs e) {
            if (e.Delta > 0)
                scaleFactor *= 1.1f;
            else
                scaleFactor /= 1.1f;
        }

        private void Repaint(object sender, EventArgs e) {
            pictureBox.Invalidate();
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

            const int circleDiameter = 7;

            foreach (Sample s in rotated) {
                int x = MapX((float)s.Data[0]);
                int y = MapY((float)s.Data[1]);

                brush.Color = Color.Black;
                e.Graphics.FillEllipse(brush, x - (s.Center ? 1.5f : 0.5f), y - (s.Center ? 1.5f : 0.5f), circleDiameter + (s.Center ? 3 : 1), circleDiameter + +(s.Center ? 3 : 1));

                brush.Color = HslColor((int)((double)s.Cluster / maxMin.ClusterCount * 239), 239, 120);
                e.Graphics.FillEllipse(brush, x, y, circleDiameter, circleDiameter);
            }

            if (showInfo) {
                e.Graphics.TranslateTransform(-ClientSize.Width / 2, -ClientSize.Height / 2);

                Rectangle rect = new Rectangle(0, 0, ClientSize.Width, 16);

                brush.Color = Color.FromArgb(128, Color.Black);
                e.Graphics.FillRectangle(brush, rect);

                string info = string.Format("Scale={0}, alphaX1={1}, alphaY1={2}, alphaX2={3}, alphaY2={4}, Alpha={5}", scaleFactor, alphaX1, alphaY1, alphaX2, alphaY2, MaxMin.Alpha);

                brush.Color = Color.White;
                e.Graphics.DrawString(info, font, brush, rect);
            }
        }

        private void Reset() {
            offsetX = 0;
            offsetX = 0;

            scaleFactor = 100.0f;

            alphaX1 = 0;
            alphaY1 = 0;

            alphaX2 = 0;
            alphaY2 = 0;

            Rotate();
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

        private void TrackBarKeyDownEvent(object sender, KeyEventArgs e) {
            KeyDownEvent(sender, e);
        }

        private void TrackBarValueChanged(object sender, EventArgs e) {
            MaxMin.Alpha = trackBar.Value / 100.0;
            maxMin.Run();
            Rotate();
        }

        private void MouseMoveEvent(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                offsetX += (e.Location.X - lastPos.X) / scaleFactor;
                offsetY += (e.Location.Y - lastPos.Y) / scaleFactor;
            } else if (e.Button == MouseButtons.Right) {
                if (ModifierKeys == Keys.Control) {
                    alphaX2 += (e.Location.X - lastPos.X) / scaleFactor / 4;
                    alphaY2 += (e.Location.Y - lastPos.Y) / scaleFactor / 4;
                } else {
                    alphaX1 += (e.Location.X - lastPos.X) / scaleFactor / 4;
                    alphaY1 += (e.Location.Y - lastPos.Y) / scaleFactor / 4;
                }

                Rotate();
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

                case Keys.I:
                    showInfo = !showInfo;
                    break;

                case Keys.Back:
                    Reset();
                    break;
            }

            e.Handled = true;
            e.SuppressKeyPress = true;
        }

        private void Rotate() {
            Matrix4x4 xMatrix1 = new Matrix4x4(new double[4, 4] {
                {Math.Cos(alphaX1), 0, -Math.Sin(alphaX1), 0},
                {0,                1, 0,                 0},
                {Math.Sin(alphaX1), 0, Math.Cos(alphaX1),  0},
                {0,                0, 0,                 1}
            });

            Matrix4x4 yMatrix1 = new Matrix4x4(new double[4, 4] {
                {1, 0,                0,                 0},
                {0, Math.Cos(alphaY1), -Math.Sin(alphaY1), 0},
                {0, Math.Sin(alphaY1), Math.Cos(alphaY1),  0},
                {0, 0,                0,                 1}
            });

            Matrix4x4 xMatrix2 = new Matrix4x4(new double[4, 4] {
                {Math.Cos(alphaX2), 0, 0, -Math.Sin(alphaX2)},
                {0,                 1, 0, 0},
                {0,                 0, 1, 0},
                {Math.Sin(alphaX2), 0, 0, Math.Cos(alphaX2)}
            });

            Matrix4x4 yMatrix2 = new Matrix4x4(new double[4, 4] {
                {1, 0,                 0, 0},
                {0, Math.Cos(alphaY2), 0, -Math.Sin(alphaY2)},
                {0, 0,                 1, 0},
                {0, Math.Sin(alphaY2), 0, Math.Cos(alphaY2)}
            });

            rotated = new Sample[samples.Length];

            for (int i = 0; i < rotated.Length; i++) {
                rotated[i] = samples[i].Clone();

                rotated[i].Data -= maxMin.Center;

                xMatrix1.Map(rotated[i].Data);
                yMatrix1.Map(rotated[i].Data);

                xMatrix2.Map(rotated[i].Data);
                yMatrix2.Map(rotated[i].Data);
            }

            rotated = rotated.OrderBy(s => s.Data[2] + s.Data[3]).ToArray();
        }
    }
}
