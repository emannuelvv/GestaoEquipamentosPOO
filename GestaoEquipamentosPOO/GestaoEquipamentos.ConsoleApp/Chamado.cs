using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoEquipamentos.ConsoleApp
{
    class Chamado
    {
        private int idChamado, idEquipamentoChamado,quantidadeChamado;
        private string titulosChamado, descricoesChamado;
        private DateTime dataAberturaChamado;
        static Chamado[] listaChamado = new Chamado[100];
        Equipamento equipamento = new Equipamento();
        Menu menu = new Menu();
        public void RegistrarChamado()
        {
            Console.Clear();
            Chamado chamado = new Chamado();

            int posicao = ObterPosicaoParaChamados();

            equipamento.VisualizarEquipamentos();

            Console.Write("Digite o Id do equipamento para manutenção: ");
            chamado.idEquipamentoChamado = Convert.ToInt32(Console.ReadLine());

            Console.Write("Digite o titulo do chamado: ");
            chamado.titulosChamado = Console.ReadLine();

            Console.Write("Digite a descricao do chamado: ");
            chamado.descricoesChamado = Console.ReadLine();

            Console.Write("Digite a data de abertura do chamado: ");
            chamado.dataAberturaChamado = Convert.ToDateTime(Console.ReadLine());

            chamado.idChamado = posicao;

            listaChamado[posicao] = chamado;
            quantidadeChamado++;
        }
        public void EditorDeChamado(int idChamado)
        {
            Console.Clear();
            Chamado chamadoEditor = new Chamado();

            equipamento.VisualizarEquipamentos();

            Console.Write("Digite o Id do equipamento para manutenção: ");
            chamadoEditor.idEquipamentoChamado = Convert.ToInt32(Console.ReadLine());

            Console.Write("Digite o titulo do chamado: ");
            chamadoEditor.titulosChamado = Console.ReadLine();

            Console.Write("Digite a descricao do chamado: ");
            chamadoEditor.descricoesChamado = Console.ReadLine();

            Console.Write("Digite a data de abertura do chamado: ");
            chamadoEditor.dataAberturaChamado = Convert.ToDateTime(Console.ReadLine());

            listaChamado[idChamado] = chamadoEditor;
        }
        public int ObterPosicaoParaChamados()
        {
            int posicao = 0;

            for (int i = 0; i < listaChamado.Length; i++)
            {
                if (listaChamado[i] == null) //posição livre...
                {
                    posicao = i; break;
                }
            }

            return posicao;
        }
        private void CabecalhoChamado()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("{0,-10} | {1,-30} | {2,-55} | {3,-25}", "Id", "Equipamento", "Título", "Dias em Aberto");
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");
            Console.ResetColor();
        }
        public void VisualizarChamados()
        {
            CabecalhoChamado();
            if (listaChamado != null)
            {
                for (int i = 0; i < quantidadeChamado; i++)

                {
                    string nomeEquipamento = equipamento.RetornaNomeEquipamento(listaChamado[i].idEquipamentoChamado);

                    TimeSpan diasEmAberto = DateTime.Now - listaChamado[i].dataAberturaChamado;

                    Console.Write("{0,-10} | {1,-30} | {2,-55} | {3,-25}",
                       listaChamado[i].idChamado,
                       nomeEquipamento,
                       listaChamado[i].titulosChamado,
                       diasEmAberto.ToString("dd"));
                }
                Console.WriteLine();
            }
            else
                menu.mensagemErro("Nenhum chamado registrado!");

            Console.ReadLine();

        }
        public void EditarChamado()
        {
            Console.Clear();

            VisualizarChamados();

            Console.WriteLine();

            Console.Write("Digite o número do chamado que deseja editar: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            EditorDeChamado(idSelecionado);
        }
        public void ExcluirChamado()
        {
            Console.Clear();

            VisualizarChamados();

            Console.WriteLine();

            Console.Write("Digite o número do chamado que deseja excluir: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            listaChamado[idSelecionado] = null;
            quantidadeChamado--;
        }

    }


}

