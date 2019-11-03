using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjektGK1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Bitmap background;
      //  Graphics scG;

        private Rectangle rectangleObj=Rectangle.Empty;
        private List<List<Point>> points= new List<List<Point>>();
        private List<int> index = new List<int>();
        private List<Color> color = new List<Color>();
        private List<bool> finish_graph = new List<bool>();
        private int number_of_graphs=-1;
        private int which_graph;
        private int size = 4;
        int mode = 0;
        bool new_graph = true;
        List<int[]> properties = new List<int[]>();


        private void Form1_Load(object sender, EventArgs e)
        {          
            
            background = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = background;
            which_graph = number_of_graphs;
            points.Add(new List<Point>());
            //points[0].Add(new Point(336, 92));
            points[0].Add(new Point(295, 203));
            points[0].Add(new Point(122, 222));
            points[0].Add(new Point(111, 78));
            points[0].Add(new Point(204, 55));
            points[0].Add(new Point(297, 54));
            points.Add(new List<Point>());
            points[1].Add(new Point(408, 101));
            points[1].Add(new Point(459, 229));
            points[1].Add(new Point(267, 243));
            points[1].Add(new Point(211, 152));
            points[1].Add(new Point(383, 32));
            points[1].Add(new Point(480, 41));
            index.Add(4);
            index.Add(5);
            finish_graph.Add(true);
            finish_graph.Add(true);
            number_of_graphs = 1;
            color.Add(Color.Aqua);
            color.Add(Color.Red);

            properties.Add(new int[] { -1 });
            properties.Add(new int[] {-1 });

            Refresh();
        }      

        //}
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            background = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = background;;
            if (number_of_graphs > -1)
            {
                for (int j = 0; j <= number_of_graphs; j++)
                {

                    for (int i = 0; i <= index[j]; i++)
                    {
                        if (index[j] >= 1 && index[j] > i)
                            BresenhamLine(points[j][i].X, points[j][i].Y, points[j][i + 1].X, points[j][i + 1].Y, color[j], e);
                        
                        AddVertex(points[j][i].X, points[j][i].Y, color[j], e);
                    }
                    if (finish_graph[j] && index[j] != -1)
                    {
                        BresenhamLine(points[j][index[j]].X, points[j][index[j]].Y, points[j][0].X, points[j][0].Y, color[j], e);

                    }
                    if (properties[j][0] != -1)
                    {
                        // if()
                        if (properties[j][0] == 0 || properties[j][0] == 1)
                        {
                            if (properties[j][4] != -1)
                            {
                                Point p1, p2, p11, p22;
                                p1 = points[properties[j][1]][properties[j][2]];
                                p11 = points[properties[j][1]][properties[j][3]];

                                p2 = points[properties[j][1]][properties[j][5]];
                                p22 = points[properties[j][1]][properties[j][6]];
                                double x1 = p1.X, x11 = p11.X, y1 = p1.Y, y11 = p11.Y;
                                double x2 = p2.X, x22 = p22.X, y2 = p2.Y, y22 = p22.Y;
                                double a, b, c, d;
                                // ustalenie kierunku rysowania
                                if (x1 < x11)
                                {
                                    a = x1 + (x11 - x1) / 2;
                                }
                                else
                                {
                                    a = x11 + (x1 - x11) / 2;
                                }
                                if (y1 < y11)
                                {
                                    b = y1 + (y11 - y1) / 2;
                                }
                                else
                                {
                                    b = y11 + (y1 - y11) / 2;
                                }

                                if (x2 < x22)
                                {
                                    c = x2 + (x22 - x2) / 2;
                                }
                                else
                                {
                                    c = x22 + (x2 - x22) / 2;
                                }
                                if (y2 < y22)
                                {
                                    d = y2 + (y22 - y2) / 2;
                                }
                                else
                                {
                                    d = y22 + (y2 - y22) / 2;
                                }
                                // ustalenie kierunku rysowania
                                if (properties[j][0] == 0)
                                {
                                    AddPara((int)a, (int)b, e);
                                    AddPara((int)c, (int)d, e);

                                }
                                if (properties[j][0] == 1)
                                {
                                    AddEq((int)a, (int)b, e);
                                    AddEq((int)c, (int)d, e);
                                }
                            }
                        }
                        if(properties[j][0]==2)
                        {
                            for(int i=2;i<properties[j].Length;i++)
                            AddDont(points[properties[j][1]][ properties[j][i]].X, points[properties[j][1]][properties[j][i]].Y, e);
                        }
                    }
                }
            }
        }
        
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (mode == 0)
            {
                if(new_graph)
                {
                    finish_graph.Add(false);
                    index.Add(-1);
                    points.Add(new List<Point>());
                    Random r = new Random();
                    color.Add(Color.FromArgb(r.Next(0, 256), r.Next(0, 256), r.Next(0, 256)));
                    new_graph = false;
                    number_of_graphs++;
                    properties.Add(new int[]{ -1});
                }
                points[number_of_graphs].Add(e.Location);
                ++index[number_of_graphs];

                if (index[number_of_graphs] == -1) return;
            }
            if (mode == 3)
            {
                int[] vertex = looking_for_vertex(e.Location);
                if(vertex[0]!=-1)
                {
                    if (properties[vertex[0]][0] != -1)
                    {
                        properties[vertex[0]] = new int[] { -1 };
                    }
                   
                    if(index[vertex[0]]==0)
                    {
                        points.RemoveAt(vertex[0]);
                        number_of_graphs--;
                        index.RemoveAt(vertex[0]);
                        finish_graph.RemoveAt(vertex[0]);
                        color.RemoveAt(vertex[0]);
                        properties.RemoveAt(vertex[0]);

                        if (number_of_graphs == -1)
                        {
                            new_graph = true;
                            points.Clear();
                            finish_graph.Clear();
                            index.Clear();
                            color.Clear();
                            mode = 0;
                            properties.Clear();
                            
                        }
                        
                    }
                    else if(index[vertex[0]]==vertex[1]||vertex[1]==0)
                    {
                        points[vertex[0]].RemoveAt(vertex[1]);
                        
                        if(finish_graph[vertex[0]])
                        {
                            finish_graph[vertex[0]] = false;
                        }
                        index[vertex[0]]--;
                    }
                    else if(finish_graph[vertex[0]])
                    {
                        List<Point> tmp = new List<Point>();
                        tmp = points[vertex[0]];
                        points[vertex[0]] = new List<Point>();
                        points[vertex[0]] = tmp.GetRange(vertex[1] + 1, index[vertex[0]] - vertex[1] );
                        points[vertex[0]].AddRange(tmp.GetRange(0, vertex[1]));                        
                        finish_graph[vertex[0]] = false;
                        
                            //if (index[number_of_graphs])
                        index[vertex[0]]--;
                        
                    }
                    else 
                    {
                        List<Point> tmp = new List<Point>();
                        
                        tmp = points[vertex[0]];
                        points[vertex[0]] = new List<Point>();
                        points[vertex[0]] = tmp.GetRange(vertex[1] + 1, index[vertex[0]] - vertex[1]);
                        index[vertex[0]]= index[vertex[0]] - vertex[1]-1;
                       
                        points.Add(new List<Point>());
                        number_of_graphs++;
                        index.Add(vertex[1]-1);                        
                        points[number_of_graphs].AddRange(tmp.GetRange(0, vertex[1]));                        
                        finish_graph.Add(false);
                        Random r = new Random();
                        color.Add(Color.FromArgb(r.Next(0, 256), r.Next(0, 256), r.Next(0, 256)));
                        properties.Add(new int[] { -1 });
                       
                    }
                    
                }
            }
            if(mode==5)
            {
                int[] edge_f = look_for_edge(e.Location);
                if(edge_f[0]!=-1)
                {
                   
                    if (edge_f[1] != index[edge_f[0]])
                    {
                        List<Point> tmp = points[edge_f[0]];
                        if (properties[edge_f[0]][0] != -1)
                        {
                            if ((properties[edge_f[0]][2] == edge_f[1] && properties[edge_f[0]][3] == edge_f[1] + 1) || (properties[edge_f[0]][2] == edge_f[1] + 1 && properties[edge_f[0]][3] == edge_f[1]) || (properties[edge_f[0]][5] == edge_f[1] && properties[edge_f[0]][6] == edge_f[1] + 1) || (properties[edge_f[0]][5] == edge_f[1] + 1 && properties[edge_f[0]][6] == edge_f[1]))
                            {
                                properties[edge_f[0]] = new int[] { -1 };
                            }
                        }
                        points[edge_f[0]] = new List<Point>();
                        points[edge_f[0]].AddRange(tmp.GetRange(0, edge_f[1]+1));
                        points[edge_f[0]].Add(e.Location);
                        points[edge_f[0]].AddRange(tmp.GetRange(edge_f[1]+1, index[edge_f[0]] - edge_f[1]));
                        if (properties[edge_f[0]][0] != -1)
                        {
                            if (edge_f[1] < properties[edge_f[0]][2])
                                properties[edge_f[0]][2]++;
                            if (edge_f[1] < properties[edge_f[0]][3])
                                properties[edge_f[0]][3]++;
                            if (edge_f[1] < properties[edge_f[0]][5])
                                properties[edge_f[0]][5]++;
                            if (edge_f[1] < properties[edge_f[0]][6])
                                properties[edge_f[0]][6]++;
                        }

                        index[edge_f[0]]++;
                        color[edge_f[0]] = Prev_color;
                        
                    }
                    else
                    {
                        points[edge_f[0]].Add(e.Location);
                        index[edge_f[0]]++;
                        color[edge_f[0]] = Prev_color;
                        if (properties[edge_f[0]][0] != -1)
                        {
                            if ((properties[edge_f[0]][2] == edge_f[1] && properties[edge_f[0]][3] == 0) || (properties[edge_f[0]][2] == 0 && properties[edge_f[0]][3] == edge_f[1]) || (properties[edge_f[0]][5] == edge_f[1] && properties[edge_f[0]][6] == 0) || (properties[edge_f[0]][5] == 0 && properties[edge_f[0]][6] == edge_f[1]))
                            {
                                properties[edge_f[0]] = new int[] { -1 };
                            }
                        }
                    }
                }                
            }
           
            if (mode==6)
            {
               // if (Prev_color != Color.AntiqueWhite)
                 //   prev = Prev_color;
                int[] edge_f = look_for_edge(e.Location);
                
                if(edge_f[0]!=-1 && finish_graph[edge_f[0]])
                {
                    if (properties[edge_f[0]][0] == -1)
                    {
                        if(edge_f[1]!=index[edge_f[0]])
                        {
                            properties[edge_f[0]] = new int[] { 0, edge_f[0], edge_f[1],edge_f[1]+1, -1,-1, -1 };
                        }
                        else
                            properties[edge_f[0]] = new int[] { 0, edge_f[0], edge_f[1], 0, -1, -1, -1 };
                        

                    }
                    else if(properties[edge_f[0]][0] == 0 && properties[edge_f[0]][4]==-1 && properties[edge_f[0]][1]==edge_f[0]&& (properties[edge_f[0]][2] != edge_f[1]&& properties[edge_f[0]][3] != edge_f[1]))
                    {
                       // color[edge_f[0]] = prev;
                        properties[edge_f[0]][4] = edge_f[0];
                        properties[edge_f[0]][5] = edge_f[1];
                        if (edge_f[1] != index[edge_f[0]])
                        {
                            properties[edge_f[0]][6] = edge_f[1] + 1;
                        }
                        else
                            properties[edge_f[0]][6] = 0;
                        Point p1, p11, p2, p22;
                        
                            p1 = points[properties[edge_f[0]][1]][properties[edge_f[0]][2]];
                            p11 = points[properties[edge_f[0]][1]][properties[edge_f[0]][3]];
                        
                        
                            p2 = points[properties[edge_f[0]][4]][properties[edge_f[0]][5]];
                            p22 = points[properties[edge_f[0]][4]][properties[edge_f[0]][6]];
                        
                        
                        double x1=p1.X-p11.X, y1=p1.Y-p11.Y, x2=p2.X-p22.X, y2=p2.Y-p22.Y;
                        double f1 = x1 / y1;
                        double f2 = x2 / y2;
                        if (f1!=f2|| f1!=-f2)
                        {
                            points[properties[edge_f[0]][4]][properties[edge_f[0]][5]]=new Point((int)(x1*y2/y1)+p22.X,p2.Y);
                           
                        }
                       
                        mode = 0;
                    }
                }
            }
            if(mode==7)
            {
                
                int[] edge_f = look_for_edge(e.Location);

                if (edge_f[0] != -1)
                {
                    if (properties[edge_f[0]][0] == -1)
                    {
                        if (edge_f[1] != index[edge_f[0]])
                        {
                            properties[edge_f[0]] = new int[] { 1, edge_f[0], edge_f[1], edge_f[1] + 1, -1, -1, -1 };
                        }
                        else
                            properties[edge_f[0]] = new int[] { 1, edge_f[0], edge_f[1], 0, -1, -1, -1 };
                       // prev = Prev_color;

                    }
                    else if (properties[edge_f[0]][0] == 1 && properties[edge_f[0]][4] == -1 && properties[edge_f[0]][1] == edge_f[0])
                    {
                       // color[edge_f[0]] = prev;
                        properties[edge_f[0]][4] = edge_f[0];
                        properties[edge_f[0]][5] = edge_f[1];
                        if (edge_f[1] != index[edge_f[0]])
                        {
                            properties[edge_f[0]][6] = edge_f[1] + 1;
                        }
                        else
                            properties[edge_f[0]][6] = 0;
                        Point p1, p11, p2, p22;

                        p1 = points[properties[edge_f[0]][1]][properties[edge_f[0]][2]];
                        p11 = points[properties[edge_f[0]][1]][properties[edge_f[0]][3]];


                        p2 = points[properties[edge_f[0]][4]][properties[edge_f[0]][5]];
                        p22 = points[properties[edge_f[0]][4]][properties[edge_f[0]][6]];


                        double x1 = Math.Abs(p1.X - p11.X), y1 = Math.Abs(p1.Y - p11.Y), x2 = Math.Abs(p2.X - p22.X), y2 = Math.Abs(p2.Y - p22.Y);
                        
                        double f1 = x1*x1+y1*y1;
                        double f2 = x2*x2+y2*y2;
                        double a = 0.3;
                        if (f1 != f2)
                        {
                            if (f1 > f2)
                            {
                                int w = 2;
                                //x1 = x1 * 2;
                               //y1 = y1 * 2;

                                if (properties[edge_f[0]][5] == properties[edge_f[0]][w] || properties[edge_f[0]][6] == properties[edge_f[0]][w])
                                    w = 3;
                                if (w==2)
                                    points[properties[edge_f[0]][4]][properties[edge_f[0]][w]] = new Point(p1.X - (int)(Math.Sqrt((f2/ f1))*x1), p1.Y - (int)(Math.Sqrt((f2/ f1)) * y1)) ;
                                else if ( w == 3)
                                    points[properties[edge_f[0]][4]][properties[edge_f[0]][w]] = new Point(p11.X - (int)(Math.Sqrt((f2/ f1))*x1), p11.Y - (int)(Math.Sqrt((f2 / f1)) * y1));
                               // else if (x1 < x2 && y1 > y2 && w == 2)
                                  //  points[properties[edge_f[0]][4]][properties[edge_f[0]][w]] = new Point(p11.X, p11.Y - (int)(Math.Sqrt((f1 - f2))*0.7));
                            }
                            else
                            {
                               // x2 = x2 * 2;
                               //y2 = y2 * 2;
                                int w = 5;
                                if (properties[edge_f[0]][2] == properties[edge_f[0]][w]|| properties[edge_f[0]][3]== properties[edge_f[0]][w])
                                    w = 6;
                                if (w==5)
                                    points[properties[edge_f[0]][4]][properties[edge_f[0]][w]] = new Point(p2.X - (int)(Math.Sqrt((f1 / f2))*x2), p2.Y - (int)(Math.Sqrt((f1 / f2))* y2));
                                else if ( w == 6)
                                    points[properties[edge_f[0]][4]][properties[edge_f[0]][w]] = new Point(p22.X - (int)(Math.Sqrt((f1 / f2))*x2), p22.Y - (int)(Math.Sqrt((f1 / f2))* y2));
                                //else if (x1 > x2 && y1 < y2 && w == 6)
                                //    points[properties[edge_f[0]][4]][properties[edge_f[0]][w]] = new Point(p22.X , p22.Y - (int)(Math.Sqrt((f2 - f1))*0.7));

                            }
                            Refresh();
                        }

                        mode = 0;
                    }
                }
            }
            if (mode == 8)
            {
                int[] edge_f = look_for_edge(e.Location);
                if (edge_f[0] != -1)
                {

                    if(properties[edge_f[0]][0]!=-1&& properties[edge_f[0]][0]!=2)
                    {
                        if(properties[edge_f[0]][3]==edge_f[1]|| properties[edge_f[0]][2] == edge_f[1]|| properties[edge_f[0]][5] == edge_f[1]|| properties[edge_f[0]][6] == edge_f[1])
                        {
                            properties[edge_f[0]] = new int[]{ -1 };
                            
                        }
                    }
                    color[edge_f[0]] = Prev_color;
                }
                int[] vert_f = looking_for_vertex(e.Location);
                if(vert_f[0]!=-1)
                if(properties[vert_f[0]][0]==2)
                {
                    properties[vert_f[0]] = new int[] { -1 };
                }
            }
            if(mode==9)
            {
                int[] vertex = looking_for_vertex(e.Location);
                if(vertex[0]!=-1&&(properties[vertex[0]][0]==-1||properties[vertex[0]][0]==2))
                {
                    if(properties[vertex[0]].Length==1)
                         properties[vertex[0]] = new int[] { 2, vertex[0], vertex[1] };
                    else
                    {

                        List<int> l = properties[vertex[0]].ToList<int>();
                        l.Add(vertex[1]);
                        properties[vertex[0]] = l.ToArray();

                    }
                }
            }
                

            Refresh();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            points.Clear();
            index.Clear();
            color.Clear();
            finish_graph.Clear();
            which_graph = 0;
            number_of_graphs = -1;
            properties.Clear();
            new_graph = true;
            mode = 0;
            pictureBox1.Refresh();

        }
        private static void PutPixel(int x, int y, Color color, PaintEventArgs e)
        {
            using (SolidBrush brush = new SolidBrush(color))
                e.Graphics.FillRectangle(brush, x, y, 1, 1);
            
        }
        private void AddVertex(int x, int y, Color color, PaintEventArgs e)
        {
            for( int i = x-size; i < x+size;i++ )
            {
                for(int j=y-size; j<y+size;j++)
                {
                    PutPixel(i, j, color, e);
                }
            }
        }
        private void AddPara(int x, int y, PaintEventArgs e)
        {
            for (int i = x-2*size ; i < x + 2*size; i++)
            {
                for (int j = y - 2*size; j < y + 2*size; j++)
                {
                    if(i!=x-size && i!=x+size)
                    PutPixel(i, j, Color.White, e);
                    else
                    PutPixel(i, j, Color.Black, e);
                }
            }
        }
        private void AddEq(int x, int y, PaintEventArgs e)
        {
            for (int i = x - 2 * size; i < x + 2 * size; i++)
            {
                for (int j = y - 2 * size; j < y + 2 * size; j++)
                {
                    if (j != y - size&& j != y - size+1 && j != y + size&& j != y -1+ size)
                        PutPixel(i, j, Color.White, e);
                    else
                        PutPixel(i, j, Color.Black, e);
                }
            }
        }
        private void AddDont(int x, int y, PaintEventArgs e)
        {
            for (int i = -  2*size; i <  2*size; i++)
            {
                for (int j =  - 2* size; j < 2*size; j++)
                {
                    if (j == i || j ==-i)
                        PutPixel(x+i, y+j, Color.White, e);
                    else
                        PutPixel(i+x, j+y, Color.Red, e);
                }
            }
        }

        private void BresenhamLine(int x1, int y1, int x2, int y2, Color color, PaintEventArgs e)
        {
            // zmienne pomocnicze
            int d, dx, dy, ai, bi, xi, yi;
            int x = x1, y = y1;
            // ustalenie kierunku rysowania
            if (x1 < x2)
            {
                xi = 1;
                dx = x2 - x1;
            }
            else
            {
                xi = -1;
                dx = x1 - x2;
            }
            // ustalenie kierunku rysowania
            if (y1 < y2)
            {
                yi = 1;
                dy = y2 - y1;
            }
            else
            {
                yi = -1;
                dy = y1 - y2;
            }
            // pierwszy piksel
            PutPixel(x, y, color, e);
            //   glVertex2i(x, y);
            // oś wiodąca OX
            if (dx > dy)
            {
                ai = (dy - dx) * 2;
                bi = dy * 2;
                d = bi - dx;
                // pętla po kolejnych x
                while (x != x2)
                {
                    // test współczynnika
                    if (d >= 0)
                    {
                        x += xi;
                        y += yi;
                        d += ai;
                    }
                    else
                    {
                        d += bi;
                        x += xi;
                    }
                    PutPixel(x, y, color, e);
                    //   glVertex2i(x, y);
                }
            }
            // oś wiodąca OY
            else
            {
                ai = (dx - dy) * 2;
                bi = dx * 2;
                d = bi - dy;
                // pętla po kolejnych y
                while (y != y2)
                {
                    // test współczynnika
                    if (d >= 0)
                    {
                        x += xi;
                        y += yi;
                        d += ai;
                    }
                    else
                    {
                        d += bi;
                        y += yi;
                    }
                    PutPixel(x, y, color, e);
                    //  glVertex2i(x, y);
                }
            }
        }

        private void finishGraphToolStripMenuItem_Click(object sender, EventArgs e)
        {
            finish_graph[points.Count-1] = true;
            which_graph = number_of_graphs;
            
            new_graph = true;
            pictureBox1.Refresh();
        }

        //////////movment

        int[] vertex_found= { -1, -1 };
        Color Prev_color;
        private void moveVertexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mode = 1;
        }

        private void moveGraphToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mode = 2;
        }
        public int[] looking_for_vertex(Point point)
        {
            int[] tab = { -1, -1 };            //which graph and which vertex in graph

            for (int j = 0; j <= number_of_graphs; j++)
                for (int i = 0; i <= index[j]; i++)
                {
                    if (point.X >= points[j][i].X-size && point.X <= (points[j][i].X + size) && point.Y >= points[j][i].Y-size && point.Y <= (points[j][i].Y + size))
                    {
                        Prev_color = color[j];
                        if (mode != 3&&mode!=9&&mode!=8)
                        {
                            color[j] = Color.AntiqueWhite;
                        }
                        tab[0] = j;
                        tab[1] = i;
                        break;
                    }
                }

            pictureBox1.Refresh();
            return tab;
        }
        int[] edge_found= { -1, -1 };
        Point previous_edge_point;
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if(mode==1 || mode==2)
            {
                
                vertex_found = looking_for_vertex(e.Location);

            }
            if (mode == 4)
            {
                edge_found=look_for_edge(e.Location);
                previous_edge_point = e.Location;
                //mode = 5;
            }
        }
       // Point previous_vertex_pos;
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            Point currentPoint = new Point(((MouseEventArgs)e).X, ((MouseEventArgs)e).Y);
            if (mode==1)
            {
                if (vertex_found[0]!=-1)
                {
                    if(properties[vertex_found[0]][0]==-1)
                         points[vertex_found[0]][vertex_found[1]] = currentPoint;
                    else if(properties[vertex_found[0]][0]==0 &&(properties[vertex_found[0]][2] == vertex_found[1]||properties[vertex_found[0]][3] == vertex_found[1]) )
                    {
                        points[vertex_found[0]][vertex_found[1]] = currentPoint;
                        Point p1, p11, p2, p22;

                        p1 = points[properties[vertex_found[0]][1]][properties[vertex_found[0]][2]];
                        p11 = points[properties[vertex_found[0]][1]][properties[vertex_found[0]][3]];


                        p2 = points[properties[vertex_found[0]][4]][properties[vertex_found[0]][5]];
                        p22 = points[properties[vertex_found[0]][4]][properties[vertex_found[0]][6]];


                        double x1 = p1.X - p11.X, y1 = p1.Y - p11.Y, x2 = p2.X - p22.X, y2 = p2.Y - p22.Y;
                        double f1 = x1 / y1;
                        double f2 = x2 / y2;
                        if (f1 != f2 || f1 != -f2)
                        {
                            points[properties[vertex_found[0]][4]][properties[vertex_found[0]][5]] = new Point((int)(x1 * y2 / y1) + p22.X, p2.Y);

                        }
                    }
                    else if(properties[vertex_found[0]][0] == 0&&(properties[vertex_found[0]][5] == vertex_found[1] || properties[vertex_found[0]][6] == vertex_found[1]))
                    {
                        points[vertex_found[0]][vertex_found[1]] = currentPoint;
                        int t;
                        t = properties[vertex_found[0]][5];
                        properties[vertex_found[0]][5] = properties[vertex_found[0]][2];
                        properties[vertex_found[0]][2] = t;
                        t = properties[vertex_found[0]][6];
                        properties[vertex_found[0]][6] = properties[vertex_found[0]][3];
                        properties[vertex_found[0]][3] = t;
                        Point p1, p11, p2, p22;

                        p1 = points[properties[vertex_found[0]][1]][properties[vertex_found[0]][2]];
                        p11 = points[properties[vertex_found[0]][1]][properties[vertex_found[0]][3]];


                        p2 = points[properties[vertex_found[0]][4]][properties[vertex_found[0]][5]];
                        p22 = points[properties[vertex_found[0]][4]][properties[vertex_found[0]][6]];


                        double x1 = p1.X - p11.X, y1 = p1.Y - p11.Y, x2 = p2.X - p22.X, y2 = p2.Y - p22.Y;
                        double f1 = x1 / y1;
                        double f2 = x2 / y2;
                        if (f1 != f2 || f1 != -f2)
                        {
                            points[properties[vertex_found[0]][4]][properties[vertex_found[0]][5]] = new Point((int)(x1 * y2 / y1) + p22.X, p2.Y);

                        }

                    }
                    else if(properties[vertex_found[0]][0]==2)
                    {
                        int[] tmp = properties[vertex_found[0]].ToList<int>().GetRange(2, properties[vertex_found[0]].Length - 2).ToArray();
                        if (!tmp.Contains<int>(vertex_found[1]) )
                        {
                            
                            points[vertex_found[0]][vertex_found[1]] = currentPoint;
                        }
                    }



                   // pictureBox1.Refresh();
                }
                pictureBox1.Refresh();
            }
            else if(mode==2)
            {
                
                if (vertex_found[0] != -1&&properties[vertex_found[0]][0]!=2)
                {
                    Point previous = points[vertex_found[0]][vertex_found[1]];
                    points[vertex_found[0]][vertex_found[1]] = currentPoint;
                    for (int i=0;i<=index[vertex_found[0]];i++)
                    {
                        if(i!=vertex_found[1])
                        points[vertex_found[0]][i] = new Point(points[vertex_found[0]][i].X+currentPoint.X-previous.X, points[vertex_found[0]][i].Y+currentPoint.Y - previous.Y);
                    }
                   // points[vertex_found[0]][vertex_found[1]] = currentPoint;
                    pictureBox1.Refresh();
                }
               
                pictureBox1.Refresh();

            }
            else if(mode==4)
            {
                if(edge_found[0]!=-1)
                {
                    // Point currentPoint1 = new Point(((MouseEventArgs)e).X, ((MouseEventArgs)e).Y);
                    if (properties[edge_found[0]][0] == -1)
                    {
                        points[edge_found[0]][edge_found[1]] = new Point(points[edge_found[0]][edge_found[1]].X + (currentPoint.X - previous_edge_point.X), points[edge_found[0]][edge_found[1]].Y + (currentPoint.Y - previous_edge_point.Y));
                        if (index[edge_found[0]] == edge_found[1])
                            points[edge_found[0]][0] = new Point(points[edge_found[0]][0].X + currentPoint.X - previous_edge_point.X, points[edge_found[0]][0].Y + currentPoint.Y - previous_edge_point.Y);

                        else
                            points[edge_found[0]][edge_found[1] + 1] = new Point(points[edge_found[0]][edge_found[1] + 1].X + currentPoint.X - previous_edge_point.X, points[edge_found[0]][edge_found[1] + 1].Y + currentPoint.Y - previous_edge_point.Y);
                        previous_edge_point = currentPoint;
                    }
                    else if (properties[edge_found[0]][0] == 0 && (properties[edge_found[0]][2] == edge_found[1] || properties[edge_found[0]][3] == edge_found[1]))
                    {
                        points[edge_found[0]][edge_found[1]] = new Point(points[edge_found[0]][edge_found[1]].X + (currentPoint.X - previous_edge_point.X), points[edge_found[0]][edge_found[1]].Y + (currentPoint.Y - previous_edge_point.Y));
                        if (index[edge_found[0]] == edge_found[1])
                            points[edge_found[0]][0] = new Point(points[edge_found[0]][0].X + currentPoint.X - previous_edge_point.X, points[edge_found[0]][0].Y + currentPoint.Y - previous_edge_point.Y);

                        else
                            points[edge_found[0]][edge_found[1] + 1] = new Point(points[edge_found[0]][edge_found[1] + 1].X + currentPoint.X - previous_edge_point.X, points[edge_found[0]][edge_found[1] + 1].Y + currentPoint.Y - previous_edge_point.Y);
                        previous_edge_point = currentPoint;

                        Point p1, p11, p2, p22;

                        p1 = points[properties[edge_found[0]][1]][properties[edge_found[0]][2]];
                        p11 = points[properties[edge_found[0]][1]][properties[edge_found[0]][3]];


                        p2 = points[properties[edge_found[0]][4]][properties[edge_found[0]][5]];
                        p22 = points[properties[edge_found[0]][4]][properties[edge_found[0]][6]];


                        double x1 = p1.X - p11.X, y1 = p1.Y - p11.Y, x2 = p2.X - p22.X, y2 = p2.Y - p22.Y;
                        double f1 = x1 / y1;
                        double f2 = x2 / y2;
                        if (f1 != f2 || f1 != -f2)
                        {
                            points[properties[edge_found[0]][4]][properties[edge_found[0]][5]] = new Point((int)(x1 * y2 / y1) + p22.X, p2.Y);

                        }
                    }
                    else if (properties[edge_found[0]][0] == 0 && (properties[edge_found[0]][5] == edge_found[1] || properties[edge_found[0]][6] == edge_found[1]))
                    {
                        points[edge_found[0]][edge_found[1]] = new Point(points[edge_found[0]][edge_found[1]].X + (currentPoint.X - previous_edge_point.X), points[edge_found[0]][edge_found[1]].Y + (currentPoint.Y - previous_edge_point.Y));
                        if (index[edge_found[0]] == edge_found[1])
                            points[edge_found[0]][0] = new Point(points[edge_found[0]][0].X + currentPoint.X - previous_edge_point.X, points[edge_found[0]][0].Y + currentPoint.Y - previous_edge_point.Y);

                        else
                            points[edge_found[0]][edge_found[1] + 1] = new Point(points[edge_found[0]][edge_found[1] + 1].X + currentPoint.X - previous_edge_point.X, points[edge_found[0]][edge_found[1] + 1].Y + currentPoint.Y - previous_edge_point.Y);
                        previous_edge_point = currentPoint;

                        int t;
                        t = properties[edge_found[0]][5];
                        properties[edge_found[0]][5] = properties[edge_found[0]][2];
                        properties[edge_found[0]][2] = t;
                        t = properties[edge_found[0]][6];
                        properties[edge_found[0]][6] = properties[edge_found[0]][3];
                        properties[edge_found[0]][3] = t;
                        Point p1, p11, p2, p22;

                        p1 = points[properties[edge_found[0]][1]][properties[edge_found[0]][2]];
                        p11 = points[properties[edge_found[0]][1]][properties[edge_found[0]][3]];


                        p2 = points[properties[edge_found[0]][4]][properties[edge_found[0]][5]];
                        p22 = points[properties[edge_found[0]][4]][properties[edge_found[0]][6]];


                        double x1 = p1.X - p11.X, y1 = p1.Y - p11.Y, x2 = p2.X - p22.X, y2 = p2.Y - p22.Y;
                        double f1 = x1 / y1;
                        double f2 = x2 / y2;
                        if (f1 != f2 || f1 != -f2)
                        {
                            points[properties[edge_found[0]][4]][properties[edge_found[0]][5]] = new Point((int)(x1 * y2 / y1) + p22.X, p2.Y);

                        }

                    }
                    else if(properties[edge_found[0]][0]==2)
                    {
                        //properties[edge_found[0]].Contains<int>(edge_found[1])
                        int[] tmp = properties[edge_found[0]].ToList<int>().GetRange(2, properties[edge_found[0]].Length - 2).ToArray();
                            if (!tmp.Contains<int>(edge_found[1])&& !tmp.Contains<int>(edge_found[2]))
                            {
                                points[edge_found[0]][edge_found[1]] = new Point(points[edge_found[0]][edge_found[1]].X + (currentPoint.X - previous_edge_point.X), points[edge_found[0]][edge_found[1]].Y + (currentPoint.Y - previous_edge_point.Y));
                                if (index[edge_found[0]] == edge_found[1])
                                    points[edge_found[0]][0] = new Point(points[edge_found[0]][0].X + currentPoint.X - previous_edge_point.X, points[edge_found[0]][0].Y + currentPoint.Y - previous_edge_point.Y);

                                else
                                    points[edge_found[0]][edge_found[1] + 1] = new Point(points[edge_found[0]][edge_found[1] + 1].X + currentPoint.X - previous_edge_point.X, points[edge_found[0]][edge_found[1] + 1].Y + currentPoint.Y - previous_edge_point.Y);
                                previous_edge_point = currentPoint;
                            }
                    }

                }
                pictureBox1.Refresh();
            }
            
        }
                      

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (mode != 0 && mode!=3)
            {
                //mode = 0;

                if(vertex_found[0]!=-1)
                    color[vertex_found[0]] = Prev_color;
                if(edge_found[0] != -1)
                    color[edge_found[0]] = Prev_color;
                vertex_found = new int[] { -1, -1 };
                edge_found= new int[] { -1, -1 };
                Prev_color = new Color();
                pictureBox1.Refresh();
            }
        }

        
        private void addVertexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mode = 0;
        }

        private void deleteVertexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mode = 3;

        }


        ////edge
        private int[] look_for_edge(Point point)
        {

            int[] which_one= { -1, -1 ,-1};
            int zer = -1;
            
            for (int z = 0; z <= number_of_graphs; z++)
            {
                for(int zz=0;zz<=index[z];zz++)
                {  
                    int d, dx, dy, ai, bi, xi, yi;
                    int x1 = points[z][zz].X,x2;
                    int y1 = points[z][zz].Y,y2;
                    float x = x1, y =  y1;
                    if (finish_graph[z] && zz == index[z])
                    {
                        x2 = points[z][0].X;
                        y2 = points[z][0].Y;
                        zer = 0;
                    }
                    else if (zz != index[z])
                    {
                        x2 = points[z][zz + 1].X;
                        y2 = points[z][zz + 1].Y;
                        zer = -1;

                    }
                    else
                        break;

                        if (x1 < x2)
                    {
                        xi = 1;
                        dx = x2 - x1;
                    }
                    else
                    {
                        xi = -1;
                        dx = x1 - x2;
                    }
                    // ustalenie kierunku rysowania
                    if (y1 < y2)
                    {
                        yi = 1;
                        dy = y2 - y1;
                    }
                    else
                    {
                        yi = -1;
                        dy = y1 - y2;
                    }
            // pierwszy piksel
                    for (int i = -size; i < size; i++)
                    {
                        for (int j = -size; j < size; j++)
                        {
                            if (point.X + i == x && point.Y + j == y)
                            {
                                which_one[0] = z;
                                which_one[1] = zz;
                                if (zer == 0)
                                    which_one[2] = 0;
                                else
                                {
                                    which_one[2] = zz + 1;
                                }
                                break;
                            }
                        }
                    }
                    if (dx > dy)
                    {
                        ai = (dy - dx) * 2;
                        bi = dy * 2;
                        d = bi - dx;
                        while (x != x2)
                        {
                            if (d >= 0)
                            {
                                x += xi;
                                y += yi;
                                d += ai;
                            }
                            else
                            {
                                d += bi;
                                x += xi;
                            }
                            for (int i = -size; i < size; i++)
                            {
                                for (int j = -size; j < size; j++)
                                {
                                    if (point.X + i == x && point.Y + j == y)
                                    {
                                        which_one[0] = z;
                                        which_one[1] = zz;
                                        if (zer == 0)
                                            which_one[2] = 0;
                                        else
                                        {
                                            which_one[2] = zz + 1;
                                        }
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    // oś wiodąca OY
                    else
                    {
                        ai = (dx - dy) * 2;
                        bi = dx * 2;
                        d = bi - dy;
                        // pętla po kolejnych y
                        while (y != y2)
                        {
                            // test współczynnika
                            if (d >= 0)
                            {
                                x += xi;
                                y += yi;
                                d += ai;
                            }
                            else
                            {
                                d += bi;
                                y += yi;
                            }
                            for (int i = -size; i < size; i++)
                            {
                                for (int j = -size; j < size; j++)
                                {
                                    if (point.X + i == x && point.Y + j == y)
                                    {
                                        which_one[0] = z;
                                        which_one[1] = zz;
                                        if (zer == 0)
                                            which_one[2] = 0;
                                        else
                                        {
                                            which_one[2] = zz + 1;
                                        }
                                        break;
                                    }
                                }
                            }
                        }
                    }                        
                    
                }
            }
            if (which_one[0] != -1 && (mode!=6&&mode!=7))
            {
                Prev_color = color[which_one[0]];
                
                color[which_one[0]] = Color.AntiqueWhite;
            }
            pictureBox1.Refresh();
            return which_one;

        }

        private void moveEdgeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mode = 4;
        }

        private void addVertexToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            mode = 5;
        }

        private void sameLengthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mode = 7;
        }

        private void paToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mode = 6;
        }

        private void removePropetiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mode = 8;
        }

        private void dontMoveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mode = 9;
        }
    }
}
