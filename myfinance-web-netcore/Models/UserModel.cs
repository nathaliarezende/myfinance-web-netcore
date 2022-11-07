using myfinance_web_netcore.Infra;

namespace myfinance_web_netcore.Models
{
    public class UserModel
    {
        public int? UserId { get; set; }
        public string? Name { get; set; }

        public void Insert()
        {
            var objDAL = DAL.getInstance;
            objDAL.Conect();
            var sql = $"INSERT INTO RESPONSAVEL (NOME) VALUES ('{Name}') ";
            objDAL.ExecuteSQLCommand(sql);
            objDAL.Disconnect();
        }

        public void Update(int? id)
        {
            var objDAL = DAL.getInstance;
            objDAL.Conect();
            var sql = $"UPDATE RESPONSAVEL SET " +
                $"Nome = '{Name}' " +
                $"WHERE id_responsavel = {id}";
            objDAL.ExecuteSQLCommand(sql);
            objDAL.Disconnect();
        }

        public void Delete(int id)
        {
            var objDAL = DAL.getInstance;
            objDAL.Conect();
            var sql = $"DELETE FROM RESPONSAVEL WHERE ID_RESPONSAVEL={id}";
            objDAL.ExecuteSQLCommand(sql);
            objDAL.Disconnect();
        }

        public UserModel LoadUserById(int? id) 
        {
            var objDAL = DAL.getInstance;
            objDAL.Conect();

            var sql = $"SELECT ID_RESPONSAVEL, NOME FROM RESPONSAVEL WHERE ID_RESPONSAVEL = {id}";
            var dataTable = objDAL.ReturnDataTable(sql);

            var user = new UserModel(){
                UserId = int.Parse(dataTable.Rows[0]["ID_RESPONSAVEL"].ToString()),
                Name = dataTable.Rows[0]["NOME"].ToString()
            };

            objDAL.Disconnect();
            return user;
        }

        public List<UserModel> List() 
        {
            List<UserModel> list = new List<UserModel>();

            var objDAL = DAL.getInstance;
            objDAL.Conect();

            var sql = "SELECT ID_RESPONSAVEL, NOME FROM RESPONSAVEL";
            var dataTable = objDAL.ReturnDataTable(sql);

            for (int i=0; i < dataTable.Rows.Count; i++) 
            {
                var User = new UserModel(){
                    UserId = int.Parse(dataTable.Rows[i]["ID_RESPONSAVEL"].ToString()),
                    Name = dataTable.Rows[i]["NOME"].ToString()
                };

                list.Add(User);
            }
            objDAL.Disconnect();
            return list;
        }
    }
}