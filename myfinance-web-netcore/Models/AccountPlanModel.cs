using myfinance_web_netcore.Infra;

namespace myfinance_web_netcore.Models
{
    public class AccountPlanModel
    {
        public int? Id { get; set; }
        public string? Description { get; set; }
        public string? Type { get; set; }

        public void Insert()
        {
            var objDAL = DAL.getInstance;
            objDAL.Conect();
            var sql = $"INSERT INTO PLANO_CONTAS (DESCRICAO, TIPO) VALUES ('{Description}','{Type}') ";
            objDAL.ExecuteSQLCommand(sql);
            objDAL.Disconnect();
        }

        public void Update(int? id)
        {
            var objDAL = DAL.getInstance;
            objDAL.Conect();
            var sql = $"UPDATE PLANO_CONTAS SET " +
                $"Descricao = '{Description}'," +
                $"Tipo = '{Type}' " +
                $"WHERE id = {id}";
            objDAL.ExecuteSQLCommand(sql);
            objDAL.Disconnect();
        }

        public void Delete(int id)
        {
            var objDAL = DAL.getInstance;
            objDAL.Conect();
            var sql = $"DELETE FROM PLANO_CONTAS WHERE ID={id}";
            objDAL.ExecuteSQLCommand(sql);
            objDAL.Disconnect();
        }

        public AccountPlanModel LoadAccountPlanById(int? id) 
        {
            var objDAL = DAL.getInstance;
            objDAL.Conect();

            var sql = $"SELECT ID, DESCRICAO, TIPO FROM PLANO_CONTAS WHERE ID = {id}";
            var dataTable = objDAL.ReturnDataTable(sql);

            var accountPlan = new AccountPlanModel(){
                Id = int.Parse(dataTable.Rows[0]["ID"].ToString()),
                Description = dataTable.Rows[0]["DESCRICAO"].ToString(),
                Type = dataTable.Rows[0]["TIPO"].ToString()
            };

            objDAL.Disconnect();
            return accountPlan;
        }

        public List<AccountPlanModel> List() 
        {
            List<AccountPlanModel> list = new List<AccountPlanModel>();

            var objDAL = DAL.getInstance;
            objDAL.Conect();

            var sql = "SELECT ID, DESCRICAO, TIPO FROM PLANO_CONTAS";
            var dataTable = objDAL.ReturnDataTable(sql);

            for (int i=0; i < dataTable.Rows.Count; i++) 
            {
                var accountPlan = new AccountPlanModel(){
                    Id = int.Parse(dataTable.Rows[i]["ID"].ToString()),
                    Description = dataTable.Rows[i]["DESCRICAO"].ToString(),
                    Type = dataTable.Rows[i]["TIPO"].ToString()
                };

                list.Add(accountPlan);
            }
            objDAL.Disconnect();
            return list;
        }
    }
}