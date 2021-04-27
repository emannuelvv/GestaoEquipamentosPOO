using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoEquipamentos.ConsoleApp
{
    class Equipamento
    {
        private string nomeEquipamento, numeroSerieEquipamento, fabricanteEquipamento;
        private double precoEquipamento;
        private int idEquipamento, quantidadeEquipamento;
        private DateTime dataFabricacaoEquipamento;
        static Equipamento[] listaEquipamento = new Equipamento[100];
        Menu menu = new Menu();

        public string RetornaNomeEquipamento(int idEquipamento)
        {
            string nomeEquipamento = listaEquipamento[idEquipamento].nomeEquipamento; ;

            return nomeEquipamento;
        }

        private void EditorDeEquipamento(int posicao)
        {
            Equipamento equipamento = new Equipamento();
            bool nomeInvalido = false;
            do
            {
                Console.Write("Digite o nome do equipamento: ");
                equipamento.nomeEquipamento = Console.ReadLine();
                if (equipamento.nomeEquipamento.Length < 6)
                {
                    nomeInvalido = true;
                    menu.mensagemErro("Nome inválido. No mínimo 6 caracteres");
                }
                else
                    nomeInvalido = false;

            } while (nomeInvalido);


            Console.Write("Digite o preço do equipamento: ");
            equipamento.precoEquipamento = Convert.ToDouble(Console.ReadLine());

            Console.Write("Digite o número de série do equipamento: ");
            equipamento.numeroSerieEquipamento = Console.ReadLine();

            Console.Write("Digite a data de fabricação do equipamento: ");
            equipamento.dataFabricacaoEquipamento = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Digite o fabricante do equipamento: ");
            equipamento.fabricanteEquipamento = Console.ReadLine();

            equipamento.idEquipamento = posicao;

            listaEquipamento[posicao] = equipamento;
        }
        public void ExcluirEquipamento()
        {
            Console.Clear();

            VisualizarEquipamentos();

            Console.WriteLine();

            Console.Write("Digite o número do equipamento que deseja excluir: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < listaEquipamento.Length; i++)
            {
                if (listaEquipamento[i].idEquipamento == idSelecionado)
                {
                    listaEquipamento[i] = null;
                    quantidadeEquipamento--;
                    break;
                }
            }
        }
        public void RegistrarEquipamento()
        {
            Console.Clear();
            Equipamento equipamento = new Equipamento();
            int posicao = ObterPosicaoParaEquipamentos();
            bool nomeInvalido = false;
            do
            {
                Console.Write("Digite o nome do equipamento: ");
                equipamento.nomeEquipamento = Console.ReadLine();
                if (equipamento.nomeEquipamento.Length < 6)
                {
                    nomeInvalido = true;
                    menu.mensagemErro("Nome inválido. No mínimo 6 caracteres");
                }
                else
                    nomeInvalido = false;

            } while (nomeInvalido);


            Console.Write("Digite o preço do equipamento: ");
            equipamento.precoEquipamento = Convert.ToDouble(Console.ReadLine());

            Console.Write("Digite o número de série do equipamento: ");
            equipamento.numeroSerieEquipamento = Console.ReadLine();

            Console.Write("Digite a data de fabricação do equipamento: ");
            equipamento.dataFabricacaoEquipamento = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Digite o fabricante do equipamento: ");
            equipamento.fabricanteEquipamento = Console.ReadLine();

            equipamento.idEquipamento = posicao;

            listaEquipamento[posicao] = equipamento;
            quantidadeEquipamento++;
        }
        public void EditarEquipamento()
        {
            Console.Clear();

            VisualizarEquipamentos();

            Console.WriteLine();

            Console.Write("Digite o número do equipamento que deseja editar: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            EditorDeEquipamento(idSelecionado);
        }
        public void VisualizarEquipamentos()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("{0,-10} | {1,-55} | {2,-35}", "Id", "Nome", "Fabricante");
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");
            Console.ResetColor();

            for (int i = 0; i < listaEquipamento.Length; i++)
            {
                if (listaEquipamento[i] != null)
                {
                    Console.Write("{0,-10} | {1,-55} | {2,-35}",
                       listaEquipamento[i].idEquipamento, listaEquipamento[i].nomeEquipamento, listaEquipamento[i].fabricanteEquipamento);

                    Console.WriteLine();
                }
            }

            if (listaEquipamento == null)
                menu.mensagemErro("Nenhum equipmaneto cadastrado!");


            Console.ReadLine();
        }
        public int ObterPosicaoParaEquipamentos()
        {
            int posicao = 0;

            for (int i = 0; i < listaEquipamento.Length; i++)
            {
                if (listaEquipamento[i] == null) //posição livre...
                {
                    posicao = i;
                    break;
                }
            }

            return posicao;
        }

    }
}
