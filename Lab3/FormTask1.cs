using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Lab3
{
    public partial class FormTask1 : Form
    {
        static string filename = "milyaM.png";
        static Bitmap _bmFillPicture = new Bitmap(filename);

        Bitmap _bm;
        Graphics _g;
        List<Point> _points;

        Pen _pen = new Pen(Color.Black);
        Pen _fillPen = new Pen(Color.DarkRed);
        Color edgeColor = Color.Cyan;

        private Color _penColor;
        private Color _fillColor;

        public FormTask1()
        {
            InitializeComponent();
            DoubleBuffered = true;

            _bm = new Bitmap(pictureBox1.Size.Width-1, pictureBox1.Size.Height-1);
            pictureBox1.Image = _bm;
            Clear();

            _points = new List<Point>();
            _g = Graphics.FromImage(_bm);

            pictureBox1.MouseDown += OnMouseDown;
            pictureBox1.MouseMove += OnMouseMove;

            _penColor = _pen.Color;
            _fillColor = _fillPen.Color;
        }


        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked) //Рисовать
            {
                pictureBox1.MouseDown -= ColorFill;
                pictureBox1.MouseDown -= PictureFill;
                pictureBox1.MouseDown -= SelectEdge;

                pictureBox1.MouseDown += OnMouseDown;
                pictureBox1.MouseMove += OnMouseMove;
            }
            else if (radioButton2.Checked) //Залить цветом
            {
                pictureBox1.MouseDown -= OnMouseDown;
                pictureBox1.MouseMove -= OnMouseMove;
                pictureBox1.MouseDown -= PictureFill;
                pictureBox1.MouseDown -= SelectEdge;

                pictureBox1.MouseDown += ColorFill;
            }
            else if (radioButton3.Checked) //Залить картинкой
            {
                pictureBox1.MouseDown -= OnMouseDown;
                pictureBox1.MouseMove -= OnMouseMove;
                pictureBox1.MouseDown -= ColorFill;
                pictureBox1.MouseDown -= SelectEdge;

                pictureBox1.MouseDown += PictureFill;
            }
            else if (radioButton4.Checked) //Выделить границу
            {
                pictureBox1.MouseDown -= OnMouseDown;
                pictureBox1.MouseMove -= OnMouseMove;
                pictureBox1.MouseDown -= ColorFill;
                pictureBox1.MouseDown -= PictureFill;

                pictureBox1.MouseDown += SelectEdge;
            }
        }

        void ColorFill(object sender, MouseEventArgs e)
        {
            ColorFill_(e.Location);
        }

        private bool ColorsEqual(Color c1, Color c2) => c1.ToArgb() == c2.ToArgb();

        void ColorFill_(Point p)
        {
            if (p.X >= 0 && p.X < _bm.Width && p.Y >= 0 && p.Y < _bm.Height &&
                !ColorsEqual(_bm.GetPixel(p.X, p.Y), _fillColor) && !ColorsEqual(_bm.GetPixel(p.X, p.Y), _penColor))
            {
                Color oldColor = _bm.GetPixel(p.X, p.Y);
                Point left = new Point(p.X, p.Y);
                while (left.X > 0 && ColorsEqual(_bm.GetPixel(left.X, left.Y), oldColor)) left.X -= 1;
                Point right = new Point(p.X, p.Y);
                while (right.X < _bm.Width - 1 && ColorsEqual(_bm.GetPixel(right.X, right.Y), oldColor)) right.X += 1;

                if (left.X == 0) left.X = -1;
                if (right.X == _bm.Width - 1) right.X = _bm.Width;

                _g.DrawLine(_fillPen, left.X + 1, left.Y, right.X - 1, right.Y);
                pictureBox1.Image = _bm;

                for (int i = left.X + 1; i <= right.X - 1; i++)
                    ColorFill_(new Point(i, p.Y + 1));
                for (int i = left.X + 1; i <= right.X - 1; i++)
                    ColorFill_(new Point(i, p.Y - 1));
            }
        }

        void PictureFill(object sender, MouseEventArgs e)
        {
            PictureFill_(e.Location, e.Location);
        }
        Point GetLocalPoint(Point p, Point origin)
        {
            // 1. Вычисляем смещение относительно центральной точки изображения-заполнителя
            int xOffset = p.X - origin.X;
            int yOffset = p.Y - origin.Y;

            // 2. Прибавляем половину ширины и высоты изображения-заполнителя,
            // чтобы получить координаты относительно центра
            int x = _bmFillPicture.Width / 2 + xOffset;
            int y = _bmFillPicture.Height / 2 + yOffset;

            // 3. Обрабатываем переполнение по краям изображения-заполнителя
            // с помощью оператора modulo (%)
            x %= _bmFillPicture.Width;
            y %= _bmFillPicture.Height;

            // 4. Исправляем отрицательные координаты, чтобы они были в диапазоне 
            // от 0 до ширины/высоты изображения-заполнителя
            while (x < 0) x += _bmFillPicture.Width;
            while (y < 0) y += _bmFillPicture.Height;

            // 5. Возвращаем полученные координаты
            return new Point(x, y);
        }


        void PictureFill_(Point p, Point origin)
        {
            if (p.X >= 0 && p.X < _bm.Width && p.Y >= 0 && p.Y < _bm.Height &&
                !ColorsEqual(_bm.GetPixel(p.X, p.Y), _penColor))
            {
                Color oldColor = _bm.GetPixel(p.X, p.Y);
                Point temp = GetLocalPoint(new Point(p.X, p.Y), origin);
                if (ColorsEqual(_bmFillPicture.GetPixel(temp.X, temp.Y), oldColor)) return;

                Point left = new Point(p.X, p.Y);
                while (left.X > 0 && ColorsEqual(_bm.GetPixel(left.X, left.Y), oldColor)) left.X -= 1;
                Point right = new Point(p.X, p.Y);
                while (right.X < _bm.Width - 1 && ColorsEqual(_bm.GetPixel(right.X, right.Y), oldColor)) right.X += 1;

                if (left.X == 0) left.X = -1;
                if (right.X == _bm.Width - 1) right.X = _bm.Width;

                for (int i = left.X + 1; i <= right.X - 1; i++)
                {
                    Point localP = GetLocalPoint(new Point(i, left.Y), origin);
                    _bm.SetPixel(i, left.Y, _bmFillPicture.GetPixel(localP.X, localP.Y));
                }

                pictureBox1.Image = _bm;

                for (int i = left.X + 1; i <= right.X - 1; i++)
                    PictureFill_(new Point(i, p.Y + 1), origin);
                for (int i = left.X + 1; i <= right.X - 1; i++)
                    PictureFill_(new Point(i, p.Y - 1), origin);
            }
        }

        Point GetNeighboor(Point p, int dir)
        {
            Point p1 = new Point(0, 0);
            switch (dir)
            {
                case 0: p1 = new Point(p.X, p.Y - 1); break;
                case 1: p1 = new Point(p.X + 1, p.Y - 1); break;
                case 2: p1 = new Point(p.X + 1, p.Y); break;
                case 3: p1 = new Point(p.X + 1, p.Y + 1); break;
                case 4: p1 = new Point(p.X, p.Y + 1); break;
                case 5: p1 = new Point(p.X - 1, p.Y + 1); break;
                case 6: p1 = new Point(p.X - 1, p.Y); break;
                case 7: p1 = new Point(p.X - 1, p.Y - 1); break;
                default: break;
            }
            return p1;
        }

        void SelectEdge(object sender, MouseEventArgs e)
        {
            LinkedList<Point> edge = SelectEdge_(e.Location);
            if (edge.Count > 0)
            {
                foreach (Point p in edge)
                    _bm.SetPixel(p.X, p.Y, edgeColor);
                pictureBox1.Image = _bm;
            }
        }

        LinkedList<Point> SelectEdge_(Point start)
        {
            LinkedList<Point> edge = new LinkedList<Point>();
            edge.AddLast(start);
            Color c = _bm.GetPixel(start.X, start.Y);

            Point cur = start;
            int dir = 4;

            while (true)
            {
                dir += 2;
                if (dir > 7) dir -= 8;
                Point p;

                for (int i = 0; i < 8; i++)
                {
                    p = GetNeighboor(cur, dir);
                    if (!(p.X >= 0 && p.X < _bm.Width && p.Y >= 0 && p.Y < _bm.Height)) continue;
                    if (ColorsEqual(_bm.GetPixel(p.X, p.Y), c)) goto a;
                    dir--;
                    if (dir < 0) dir += 8;
                }
                return new LinkedList<Point>();
            a:
                if (p.X == start.X && p.Y == start.Y) break;

                edge.AddLast(p);
                cur = p;
            }
            return edge;
        }

        void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            _points.Clear();
            _points.Add(e.Location);
        }


        void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            _points.Add(e.Location);

            if (_points.Count < 2)
                return;

            _g.DrawLines(_pen, _points.ToArray());
            pictureBox1.Image = _bm;
        }

        private void Clear()
        {
            var _g = Graphics.FromImage(pictureBox1.Image);
            _g.Clear(pictureBox1.BackColor);
            pictureBox1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clear();
        }
    }
}

