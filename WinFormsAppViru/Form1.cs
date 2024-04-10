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

        // no evento de clique
        private void button1_Click(object sender, EventArgs e)
        {
            // para i igual a 0 até i menor que 10 repita
            for(int i = 0; i < 100; i++)
            {
                // chamando o metodo que mover o curso aleatorio
                MoverCursor();

                for(int tico = 1; tico <= 2; tico++)
                {
                    MouseClicar();
                }                               

                // Cerebro.Dormir 1 segundo
                Thread.Sleep(100);
            }           
        }

        private void MouseClicar()
        {
            // executa o pressionar o botao esquerdo do mouse
            mouse_event(
                MOUSEEVENTF_LEFTDOWN, // codigo do evento de pressionar
                Cursor.Position.X,    // posicao x do cursor
                Cursor.Position.Y, 0, 0); // posicao y do cursos
            // executa o soltar o botao esquerdo do mouse
            mouse_event(
                MOUSEEVENTF_LEFTUP,  // codigo do evento de soltar o botao
                Cursor.Position.X,   // posicao x do cursor
                Cursor.Position.Y, 0, 0); // posicao y do cursor
        }
    }
}
