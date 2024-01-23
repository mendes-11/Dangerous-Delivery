using System.Drawing;
using System.Windows.Forms;

Game game = new Game();
game.Initialize();

Form form = new Form();
game.Run(form);

