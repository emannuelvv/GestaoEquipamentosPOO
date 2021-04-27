using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoEquipamentos.ConsoleApp
{
    class Menu
    {
        public void mensagemErro(string mensagem)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(mensagem);
            Console.ResetColor(); ;
        }
        public string ObterOpcaoCadastroEquipamentos()
        {
            Console.WriteLine("Digite 1 para inserir novo equipamento");
            Console.WriteLine("Digite 2 para visualizar equipamentos");
            Console.WriteLine("Digite 3 para editar um equipamento");
            Console.WriteLine("Digite 4 para excluir um equipamento");

            Console.WriteLine("Digite S para sair");

            string opcao = Console.ReadLine();

            return opcao;
        }
        public string ObterMenuPrincipal()
        {
            Console.WriteLine("Digite 1 para o Cadastro de Equipamentos");
            Console.WriteLine("Digite 2 para o Controle de Chamados");

            Console.WriteLine("Digite S para Sair");

            string opcao = Console.ReadLine();
            return opcao;
        }
        public string ObterOpcaoControleChamados()
        {
            Console.WriteLine("Digite 1 para inserir novo chamado");
            Console.WriteLine("Digite 2 para visualizar chamados");
            Console.WriteLine("Digite 3 para editar um chamado");
            Console.WriteLine("Digite 4 para excluir um chamado");

            Console.WriteLine("Digite S para sair");

            string opcao = Console.ReadLine();

            return opcao;
        }
        public bool EhOpcaoSair(string opcao)
        {
            return opcao.Equals("s", StringComparison.OrdinalIgnoreCase);
        }
        public bool EhOpcaoInvalidaMenuPrincipal(string opcao)
        {
            return opcao != "1" && opcao !="2";
        }
        public bool EhOpcaoInvalidaSubMenu(string opcao)
        {
            return opcao != "1" && opcao != "2" && opcao != "3" && opcao != "4";
        }
    }
}
