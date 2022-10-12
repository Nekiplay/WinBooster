using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinBooster.Native;
using WinBooster.DataBase;

namespace WinBooster
{
    public partial class GameOptimizeForm : Form
    {
        public GameOptimizeForm()
        {
            InitializeComponent();
        }
        private void GameOptimizeForm_Load(object sender, EventArgs e)
        {
            foreach (GameOptimizeI game in GameList.games)
            {
                if (game.GameInstalled())
                {
                    guna2ComboBox1.Items.Add(game.GameName());
                }
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                guna2Button1.Invoke(new MethodInvoker(() =>
                {
                    guna2Button1.Enabled = false;
                }));
                if (guna2ComboBox1.SelectedItem != null)
                {
                    foreach (GameOptimizeI game in GameList.games)
                    {
                        if (game.GameName() == guna2ComboBox1.SelectedItem.ToString())
                        {
                            try {
                                game.Optimize(); 
                            } catch { }
                        }
                    }
                }
                guna2Button1.Invoke(new MethodInvoker(() =>
                {
                    guna2Button1.Enabled = true;
                }));
            });
        }
    }
}
