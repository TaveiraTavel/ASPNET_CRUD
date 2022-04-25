using AppBancoDominio;
using AppBancoDLL;
using MySql.Data.MySqlClient;
using System;

namespace app1
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                // Menuzinho de seleção da ação
                Console.WriteLine("\nBem-vindo(a) ao Gerenciamento de Funcionários LIA" +
                             "\n\n Selecione uma ação para continuar:" +
                             "\n   [ 0 ] Visualizar todos os registros;" +
                             "\n   [ 1 ] Realizar novo cadastro;" +
                             "\n   [ 2 ] Deletar um registro;" +
                             "\n   [ 3 ] Atualizar um registro;\n");

                int sla = Convert.ToInt32(Console.ReadLine());

                var usuarioDAO = new UsuarioDAO();

                switch (sla)
                {
                    default:

                    case 0:
                        Console.WriteLine("\n");

                        // Listar Usuários <tb_liaUsuario>
                        var leitor = usuarioDAO.ListarUsuario();

                        foreach (var usuarios in leitor)
                        {
                            Console.WriteLine("======= USUÁRIO - ID: {0} =======\n"
                                              + "Nome: {1} \nCargo: {2} \nNascimento: {3}\n",
                                              usuarios.Id, usuarios.Nome, usuarios.Cargo, usuarios.DataNasc);
                        };
                        break;
                    case 1:
                        Console.WriteLine("\n");

                        // Inserir Usuário <tb_liaUsuario>
                        Console.WriteLine("Digite o nome do usuário:");
                        string vNome = Console.ReadLine();

                        Console.WriteLine("Digite o cargo do usuário:");
                        string vCargo = Console.ReadLine();

                        Console.WriteLine("Digite a data de nascimento do usuário");
                        string vDataNasc = Console.ReadLine();

                        var usuarioNovo = new Usuario
                        {
                            Id = 0,
                            Nome = vNome,
                            Cargo = vCargo,
                            DataNasc = DateTime.Parse(vDataNasc)
                        };

                        usuarioDAO.SalvarUsuario(usuarioNovo);

                        foreach (var usuarios in usuarioDAO.ListarUsuario())
                        {
                            Console.WriteLine("======= USUÁRIO - ID: {0} =======\n"
                                              + "Nome: {1} \nCargo: {2} \nNascimento: {3}\n",
                                              usuarios.Id, usuarios.Nome, usuarios.Cargo, usuarios.DataNasc);
                        };
                        break;
                    case 2:
                        Console.WriteLine("\n");

                        // Deletar Usuário <tb_liaUsuario>
                        Console.WriteLine("Digite o ID do usuário:");
                        int vId = Convert.ToInt32(Console.ReadLine());

                        var usuarioExcluir = new Usuario
                        {
                            Id = 6
                        };

                        usuarioDAO.ExcluirUsuario(vId);

                        foreach (var usuarios in usuarioDAO.ListarUsuario())
                        {
                            Console.WriteLine("======= USUÁRIO - ID: {0} =======\n"
                                              + "Nome: {1} \nCargo: {2} \nNascimento: {3}\n",
                                              usuarios.Id, usuarios.Nome, usuarios.Cargo, usuarios.DataNasc);
                        };
                        break;
                    case 3:
                        Console.WriteLine("\n");

                        // Alterar Usuário <tb_liaUsuario>
                        Console.WriteLine("Digite o ID do usuário:");
                        int vIdAlt = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Digite o novo nome:");
                        string vNomeAlt = Console.ReadLine();

                        Console.WriteLine("Digite o novo cargo:");
                        string vCargoAlt = Console.ReadLine();

                        Console.WriteLine("Digite a nova data de nascimento:");
                        string vDataNascAlt = Console.ReadLine();
                        

                        var usuarioAlterado = new Usuario
                        {
                            Id = vIdAlt,
                            Nome = vNomeAlt,
                            Cargo = vCargoAlt,
                            DataNasc = DateTime.Parse(vDataNascAlt)
                        };

                        usuarioDAO.AtualizarUsuario(usuarioAlterado);

                        foreach (var usuarios in usuarioDAO.ListarUsuario())
                        {
                            Console.WriteLine("======= USUÁRIO - ID: {0} =======\n"
                                              + "Nome: {1} \nCargo: {2} \nNascimento: {3}\n",
                                              usuarios.Id, usuarios.Nome, usuarios.Cargo, usuarios.DataNasc);
                        };
                        break;
                }


                Console.WriteLine("\nDeseja continuar? [qualquer tecla/N]");
                string vContinuar = Console.ReadLine();

                if (vContinuar == "N")
                {
                    break;
                }

            }
            
        }
    }
}
