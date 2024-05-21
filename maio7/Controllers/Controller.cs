using maio7.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace maio7.Controllers
{
    public class Controller:UIElement   
    {
        public Cmd cmdSair { get; set; }
        public Cmd cmdNavegar { get; set; }
        public Cmd cmdDobro { get; set; }
        public Cmd cmdSelos { get; set; }

        public Controller() 
        {
            cmdSair = new Cmd(Sair, canSair);
            cmdNavegar = new Cmd(Navegar, canNavegar);
            cmdDobro = new Cmd(CalculaDobro, canCalculaDobro);
            cmdSelos = new Cmd(TrocaSelos, canTrocaSelos);
        }

        public bool canTrocaSelos(Object parameter)
        {
            if (parameter == null || String.IsNullOrEmpty(parameter.ToString())) return false;
            int euros;
            if (int.TryParse(parameter.ToString(), out euros))
            {
                if (euros > 0) return true;
                return false;
            }
            else return false;

        }


        public void TrocaSelos(Object parameter)
        {
            String path = AppDomain.CurrentDomain.BaseDirectory;
            int idx = path.LastIndexOf("bin");
            path = path.Substring(0, idx) + @"\Sons\rosca.wav";
            SoundPlayer player = new SoundPlayer(path);
            player.Load();
            player.Play();

            int euros;
            Selos pgselos = (Selos)main.frame.Content;
            if(int.TryParse(parameter.ToString(), out euros))
            {
                pgselos.lbl_Resultado.Content= Biblioteca.trocaSelos(euros);
            }
            else
            {
                pgselos.lbl_Resultado.Content = "Quantia Inválida";
            }
            
        }

        public Boolean canCalculaDobro(Object parameter)
        {
            //testa para ver se a text box está vazia e se tem apenas números int
            if(String.IsNullOrEmpty(parameter.ToString())) return false;
            if(int.TryParse(parameter.ToString(), out int result) ) return true;
            return false;
        }
        public void CalculaDobro(Object parameter)
        {
            Dobro dobro = (Dobro)main.frame.Content;
            int i = int.Parse(parameter.ToString());
            dobro.resultado.Content = (2*i).ToString();
        }

        public Boolean canNavegar(Object parameter)
        {
            if(String.IsNullOrEmpty(main.frame.Source.ToString())) return false;
            if(String.IsNullOrEmpty(parameter.ToString())) return false;
            String destino = parameter.ToString();
            String corrente = main.frame.Source.ToString();
            if(corrente.Contains(destino)) return false;

            return true;

        }

        MainWindow main = (MainWindow)App.Current.MainWindow;
        public void Navegar(Object parameter)
        {
            String destino = parameter.ToString();
            switch(destino)
            {
                case "Inicio":
                    main.frame.Source=new Uri("/Views/Inicio.xaml",UriKind.RelativeOrAbsolute);
                    break;
                case "JogoDados":
                    main.frame.Source = new Uri("/Views/JogoDados.xaml", UriKind.RelativeOrAbsolute);
                    break;
                case "Selos":
                    main.frame.Source = new Uri("/Views/Selos.xaml", UriKind.RelativeOrAbsolute);
                    break;
                case "Dobro":
                    main.frame.Source = new Uri("/Views/Dobro.xaml", UriKind.RelativeOrAbsolute);
                    break;
                default:
                    break;

            }
        }


        public Boolean canSair(Object parameter)
        {
            return true;
        }

        public void Sair(Object parameter)
        {
            App.Current.Shutdown();
        }
    }
}
