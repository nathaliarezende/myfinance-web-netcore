using myfinance_web_netcore.Infra;
using myfinance_web_netcore.Models;

namespace myfinance_web_netcore.Domain
{
    public class Transaction
    {
        public void Insert(TransactionModel form) 
        {
            var objDAL = DAL.getInstance;
            objDAL.Conect();

            var sql = "INSERT INTO TRANSACAO (DATA, VALOR, TIPO, HISTORICO, ID_PLANO_CONTA) " + 
                "VALUES (" +
                $"'{form.Date.ToString("yyyy-MM-dd")}'," +
                $"{form.Value}," +
                $"'{form.Type}'," +
                $"'{form.History}'," +
                $"{form.AccountPlanId})";
                
            objDAL.ExecuteSQLCommand(sql);
            objDAL.Disconnect();
        }

        public void Update(TransactionModel form)
        {
            var objDAL = DAL.getInstance;
            objDAL.Conect();
            var sql = $"UPDATE TRANSACAO SET " +
                $"Historico = '{form.History}'," +
                $"Tipo = '{form.Type}'," +
                $"Valor = {form.Value}," +
                $"Data = '{form.Date.ToString("yyyy-MM-dd")}'," +
                $"id_plano_conta = '{form.AccountPlanId}' " +
                $"WHERE id = {form.Id}";
            objDAL.ExecuteSQLCommand(sql);
            objDAL.Disconnect();
        }

        public void Delete(int id)
        {
            var objDAL = DAL.getInstance;
            objDAL.Conect();
            var sql = $"DELETE FROM TRANSACAO WHERE ID={id}";
            objDAL.ExecuteSQLCommand(sql);
            objDAL.Disconnect();
        }

        public TransactionModel LoadTransactionById(int? id) 
        {
            var objDAL = DAL.getInstance;
            objDAL.Conect();

            var sql = $"SELECT ID, DATA, VALOR, TIPO, HISTORICO, ID_PLANO_CONTA FROM TRANSACAO WHERE ID = {id}";
            var dataTable = objDAL.ReturnDataTable(sql);

            var transaction = new TransactionModel(){
                Id = int.Parse(dataTable.Rows[0]["ID"].ToString()),
                Date = DateTime.Parse(dataTable.Rows[0]["DATA"].ToString()),
                Value = decimal.Parse(dataTable.Rows[0]["VALOR"].ToString()),
                Type = dataTable.Rows[0]["TIPO"].ToString(),
                History = dataTable.Rows[0]["HISTORICO"].ToString(),
                AccountPlanId = int.Parse(dataTable.Rows[0]["ID_PLANO_CONTA"].ToString())
            };

            objDAL.Disconnect();
            return transaction;
        }

        public List<TransactionModel> ListTransactions() 
        {
            List<TransactionModel> list = new List<TransactionModel>();

            var objDAL = DAL.getInstance;
            objDAL.Conect();

            var sql = "SELECT ID, DATA, VALOR, TIPO, HISTORICO, ID_PLANO_CONTA FROM TRANSACAO";
            var dataTable = objDAL.ReturnDataTable(sql);

            for (int i=0; i < dataTable.Rows.Count; i++) 
            {
                var transaction = new TransactionModel(){
                    Id = int.Parse(dataTable.Rows[i]["ID"].ToString()),
                    Date = DateTime.Parse(dataTable.Rows[i]["DATA"].ToString()),
                    Value = decimal.Parse(dataTable.Rows[i]["VALOR"].ToString()),
                    Type = dataTable.Rows[i]["TIPO"].ToString(),
                    History = dataTable.Rows[i]["HISTORICO"].ToString(),
                    AccountPlanId = int.Parse(dataTable.Rows[i]["ID_PLANO_CONTA"].ToString())
                };

                list.Add(transaction);
            }
            objDAL.Disconnect();
            return list;
        }
    }
}