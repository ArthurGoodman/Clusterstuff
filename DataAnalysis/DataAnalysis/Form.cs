using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DataAnalysis {
    partial class Form : System.Windows.Forms.Form {
        private DataEngine engine = new DataEngine();

        private float scaleFactor = 0.0f;
        private float offsetX = 0, offsetY = 0;

        private Point lastPos;

        private Font font = new Font("Consolas", 10);

        private bool showInfo = true;
        private bool visualize4thD = true;
        private bool usePerspective = true;
        private bool showAxes = true;

        private Matrix4x4 perspective;
        private double perspectiveOffset = 7;

        public Form() {
            InitializeComponent();

            MouseWheel += new MouseEventHandler(MouseWheelEvent);

            ResizeRedraw = true;
            DoubleBuffered = true;

            Application.Idle += new EventHandler(Repaint);

            Width = Screen.PrimaryScreen.WorkingArea.Width / 2;
            Height = (int)(Screen.PrimaryScreen.WorkingArea.Height / 1.75);

            engine.LoadData();

            CenterToScreen();

            Reset();
            CreatePerspective();
        }

        private void CreatePerspective() {
            double fov = Math.PI / scaleFactor * perspectiveOffset;

            double near = 100;
            double far = 500;

            double s = 1 / Math.Tan(fov / 2);

            perspective = new Matrix4x4(new double[4, 4] {
                { s, 0, 0,                           0                             },
                { 0, s, 0,                           0                             },
                { 0, 0, (far + near) / (far - near), 2 * near * far / (near - far) },
                { 0, 0, 1,                           0                             }
            });
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

            if (showAxes) {
                int xAxis = ClientSize.Width / 2 + (int)(offsetX * scaleFactor);
                int yAxis = ClientSize.Height / 2 + (int)(offsetY * scaleFactor);

                e.Graphics.DrawLine(pen, new Point(xAxis, 0), new Point(xAxis, ClientSize.Height));
                e.Graphics.DrawLine(pen, new Point(0, yAxis), new Point(ClientSize.Width, yAxis));
            }

            e.Graphics.TranslateTransform(ClientSize.Width / 2, ClientSize.Height / 2);

            SolidBrush brush = new SolidBrush(Color.Red);
            pen.Color = Color.Black;

            foreach (Sample s in engine.Rotated) {
                Vector4 v = new Vector4(s.Vector.Data) + new Vector4(new double[] { 0, 0, perspectiveOffset, 0 });

                float circleDiameter = (float)(7 + (visualize4thD ? v[3] * 2 : 0));

                if (usePerspective) {
                    v[3] = 1;
                    perspective.Map(v);
                    v /= v[3];
                }

                int x = MapX((float)v[0]);
                int y = MapY((float)v[1]);

                brush.Color = Color.Black;
                e.Graphics.FillEllipse(brush, x - circleDiameter / 2 - (s.Mark ? 1.5f : 0.5f), y - circleDiameter / 2 - (s.Mark ? 1.5f : 0.5f), circleDiameter + (s.Mark ? 3 : 1), circleDiameter + (s.Mark ? 3 : 1));

                brush.Color = HslColor((int)((double)s.Cluster / engine.ClusterCount * 239), 239, 120);
                e.Graphics.FillEllipse(brush, x - circleDiameter / 2, y - circleDiameter / 2, circleDiameter, circleDiameter);
            }

            if (showInfo) {
                e.Graphics.TranslateTransform(-ClientSize.Width / 2, -ClientSize.Height / 2);

                Rectangle rect = new Rectangle(0, 0, ClientSize.Width, 16);

                brush.Color = Color.FromArgb(128, Color.Black);
                e.Graphics.FillRectangle(brush, rect);

                string info = string.Format("Scale={0}, alphaX1={1}, alphaY1={2}, alphaX2={3}, alphaY2={4}, Param={5}, ClusterCount={6}", scaleFactor, engine.AlphaX1, engine.AlphaY1, engine.AlphaX2, engine.AlphaY2, engine.Alg.Param, engine.ClusterCount);

                brush.Color = Color.White;
                e.Graphics.DrawString(info, font, brush, rect);
            }
        }

        private void Reset() {
            offsetX = 0;
            offsetX = 0;

            scaleFactor = 75.0f;

            engine.ResetAngles();
            engine.Rotate();
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

        private void maxMinToolStripMenuItem_Click(object sender, EventArgs e) {
            kMeansToolStripMenuItem.Checked = false;
            perceptronToolStripMenuItem.Checked = false;

            ((ToolStripMenuItem)sender).Checked = true;

            engine.Alg = new MaxMin();
            engine.LoadSamples();

            trackBar.Value = (int)(100 * engine.Alg.Param);
        }

        private void kMeansToolStripMenuItem_Click(object sender, EventArgs e) {
            maxMinToolStripMenuItem.Checked = false;
            perceptronToolStripMenuItem.Checked = false;

            ((ToolStripMenuItem)sender).Checked = true;

            engine.Alg = new KMeans();
            engine.LoadSamples();

            trackBar.Value = (int)(100 * engine.Alg.Param);
        }

        private void perceptronToolStripMenuItem_Click(object sender, EventArgs e) {
            maxMinToolStripMenuItem.Checked = false;
            kMeansToolStripMenuItem.Checked = false;

            ((ToolStripMenuItem)sender).Checked = true;

            engine.Alg = new Perceptron();
            engine.LoadSamples();

            trackBar.Value = (int)(100 * engine.Alg.Param);
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e) {
            engine.LoadData();
        }

        private void randomizeToolStripMenuItem_Click(object sender, EventArgs e) {
            engine.RandomizeData();
        }

        private void perspectiveToolStripMenuItem_Click(object sender, EventArgs e) {
            usePerspective = !usePerspective;
        }

        private void thDimentionToolStripMenuItem_Click(object sender, EventArgs e) {
            visualize4thD = !visualize4thD;
        }

        private void showInfoToolStripMenuItem_Click(object sender, EventArgs e) {
            showInfo = !showInfo;
        }

        private void axesToolStripMenuItem_Click(object sender, EventArgs e) {
            showAxes = !showAxes;
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e) {
            Reset();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e) {
            MessageBox.Show("Data Analysis v3", "About");
        }

        private void activeToolStripMenuItem_Click(object sender, EventArgs e) {
            engine.AlgorithmActive = !engine.AlgorithmActive;
            engine.Calculate();
        }

        private void showInfoToolStripMenuItem1_Click(object sender, EventArgs e) {
            MessageBox.Show(engine.Alg.Info, "Info");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            Close();
        }

        private void TrackBarValueChanged(object sender, EventArgs e) {
            engine.Alg.Param = trackBar.Value / 100.0;
            engine.Calculate();
        }

        private void MouseMoveEvent(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                offsetX += (e.Location.X - lastPos.X) / scaleFactor;
                offsetY += (e.Location.Y - lastPos.Y) / scaleFactor;
            } else if (e.Button == MouseButtons.Right) {
                engine.UpdateAngles(new Point(e.Location.X - lastPos.X, e.Location.Y - lastPos.Y), ModifierKeys == Keys.Control);
                engine.Rotate();
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
