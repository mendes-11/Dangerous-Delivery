// using System;
// using System.Drawing;
// using System.Windows.Forms;

// ApplicationConfiguration.Initialize();

// Bitmap bmp = null;
// Graphics g = null;


// Fundo fundo = new Fundo();
// Moto moto = new Moto();

// var pb = new PictureBox {
//     Dock = DockStyle.Fill,
// };

// var timer = new Timer {
//     Interval = 20,
// };

// var form = new Form {
//     WindowState = FormWindowState.Maximized,
//     // FormBorderStyle = FormBorderStyle.None,
//     Text = "Delivery",
//     Controls = { pb }
// };

// form.Load += (o, e) =>
// {
//     bmp = new Bitmap(
//         pb.Width, 
//         pb.Height
//     );
//     g = Graphics.FromImage(bmp);
//     g.Clear(Color.Black);
//     pb.Image = bmp;
//     timer.Start();
// };

// timer.Tick += (o, e) =>
// {
//     g.Clear(Color.SkyBlue);

//     // g.FillRectangle(Brushes.Purple,
//     //     0, 0, .3f * pb.Width, pb.Height
//     // );

//     fundo.Draw(g, pb.Width, pb.Height);
//     // moto.Draw(g, pb.Width, pb.Height);

//     pb.Refresh();
// };

// form.KeyDown += (o, e) =>
// {
//     switch (e.KeyCode)
//     {
//         case Keys.Escape:
//             Application.Exit();
//             break;
        
//         case Keys.D:
//             break;
        
//         case Keys.A:
//             break;
//     }
// };

// form.KeyUp += (o, e) =>
// {
//     switch (e.KeyCode)
//     {
//     }
// };

// Application.Run(form);





// public class Fundo
// {
//     public int X { get; set; }
//     public int Y { get; set; }
//     public float Size { get; set; }
//     private Image img;
//     private Image img2;
//     private Image img3;
//     private Image img4;
//     private Image img5;
//     private Image img6;
//     private Image img7;
//     private Image img8;




//     private DateTime lastDamage = DateTime.MinValue;
//     public Fundo()
//     {
//         this.img = Bitmap.FromFile("CASA1B.png");
//         this.img2 = Bitmap.FromFile("CASA2B.png");
//         this.img3 = Bitmap.FromFile("CASA3B.png");
//         this.img4 = Bitmap.FromFile("CASA4B.png");
//         this.img5 = Bitmap.FromFile("CASA5B.png");
//         this.img6 = Bitmap.FromFile("CASA6B.png");
//         this.img7 = Bitmap.FromFile("CASA7B.png");
//         this.img8 = Bitmap.FromFile("CASA8B.png");

//     }

//     public void Draw(Graphics g, int width, int height)
//     {

//         g.DrawImage(img, 
//             0 , 100,
//             300,
//             400
//         );
//          g.DrawImage(img2, 
//             350 , 100,
//             300,
//             400
//         );
//         g.DrawImage(img3, 
//             700 , 100,
//             300,
//             400
//         );
//         g.DrawImage(img4, 
//             1050 , 100,
//             300,
//             400
//         );
//         g.DrawImage(img5, 
//             1400 , 100,
//             300,
//             400
//         );
//         g.DrawImage(img6, 
//             0 , 500,
//             300,
//             400
//         );
//         g.DrawImage(img7, 
//             350 , 500,
//             300,
//             400
//         );
//         g.DrawImage(img8, 
//             700 , 500,
//             300,
//             400
//         );
//     }
// }

// public class Moto
// {
//     public int X { get; set; }
//     public int Y { get; set; }
//     public float Size { get; set; }
//     private Image img;
//     private DateTime lastDamage = DateTime.MinValue;
//     public Moto()
//     {
//         this.img = Bitmap.FromFile("moto1.png");
//     }

//     public void Draw(Graphics g, int width, int height)
//     {

//         g.DrawImage(img, 
//             550 , 560,
//             600,
//             600
//         );
//     }
// }

// ------------------------------------------
// public class Plano1 : IPlano
// {
//     private int X { get; set; }
//     private int Y { get; set; }
//     private float Size { get; set; }
//     private Image rua;
    

//     public Plano1()
//     {  
//          this.rua = Bitmap.FromFile("Image/RUA.png");
//     }



//     public void Draw(Graphics g, int X, int Y, int width, int height, int vel)
//     {

//         g.DrawImage(rua, X - this.X , Y, width, height);
//         // g.DrawImage(rua, 0 - X , 700, 2000, 300);
//         X += vel;
//     }
    
// }

// ------------------------------------------


// public class Fundo
// {
//     private int X { get; set; }
//     private int Y { get; set; }
//     private float Size { get; set; }
//     private Image img;
//     private Image img2;
//     private Image img3;
//     private Image img4;
//     private Image img5;
//     private Image img6;
//     private Image img7;
//     private Image img8;
//     private Image rua;
    



//     public Fundo()
//     {
//         this.img = Bitmap.FromFile("Image/CASA1B.png");
//         this.img2 = Bitmap.FromFile("Image/CASA2B.png");
//         this.img3 = Bitmap.FromFile("Image/CASA3B.png");
//         this.img4 = Bitmap.FromFile("Image/CASA4B.png");
//         this.img5 = Bitmap.FromFile("Image/CASA5B.png");
//         this.img6 = Bitmap.FromFile("Image/CASA6B.png");
//         this.img7 = Bitmap.FromFile("Image/CASA7B.png");
//         this.img8 = Bitmap.FromFile("Image/CASA8B.png");
//         // this.rua = Bitmap.FromFile("Image/RUA.png");
//         this.rua = Bitmap.FromFile("Image/rua.jpeg");


//     }

//     public void Draw(Graphics g, int width, int height)
//     {
//         // g.DrawImage(img, 0 , 500, 2000, 400);
//         g.DrawImage(img, 0 - X, 100);
//         g.DrawImage(img2, 350 - X, 100);
//         g.DrawImage(img3, 700 - X, 100);
//         g.DrawImage(img4, 1050 - X, 100);
//         g.DrawImage(img5, 1400 - X, 100);
//         g.DrawImage(img6, 1750 - X, 100);
//         g.DrawImage(img7, 2000 - X, 100);
//         g.DrawImage(img8, 2350 - X, 100);
//         g.DrawImage(rua, 0 - X , 700, 2000, 300);


//         X += 5; 
//         if (X > img.Width) X = 0;
//     }
    
// }

// public class Moto
// {
//     private int X { get; set; }
//     private int Y { get; set; }
//     private float Size { get; set; }
//     private Image img;
//     private DateTime lastDamage = DateTime.MinValue;

//     public Moto()
//     {
//         this.img = Bitmap.FromFile("Image/moto1.png");
//     }

//     public void Draw(Graphics g, int width, int height)
//     {
//         g.DrawImage(img, 300, 600, 500, 500);
//     }
// }

