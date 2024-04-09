using System.Runtime.InteropServices;

namespace WinFormsAppViru
{
    public partial class Form1 : Form
    {
        // variaveis
        private const int MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const int MOUSEEVENTF_LEFTUP = 0x0004;
        // metodo que executa o evento de clique
        [DllImport("user32.dll", 
            CharSet = CharSet.Auto, 
            CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(
            int dwFlags,
            int dx,
            int dy,
            int cButtons,
            int dwExtraInfo);

        // gerar as posicoes aleatorias
        private Random random = new Random();

        // Movimento aleatorio do mouse
        private void MoverCursor()
        {
            // obter largura de tela
            int larguraTela = Screen.PrimaryScreen.Bounds.Width;
            // altura da tela
            int alturaTela = Screen.PrimaryScreen.Bounds.Height;
            // posicaoXAleatoria
            int posicaoXAleatoria = random.Next(larguraTela);
            // posicaoYAleatoria
            int posicaoYAleatorio = random.Next(alturaTela);
            // Posicao nova do cursor
            Cursor.Position = new Point(posicaoXAleatoria, posicaoYAleatorio);

        }

        // Clique do mouse
        public Form1()
        {
            InitializeComponent();
        }
    }
}
