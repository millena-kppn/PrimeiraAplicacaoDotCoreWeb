using System.Security.Cryptography.X509Certificates;
using MaxMind.Db;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Crypto.Digests;

namespace Service
{
    // This class is responsible for managing the database connection and operations.
    public class Db
    {
        private readonly MySqlConnection _con;
        private MySqlCommand? _command;
        private MySqlDataReader? _reader;
        // The constructor initializes the MySQL connection with the specified server address.
        public Db()
        {
            _con = new MySqlConnection("Server=127.0.0.1; Database=cadusuario06; Uid=root; Pwd=; SslMode=none");
        }
        // This method opens the database connection and retrieves a list of users from the "usuario" table.
        public List<UsuarioDTO> GetUsuarios()
        {
            _con.Open();
            _command = new MySqlCommand();
            _command.Connection = _con;
            _command.CommandText = "SELECT * FROM usuario";
            _reader = _command.ExecuteReader();
            // Initialize a list to hold the user data.
            List<UsuarioDTO> listaDeUsuarios = new List<UsuarioDTO>();

            // Read each record from the database and create a UsuarioDTO object for each user.
            while (_reader.Read())
            {
                // Create a new UsuarioDTO object and populate it with data from the database.
                var usuarioDTO = new UsuarioDTO
                {
                    id = int.Parse(_reader["Id"].ToString()!),
                    nome = _reader["Nome"].ToString()!,
                    sobrenome = _reader["Sobrenome"].ToString()!,
                    email = _reader["Email"].ToString()!
                };
                // Add the UsuarioDTO object to the list.
                listaDeUsuarios.Add(usuarioDTO);
            }

            _con.Close();

            return listaDeUsuarios;
        }
        public void AddUsuario(string nome, string sobrenome, string email)
        {
            _con.Open();
            _command = new MySqlCommand();
            _command.Connection = _con;
            _command.CommandText = "INSERT INTO usuario (Nome, Sobrenome, Email) VALUES (?nome, ?sobrenome, ?email)";
            _command.Parameters.Add("?nome", MySqlDbType.String).Value = nome;
            _command.Parameters.Add("?sobrenome", MySqlDbType.String).Value = sobrenome;
            _command.Parameters.Add("?email", MySqlDbType.String).Value = email;
            _command.ExecuteNonQuery();
            _con.Close();// para fechar a conexão

        }
    }
}
